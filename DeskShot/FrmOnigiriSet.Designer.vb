<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnigiriSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOnigiriSet))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuDelTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelTab_SelOne = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDelTab_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuTopMost = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStartSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuBackOnigiri = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBackOnigiri_SelOne = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBackOnigiri_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOutPic_SelOne = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOutPic_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendClip = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendClip_SelOne = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendClip_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendWordpad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendWordpad_SelOne = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSendWordpad_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(424, 299)
        Me.TabControl1.TabIndex = 0
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuDelTab, Me.ToolStripSeparator1, Me.MenuTopMost, Me.MenuStartSize})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(173, 76)
        '
        'MenuDelTab
        '
        Me.MenuDelTab.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuDelTab_SelOne, Me.MenuDelTab_All})
        Me.MenuDelTab.Name = "MenuDelTab"
        Me.MenuDelTab.Size = New System.Drawing.Size(172, 22)
        Me.MenuDelTab.Text = "タブ削除"
        '
        'MenuDelTab_SelOne
        '
        Me.MenuDelTab_SelOne.Name = "MenuDelTab_SelOne"
        Me.MenuDelTab_SelOne.Size = New System.Drawing.Size(136, 22)
        Me.MenuDelTab_SelOne.Text = "選択タブ"
        '
        'MenuDelTab_All
        '
        Me.MenuDelTab_All.Name = "MenuDelTab_All"
        Me.MenuDelTab_All.Size = New System.Drawing.Size(136, 22)
        Me.MenuDelTab_All.Text = "全てのタブ"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(169, 6)
        '
        'MenuTopMost
        '
        Me.MenuTopMost.Name = "MenuTopMost"
        Me.MenuTopMost.Size = New System.Drawing.Size(172, 22)
        Me.MenuTopMost.Text = "前面表示"
        '
        'MenuStartSize
        '
        Me.MenuStartSize.Name = "MenuStartSize"
        Me.MenuStartSize.Size = New System.Drawing.Size(172, 22)
        Me.MenuStartSize.Text = "起動サイズに戻す"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(416, 273)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "おにぎり1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(410, 267)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuBackOnigiri, Me.ToolStripMenuItem1, Me.MenuSendClip, Me.MenuSendWordpad})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 124)
        '
        'MenuBackOnigiri
        '
        Me.MenuBackOnigiri.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuBackOnigiri_SelOne, Me.MenuBackOnigiri_All})
        Me.MenuBackOnigiri.Image = CType(resources.GetObject("MenuBackOnigiri.Image"), System.Drawing.Image)
        Me.MenuBackOnigiri.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuBackOnigiri.Name = "MenuBackOnigiri"
        Me.MenuBackOnigiri.Size = New System.Drawing.Size(204, 30)
        Me.MenuBackOnigiri.Text = "おにぎりに出力"
        '
        'MenuBackOnigiri_SelOne
        '
        Me.MenuBackOnigiri_SelOne.Image = CType(resources.GetObject("MenuBackOnigiri_SelOne.Image"), System.Drawing.Image)
        Me.MenuBackOnigiri_SelOne.Name = "MenuBackOnigiri_SelOne"
        Me.MenuBackOnigiri_SelOne.Size = New System.Drawing.Size(172, 22)
        Me.MenuBackOnigiri_SelOne.Text = "選択おにぎりのみ"
        '
        'MenuBackOnigiri_All
        '
        Me.MenuBackOnigiri_All.Image = CType(resources.GetObject("MenuBackOnigiri_All.Image"), System.Drawing.Image)
        Me.MenuBackOnigiri_All.Name = "MenuBackOnigiri_All"
        Me.MenuBackOnigiri_All.Size = New System.Drawing.Size(172, 22)
        Me.MenuBackOnigiri_All.Text = "全てのおにぎり"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOutPic_SelOne, Me.MenuOutPic_All})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(204, 30)
        Me.ToolStripMenuItem1.Text = "ファイルに保存"
        '
        'MenuOutPic_SelOne
        '
        Me.MenuOutPic_SelOne.Image = CType(resources.GetObject("MenuOutPic_SelOne.Image"), System.Drawing.Image)
        Me.MenuOutPic_SelOne.Name = "MenuOutPic_SelOne"
        Me.MenuOutPic_SelOne.Size = New System.Drawing.Size(172, 22)
        Me.MenuOutPic_SelOne.Text = "選択おにぎりのみ"
        '
        'MenuOutPic_All
        '
        Me.MenuOutPic_All.Image = CType(resources.GetObject("MenuOutPic_All.Image"), System.Drawing.Image)
        Me.MenuOutPic_All.Name = "MenuOutPic_All"
        Me.MenuOutPic_All.Size = New System.Drawing.Size(172, 22)
        Me.MenuOutPic_All.Text = "全てのおにぎり"
        '
        'MenuSendClip
        '
        Me.MenuSendClip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSendClip_SelOne, Me.MenuSendClip_All})
        Me.MenuSendClip.Image = CType(resources.GetObject("MenuSendClip.Image"), System.Drawing.Image)
        Me.MenuSendClip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSendClip.Name = "MenuSendClip"
        Me.MenuSendClip.Size = New System.Drawing.Size(204, 30)
        Me.MenuSendClip.Text = "クリップボードに送る"
        '
        'MenuSendClip_SelOne
        '
        Me.MenuSendClip_SelOne.Image = CType(resources.GetObject("MenuSendClip_SelOne.Image"), System.Drawing.Image)
        Me.MenuSendClip_SelOne.Name = "MenuSendClip_SelOne"
        Me.MenuSendClip_SelOne.Size = New System.Drawing.Size(172, 22)
        Me.MenuSendClip_SelOne.Text = "選択おにぎりのみ"
        '
        'MenuSendClip_All
        '
        Me.MenuSendClip_All.Image = CType(resources.GetObject("MenuSendClip_All.Image"), System.Drawing.Image)
        Me.MenuSendClip_All.Name = "MenuSendClip_All"
        Me.MenuSendClip_All.Size = New System.Drawing.Size(172, 22)
        Me.MenuSendClip_All.Text = "全てのおにぎり"
        '
        'MenuSendWordpad
        '
        Me.MenuSendWordpad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSendWordpad_SelOne, Me.MenuSendWordpad_All})
        Me.MenuSendWordpad.Image = CType(resources.GetObject("MenuSendWordpad.Image"), System.Drawing.Image)
        Me.MenuSendWordpad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSendWordpad.Name = "MenuSendWordpad"
        Me.MenuSendWordpad.Size = New System.Drawing.Size(204, 30)
        Me.MenuSendWordpad.Text = "ワードパッドに送る"
        '
        'MenuSendWordpad_SelOne
        '
        Me.MenuSendWordpad_SelOne.Image = CType(resources.GetObject("MenuSendWordpad_SelOne.Image"), System.Drawing.Image)
        Me.MenuSendWordpad_SelOne.Name = "MenuSendWordpad_SelOne"
        Me.MenuSendWordpad_SelOne.Size = New System.Drawing.Size(172, 22)
        Me.MenuSendWordpad_SelOne.Text = "選択おにぎりのみ"
        '
        'MenuSendWordpad_All
        '
        Me.MenuSendWordpad_All.Image = CType(resources.GetObject("MenuSendWordpad_All.Image"), System.Drawing.Image)
        Me.MenuSendWordpad_All.Name = "MenuSendWordpad_All"
        Me.MenuSendWordpad_All.Size = New System.Drawing.Size(172, 22)
        Me.MenuSendWordpad_All.Text = "全てのおにぎり"
        '
        'FrmOnigiriSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 299)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmOnigiriSet"
        Me.Text = "おにぎりセット"
        Me.TabControl1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuBackOnigiri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuDelTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuTopMost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOutPic_SelOne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOutPic_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBackOnigiri_SelOne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBackOnigiri_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelTab_SelOne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuDelTab_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendClip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendClip_SelOne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendClip_All As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendWordpad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStartSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendWordpad_SelOne As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSendWordpad_All As System.Windows.Forms.ToolStripMenuItem
End Class
