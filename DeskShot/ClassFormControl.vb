Public Class ClassFormControl
    Private Declare Function SendMessage Lib "User32.dll" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Long
    Private Declare Sub ReleaseCapture Lib "User32.dll" ()

    Const WM_NCLBUTTONDOWN = &HA1
    Const HTCAPTION = 2
    Dim _TargetForm As Form = Nothing
    Dim _Opacity As Double = 1
    Dim _Enable As Boolean = True
    Dim _OpacityPause As Boolean = False
    Dim _FadeOut As Boolean = True
    Dim _Lock As Boolean = False
    Property TargetForm() As Form
        Get
            Return _TargetForm
        End Get
        'Set(ByVal value As FrmMain)
        Set(ByVal value As Form)
            _TargetForm = value
            AddHandler _TargetForm.MouseMove, AddressOf FormMouseMove
            AddHandler _TargetForm.MouseHover, AddressOf FormMouseHover
            'AddHandler _TargetForm.MouseLeave, AddressOf FormMouseLeave
            AddHandler _TargetForm.Click, AddressOf FrmFusenClick
        End Set
    End Property

    Public Sub AddButtonIcon(ByVal Obj As PictureBox)
        AddHandler Obj.MouseMove, AddressOf FormMouseMove
        AddHandler Obj.MouseHover, AddressOf FormMouseHover
        'AddHandler Obj.MouseLeave, AddressOf FormMouseLeave
    End Sub
    Public Sub AddButtonIcon(ByVal Obj As Panel)
        AddHandler Obj.MouseMove, AddressOf FormMouseMove
        AddHandler Obj.MouseHover, AddressOf FormMouseHover
        'AddHandler Obj.MouseLeave, AddressOf FormMouseLeave
    End Sub
    Public Event FormSizeClicked(ByVal SelectMode As Boolean)
    Private Sub FrmFusenClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call FormMouseHover(Nothing, Nothing)
        If My.Computer.Keyboard.CtrlKeyDown Then
            'If IsNothing(_SizeParent) Then
            '    _SizeParent = _TargetForm
            'Else
            '    If _TargetForm.Tag <> _SizeParent.Tag Then
            '        For Each FR As FrmFusen In _SizeChild
            '            If FR.Tag = _TargetForm.Tag Then
            '                Return
            '            End If
            '        Next
            '        _SizeChild.Add(_TargetForm)
            '    End If
            'End If
            'RaiseEvent FormSizeClicked(True)
        Else
            RaiseEvent FormSizeClicked(False)
        End If
    End Sub
    Property Opacity() As Double
        Get
            Return _Opacity
        End Get
        Set(ByVal value As Double)
            _Opacity = value
        End Set
    End Property
    Property Lock As Boolean
        Get
            Return _Lock
        End Get
        Set(value As Boolean)
            _Lock = value
        End Set
    End Property
    Property UseFadeOut() As Boolean
        Get
            Return _FadeOut
        End Get
        Set(ByVal value As Boolean)
            _FadeOut = value
        End Set
    End Property
    Public Sub OpacityPause()
        _OpacityPause = True
        _TargetForm.Opacity = 1
    End Sub
    Property Enable() As Boolean
        Get
            Return _Enable
        End Get
        Set(ByVal value As Boolean)
            _Enable = value
            If Not _Enable Then
                _TargetForm.Opacity = 1
            Else
                _TargetForm.Opacity = _Opacity
            End If
        End Set
    End Property
    Dim _MouseEdge As System.Drawing.ContentAlignment = ContentAlignment.MiddleCenter
    Public Event FormMoved()

    Private Sub FormMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Select Case e.Button
            Case MouseButtons.Left
                If _MouseEdge = ContentAlignment.MiddleCenter Then
                    Call ReleaseCapture()
                    Call SendMessage(_TargetForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0&)
                Else
                    Call FormSizeChange()
                End If
                RaiseEvent FormMoved()
            Case MouseButtons.Right
            Case MouseButtons.None
                Call MouseFlg()
        End Select

    End Sub
    Private Sub FormMouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        '_TimerFadeWait.Enabled = False
        '_TimerFade.Enabled = False
        '_TargetForm.Opacity = 1
        _OpacityPause = False
    End Sub
    '#Region "フェードアウト"
    '    Dim WithEvents _TimerFadeWait As New Timer
    '    Dim WithEvents _TimerFade As New Timer
    '    Dim WithEvents _TimerFadeVisible As New Timer
    '    Private Sub FormMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        If _Enable Then
    '            If _FadeOut Then
    '                _TimerFadeWait.Interval = 500
    '                _TimerFadeWait.Enabled = True
    '            Else

    '                _TargetForm.Opacity = _Opacity
    '            End If
    '        End If
    '    End Sub
    '    Private Sub _TimerFadeWait_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TimerFadeWait.Tick
    '        '_TargetForm.Opacity = _Opacity
    '        _TimerFadeWait.Enabled = False

    '        _TimerFade.Interval = 10
    '        _TimerFade.Enabled = True
    '    End Sub
    '    Public Sub FusenFadeOut()
    '        _TargetForm.Opacity = 1
    '        _TimerFade.Interval = 10
    '        _TimerFade.Enabled = True
    '    End Sub
    '    Private Sub _TimerFade_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TimerFade.Tick
    '        Dim _Span As Single = 0.01
    '        If _TargetForm.Opacity - _Span < _Opacity Then
    '            _TargetForm.Opacity = _Opacity
    '            _TimerFade.Enabled = False
    '        Else
    '            _TargetForm.Opacity -= _Span
    '        End If
    '    End Sub
    '    Public Sub FusenFadeDelete()
    '        Call FormBottomMostClear(_TargetForm) '最背面を解除する
    '        Dim _Span As Single = 0.02
    '        '_TargetForm.Opacity = (CInt(_TargetForm.Opacity * 100)) / 100
    '        For i As Single = _TargetForm.Opacity To 0 Step -_Span
    '            _TargetForm.Opacity = i
    '            '_TargetForm.Opacity -= _Span
    '            System.Threading.Thread.Sleep(10)
    '        Next
    '        '_TargetForm.Opacity = 1
    '    End Sub

    '    Dim _TimerFadeVisibleMode As Boolean = False
    '    Public Sub FunseVisible(ByVal Mode As Boolean)
    '        _TimerFadeVisibleMode = Mode
    '        _TimerFadeVisible.Interval = 10
    '        _TimerFadeVisible.Enabled = True
    '    End Sub
    '    Private Sub _TimerFadeVisible_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _TimerFadeVisible.Tick
    '        Dim _Span As Single = 0.02
    '        If Not _TimerFadeVisibleMode Then
    '            If _TargetForm.Opacity - _Span < 0 Then
    '                _TargetForm.Opacity = 0
    '                _TimerFadeVisible.Enabled = False
    '                _TargetForm.Visible = False
    '            Else
    '                _TargetForm.Opacity -= _Span
    '            End If
    '        Else
    '            If _TargetForm.Opacity + _Span > _Opacity Then
    '                _TargetForm.Opacity = _Opacity
    '                _TimerFadeVisible.Enabled = False
    '            Else
    '                _TargetForm.Visible = True
    '                _TargetForm.Opacity += _Span
    '            End If
    '        End If

    '    End Sub

    '#End Region
    Private Sub FormSizeChange()
        If Not _Lock Then
            With _TargetForm
                Dim MouseX As Integer = System.Windows.Forms.Cursor.Position.X
                Dim MouseY As Integer = System.Windows.Forms.Cursor.Position.Y
                Dim FormTopLeftX As Integer = .Location.X
                Dim FormTopLeftY As Integer = .Location.Y
                Dim FormBottomRightX As Integer = FormTopLeftX + .Width
                Dim FormBottomRightY As Integer = FormTopLeftY + .Height

                Select Case _MouseEdge
                    Case ContentAlignment.TopLeft
                        .Location = New Point(MouseX, MouseY)
                        .Size = New Size(FormBottomRightX - MouseX, FormBottomRightY - MouseY)
                    Case ContentAlignment.TopCenter
                        .Location = New Point(FormTopLeftX, MouseY)
                        .Size = New Size(.Width, FormBottomRightY - MouseY)
                    Case ContentAlignment.TopRight
                        .Location = New Point(FormTopLeftX, MouseY)
                        .Size = New Size(MouseX - FormTopLeftX, FormBottomRightY - MouseY)

                    Case ContentAlignment.MiddleLeft
                        .Location = New Point(MouseX, FormTopLeftY)
                        .Size = New Size(FormBottomRightX - MouseX, .Height)
                    Case ContentAlignment.MiddleRight
                        .Size = New Size(MouseX - FormTopLeftX, .Height)

                    Case ContentAlignment.BottomLeft
                        .Location = New Point(MouseX, FormTopLeftY)
                        .Size = New Size(FormBottomRightX - MouseX, MouseY - FormTopLeftY)
                    Case ContentAlignment.BottomCenter
                        .Size = New Size(.Width, MouseY - FormTopLeftY)
                    Case ContentAlignment.BottomRight

                        .Size = New Size(MouseX - FormTopLeftX, MouseY - FormTopLeftY)
                End Select

            End With
        End If
    End Sub
    Const _EdgeWidth As Integer = 5 'フォーム選択エッジの余白
    Private Sub MouseFlg()
        Dim X As Integer = _TargetForm.PointToClient(System.Windows.Forms.Cursor.Position).X
        Dim Y As Integer = _TargetForm.PointToClient(System.Windows.Forms.Cursor.Position).Y
        Select Case X
            Case Is < _EdgeWidth
                Select Case Y
                    Case Is < _EdgeWidth
                        _MouseEdge = ContentAlignment.TopLeft
                        _TargetForm.Cursor = Cursors.SizeNWSE
                    Case Is > _TargetForm.Height - _EdgeWidth
                        _MouseEdge = ContentAlignment.BottomLeft
                        _TargetForm.Cursor = Cursors.SizeNESW
                    Case Else
                        _MouseEdge = ContentAlignment.MiddleLeft
                        _TargetForm.Cursor = Cursors.SizeWE
                End Select
            Case Is > _TargetForm.Width - _EdgeWidth
                Select Case Y
                    Case Is < _EdgeWidth
                        _MouseEdge = ContentAlignment.TopRight
                        _TargetForm.Cursor = Cursors.SizeNESW
                    Case Is > _TargetForm.Height - _EdgeWidth
                        _MouseEdge = ContentAlignment.BottomRight
                        _TargetForm.Cursor = Cursors.SizeNWSE
                    Case Else
                        _MouseEdge = ContentAlignment.MiddleRight
                        _TargetForm.Cursor = Cursors.SizeWE
                End Select
            Case Else
                Select Case Y
                    Case Is < _EdgeWidth
                        _MouseEdge = ContentAlignment.TopCenter
                        _TargetForm.Cursor = Cursors.SizeNS
                    Case Is > _TargetForm.Height - _EdgeWidth
                        _MouseEdge = ContentAlignment.BottomCenter
                        _TargetForm.Cursor = Cursors.SizeNS
                    Case Else
                        _MouseEdge = ContentAlignment.MiddleCenter
                        _TargetForm.Cursor = Cursors.Default
                End Select
        End Select

    End Sub



End Class
