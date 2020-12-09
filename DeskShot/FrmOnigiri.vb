Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO


Public Class FrmOnigiri
    ''' <summary>
    ''' 作業モード
    ''' </summary>
    ''' <remarks></remarks>
    Enum DrawMode
        ''' <summary>
        ''' 手書きモード
        ''' </summary>
        ''' <remarks></remarks>
        ModeHand = 0
        ''' <summary>
        ''' 矩形モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeBox = 1
        ''' <summary>
        ''' 直線モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeLine = 2
        ''' <summary>
        ''' 文字描写モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeText = 3
        ''' <summary>
        ''' 矢印付き直線モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeLineArrow = 4
        ''' <summary>
        ''' 塗りつぶし矩形モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeSolid = 5
        ''' <summary>
        ''' 図形モード
        ''' </summary>
        ''' <remarks></remarks>
        ModePicture = 6
        ''' <summary>
        ''' 円モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeEllipsee = 7
        ''' <summary>
        ''' 矢印付き直線モード
        ''' </summary>
        ''' <remarks></remarks>
        ModeLineBothArrow = 8

    End Enum

    Dim WithEvents _Timer As New Timer
    Dim _OriginalSize As Size
    Dim _Title As String = ""
    Dim _DrawMode As DrawMode = DrawMode.ModeHand
    Dim _PenSize As Integer = 1
    Dim _ArrowHead As Integer = 4
    'Dim _Is64Bit As Boolean = False
    Dim _LoadPictureFile As String = ""
    ''' <summary>
    ''' 既存画像ファイルを読み込む時のファイル名
    ''' 無ければクリップボード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LoadPictureFile As String
        Get
            Return _LoadPictureFile
        End Get
        Set(value As String)
            _LoadPictureFile = value
        End Set
    End Property
    Property UserTitle As String
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmOnigiri_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If FrmMain.WindowState = FormWindowState.Minimized Then
            FrmMain.WindowState = FormWindowState.Normal
            Application.DoEvents()
        End If

        Me.Dispose()
    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmOnigiri_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Y As New ColorConverter
        Try
            Call WriteReg("General", "DrawColor", Y.ConvertToString(_ULineColor))
            My.Settings.AddPicture_Zoom = imgz
            My.Settings.Onigiri_TopMost = Me.TopMost
            'My.Settings.AddPicture_ZoomLock = MenuAddPicture_ZoomLock.Checked

            My.Settings.Onigiri_UseBack = _UUseBack
            My.Settings.Onigiri_BackColor = _UBackColor
            My.Settings.Onigiri_BackForeColor = _UBackForeColor
            My.Settings.Onigiri_BackShift_Left = _UBackShiftLeft
            My.Settings.Onigiri_BackShift_Right = _UBackShiftRight
            My.Settings.Onigiri_BackShift_Top = _UBackShiftTop
            My.Settings.Onigiri_BackShift_Bottom = _UBackShiftBottom
            My.Settings.Save()

            If FrmMain._OnigiriForm.Count > 0 Then
                For i As Integer = 0 To FrmMain._OnigiriForm.Count - 1
                    Dim FR As FrmOnigiri = FrmMain._OnigiriForm(i)
                    If FR.Tag = Me.Tag Then
                        FrmMain._OnigiriForm.RemoveAt(i)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
     
    End Sub
    ''' <summary>
    ''' コメント作成ダイアログ表示
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CommentEdit() As DialogResult
       
        Dim Ret As DialogResult
        With FrmOnigiriSUB
            .SetText = _UText
            .SetFont = _UFont
            .SetFontColor = _UBackForeColor
            .UseBack = _UUseBack
            .MojiBackColor = _UBackColor
            .ShiftLeft = _UBackShiftLeft
            .ShiftRight = _UBackShiftRight
            .ShiftTop = _UBackShiftTop
            .ShiftBottom = _UBackShiftBottom
            Ret = .ShowDialog(Me)
            If Ret = Windows.Forms.DialogResult.OK Then
                _UText = .SetText
                _UFont = .SetFont
                _UBackForeColor = .SetFontColor
                _UUseBack = .UseBack
                _UBackColor = .MojiBackColor
                _UBackShiftLeft = .ShiftLeft
                _UBackShiftRight = .ShiftRight
                _UBackShiftTop = .ShiftTop
                _UBackShiftBottom = .ShiftBottom
            End If
        End With
        Return Ret
        Dim ff As Integer = ValueBetween(10, 20, 30)
    End Function
 
    ''' <summary>
    ''' キーダウン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmOnigiri_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.Space 'クリップボードへ送る
                Call MenuSaveClipbord_Click(Nothing, Nothing)
            Case Keys.Escape '終了／文字モード終了
                If PictureBox2.Visible Then
                    Call PictureBox2_Click(Nothing, Nothing)
                Else
                    Call MenuMeClose_Click(Nothing, Nothing)
                End If
            Case Keys.Enter 'Wordpad連携
                If Not PictureBox2.Visible Then
                    Call MenuSendWordpad_Click(Nothing, Nothing)
                Else
                    Call CommentEdit()
                End If
            Case Keys.Back 'アンドゥ
                If Not PictureBox2.Visible Then
                    If MenuUndo.Enabled Then
                        Call MenuUndo_Click(Nothing, Nothing)
                    End If
                End If
            Case Keys.Up 'アイコンスケールアップ
                If imgz < 2 Then
                    imgz += 0.1
                Else
                    imgz = 2
                End If
                Call DrawIcon()
                ToolTip1.SetToolTip(PictureBox2, String.Format("倍率:{0}%", imgz * 100))
            Case Keys.Down 'アイコンスケールダウン
                If imgz > 0.1 Then
                    imgz -= 0.1
                Else
                    imgz = 0.1
                End If
                Call DrawIcon()
                ToolTip1.SetToolTip(PictureBox2, String.Format("倍率:{0}%", imgz * 100))

            Case Keys.Right '右回転
                imga += 10
                Call DrawIcon()
            Case Keys.Left '左回転
                imga -= 10
                Call DrawIcon()

        End Select
    End Sub
    ''' <summary>
    ''' 画像の表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawIcon()
        If _DrawMode = DrawMode.ModePicture Then
            If Not IsNothing(img2) Then
                Try
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    'ImageオブジェクトのGraphicsオブジェクトを作成する
                    Using g As Graphics = Graphics.FromImage(canvas)
                        '画像枠計算
                        Dim ImageRectPoints() As PointF = Calc3Point(_BoxSPosi.X, _BoxSPosi.Y, img2.Width * imgz, img2.Height * imgz, imga)
                        '画像を表示
                        g.DrawImage(img2, ImageRectPoints)
                    End Using
                    PictureBox2.Image = canvas
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Dim _LoadError As Boolean = False
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmOnigiri_Load(sender As Object, e As EventArgs) Handles Me.Load
        _Timer.Interval = 2000
        _Timer.Enabled = False
        If UserTitle <> "" Then
            Me.Text = String.Format("{0}({1})", Me.Text, UserTitle)
        End If
        _Title = Me.Text
        PictureBox2.Dock = DockStyle.Fill
        PictureBox2.Parent = PictureBox1

        If ReadReg("General", "OnigiriDrawPenSize", enum_Type.er_Integer) > 0 Then
            _PenSize = ReadReg("General", "OnigiriDrawPenSize", enum_Type.er_Integer)
        End If
        If ReadReg("General", "OnigiriDrawArrowHead", enum_Type.er_Integer) > 0 Then
            _ArrowHead = ReadReg("General", "OnigiriDrawArrowHead", enum_Type.er_Integer)
        End If

        ''使用OSが３２ビットか６４ビットかを判別する
        'If System.Environment.Is64BitOperatingSystem Then
        '    _Is64Bit = True
        '    Console.WriteLine("64ビットOSです。")
        'Else
        '    _Is64Bit = False
        '    Console.WriteLine("32ビットOSです。")
        'End If

        imgz = My.Settings.AddPicture_Zoom
        Select Case imgz
            Case Is < 0.1 : imgz = 1
            Case Is > 2 : imgz = 1
            Case Else
        End Select
        Call SetIcon()

        Me.TopMost = My.Settings.Onigiri_TopMost
        MenuTopMost.Checked = My.Settings.Onigiri_TopMost

        _UUseBack = My.Settings.Onigiri_UseBack
        _UBackColor = My.Settings.Onigiri_BackColor
        _UBackForeColor = My.Settings.Onigiri_BackForeColor
        _UBackShiftLeft = My.Settings.Onigiri_BackShift_Left
        _UBackShiftRight = My.Settings.Onigiri_BackShift_Right
        _UBackShiftTop = My.Settings.Onigiri_BackShift_Top
        _UBackShiftBottom = My.Settings.Onigiri_BackShift_Bottom

        Dim Y As New ColorConverter
        Dim _C As Color = Y.ConvertFromString(ReadReg("General", "DrawColor"))
        If _C.IsEmpty Then
            _ULineColor = Color.Red
        Else
            _ULineColor = _C
        End If

        Try
            If _LoadPictureFile = "" Then
                'クリップボードデータを読み込む
                If Clipboard.ContainsImage() Then
                    'クリップボードにあるデータの取得
                    Dim img As Image = Clipboard.GetImage()
                    If img IsNot Nothing Then
                        'データが取得できたときは表示する
                        PictureBox1.Image = img
                        _OriginalSize = img.Size
                        Me.ClientSize = New Size(img.Size)
                    Else
                        Me.WindowState = FormWindowState.Minimized
                        _LoadError = True
                    End If
                Else
                    Me.WindowState = FormWindowState.Minimized
                    _LoadError = True
                End If
            Else
                '保存済み画像ファイルを読み込む
                If System.IO.File.Exists(_LoadPictureFile) Then
                    Dim img As Image = System.Drawing.Image.FromFile(_LoadPictureFile)
                    If img IsNot Nothing Then
                        'データが取得できたときは表示する
                        PictureBox1.Image = img
                        _OriginalSize = img.Size
                        Me.ClientSize = New Size(img.Size)
                    Else
                        Me.WindowState = FormWindowState.Minimized
                        _LoadError = True
                    End If
                Else
                    Me.WindowState = FormWindowState.Minimized
                    _LoadError = True
                End If
            End If
            
        Catch ex As Exception
            Me.WindowState = FormWindowState.Minimized
            MsgBox(ex.Message)
            MsgBox("クリップボードからの画像取得に失敗しました", 48, "エラー")
            _LoadError = True
        End Try
    End Sub
    ''' <summary>
    ''' 画像追加メニュー調整
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetIcon()
        MenuAddPicture_No1.Tag = My.Resources.NoImage_1_32 : MenuAddPicture_No1.Image = My.Resources.NoImage_1_32
        AddHandler MenuAddPicture_No1.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No2.Tag = My.Resources.NoImage_2_32 : MenuAddPicture_No2.Image = My.Resources.NoImage_2_32
        AddHandler MenuAddPicture_No2.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No3.Tag = My.Resources.NoImage_3_32 : MenuAddPicture_No3.Image = My.Resources.NoImage_3_32
        AddHandler MenuAddPicture_No3.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No4.Tag = My.Resources.NoImage_4_32 : MenuAddPicture_No4.Image = My.Resources.NoImage_4_32
        AddHandler MenuAddPicture_No4.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No5.Tag = My.Resources.NoImage_5_32 : MenuAddPicture_No5.Image = My.Resources.NoImage_5_32
        AddHandler MenuAddPicture_No5.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No6.Tag = My.Resources.NoImage_6_32 : MenuAddPicture_No6.Image = My.Resources.NoImage_6_32
        AddHandler MenuAddPicture_No6.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No7.Tag = My.Resources.NoImage_7_32 : MenuAddPicture_No7.Image = My.Resources.NoImage_7_32
        AddHandler MenuAddPicture_No7.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No8.Tag = My.Resources.NoImage_8_32 : MenuAddPicture_No8.Image = My.Resources.NoImage_8_32
        AddHandler MenuAddPicture_No8.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_No9.Tag = My.Resources.NoImage_9_32 : MenuAddPicture_No9.Image = My.Resources.NoImage_9_32
        AddHandler MenuAddPicture_No9.Click, AddressOf MenuAddPicture2_Click


        MenuAddPicture_NoBlack1.Tag = My.Resources.Numbers_1_Black_icon : MenuAddPicture_NoBlack1.Image = My.Resources.Numbers_1_Black_icon
        AddHandler MenuAddPicture_NoBlack1.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack2.Tag = My.Resources.Numbers_2_Black_icon : MenuAddPicture_NoBlack2.Image = My.Resources.Numbers_2_Black_icon
        AddHandler MenuAddPicture_NoBlack2.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack3.Tag = My.Resources.Numbers_3_Black_icon : MenuAddPicture_NoBlack3.Image = My.Resources.Numbers_3_Black_icon
        AddHandler MenuAddPicture_NoBlack3.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack4.Tag = My.Resources.Numbers_4_Black_icon : MenuAddPicture_NoBlack4.Image = My.Resources.Numbers_4_Black_icon
        AddHandler MenuAddPicture_NoBlack4.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack5.Tag = My.Resources.Numbers_5_Black_icon : MenuAddPicture_NoBlack5.Image = My.Resources.Numbers_5_Black_icon
        AddHandler MenuAddPicture_NoBlack5.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack6.Tag = My.Resources.Numbers_6_Black_icon : MenuAddPicture_NoBlack6.Image = My.Resources.Numbers_6_Black_icon
        AddHandler MenuAddPicture_NoBlack6.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack7.Tag = My.Resources.Numbers_7_Black_icon : MenuAddPicture_NoBlack7.Image = My.Resources.Numbers_7_Black_icon
        AddHandler MenuAddPicture_NoBlack7.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack8.Tag = My.Resources.Numbers_8_Black_icon : MenuAddPicture_NoBlack8.Image = My.Resources.Numbers_8_Black_icon
        AddHandler MenuAddPicture_NoBlack8.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoBlack9.Tag = My.Resources.Numbers_9_Black_icon : MenuAddPicture_NoBlack9.Image = My.Resources.Numbers_9_Black_icon
        AddHandler MenuAddPicture_NoBlack9.Click, AddressOf MenuAddPicture2_Click


        MenuAddPicture_NoWhite1.Tag = My.Resources.Numbers_1_White_icon : MenuAddPicture_NoWhite1.Image = My.Resources.Numbers_1_White_icon
        AddHandler MenuAddPicture_NoWhite1.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite2.Tag = My.Resources.Numbers_2_White_icon : MenuAddPicture_NoWhite2.Image = My.Resources.Numbers_2_White_icon
        AddHandler MenuAddPicture_NoWhite2.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite3.Tag = My.Resources.Numbers_3_White_icon : MenuAddPicture_NoWhite3.Image = My.Resources.Numbers_3_White_icon
        AddHandler MenuAddPicture_NoWhite3.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite4.Tag = My.Resources.Numbers_4_White_icon : MenuAddPicture_NoWhite4.Image = My.Resources.Numbers_4_White_icon
        AddHandler MenuAddPicture_NoWhite4.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite5.Tag = My.Resources.Numbers_5_White_icon : MenuAddPicture_NoWhite5.Image = My.Resources.Numbers_5_White_icon
        AddHandler MenuAddPicture_NoWhite5.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite6.Tag = My.Resources.Numbers_6_White_icon : MenuAddPicture_NoWhite6.Image = My.Resources.Numbers_6_White_icon
        AddHandler MenuAddPicture_NoWhite6.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite7.Tag = My.Resources.Numbers_7_White_icon : MenuAddPicture_NoWhite7.Image = My.Resources.Numbers_7_White_icon
        AddHandler MenuAddPicture_NoWhite7.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite8.Tag = My.Resources.Numbers_8_White_icon : MenuAddPicture_NoWhite8.Image = My.Resources.Numbers_8_White_icon
        AddHandler MenuAddPicture_NoWhite8.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_NoWhite9.Tag = My.Resources.Numbers_9_White_icon : MenuAddPicture_NoWhite9.Image = My.Resources.Numbers_9_White_icon
        AddHandler MenuAddPicture_NoWhite9.Click, AddressOf MenuAddPicture2_Click


        MenuAddPicture_Other1.Tag = My.Resources.accept_button : MenuAddPicture_Other1.Image = My.Resources.accept_button
        AddHandler MenuAddPicture_Other1.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other2.Tag = My.Resources.cancel : MenuAddPicture_Other2.Image = My.Resources.cancel
        AddHandler MenuAddPicture_Other2.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other3.Tag = My.Resources.cross : MenuAddPicture_Other3.Image = My.Resources.cross
        AddHandler MenuAddPicture_Other3.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other4.Tag = My.Resources.delete : MenuAddPicture_Other4.Image = My.Resources.delete
        AddHandler MenuAddPicture_Other4.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other5.Tag = My.Resources.exclamation : MenuAddPicture_Other5.Image = My.Resources.exclamation
        AddHandler MenuAddPicture_Other5.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other6.Tag = My.Resources.help : MenuAddPicture_Other6.Image = My.Resources.help
        AddHandler MenuAddPicture_Other6.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other7.Tag = My.Resources.information : MenuAddPicture_Other7.Image = My.Resources.information
        AddHandler MenuAddPicture_Other7.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other8.Tag = My.Resources.lightbulb : MenuAddPicture_Other8.Image = My.Resources.lightbulb
        AddHandler MenuAddPicture_Other8.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other9.Tag = My.Resources.lightning : MenuAddPicture_Other9.Image = My.Resources.lightning
        AddHandler MenuAddPicture_Other9.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other10.Tag = My.Resources.magnifier : MenuAddPicture_Other10.Image = My.Resources.magnifier
        AddHandler MenuAddPicture_Other10.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other11.Tag = My.Resources.arrow_down : MenuAddPicture_Other11.Image = My.Resources.arrow_down
        AddHandler MenuAddPicture_Other11.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other12.Tag = My.Resources.arrow_left : MenuAddPicture_Other12.Image = My.Resources.arrow_left
        AddHandler MenuAddPicture_Other12.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other13.Tag = My.Resources.arrow_right : MenuAddPicture_Other13.Image = My.Resources.arrow_right
        AddHandler MenuAddPicture_Other13.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Other14.Tag = My.Resources.arrow_up : MenuAddPicture_Other14.Image = My.Resources.arrow_up
        AddHandler MenuAddPicture_Other14.Click, AddressOf MenuAddPicture2_Click

        MenuAddPicture_Mouse0.Tag = My.Resources.cursor : MenuAddPicture_Mouse0.Image = My.Resources.cursor
        AddHandler MenuAddPicture_Mouse0.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Mouse1.Tag = My.Resources.mouse_pc : MenuAddPicture_Mouse1.Image = My.Resources.mouse_pc
        AddHandler MenuAddPicture_Mouse1.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Mouse2.Tag = My.Resources.mouse_select_left : MenuAddPicture_Mouse2.Image = My.Resources.mouse_select_left
        AddHandler MenuAddPicture_Mouse2.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Mouse3.Tag = My.Resources.mouse_select_right : MenuAddPicture_Mouse3.Image = My.Resources.mouse_select_right
        AddHandler MenuAddPicture_Mouse3.Click, AddressOf MenuAddPicture2_Click
        MenuAddPicture_Mouse4.Tag = My.Resources.mouse_select_scroll : MenuAddPicture_Mouse4.Image = My.Resources.mouse_select_scroll
        AddHandler MenuAddPicture_Mouse4.Click, AddressOf MenuAddPicture2_Click

    End Sub

    Private Sub FrmOnigiri_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'クリップボードエラー時はそのまま閉じる
        If _LoadError Then
            Me.Close()
        End If
    End Sub
#Region "画像ファイルに変換"
    Private Sub MenuSaveBmp_Click(sender As Object, e As EventArgs) Handles MenuSaveBmp.Click, MenuSaveJPEG.Click, MenuSavePNG.Click
        Dim Obj As ToolStripMenuItem = sender
        Dim Index As Integer = Obj.Tag
        Dim rect As Rectangle = PictureBox1.ClientRectangle

        Try
            'PictureBox1に表示されている画像を取得するためのBitmap
            Using bmp As New Bitmap(rect.Width, rect.Height)
                'bmpに画像を入れるための準備
                Using g As Graphics = Graphics.FromImage(bmp)
                    Dim pea As New PaintEventArgs(g, rect)

                    'PaintBackgroundイベントを発生
                    Me.InvokePaintBackground(PictureBox1, pea)
                    'Paintイベントを発生
                    Me.InvokePaint(PictureBox1, pea)

                    Dim _FL As String = SaveFileName(Index)
                    If _FL <> "" Then
                        '画像を保存する
                        Select Case Index
                            Case 0
                                bmp.Save(_FL, System.Drawing.Imaging.ImageFormat.Bmp)
                            Case 1
                                bmp.Save(_FL, System.Drawing.Imaging.ImageFormat.Jpeg)
                            Case 2
                                bmp.Save(_FL, System.Drawing.Imaging.ImageFormat.Png)
                        End Select
                        MsgBox("画像保存完了", 64, "情報")

                        If ReadReg("General", "AutoOnigiriClose", enum_Type.er_Boolean) Then
                            Call MenuMeClose_Click(Nothing, Nothing)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try

    End Sub
    ''' <summary>
    ''' 保存ファイル名設定
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveFileName(Value As Integer) As String
        Dim _File As String = ""
        Try
            Using oFD As New SaveFileDialog
                With oFD
                    .AddExtension = True
                    .CheckFileExists = False
                    .CheckPathExists = True
                    Select Case Value
                        Case 0
                            .DefaultExt = ".bmp"
                            .FileName = "無題.bmp"
                            .Filter = "BMPファイル(*.bmp)|*.bmp|全てのファイル(*.*)|*.*"
                        Case 1
                            .DefaultExt = ".jpg"
                            .FileName = "無題.jpg"
                            .Filter = "JPEGPファイル(*.jpg)|*.jpg|全てのファイル(*.*)|*.*"
                        Case Else
                            .DefaultExt = ".png"
                            .FileName = "無題.png"
                            .Filter = "PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*"

                    End Select
                    .FilterIndex = 0
                    .RestoreDirectory = True
                    .Title = "画像保存"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _File = .FileName
                    End If
                End With
            End Using
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
       
        Return _File
    End Function
#End Region

    ''' <summary>
    ''' TODO:プリンターへ出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPrintOut_Click(sender As Object, e As EventArgs) Handles MenuPrintOut.Click
        If MsgBox("プリンターに直接出力してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Try
                Dim rect As Rectangle = PictureBox1.ClientRectangle

                _FileName = String.Format("{0:yyyyMMddHHmmss}.bmp", Now)
                '_FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                _FileName = My.Computer.FileSystem.CombinePath(SystemFullPath(Environment.SpecialFolder.ApplicationData, "workfolder"), _FileName)

                'PictureBox1に表示されている画像を取得するためのBitmap
                Using bmp As New Bitmap(rect.Width, rect.Height)
                    'bmpに画像を入れるための準備
                    Using g As Graphics = Graphics.FromImage(bmp)
                        Dim pea As New PaintEventArgs(g, rect)

                        'PaintBackgroundイベントを発生
                        Me.InvokePaintBackground(PictureBox1, pea)
                        'Paintイベントを発生
                        Me.InvokePaint(PictureBox1, pea)

                        bmp.Save(_FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                    End Using
                End Using

                Dim pd As New System.Drawing.Printing.PrintDocument
                pd.PrinterSettings.DefaultPageSettings.Landscape = True

                'PrintPageイベントハンドラの追加
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                '印刷を開始する
                'pd.PrinterSettings.DefaultPageSettings.PrintableArea.Width
                pd.Print()
            Catch ex As Exception
                MsgBox("プリンター出力に失敗しました", 48, "エラー")
            End Try
        End If

    End Sub

    Dim _FileName As String = ""
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Try
            '画像を読み込む
            Using img As Image = Image.FromFile(_FileName)
                Dim IW As Integer = img.Width
                Dim IH As Integer = img.Height
                Dim ff As Single = e.MarginBounds.Width / img.Width

                '画像を描画する
                Dim jj As Rectangle = New Rectangle(e.MarginBounds.X, e.MarginBounds.Y, e.MarginBounds.Width, img.Height * ff)

                e.Graphics.DrawImage(img, jj)
                '次のページがないことを通知する
                e.HasMorePages = False
            End Using
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
    End Sub
    ''' <summary>
    ''' クリップボードに画像を転送
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSaveClipbord_Click(sender As Object, e As EventArgs) Handles MenuSaveClipbord.Click
        Me.ClientSize = New Size(_OriginalSize) '元のサイズに戻す

        Dim rect As Rectangle = PictureBox1.ClientRectangle

        Try
            'PictureBox1に表示されている画像を取得するためのBitmap
            Using bmp As New Bitmap(rect.Width, rect.Height)
                'bmpに画像を入れるための準備
                Using g As Graphics = Graphics.FromImage(bmp)
                    Dim pea As New PaintEventArgs(g, rect)

                    'PaintBackgroundイベントを発生
                    Me.InvokePaintBackground(PictureBox1, pea)
                    'Paintイベントを発生
                    Me.InvokePaint(PictureBox1, pea)

                    Clipboard.SetDataObject(bmp, True)
                    'MsgBox("クリップボード転送完了", 64, "情報")
                    Me.Text = String.Format("{0}(クリップボード転送完了)", _Title)
                    _Timer.Enabled = True
                End Using
            End Using

            If ReadReg("General", "AutoOnigiriClose", enum_Type.er_Boolean) Then
                Call MenuMeClose_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgBox("クリップボードへの転送に失敗しました", 48, "エラー")
        End Try

    End Sub
    ''' <summary>
    ''' 終了メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' 
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuMeClose_Click(sender As Object, e As EventArgs) Handles MenuMeClose.Click
        Me.Close()
    End Sub
#Region "DRAW関係"

    Dim _IsDrawing As Boolean = False
    Private PenColorC As String
    Private dwnC As Boolean
    Dim brC As New Pen(Color.Red)
    Dim _OldPosi As Point
    Dim _IsFirst As Boolean = True
    Dim UNDO_Array As New List(Of Bitmap)
    Dim _BoxSPosi As Point

    Dim _UText As String = ""
    Dim _UFont As Font = Nothing
    Dim _UColor As Color = Nothing
    Dim _ULineColor As Color = Color.Red
    Dim _UUseBack As Boolean = False
    Dim _UBackColor As Color = Nothing
    Dim _UBackForeColor As Color = Color.Red

    Dim _UBackShiftLeft As Integer = 0
    Dim _UBackShiftTop As Integer = 0
    Dim _UBackShiftRight As Integer = 0
    Dim _UBackShiftBottom As Integer = 0

    ''' <summary>
    ''' 文字追加メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddText_Click(sender As Object, e As EventArgs) Handles MenuAddText.Click
        Call PictureBox1_DoubleClick(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' ダブルクリックで文字の描写
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        '文字モードでは無い時は文字モードに入る

        Try
            If Not PictureBox2.Visible Then
                Me.Text = String.Format("{0}(文字モード)", _Title)

                _UText = "新しいコメント"
                If IsNothing(_OnigiriFont) Then
                    _UFont = New Font("MS UI Gothic", 12, FontStyle.Bold)
                Else
                    _UFont = _OnigiriFont
                End If

                _UColor = _ULineColor 'Color.Red
                If Not CommentEdit() = Windows.Forms.DialogResult.OK Then
                    Me.Text = String.Format("{0}", _Title)
                    Return
                End If

                PictureBox2.Visible = True
                _DrawMode = DrawMode.ModeText
                Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Using g As Graphics = Graphics.FromImage(canvas)
                    'Dim img As Image = PictureBox1.Image
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                    If _UUseBack Then
                        '塗りつぶし背景を使用する
                        Dim StringWidth As Integer = g.MeasureString(_UText, _UFont).Width
                        Dim StringHeight As Integer = g.MeasureString(_UText, _UFont).Height
                        Using b As New SolidBrush(_UBackColor)
                            g.FillRectangle(b, _BoxSPosi.X - _UBackShiftLeft, _BoxSPosi.Y - _UBackShiftTop, StringWidth + _UBackShiftLeft + _UBackShiftRight, StringHeight + _UBackShiftTop + _UBackShiftBottom)
                        End Using
                    End If

                    Dim _UBrush As Brush = New SolidBrush(_UBackForeColor)
                    g.DrawString(_UText, _UFont, _UBrush, _BoxSPosi.X, _BoxSPosi.Y)
                End Using
                PictureBox2.Image = canvas
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try

    End Sub

    ''' <summary>
    ''' マウス移動で文字も移動
    ''' </summary>C:\Makesource\DeskShot(画面キャプチャー)\DeskShot\FrmOnigiriSUB_Color.vb
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        _BoxSPosi = e.Location
        If _DrawMode = DrawMode.ModeText Then
            '文字描写モード
            Try
                Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Using g As Graphics = Graphics.FromImage(canvas)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                    If _UUseBack Then
                        '塗りつぶし背景を使用する
                        Dim StringWidth As Integer = g.MeasureString(_UText, _UFont).Width
                        Dim StringHeight As Integer = g.MeasureString(_UText, _UFont).Height

                        Using b As New SolidBrush(_UBackColor)
                            g.FillRectangle(b, _BoxSPosi.X - _UBackShiftLeft, _BoxSPosi.Y - _UBackShiftTop, StringWidth + _UBackShiftLeft + _UBackShiftRight, StringHeight + _UBackShiftTop + _UBackShiftBottom)

                        End Using
                    End If

                    Dim _UBrush As Brush = New SolidBrush(_UBackForeColor)
                    g.DrawString(_UText, _UFont, _UBrush, _BoxSPosi.X, _BoxSPosi.Y)
                End Using
                PictureBox2.Image = canvas
            Catch ex As Exception

            End Try
        ElseIf _DrawMode = DrawMode.ModePicture Then
            '画像配置モード
            Call DrawIcon()
        End If
    End Sub
    ''' <summary>
    ''' クリックで文字位置確定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If _DrawMode = DrawMode.ModeText Then
            '文字描写モード
            Try
                
                'クリックする事によりPictureBox2の内容をPictureBox1転記しても文字モードから抜け出す
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)

                    If _UUseBack Then
                        '塗りつぶし背景を使用する
                        Dim StringWidth As Integer = g.MeasureString(_UText, _UFont).Width
                        Dim StringHeight As Integer = g.MeasureString(_UText, _UFont).Height
                        Using b As New SolidBrush(_UBackColor)
                            g.FillRectangle(b, _BoxSPosi.X - _UBackShiftLeft, _BoxSPosi.Y - _UBackShiftTop, StringWidth + _UBackShiftLeft + _UBackShiftRight, StringHeight + _UBackShiftTop + _UBackShiftBottom)

                        End Using
                    End If

                    Dim _UBrush As Brush = New SolidBrush(_UBackForeColor)
                    g.DrawString(_UText, _UFont, _UBrush, _BoxSPosi.X, _BoxSPosi.Y)
                End Using
                PictureBox1.Image = canvas
                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)
                _DrawMode = DrawMode.ModeHand
            Catch ex As Exception

            End Try

        ElseIf _DrawMode = DrawMode.ModePicture Then
            '画像配置モード
            If Not IsNothing(img2) Then
                Try
                    Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Dim img As Image = PictureBox1.Image
                        g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                        '画像枠計算
                        Dim destinationPoints() As PointF = Calc3Point(_BoxSPosi.X, _BoxSPosi.Y, img2.Width * imgz, img2.Height * imgz, imga)
                        '画像を表示
                        g.DrawImage(img2, destinationPoints)
                    End Using
                    PictureBox1.Image = canvas
                    _DrawMode = DrawMode.ModeHand
                    PictureBox2.Visible = False
                    Me.Text = String.Format("{0}", _Title)
                    _DrawMode = DrawMode.ModeHand
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    ''' <summary>
    ''' マウスダウンイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Not IsNothing(PictureBox1.Image) Then
                Dim _ColorName As String = ""
                Select Case _ULineColor
                    Case Color.Red : _ColorName = "赤色"
                    Case Color.Blue : _ColorName = "青色"
                    Case Color.Black : _ColorName = "黒色"
                    Case Color.White : _ColorName = "白色"
                    Case Else : _ColorName = "任意"
                End Select

                Dim _F As Integer = 0
                If (Control.ModifierKeys And Keys.Control) = Keys.Control Then _F = 1
                If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then _F += 2
                If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then _F += 4
                Select Case _F
                    Case 1
                        '[C-X-X]
                        '矩形モード
                        _DrawMode = DrawMode.ModeBox
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(矩形モード[{1}])", _Title, _ColorName)
                    Case 2
                        '[X-S-X]
                        '直線モード
                        _DrawMode = DrawMode.ModeLine
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(直線モード[{1}])", _Title, _ColorName)
                    Case 3
                        '[C-S-X]
                        '矢印付き直線モード()
                        _DrawMode = DrawMode.ModeLineArrow
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(矢印モード[{1}])", _Title, _ColorName)
                    Case 4
                        '[X-X-A]
                        '楕円描写モード
                        _DrawMode = DrawMode.ModeEllipsee
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(円モード[{1}])", _Title, _ColorName)
                    Case 5
                        '[C-X-A]
                        '塗りつぶし矩形モード
                        _DrawMode = DrawMode.ModeSolid
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(塗りつぶしモード[{1}])", _Title, _ColorName)
                        'Case 6
                        '[X-S-A]
                    Case 7
                        '[C-S-A]
                        '両矢印付き直線モード()
                        _DrawMode = DrawMode.ModeLineBothArrow
                        PictureBox2.Visible = True
                        Me.Text = String.Format("{0}(両矢印モード[{1}])", _Title, _ColorName)
                    Case Else
                        '[X-X-X](0)
                        _DrawMode = DrawMode.ModeHand
                        Me.Text = String.Format("{0}(手書きモード[{1}])", _Title, _ColorName)
                End Select

                _IsDrawing = True
                Dim MM As Bitmap = PictureBox1.Image
                UNDO_Array.Add(New Bitmap(MM))
                MenuUndo.Enabled = True
                _BoxSPosi = e.Location
            End If
        End If
    End Sub
   
    ''' <summary>
    ''' マウスを動かした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If _IsDrawing = True Then
            Select Case _DrawMode
                Case DrawMode.ModeSolid '塗りつぶし矩形モード
                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using b As New SolidBrush(_ULineColor)
                            g.FillRectangle(b, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

                Case DrawMode.ModeBox '矩形モード
                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using p As New Pen(_ULineColor, _PenSize)
                            g.DrawRectangle(p, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

                Case DrawMode.ModeLine '直線モード
                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using p As New Pen(_ULineColor, _PenSize)
                            g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

                Case DrawMode.ModeLineArrow '矢印付き直線モード
                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using p As New Pen(_ULineColor, _PenSize)
                            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            p.CustomEndCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                            g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

                Case DrawMode.ModeEllipsee '円モード
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using p As New Pen(_ULineColor, _PenSize)
                            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            g.DrawEllipse(p, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

                Case DrawMode.ModeHand '手書きモード
                    ''描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    ''ImageオブジェクトのGraphicsオブジェクトを作成する
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Dim img As Image = PictureBox1.Image
                        g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)

                        Dim sC As Integer = _PenSize
                        Dim xyC As Point = e.Location
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        brC.Color = _ULineColor 'Color.FromName("Red") 'PenColorC)
                        'brC.Width = 2
                        brC.Width = _PenSize
                        If _IsFirst Then
                            _OldPosi = xyC
                            _IsFirst = False
                        End If
                        g.DrawLine(brC, _OldPosi, xyC)
                        _OldPosi = xyC
                    End Using
                    PictureBox1.Image = canvas

                Case DrawMode.ModeLineBothArrow '両矢印付き直線モード
                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using p As New Pen(_ULineColor, _PenSize)
                            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            p.CustomStartCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                            p.CustomEndCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                            g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                        End Using
                    End Using
                    PictureBox2.Image = canvas

            End Select
        End If
    End Sub
    ''' <summary>
    ''' マウスアップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Select Case _DrawMode
            Case DrawMode.ModeSolid '塗りつぶし矩形モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using b As New SolidBrush(_ULineColor)
                        g.FillRectangle(b, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)

            Case DrawMode.ModeBox '矩形モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using p As New Pen(_ULineColor, _PenSize)
                        g.DrawRectangle(p, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)

            Case DrawMode.ModeLine '直線モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using p As New Pen(_ULineColor, _PenSize)
                        g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)

            Case DrawMode.ModeLineArrow '矢印付き直線モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using p As New Pen(_ULineColor, _PenSize)
                        p.CustomEndCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)

            Case DrawMode.ModeEllipsee '円モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using p As New Pen(_ULineColor, _PenSize)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        g.DrawEllipse(p, _BoxSPosi.X, _BoxSPosi.Y, e.X - _BoxSPosi.X, e.Y - _BoxSPosi.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)

            Case DrawMode.ModeLineBothArrow '両矢印付き直線モード
                Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(canvas)
                    Dim img As Image = PictureBox1.Image
                    g.DrawImage(img, 0, 0, PictureBox1.Width, PictureBox1.Height)
                    Using p As New Pen(_ULineColor, _PenSize)
                        p.CustomStartCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                        p.CustomEndCap = New System.Drawing.Drawing2D.AdjustableArrowCap(_ArrowHead, _ArrowHead)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        g.DrawLine(p, _BoxSPosi.X, _BoxSPosi.Y, e.X, e.Y)
                    End Using
                End Using
                PictureBox1.Image = canvas

                _DrawMode = DrawMode.ModeHand
                PictureBox2.Visible = False
                Me.Text = String.Format("{0}", _Title)
            Case DrawMode.ModeHand '手書きモード
                Me.Text = String.Format("{0}", _Title)

        End Select

        _IsDrawing = False
        _IsFirst = True
        '_EditFlg = True
    End Sub
