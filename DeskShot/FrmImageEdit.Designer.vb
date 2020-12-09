<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageEdit))
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSaveVideo = New System.Windows.Forms.ToolStripButton()
        Me.BtnResize = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnDelCell = New System.Windows.Forms.ToolStripButton()
        Me.BtnSaveCell = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnMoveUp = New System.Windows.Forms.Button()
        Me.BtnMoveDown = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnUndo = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.btnEraser = New System.Windows.Forms.RadioButton()
        Me.btnGreen = New System.Windows.Forms.RadioButton()
        Me.btnRed = New System.Windows.Forms.RadioButton()
        Me.btnBlack = New System.Windows.Forms.RadioButton()
        Me.btnBlue = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBar1
        '
        Me.TrackBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrackBar1.Location = New System.Drawing.Point(46, 0)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(663, 39)
        Me.TrackBar1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnClose, Me.ToolStripSeparator1, Me.MenuSaveVideo, Me.BtnResize, Me.ToolStripSeparator2, Me.BtnDelCell, Me.BtnSaveCell, Me.ToolStripSeparator3, Me.ToolStripSplitButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(755, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnClose
        '
        Me.BtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(36, 36)
        Me.BtnClose.Text = "閉じる"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'MenuSaveVideo
        '
        Me.MenuSaveVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MenuSaveVideo.Image = CType(resources.GetObject("MenuSaveVideo.Image"), System.Drawing.Image)
        Me.MenuSaveVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuSaveVideo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuSaveVideo.Name = "MenuSaveVideo"
        Me.MenuSaveVideo.Size = New System.Drawing.Size(36, 36)
        Me.MenuSaveVideo.Text = "動画保存"
        '
        'BtnResize
        '
        Me.BtnResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnResize.Image = CType(resources.GetObject("BtnResize.Image"), System.Drawing.Image)
        Me.BtnResize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnResize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnResize.Name = "BtnResize"
        Me.BtnResize.Size = New System.Drawing.Size(36, 36)
        Me.BtnResize.Text = "ToolStripButton6"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'BtnDelCell
        '
        Me.BtnDelCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDelCell.Image = CType(resources.GetObject("BtnDelCell.Image"), System.Drawing.Image)
        Me.BtnDelCell.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnDelCell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDelCell.Name = "BtnDelCell"
        Me.BtnDelCell.Size = New System.Drawing.Size(36, 36)
        Me.BtnDelCell.Text = "選択セル削除"
        '
        'BtnSaveCell
        '
        Me.BtnSaveCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSaveCell.Image = CType(resources.GetObject("BtnSaveCell.Image"), System.Drawing.Image)
        Me.BtnSaveCell.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSaveCell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSaveCell.Name = "BtnSaveCell"
        Me.BtnSaveCell.Size = New System.Drawing.Size(36, 36)
        Me.BtnSaveCell.Text = "セル画像保存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(48, 36)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(196, 22)
        Me.ToolStripMenuItem1.Text = "このセルのみリセット"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(196, 22)
        Me.ToolStripMenuItem2.Text = "全てのセルをリセット"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 537)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(755, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TrackBar1)
        Me.Panel1.Controls.Add(Me.BtnMoveUp)
        Me.Panel1.Controls.Add(Me.BtnMoveDown)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 498)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 39)
        Me.Panel1.TabIndex = 5
        '
        'BtnMoveUp
        '
        Me.BtnMoveUp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnMoveUp.Image = CType(resources.GetObject("BtnMoveUp.Image"), System.Drawing.Image)
        Me.BtnMoveUp.Location = New System.Drawing.Point(709, 0)
        Me.BtnMoveUp.Name = "BtnMoveUp"
        Me.BtnMoveUp.Size = New System.Drawing.Size(46, 39)
        Me.BtnMoveUp.TabIndex = 0
        Me.BtnMoveUp.UseVisualStyleBackColor = True
        '
        'BtnMoveDown
        '
        Me.BtnMoveDown.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMoveDown.Image = CType(resources.GetObject("BtnMoveDown.Image"), System.Drawing.Image)
        Me.BtnMoveDown.Location = New System.Drawing.Point(0, 0)
        Me.BtnMoveDown.Name = "BtnMoveDown"
        Me.BtnMoveDown.Size = New System.Drawing.Size(46, 39)
        Me.BtnMoveDown.TabIndex = 0
        Me.BtnMoveDown.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BtnUndo)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate)
        Me.GroupBox1.Controls.Add(Me.btnEraser)
        Me.GroupBox1.Controls.Add(Me.btnGreen)
        Me.GroupBox1.Controls.Add(Me.btnRed)
        Me.GroupBox1.Controls.Add(Me.btnBlack)
        Me.GroupBox1.Controls.Add(Me.btnBlue)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(698, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(57, 459)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ペン色"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 322)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnUndo
        '
        Me.BtnUndo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUndo.Enabled = False
        Me.BtnUndo.Image = CType(resources.GetObject("BtnUndo.Image"), System.Drawing.Image)
        Me.BtnUndo.Location = New System.Drawing.Point(6, 358)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.Size = New System.Drawing.Size(47, 43)
        Me.BtnUndo.TabIndex = 5
        Me.BtnUndo.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate.Image = CType(resources.GetObject("BtnUpdate.Image"), System.Drawing.Image)
        Me.BtnUpdate.Location = New System.Drawing.Point(6, 407)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(47, 43)
        Me.BtnUpdate.TabIndex = 5
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'btnEraser
        '
        Me.btnEraser.AutoSize = True
        Me.btnEraser.Location = New System.Drawing.Point(9, 114)
        Me.btnEraser.Name = "btnEraser"
        Me.btnEraser.Size = New System.Drawing.Size(35, 16)
        Me.btnEraser.TabIndex = 4
        Me.btnEraser.Text = "白"
        Me.btnEraser.UseVisualStyleBackColor = True
        '
        'btnGreen
        '
        Me.btnGreen.AutoSize = True
        Me.btnGreen.Location = New System.Drawing.Point(9, 90)
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.Size = New System.Drawing.Size(35, 16)
        Me.btnGreen.TabIndex = 3
        Me.btnGreen.Text = "緑"
        Me.btnGreen.UseVisualStyleBackColor = True
        '
        'btnRed
        '
        Me.btnRed.AutoSize = True
        Me.btnRed.Location = New System.Drawing.Point(9, 66)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(35, 16)
        Me.btnRed.TabIndex = 2
        Me.btnRed.Text = "赤"
        Me.btnRed.UseVisualStyleBackColor = True
        '
        'btnBlack
        '
        Me.btnBlack.AutoSize = True
        Me.btnBlack.Location = New System.Drawing.Point(9, 42)
        Me.btnBlack.Name = "btnBlack"
        Me.btnBlack.Size = New System.Drawing.Size(35, 16)
        Me.btnBlack.TabIndex = 1
        Me.btnBlack.Text = "黒"
        Me.btnBlack.UseVisualStyleBackColor = True
        '
        'btnBlue
        '
        Me.btnBlue.AutoSize = True
        Me.btnBlue.Checked = True
        Me.btnBlue.Location = New System.Drawing.Point(9, 18)
        Me.btnBlue.Name = "btnBlue"
        Me.btnBlue.Size = New System.Drawing.Size(35, 16)
        Me.btnBlue.TabIndex = 0
        Me.btnBlue.TabStop = True
        Me.btnBlue.Text = "青"
        Me.btnBlue.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(698, 459)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Location = New System.Drawing.Point(441, 327)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(179, 64)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmImageEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 559)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmImageEdit"
        Me.Text = "画像編集"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BtnDelCell As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSaveCell As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnMoveUp As System.Windows.Forms.Button
    Friend WithEvents BtnMoveDown As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuSaveVideo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnResize As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEraser As System.Windows.Forms.RadioButton
    Friend WithEvents btnGreen As System.Windows.Forms.RadioButton
    Friend WithEvents btnRed As System.Windows.Forms.RadioButton
    Friend WithEvents btnBlack As System.Windows.Forms.RadioButton
    Friend WithEvents btnBlue As System.Windows.Forms.RadioButton
    Friend WithEvents BtnUndo As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
