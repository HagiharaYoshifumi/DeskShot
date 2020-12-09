Public Class FrmOnigiriSetting

    Private Sub FrmOnigiriSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmOnigiriSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetNumericValue("General", "OnigiriDrawPenSize", TxtPenSize)
        Call SetNumericValue("General", "OnigiriDrawArrowHead", TxtArrowHead)

    End Sub
    Private Sub SetNumericValue(SectionName As String, KeyName As String, TargetObj As NumericUpDown)
        Dim _Tmp As Integer = CInt(ReadReg(SectionName, KeyName, enum_Type.er_Integer))
        Call SetNumericValue(_Tmp, TargetObj)
    End Sub
    Private Sub SetNumericValue(Value As Integer, TargetObj As NumericUpDown)
        Select Case Value
            Case Is < TargetObj.Minimum
                TargetObj.Value = TargetObj.Minimum
            Case Is > TargetObj.Maximum
                TargetObj.Value = TargetObj.Maximum
            Case Else
                TargetObj.Value = Value
        End Select
    End Sub
    Private Function GetNumericValue(TargetObj As NumericUpDown) As Integer
        Select Case TargetObj.Value
            Case Is < TargetObj.Minimum
                Return TargetObj.Minimum
            Case Is > TargetObj.Maximum
                Return TargetObj.Maximum
            Case Else
                Return TargetObj.Value
        End Select
    End Function
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Call WriteReg("General", "OnigiriDrawPenSize", GetNumericValue(TxtPenSize))
        Call WriteReg("General", "OnigiriDrawArrowHead", GetNumericValue(TxtArrowHead))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtbCancel_Click(sender As Object, e As EventArgs) Handles BtbCancel.Click
        Me.Close()
    End Sub
End Class