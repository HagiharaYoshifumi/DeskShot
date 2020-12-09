Imports System
Imports System.Runtime.InteropServices
Public Class FrmMain
    Dim _FLG As Boolean = True
#Region "FORM"
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        GcGlobalHook1.StopKeyboardHook()
        GcGlobalHook1.StopMouseHook()
        Application.Exit()
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GcGlobalHook1.StartKeyboardHook()
        GcGlobalHook1.StartMouseHook()
        Panel2.Anchor = AnchorStyles.Left And AnchorStyles.Top
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
#End Region

    ''' <summary>
    ''' クリップボードへ画像を転送
    ''' </summary>
    ''' <param name="BMPData"></param>
    ''' <remarks></remarks>
    Private Sub PictureClipbord(BMPData As Bitmap)
        Try
            Clipboard.SetDataObject(BMPData, True)
            Label1.Text = "クリップボード転送"
        Catch ex As Exception
            Label1.Text = "クリップボード転送失敗"
        End Try
    End Sub
    ''' <summary>
    ''' 画面をクリップ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPicture() As Bitmap
        Try
            Dim P As Point = Panel1.PointToScreen(New Point(0, 0))

            Me.Cursor = New Cursor(Cursor.Current.Handle)
            Dim curPoint As Point = Cursor.Position
            Dim hotSpot As Point = Me.Cursor.HotSpot
            Dim position As Point = New Point((curPoint.X - hotSpot.X), (curPoint.Y - hotSpot.Y))

            'Dim bmp As New Bitmap(PictureBox1.Width - 2, PictureBox1.Height - 2, Drawing.Imaging.PixelFormat.Format48bppRgb)
            Dim bmp As New Bitmap(Panel1.Width - 2, Panel1.Height - 2)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.CopyFromScreen(New Point(P.X, P.Y), New Point(0, 0), bmp.Size)
                Me.Cursor.Draw(g, New Rectangle(New Point(position.X - P.X, position.Y - P.Y), Me.Cursor.Size))
            End Using

            Return bmp
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' ウィンドウフィット
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DiarogFit()
        'GcGlobalHook1.StopKeyboardHook()
        'GcGlobalHook1.StopMouseHook()

        Me.TopMost = False
        Me.WindowState = FormWindowState.Minimized
        Application.DoEvents()

        'アクティブなウィンドウのデバイスコンテキストを取得
        Dim hWnd As IntPtr = GetForegroundWindow()
        Dim winDC As IntPtr = GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New RECT
        'GetWindowRect(hWnd, winRect)
        Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
        DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)

        Dim _W As Integer = winRect.right - winRect.left + 10
        Dim _H As Integer = winRect.bottom - winRect.top + 10

        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = True

        Panel2.Location = New Point(winRect.left - 5, winRect.top - 5)
        Panel2.Size = New Size(_W, _H)

        ReleaseDC(hWnd, winDC)
    End Sub
    ''' <summary>
    ''' キーボードフック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_KeyDown(sender As Object, e As KeyEventArgs) Handles GcGlobalHook1.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Application.Exit()
            Case Keys.Pause
                If Me.Visible Then
                    Call DiarogFit()
                End If
            Case Keys.Return
                If Me.Visible Then
                    Call PictureClipbord(GetPicture())
                End If
            Case Keys.PrintScreen
                Me.Visible = Not Me.Visible
            Case Keys.Down
                If IsOnKey_Control() Then
                    If Me.Opacity > 0.5 Then
                        Me.Opacity -= 0.05
                        Label1.Text = String.Format("透過率：{0}%", CInt((1 - Me.Opacity) * 100))
                    End If
                End If
            Case Keys.Up
                If IsOnKey_Control() Then
                    If Me.Opacity < 1 Then
                        Me.Opacity += 0.05
                        Label1.Text = String.Format("透過率：{0}%", CInt((1 - Me.Opacity) * 100))
                    End If
                End If
        End Select
        If Not _FLG Then
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' マウスフック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_MouseMove(sender As Object, e As HandledMouseEventArgs) Handles GcGlobalHook1.MouseMove
        If Not IsOnKey_Control() AndAlso Not IsOnKey_Alt() Then
            If RectPosition(e.Location, Panel2.Location, Panel2.Size) = ContentAlignment.MiddleCenter Then
                Label1.Text = "状態：枠内"
                _FLG = True
            Else
                Label1.Text = "状態：枠外"
                _FLG = False
            End If
        End If

        If _FLG Then
            Select Case True
                Case IsOnKey_Control()
                    Label1.Text = "状態：枠移動中"
                    Panel2.Location = New Point(e.X + 5, e.Y + 5)
                Case IsOnKey_Alt()
                    Label1.Text = "状態：枠リサイズ中"
                    Panel2.Size = New Size(e.X - Panel2.Location.X - 3, e.Y - Panel2.Location.Y - 3)
            End Select
        End If
    End Sub
    ''' <summary>
    ''' コントロールキーを押されているか？
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsOnKey_Control() As Boolean
        Return (Control.ModifierKeys And Keys.Control) = Keys.Control
    End Function
    ''' <summary>
    ''' ALTキーを押されているか？
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsOnKey_Alt() As Boolean
        Return (Control.ModifierKeys And Keys.Alt) = Keys.Alt
    End Function
    ''' <summary>
    ''' ポイントと矩形位置関係を調べる
    ''' </summary>
    ''' <param name="Pa">ポイント位置</param>
    ''' <param name="P1">対象矩形の左上座標</param>
    ''' <param name="P2">対象矩形の右下座標</param>
    ''' <returns>
    ''' 01(TopLeft)    |02(TopCenter)    |04(TopRight)
    ''' ---------------+-----------------+----------------------
    ''' 16(MiddleLeft) |32(MiddleCenter) |64(MiddleRight)
    ''' ---------------+-----------------+----------------------
    ''' 256(BottomLeft)|512(BottomCenter)|1024(BottomRight)
    ''' </returns>
    ''' <remarks>32(MiddleCenter)以外は指定矩形の「外」になります。</remarks>
    Private Function RectPosition(Pa As Point, P1 As Point, P2 As Point) As ContentAlignment
        Dim Ret As ContentAlignment = ContentAlignment.MiddleCenter
        Select Case True
            Case Pa.X < P1.X : Ret = 1
            Case Pa.X > P2.X : Ret = 4
            Case Else : Ret = 2
        End Select
        Select Case True
            Case Pa.Y < P1.Y : Ret *= 1
            Case Pa.Y > P2.Y : Ret *= 256
            Case Else : Ret *= 16
        End Select

        Return Ret
    End Function
    ''' <summary>
    ''' ポイントと矩形位置関係を調べる
    ''' </summary>
    ''' <param name="Pa">ポイント位置</param>
    ''' <param name="P1">対象矩形の左上座標</param>
    ''' <param name="BSize">対象矩形サイズ</param>
    ''' <returns>
    ''' 01(TopLeft)    |02(TopCenter)    |04(TopRight)
    ''' ---------------+-----------------+----------------------
    ''' 16(MiddleLeft) |32(MiddleCenter) |64(MiddleRight)
    ''' ---------------+-----------------+----------------------
    ''' 256(BottomLeft)|512(BottomCenter)|1024(BottomRight)
    ''' </returns>
    ''' <remarks>32(MiddleCenter)以外は指定矩形の「外」になります。</remarks>
    Private Function RectPosition(Pa As Point, P1 As Point, BSize As Size) As ContentAlignment
        Dim Ret As ContentAlignment = ContentAlignment.MiddleCenter
        Select Case True
            Case Pa.X < P1.X : Ret = 1
            Case Pa.X > P1.X + BSize.Width : Ret = 4
            Case Else : Ret = 2
        End Select
        Select Case True
            Case Pa.Y < P1.Y : Ret *= 1
            Case Pa.Y > P1.Y + BSize.Height : Ret *= 256
            Case Else : Ret *= 16
        End Select

        Return Ret
    End Function
End Class
