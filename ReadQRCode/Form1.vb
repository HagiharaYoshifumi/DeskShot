Imports ZXing
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.QR_CODE
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reader As ZXing.BarcodeReader = New BarcodeReader
        Dim ret As ZXing.Result = reader.Decode(PictureBox1.Image)
        If Not IsNothing(ret) Then
            Dim format As String = ret.BarcodeFormat.ToString
            Dim moji As String = ret.Text

            TextBox1.Text = format
            TextBox2.Text = moji
        End If

    End Sub
End Class
