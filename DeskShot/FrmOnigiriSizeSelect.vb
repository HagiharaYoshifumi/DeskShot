Public Class FrmOnigiriSizeSelect

    Dim _SelectMode As Integer = -1
    Public Property IsOnigiriSet As Boolean = False

    Public Property SelectMode As Integer
        Get
            Return _SelectMode
        End Get
        Set(value As Integer)
            _SelectMode = value
        End Set
    End Property
    
    Private Sub FrmOnigiriSizeSelect_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        _SelectMode = -1
        Me.Close()
    End Sub

    Private Sub BtnOK_WordPad_Click(sender As Object, e As EventArgs) Handles BtnOK_WordPad.Click
        _SelectMode = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnOK_Clipbord_Click(sender As Object, e As EventArgs) Handles BtnOK_Clipbord.Click
        _SelectMode = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnOK_BMP_Click(sender As Object, e As EventArgs) Handles BtnOK_BMP.Click
        _SelectMode = 3
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnOK_JPEG_Click(sender As Object, e As EventArgs) Handles BtnOK_JPEG.Click
        _SelectMode = 4
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnOK_PNG_Click(sender As Object, e As EventArgs) Handles BtnOK_PNG.Click
        _SelectMode = 5
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnOK_Onigiri_Click(sender As Object, e As EventArgs) Handles BtnOK_Onigiri.Click
        _SelectMode = 0
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub FrmOnigiriSizeSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsOnigiriSet Then
            BtnOK_Onigiri.Text = "継続(おにぎりセット起動)"
        End If
    End Sub
End Class