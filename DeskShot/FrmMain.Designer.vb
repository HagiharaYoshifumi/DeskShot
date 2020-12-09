<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnWindowSmall = New System.Windows.Forms.Button()
        Me.PanelButton = New System.Windows.Forms.Panel()
        Me.BtnSelectAria = New System.Windows.Forms.Button()
        Me.BtnDialog = New System.Windows.Forms.Button()
        Me.BtnFitSize = New System.Windows.Forms.Button()
        Me.BtnDesktop = New System.Windows.Forms.Button()
        Me.BtnExecute = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnExecuteCamera = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ConMenuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_VideoSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_VideoAsSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureSave_BMP = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureSave_JPEG = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureSave_PNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureAsSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureClipbord = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_PictureWordpad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_Onigiri = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMode_OnigiriSet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuMode_PicturePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAutoSmall = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShotTimer5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMouseShotCaptuer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuWork_WindowSmall = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuWork_WindowFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuWork_WindowOpenner = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuWork_DialogFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuWork_AllScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuDirectOnigiri = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPicture = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuOriginalSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFormPosition_Regist = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuFormPosition_View = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFormPosition_Close = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuFormPosition_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuFormPosition_AutoFollow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMoveLast = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuVideoEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuBarcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuInputMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuInput_Screen = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuInput_Camera = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPosition = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPosition_Top = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPosition_Bottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting_ViewScale = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting_Resize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSetting_KeyHook = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSetting_Setting = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCompress = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPlayGIF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuShirtcat = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHelpText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAPPEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GcBalloonTip1 = New GrapeCity.Win.Components.GcBalloonTip()
        Me.BtnCamera_ZoomIn = New System.Windows.Forms.Button()
        Me.BtnCamera_ZoomOut = New System.Windows.Forms.Button()
        Me.ConMenuFit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuAutoFollow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuShift0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConMenuScaleMode = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuScale0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuScale1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuScale3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuScale4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuScaleEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConMenuFit2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuShift20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift22 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuShift23 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GcGlobalHook1 = New GrapeCity.Win.Components.GcGlobalHook(Me.components)
        Me.LblimeStamp = New System.Windows.Forms.Label()
        Me.ConMenuTimeStamp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuTimeStampPosi0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuTimeStampPosi1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeStampPosi2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeStampPosi3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTimeStampPosi4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuDisStamp = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_TimeStamp = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer_AutoFollow = New System.Windows.Forms.Timer(Me.components)
        Me.PanelCamera = New System.Windows.Forms.Panel()
        Me.BtnCamera_Setting = New System.Windows.Forms.Button()
        Me.ChkFlip = New System.Windows.Forms.CheckBox()
        Me.ChkRotate = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.PanelButton.SuspendLayout()
        Me.ConMenuMain.SuspendLayout()
        Me.ConMenuFit.SuspendLayout()
        Me.ConMenuScaleMode.SuspendLayout()
        Me.ConMenuFit2.SuspendLayout()
        Me.ConMenuTimeStamp.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCamera.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BtnWindowSmall)
        Me.Panel1.Controls.Add(Me.PanelButton)
        Me.Panel1.Controls.Add(Me.BtnExecute)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 37)
        Me.Panel1.TabIndex = 0
        '
        'BtnWindowSmall
        '
        Me.BtnWindowSmall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnWindowSmall, New GrapeCity.Win.Components.BalloonTipInformation("最小化します" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT]+[END]", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnWindowSmall.Image = CType(resources.GetObject("BtnWindowSmall.Image"), System.Drawing.Image)
        Me.BtnWindowSmall.Location = New System.Drawing.Point(463, 3)
        Me.BtnWindowSmall.Name = "BtnWindowSmall"
        Me.BtnWindowSmall.Size = New System.Drawing.Size(34, 31)
        Me.BtnWindowSmall.TabIndex = 6
        Me.BtnWindowSmall.UseVisualStyleBackColor = True
        '
        'PanelButton
        '
        Me.PanelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButton.Controls.Add(Me.BtnSelectAria)
        Me.PanelButton.Controls.Add(Me.BtnDialog)
        Me.PanelButton.Controls.Add(Me.BtnFitSize)
        Me.PanelButton.Controls.Add(Me.BtnDesktop)
        Me.PanelButton.Location = New System.Drawing.Point(295, 3)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(166, 37)
        Me.PanelButton.TabIndex = 16
        '
        'BtnSelectAria
        '
        Me.BtnSelectAria.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnSelectAria, New GrapeCity.Win.Components.BalloonTipInformation("マウスによりキャプチャー範囲を設定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT]+[Enter]", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnSelectAria.Image = CType(resources.GetObject("BtnSelectAria.Image"), System.Drawing.Image)
        Me.BtnSelectAria.Location = New System.Drawing.Point(89, 0)
        Me.BtnSelectAria.Name = "BtnSelectAria"
        Me.BtnSelectAria.Size = New System.Drawing.Size(34, 31)
        Me.BtnSelectAria.TabIndex = 15
        Me.BtnSelectAria.UseVisualStyleBackColor = True
        '
        'BtnDialog
        '
        Me.BtnDialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnDialog, New GrapeCity.Win.Components.BalloonTipInformation("最前面ウィンドウやダイアログなど" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "を一時的にフィットさせキャプチャーします。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT]+[Home]", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnDialog.Image = CType(resources.GetObject("BtnDialog.Image"), System.Drawing.Image)
        Me.BtnDialog.Location = New System.Drawing.Point(49, 0)
        Me.BtnDialog.Name = "BtnDialog"
        Me.BtnDialog.Size = New System.Drawing.Size(34, 31)
        Me.BtnDialog.TabIndex = 12
        Me.BtnDialog.UseVisualStyleBackColor = True
        Me.BtnDialog.Visible = False
        '
        'BtnFitSize
        '
        Me.BtnFitSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnFitSize, New GrapeCity.Win.Components.BalloonTipInformation(resources.GetString("BtnFitSize.BalloonTipInformation"), "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnFitSize.Image = CType(resources.GetObject("BtnFitSize.Image"), System.Drawing.Image)
        Me.BtnFitSize.Location = New System.Drawing.Point(129, 0)
        Me.BtnFitSize.Name = "BtnFitSize"
        Me.BtnFitSize.Size = New System.Drawing.Size(34, 31)
        Me.BtnFitSize.TabIndex = 14
        Me.BtnFitSize.UseVisualStyleBackColor = True
        '
        'BtnDesktop
        '
        Me.BtnDesktop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnDesktop, New GrapeCity.Win.Components.BalloonTipInformation("画面全体をキャプチャーします" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT]+[Pause]", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnDesktop.Image = CType(resources.GetObject("BtnDesktop.Image"), System.Drawing.Image)
        Me.BtnDesktop.Location = New System.Drawing.Point(9, 0)
        Me.BtnDesktop.Name = "BtnDesktop"
        Me.BtnDesktop.Size = New System.Drawing.Size(34, 31)
        Me.BtnDesktop.TabIndex = 13
        Me.BtnDesktop.UseVisualStyleBackColor = True
        Me.BtnDesktop.Visible = False
        '
        'BtnExecute
        '
        Me.BtnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExecute.Image = CType(resources.GetObject("BtnExecute.Image"), System.Drawing.Image)
        Me.BtnExecute.Location = New System.Drawing.Point(503, 3)
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(34, 31)
        Me.BtnExecute.TabIndex = 11
        Me.BtnExecute.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(7, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "."
        '
        'BtnExecuteCamera
        '
        Me.BtnExecuteCamera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnExecuteCamera, New GrapeCity.Win.Components.BalloonTipInformation("カメラのON/OFFを行います", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnExecuteCamera.Image = CType(resources.GetObject("BtnExecuteCamera.Image"), System.Drawing.Image)
        Me.BtnExecuteCamera.Location = New System.Drawing.Point(503, 5)
        Me.BtnExecuteCamera.Name = "BtnExecuteCamera"
        Me.BtnExecuteCamera.Size = New System.Drawing.Size(34, 31)
        Me.BtnExecuteCamera.TabIndex = 16
        Me.BtnExecuteCamera.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'ConMenuMain
        '
        Me.ConMenuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator9, Me.MenuAutoSmall, Me.MenuShotTimer, Me.MenuMouseShotCaptuer, Me.ToolStripMenuItem4, Me.ToolStripMenuItem3, Me.MenuMoveLast, Me.ToolStripSeparator1, Me.MenuVideoEdit, Me.MenuPlay, Me.MenuOpenFolder, Me.ToolStripSeparator3, Me.MenuBarcode, Me.MenuInputMode, Me.MenuPosition, Me.MenuSetting, Me.ToolStripMenuItem2, Me.ToolStripSeparator10, Me.MenuAPPEnd})
        Me.ConMenuMain.Name = "ContextMenuStrip1"
        Me.ConMenuMain.Size = New System.Drawing.Size(289, 508)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuMode_VideoSave, Me.MenuMode_VideoAsSave, Me.ToolStripSeparator2, Me.ToolStripMenuItem7, Me.MenuMode_PictureAsSave, Me.MenuMode_PictureClipbord, Me.MenuMode_PictureWordpad, Me.MenuMode_Onigiri, Me.MenuMode_OnigiriSet, Me.ToolStripSeparator8, Me.MenuMode_PicturePrint})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(288, 30)
        Me.ToolStripMenuItem1.Text = "動作モード"
        '
        'MenuMode_VideoSave
        '
        Me.MenuMode_VideoSave.Checked = True
        Me.MenuMode_VideoSave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuMode_VideoSave.Image = CType(resources.GetObject("MenuMode_VideoSave.Image"), System.Drawing.Image)
        Me.MenuMode_VideoSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_VideoSave.Name = "MenuMode_VideoSave"
        Me.MenuMode_VideoSave.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_VideoSave.Text = "動画（自動保存）"
        '
        'MenuMode_VideoAsSave
        '
        Me.MenuMode_VideoAsSave.Image = CType(resources.GetObject("MenuMode_VideoAsSave.Image"), System.Drawing.Image)
        Me.MenuMode_VideoAsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_VideoAsSave.Name = "MenuMode_VideoAsSave"
        Me.MenuMode_VideoAsSave.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_VideoAsSave.Text = "動画（手動保存）"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(273, 6)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuMode_PictureSave_BMP, Me.MenuMode_PictureSave_JPEG, Me.MenuMode_PictureSave_PNG})
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(276, 30)
        Me.ToolStripMenuItem7.Text = "静止画（自動保存）"
        '
        'MenuMode_PictureSave_BMP
        '
        Me.MenuMode_PictureSave_BMP.Image = CType(resources.GetObject("MenuMode_PictureSave_BMP.Image"), System.Drawing.Image)
        Me.MenuMode_PictureSave_BMP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureSave_BMP.Name = "MenuMode_PictureSave_BMP"
        Me.MenuMode_PictureSave_BMP.Size = New System.Drawing.Size(180, 30)
        Me.MenuMode_PictureSave_BMP.Text = "ビットマップ形式"
        '
        'MenuMode_PictureSave_JPEG
        '
        Me.MenuMode_PictureSave_JPEG.Image = CType(resources.GetObject("MenuMode_PictureSave_JPEG.Image"), System.Drawing.Image)
        Me.MenuMode_PictureSave_JPEG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureSave_JPEG.Name = "MenuMode_PictureSave_JPEG"
        Me.MenuMode_PictureSave_JPEG.Size = New System.Drawing.Size(180, 30)
        Me.MenuMode_PictureSave_JPEG.Text = "JPEG形式"
        '
        'MenuMode_PictureSave_PNG
        '
        Me.MenuMode_PictureSave_PNG.Image = CType(resources.GetObject("MenuMode_PictureSave_PNG.Image"), System.Drawing.Image)
        Me.MenuMode_PictureSave_PNG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureSave_PNG.Name = "MenuMode_PictureSave_PNG"
        Me.MenuMode_PictureSave_PNG.Size = New System.Drawing.Size(180, 30)
        Me.MenuMode_PictureSave_PNG.Text = "PNG形式"
        '
        'MenuMode_PictureAsSave
        '
        Me.MenuMode_PictureAsSave.Image = CType(resources.GetObject("MenuMode_PictureAsSave.Image"), System.Drawing.Image)
        Me.MenuMode_PictureAsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureAsSave.Name = "MenuMode_PictureAsSave"
        Me.MenuMode_PictureAsSave.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_PictureAsSave.Text = "静止画（手動保存）"
        '
        'MenuMode_PictureClipbord
        '
        Me.MenuMode_PictureClipbord.Image = CType(resources.GetObject("MenuMode_PictureClipbord.Image"), System.Drawing.Image)
        Me.MenuMode_PictureClipbord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureClipbord.Name = "MenuMode_PictureClipbord"
        Me.MenuMode_PictureClipbord.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_PictureClipbord.Text = "静止画（クリップボード）"
        '
        'MenuMode_PictureWordpad
        '
        Me.MenuMode_PictureWordpad.Image = Global.DeskShot.My.Resources.Resources.Wordpad_icon
        Me.MenuMode_PictureWordpad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PictureWordpad.Name = "MenuMode_PictureWordpad"
        Me.MenuMode_PictureWordpad.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_PictureWordpad.Text = "静止画（ワードパッド連携）"
        '
        'MenuMode_Onigiri
        '
        Me.MenuMode_Onigiri.Image = CType(resources.GetObject("MenuMode_Onigiri.Image"), System.Drawing.Image)
        Me.MenuMode_Onigiri.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_Onigiri.Name = "MenuMode_Onigiri"
        Me.MenuMode_Onigiri.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_Onigiri.Text = "おにぎり（一時クリップ）"
        '
        'MenuMode_OnigiriSet
        '
        Me.MenuMode_OnigiriSet.Image = CType(resources.GetObject("MenuMode_OnigiriSet.Image"), System.Drawing.Image)
        Me.MenuMode_OnigiriSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_OnigiriSet.Name = "MenuMode_OnigiriSet"
        Me.MenuMode_OnigiriSet.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_OnigiriSet.Text = "おにぎりセット（クリップセット）"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(273, 6)
        '
        'MenuMode_PicturePrint
        '
        Me.MenuMode_PicturePrint.Image = Global.DeskShot.My.Resources.Resources.printer_icon
        Me.MenuMode_PicturePrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMode_PicturePrint.Name = "MenuMode_PicturePrint"
        Me.MenuMode_PicturePrint.Size = New System.Drawing.Size(276, 30)
        Me.MenuMode_PicturePrint.Text = "直接印刷"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(285, 6)
        '
        'MenuAutoSmall
        '
        Me.MenuAutoSmall.Image = CType(resources.GetObject("MenuAutoSmall.Image"), System.Drawing.Image)
        Me.MenuAutoSmall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuAutoSmall.Name = "MenuAutoSmall"
        Me.MenuAutoSmall.Size = New System.Drawing.Size(288, 30)
        Me.MenuAutoSmall.Text = "キャプチャー動作終了後、最小化する"
        '
        'MenuShotTimer
        '
        Me.MenuShotTimer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuShotTimer0, Me.MenuShotTimer1, Me.MenuShotTimer2, Me.MenuShotTimer3, Me.MenuShotTimer4, Me.MenuShotTimer5})
        Me.MenuShotTimer.Image = CType(resources.GetObject("MenuShotTimer.Image"), System.Drawing.Image)
        Me.MenuShotTimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuShotTimer.Name = "MenuShotTimer"
        Me.MenuShotTimer.Size = New System.Drawing.Size(288, 30)
        Me.MenuShotTimer.Text = "ショットタイマー"
        '
        'MenuShotTimer0
        '
        Me.MenuShotTimer0.Checked = True
        Me.MenuShotTimer0.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuShotTimer0.Name = "MenuShotTimer0"
        Me.MenuShotTimer0.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer0.Text = "使用しない [Alt]+[0]"
        '
        'MenuShotTimer1
        '
        Me.MenuShotTimer1.Name = "MenuShotTimer1"
        Me.MenuShotTimer1.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer1.Text = "３秒 [Alt]+[1]"
        '
        'MenuShotTimer2
        '
        Me.MenuShotTimer2.Name = "MenuShotTimer2"
        Me.MenuShotTimer2.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer2.Text = "５秒 [Alt]+[2]"
        '
        'MenuShotTimer3
        '
        Me.MenuShotTimer3.Name = "MenuShotTimer3"
        Me.MenuShotTimer3.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer3.Text = "１０秒 [Alt]+[3]"
        '
        'MenuShotTimer4
        '
        Me.MenuShotTimer4.Name = "MenuShotTimer4"
        Me.MenuShotTimer4.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer4.Text = "１５秒 [Alt]+[4]"
        '
        'MenuShotTimer5
        '
        Me.MenuShotTimer5.Name = "MenuShotTimer5"
        Me.MenuShotTimer5.Size = New System.Drawing.Size(193, 22)
        Me.MenuShotTimer5.Text = "２０秒 [Alt]+[5]"
        '
        'MenuMouseShotCaptuer
        '
        Me.MenuMouseShotCaptuer.Image = CType(resources.GetObject("MenuMouseShotCaptuer.Image"), System.Drawing.Image)
        Me.MenuMouseShotCaptuer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMouseShotCaptuer.Name = "MenuMouseShotCaptuer"
        Me.MenuMouseShotCaptuer.Size = New System.Drawing.Size(288, 30)
        Me.MenuMouseShotCaptuer.Text = "マウスショットキャプチャー"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuWork_WindowSmall, Me.MenuWork_WindowFit, Me.MenuWork_WindowOpenner, Me.MenuWork_DialogFit, Me.MenuWork_AllScreen, Me.ToolStripSeparator15, Me.MenuDirectOnigiri, Me.MenuPicture, Me.ToolStripSeparator17, Me.MenuOriginalSize})
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(288, 30)
        Me.ToolStripMenuItem4.Text = "操作"
        '
        'MenuWork_WindowSmall
        '
        Me.MenuWork_WindowSmall.Image = CType(resources.GetObject("MenuWork_WindowSmall.Image"), System.Drawing.Image)
        Me.MenuWork_WindowSmall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuWork_WindowSmall.Name = "MenuWork_WindowSmall"
        Me.MenuWork_WindowSmall.Size = New System.Drawing.Size(322, 30)
        Me.MenuWork_WindowSmall.Text = "最小化 [Alt]+[End]"
        '
        'MenuWork_WindowFit
        '
        Me.MenuWork_WindowFit.Image = CType(resources.GetObject("MenuWork_WindowFit.Image"), System.Drawing.Image)
        Me.MenuWork_WindowFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuWork_WindowFit.Name = "MenuWork_WindowFit"
        Me.MenuWork_WindowFit.Size = New System.Drawing.Size(322, 30)
        Me.MenuWork_WindowFit.Text = "ウィンドウフイット [Alt]+[ScrollLock]"
        '
        'MenuWork_WindowOpenner
        '
        Me.MenuWork_WindowOpenner.Image = CType(resources.GetObject("MenuWork_WindowOpenner.Image"), System.Drawing.Image)
        Me.MenuWork_WindowOpenner.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuWork_WindowOpenner.Name = "MenuWork_WindowOpenner"
        Me.MenuWork_WindowOpenner.Size = New System.Drawing.Size(322, 30)
        Me.MenuWork_WindowOpenner.Text = "ウィンドウオープナー [Alt]+[Enter]"
        '
        'MenuWork_DialogFit
        '
        Me.MenuWork_DialogFit.Image = CType(resources.GetObject("MenuWork_DialogFit.Image"), System.Drawing.Image)
        Me.MenuWork_DialogFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuWork_DialogFit.Name = "MenuWork_DialogFit"
        Me.MenuWork_DialogFit.Size = New System.Drawing.Size(322, 30)
        Me.MenuWork_DialogFit.Text = "ダイアログフィット [Alt]+[Home]"
        '
        'MenuWork_AllScreen
        '
        Me.MenuWork_AllScreen.Image = CType(resources.GetObject("MenuWork_AllScreen.Image"), System.Drawing.Image)
        Me.MenuWork_AllScreen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuWork_AllScreen.Name = "MenuWork_AllScreen"
        Me.MenuWork_AllScreen.Size = New System.Drawing.Size(322, 30)
        Me.MenuWork_AllScreen.Text = "全画面 [Alt]+[Pause]"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(319, 6)
        '
        'MenuDirectOnigiri
        '
        Me.MenuDirectOnigiri.Image = CType(resources.GetObject("MenuDirectOnigiri.Image"), System.Drawing.Image)
        Me.MenuDirectOnigiri.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuDirectOnigiri.Name = "MenuDirectOnigiri"
        Me.MenuDirectOnigiri.Size = New System.Drawing.Size(322, 30)
        Me.MenuDirectOnigiri.Text = "クリップボード画像操作"
        '
        'MenuPicture
        '
        Me.MenuPicture.Image = CType(resources.GetObject("MenuPicture.Image"), System.Drawing.Image)
        Me.MenuPicture.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPicture.Name = "MenuPicture"
        Me.MenuPicture.Size = New System.Drawing.Size(322, 30)
        Me.MenuPicture.Text = "画像ファイルの読み込み"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(319, 6)
        '
        'MenuOriginalSize
        '
        Me.MenuOriginalSize.Image = CType(resources.GetObject("MenuOriginalSize.Image"), System.Drawing.Image)
        Me.MenuOriginalSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuOriginalSize.Name = "MenuOriginalSize"
        Me.MenuOriginalSize.Size = New System.Drawing.Size(322, 30)
        Me.MenuOriginalSize.Text = "起動サイズに戻す [ALT]+[CTRL]+[HOME]"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFormPosition_Regist, Me.ToolStripSeparator5, Me.MenuFormPosition_View, Me.MenuFormPosition_Close, Me.ToolStripSeparator7, Me.MenuFormPosition_Clear, Me.ToolStripSeparator14, Me.MenuFormPosition_AutoFollow})
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(288, 30)
        Me.ToolStripMenuItem3.Text = "フレーム位置"
        '
        'MenuFormPosition_Regist
        '
        Me.MenuFormPosition_Regist.Image = CType(resources.GetObject("MenuFormPosition_Regist.Image"), System.Drawing.Image)
        Me.MenuFormPosition_Regist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFormPosition_Regist.Name = "MenuFormPosition_Regist"
        Me.MenuFormPosition_Regist.Size = New System.Drawing.Size(256, 30)
        Me.MenuFormPosition_Regist.Text = "位置記録 [Ctrl]+[Insert]"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(253, 6)
        '
        'MenuFormPosition_View
        '
        Me.MenuFormPosition_View.Image = CType(resources.GetObject("MenuFormPosition_View.Image"), System.Drawing.Image)
        Me.MenuFormPosition_View.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFormPosition_View.Name = "MenuFormPosition_View"
        Me.MenuFormPosition_View.Size = New System.Drawing.Size(256, 30)
        Me.MenuFormPosition_View.Text = "記憶位置表示 [Ctrl]+[Delete]"
        '
        'MenuFormPosition_Close
        '
        Me.MenuFormPosition_Close.Image = CType(resources.GetObject("MenuFormPosition_Close.Image"), System.Drawing.Image)
        Me.MenuFormPosition_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFormPosition_Close.Name = "MenuFormPosition_Close"
        Me.MenuFormPosition_Close.Size = New System.Drawing.Size(256, 30)
        Me.MenuFormPosition_Close.Text = "表示キャンセル"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(253, 6)
        '
        'MenuFormPosition_Clear
        '
        Me.MenuFormPosition_Clear.Image = CType(resources.GetObject("MenuFormPosition_Clear.Image"), System.Drawing.Image)
        Me.MenuFormPosition_Clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFormPosition_Clear.Name = "MenuFormPosition_Clear"
        Me.MenuFormPosition_Clear.Size = New System.Drawing.Size(256, 30)
        Me.MenuFormPosition_Clear.Text = "記憶位置クリア"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(253, 6)
        '
        'MenuFormPosition_AutoFollow
        '
        Me.MenuFormPosition_AutoFollow.Image = CType(resources.GetObject("MenuFormPosition_AutoFollow.Image"), System.Drawing.Image)
        Me.MenuFormPosition_AutoFollow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFormPosition_AutoFollow.Name = "MenuFormPosition_AutoFollow"
        Me.MenuFormPosition_AutoFollow.Size = New System.Drawing.Size(256, 30)
        Me.MenuFormPosition_AutoFollow.Text = "ウィンドウ自動追尾 [Ctrl]+[Q]"
        '
        'MenuMoveLast
        '
        Me.MenuMoveLast.Image = CType(resources.GetObject("MenuMoveLast.Image"), System.Drawing.Image)
        Me.MenuMoveLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMoveLast.Name = "MenuMoveLast"
        Me.MenuMoveLast.Size = New System.Drawing.Size(288, 30)
        Me.MenuMoveLast.Text = "１つ前の位置・サイズに戻す"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(285, 6)
        '
        'MenuVideoEdit
        '
        Me.MenuVideoEdit.Image = CType(resources.GetObject("MenuVideoEdit.Image"), System.Drawing.Image)
        Me.MenuVideoEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuVideoEdit.Name = "MenuVideoEdit"
        Me.MenuVideoEdit.Size = New System.Drawing.Size(288, 30)
        Me.MenuVideoEdit.Text = "GIF画像編集"
        '
        'MenuPlay
        '
        Me.MenuPlay.Image = CType(resources.GetObject("MenuPlay.Image"), System.Drawing.Image)
        Me.MenuPlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPlay.Name = "MenuPlay"
        Me.MenuPlay.Size = New System.Drawing.Size(288, 30)
        Me.MenuPlay.Text = "再生"
        '
        'MenuOpenFolder
        '
        Me.MenuOpenFolder.Image = CType(resources.GetObject("MenuOpenFolder.Image"), System.Drawing.Image)
        Me.MenuOpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuOpenFolder.Name = "MenuOpenFolder"
        Me.MenuOpenFolder.Size = New System.Drawing.Size(288, 30)
        Me.MenuOpenFolder.Text = "フォルダを開く"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(285, 6)
        '
        'MenuBarcode
        '
        Me.MenuBarcode.Image = CType(resources.GetObject("MenuBarcode.Image"), System.Drawing.Image)
        Me.MenuBarcode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuBarcode.Name = "MenuBarcode"
        Me.MenuBarcode.Size = New System.Drawing.Size(288, 30)
        Me.MenuBarcode.Text = "バーコード読み取り"
        '
        'MenuInputMode
        '
        Me.MenuInputMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuInput_Screen, Me.MenuInput_Camera})
        Me.MenuInputMode.Image = CType(resources.GetObject("MenuInputMode.Image"), System.Drawing.Image)
        Me.MenuInputMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuInputMode.Name = "MenuInputMode"
        Me.MenuInputMode.Size = New System.Drawing.Size(288, 30)
        Me.MenuInputMode.Text = "入力デバイス"
        '
        'MenuInput_Screen
        '
        Me.MenuInput_Screen.Checked = True
        Me.MenuInput_Screen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuInput_Screen.Image = CType(resources.GetObject("MenuInput_Screen.Image"), System.Drawing.Image)
        Me.MenuInput_Screen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuInput_Screen.Name = "MenuInput_Screen"
        Me.MenuInput_Screen.Size = New System.Drawing.Size(120, 30)
        Me.MenuInput_Screen.Text = "画面"
        '
        'MenuInput_Camera
        '
        Me.MenuInput_Camera.Image = CType(resources.GetObject("MenuInput_Camera.Image"), System.Drawing.Image)
        Me.MenuInput_Camera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuInput_Camera.Name = "MenuInput_Camera"
        Me.MenuInput_Camera.Size = New System.Drawing.Size(120, 30)
        Me.MenuInput_Camera.Text = "カメラ"
        '
        'MenuPosition
        '
        Me.MenuPosition.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPosition_Top, Me.MenuPosition_Bottom})
        Me.MenuPosition.Image = CType(resources.GetObject("MenuPosition.Image"), System.Drawing.Image)
        Me.MenuPosition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPosition.Name = "MenuPosition"
        Me.MenuPosition.Size = New System.Drawing.Size(288, 30)
        Me.MenuPosition.Text = "メニュー位置"
        '
        'MenuPosition_Top
        '
        Me.MenuPosition_Top.Name = "MenuPosition_Top"
        Me.MenuPosition_Top.Size = New System.Drawing.Size(112, 22)
        Me.MenuPosition_Top.Text = "上付き"
        '
        'MenuPosition_Bottom
        '
        Me.MenuPosition_Bottom.Checked = True
        Me.MenuPosition_Bottom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuPosition_Bottom.Name = "MenuPosition_Bottom"
        Me.MenuPosition_Bottom.Size = New System.Drawing.Size(112, 22)
        Me.MenuPosition_Bottom.Text = "下付き"
        '
        'MenuSetting
        '
        Me.MenuSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSetting_ViewScale, Me.MenuSetting_Resize, Me.MenuSetting_KeyHook, Me.ToolStripSeparator4, Me.MenuSetting_Setting})
        Me.MenuSetting.Image = CType(resources.GetObject("MenuSetting.Image"), System.Drawing.Image)
        Me.MenuSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSetting.Name = "MenuSetting"
        Me.MenuSetting.Size = New System.Drawing.Size(288, 30)
        Me.MenuSetting.Text = "設定"
        '
        'MenuSetting_ViewScale
        '
        Me.MenuSetting_ViewScale.Image = CType(resources.GetObject("MenuSetting_ViewScale.Image"), System.Drawing.Image)
        Me.MenuSetting_ViewScale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSetting_ViewScale.Name = "MenuSetting_ViewScale"
        Me.MenuSetting_ViewScale.Size = New System.Drawing.Size(180, 30)
        Me.MenuSetting_ViewScale.Text = "シフト設定モード"
        '
        'MenuSetting_Resize
        '
        Me.MenuSetting_Resize.Image = CType(resources.GetObject("MenuSetting_Resize.Image"), System.Drawing.Image)
        Me.MenuSetting_Resize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSetting_Resize.Name = "MenuSetting_Resize"
        Me.MenuSetting_Resize.Size = New System.Drawing.Size(180, 30)
        Me.MenuSetting_Resize.Text = "サイズ指定"
        '
        'MenuSetting_KeyHook
        '
        Me.MenuSetting_KeyHook.Name = "MenuSetting_KeyHook"
        Me.MenuSetting_KeyHook.Size = New System.Drawing.Size(180, 30)
        Me.MenuSetting_KeyHook.Text = "キーボードフック"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
        '
        'MenuSetting_Setting
        '
        Me.MenuSetting_Setting.Image = CType(resources.GetObject("MenuSetting_Setting.Image"), System.Drawing.Image)
        Me.MenuSetting_Setting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSetting_Setting.Name = "MenuSetting_Setting"
        Me.MenuSetting_Setting.Size = New System.Drawing.Size(180, 30)
        Me.MenuSetting_Setting.Text = "詳細設定"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCompress, Me.MenuPlayGIF, Me.ToolStripSeparator13, Me.MenuShirtcat, Me.MenuHelpText})
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(288, 30)
        Me.ToolStripMenuItem2.Text = "その他"
        '
        'MenuCompress
        '
        Me.MenuCompress.Image = CType(resources.GetObject("MenuCompress.Image"), System.Drawing.Image)
        Me.MenuCompress.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuCompress.Name = "MenuCompress"
        Me.MenuCompress.Size = New System.Drawing.Size(201, 30)
        Me.MenuCompress.Text = "GIF圧縮サイトを開く"
        '
        'MenuPlayGIF
        '
        Me.MenuPlayGIF.Image = CType(resources.GetObject("MenuPlayGIF.Image"), System.Drawing.Image)
        Me.MenuPlayGIF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPlayGIF.Name = "MenuPlayGIF"
        Me.MenuPlayGIF.Size = New System.Drawing.Size(201, 30)
        Me.MenuPlayGIF.Text = "GIF再生ソフト起動"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(198, 6)
        '
        'MenuShirtcat
        '
        Me.MenuShirtcat.Image = CType(resources.GetObject("MenuShirtcat.Image"), System.Drawing.Image)
        Me.MenuShirtcat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuShirtcat.Name = "MenuShirtcat"
        Me.MenuShirtcat.Size = New System.Drawing.Size(201, 30)
        Me.MenuShirtcat.Text = "ショートカット表"
        '
        'MenuHelpText
        '
        Me.MenuHelpText.Image = CType(resources.GetObject("MenuHelpText.Image"), System.Drawing.Image)
        Me.MenuHelpText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuHelpText.Name = "MenuHelpText"
        Me.MenuHelpText.Size = New System.Drawing.Size(201, 30)
        Me.MenuHelpText.Text = "ヘルプテキスト表示"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(285, 6)
        '
        'MenuAPPEnd
        '
        Me.MenuAPPEnd.Image = CType(resources.GetObject("MenuAPPEnd.Image"), System.Drawing.Image)
        Me.MenuAPPEnd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuAPPEnd.Name = "MenuAPPEnd"
        Me.MenuAPPEnd.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MenuAPPEnd.Size = New System.Drawing.Size(288, 30)
        Me.MenuAPPEnd.Text = "終了"
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'BtnCamera_ZoomIn
        '
        Me.BtnCamera_ZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnCamera_ZoomIn, New GrapeCity.Win.Components.BalloonTipInformation("ズームインします", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnCamera_ZoomIn.Enabled = False
        Me.BtnCamera_ZoomIn.Image = CType(resources.GetObject("BtnCamera_ZoomIn.Image"), System.Drawing.Image)
        Me.BtnCamera_ZoomIn.Location = New System.Drawing.Point(285, 5)
        Me.BtnCamera_ZoomIn.Name = "BtnCamera_ZoomIn"
        Me.BtnCamera_ZoomIn.Size = New System.Drawing.Size(34, 31)
        Me.BtnCamera_ZoomIn.TabIndex = 21
        Me.BtnCamera_ZoomIn.UseVisualStyleBackColor = True
        '
        'BtnCamera_ZoomOut
        '
        Me.BtnCamera_ZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GcBalloonTip1.SetBalloonTipInformation(Me.BtnCamera_ZoomOut, New GrapeCity.Win.Components.BalloonTipInformation("ズームアウトします", "説明", GrapeCity.Win.Components.BalloonShape.RoundCorner, GrapeCity.Win.Components.IconType.Information, 5000, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte)), System.Drawing.SystemColors.InfoText, New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold), System.Drawing.SystemColors.InfoText, System.Drawing.SystemColors.Info, Nothing, True, True, False, Nothing, 600, 0))
        Me.BtnCamera_ZoomOut.Enabled = False
        Me.BtnCamera_ZoomOut.Image = CType(resources.GetObject("BtnCamera_ZoomOut.Image"), System.Drawing.Image)
        Me.BtnCamera_ZoomOut.Location = New System.Drawing.Point(325, 5)
        Me.BtnCamera_ZoomOut.Name = "BtnCamera_ZoomOut"
        Me.BtnCamera_ZoomOut.Size = New System.Drawing.Size(34, 31)
        Me.BtnCamera_ZoomOut.TabIndex = 20
        Me.BtnCamera_ZoomOut.UseVisualStyleBackColor = True
        '
        'ConMenuFit
        '
        Me.ConMenuFit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAutoFollow, Me.ToolStripSeparator16, Me.MenuShift0, Me.MenuShift1, Me.MenuShift2, Me.MenuShift3})
        Me.ConMenuFit.Name = "ContextMenuStrip2"
        Me.ConMenuFit.Size = New System.Drawing.Size(249, 120)
        '
        'MenuAutoFollow
        '
        Me.MenuAutoFollow.Image = CType(resources.GetObject("MenuAutoFollow.Image"), System.Drawing.Image)
        Me.MenuAutoFollow.Name = "MenuAutoFollow"
        Me.MenuAutoFollow.Size = New System.Drawing.Size(248, 22)
        Me.MenuAutoFollow.Text = "ウィンドウ自動追尾 [Ctrl]+[Q]"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(245, 6)
        '
        'MenuShift0
        '
        Me.MenuShift0.Name = "MenuShift0"
        Me.MenuShift0.Size = New System.Drawing.Size(248, 22)
        Me.MenuShift0.Tag = "0"
        Me.MenuShift0.Text = "シフト量１で自動フィットする"
        '
        'MenuShift1
        '
        Me.MenuShift1.Name = "MenuShift1"
        Me.MenuShift1.Size = New System.Drawing.Size(248, 22)
        Me.MenuShift1.Tag = "1"
        Me.MenuShift1.Text = "シフト量２で自動フィットする"
        '
        'MenuShift2
        '
        Me.MenuShift2.Name = "MenuShift2"
        Me.MenuShift2.Size = New System.Drawing.Size(248, 22)
        Me.MenuShift2.Tag = "2"
        Me.MenuShift2.Text = "シフト量３で自動フィットする"
        '
        'MenuShift3
        '
        Me.MenuShift3.Name = "MenuShift3"
        Me.MenuShift3.Size = New System.Drawing.Size(248, 22)
        Me.MenuShift3.Tag = "3"
        Me.MenuShift3.Text = "シフト量４で自動フィットする"
        '
        'ConMenuScaleMode
        '
        Me.ConMenuScaleMode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuScale0, Me.MenuScale1, Me.MenuScale3, Me.MenuScale4, Me.ToolStripSeparator6, Me.MenuScaleEnd})
        Me.ConMenuScaleMode.Name = "ContextMenuStrip2"
        Me.ConMenuScaleMode.Size = New System.Drawing.Size(281, 120)
        '
        'MenuScale0
        '
        Me.MenuScale0.Name = "MenuScale0"
        Me.MenuScale0.Size = New System.Drawing.Size(280, 22)
        Me.MenuScale0.Tag = "0"
        Me.MenuScale0.Text = "シフト量を「シフト量１」に設定する"
        '
        'MenuScale1
        '
        Me.MenuScale1.Name = "MenuScale1"
        Me.MenuScale1.Size = New System.Drawing.Size(280, 22)
        Me.MenuScale1.Tag = "1"
        Me.MenuScale1.Text = "シフト量を「シフト量２」に設定する"
        '
        'MenuScale3
        '
        Me.MenuScale3.Name = "MenuScale3"
        Me.MenuScale3.Size = New System.Drawing.Size(280, 22)
        Me.MenuScale3.Tag = "2"
        Me.MenuScale3.Text = "シフト量を「シフト量３」に設定する"
        '
        'MenuScale4
        '
        Me.MenuScale4.Name = "MenuScale4"
        Me.MenuScale4.Size = New System.Drawing.Size(280, 22)
        Me.MenuScale4.Tag = "3"
        Me.MenuScale4.Text = "シフト量を「シフト量４」に設定する"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(277, 6)
        '
        'MenuScaleEnd
        '
        Me.MenuScaleEnd.Name = "MenuScaleEnd"
        Me.MenuScaleEnd.Size = New System.Drawing.Size(280, 22)
        Me.MenuScaleEnd.Text = "シフト設定モード終了"
        '
        'ConMenuFit2
        '
        Me.ConMenuFit2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuShift20, Me.MenuShift21, Me.MenuShift22, Me.MenuShift23})
        Me.ConMenuFit2.Name = "ContextMenuStrip2"
        Me.ConMenuFit2.Size = New System.Drawing.Size(245, 92)
        '
        'MenuShift20
        '
        Me.MenuShift20.Name = "MenuShift20"
        Me.MenuShift20.Size = New System.Drawing.Size(244, 22)
        Me.MenuShift20.Tag = "0"
        Me.MenuShift20.Text = "シフト量１で自動フィットする"
        '
        'MenuShift21
        '
        Me.MenuShift21.Name = "MenuShift21"
        Me.MenuShift21.Size = New System.Drawing.Size(244, 22)
        Me.MenuShift21.Tag = "1"
        Me.MenuShift21.Text = "シフト量２で自動フィットする"
        '
        'MenuShift22
        '
        Me.MenuShift22.Name = "MenuShift22"
        Me.MenuShift22.Size = New System.Drawing.Size(244, 22)
        Me.MenuShift22.Tag = "2"
        Me.MenuShift22.Text = "シフト量３で自動フィットする"
        '
        'MenuShift23
        '
        Me.MenuShift23.Name = "MenuShift23"
        Me.MenuShift23.Size = New System.Drawing.Size(244, 22)
        Me.MenuShift23.Tag = "3"
        Me.MenuShift23.Text = "シフト量４で自動フィットする"
        '
        'GcGlobalHook1
        '
        '
        'LblimeStamp
        '
        Me.LblimeStamp.AutoSize = True
        Me.LblimeStamp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblimeStamp.ContextMenuStrip = Me.ConMenuTimeStamp
        Me.LblimeStamp.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblimeStamp.ForeColor = System.Drawing.Color.White
        Me.LblimeStamp.Location = New System.Drawing.Point(119, 9)
        Me.LblimeStamp.Name = "LblimeStamp"
        Me.LblimeStamp.Padding = New System.Windows.Forms.Padding(3)
        Me.LblimeStamp.Size = New System.Drawing.Size(17, 21)
        Me.LblimeStamp.TabIndex = 4
        Me.LblimeStamp.Text = "."
        '
        'ConMenuTimeStamp
        '
        Me.ConMenuTimeStamp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuTimeStampPosi0, Me.ToolStripSeparator11, Me.MenuTimeStampPosi1, Me.MenuTimeStampPosi2, Me.MenuTimeStampPosi3, Me.MenuTimeStampPosi4, Me.ToolStripSeparator12, Me.MenuDisStamp})
        Me.ConMenuTimeStamp.Name = "ConMenuTimeStamp"
        Me.ConMenuTimeStamp.Size = New System.Drawing.Size(125, 148)
        '
        'MenuTimeStampPosi0
        '
        Me.MenuTimeStampPosi0.Name = "MenuTimeStampPosi0"
        Me.MenuTimeStampPosi0.Size = New System.Drawing.Size(124, 22)
        Me.MenuTimeStampPosi0.Text = "手動設定"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(121, 6)
        '
        'MenuTimeStampPosi1
        '
        Me.MenuTimeStampPosi1.Name = "MenuTimeStampPosi1"
        Me.MenuTimeStampPosi1.Size = New System.Drawing.Size(124, 22)
        Me.MenuTimeStampPosi1.Text = "左上固定"
        '
        'MenuTimeStampPosi2
        '
        Me.MenuTimeStampPosi2.Name = "MenuTimeStampPosi2"
        Me.MenuTimeStampPosi2.Size = New System.Drawing.Size(124, 22)
        Me.MenuTimeStampPosi2.Text = "左下固定"
        '
        'MenuTimeStampPosi3
        '
        Me.MenuTimeStampPosi3.Name = "MenuTimeStampPosi3"
        Me.MenuTimeStampPosi3.Size = New System.Drawing.Size(124, 22)
        Me.MenuTimeStampPosi3.Text = "右上固定"
        '
        'MenuTimeStampPosi4
        '
        Me.MenuTimeStampPosi4.Name = "MenuTimeStampPosi4"
        Me.MenuTimeStampPosi4.Size = New System.Drawing.Size(124, 22)
        Me.MenuTimeStampPosi4.Text = "右下固定"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(121, 6)
        '
        'MenuDisStamp
        '
        Me.MenuDisStamp.Name = "MenuDisStamp"
        Me.MenuDisStamp.Size = New System.Drawing.Size(124, 22)
        Me.MenuDisStamp.Text = "非表示"
        '
        'Timer_TimeStamp
        '
        Me.Timer_TimeStamp.Enabled = True
        Me.Timer_TimeStamp.Interval = 500
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Fuchsia
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(543, 336)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Timer_AutoFollow
        '
        Me.Timer_AutoFollow.Interval = 10
        '
        'PanelCamera
        '
        Me.PanelCamera.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelCamera.Controls.Add(Me.BtnCamera_Setting)
        Me.PanelCamera.Controls.Add(Me.BtnCamera_ZoomIn)
        Me.PanelCamera.Controls.Add(Me.BtnCamera_ZoomOut)
        Me.PanelCamera.Controls.Add(Me.ChkFlip)
        Me.PanelCamera.Controls.Add(Me.ChkRotate)
        Me.PanelCamera.Controls.Add(Me.BtnExecuteCamera)
        Me.PanelCamera.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelCamera.Location = New System.Drawing.Point(0, 336)
        Me.PanelCamera.Name = "PanelCamera"
        Me.PanelCamera.Size = New System.Drawing.Size(543, 39)
        Me.PanelCamera.TabIndex = 5
        '
        'BtnCamera_Setting
        '
        Me.BtnCamera_Setting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCamera_Setting.Enabled = False
        Me.BtnCamera_Setting.Image = CType(resources.GetObject("BtnCamera_Setting.Image"), System.Drawing.Image)
        Me.BtnCamera_Setting.Location = New System.Drawing.Point(245, 5)
        Me.BtnCamera_Setting.Name = "BtnCamera_Setting"
        Me.BtnCamera_Setting.Size = New System.Drawing.Size(34, 31)
        Me.BtnCamera_Setting.TabIndex = 22
        Me.BtnCamera_Setting.UseVisualStyleBackColor = True
        '
        'ChkFlip
        '
        Me.ChkFlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkFlip.AutoSize = True
        Me.ChkFlip.Enabled = False
        Me.ChkFlip.ForeColor = System.Drawing.Color.White
        Me.ChkFlip.Location = New System.Drawing.Point(449, 11)
        Me.ChkFlip.Name = "ChkFlip"
        Me.ChkFlip.Size = New System.Drawing.Size(48, 16)
        Me.ChkFlip.TabIndex = 19
        Me.ChkFlip.Text = "反転"
        Me.ChkFlip.UseVisualStyleBackColor = True
        '
        'ChkRotate
        '
        Me.ChkRotate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkRotate.AutoSize = True
        Me.ChkRotate.Enabled = False
        Me.ChkRotate.ForeColor = System.Drawing.Color.White
        Me.ChkRotate.Location = New System.Drawing.Point(365, 11)
        Me.ChkRotate.Name = "ChkRotate"
        Me.ChkRotate.Size = New System.Drawing.Size(78, 16)
        Me.ChkRotate.TabIndex = 19
        Me.ChkRotate.Text = "180度回転"
        Me.ChkRotate.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(543, 412)
        Me.Controls.Add(Me.LblimeStamp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelCamera)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmMain"
        Me.Text = "DeskShot"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelButton.ResumeLayout(False)
        Me.ConMenuMain.ResumeLayout(False)
        Me.ConMenuFit.ResumeLayout(False)
        Me.ConMenuScaleMode.ResumeLayout(False)
        Me.ConMenuFit2.ResumeLayout(False)
        Me.ConMenuTimeStamp.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCamera.ResumeLayout(False)
        Me.PanelCamera.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnWindowSmall As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConMenuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuAPPEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_VideoSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_VideoAsSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureSave_BMP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureSave_JPEG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureSave_PNG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureAsSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureClipbord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExecute As System.Windows.Forms.Button
    Friend WithEvents MenuPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOpenFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuVideoEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents BtnDialog As System.Windows.Forms.Button
    Friend WithEvents BtnDesktop As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuSetting_ViewScale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSetting_Resize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSetting_Setting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuMouseShotCaptuer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAutoSmall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShotTimer5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GcBalloonTip1 As GrapeCity.Win.Components.GcBalloonTip
    Friend WithEvents BtnFitSize As System.Windows.Forms.Button
    Friend WithEvents MenuPosition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPosition_Top As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPosition_Bottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFormPosition_Regist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuFormPosition_View As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFormPosition_Close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFormPosition_Clear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConMenuFit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuShift0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConMenuScaleMode As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuScale0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuScale1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuScale3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuScale4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuScaleEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConMenuFit2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuShift20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShift23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMoveLast As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuMode_PicturePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GcGlobalHook1 As GrapeCity.Win.Components.GcGlobalHook
    Friend WithEvents MenuSetting_KeyHook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_Onigiri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnSelectAria As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuWork_WindowSmall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuWork_WindowFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuWork_WindowOpenner As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuWork_DialogFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuWork_AllScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblimeStamp As System.Windows.Forms.Label
    Friend WithEvents Timer_TimeStamp As System.Windows.Forms.Timer
    Friend WithEvents ConMenuTimeStamp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuTimeStampPosi0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuTimeStampPosi1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeStampPosi2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeStampPosi3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTimeStampPosi4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuDisStamp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMode_PictureWordpad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCompress As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPlayGIF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuHelpText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuDirectOnigiri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuPicture As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_AutoFollow As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuFormPosition_AutoFollow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAutoFollow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuBarcode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnExecuteCamera As System.Windows.Forms.Button
    Friend WithEvents PanelCamera As System.Windows.Forms.Panel
    Friend WithEvents MenuInputMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuInput_Screen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuInput_Camera As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkFlip As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRotate As System.Windows.Forms.CheckBox
    Friend WithEvents PanelButton As System.Windows.Forms.Panel
    Friend WithEvents BtnCamera_ZoomOut As System.Windows.Forms.Button
    Friend WithEvents BtnCamera_ZoomIn As System.Windows.Forms.Button
    Friend WithEvents MenuMode_OnigiriSet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnCamera_Setting As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuOriginalSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuShirtcat As System.Windows.Forms.ToolStripMenuItem

End Class
