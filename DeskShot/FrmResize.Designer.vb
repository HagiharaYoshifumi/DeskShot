<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResize
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
        Me.TxtWidth = New System.Windows.Forms.NumericUpDown()
        Me.TxtHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.TxtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtWidth
        '
        Me.TxtWidth.Location = New System.Drawing.Point(71, 11)
        Me.TxtWidth.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.TxtWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtWidth.Name = "TxtWidth"
        Me.TxtWidth.Size = New System.Drawing.Size(120, 19)
        Me.TxtWidth.TabIndex = 0
        Me.TxtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtHeight
        '
        Me.TxtHeight.Location = New System.Drawing.Point(71, 38)
        Me.TxtHeight.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.TxtHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtHeight.Name = "TxtHeight"
        Me.TxtHeight.Size = New System.Drawing.Size(120, 19)
        Me.TxtHeight.TabIndex = 1
        Me.TxtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "フォーム幅"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "フォーム高さ"
        '
        'FrmResize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(211, 71)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtHeight)
        Me.Controls.Add(Me.TxtWidth)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmResize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "サイズ調整"
        CType(Me.TxtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents TxtHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