#End Region
    ''' <summary>
    ''' アンドゥーメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuUndo_Click(sender As Object, e As EventArgs) Handles MenuUndo.Click
        If UNDO_Array.Count > 0 Then
            PictureBox1.Image = Nothing
            PictureBox1.Image = New Bitmap(UNDO_Array(UNDO_Array.Count - 1))
            UNDO_Array.RemoveAt(UNDO_Array.Count - 1)
        Else
            MenuUndo.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' コンテキストメニューオープニング
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If UNDO_Array.Count > 0 Then
            MenuUndo.Enabled = True
        Else
            MenuUndo.Enabled = False
        End If

        If IsNothing(OnigiriSetStat) Then
            MenuOnigiriSet.Text = "おにぎりセットを起動"
        Else
            MenuOnigiriSet.Text = "おにぎりセットに追加"
        End If
    End Sub
    ''' <summary>
    ''' 元サイズに戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSizeReset_Click(sender As Object, e As EventArgs) Handles MenuSizeReset.Click
        Me.ClientSize = New Size(_OriginalSize)
    End Sub

    Private Sub MenuDrawBox_Click(sender As Object, e As EventArgs) Handles MenuDrawBox.Click
        MenuDrawBox.Checked = True
        PictureBox2.Visible = True
    End Sub

    Private Sub _Timer_Tick(sender As Object, e As EventArgs) Handles _Timer.Tick
        _Timer.Enabled = False
        Me.Text = _Title
    End Sub
    ''' <summary>
    ''' 前面にする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuTopMost_Click(sender As Object, e As EventArgs) Handles MenuTopMost.Click
        MenuTopMost.Checked = Not MenuTopMost.Checked
        Me.TopMost = MenuTopMost.Checked
    End Sub
 

