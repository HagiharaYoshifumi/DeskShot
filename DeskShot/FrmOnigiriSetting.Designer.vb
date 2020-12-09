<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnigiriSetting
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
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtArrowHead = New System.Windows.Forms.NumericUpDown()
        Me.TxtPenSize = New System.Windows.Forms.NumericUpDown()
        Me.BtbCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        CType(Me.TxtArrowHead, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPenSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 41)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 12)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "描写矢頭"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 12)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "描写ペン幅"
        '
        'TxtArrowHead
        '
        Me.TxtArrowHead.Location = New System.Drawing.Point(78, 39)
        Me.TxtArrowHead.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.TxtArrowHead.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.TxtArrowHead.Name = "TxtArrowHead"
        Me.TxtArrowHead.Size = New System.Drawing.Size(55, 19)
        Me.TxtArrowHead.TabIndex = 3
        Me.TxtArrowHead.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'TxtPenSize
        '
        Me.TxtPenSize.Location = New System.Drawing.Point(78, 12)
        Me.TxtPenSize.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.TxtPenSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtPenSize.Name = "TxtPenSize"
        Me.TxtPenSize.Size = New System.Drawing.Size(55, 19)
        Me.TxtPenSize.TabIndex = 1
        Me.TxtPenSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BtbCancel
        '
        Me.BtbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtbCancel.Location = New System.Drawing.Point(139, 39)
        Me.BtbCancel.Name = "BtbCancel"
        Me.BtbCancel.Size = New System.Drawing.Size(89, 26)
        Me.BtbCancel.TabIndex = 5
        Me.BtbCancel.Text = "キャンセル(&C)"
        Me.BtbCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(139, 7)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(89, 26)
        Me.BtnOK.TabIndex = 4
        Me.BtnOK.Text = "OK(&O)"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'FrmOnigiriSetting
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtbCancel
        Me.ClientSize = New System.Drawing.Size(239, 70)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtArrowHead)
        Me.Controls.Add(Me.TxtPenSize)
        Me.Controls.Add(Me.BtbCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOnigiriSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "描写ペン設定"
        CType(Me.TxtArrowHead, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPenSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtArrowHead As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtPenSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtbCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
End Class
