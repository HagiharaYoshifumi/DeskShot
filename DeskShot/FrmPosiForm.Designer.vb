<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPosiForm
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_MoveForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CopyForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_DeleteForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_MoveForm, Me.Menu_CopyForm, Me.ToolStripSeparator1, Me.Menu_DeleteForm, Me.ToolStripSeparator2, Me.MenuCancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 126)
        '
        'Menu_MoveForm
        '
        Me.Menu_MoveForm.Name = "Menu_MoveForm"
        Me.Menu_MoveForm.Size = New System.Drawing.Size(184, 22)
        Me.Menu_MoveForm.Text = "ここに移動"
        '
        'Menu_CopyForm
        '
        Me.Menu_CopyForm.Name = "Menu_CopyForm"
        Me.Menu_CopyForm.Size = New System.Drawing.Size(184, 22)
        Me.Menu_CopyForm.Text = "コピー"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        'Menu_DeleteForm
        '
        Me.Menu_DeleteForm.Name = "Menu_DeleteForm"
        Me.Menu_DeleteForm.Size = New System.Drawing.Size(184, 22)
        Me.Menu_DeleteForm.Text = "この位置を削除する"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'MenuCancel
        '
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(184, 22)
        Me.MenuCancel.Text = "キャンセル"
        '
        'FrmPosiForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPosiForm"
        Me.Opacity = 0.7R
        Me.ShowInTaskbar = False
        Me.Text = "FrmPosiForm"
        Me.TopMost = True
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_MoveForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_DeleteForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_CopyForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