#Region "ワードパッド連携"
    <DllImport("user32.dll")> _
    Private Shared Function IsIconic(hWnd As IntPtr) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function ShowWindowAsync(hWnd As IntPtr, nCmdShow As Integer) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    Private Const SW_SHOWNORMAL As Integer = 1
    Private Const SW_SHOW As Integer = 5
    Private Const SW_RESTORE As Integer = 9
    Private Const SW_MINIMIZE As Integer = 9

    Dim _WordpadStatus As Boolean = False '貼り付け前の状態を覚える
    ''' <summary>
    ''' ワードパッド連携
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendWordpad_Click(sender As Object, e As EventArgs) Handles MenuSendWordpad.Click
        Me.ClientSize = New Size(_OriginalSize) '元のサイズに戻す

        If FrmMain.WindowState = FormWindowState.Minimized Then
            FrmMain.WindowState = FormWindowState.Normal
            Application.DoEvents()
        End If

        Call SendWordpad()
    End Sub
    ''' <summary>
    ''' ワードパッド連携
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SendWordpad(Optional IsSmallSize As Boolean = True) As Boolean
        Select Case Execute_Wordpad() 'ワードパッド起動確認
            Case 0
                'Wordpad未起動
                If MsgBox("ワードパッドが起動されていません。" & vbCrLf & "ワードパッドを起動させますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                    Try
                        Dim psi As New System.Diagnostics.ProcessStartInfo()
                        psi.FileName = "wordpad.exe"
                        'WindowStyleにMinimizedを指定して、最小化された状態で起動されるようにする
                        If IsSmallSize Then
                            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized
                        End If

                        'アプリケーションを起動する
                        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
                        System.Threading.Thread.Sleep(1000)
                        'MsgBox("ワードパッドを起動させました。" & vbCrLf & "もう一度連携作業を実行してください。", 64, "情報")

                        With FrmDialog1
                            If Me.Visible Then
                                .MainFormPosition = Me.Location
                            Else
                                .MainFormPosition = New Point(0, 0)
                            End If
                            If .ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                                Return False
                            End If
                        End With
                        'もしダイアログでOKなら再帰する

                        'Call MenuSendWordpad_Click(Nothing, Nothing)
                        Call SendWordpad(IsSmallSize)
                        Return True

                    Catch ex As Exception
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "WordPad起動エラー")
                        Return False
                    End Try
                Else
                    Return False
                End If
            Case 1
                'Wordpad連携
                Try
                    '画像をクリップボードに送る
                    Call MenuSaveClipbord_Click(Nothing, Nothing)
                    System.Threading.Thread.Sleep(500)

                    Call WordPadWork(_WordpadStatus) 'ワードパッド操作
                    Return True
                Catch ex As Exception
                    MsgBox(ExMessCreater(GetStack(ex)), 48, "WordPad連携エラー")
                    Return False
                End Try
            Case Else
                'その他（エラー）
                MsgBox("ワードパッド連携に失敗しました" & vbCrLf & "申し訳ございませんが、もう一度実行してみてください。", 64, "情報")
                Return False
        End Select
    End Function
    ''' <summary>
    ''' ワードパッドの起動確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Execute_Wordpad() As Integer
        Try
            Dim PP As System.Diagnostics.Process()
            '使用OSによりプロセスの一覧の処理を切り替える
            If _Is64Bit Then
                PP = GetProcessesByFileName64("wordpad.exe")
            Else
                PP = GetProcessesByFileName("wordpad.exe")
            End If

            If Not IsNothing(PP) Then
                If PP.Length = 0 Then
                    Return 0
                Else
                    If IsIconic(PP(0).MainWindowHandle) Then
                        '    '最小化なら通常の大きさに戻す
                        'ShowWindowAsync(PP(0).MainWindowHandle, SW_RESTORE)
                        _WordpadStatus = True
                        System.Threading.Thread.Sleep(200)
                    End If
                    '指定アプリをアクティブにする
                    Microsoft.VisualBasic.Interaction.AppActivate(PP(0).Id)
                    Return 1
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, 48, "WordPad起動確認エラー")
            MsgBox(ExMessCreater(GetStack(ex)), 48, "WordPad起動確認エラー")
            Return -1
        End Try

    End Function

    ' ''' <summary>
    ' ''' 起動プロセスの列挙(32ビット)
    ' ''' </summary>
    ' ''' <param name="searchFileName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetProcessesByFileName(searchFileName As String) As System.Diagnostics.Process()
    '    searchFileName = searchFileName.ToLower()
    '    Dim list As New System.Collections.ArrayList()

    '    Try
    '        'すべてのプロセスを列挙する
    '        For Each p As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
    '            Dim fileName As String
    '            Try
    '                'メインモジュールのパスを取得する
    '                fileName = p.MainModule.FileName
    '            Catch generatedExceptionName As System.ComponentModel.Win32Exception
    '                'MainModuleの取得に失敗
    '                fileName = ""
    '            End Try
    '            If 0 < fileName.Length Then
    '                'ファイル名の部分を取得する
    '                fileName = System.IO.Path.GetFileName(fileName)
    '                '探しているファイル名と一致した時、コレクションに追加
    '                If searchFileName.Equals(fileName.ToLower()) Then
    '                    list.Add(p)
    '                End If
    '            End If
    '        Next

    '        'コレクションを配列にして返す
    '        Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)), System.Diagnostics.Process())
    '    Catch ex As Exception
    '        MsgBox(ex.Message, 48, "プロセス列挙エラー32")
    '        Return Nothing
    '    End Try

    'End Function
    ' ''' <summary>
    ' ''' 起動プロセスの列挙(64ビット)
    ' ''' </summary>
    ' ''' <param name="searchFileName"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetProcessesByFileName64(searchFileName As String) As System.Diagnostics.Process()
    '    searchFileName = searchFileName.ToLower()
    '    Dim list As New System.Collections.ArrayList()
    '    Dim dic As New Dictionary(Of String, String)
    '    Try
    '        Using mc As New System.Management.ManagementClass("Win32_Process")
    '            Using moc As System.Management.ManagementObjectCollection = mc.GetInstances()
    '                Dim mo As System.Management.ManagementObject
    '                For Each mo In moc
    '                    Console.WriteLine("プロセス名:{0}", mo("Name"))
    '                    Console.WriteLine("プロセスID:{0}", mo("ProcessId"))
    '                    Console.WriteLine("ファイル名:{0}", mo("ExecutablePath"))
    '                    If Not IsNothing(mo("ExecutablePath")) Then
    '                        If mo("ExecutablePath").ToString.ToLower.IndexOf(searchFileName) > -1 Then
    '                            dic.Add(mo("ProcessId").ToString(), mo("ExecutablePath").ToString())
    '                        End If
    '                    End If
    '                    mo.Dispose()
    '                Next
    '            End Using
    '        End Using

    '        '名前からプロセスを特定する
    '        For Each p As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
    '            If p.MainWindowHandle <> IntPtr.Zero Then
    '                If (dic.ContainsKey(p.Id.ToString())) Then
    '                    list.Add(p)
    '                End If
    '            End If
    '        Next

    '        'コレクションを配列にして返す
    '        Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)), System.Diagnostics.Process())

    '    Catch ex As Exception
    '        MsgBox(ex.Message, 48, "プロセス列挙エラー64")
    '        Return Nothing
    '    End Try

    'End Function
