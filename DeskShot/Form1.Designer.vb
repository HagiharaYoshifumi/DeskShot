<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnBlue = New System.Windows.Forms.RadioButton()
        Me.btnBlack = New System.Windows.Forms.RadioButton()
        Me.btnRed = New System.Windows.Forms.RadioButton()
        Me.btnGreen = New System.Windows.Forms.RadioButton()
        Me.btnEraser = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(765, 565)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(31, 602)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(746, 45)
        Me.TrackBar1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 679)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(457, 679)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnBlue
        '
        Me.btnBlue.AutoSize = True
        Me.btnBlue.Checked = True
        Me.btnBlue.Location = New System.Drawing.Point(809, 25)
        Me.btnBlue.Name = "btnBlue"
        Me.btnBlue.Size = New System.Drawing.Size(62, 16)
        Me.btnBlue.TabIndex = 4
        Me.btnBlue.TabStop = True
        Me.btnBlue.Text = "btnBlue"
        Me.btnBlue.UseVisualStyleBackColor = True
        '
        'btnBlack
        '
        Me.btnBlack.AutoSize = True
        Me.btnBlack.Location = New System.Drawing.Point(809, 58)
        Me.btnBlack.Name = "btnBlack"
        Me.btnBlack.Size = New System.Drawing.Size(92, 16)
        Me.btnBlack.TabIndex = 5
        Me.btnBlack.Text = "RadioButton2"
        Me.btnBlack.UseVisualStyleBackColor = True
        '
        'btnRed
        '
        Me.btnRed.AutoSize = True
        Me.btnRed.Location = New System.Drawing.Point(809, 97)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(92, 16)
        Me.btnRed.TabIndex = 6
        Me.btnRed.Text = "RadioButton3"
        Me.btnRed.UseVisualStyleBackColor = True
        '
        'btnGreen
        '
        Me.btnGreen.AutoSize = True
        Me.btnGreen.Location = New System.Drawing.Point(809, 145)
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.Size = New System.Drawing.Size(69, 16)
        Me.btnGreen.TabIndex = 7
        Me.btnGreen.Text = "btnGreen"
        Me.btnGreen.UseVisualStyleBackColor = True
        '
        'btnEraser
        '
        Me.btnEraser.AutoSize = True
        Me.btnEraser.Location = New System.Drawing.Point(809, 186)
        Me.btnEraser.Name = "btnEraser"
        Me.btnEraser.Size = New System.Drawing.Size(92, 16)
        Me.btnEraser.TabIndex = 8
        Me.btnEraser.Text = "RadioButton5"
        Me.btnEraser.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(837, 270)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "UNDO"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(837, 333)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(703, 679)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(196, 23)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Image Update"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 714)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnEraser)
        Me.Controls.Add(Me.btnGreen)
        Me.Controls.Add(Me.btnRed)
        Me.Controls.Add(Me.btnBlack)
        Me.Controls.Add(Me.btnBlue)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnBlue As System.Windows.Forms.RadioButton
    Friend WithEvents btnBlack As System.Windows.Forms.RadioButton
    Friend WithEvents btnRed As System.Windows.Forms.RadioButton
    Friend WithEvents btnGreen As System.Windows.Forms.RadioButton
    Friend WithEvents btnEraser As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
