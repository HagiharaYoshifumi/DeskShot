Public Class FrmImageResize
    Dim BB As Bitmap
    ReadOnly Property UserSize As Size
        Get
            Return PictureBox1.ClientSize
        End Get
    End Property
    WriteOnly Property SampleImage As Bitmap
        Set(value As Bitmap)
            BB = value
        End Set
    End Property
    Private Sub FrmImageResize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmImageResize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = BB
    End Sub
End Class