#End Region

    Dim img2 As Image = Nothing '追加するイメージ
    Dim imgz As Decimal = 1 '追加イメージ縮率
    Dim imga As Decimal = 0 '追加イメージ縮率
    ''' <summary>
    ''' 画像追加メニュー
    ''' </summary>
    ''' <param name="Img"></param>
    ''' <remarks></remarks>
    Private Sub AddPicture(Optional Img As Image = Nothing)
        If Not PictureBox2.Visible Then
            If IsNothing(Img) Then
                '既定の画像の指定が無ければ選択する様にする
                Dim FL As String = ""
                Using OFD As New OpenFileDialog
                    With OFD
                        .CheckFileExists = True
                        .CheckPathExists = True
                        .Filter = "画像ファイル(*.bmp,*.jpg,*.jpeg,*.png,*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif|全てのファイル(*.*)|*.*"
                        .FilterIndex = 0
                        .Multiselect = False
                        .RestoreDirectory = True
                        .Title = "追加する画像ファイル"
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            FL = .FileName
                        End If
                    End With
                End Using
                If FL <> "" Then
                    img2 = Image.FromFile(FL)
                Else
                    Return
                End If
            Else
                img2 = Img
            End If

            If Not IsNothing(img2) Then
                imga = 0 '画像角度のリセット
                Dim MM As Bitmap = PictureBox1.Image
                UNDO_Array.Add(New Bitmap(MM))
                MenuUndo.Enabled = True

                Me.Text = String.Format("{0}(画像モード)", _Title)
                PictureBox2.Visible = True
                _DrawMode = DrawMode.ModePicture
                Dim canvas As New Bitmap(PictureBox2.Width, PictureBox2.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Using g As Graphics = Graphics.FromImage(canvas)
                    'g.DrawImage(img2, 0, 0, img2.Width * imgz, img2.Height * imgz)

                    '画像をcanvasの座標(0, 0)の位置に描画する
                    '画像枠計算
                    Dim ImageRectPoints() As PointF = Calc3Point(canvas.Size.Width / 2, canvas.Size.Height / 2, img2.Width * imgz, img2.Height * imgz, imga)
                    '画像を表示
                    g.DrawImage(img2, ImageRectPoints)
                End Using

                PictureBox2.Image = canvas
            End If

        End If
    End Sub
    ''' <summary>
    ''' 任意画像追加メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddPicture_Click(sender As Object, e As EventArgs) Handles MenuAddPicture.Click
        Call AddPicture()
    End Sub
    ''' <summary>
    ''' 所定アイコン追加メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddPicture2_Click(sender As Object, e As EventArgs)
        Dim Obj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Call AddPicture(Obj.Tag)
    End Sub

    ''' <summary>
    ''' 拡大率を戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAddPicture_100_Click(sender As Object, e As EventArgs) Handles MenuAddPicture_100.Click
        imgz = 1
        Call DrawIcon()
    End Sub
    ''' <summary>
    ''' 描写色選択（任意）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSelectColor_Other_Click(sender As Object, e As EventArgs) Handles MenuSelectColor_Other.Click
        With FrmOnigiriSUB_Color
            .SelColor = _ULineColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                _ULineColor = .SelColor
            End If
        End With
    End Sub
    ''' <summary>
    ''' 描写色選択（赤）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSelectColor_Red_Click(sender As Object, e As EventArgs) Handles MenuSelectColor_Red.Click
        _ULineColor = Color.Red
    End Sub
    ''' <summary>
    ''' 描写色選択（青）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSelectColor_Blue_Click(sender As Object, e As EventArgs) Handles MenuSelectColor_Blue.Click
        _ULineColor = Color.Blue
    End Sub
    ''' <summary>
    ''' 描写色選択（白）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSelectColor_While_Click(sender As Object, e As EventArgs) Handles MenuSelectColor_While.Click
        _ULineColor = Color.White
    End Sub
    ''' <summary>
    ''' 描写色選択（黒）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSelectColor_Black_Click(sender As Object, e As EventArgs) Handles MenuSelectColor_Black.Click
        _ULineColor = Color.Black
    End Sub

    ''' <summary>
    ''' 線幅設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuLineWidth_Click(sender As Object, e As EventArgs) Handles MenuLineWidth.Click
        If FrmOnigiriSetting.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If ReadReg("General", "OnigiriDrawPenSize", enum_Type.er_Integer) > 0 Then
                _PenSize = ReadReg("General", "OnigiriDrawPenSize", enum_Type.er_Integer)
            End If
            If ReadReg("General", "OnigiriDrawArrowHead", enum_Type.er_Integer) > 0 Then
                _ArrowHead = ReadReg("General", "OnigiriDrawArrowHead", enum_Type.er_Integer)
            End If
        End If
    End Sub
    ''' <summary>
    ''' TODO:画像中バーコード認識
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuBarcode_Click(sender As Object, e As EventArgs) Handles MenuBarcode.Click
        Try
            If Not ReadBarcode(Me, PictureBox1.Image) Then

            End If
        Catch ex As Exception
            MsgBox("バーコード解析エラー", 48, "エラー")
        End Try
    End Sub
    ''' <summary>
    ''' ヘルプ表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOnigiriHelp_Click(sender As Object, e As EventArgs) Handles MenuOnigiriHelp.Click
        Dim _FL As String = AppFullPath("OnigiriHelp.txt")
        If File.Exists(_FL) Then
            Try
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(_FL)
            Catch ex As Exception
                MsgBox("ヘルプテキストの起動に失敗しました", 48, "エラー")
            End Try
        End If
    End Sub
    ''' <summary>
    ''' TODO:直接メール送信
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendMail_Click(sender As Object, e As EventArgs) Handles MenuSendMail.Click
        If MailSettingCheck() Then
            Dim _ToAddress As String = "" ' ReadReg("Mail", "ToAddress")
            Dim _Note As String = ""
            With FrmOnigiri_SendMail
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _ToAddress = .ToAddress
                    _Note = .SendNote
                Else
                    Return
                End If
            End With

            Dim _Title As String = Me.Text
            Dim Obj As ToolStripMenuItem = sender
            Dim Index As Integer = Obj.Tag
            Dim rect As Rectangle = PictureBox1.ClientRectangle

            If Not ReadReg("Mail", "SendNoAccept", enum_Type.er_Boolean) Then
                If MsgBox(String.Format("{0}宛にメールを送ってもいいですか？", _ToAddress), 4 + 32, "確認") = MsgBoxResult.No Then
                    Return
                End If
            End If

            Me.Text = String.Format("{0}(メール送信中)", _Title)
            Application.DoEvents()
            Try
                'PictureBox1に表示されている画像を取得するためのBitmap
                Using bmp As New Bitmap(rect.Width, rect.Height)
                    'bmpに画像を入れるための準備
                    Using g As Graphics = Graphics.FromImage(bmp)
                        Dim pea As New PaintEventArgs(g, rect)

                        'PaintBackgroundイベントを発生
                        Me.InvokePaintBackground(PictureBox1, pea)
                        'Paintイベントを発生
                        Me.InvokePaint(PictureBox1, pea)
                        Dim _FL As String = SystemFullPath(Environment.SpecialFolder.ApplicationData, String.Format("{0:yyyyMMddHHmmss}.jpg", Now))
                        bmp.Save(_FL, System.Drawing.Imaging.ImageFormat.Jpeg)

                        If SendMail(_FL, _ToAddress, _Note) Then
                            If ReadReg("General", "AutoOnigiriClose", enum_Type.er_Boolean) Then
                                Call MenuMeClose_Click(Nothing, Nothing)
                            End If
                            MsgBox("メール送信完了", 64, "情報")
                        Else
                            MsgBox("メール送信失敗", 48, "エラー")
                        End If

                        File.Delete(_FL)
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

            End Try
            Me.Text = _Title
        Else
            MsgBox("メール送信の為の設定が行われていません", 48, "エラー")
        End If

    End Sub
    ''' <summary>
    ''' おにぎりセット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOnigiriSet_Click(sender As Object, e As EventArgs) Handles MenuOnigiriSet.Click
        If IsNothing(OnigiriSetStat) Then
            Dim FR As New FrmOnigiriSet
            FR.Show()
            FR.SetPict()
        Else
            OnigiriSetStat.AddPic(PictureBox1.Image)
            Me.Close()
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave

    End Sub
End Class
Public Class NumericD
    Public Max As Decimal
    Public Min As Decimal
    Public Value As Decimal
    Sub New(Max As Decimal, Min As Decimal)
        Me.Max = Max
        Me.Min = Min
    End Sub
End Class