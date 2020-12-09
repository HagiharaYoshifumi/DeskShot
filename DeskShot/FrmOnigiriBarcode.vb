Public Class FrmOnigiriBarcode
    Property ReadedData As String
    Property IsOCR As Boolean

    Private Sub FrmOnigiriBarcode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmOnigiriBarcode_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsOCR Then Me.Text = "OCRデータ"
        TextBox1.Text = _ReadedData
        TextBox1.SelectionStart = 1
        TextBox1.SelectionLength = 0
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Control Then
            TextBox1.SelectAll()
        End If
        If e.KeyCode = Keys.C AndAlso e.Control Then
            TextBox1.Copy()
        End If
        If e.KeyCode = Keys.V AndAlso e.Control Then
            TextBox1.Paste()
        End If
    End Sub

    Private Sub TextBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseWheel
        Try
            With TextBox1
                If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                    If e.Delta > 0 Then
                        .Font = New Font(.Font.FontFamily, .Font.Size + 1)
                    Else
                        .Font = New Font(.Font.FontFamily, .Font.Size - 1)
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class