Public Class FrmSnapMouse
    Dim _BaseFolder As String = ""
    Dim _DefSize As Size = New Size(200, 200)
    Dim _ShotMode As WorkModeClass.enumWorkMode
    Dim _WorkScreenNo As Integer
#Region "Property"
    ''' <summary>
    ''' 保存先フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property BaseFolder As String
        Get
            Return _BaseFolder
        End Get
        Set(value As String)
            _BaseFolder = value
        End Set
    End Property
    ''' <summary>
    ''' キャプチャサイズ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShotSize As Size
        Get
            Return _DefSize
        End Get
        Set(value As Size)
            _DefSize = value
        End Set
    End Property
    ''' <summary>
    ''' キャプチャモード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShotMode As WorkModeClass.enumWorkMode
        Get
            Return _ShotMode
        End Get
        Set(value As WorkModeClass.enumWorkMode)
            _ShotMode = value
        End Set
    End Property
    ''' <summary>
    ''' キャプチャ対象スクリーン
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property WorkScreenNo As Integer
        Get
            Return _WorkScreenNo
        End Get
        Set(value As Integer)
            _WorkScreenNo = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSnapMouse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSnapMouse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        GcGlobalHook1.EnableMouseHook = False
        GcGlobalHook1.EnableKeyboardHook = False

        If _ReSized Then
            If ReadReg("General", "MouseShot_UserSizeSave", enum_Type.er_Boolean) = True Then
                Call WriteReg("General", "MouseShot_Width", Panel1.Size.Width)
                Call WriteReg("General", "MouseShot_Height", Panel1.Size.Height)
            End If
        End If

    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSnapMouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _IsSizeUse As Boolean = ReadReg("General", "MouseShot_UseSize", enum_Type.er_Boolean)
        Dim _MCW As Integer = ReadReg("General", "MouseShot_Width", enum_Type.er_Integer)
        Dim _MCH As Integer = ReadReg("General", "MouseShot_Height", enum_Type.er_Integer)

        If _IsSizeUse Then
            If _MCW > 10 AndAlso _MCH > 10 Then
                Panel1.Size = New Size(_MCW - 2, _MCH - 2)
            Else
                Panel1.Size = New Size(_DefSize.Width - 2, _DefSize.Height - 2)
            End If
        Else
            Panel1.Size = New Size(_DefSize.Width - 2, _DefSize.Height - 2)
        End If

        If _WorkScreenNo = -1 Then
            Me.MaximizedBounds = Screen.AllScreens(0).Bounds
        Else
            Me.MaximizedBounds = Screen.AllScreens(_WorkScreenNo).Bounds
        End If

        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = True
        Me.KeyPreview = True
        Me.Opacity = 0.7
        Panel1.Location = New Point(0, 0)

        GcGlobalHook1.EnableKeyboardHook = True
        GcGlobalHook1.EnableMouseHook = True

        'Label1.Text = String.Format("サイズ:{0}x{1}", _DefSize.Width, _DefSize.Height)
    End Sub
    Dim _IsResize As Boolean = False
    Dim _ReSized As Boolean = False
    ''' <summary>
    ''' キーダウン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_KeyDown(sender As Object, e As KeyEventArgs) Handles GcGlobalHook1.KeyDown

        If e.Control AndAlso e.Shift Then
            'Crtl+Shitでサイズ変更モード
            Dim _X As Integer = Panel1.Location.X + Panel1.Size.Width
            Dim _Y As Integer = Panel1.Location.Y + Panel1.Size.Height
            Cursor.Position = New Point(_X, _Y)
            _IsResize = True
        Else

            Select Case e.KeyCode
                Case Keys.Escape 'ESCキー
                    Me.Close()
                Case Keys.PrintScreen
                    Call ScreenCaptuer() 'キャプチャー
            End Select
        End If
    End Sub
    ''' <summary>
    ''' キーアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_KeyUp(sender As Object, e As KeyEventArgs) Handles GcGlobalHook1.KeyUp
        Dim _X As Integer = Panel1.Location.X + (Panel1.Size.Width / 2)
        Dim _Y As Integer = Panel1.Location.Y + (Panel1.Size.Height / 2)
        Cursor.Position = New Point(_X, _Y)
        _IsResize = False
    End Sub
    ''' <summary>
    ''' マウスダウン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_MouseDown(sender As Object, e As HandledMouseEventArgs) Handles GcGlobalHook1.MouseDown
        If Not _IsResize Then
            If e.Button = Windows.Forms.MouseButtons.Middle Then
                Call ScreenCaptuer() 'キャプチャー
            End If
        End If
    End Sub
    ''' <summary>
    ''' マウスムーブ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_MouseMove(sender As Object, e As HandledMouseEventArgs) Handles GcGlobalHook1.MouseMove
        If Not _IsResize Then
            'ウィンドウ移動モード
            Dim X As Integer = e.Location.X - (Panel1.Size.Width / 2)
            Dim Y As Integer = e.Location.Y - (Panel1.Size.Height / 2)
            Panel1.Location = New Point(X, Y)
        Else
            'サイズ変更モード
            Dim X As Integer = e.Location.X - Panel1.Location.X
            Dim Y As Integer = e.Location.Y - Panel1.Location.Y
            Panel1.Size = New Size(X, Y)
            _ReSized = True
        End If
    End Sub
    ''' <summary>
    ''' 画面キャプチャー
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenCaptuer()
        Try
            Dim bmp As New Bitmap(Panel1.Size.Width - 2, Panel1.Size.Height - 2)
            Using g As Graphics = Graphics.FromImage(bmp)
                'g.CopyFromScreen(New Point(e.X - (_DefSize.Width / 2), e.Y - (_DefSize.Height / 2)), New Point(0, 0), bmp.Size)
                g.CopyFromScreen(New Point(Panel1.Location), New Point(0, 0), bmp.Size)
            End Using

            Dim _FileName As String = ""
            Select Case _ShotMode
                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.bmp", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    bmp.Save(_FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                Case WorkModeClass.enumWorkMode.PictureSave_JPEG
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.jpg", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    bmp.Save(_FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case WorkModeClass.enumWorkMode.PictureSave_PNG
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.png", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    bmp.Save(_FileName, System.Drawing.Imaging.ImageFormat.Png)
                Case WorkModeClass.enumWorkMode.PictureSaveClipbord
                    Clipboard.SetDataObject(bmp, True)
            End Select
            Label2.Text = "キャプチャー完了"

        Catch ex As Exception
            Label2.Text = "キャプチャーエラー"
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Label2.Text = "マウス中:キャプチャ ESC:終了"
    End Sub
End Class