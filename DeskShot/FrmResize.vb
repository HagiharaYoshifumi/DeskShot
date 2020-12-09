Public Class FrmResize
    Dim _Width As Integer = 0
    Dim _Height As Integer = 0
    Dim _StartFlg As Boolean = False
    Property FormWidth As Integer
        Get
            Return _Width
        End Get
        Set(value As Integer)
            _Width = value
            TxtWidth.Value = value
        End Set
    End Property
    Property FormHeight As Integer
        Get
            Return _Height
        End Get
        Set(value As Integer)
            _Height = value
            TxtHeight.Value = value
        End Set
    End Property

    Private Sub FrmResize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmResize_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtWidth_ValueChanged(sender As Object, e As EventArgs) Handles TxtWidth.ValueChanged, TxtHeight.ValueChanged
        If _StartFlg Then
            FrmMain.Size = New Size(TxtWidth.Value, TxtHeight.Value + FrmMain.Panel1.Height)
        End If
    End Sub
    Private Sub FrmResize_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _StartFlg = True
    End Sub
End Class