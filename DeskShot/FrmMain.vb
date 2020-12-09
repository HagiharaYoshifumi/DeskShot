Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports AForge.Video
Imports AForge.Video.DirectShow
Public Class FrmMain
   
    Dim WithEvents FCF As New ClassFormControl
    Dim _WorkMode As WorkModeClass.enumWorkMode = WorkModeClass.enumWorkMode.VideoSave
    Dim _IsWork As Boolean = False

    Public _BaseFolder As String = ""
    Dim _WorkFolder As String = SystemFullPath(Environment.SpecialFolder.ApplicationData, "workfolder") 'AppFullPath("workfolder")
    Dim _FileName As String = ""
    Public _Bmp As New List(Of Bitmap)
    Dim _FormHistory As New List(Of ClassFormPosition) '前の位置に戻る用

    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    ''' <summary>
    ''' フォームクローズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _OnigiriForm.Count > 0 Then
            If MsgBox("おにぎりフォームが起動されていますが、終了を継続しますか？", 4 + 32, "終了確認") = MsgBoxResult.No Then
                e.Cancel = True
                Return
            End If
        End If
        If Not IsNothing(OnigiriSetStat) Then
            If OnigiriSetStat.TabControl1.TabCount > 0 Then
                If MsgBox("おにぎりセットが起動されていますが、終了を継続しますか？", 4 + 32, "終了確認") = MsgBoxResult.No Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
        GcGlobalHook1.EnableKeyboardHook = False
        Timer1.Enabled = False
        Call SavePosiData()
        Call WriteReg("General", "SaveFolder", _BaseFolder)
        Call WriteReg("General", "KeyHook", MenuSetting_KeyHook.Checked)
        'Select Case 
        'VideoSave = 0
        'VideoSaveAs = 1
        'PictureSave_Bitmap = 2
        'PictureSave_JPEG = 3
        'PictureSave_PNG = 4
        'PictureSaveAs = 5
        'PictureSaveClipbord = 6

        Call WriteReg("General", "WorkMode", _WorkMode.GetHashCode)
        Call WriteReg("General", "AutoSmall", MenuAutoSmall.Checked)

        Call MenuInput_Screen_Click(Nothing, Nothing) 'カメラ停止
    End Sub
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Visible = False

        Try
            _BaseFolder = ReadReg("General", "SaveFolder")
            If Not String.IsNullOrEmpty(_BaseFolder) AndAlso Directory.Exists(_BaseFolder) Then
            Else
                _BaseFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                Call WriteReg("General", "SaveFolder", _BaseFolder)
            End If
            If ReadReg("General", "ShotInterval", enum_Type.er_Integer) > 0 Then
                Timer1.Interval = ReadReg("General", "ShotInterval", enum_Type.er_Integer)
            Else
                Timer1.Interval = 100
                Call WriteReg("General", "ShotInterval", 100)
            End If
            My.Settings.Save()

            If Not Directory.Exists(_WorkFolder) Then
                Directory.CreateDirectory(_WorkFolder)
            End If
            MenuAutoSmall.Checked = ReadReg("General", "AutoSmall", enum_Type.er_Boolean)

            LblimeStamp.Visible = ReadReg("General", "ImageTimeStamp", enum_Type.er_Boolean)
            If ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer) = 0 Then
                LblimeStamp.Location = New Point(5, 5)
            End If

            Call ScreenInitial()

            'ウィンドウ自動追尾間隔
            If ReadReg("General", "FollowInterval", enum_Type.er_Integer) > 10 Then
                Timer_AutoFollow.Interval = ReadReg("General", "FollowInterval", enum_Type.er_Integer)
            Else
                Timer_AutoFollow.Interval = 10
                Call WriteReg("General", "FollowInterval", 10)
            End If

            Me.TopMost = True
            Me.TransparencyKey = Color.Fuchsia
            FCF.TargetForm = Me
            Call FCF.AddButtonIcon(Panel1)
            Call LoadPosiData()
            Call GetPosiShift()

            Me.PictureBox1.BorderStyle = BorderStyle.FixedSingle
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.ControlBox = False
            Me.Text = ""

            'Me.Activate()
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "フォームロードエラー")
        End Try
       
    End Sub
    ''' <summary>
    ''' フォームショーン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            MenuSetting_KeyHook.Checked = ReadReg("General", "KeyHook", enum_Type.er_Boolean)
            GcGlobalHook1.EnableKeyboardHook = ReadReg("General", "KeyHook", enum_Type.er_Boolean)

            Me.WindowState = FormWindowState.Normal
            Me.Visible = True
            Me.Activate()
            PanelCamera.Visible = False

            _FormInitial = False
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "フォームエラー")

        End Try
    End Sub
    ''' <summary>
    ''' フォーム移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Move(sender As Object, e As EventArgs) Handles Me.Move
        Label2.Text = String.Format("Position: X={0} Y={1}", Me.Location.X, Me.Location.Y)
    End Sub
    ''' <summary>
    ''' フォームリサイズ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Dim _X1 As Integer = (Me.Size.Width - Label2.Size.Width) / 2
            Dim _Y1 As Integer = (Me.Size.Height / 2) - Label2.Size.Height
            Label2.Location = New Point(_X1, _Y1)
            Label3.Location = New Point(_X1, _Y1 + Label2.Height + 5)
            Label3.Text = String.Format("Size    : W={0} H={1}", Me.Size.Width, Me.Size.Height)
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "リサイズエラー")

        End Try
       
    End Sub

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenInitial()
        Try
            MenuMode_VideoSave.Checked = False : MenuMode_VideoSave.Tag = WorkModeClass.enumWorkMode.VideoSave
            MenuMode_VideoAsSave.Checked = False : MenuMode_VideoAsSave.Tag = WorkModeClass.enumWorkMode.VideoSaveAs
            MenuMode_PictureSave_BMP.Checked = False : MenuMode_PictureSave_BMP.Tag = WorkModeClass.enumWorkMode.PictureSave_Bitmap
            MenuMode_PictureSave_JPEG.Checked = False : MenuMode_PictureSave_JPEG.Tag = WorkModeClass.enumWorkMode.PictureSave_JPEG
            MenuMode_PictureSave_PNG.Checked = False : MenuMode_PictureSave_PNG.Tag = WorkModeClass.enumWorkMode.PictureSave_PNG
            MenuMode_PictureAsSave.Checked = False : MenuMode_PictureAsSave.Tag = WorkModeClass.enumWorkMode.PictureSaveAs
            MenuMode_PictureClipbord.Checked = False : MenuMode_PictureClipbord.Tag = WorkModeClass.enumWorkMode.PictureSaveClipbord
            MenuMode_PictureWordpad.Checked = False : MenuMode_PictureWordpad.Tag = WorkModeClass.enumWorkMode.PictureSaveWordpad
            MenuMode_PicturePrint.Checked = False : MenuMode_PicturePrint.Tag = WorkModeClass.enumWorkMode.PicturePrintOut
            MenuMode_Onigiri.Checked = False : MenuMode_Onigiri.Tag = WorkModeClass.enumWorkMode.PictureOnigiri
            MenuMode_OnigiriSet.Checked = False : MenuMode_OnigiriSet.Tag = WorkModeClass.enumWorkMode.PictureOnigiriSet

            Dim _Y As Integer = ReadReg("General", "WorkMode", enum_Type.er_Integer)
            Select Case ReadReg("General", "WorkMode", enum_Type.er_Integer)
                Case 1
                    MenuMode_VideoAsSave.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.VideoSaveAs
                    BtnExecute.Image = My.Resources.film_save_icon
                Case 2
                    MenuMode_PictureSave_BMP.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSave_Bitmap
                    BtnExecute.Image = My.Resources.file_extension_bmp_icon
                Case 3
                    MenuMode_PictureSave_JPEG.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSave_JPEG
                    BtnExecute.Image = My.Resources.file_extension_jpg_icon
                Case 4
                    MenuMode_PictureSave_PNG.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSave_PNG
                    BtnExecute.Image = My.Resources.file_extension_png_icon
                Case 5
                    MenuMode_PictureAsSave.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSaveAs
                    BtnExecute.Image = My.Resources.camera_edit_icon
                Case 6
                    MenuMode_PictureClipbord.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSaveClipbord
                    BtnExecute.Image = My.Resources.camera_go_icon
                Case 7
                    MenuMode_PicturePrint.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PicturePrintOut
                    BtnExecute.Image = My.Resources.printer_icon
                Case 8
                    MenuMode_Onigiri.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                    BtnExecute.Image = MenuMode_Onigiri.Image 'My.Resources.Onigiri_icon
                Case 9
                    MenuMode_PictureWordpad.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureSaveWordpad
                    BtnExecute.Image = My.Resources.Wordpad_icon
                Case 10
                    MenuMode_OnigiriSet.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiriSet
                    BtnExecute.Image = MenuMode_OnigiriSet.Image
                Case Else
                    MenuMode_VideoSave.Checked = True : _WorkMode = WorkModeClass.enumWorkMode.VideoSave
                    BtnExecute.Image = My.Resources.film_icon
            End Select
            Call ChangeWorkScreen()

            If _WorkMode = WorkModeClass.enumWorkMode.VideoSave OrElse _WorkMode = WorkModeClass.enumWorkMode.VideoSaveAs Then
                BtnDialog.Visible = False
                BtnDesktop.Visible = False
            Else
                BtnDialog.Visible = True
                BtnDesktop.Visible = True
            End If

            Label2.Parent = PictureBox1
            Label3.Parent = PictureBox1
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "画面初期化エラー")

        End Try
       
    End Sub
    Dim _BmpFileName As New List(Of String)
    Dim _FrameNo As Integer = 0
    ''' <summary>
    ''' GIF作成タイマー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim P As Point = Me.PictureBox1.PointToScreen(New Point(0, 0))

        Label1.Text = String.Format("録画中...{0}", _FrameNo)
        Application.DoEvents()

        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Dim curPoint As Point = Cursor.Position
        Dim hotSpot As Point = Me.Cursor.HotSpot
        Dim position As Point = New Point((curPoint.X - hotSpot.X), (curPoint.Y - hotSpot.Y))

        Try
            Dim bmp As New Bitmap(PictureBox1.Width - 2, PictureBox1.Height - 2) ', Drawing.Imaging.PixelFormat.Format48bppRgb)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.CopyFromScreen(New Point(P.X, P.Y), New Point(0, 0), bmp.Size)
                Me.Cursor.Draw(g, New Rectangle(New Point(position.X - P.X, position.Y - P.Y), Me.Cursor.Size))

                '_Bmp.Add(bmp)
                GC.Collect()

                Dim FN As String = My.Computer.FileSystem.CombinePath(_WorkFolder, CreateTempFileName)
                bmp.Save(FN)
                _BmpFileName.Add(FN)
            End Using
        Catch ex As Exception

        End Try

        _FrameNo += 1
        Timer1.Enabled = True
    End Sub
    ''' <summary>
    ''' 最小化ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnWindowSmall_Click(sender As Object, e As EventArgs) Handles BtnWindowSmall.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Return
        End If
        If _IsWork Then
            Return
        End If
        Me.WindowState = FormWindowState.Minimized
    End Sub
    ''' <summary>
    ''' 終了メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAPPEnd_Click(sender As Object, e As EventArgs) Handles MenuAPPEnd.Click
        If MenuAPPEnd.Tag = 1 Then
            ConMenuMain.Hide()
        Else
            Me.Close()
        End If
    End Sub
    ''' <summary>
    ''' 動作モードの変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChangeMode(sender As Object, e As EventArgs) Handles MenuMode_VideoSave.Click, MenuMode_VideoAsSave.Click, MenuMode_PictureSave_BMP.Click, MenuMode_PictureSave_JPEG.Click, MenuMode_PictureSave_PNG.Click, MenuMode_PictureAsSave.Click, MenuMode_PictureClipbord.Click, MenuMode_PicturePrint.Click, MenuMode_Onigiri.Click, MenuMode_OnigiriSet.Click, MenuMode_PictureWordpad.Click
        Try
            MenuMode_VideoSave.Checked = False
            MenuMode_VideoAsSave.Checked = False
            MenuMode_PictureSave_BMP.Checked = False
            MenuMode_PictureSave_JPEG.Checked = False
            MenuMode_PictureSave_PNG.Checked = False
            MenuMode_PictureAsSave.Checked = False
            MenuMode_PictureClipbord.Checked = False
            MenuMode_PictureWordpad.Checked = False
            MenuMode_PicturePrint.Checked = False
            MenuMode_Onigiri.Checked = False
            MenuMode_OnigiriSet.Checked = False

            Dim Obj As ToolStripMenuItem = sender
            Obj.Checked = True
            _WorkMode = Obj.Tag
            Select Case _WorkMode
                Case WorkModeClass.enumWorkMode.VideoSave
                    BtnExecute.Image = My.Resources.film_icon
                Case WorkModeClass.enumWorkMode.VideoSaveAs
                    BtnExecute.Image = My.Resources.film_save_icon
                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap
                    BtnExecute.Image = My.Resources.file_extension_bmp_icon
                Case WorkModeClass.enumWorkMode.PictureSave_JPEG
                    BtnExecute.Image = My.Resources.file_extension_jpg_icon
                Case WorkModeClass.enumWorkMode.PictureSave_PNG
                    BtnExecute.Image = My.Resources.file_extension_png_icon
                Case WorkModeClass.enumWorkMode.PictureSaveAs
                    BtnExecute.Image = My.Resources.camera_edit_icon
                Case WorkModeClass.enumWorkMode.PictureSaveClipbord
                    BtnExecute.Image = My.Resources.camera_go_icon
                Case WorkModeClass.enumWorkMode.PictureSaveWordpad
                    BtnExecute.Image = My.Resources.Wordpad_icon
                Case WorkModeClass.enumWorkMode.PicturePrintOut
                    BtnExecute.Image = My.Resources.printer_icon
                Case WorkModeClass.enumWorkMode.PictureOnigiri
                    BtnExecute.Image = MenuMode_Onigiri.Image 'My.Resources.Onigiri_icon
                Case WorkModeClass.enumWorkMode.PictureOnigiriSet
                    BtnExecute.Image = MenuMode_OnigiriSet.Image
            End Select

            Call ChangeWorkScreen()
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "モード変更エラー")

        End Try

    End Sub
    ''' <summary>
    ''' モード変更時の画面調整
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeWorkScreen()
        Try
            Select Case _WorkMode
                Case WorkModeClass.enumWorkMode.VideoSave '動画（自動保存）
                    BtnDialog.Visible = False
                    BtnDesktop.Visible = False
                    MenuWork_DialogFit.Enabled = False
                    MenuWork_AllScreen.Enabled = False

                    Timer_AutoFollow.Enabled = False
                    MenuFormPosition_AutoFollow.Checked = False
                    MenuFormPosition_AutoFollow.Enabled = False
                    MenuAutoFollow.Checked = False
                    MenuAutoFollow.Enabled = False
                    BtnFitSize.Image = My.Resources.zoom_fit_icon

                Case WorkModeClass.enumWorkMode.VideoSaveAs '動画（手動保存）
                    BtnDialog.Visible = False
                    BtnDesktop.Visible = False
                    MenuWork_DialogFit.Enabled = False
                    MenuWork_AllScreen.Enabled = False

                    Timer_AutoFollow.Enabled = False
                    MenuFormPosition_AutoFollow.Checked = False
                    MenuFormPosition_AutoFollow.Enabled = False
                    MenuAutoFollow.Checked = False
                    MenuAutoFollow.Enabled = False
                    BtnFitSize.Image = My.Resources.zoom_fit_icon

                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap '静止画（ビットマップ）
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureSave_JPEG '静止画（ＪＰＥＧ）
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureSave_PNG '静止画（ＰＮＧ）
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureSaveAs '静止画（手動保存）
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureSaveClipbord 'クリップボード
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureSaveWordpad 'ワードパッド連携
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = True
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PictureOnigiri, WorkModeClass.enumWorkMode.PictureOnigiriSet 'おにぎり
                    BtnDialog.Visible = True
                    BtnDesktop.Visible = False
                    MenuWork_DialogFit.Enabled = True
                    MenuWork_AllScreen.Enabled = True
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

                Case WorkModeClass.enumWorkMode.PicturePrintOut 'プリントアウト
                    BtnDialog.Visible = False
                    BtnDesktop.Visible = False
                    MenuWork_DialogFit.Enabled = False
                    MenuWork_AllScreen.Enabled = False
                    MenuFormPosition_AutoFollow.Enabled = True
                    MenuAutoFollow.Enabled = True

            End Select

            '自動最小化の設定
            'If _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri Then
            '    MenuAutoSmall.Checked = True
            'Else
            '    MenuAutoSmall.Checked = False
            'End If

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "画面調整エラー")

        End Try
       
    End Sub
    ''' <summary>
    ''' スナップタイマー数設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckShotTimer() As Integer
        Select Case True
            Case MenuShotTimer1.Checked : Return 3
            Case MenuShotTimer2.Checked : Return 5
            Case MenuShotTimer3.Checked : Return 10
            Case MenuShotTimer4.Checked : Return 15
            Case MenuShotTimer5.Checked : Return 20
            Case Else : Return 0
        End Select
    End Function
    Dim _ShotTimerCancel As Boolean = False
    ''' <summary>
    ''' 作業開始ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExecute_Click(sender As Object, e As EventArgs) Handles BtnExecute.Click
        Try
            If PanelCamera.Visible Then
                If Not _CamIsExecute Then
                    '入力デバイスがカメラでカメラ撮影していない場合は作業はキャンセルする
                    Return
                End If
            End If

            Select Case _WorkMode
                Case WorkModeClass.enumWorkMode.VideoSave, WorkModeClass.enumWorkMode.VideoSaveAs '動画
                    If Not _IsWork Then
                        FCF.Lock = True 'GIF作成中はサイズ変更禁止
                        Call VideoStart()
                    Else
                        Call VideoStop()
                        FCF.Lock = False 'サイズ変更禁止解除
                        Call AddFormHistory() 'ポジションの記憶
                        'If MenuAutoSmall.Checked Then
                        '    Me.WindowState = FormWindowState.Minimized
                        'End If
                    End If

                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap, WorkModeClass.enumWorkMode.PictureSave_JPEG, WorkModeClass.enumWorkMode.PictureSave_PNG '静止画
                    If CheckShotTimer() = 0 Then
                        Call PictureSave(GetPicture())
                        Call AddFormHistory() 'ポジションの記憶

                        If MenuAutoSmall.Checked Then
                            Me.WindowState = FormWindowState.Minimized
                        End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If

                Case WorkModeClass.enumWorkMode.PictureSaveAs '静止画（保存）
                    Call PictureSaveAs(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶

                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                Case WorkModeClass.enumWorkMode.PictureSaveClipbord 'クリップボード
                    If CheckShotTimer() = 0 Then
                        Call PictureClipbord(GetPicture())
                        Call AddFormHistory() 'ポジションの記憶

                        If MenuAutoSmall.Checked Then
                            Me.WindowState = FormWindowState.Minimized
                        End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If

                Case WorkModeClass.enumWorkMode.PictureSaveWordpad 'ワードパッド
                    If CheckShotTimer() = 0 Then
                        Call PictureWordpad(GetPicture())
                        Call AddFormHistory() 'ポジションの記憶

                        If MenuAutoSmall.Checked Then
                            Me.WindowState = FormWindowState.Minimized
                        End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If

                Case WorkModeClass.enumWorkMode.PictureOnigiri 'おにぎり
                    'おにぎりサイズ警告
                    If ReadReg("General", "OnigiriSizeWarning", enum_Type.er_Boolean) Then
                        If Me.Size.Width < 115 OrElse Me.Size.Height < 115 Then
                            Dim _Mode As Integer = -1
                            With FrmOnigiriSizeSelect
                                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                    _Mode = .SelectMode
                                Else
                                    Return
                                End If
                            End With

                            System.Threading.Thread.Sleep(200)
                            Application.DoEvents()

                            Select Case _Mode
                                Case 1
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSaveWordpad
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 2
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSaveClipbord
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 3
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_Bitmap
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 4
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_JPEG
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 5
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_PNG
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case Else

                            End Select
                        End If
                    End If

                    If CheckShotTimer() = 0 Then
                        Call PictureClipbord(GetPicture())
                        Call AddFormHistory() 'ポジションの記憶

                        Dim FR As New FrmOnigiri
                        FR.Tag = CreateFormID
                        FR.Show()
                        _OnigiriForm.Add(FR)
                        If MenuAutoSmall.Checked Then
                            Me.WindowState = FormWindowState.Minimized
                        End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If

                Case WorkModeClass.enumWorkMode.PictureOnigiriSet 'おにぎりセット
                    'おにぎりサイズ警告
                    If ReadReg("General", "OnigiriSizeWarning", enum_Type.er_Boolean) Then
                        If Me.Size.Width < 115 OrElse Me.Size.Height < 115 Then
                            Dim _Mode As Integer = -1
                            With FrmOnigiriSizeSelect
                                .IsOnigiriSet = True
                                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                    _Mode = .SelectMode
                                Else
                                    Return
                                End If
                            End With

                            System.Threading.Thread.Sleep(200)
                            Application.DoEvents()

                            Select Case _Mode
                                Case 1
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSaveWordpad
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 2
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSaveClipbord
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 3
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_Bitmap
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 4
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_JPEG
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case 5
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureSave_PNG
                                    Call BtnExecute_Click(Nothing, Nothing)
                                    _WorkMode = WorkModeClass.enumWorkMode.PictureOnigiri
                                    Return
                                Case Else

                            End Select
                        End If
                    End If

                    If CheckShotTimer() = 0 Then
                        Dim Img As Image = GetPicture()
                        Call AddFormHistory() 'ポジションの記憶

                        If IsNothing(OnigiriSetStat) Then 'おにぎりセットが立ち上がってなかったら立ち上げる
                            Dim FR As New FrmOnigiriSet
                            FR.Show()
                        End If
                        OnigiriSetStat.AddPic(Img)

                        If MenuAutoSmall.Checked Then
                            Me.WindowState = FormWindowState.Minimized
                        End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If

                Case WorkModeClass.enumWorkMode.PicturePrintOut  'プリントアウト
                    If CheckShotTimer() = 0 Then
                        Dim BMPData As Bitmap = GetPicture()
                        _FileName = String.Format("{0:yyyyMMddHHmmss}.bmp", Now)
                        '_FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                        _FileName = My.Computer.FileSystem.CombinePath(SystemFullPath(Environment.SpecialFolder.ApplicationData, "workfolder"), _FileName)

                        BMPData.Save(_FileName, System.Drawing.Imaging.ImageFormat.Bmp)

                        Dim pd As New System.Drawing.Printing.PrintDocument

                        pd.PrinterSettings.DefaultPageSettings.Landscape = True

                        'PrintPageイベントハンドラの追加
                        AddHandler pd.PrintPage, AddressOf pd_PrintPage
                        '印刷を開始する
                        'pd.PrinterSettings.DefaultPageSettings.PrintableArea.Width
                        pd.Print()

                        Label1.Text = "プリンタ出力完了"
                        Timer2.Enabled = True
                        Call AddFormHistory() 'ポジションの記憶

                        'If MenuAutoSmall.Checked Then
                        '    Me.WindowState = FormWindowState.Minimized
                        'End If
                    Else
                        If _ShotTimer.Enabled Then
                            _ShotTimer.Enabled = False
                            Label1.Text = "ショットタイマー中止"
                            Timer2.Enabled = True
                        Else
                            _ShotTimerCount = CheckShotTimer()
                            _ShotTimer.Interval = 1000
                            _ShotTimer.Enabled = True
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "作業開始エラー")

        End Try

    End Sub
    Public _OnigiriForm As New List(Of FrmOnigiri)
    ''' <summary>
    ''' 現在のメインフォームの位置・サイズを記憶
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddFormHistory()
        Try
            Dim _AddPosi As Boolean = True

            If _FormHistory.Count > 0 Then
                'さっきと位置＆サイズが一緒なら記憶しない
                If Me.Location = _FormHistory.Last.Position Then
                    If Me.Size = _FormHistory.Last.FormSize Then
                        _AddPosi = False
                    End If
                End If
            End If
            If _AddPosi Then
                If Me.WindowState <> FormWindowState.Minimized Then
                    Dim _T As New ClassFormPosition
                    _T.ID = ""
                    _T.Position = Me.Location
                    _T.FormSize = Me.Size
                    _FormHistory.Add(_T)
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try

    End Sub
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
    ''' ＧＩＦ録画開始
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VideoStart()
        _IsWork = True

        _FileName = ""
        _Bmp.Clear()
        _BmpFileName.Clear()
        _FrameNo = 1

        Timer1.Enabled = True
    End Sub
    ''' <summary>
    ''' キャプチャー画像の追加
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateImage(ByVal filename As String) As System.Drawing.Image
        Try
            Dim img As System.Drawing.Image
            Using fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                img = System.Drawing.Image.FromStream(fs, False)
            End Using
            Return img
        Catch ex As Exception
            Return Nothing
        End Try
    
    End Function
    ''' <summary>
    ''' ＧＩＦ録画終了
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VideoStop()
        Me.Cursor = Cursors.WaitCursor
        Timer1.Enabled = False
        Application.DoEvents()

        System.Threading.Thread.Sleep(1000)
        Dim I As Integer = 1
        For Each S As String In _BmpFileName
            Label1.Text = String.Format("保存中...{0}/{1}", I, _BmpFileName.Count)
            Application.DoEvents()

            _Bmp.Add(CreateImage(S))
            System.IO.File.Delete(S)
            I += 1
        Next

        Label1.Text = "GIFファイル書き込み中..."
        Application.DoEvents()
        If _WorkMode = WorkModeClass.enumWorkMode.VideoSave Then
            Call VideoSave()
        Else
            Call VisedSaveAs()
        End If

        Label1.Text = "保存完了"
        Timer2.Enabled = True
        Me.Cursor = Cursors.Default
        _IsWork = False
    End Sub
    ''' <summary>
    ''' ＧＩＦファイル保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VideoSave()
        _FileName = String.Format("{0:yyyyMMddHHmmss}.gif", Now)
        _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
        Dim _IL As Integer = ReadReg("General", "ImageLoop", enum_Type.er_Integer)
        If _IL = 0 Then _IL = 100
        Dim DelayTime As Integer = ReadReg("General", "GifDelayTime", enum_Type.er_Integer)
        Call SaveAnimatedGif(_FileName, _Bmp.ToArray, DelayTime, _IL)
    End Sub
    ''' <summary>
    ''' ＧＩＦファイル保存（名前を付けて）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VisedSaveAs()
        Dim FN As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                .DefaultExt = ".gif"
                .FileName = String.Format("{0:yyyyMMddHHmmss}", Now)
                .Filter = "GIFファイル(*.gif)|*.gif|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .RestoreDirectory = True
                .Title = "動画の保存"
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    FN = .FileName
                End If
            End With
        End Using
        If Not String.IsNullOrEmpty(FN) Then
            _FileName = FN
            Dim _IL As Integer = ReadReg("General", "ImageLoop", enum_Type.er_Integer)
            If _IL = 0 Then _IL = 100
            Dim DelayTime As Integer = ReadReg("General", "GifDelayTime", enum_Type.er_Integer)
            Call SaveAnimatedGif(_FileName, _Bmp.ToArray, DelayTime, _IL)
        End If
    End Sub
    ''' <summary>
    ''' 画面をクリップ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPicture() As Bitmap
        Try
            Dim P As Point = Me.PictureBox1.PointToScreen(New Point(0, 0))

            Me.Cursor = New Cursor(Cursor.Current.Handle)
            Dim curPoint As Point = Cursor.Position
            Dim hotSpot As Point = Me.Cursor.HotSpot
            Dim position As Point = New Point((curPoint.X - hotSpot.X), (curPoint.Y - hotSpot.Y))

            'Dim bmp As New Bitmap(PictureBox1.Width - 2, PictureBox1.Height - 2, Drawing.Imaging.PixelFormat.Format48bppRgb)
            Dim bmp As New Bitmap(PictureBox1.Width - 2, PictureBox1.Height - 2)
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
    ''' 画像保存
    ''' </summary>
    ''' <param name="BMPData"></param>
    ''' <remarks></remarks>
    Private Sub PictureSave(BMPData As Bitmap)
        _IsWork = True
        Try
            Select Case _WorkMode
                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap 'ビットマップ
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.bmp", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    BMPData.Save(_FileName, System.Drawing.Imaging.ImageFormat.Bmp)
                Case WorkModeClass.enumWorkMode.PictureSave_JPEG 'ＪＰＥＧ
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.jpg", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    BMPData.Save(_FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case WorkModeClass.enumWorkMode.PictureSave_PNG 'ＰＮＧ
                    _FileName = String.Format("{0:yyyyMMddHHmmss}.png", Now)
                    _FileName = My.Computer.FileSystem.CombinePath(_BaseFolder, _FileName)
                    BMPData.Save(_FileName, System.Drawing.Imaging.ImageFormat.Png)
            End Select
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
        Label1.Text = "画像保存"
        Timer2.Enabled = True
        _IsWork = False
    End Sub
    ''' <summary>
    ''' 画像保存（名前を付けて）
    ''' </summary>
    ''' <param name="BMPData"></param>
    ''' <remarks></remarks>
    Private Sub PictureSaveAs(BMPData As Bitmap)
        _IsWork = True

        Try
            Dim FN As String = ""
            Using SFD As New SaveFileDialog
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .FileName = String.Format("{0:yyyyMMddHHmmss}", Now)
                    .Filter = "JPEGファイル(*.jpg)|*.jpg|PNGファイル(*.png)|*.png|ビットマップファイル(*.bmp)|*.bmp"
                    .FilterIndex = 0
                    .OverwritePrompt = True
                    .RestoreDirectory = True
                    .Title = "画像の保存"
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        FN = .FileName
                    End If
                End With
            End Using
            If Not String.IsNullOrEmpty(FN) Then
                Select Case Path.GetExtension(FN).ToUpper
                    Case ".JPG"
                        BMPData.Save(FN, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Case ".BMP"
                        BMPData.Save(FN, System.Drawing.Imaging.ImageFormat.Bmp)
                    Case ".PNG"
                        BMPData.Save(FN, System.Drawing.Imaging.ImageFormat.Png)
                End Select
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try

        _IsWork = False
    End Sub
    ''' <summary>
    ''' クリップボードへ画像を転送
    ''' </summary>
    ''' <param name="BMPData"></param>
    ''' <remarks></remarks>
    Private Sub PictureClipbord(BMPData As Bitmap)
        _IsWork = True
        Try
            Clipboard.SetDataObject(BMPData, True)
            Label1.Text = "クリップボード転送"
        Catch ex As Exception
            Label1.Text = "クリップボード転送失敗"
        End Try
        Timer2.Enabled = True
        _IsWork = False
    End Sub
#Region "ワードパッド連携関係"
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
    ''' 静止画（ワードパッド）
    ''' </summary>
    ''' <param name="BMPData"></param>
    ''' <remarks></remarks>
    Private Sub PictureWordpad(BMPData As Bitmap)
        _IsWork = True

        Timer_AutoFollow.Enabled = False
        Try
            Label1.Text = "ワードパッド連携中"
            Application.DoEvents()
            Clipboard.SetDataObject(BMPData, True)

            Select Case Execute_Wordpad() 'ワードパッド起動確認
                Case 0
                    'Wordpad未起動
                    If MsgBox("ワードパッドが起動されていません。" & vbCrLf & "ワードパッドを起動させますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                        Try
                            Dim psi As New System.Diagnostics.ProcessStartInfo()
                            psi.FileName = "wordpad.exe"
                            'WindowStyleにMinimizedを指定して、最小化された状態で起動されるようにする
                            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized
                            'アプリケーションを起動する
                            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
                            System.Threading.Thread.Sleep(1000)
                            'MsgBox("ワードパッドを起動させました。" & vbCrLf & "もう一度連携作業を実行してください。", 64, "情報")

                            With FrmDialog1
                                .MainFormPosition = Me.Location
                                If .ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                                    Label1.Text = ""
                                    Timer_AutoFollow.Enabled = MenuFormPosition_AutoFollow.Checked
                                    Return
                                End If
                            End With
                            'もしダイアログでOKなら再帰する
                            Call PictureWordpad(BMPData)
                        Catch ex As Exception
                            MsgBox(ExMessCreater(GetStack(ex)), 48, "WordPad起動エラー")
                        End Try
                    Else
                        Label1.Text = ""
                        _IsWork = False
                        Timer_AutoFollow.Enabled = MenuFormPosition_AutoFollow.Checked
                        Return
                    End If
                Case 1
                    'Wordpad連携
                    Try
                        '画像をクリップボードに送る
                        Clipboard.SetDataObject(BMPData, True)
                        System.Threading.Thread.Sleep(500)

                        Call WordPadWork(_WordpadStatus) 'ワードパッド操作

                        Label1.Text = "ワードパッド転送"
                    Catch ex As Exception
                        MsgBox(ExMessCreater(GetStack(ex)), 48, "WordPad連携エラー")

                    End Try
                Case Else
                    'その他（エラー）
                    MsgBox("ワードパッド転送に失敗しました" & vbCrLf & "申し訳ございませんが、もう一度実行してみてください。", 64, "情報")
            End Select

        Catch ex As Exception
            Label1.Text = "ワードパッド転送失敗"
        End Try
        Timer2.Enabled = True
        _IsWork = False

        Timer_AutoFollow.Enabled = MenuFormPosition_AutoFollow.Checked
    End Sub
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
                        '最小化なら通常の大きさに戻す
                        ShowWindowAsync(PP(0).MainWindowHandle, SW_RESTORE)
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
    ''' <summary>
    ''' ＧＩＦファイル再生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPlay_Click(sender As Object, e As EventArgs) Handles MenuPlay.Click
        If _WorkMode = WorkModeClass.enumWorkMode.PictureSaveClipbord Then
            If Clipboard.ContainsImage() Then
                Dim FR As New FrmViewer2
                With FR
                    .Show()
                End With
            End If
        Else
            If Not String.IsNullOrEmpty(_FileName) AndAlso File.Exists(_FileName) Then
                Me.WindowState = FormWindowState.Minimized
                'System.Diagnostics.Process.Start("iexplore.EXE", _FileName)
                Dim FR As New FrmViewer1
                With FR
                    .TargetFileName = _FileName
                    .Show()
                End With
            End If
        End If
    End Sub
    ''' <summary>
    ''' 作業フォルダを開く
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOpenFolder_Click(sender As Object, e As EventArgs) Handles MenuOpenFolder.Click
        If Not String.IsNullOrEmpty(_BaseFolder) AndAlso Directory.Exists(_BaseFolder) Then
            Me.WindowState = FormWindowState.Minimized
            System.Diagnostics.Process.Start("EXPLORER.EXE", "/e, " & _BaseFolder)
        End If
    End Sub
    ''' <summary>
    ''' コンテントメニューオープニング
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConMenuMain.Opening
        If _WorkMode = WorkModeClass.enumWorkMode.VideoSave OrElse _WorkMode = WorkModeClass.enumWorkMode.VideoSaveAs Then
            MenuVideoEdit.Enabled = True
        Else
            MenuVideoEdit.Enabled = False
        End If

        If _FormPosition.Count = 0 Then
            MenuFormPosition_View.Enabled = False
            MenuFormPosition_Clear.Enabled = False
        Else
            If _FormPositionForm.Count = 0 Then
                MenuFormPosition_View.Enabled = True
                MenuFormPosition_Clear.Enabled = True
            Else
                MenuFormPosition_View.Enabled = False
                MenuFormPosition_Clear.Enabled = False
            End If
        End If

        If _FormPositionForm.Count = 0 Then
            MenuFormPosition_Close.Enabled = False
        Else
            MenuFormPosition_Close.Enabled = True
        End If

        If _FormHistory.Count = 0 Then
            MenuMoveLast.Enabled = False
        Else
            MenuMoveLast.Enabled = True
        End If

        If _WorkMode = WorkModeClass.enumWorkMode.PictureSave_Bitmap OrElse _WorkMode = WorkModeClass.enumWorkMode.PictureSave_JPEG OrElse _WorkMode = WorkModeClass.enumWorkMode.PictureSave_PNG Then
            MenuMouseShotCaptuer.Enabled = True
        Else
            MenuMouseShotCaptuer.Enabled = False
        End If

    End Sub
    ''' <summary>
    ''' ＧＩＦファイル編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuVideoEdit_Click(sender As Object, e As EventArgs) Handles MenuVideoEdit.Click
        If _Bmp.Count > 0 Then
            Me.WindowState = FormWindowState.Minimized
            With FrmImageEdit
                .BmpData = _Bmp
                .ShowDialog()
            End With
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
    ''' <summary>
    ''' 一定時間でメッセージを消す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label1.Text = ""
        Timer2.Enabled = False
    End Sub
    Private Sub BtnExecute_MouseHover(sender As Object, e As EventArgs) Handles BtnExecute.MouseHover
        If Not _IsWork Then
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End If
    End Sub
    ''' <summary>
    ''' ダイアログフィット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDialog_Click(sender As Object, e As EventArgs) Handles BtnDialog.Click
        Call DialogFit(GetSiftPosi)
    End Sub
    ''' <summary>
    ''' ダイアログフィット
    ''' </summary>
    ''' <param name="SiftValue"></param>
    ''' <remarks></remarks>
    Public Sub DialogFit(SiftValue As PosiShift_Collection)
        _IsWork = True

        Dim _OrgPosi As Point = Me.Location
        Dim _OrgSize As Size = Me.Size
        Call WindowFit(SiftValue)
        Application.DoEvents()

        Select Case _WorkMode
            Case WorkModeClass.enumWorkMode.PictureSave_Bitmap, WorkModeClass.enumWorkMode.PictureSave_JPEG, WorkModeClass.enumWorkMode.PictureSave_PNG '画像自動保存
                Call PictureSave(GetPicture())
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureSaveAs '画像保存
                Call PictureSaveAs(GetPicture())
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureSaveClipbord 'クリップボード
                Call PictureClipbord(GetPicture())
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureOnigiri 'おにぎり
                Call PictureClipbord(GetPicture())
                Call AddFormHistory() 'ポジションの記憶
                Dim FR As New FrmOnigiri
                FR.Show()
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If
            Case WorkModeClass.enumWorkMode.PictureOnigiriSet 'おにぎりセット
                Dim Img As Image = GetPicture()
                Call AddFormHistory() 'ポジションの記憶

                If IsNothing(OnigiriSetStat) Then
                    Dim FR As New FrmOnigiriSet
                    FR.Show()
                    FR.SetPict()
                End If
                OnigiriSetStat.AddPic(Img)
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

        End Select

        Me.Location = New Point(_OrgPosi)
        Me.Size = New Size(_OrgSize)

        _IsWork = False
    End Sub
    ''' <summary>
    ''' 画面全体キャプチャー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDesktop_Click(sender As Object, e As EventArgs) Handles BtnDesktop.Click
        _IsWork = True
        Dim P As Point = Me.PictureBox1.PointToScreen(New Point(0, 0))

        Dim SCNo As Integer = GetScreenNo(Me)
        Me.TopMost = False
        Me.WindowState = FormWindowState.Minimized
        System.Threading.Thread.Sleep(1000)
        Dim BB As Bitmap = CaptureScreen(SCNo)
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True

        Select Case _WorkMode
            Case WorkModeClass.enumWorkMode.VideoSave, WorkModeClass.enumWorkMode.VideoSaveAs '動画

            Case WorkModeClass.enumWorkMode.PictureSave_Bitmap, WorkModeClass.enumWorkMode.PictureSave_JPEG, WorkModeClass.enumWorkMode.PictureSave_PNG '画像自動保存
                Call PictureSave(BB)
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureSaveAs '画像保存
                Call PictureSaveAs(BB)
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureSaveClipbord 'クリップボード
                Call PictureClipbord(BB)
                Call AddFormHistory() 'ポジションの記憶
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureOnigiri  'おにぎり
                Call PictureClipbord(BB)
                Call AddFormHistory() 'ポジションの記憶
                Dim FR As New FrmOnigiri
                FR.Show()
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If

            Case WorkModeClass.enumWorkMode.PictureOnigiriSet 'おにぎりセット
                Call AddFormHistory() 'ポジションの記憶
                If IsNothing(OnigiriSetStat) Then 'おにぎりセットが立ち上がってなかったら立ち上げる
                    Dim FR As New FrmOnigiriSet
                    FR.Show()
                End If
                OnigiriSetStat.AddPic(BB)

                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If
        End Select

        _IsWork = False

    End Sub
    ''' <summary>
    ''' 設定メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetting_Setting_Click(sender As Object, e As EventArgs) Handles MenuSetting_Setting.Click
        Dim _Size As Size = PictureBox1.ClientSize
        With FrmSetting
            .MainSize = _Size
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                _BaseFolder = ReadReg("General", "SaveFolder")
                Timer1.Interval = ReadReg("General", "ShotInterval", enum_Type.er_Integer)
                LblimeStamp.Visible = ReadReg("General", "ImageTimeStamp", enum_Type.er_Boolean)
                If LblimeStamp.Visible Then
                    If ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer) = 0 Then
                        LblimeStamp.Location = New Point(5, 5)
                    End If
                End If

                Call GetPosiShift()
            End If
        End With
    End Sub

    Dim _OrgPosi As Point
    Dim _OrgSize As Size
    ''' <summary>
    ''' シフト設定モード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetting_ViewScale_Click(sender As Object, e As EventArgs) Handles MenuSetting_ViewScale.Click
        If Not Label2.Visible Then
            If MenuFormPosition_AutoFollow.Checked Then
                '自動追尾モードを解除する
                Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
            End If

            _OrgPosi = New Point(Me.Location)
            _OrgSize = New Size(Me.Size)

            BtnExecute.Visible = False
            BtnDialog.Visible = False
            BtnDesktop.Visible = False
            Label2.Visible = True
            Label3.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' サイズ指定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetting_Resize_Click(sender As Object, e As EventArgs) Handles MenuSetting_Resize.Click
        If MenuFormPosition_AutoFollow.Checked Then
            '自動追尾モードを解除する
            Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
        End If
        With FrmResize
            .FormHeight = Me.Height - Me.Panel1.Height
            .FormWidth = Me.Width
            .ShowDialog(Me)
        End With
    End Sub
    ''' <summary>
    ''' マウスショットキャプチャー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MenuMouseShotCaptuer.Click
        If _WorkMode = WorkModeClass.enumWorkMode.PictureSave_Bitmap OrElse _WorkMode = WorkModeClass.enumWorkMode.PictureSave_JPEG OrElse _WorkMode = WorkModeClass.enumWorkMode.PictureSave_PNG Then
            Dim SCNo As Integer = GetScreenNo(Me)

            Dim _Size As Size = PictureBox1.ClientSize
            Me.TopMost = False
            Me.WindowState = FormWindowState.Minimized
            With FrmSnapMouse
                .WorkScreenNo = SCNo
                .BaseFolder = _BaseFolder
                .ShotMode = _WorkMode
                .ShotSize = _Size
                .ShowDialog()
            End With
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = True
        Else
            MsgBox("現在の作業モードではマウスショットは使用出来ません。" & vbCrLf & _
                        "先に静止画像自動保存モードにしてから行ってください。", 48, "手順エラー")
        End If
    End Sub
    ''' <summary>
    ''' 自動最小化メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuAutoSmall_Click(sender As Object, e As EventArgs) Handles MenuAutoSmall.Click
        MenuAutoSmall.Checked = Not MenuAutoSmall.Checked
    End Sub

    Dim WithEvents _ShotTimer As New Timer
    Dim _ShotTimerCount As Integer = 0
    ''' <summary>
    ''' ショットタイマー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _ShotTimer_Tick(sender As Object, e As EventArgs) Handles _ShotTimer.Tick
        If _ShotTimerCount <= 0 Then
            _ShotTimer.Enabled = False
            Select Case _WorkMode
                Case WorkModeClass.enumWorkMode.VideoSave, WorkModeClass.enumWorkMode.VideoSaveAs '動画

                Case WorkModeClass.enumWorkMode.PictureSave_Bitmap, WorkModeClass.enumWorkMode.PictureSave_JPEG, WorkModeClass.enumWorkMode.PictureSave_PNG '画像自動保存
                    Call PictureSave(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                Case WorkModeClass.enumWorkMode.PictureSaveAs '画像保存
                    Call PictureSaveAs(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                Case WorkModeClass.enumWorkMode.PictureOnigiri 'おにぎり
                    Call PictureClipbord(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶
                    Dim FR As New FrmOnigiri
                    FR.Show()
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                Case WorkModeClass.enumWorkMode.PictureOnigiriSet 'おにぎりセット
                    Dim Img As Image = GetPicture()
                    Call AddFormHistory() 'ポジションの記憶

                    If IsNothing(OnigiriSetStat) Then 'おにぎりセットが立ち上がってなかったら立ち上げる
                        Dim FR As New FrmOnigiriSet
                        FR.Show()
                    End If
                    OnigiriSetStat.AddPic(Img)
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                    Label1.Text = "おにぎりセットへ転送"
                    Timer2.Enabled = True
                    _IsWork = False

                Case WorkModeClass.enumWorkMode.PictureSaveClipbord 'クリップボード
                    Call PictureClipbord(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

                Case WorkModeClass.enumWorkMode.PictureSaveWordpad 'ワードパッド
                    Call PictureWordpad(GetPicture())
                    Call AddFormHistory() 'ポジションの記憶
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If

            End Select
            If ReadReg("General", "ShotTimerClear", enum_Type.er_Boolean) Then
                Call ShotTimerSet_Clear() 'ショットタイマーのクリア
            End If
        Else
            Label1.Text = String.Format("Shotまで{0}秒", _ShotTimerCount)
        End If
        _ShotTimerCount -= 1
    End Sub
    Private Sub ShotTimerSet_Clear()
        MenuShotTimer0.Checked = True
        MenuShotTimer1.Checked = False
        MenuShotTimer2.Checked = False
        MenuShotTimer3.Checked = False
        MenuShotTimer4.Checked = False
        MenuShotTimer5.Checked = False
    End Sub
    Private Sub MenuShotTimer_Click(sender As Object, e As EventArgs) Handles MenuShotTimer0.Click, MenuShotTimer1.Click, MenuShotTimer2.Click, MenuShotTimer3.Click, MenuShotTimer4.Click, MenuShotTimer5.Click
        Dim Obj As ToolStripMenuItem = sender

        MenuShotTimer0.Checked = False
        MenuShotTimer1.Checked = False
        MenuShotTimer2.Checked = False
        MenuShotTimer3.Checked = False
        MenuShotTimer4.Checked = False
        MenuShotTimer5.Checked = False

        Obj.Checked = True
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, PanelButton.MouseDown, PanelCamera.MouseDown
        If Not _IsWork Then
            Dim B As Panel = CType(sender, Panel)
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If Label2.Visible Then
                    ConMenuScaleMode.Show(B, e.Location)
                Else
                    MenuAPPEnd.Tag = 0
                    MenuAPPEnd.Text = "終了"
                    ConMenuMain.Show(B, e.Location)
                End If
            End If
        End If
    End Sub
    Private Sub BtnDesktop_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnDesktop.MouseDown, BtnSelectAria.MouseDown, BtnWindowSmall.MouseDown, BtnExecute.MouseDown
        If Not _IsWork Then
            Dim B As Button = CType(sender, Button)
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If Label2.Visible Then
                    ConMenuScaleMode.Show(B, e.Location)
                Else
                    MenuAPPEnd.Tag = 0
                    MenuAPPEnd.Text = "終了"
                    ConMenuMain.Show(B, e.Location)
                End If
            End If
        End If
    End Sub

    Private Sub BtnDesktop_MouseHover(sender As Object, e As EventArgs) Handles BtnDesktop.MouseHover
        GcBalloonTip1.Show(BtnDesktop)
    End Sub
    Private Sub BtnSelectAria_MouseHover(sender As Object, e As EventArgs) Handles BtnSelectAria.MouseHover
        GcBalloonTip1.Show(BtnSelectAria)
    End Sub
    Private Sub BtnSelectAria_MouseLeave(sender As Object, e As EventArgs) Handles BtnSelectAria.MouseLeave
        GcBalloonTip1.Hide()
    End Sub
    Private Sub BtnDialog_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnDialog.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ConMenuFit2.Show(BtnDialog, e.Location)
        End If
    End Sub
    Private Sub BtnDialog_MouseHover(sender As Object, e As EventArgs) Handles BtnDialog.MouseHover
        GcBalloonTip1.Show(BtnDialog)
    End Sub
    Private Sub BtnWindowSmall_MouseHover(sender As Object, e As EventArgs) Handles BtnWindowSmall.MouseHover
        GcBalloonTip1.Show(BtnWindowSmall)
        If Not _IsWork Then
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End If
    End Sub
    Private Sub BtnDesktop_MouseLeave(sender As Object, e As EventArgs) Handles BtnDesktop.MouseLeave
        GcBalloonTip1.Hide()
    End Sub
    Private Sub BtnDialog_MouseLeave(sender As Object, e As EventArgs) Handles BtnDialog.MouseLeave
        GcBalloonTip1.Hide()
    End Sub
    Private Sub BtnWindowSmall_MouseLeave(sender As Object, e As EventArgs) Handles BtnWindowSmall.MouseLeave
        GcBalloonTip1.Hide()
    End Sub
    ''' <summary>
    ''' サイズフィットボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFitSize_Click(sender As Object, e As EventArgs) Handles BtnFitSize.Click
        If Label2.Visible Then
            Try
                Me.TopMost = False
                Me.WindowState = FormWindowState.Minimized

                'アクティブなウィンドウのデバイスコンテキストを取得
                Dim hWnd As IntPtr = GetForegroundWindow()
                Dim winDC As IntPtr = GetWindowDC(hWnd)
                'ウィンドウの大きさを取得
                Dim winRect As New RECT
                'GetWindowRect(hWnd, winRect)
                Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
                DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)

                Dim _W As Integer = winRect.right - winRect.left + 2
                Dim _H As Integer = winRect.bottom - winRect.top + (Me.Size.Height - PictureBox1.Size.Height) + 12

                If Panel1.Dock = DockStyle.Top Then
                    Me.Location = New Point(winRect.left, winRect.top - Panel1.Height)
                Else
                    Me.Location = New Point(winRect.left - 5, winRect.top - 5)
                End If
                Me.Size = New Size(_W, _H)

                Me.WindowState = FormWindowState.Normal
                Me.TopMost = True

                _OrgPosi = New Point(Me.Location)
                _OrgSize = New Size(Me.Size)

                ReleaseDC(hWnd, winDC)
            Catch ex As Exception

            End Try
       
        Else
            Call WindowFit(GetSiftPosi)
        End If
    End Sub
    ''' <summary>
    ''' エリアシフトメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuShift_Click(sender As Object, e As EventArgs) Handles MenuShift0.Click, MenuShift1.Click, MenuShift2.Click, MenuShift3.Click
        Dim Obj As ToolStripMenuItem = sender
        If Obj.Tag >= 0 AndAlso Obj.Tag <= 3 Then
            Dim _Use As Boolean = ReadReg("SizeShift", String.Format("Use{0}", Obj.Tag), enum_Type.er_Boolean)
            Dim _ShiftX As Integer = ReadReg("SizeShift", String.Format("X{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _ShiftY As Integer = ReadReg("SizeShift", String.Format("Y{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _SiiftWidth As Integer = ReadReg("SizeShift", String.Format("Width{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _ShiftHeight As Integer = ReadReg("SizeShift", String.Format("Height{0}", Obj.Tag), enum_Type.er_Integer)

            Call WindowFit(New PosiShift_Collection(_Use, _ShiftX, _ShiftY, _SiiftWidth, _ShiftHeight))
        End If
    End Sub
    ''' <summary>
    ''' 画面フィット
    ''' </summary>
    ''' <param name="SiftValue"></param>
    ''' <remarks></remarks>
    Private Sub WindowFit(SiftValue As PosiShift_Collection)
        Try
            Me.TopMost = False
            Me.WindowState = FormWindowState.Minimized
            System.Threading.Thread.Sleep(500)

            'アクティブなウィンドウのデバイスコンテキストを取得
            Dim hWnd As IntPtr = GetForegroundWindow()
            Dim winDC As IntPtr = GetWindowDC(hWnd)
            'ウィンドウの大きさを取得
            Dim winRect As New RECT

            If ReadReg("General", "FitType", enum_Type.er_Integer) = 0 Then
                'GetWindowRect(hWnd, winRect)
                Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
                DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)
            Else
                GetWindowRect(hWnd, winRect)
            End If

            Dim _W As Integer = winRect.right - winRect.left + 2
            Dim _H As Integer = winRect.bottom - winRect.top + (Me.Size.Height - PictureBox1.Size.Height) + 12

            Dim _Sift As PosiShift_Collection = SiftValue
            Dim _ShiftX As Integer = _Sift.X
            Dim _ShiftY As Integer = _Sift.Y
            Dim _ShiftHeight As Integer = _Sift.Height
            Dim _SiiftWidth As Integer = _Sift.Width

            Dim _LocalShiftX As Integer = -2
            Dim _LocalShiftY As Integer = -2

            Select Case True
                Case _W < 50
                    Label1.Text = String.Format("横SizeErr:{0}", _W)
                    Timer2.Enabled = True
                Case _H < 100
                    Label1.Text = String.Format("縦SizeErr:{0}", _H)
                    Timer2.Enabled = True
                Case Else
                    Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
                    Dim Display_H As Integer = s.Bounds.Height
                    Dim Display_W As Integer = s.Bounds.Width

                    Dim _X As Integer = winRect.left + _ShiftX + _W
                    Dim _Y As Integer = winRect.top + _ShiftY + _H
                    If My.Computer.Screen.WorkingArea.Height < _Y OrElse My.Computer.Screen.WorkingArea.Width < _X Then
                        Label1.Text = "画面サイズ取得失敗"
                        Timer2.Enabled = True
                    Else
                        If Panel1.Dock = DockStyle.Top Then
                            Me.Location = New Point(winRect.left + _ShiftX + _LocalShiftX, winRect.top + _ShiftY - Panel1.Height + _LocalShiftY)
                        Else
                            Me.Location = New Point(winRect.left + _ShiftX + _LocalShiftX, winRect.top + _ShiftY + _LocalShiftY)
                        End If
                        Me.Size = New Size(_W + _SiiftWidth - _LocalShiftX, _H + _ShiftHeight - _LocalShiftY)
                    End If

            End Select
            ReleaseDC(hWnd, winDC)

            Me.WindowState = FormWindowState.Normal
            Me.TopMost = True
        Catch ex As Exception

        End Try

    End Sub
    ''' <summary>
    ''' 画面フィットメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFitSize_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnFitSize.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ConMenuFit.Show(BtnFitSize, e.Location)
        End If
    End Sub
    Private Sub BtnFitSize_MouseHover(sender As Object, e As EventArgs) Handles BtnFitSize.MouseHover
        GcBalloonTip1.Show(BtnFitSize)
    End Sub
    Private Sub BtnFitSize_MouseLeave(sender As Object, e As EventArgs) Handles BtnFitSize.MouseLeave
        GcBalloonTip1.Hide()
    End Sub
    ''' <summary>
    ''' メニューの上付き
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPosition_Top_Click(sender As Object, e As EventArgs) Handles MenuPosition_Top.Click
        If Panel1.Dock = DockStyle.Bottom Then
            Panel1.Dock = DockStyle.Top
            PanelCamera.Dock = DockStyle.Top
            MenuPosition_Top.Checked = True
            MenuPosition_Bottom.Checked = False
            Me.Location = New Point(Me.Location.X, Me.Location.Y - Panel1.Height)
            Call LblTimeStampMove()
        End If
    End Sub
    ''' <summary>
    ''' メニューの下付き
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPosition_Bottom_Click(sender As Object, e As EventArgs) Handles MenuPosition_Bottom.Click
        If Panel1.Dock = DockStyle.Top Then
            Panel1.Dock = DockStyle.Bottom
            PanelCamera.Dock = DockStyle.Bottom
            MenuPosition_Top.Checked = False
            MenuPosition_Bottom.Checked = True
            Me.Location = New Point(Me.Location.X, Me.Location.Y + Panel1.Height)
            Call LblTimeStampMove()
        End If
    End Sub
    ''' <summary>
    ''' 位置記憶
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFormPosition_Regist_Click(sender As Object, e As EventArgs) Handles MenuFormPosition_Regist.Click
        Dim _T As New ClassFormPosition
        _T.ID = CreateID()
        _T.Position = Me.Location
        '_T.FormSize = Me.Size
        _T.FormSize = New Size(Me.Width, Me.Height - Panel1.Height)
        _FormPosition.Add(_T)
        Label1.Text = "位置を記録しました"
        Timer2.Enabled = True
        _IsWork = False
    End Sub
    Dim _IsVisiblePosiForm As Boolean = False
    ''' <summary>
    ''' 位置表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFormPosition_View_Click(sender As Object, e As EventArgs) Handles MenuFormPosition_View.Click
        If Not _IsVisiblePosiForm Then
            If _FormPosition.Count > 0 Then
                _FormPositionForm.Clear()
                For Each _T As ClassFormPosition In _FormPosition
                    Dim FR As New FrmPosiForm
                    FR.Show()
                    FR.Tag = _T.ID
                    FR.Location = New Point(_T.Position)
                    FR.Size = New Size(_T.FormSize)
                    _FormPositionForm.Add(FR)
                Next
                Me.WindowState = FormWindowState.Minimized
                _IsVisiblePosiForm = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' 位置表示キャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub MenuFormPosition_Close_Click(sender As Object, e As EventArgs) Handles MenuFormPosition_Close.Click
        If _FormPositionForm.Count > 0 Then
            For Each _T As FrmPosiForm In _FormPositionForm
                _T.Close()
            Next
            _FormPositionForm.Clear()
            _IsVisiblePosiForm = False
        End If
    End Sub
    ''' <summary>
    ''' 表示位置クリア
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFormPosition_Clear_Click(sender As Object, e As EventArgs) Handles MenuFormPosition_Clear.Click
        If MsgBox("記憶表示位置を全てクリアしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _FormPosition.Clear()
        End If
    End Sub

    Dim _DataFile As String = AppFullPath("PosiDataFile.xml")
    ''' <summary>
    ''' ユーザポジション保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SavePosiData()
        If System.IO.File.Exists(_DataFile) Then System.IO.File.Delete(_DataFile)
        If _FormPosition.Count > 0 Then
            Try
                If Not String.IsNullOrEmpty(_DataFile) Then
                    Dim LocalClass() As ClassFormPosition = TryCast(_FormPosition.ToArray, ClassFormPosition())

                    If Not LocalClass Is Nothing Then
                        Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassFormPosition()))
                        Using FS As New IO.FileStream(_DataFile, IO.FileMode.Create)
                            SRZ.Serialize(FS, LocalClass)
                        End Using
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetPosiShift()
        _PosiShift.Clear()

        For i As Integer = 0 To 3
            Dim _Use As Boolean = ReadReg("SizeShift", String.Format("Use{0}", i), enum_Type.er_Boolean)
            Dim _X As Integer = ReadReg("SizeShift", String.Format("X{0}", i), enum_Type.er_Integer)
            Dim _Y As Integer = ReadReg("SizeShift", String.Format("Y{0}", i), enum_Type.er_Integer)
            Dim _Width As Integer = ReadReg("SizeShift", String.Format("Width{0}", i), enum_Type.er_Integer)
            Dim _Height As Integer = ReadReg("SizeShift", String.Format("Height{0}", i), enum_Type.er_Integer)
            If _Use Then
                _PosiShift.Add(New PosiShift_Collection(_Use, _X, _Y, _Width, _Height))
            End If
        Next

        If ReadReg("SizeShift", "ShiftTimerInterva", enum_Type.er_Integer) <= 0 Then
            _Tim.Interval = 1000
        Else
            _Tim.Interval = ReadReg("SizeShift", "ShiftTimerInterva", enum_Type.er_Integer) * 1000
        End If
    End Sub
    ''' <summary>
    ''' ユーザポジション読込
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPosiData()
        Try
            If System.IO.File.Exists(_DataFile) Then
                _FormPosition.Clear()
                Dim SRZ As New System.Xml.Serialization.XmlSerializer(GetType(ClassFormPosition()))
                Using FS As New IO.FileStream(_DataFile, IO.FileMode.Open)
                    Dim LocalClass() As ClassFormPosition
                    LocalClass = SRZ.Deserialize(FS)

                    For Each LoopClass As ClassFormPosition In LocalClass
                        _FormPosition.Add(LoopClass)
                    Next
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConMenuFit.Opening
        MenuShift0.Enabled = ReadReg("SizeShift", "Use0", enum_Type.er_Boolean)
        MenuShift1.Enabled = ReadReg("SizeShift", "Use1", enum_Type.er_Boolean)
        MenuShift2.Enabled = ReadReg("SizeShift", "Use2", enum_Type.er_Boolean)
        MenuShift3.Enabled = ReadReg("SizeShift", "Use3", enum_Type.er_Boolean)
    End Sub
    Private Sub ConMenuFit2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConMenuFit2.Opening
        MenuShift20.Enabled = ReadReg("SizeShift", "Use0", enum_Type.er_Boolean)
        MenuShift21.Enabled = ReadReg("SizeShift", "Use1", enum_Type.er_Boolean)
        MenuShift22.Enabled = ReadReg("SizeShift", "Use2", enum_Type.er_Boolean)
        MenuShift23.Enabled = ReadReg("SizeShift", "Use3", enum_Type.er_Boolean)
    End Sub
    Private Sub MenuScaleEnd_Click(sender As Object, e As EventArgs) Handles MenuScaleEnd.Click
        If Label2.Visible Then
            BtnExecute.Visible = True
            BtnDialog.Visible = True
            BtnDesktop.Visible = True
            Label2.Visible = False
            Label3.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' シフト量１
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuScale0_Click(sender As Object, e As EventArgs) Handles MenuScale0.Click
        If MsgBox("この画面のシフトをシフト量１に設定しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Call WriteReg("SizeShift", "Use0", True)
            Call WriteReg("SizeShift", "X0", Me.Location.X - _OrgPosi.X)
            Call WriteReg("SizeShift", "Y0", Me.Location.Y - _OrgPosi.Y)
            Call WriteReg("SizeShift", "Width0", Me.Size.Width - _OrgSize.Width)
            Call WriteReg("SizeShift", "Height0", Me.Size.Height - _OrgSize.Height)
            Call GetPosiShift()

            Call MenuScaleEnd_Click(Nothing, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' シフト量２
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuScale1_Click(sender As Object, e As EventArgs) Handles MenuScale1.Click
        If MsgBox("この画面のシフトをシフト量２に設定しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Call WriteReg("SizeShift", "Use1", True)
            Call WriteReg("SizeShift", "X1", Me.Location.X - _OrgPosi.X)
            Call WriteReg("SizeShift", "Y1", Me.Location.Y - _OrgPosi.Y)
            Call WriteReg("SizeShift", "Width1", Me.Size.Width - _OrgSize.Width)
            Call WriteReg("SizeShift", "Height1", Me.Size.Height - _OrgSize.Height)
            Call GetPosiShift()

            Call MenuScaleEnd_Click(Nothing, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' シフト量３
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuScale3_Click(sender As Object, e As EventArgs) Handles MenuScale3.Click
        If MsgBox("この画面のシフトをシフト量３に設定しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Call WriteReg("SizeShift", "Use2", True)
            Call WriteReg("SizeShift", "X2", Me.Location.X - _OrgPosi.X)
            Call WriteReg("SizeShift", "Y2", Me.Location.Y - _OrgPosi.Y)
            Call WriteReg("SizeShift", "Width2", Me.Size.Width - _OrgSize.Width)
            Call WriteReg("SizeShift", "Height2", Me.Size.Height - _OrgSize.Height)
            Call GetPosiShift()

            Call MenuScaleEnd_Click(Nothing, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' シフト量４
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuScale4_Click(sender As Object, e As EventArgs) Handles MenuScale4.Click
        If MsgBox("この画面のシフトをシフト量４に設定しますか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Call WriteReg("SizeShift", "Use3", True)
            Call WriteReg("SizeShift", "X3", Me.Location.X - _OrgPosi.X)
            Call WriteReg("SizeShift", "Y3", Me.Location.Y - _OrgPosi.Y)
            Call WriteReg("SizeShift", "Width3", Me.Size.Width - _OrgSize.Width)
            Call WriteReg("SizeShift", "Height3", Me.Size.Height - _OrgSize.Height)
            Call GetPosiShift()

            Call MenuScaleEnd_Click(Nothing, Nothing)
        End If
    End Sub
   
    Private Sub MenuShift2_Click(sender As Object, e As EventArgs) Handles MenuShift20.Click, MenuShift21.Click, MenuShift22.Click, MenuShift23.Click
        Dim Obj As ToolStripMenuItem = sender
        If Obj.Tag >= 0 AndAlso Obj.Tag <= 3 Then
            Dim _Use As Boolean = ReadReg("SizeShift", String.Format("Use{0}", Obj.Tag), enum_Type.er_Boolean)
            Dim _ShiftX As Integer = ReadReg("SizeShift", String.Format("X{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _ShiftY As Integer = ReadReg("SizeShift", String.Format("Y{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _SiiftWidth As Integer = ReadReg("SizeShift", String.Format("Width{0}", Obj.Tag), enum_Type.er_Integer)
            Dim _ShiftHeight As Integer = ReadReg("SizeShift", String.Format("Height{0}", Obj.Tag), enum_Type.er_Integer)

            Call DialogFit(New PosiShift_Collection(_Use, _ShiftX, _ShiftY, _SiiftWidth, _ShiftHeight))
        End If
    End Sub
    Private Sub MenuMoveLast_Click(sender As Object, e As EventArgs) Handles MenuMoveLast.Click
        If _FormHistory.Count > 0 Then
            Me.Location = New Point(_FormHistory.Last.Position)
            Me.Size = New Size(_FormHistory.Last.FormSize)
            _FormHistory.RemoveAt(_FormHistory.Count - 1)
        End If
    End Sub
    ''' <summary>
    ''' GIFコンプレスサイトへの誘導
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuCompress_Click(sender As Object, e As EventArgs) Handles MenuCompress.Click
        Dim URL As String = ReadReg("General", "CompressURL")
        If URL <> "" Then
            System.Diagnostics.Process.Start(URL)
        End If
    End Sub
    ''' <summary>
    ''' ショットタイマのキャンセル
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label1.DoubleClick
        _ShotTimer.Enabled = False
        _ShotTimerCount = 0
        Call _ShotTimer_Tick(Nothing, Nothing)

    End Sub
    ''' <summary>
    ''' テキストヘルプの表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuHelpText_Click(sender As Object, e As EventArgs) Handles MenuHelpText.Click
        Dim _FL As String = AppFullPath("helptext.txt")
        If File.Exists(_FL) Then
            Try
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(_FL)
            Catch ex As Exception
                MsgBox("ヘルプテキストの起動に失敗しました", 48, "エラー")
            End Try
        End If
    End Sub
    Dim _Alt As Boolean = False
    Dim _Ctrl As Boolean = False
    Dim _Shift As Boolean = False
    Dim _IME_NoConvert As Boolean = False

    ''' <summary>
    ''' TODO:グローバルフック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GcGlobalHook1_KeyDown(sender As Object, e As KeyEventArgs) Handles GcGlobalHook1.KeyDown
        Dim _C As Integer = 1

        _Alt = (e.Modifiers And Keys.Alt) = Keys.Alt
        _Ctrl = (e.Modifiers And Keys.Control) = Keys.Control
        _Shift = (e.Modifiers And Keys.Shift) = Keys.Shift
        _IME_NoConvert = Keys.IMENonconvert

        Select Case True
            Case (_Alt AndAlso _Ctrl AndAlso e.KeyCode = Keys.Home) 'パニックキー [ALT]+[CTRL]+[HOME]
                '位置とサイズを元に戻す 自動追尾はOFFにする
                If MenuFormPosition_AutoFollow.Checked Then
                    Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
                End If

                Me.Size = New Size(493, 424)
                Me.Location = New Point(100, 100)
                If LblimeStamp.Visible Then
                    If ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer) = 0 Then
                        LblimeStamp.Location = New Point(5, 5)
                    End If
                End If

                'SHIFT群 ---------------------------------------------------
            Case (_Shift AndAlso e.KeyCode = Keys.Down)         '[SHIFT]+[DOWN]
                '最小化
                Call BtnWindowSmall_Click(Nothing, Nothing)

                'ALT群 ---------------------------------------------------
            Case (_Alt AndAlso e.KeyCode = Keys.Right)          '[ALT]+[→]
                If _Shift Then _C = 10
                Dim _T As Size = Me.Size
                Me.Size = New Size(_T.Width + _C, _T.Height)
            Case (_Alt AndAlso e.KeyCode = Keys.Left)           '[ALT]+[←]
                If _Shift Then _C = 10
                Dim _T As Size = Me.Size

                Me.Size = New Size(_T.Width - _C, _T.Height)
            Case (_Alt AndAlso e.KeyCode = Keys.Up)             '[ALT]+[↑]
                If _Shift Then _C = 10
                Dim _T As Size = Me.Size
                Me.Size = New Size(_T.Width, _T.Height - _C)
            Case (_Alt AndAlso e.KeyCode = Keys.Down)           '[ALT]+[↓]
                If _Shift Then _C = 10
                Dim _T As Size = Me.Size
                Me.Size = New Size(_T.Width, _T.Height + _C)

            Case (_Alt AndAlso e.KeyCode = Keys.Pause)          '[ALT]+[PAUSE]
                Call BtnDesktop_Click(Nothing, Nothing)
            Case (_Alt AndAlso e.KeyCode = Keys.Scroll)         '[ALT]+[SCROLL]
                Call BtnFitSize.PerformClick()

            Case (_Alt AndAlso e.KeyCode = Keys.Home)           '[ALT]+[HOME]
                Call BtnDialog.PerformClick()
            Case (_Alt AndAlso e.KeyCode = Keys.Insert)         '[ALT]+[INSERT]
                If MenuPosition_Top.Checked Then
                    Call MenuPosition_Bottom.PerformClick()
                Else
                    Call MenuPosition_Top.PerformClick()
                End If
            Case (_Alt AndAlso e.KeyCode = Keys.Delete)         '[ALT]+[DELETE]
                MenuAPPEnd.Tag = 1
                MenuAPPEnd.Text = "閉じる"
                Call ConMenuMain.Show(New Point(System.Windows.Forms.Cursor.Position))
            Case (_Alt AndAlso e.KeyCode = Keys.Enter) '[ALT]+[ENTER]
                If BtnSelectAria.Visible Then
                    Call BtnSelectAria_Click(Nothing, Nothing)
                End If

            Case (_Alt AndAlso e.KeyCode = Keys.D0) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad0)   '[ALT]+[0]
                Call HookShotTimer(0)
            Case (_Alt AndAlso e.KeyCode = Keys.D1) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad1)   '[ALT]+[1]
                Call HookShotTimer(1)
            Case (_Alt AndAlso e.KeyCode = Keys.D2) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad2)   '[ALT]+[2]
                Call HookShotTimer(2)
            Case (_Alt AndAlso e.KeyCode = Keys.D3) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad3)   '[ALT]+[3]
                Call HookShotTimer(3)
            Case (_Alt AndAlso e.KeyCode = Keys.D4) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad4)   '[ALT]+[4]
                Call HookShotTimer(4)
            Case (_Alt AndAlso e.KeyCode = Keys.D5) OrElse (_Alt AndAlso e.KeyCode = Keys.NumPad5)   '[ALT]+[5]
                Call HookShotTimer(5)

                'CTRL群 ------------------------------------------------------
            Case (_Ctrl AndAlso e.KeyCode = Keys.Home)          '[CTRL]+[HOME]フォルダを開く
                Call MenuOpenFolder_Click(Nothing, Nothing)
            Case (_Ctrl AndAlso e.KeyCode = Keys.Insert)        '[CTRL]+[INSERT]フレーム位置記録
                Call MenuFormPosition_Regist_Click(Nothing, Nothing)
            Case (_Ctrl AndAlso e.KeyCode = Keys.Delete)        '[CTRL]+[DELETE]フレーム位置表示
                Call MenuFormPosition_View_Click(Nothing, Nothing)

            Case (_Ctrl AndAlso e.KeyCode = Keys.Right)         '[CTRL]+[→]
                If _Shift Then _C = 10
                Dim _T As Point = Me.Location
                Me.Location = New Point(_T.X + _C, _T.Y)
            Case (_Ctrl AndAlso e.KeyCode = Keys.Left)          '[CTRL]+[←]
                If _Shift Then _C = 10
                Dim _T As Point = Me.Location
                Me.Location = New Point(_T.X - _C, _T.Y)
            Case (_Ctrl AndAlso e.KeyCode = Keys.Up)            '[CTRL]+[↑]
                If _Shift Then _C = 10
                Dim _T As Point = Me.Location
                Me.Location = New Point(_T.X, _T.Y - _C)
            Case (_Ctrl AndAlso e.KeyCode = Keys.Down)          '[CTRL]+[↓]
                If _Shift Then _C = 10
                Dim _T As Point = Me.Location
                Me.Location = New Point(_T.X, _T.Y + _C)

            Case (_Ctrl AndAlso e.KeyCode = Keys.Q)             '[CTRL]+[Q] 自動追尾
                '動画モード時は無効
                If _WorkMode <> WorkModeClass.enumWorkMode.VideoSave And _WorkMode <> WorkModeClass.enumWorkMode.VideoSaveAs Then
                    Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
                End If

                'その他群 ------------------------------------------------------
            Case (e.KeyCode = Keys.Pause)                       'スクリーンショット [PAUSE]
                Call BtnExecute.PerformClick()
        End Select

    End Sub
    ''' <summary>
    ''' ショートカットキーによるタイマーショットの実行
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub HookShotTimer(Value As Integer)
        MenuShotTimer0.Checked = False
        MenuShotTimer1.Checked = False
        MenuShotTimer2.Checked = False
        MenuShotTimer3.Checked = False
        MenuShotTimer4.Checked = False
        MenuShotTimer5.Checked = False
        Select Case Value
            Case 1 : MenuShotTimer1.Checked = True
            Case 2 : MenuShotTimer2.Checked = True
            Case 3 : MenuShotTimer3.Checked = True
            Case 4 : MenuShotTimer4.Checked = True
            Case 5 : MenuShotTimer5.Checked = True
            Case Else : MenuShotTimer0.Checked = True

        End Select
        If Value <> 0 Then
            Call BtnExecute.PerformClick()
            Call HookShotTimer(0)
        End If
    End Sub

    ''' <summary>
    ''' キーボードフック有効・無効
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSetting_KeyHook_Click(sender As Object, e As EventArgs) Handles MenuSetting_KeyHook.Click
        MenuSetting_KeyHook.Checked = Not MenuSetting_KeyHook.Checked
        GcGlobalHook1.EnableKeyboardHook = MenuSetting_KeyHook.Checked
    End Sub

    Public ScreenNo As Integer
    ''' <summary>
    ''' キャプチャー範囲設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectAria_Click(sender As Object, e As EventArgs) Handles BtnSelectAria.Click
        Dim SCNo As Integer = GetScreenNo(Me)
        Me.WindowState = FormWindowState.Minimized
        With FrmSelectAria
            .WorkScreenNo = SCNo
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.WindowState = FormWindowState.Normal
                If .SelectPosition.X > 0 AndAlso .SelectPosition.Y > 0 Then
                    If .SelectSize.Width > 10 AndAlso .SelectSize.Height > 10 Then
                        Dim SX As Integer = 0
                        Dim SY As Integer = 0
                        If SCNo > -1 Then
                            SX = Screen.AllScreens(SCNo).WorkingArea.X
                            SY = Screen.AllScreens(SCNo).WorkingArea.Y
                        End If
                        If Panel1.Dock = DockStyle.Top Then
                            Me.Location = New Point(.SelectPosition.X + SX, .SelectPosition.Y - Panel1.Height + SY)
                            Me.Size = New Size(.SelectSize.Width, .SelectSize.Height + Panel1.Height)
                        Else
                            Me.Location = New Point(.SelectPosition.X + SX, .SelectPosition.Y + SY)
                            Me.Size = New Size(.SelectSize.Width, .SelectSize.Height + Panel1.Height)
                        End If

                        If MenuFormPosition_AutoFollow.Checked Then
                            Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
                        End If
                    End If
                End If
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        End With
    End Sub

    Private Sub MenuWork_WindowSmall_Click(sender As Object, e As EventArgs) Handles MenuWork_WindowSmall.Click
        Call BtnWindowSmall_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuWork_WindowFit_Click(sender As Object, e As EventArgs) Handles MenuWork_WindowFit.Click
        Call BtnFitSize_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuWork_WindowOpenner_Click(sender As Object, e As EventArgs) Handles MenuWork_WindowOpenner.Click
        Call BtnSelectAria_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuWork_DialogFit_Click(sender As Object, e As EventArgs) Handles MenuWork_DialogFit.Click
        Call BtnDialog_Click(Nothing, Nothing)
    End Sub

    Private Sub MenuWork_AllScreen_Click(sender As Object, e As EventArgs) Handles MenuWork_AllScreen.Click
        Call BtnDesktop_Click(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' GIF再生アプリ起動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPlayGIF_Click(sender As Object, e As EventArgs) Handles MenuPlayGIF.Click
        Dim FN As String = AppFullPath("GIF Viewer.exe")
        If File.Exists(FN) Then
            Me.WindowState = FormWindowState.Minimized
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(FN)
        Else
            MsgBox("GIF再生ソフトが見つかりません", 48, "エラー")
        End If
    End Sub


#Region "タイムスタンプ関係"
    ''' <summary>
    ''' タイムスタンプ内容更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer_TimeStamp_Tick(sender As Object, e As EventArgs) Handles Timer_TimeStamp.Tick
        Select Case ReadReg("General", "ImageTimeStampType", enum_Type.er_Integer)
            Case 1
                LblimeStamp.Text = String.Format("{0:yy/MM/dd HH:mm}", Now)
            Case 2
                LblimeStamp.Text = String.Format("{0:yy/MM/dd}", Now)
            Case 3
                LblimeStamp.Text = String.Format("{0:HH:mm:ss}", Now)
            Case 4
                LblimeStamp.Text = String.Format("{0:HH:mm}", Now)
            Case Else
                LblimeStamp.Text = String.Format("{0:yy/MM/dd HH:mm:ss}", Now)
        End Select

        Call LblTimeStampMove()
    End Sub
    Dim _TimeStampMove As Boolean = False
    Dim _TimeStampMove_Point As Point
    ''' <summary>
    ''' タイムスタンプ移動開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblimeStamp_MouseDown(sender As Object, e As MouseEventArgs) Handles LblimeStamp.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer) = 0 Then
                _TimeStampMove = True
                _TimeStampMove_Point = e.Location
            End If
        End If
    End Sub
    ''' <summary>
    ''' タイムスタンプ移動中
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblimeStamp_MouseMove(sender As Object, e As MouseEventArgs) Handles LblimeStamp.MouseMove
        If _TimeStampMove Then
            Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position
            '画面座標をクライアント座標に変換する
            Dim cp As System.Drawing.Point = Me.PointToClient(sp)

            Dim X As Integer = cp.X - _TimeStampMove_Point.X
            Dim Y As Integer = cp.Y - _TimeStampMove_Point.Y

            Select Case True
                Case X < 5
                    X = 5
                Case X > PictureBox1.Location.X + PictureBox1.Size.Width - LblimeStamp.Size.Width - 5
                    X = PictureBox1.Location.X + PictureBox1.Size.Width - LblimeStamp.Size.Width - 5
            End Select
            Select Case True
                Case Y < 5
                    Y = 5
                Case Y > PictureBox1.Location.Y + PictureBox1.Size.Height - LblimeStamp.Size.Height - 5
                    Y = PictureBox1.Location.Y + PictureBox1.Size.Height - LblimeStamp.Size.Height - 5
            End Select

            LblimeStamp.Location = New Point(X, Y)
        End If
    End Sub
    ''' <summary>
    ''' タイムスタンプ移動終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LblimeStamp_MouseUp(sender As Object, e As MouseEventArgs) Handles LblimeStamp.MouseUp
        _TimeStampMove = False
    End Sub
    ''' <summary>
    ''' タイムスタンプの位置計算
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LblTimeStampMove()
        Dim Padding As Integer = 5
        Dim PosiX As Integer = 0
        Dim PosiY As Integer = 0
        With LblimeStamp
            Select Case ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer)
                Case 1
                    'LeftTop
                    PosiX = Padding
                    PosiY = PictureBox1.Location.Y + Padding
                    .Location = New Point(PosiX, PosiY)
                Case 2
                    'LeftBottom
                    PosiX = Padding
                    PosiY = PictureBox1.Location.Y + PictureBox1.Size.Height - .Size.Height - Padding
                    .Location = New Point(PosiX, PosiY)
                Case 3
                    'RightTop
                    PosiX = PictureBox1.Size.Width - .Size.Width - Padding
                    PosiY = PictureBox1.Location.Y + Padding
                    .Location = New Point(PosiX, PosiY)
                Case 4
                    PosiX = PictureBox1.Size.Width - .Size.Width - Padding
                    PosiY = PictureBox1.Location.Y + PictureBox1.Size.Height - .Size.Height - Padding
                    .Location = New Point(PosiX, PosiY)
            End Select
        End With
    End Sub
    ''' <summary>
    ''' メインが動かされたらタイムスタンプの位置も変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_Resize(sender As Object, e As EventArgs) Handles PictureBox1.Resize
        Call LblTimeStampMove()
    End Sub
    ''' <summary>
    ''' タイムスタンプ　コンテキストメニュー調整
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConMenuTimeStamp_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ConMenuTimeStamp.Opening
        MenuTimeStampPosi0.Checked = False
        MenuTimeStampPosi1.Checked = False
        MenuTimeStampPosi2.Checked = False
        MenuTimeStampPosi3.Checked = False
        MenuTimeStampPosi4.Checked = False

        Select Case ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer)
            Case 1 : MenuTimeStampPosi1.Checked = True
            Case 2 : MenuTimeStampPosi2.Checked = True
            Case 3 : MenuTimeStampPosi3.Checked = True
            Case 4 : MenuTimeStampPosi4.Checked = True
            Case Else : MenuTimeStampPosi0.Checked = True
        End Select
    End Sub

    Private Sub MenuTimeStampPosi0_Click(sender As Object, e As EventArgs) Handles MenuTimeStampPosi0.Click
        Call WriteReg("General", "ImageTimeStampPosi", 0)
    End Sub

    Private Sub MenuTimeStampPosi1_Click(sender As Object, e As EventArgs) Handles MenuTimeStampPosi1.Click
        Call WriteReg("General", "ImageTimeStampPosi", 1)
    End Sub

    Private Sub MenuTimeStampPosi2_Click(sender As Object, e As EventArgs) Handles MenuTimeStampPosi2.Click
        Call WriteReg("General", "ImageTimeStampPosi", 2)
    End Sub

    Private Sub MenuTimeStampPosi3_Click(sender As Object, e As EventArgs) Handles MenuTimeStampPosi3.Click
        Call WriteReg("General", "ImageTimeStampPosi", 3)
    End Sub

    Private Sub MenuTimeStampPosi4_Click(sender As Object, e As EventArgs) Handles MenuTimeStampPosi4.Click
        Call WriteReg("General", "ImageTimeStampPosi", 4)
    End Sub
    ''' <summary>
    ''' タイムスタンプ 非表示設定
    ''' </summary>
    ''' 
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDisStamp_Click(sender As Object, e As EventArgs) Handles MenuDisStamp.Click
        LblimeStamp.Visible = False
        Call WriteReg("General", "ImageTimeStamp", 0)
    End Sub
#End Region

    ''' <summary>
    ''' クリップボードの画像をおにぎりで表示する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDirectOnigiri_Click_1(sender As Object, e As EventArgs) Handles MenuDirectOnigiri.Click
        Dim FR As New FrmOnigiri
        FR.Show()
        If MenuAutoSmall.Checked Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub
    ''' <summary>
    ''' 画像ファイルをおにぎりで表示する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuPicture_Click(sender As Object, e As EventArgs) Handles MenuPicture.Click
        Dim FLs() As String = Nothing
        Try
            Using OFD As New OpenFileDialog
                With OFD
                    .RestoreDirectory = True
                    .Title = "画像ファイルの選択(複数可能)"
                    .Filter = "画像ファイル(Bmp.PNG.JPG.JPEG)|*.bmp;*.png;*.jpg;*.jpeg|全てのファイル(*.*)|*.*"
                    .FilterIndex = 0
                    .Multiselect = True
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        FLs = .FileNames
                    End If
                End With
            End Using
            If (Not IsNothing(FLs)) Then
                For Each FL As String In FLs
                    Dim FR As New FrmOnigiri
                    With FR
                        .LoadPictureFile = FL
                        .Show()
                    End With
                Next
                If MenuAutoSmall.Checked Then
                    Me.WindowState = FormWindowState.Minimized
                End If
            End If
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "画像表示エラー")

        End Try

    End Sub
    ''' <summary>
    ''' 画像ファイルがドロップされた
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        Dim Flg As Boolean = False
        Dim Lst As ArrayList = New ArrayList({".BMP", ".PNG", ".JPG", ".JPEG"})

        Try
            Dim FLs As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
            If FLs.Count > 0 Then
                For Each FL As String In FLs
                    Dim Ex As String = System.IO.Path.GetExtension(FL).ToUpper
                    If Lst.IndexOf(Ex) > -1 Then
                        Dim FR As New FrmOnigiri
                        With FR
                            .LoadPictureFile = FL
                            .Show()
                        End With
                        Flg = True
                    End If
                Next
                If Flg Then
                    If MenuAutoSmall.Checked Then
                        Me.WindowState = FormWindowState.Minimized
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "ファイルドロップエラー")

        End Try
    End Sub

    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy
        Else
            'ファイル以外は受け付けない
            e.Effect = DragDropEffects.None
        End If
    End Sub

    
#Region "自動追尾関係"

    ''' <summary>
    ''' 自動追尾モード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuFormPosition_AutoFollow_Click(sender As Object, e As EventArgs) Handles MenuFormPosition_AutoFollow.Click, MenuAutoFollow.Click
        MenuFormPosition_AutoFollow.Checked = Not MenuFormPosition_AutoFollow.Checked
        If MenuFormPosition_AutoFollow.Checked Then
            Dim strThisProcess As String = System.Diagnostics.Process.GetCurrentProcess().ProcessName '実行アプリケーションのプロセス名を取得
            If System.Diagnostics.Process.GetProcessesByName(strThisProcess).Length > 1 Then '取得した同名のプロセスが他に存在するかを確認
                MsgBox("二重起動時には自動追尾モードをONする事が出来ません", 48, "エラー")
                MenuFormPosition_AutoFollow.Checked = False
                Return
            End If
        End If

        MenuAutoFollow.Checked = MenuFormPosition_AutoFollow.Checked
        Timer_AutoFollow.Enabled = MenuFormPosition_AutoFollow.Checked
        If MenuFormPosition_AutoFollow.Checked Then
            BtnFitSize.Image = My.Resources.dog_icon
        Else
            BtnFitSize.Image = My.Resources.zoom_fit_icon
        End If
    End Sub
    ''' <summary>
    ''' ウィンドウの自動追尾
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer_AutoFollow_Tick(sender As Object, e As EventArgs) Handles Timer_AutoFollow.Tick
        If Label2.Visible Then

            'アクティブなウィンドウのデバイスコンテキストを取得
            Dim hWnd As IntPtr = GetForegroundWindow()
            Dim winDC As IntPtr = GetWindowDC(hWnd)
            'ウィンドウの大きさを取得
            Dim winRect As New RECT
            'GetWindowRect(hWnd, winRect)
            Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
            DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)

            Dim _W As Integer = winRect.right - winRect.left + 2
            Dim _H As Integer = winRect.bottom - winRect.top + (Me.Size.Height - PictureBox1.Size.Height) + 12

            If Panel1.Dock = DockStyle.Top Then
                Me.Location = New Point(winRect.left, winRect.top - Panel1.Height)
            Else
                Me.Location = New Point(winRect.left - 5, winRect.top - 5)
            End If
            Me.Size = New Size(_W, _H)

            _OrgPosi = New Point(Me.Location)
            _OrgSize = New Size(Me.Size)

            ReleaseDC(hWnd, winDC)
        Else
            Try
                'アクティブなウィンドウのデバイスコンテキストを取得
                Dim hWnd As IntPtr = GetForegroundWindow()
                If Me.Handle <> hWnd Then
                    If ReadReg("General", "NotFollow", enum_Type.er_Boolean) Then
                        Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(GetPidFromHwnd(hWnd))
                        If hProcess.ProcessName.StartsWith("DeskShot") Then
                            'おにぎりなどの関連画面ならキャンセル
                            Return
                        End If
                    End If

                    Dim winDC As IntPtr = GetWindowDC(hWnd)
                    'ウィンドウの大きさを取得
                    Dim winRect As New RECT

                    If ReadReg("General", "FitType", enum_Type.er_Integer) = 0 Then
                        'GetWindowRect(hWnd, winRect)
                        Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
                        DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)
                    Else
                        GetWindowRect(hWnd, winRect)
                    End If

                    Dim _W As Integer = winRect.right - winRect.left + 2
                    Dim _H As Integer = winRect.bottom - winRect.top + (Me.Size.Height - PictureBox1.Size.Height) + 2 '12

                    Dim _Sift As PosiShift_Collection = Nothing
                    If _PosiShift.Count > 0 Then
                        _Sift = _PosiShift(0)
                    Else
                        _Sift = New PosiShift_Collection(False, 0, 0, 0, 0)
                    End If

                    Dim _ShiftX As Integer = _Sift.X, _ShiftY As Integer = _Sift.Y
                    Dim _ShiftHeight As Integer = _Sift.Height, _SiiftWidth As Integer = _Sift.Width
                    Dim _LocalShiftX As Integer = -2, _LocalShiftY As Integer = -2

                    Select Case True
                        Case _W < 50
                            BtnFitSize.Image = My.Resources.dog_icon_2 '画面追従エラー
                        Case _H < 100
                            BtnFitSize.Image = My.Resources.dog_icon_2 '画面追従エラー
                        Case Else
                            Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
                            Dim Display_H As Integer = s.Bounds.Height
                            Dim Display_W As Integer = s.Bounds.Width

                            'Dim _X As Integer = winRect.left + _ShiftX + _W
                            'Dim _Y As Integer = winRect.top + _ShiftY + _H
                            Dim _X As Integer = _ShiftX + _W
                            Dim _Y As Integer = _ShiftY + _H
                            If My.Computer.Screen.WorkingArea.Height < _Y OrElse My.Computer.Screen.WorkingArea.Width < _X Then
                                BtnFitSize.Image = My.Resources.dog_icon_2 '画面追従エラー
                            Else
                                If Panel1.Dock = DockStyle.Top Then
                                    Me.Location = New Point(winRect.left + _ShiftX + _LocalShiftX, winRect.top + _ShiftY - Panel1.Height + _LocalShiftY)
                                Else
                                    Me.Location = New Point(winRect.left + _ShiftX + _LocalShiftX, winRect.top + _ShiftY + _LocalShiftY)
                                End If
                                Me.Size = New Size(_W + _SiiftWidth - _LocalShiftX, _H + _ShiftHeight - _LocalShiftY)
                                BtnFitSize.Image = My.Resources.dog_icon
                            End If

                    End Select
                    ReleaseDC(hWnd, winDC)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    ''' <summary>
    ''' 最小化時には追尾モードを一時停止させる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMain_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Timer_AutoFollow.Enabled = False
        Else
            If MenuFormPosition_AutoFollow.Checked Then
                Timer_AutoFollow.Enabled = True
            End If
        End If
    End Sub
#End Region

    ''' <summary>
    ''' バーコード読み取り
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuBarcode_Click(sender As Object, e As EventArgs) Handles MenuBarcode.Click
        Try
            Dim Img As Bitmap = GetPicture()
            Call ReadBarcode(Me, Img)
        Catch ex As Exception
            MsgBox("バーコード解析エラー", 48, "エラー")
        End Try
    End Sub
#Region "WEBカメラ関係"
    Dim _FormInitial As Boolean = True 'フォーム初期化フラグ(ShownでFalse)
    Dim _CamIsExecute As Boolean = False '撮影実行中フラグ
    Dim videoDevices As FilterInfoCollection = Nothing
    Dim videoSource As VideoCaptureDevice = Nothing

    ''' <summary>
    ''' 入力デバイス選択（スクリーン）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuInput_Screen_Click(sender As Object, e As EventArgs) Handles MenuInput_Screen.Click
        If _CamIsExecute Then
            Call CloseVideoSource()
        End If
        PictureBox1.Image = Nothing
        PictureBox1.BackColor = Color.Fuchsia
        PanelCamera.Visible = False
        _CamIsExecute = False
        MenuInput_Camera.Checked = False
        MenuInput_Screen.Checked = True
        Call EnableUseButton(True)

    End Sub
    ''' <summary>
    ''' 入力デバイス選択（カメラ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuInput_Camera_Click(sender As Object, e As EventArgs) Handles MenuInput_Camera.Click
        If Not IsUseCAM() Then
            MsgBox("使用出来るカメラデバイスがありません", 48, "エラー")
            Return
        End If
        'カメラモードに切り換えた時に追尾モードをOFFにする
        If MenuFormPosition_AutoFollow.Checked Then
            Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
        End If

        PictureBox1.BackColor = Color.White
        PanelCamera.Visible = True
        MenuInput_Screen.Checked = False
        MenuInput_Camera.Checked = True
        Call EnableUseButton(False)
    End Sub

    ''' <summary>
    ''' 撮影開始ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExecuteCamera_Click(sender As Object, e As EventArgs) Handles BtnExecuteCamera.Click
        Call CamExecute()
    End Sub
    ''' <summary>
    ''' 使用出来るカメラがあるか？
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsUseCAM() As Boolean
        Try
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            If videoDevices.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As ApplicationException
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 撮影実行・停止
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CamExecute()
        Try
            If Not _CamIsExecute Then
                Dim form As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
                If form.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    videoSource = form.VideoDevice

                    'videoSource.SetCameraProperty(CameraControlProperty.Zoom, 1, CameraControlFlags.Manual)

                    AddHandler videoSource.NewFrame, AddressOf video_NewFrame
                    Call CloseVideoSource()
                    Call videoSource.Start()
                    Call CameraOtherButton(True)
                    _CamIsExecute = True
                End If
            Else
                If videoSource.IsRunning Then
                    Call CloseVideoSource()
                    Call CameraOtherButton(False)
                    PictureBox1.Image = Nothing
                    _CamIsExecute = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, 48, "カメラエラー")
        End Try
    End Sub
    ''' <summary>
    ''' カメラ関連ボタン有効・無効
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub CameraOtherButton(Value As Boolean)
        BtnCamera_Setting.Enabled = Value
        BtnCamera_ZoomIn.Enabled = Value
        BtnCamera_ZoomOut.Enabled = Value
        ChkFlip.Enabled = Value
        ChkRotate.Enabled = Value
    End Sub
    ''' <summary>
    ''' カメラ設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCamera_Setting_Click(sender As Object, e As EventArgs) Handles BtnCamera_Setting.Click
        If Not IsNothing(videoSource) Then
            videoSource.DisplayPropertyPage(0)
        End If
    End Sub
    ''' <summary>
    ''' 使用コントロールの有効・無効
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub EnableUseButton(Value As Boolean)
        PanelButton.Visible = Value
        'BtnDesktop.Visible = Value
        'BtnDialog.Visible = Value
        'BtnSelectAria.Visible = Value
        'BtnFitSize.Visible = Value
    End Sub
   
    ''' <summary>
    ''' 画像表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub video_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Dim img As Bitmap = CType(eventArgs.Frame.Clone, Bitmap)
        If ChkRotate.Checked Then
            img.RotateFlip(RotateFlipType.Rotate180FlipNone)
        End If
        If ChkFlip.Checked Then
            img.RotateFlip(RotateFlipType.RotateNoneFlipX)
        End If

        'If _VideoIsWork Then
        '    _aviWriter.AddFrame(img)        'ファイル書き込み
        'End If
        PictureBox1.Image = img
    End Sub
    ''' <summary>
    ''' カメラソースを閉じる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseVideoSource()
        If Not (videoSource Is Nothing) Then
            If videoSource.IsRunning Then
                videoSource.SignalToStop()
                videoSource.WaitForStop()

                videoSource = Nothing
            End If
        End If
    End Sub
    Dim _ZoomScale As Integer = 1
    ''' <summary>
    ''' ズームアウト
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCamera_ZoomOut_Click(sender As Object, e As EventArgs) Handles BtnCamera_ZoomOut.Click
        If Not IsNothing(videoSource) Then
            _ZoomScale -= 1
            If _ZoomScale < 1 Then _ZoomScale = 1
            videoSource.SetCameraProperty(CameraControlProperty.Zoom, _ZoomScale, CameraControlFlags.Manual)
        End If
    End Sub
    ''' <summary>
    ''' ズームイン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCamera_ZoomIn_Click(sender As Object, e As EventArgs) Handles BtnCamera_ZoomIn.Click
        If Not IsNothing(videoSource) Then
            _ZoomScale += 1
            videoSource.SetCameraProperty(CameraControlProperty.Zoom, _ZoomScale, CameraControlFlags.Manual)
        End If
    End Sub
#End Region

    Private Sub BtnExecuteCamera_MouseHover(sender As Object, e As EventArgs) Handles BtnExecuteCamera.MouseHover
        GcBalloonTip1.Show(BtnExecuteCamera)
    End Sub

    Private Sub BtnExecuteCamera_MouseLeave(sender As Object, e As EventArgs) Handles BtnExecuteCamera.MouseLeave
        GcBalloonTip1.Hide()
    End Sub

    Private Sub BtnCamera_ZoomIn_MouseHover(sender As Object, e As EventArgs) Handles BtnCamera_ZoomIn.MouseHover
        GcBalloonTip1.Show(BtnCamera_ZoomIn)
    End Sub

    Private Sub BtnCamera_ZoomIn_MouseLeave(sender As Object, e As EventArgs) Handles BtnCamera_ZoomIn.MouseLeave
        GcBalloonTip1.Hide()
    End Sub

    Private Sub BtnCamera_ZoomOut_MouseHover(sender As Object, e As EventArgs) Handles BtnCamera_ZoomOut.MouseHover
        GcBalloonTip1.Show(BtnCamera_ZoomOut)
    End Sub

    Private Sub BtnCamera_ZoomOut_MouseLeave(sender As Object, e As EventArgs) Handles BtnCamera_ZoomOut.MouseLeave
        GcBalloonTip1.Hide()
    End Sub

    ''' <summary>
    ''' 元サイズに戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOriginalSize_Click(sender As Object, e As EventArgs) Handles MenuOriginalSize.Click
        '位置とサイズを元に戻す 自動追尾はOFFにする
        If MenuFormPosition_AutoFollow.Checked Then
            Call MenuFormPosition_AutoFollow_Click(Nothing, Nothing)
        End If

        Me.Size = New Size(493, 424)
        Me.Location = New Point(100, 100)
        If LblimeStamp.Visible Then
            If ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer) = 0 Then
                LblimeStamp.Location = New Point(5, 5)
            End If
        End If
    End Sub


    Public _FrmShotcats As FrmShotcats = Nothing
    ''' <summary>
    ''' ショートカット表表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuShirtcat_Click(sender As Object, e As EventArgs) Handles MenuShirtcat.Click
        If IsNothing(_FrmShotcats) Then
            _FrmShotcats = New FrmShotcats
            _FrmShotcats.Show()
        Else
            _FrmShotcats.Focus()
        End If
    End Sub

  

End Class
''' <summary>
''' ポジション記憶用コレクション
''' </summary>  
''' <remarks></remarks>
Public Class ClassFormPosition
    ''' <summary>
    ''' 画面ID
    ''' </summary>
    ''' <remarks></remarks>
    Public ID As String
    ''' <summary>
    ''' 画面位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Position As Point
    ''' <summary>
    ''' 画面サイズ
    ''' </summary>
    ''' <remarks></remarks>
    Public FormSize As Size
End Class