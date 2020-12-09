<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnigiriSUB
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
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSelectFont = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.ChkUseBack = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtColorBack = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton2 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton2 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.TxtOnigiriBack_Bottom = New System.Windows.Forms.NumericUpDown()
        Me.TxtOnigiriBack_Right = New System.Windows.Forms.NumericUpDown()
        Me.TxtOnigiriBack_Left = New System.Windows.Forms.NumericUpDown()
        Me.TxtOnigiriBack_Top = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtColorFore = New GrapeCity.Win.Pickers.GcColorPicker()
        Me.DropDownButton1 = New GrapeCity.Win.Common.DropDownButton()
        Me.ColorPickerButton1 = New GrapeCity.Win.Common.ColorPickerButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCount = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TxtColorBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOnigiriBack_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOnigiriBack_Right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOnigiriBack_Left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOnigiriBack_Top, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtColorFore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Location = New System.Drawing.Point(204, 269)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(299, 269)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "キャンセル(&C)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(376, 51)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(379, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "."
        Me.Label1.Visible = False
        '
        'BtnSelectFont
        '
        Me.BtnSelectFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSelectFont.Location = New System.Drawing.Point(277, 164)
        Me.BtnSelectFont.Name = "BtnSelectFont"
        Me.BtnSelectFont.Size = New System.Drawing.Size(89, 26)
        Me.BtnSelectFont.TabIndex = 4
        Me.BtnSelectFont.Text = "フォント"
        Me.BtnSelectFont.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox10)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 89)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "サンプル表示"
        '
        'PictureBox10
        '
        Me.PictureBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox10.Location = New System.Drawing.Point(3, 15)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(370, 71)
        Me.PictureBox10.TabIndex = 9
        Me.PictureBox10.TabStop = False
        '
        'ChkUseBack
        '
        Me.ChkUseBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkUseBack.AutoSize = True
        Me.ChkUseBack.Location = New System.Drawing.Point(24, 193)
        Me.ChkUseBack.Name = "ChkUseBack"
        Me.ChkUseBack.Size = New System.Drawing.Size(148, 16)
        Me.ChkUseBack.TabIndex = 6
        Me.ChkUseBack.Text = "塗りつぶし背景を使用する"
        Me.ChkUseBack.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.TxtColorBack)
        Me.GroupBox2.Controls.Add(Me.TxtOnigiriBack_Bottom)
        Me.GroupBox2.Controls.Add(Me.TxtOnigiriBack_Right)
        Me.GroupBox2.Controls.Add(Me.TxtOnigiriBack_Left)
        Me.GroupBox2.Controls.Add(Me.TxtOnigiriBack_Top)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(18, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 70)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "背景色"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(257, 20)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 12)
        Me.Label33.TabIndex = 15
        Me.Label33.Text = "右余白"
        '
        'TxtColorBack
        '
        Me.TxtColorBack.AutoSize = True
        Me.TxtColorBack.Location = New System.Drawing.Point(6, 42)
        Me.TxtColorBack.Name = "TxtColorBack"
        Me.TxtColorBack.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton2, Me.ColorPickerButton2})
        Me.TxtColorBack.Size = New System.Drawing.Size(137, 20)
        Me.TxtColorBack.TabIndex = 9
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'ColorPickerButton2
        '
        Me.ColorPickerButton2.Name = "ColorPickerButton2"
        Me.ColorPickerButton2.UseVisualStyleBackColor = True
        '
        'TxtOnigiriBack_Bottom
        '
        Me.TxtOnigiriBack_Bottom.Location = New System.Drawing.Point(304, 43)
        Me.TxtOnigiriBack_Bottom.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TxtOnigiriBack_Bottom.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.TxtOnigiriBack_Bottom.Name = "TxtOnigiriBack_Bottom"
        Me.TxtOnigiriBack_Bottom.Size = New System.Drawing.Size(55, 19)
        Me.TxtOnigiriBack_Bottom.TabIndex = 14
        '
        'TxtOnigiriBack_Right
        '
        Me.TxtOnigiriBack_Right.Location = New System.Drawing.Point(304, 18)
        Me.TxtOnigiriBack_Right.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TxtOnigiriBack_Right.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.TxtOnigiriBack_Right.Name = "TxtOnigiriBack_Right"
        Me.TxtOnigiriBack_Right.Size = New System.Drawing.Size(55, 19)
        Me.TxtOnigiriBack_Right.TabIndex = 10
        '
        'TxtOnigiriBack_Left
        '
        Me.TxtOnigiriBack_Left.Location = New System.Drawing.Point(197, 18)
        Me.TxtOnigiriBack_Left.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TxtOnigiriBack_Left.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.TxtOnigiriBack_Left.Name = "TxtOnigiriBack_Left"
        Me.TxtOnigiriBack_Left.Size = New System.Drawing.Size(55, 19)
        Me.TxtOnigiriBack_Left.TabIndex = 9
        '
        'TxtOnigiriBack_Top
        '
        Me.TxtOnigiriBack_Top.Location = New System.Drawing.Point(197, 43)
        Me.TxtOnigiriBack_Top.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TxtOnigiriBack_Top.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.TxtOnigiriBack_Top.Name = "TxtOnigiriBack_Top"
        Me.TxtOnigiriBack_Top.Size = New System.Drawing.Size(55, 19)
        Me.TxtOnigiriBack_Top.TabIndex = 12
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(257, 45)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(41, 12)
        Me.Label35.TabIndex = 13
        Me.Label35.Text = "下余白"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(149, 45)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 12)
        Me.Label34.TabIndex = 11
        Me.Label34.Text = "上余白"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(149, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 12)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "左余白"
        '
        'TxtColorFore
        '
        Me.TxtColorFore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtColorFore.AutoSize = True
        Me.TxtColorFore.Location = New System.Drawing.Point(62, 167)
        Me.TxtColorFore.Name = "TxtColorFore"
        Me.TxtColorFore.SideButtons.AddRange(New GrapeCity.Win.Common.SideButtonBase() {Me.DropDownButton1, Me.ColorPickerButton1})
        Me.TxtColorFore.Size = New System.Drawing.Size(146, 20)
        Me.TxtColorFore.TabIndex = 9
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'ColorPickerButton1
        '
        Me.ColorPickerButton1.Name = "ColorPickerButton1"
        Me.ColorPickerButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "文字色"
        '
        'TxtCount
        '
        Me.TxtCount.Location = New System.Drawing.Point(41, 274)
        Me.TxtCount.Name = "TxtCount"
        Me.TxtCount.Size = New System.Drawing.Size(73, 19)
        Me.TxtCount.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "連番"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(123, 269)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 26)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "連番"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmOnigiriSUB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(397, 300)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtColorFore)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkUseBack)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnSelectFont)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOnigiriSUB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "文字の描写"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TxtColorBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOnigiriBack_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOnigiriBack_Right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOnigiriBack_Left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOnigiriBack_Top, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtColorFore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSelectFont As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkUseBack As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOnigiriBack_Bottom As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtOnigiriBack_Right As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtOnigiriBack_Left As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtOnigiriBack_Top As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtColorFore As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton1 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtColorBack As GrapeCity.Win.Pickers.GcColorPicker
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Common.DropDownButton
    Friend WithEvents ColorPickerButton2 As GrapeCity.Win.Common.ColorPickerButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
