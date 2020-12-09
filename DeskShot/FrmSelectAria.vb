Public Class FrmSelectAria

    Dim Flg As Boolean = False
    Dim P1 As Point

    Dim _RetPoint As Point
    Dim _RetSize As Size
    Dim _WorkScreenNo As Integer
    ''' <summary>
    ''' 選択位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectPosition As Point
        Get
            Return _RetPoint
        End Get
    End Property
    ''' <summary>
    ''' 選択サイズ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectSize As Size
        Get
            Return _RetSize
        End Get
    End Property
    ''' <summary>
    ''' 対象スクリーン番号
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
    Private Sub FrmSelectAria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmSelectAria_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmSelectAria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Panel1.Size = New Size(0, 0)
    End Sub

    Private Sub FrmSelectAria_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            P1 = e.Location
            Panel1.Location = P1
            Panel1.Size = New Size(0, 0)
            Flg = True
        End If
    End Sub

    Private Sub FrmSelectAria_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If Flg Then
            Panel1.Size = New Size(e.Location.X - P1.X, e.Location.Y - P1.Y)
        End If
    End Sub

    Private Sub FrmSelectAria_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If Flg Then
            _RetPoint = Panel1.Location
            _RetSize = Panel1.Size
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

 
End Class