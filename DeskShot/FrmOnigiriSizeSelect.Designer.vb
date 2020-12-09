<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnigiriSizeSelect
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
        Me.BtnOK_WordPad = New System.Windows.Forms.Button()
        Me.BtnOK_Clipbord = New System.Windows.Forms.Button()
        Me.BtnOK_BMP = New System.Windows.Forms.Button()
        Me.BtnOK_JPEG = New System.Windows.Forms.Button()
        Me.BtnOK_PNG = New System.Windows.Forms.Button()
        Me.BtnOK_Onigiri = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnOK_WordPad
        '
        Me.BtnOK_WordPad.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOK_WordPad.Image = Global.DeskShot.My.Resources.Resources.Wordpad_icon
        Me.BtnOK_WordPad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_WordPad.Location = New System.Drawing.Point(12, 56)
        Me.BtnOK_WordPad.Name = "BtnOK_WordPad"
        Me.BtnOK_WordPad.Size = New System.Drawing.Size(152, 36)
        Me.BtnOK_WordPad.TabIndex = 0
        Me.BtnOK_WordPad.Text = "ワードパッド転送"
        Me.BtnOK_WordPad.UseVisualStyleBackColor = False
        '
        'BtnOK_Clipbord
        '
        Me.BtnOK_Clipbord.Image = Global.DeskShot.My.Resources.Resources.clipboard_sign_icon
        Me.BtnOK_Clipbord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_Clipbord.Location = New System.Drawing.Point(170, 56)
        Me.BtnOK_Clipbord.Name = "BtnOK_Clipbord"
        Me.BtnOK_Clipbord.Size = New System.Drawing.Size(152, 36)
        Me.BtnOK_Clipbord.TabIndex = 1
        Me.BtnOK_Clipbord.Text = "クリップボード"
        Me.BtnOK_Clipbord.UseVisualStyleBackColor = True
        '
        'BtnOK_BMP
        '
        Me.BtnOK_BMP.Image = Global.DeskShot.My.Resources.Resources.file_extension_bmp_icon
        Me.BtnOK_BMP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_BMP.Location = New System.Drawing.Point(12, 98)
        Me.BtnOK_BMP.Name = "BtnOK_BMP"
        Me.BtnOK_BMP.Size = New System.Drawing.Size(152, 36)
        Me.BtnOK_BMP.TabIndex = 2
        Me.BtnOK_BMP.Text = "BMP形式で保存"
        Me.BtnOK_BMP.UseVisualStyleBackColor = True
        '
        'BtnOK_JPEG
        '
        Me.BtnOK_JPEG.Image = Global.DeskShot.My.Resources.Resources.file_extension_jpg_icon
        Me.BtnOK_JPEG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_JPEG.Location = New System.Drawing.Point(170, 98)
        Me.BtnOK_JPEG.Name = "BtnOK_JPEG"
        Me.BtnOK_JPEG.Size = New System.Drawing.Size(152, 36)
        Me.BtnOK_JPEG.TabIndex = 3
        Me.BtnOK_JPEG.Text = "JPEG形式で保存"
        Me.BtnOK_JPEG.UseVisualStyleBackColor = True
        '
        'BtnOK_PNG
        '
        Me.BtnOK_PNG.Image = Global.DeskShot.My.Resources.Resources.file_extension_png_icon
        Me.BtnOK_PNG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_PNG.Location = New System.Drawing.Point(328, 98)
        Me.BtnOK_PNG.Name = "BtnOK_PNG"
        Me.BtnOK_PNG.Size = New System.Drawing.Size(152, 36)
        Me.BtnOK_PNG.TabIndex = 4
        Me.BtnOK_PNG.Text = "PNG形式で保存"
        Me.BtnOK_PNG.UseVisualStyleBackColor = True
        '
        'BtnOK_Onigiri
        '
        Me.BtnOK_Onigiri.Image = Global.DeskShot.My.Resources.Resources.Onigiri_icon
        Me.BtnOK_Onigiri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOK_Onigiri.Location = New System.Drawing.Point(12, 140)
        Me.BtnOK_Onigiri.Name = "BtnOK_Onigiri"
        Me.BtnOK_Onigiri.Size = New System.Drawing.Size(310, 36)
        Me.BtnOK_Onigiri.TabIndex = 5
        Me.BtnOK_Onigiri.Text = "継続(おにぎり起動)"
        Me.BtnOK_Onigiri.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = Global.DeskShot.My.Resources.Resources.cross
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(328, 140)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(152, 36)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "キャンセル"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(446, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "このサイズ以下になると、おにぎりモードでは正しくキャプチャー出来ない場合があります。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "一時的なモード変更を選択してください。"
        '
        'FrmOnigiriSizeSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(497, 187)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK_Onigiri)
        Me.Controls.Add(Me.BtnOK_PNG)
        Me.Controls.Add(Me.BtnOK_JPEG)
        Me.Controls.Add(Me.BtnOK_BMP)
        Me.Controls.Add(Me.BtnOK_Clipbord)
        Me.Controls.Add(Me.BtnOK_WordPad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOnigiriSizeSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "おにぎりサイズ警告"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK_WordPad As System.Windows.Forms.Button
    Friend WithEvents BtnOK_Clipbord As System.Windows.Forms.Button
    Friend WithEvents BtnOK_BMP As System.Windows.Forms.Button
    Friend WithEvents BtnOK_JPEG As System.Windows.Forms.Button
    Friend WithEvents BtnOK_PNG As System.Windows.Forms.Button
    Friend WithEvents BtnOK_Onigiri As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
