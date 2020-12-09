Public Class FrmOnigiriSUB_Color
    Dim _SelColor As Color = Color.Red
    Property SelColor As Color
        Get
            Return _SelColor
        End Get
        Set(value As Color)
            _SelColor = value
            GcColorPicker1.SelectedColor = value
        End Set
    End Property

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _SelColor = GcColorPicker1.SelectedColor
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmOnigiriSUB_Color_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmOnigiriSUB_Color_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class