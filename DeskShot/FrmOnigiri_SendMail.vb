Public Class FrmOnigiri_SendMail

    Property ToAddress As String
    Property SendNote As String
    ''' <summary>
    ''' OKボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If TxtToAddress.Text = "" Then
            MsgBox("送信先メールアドレスが未指定です。", 48, "エラー")
            Return
        End If

        ToAddress = TxtToAddress.Text
        SendNote = TxtNote.Text

        Call AddAddress()
        If TxtToAddress.Items.Count = 0 Then
            Call WriteReg("Mail", "ToAddress", "")
        Else
            Dim _T As New ArrayList
            For Each AD As String In TxtToAddress.Items
                _T.Add(AD)
            Next
            Dim Values() As String = DirectCast(_T.ToArray(GetType(String)), String()) 'ArrayListの要素の型に応じて引数を変える。
            Dim Val As String = String.Join("|", Values)
            Call WriteReg("Mail", "ToAddress", Val)
        End If
        Call WriteReg("Mail", "Note", TxtNote.Text)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmOnigiri_SendMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmOnigiri_SendMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _ToAddress As String = ReadReg("Mail", "ToAddress")
        If _ToAddress <> "" Then
            Dim AddressArray() As String = Split(_ToAddress, "|")
            If AddressArray.Length > 0 Then
                For Each AD As String In AddressArray
                    TxtToAddress.Items.Add(AD)
                Next
            End If
            If TxtToAddress.Items.Count > 0 Then
                TxtToAddress.SelectedIndex = 0
            End If
        End If
        TxtNote.Text = ReadReg("Mail", "Note")
    End Sub
    ''' <summary>
    ''' 入力されたアドレスがあるかを確認する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddAddress()
        If TxtToAddress.Text <> "" Then
            If TxtToAddress.Items.Count = 0 Then
                TxtToAddress.Items.Add(TxtToAddress.Text)
            Else
                Dim FLG As Boolean = False
                For i As Integer = 0 To TxtToAddress.Items.Count - 1
                    Dim _T As String = TxtToAddress.Items(i)
                    If _T.ToUpper = TxtToAddress.Text.ToUpper Then
                        FLG = True
                        Exit For
                    End If
                Next
                If Not FLG Then
                    'TxtToAddress.Items.Add(TxtToAddress.Text)
                    TxtToAddress.Items.Insert(0, TxtToAddress.Text)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 選択アドレス削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelAddress_Click(sender As Object, e As EventArgs) Handles BtnDelAddress.Click
        If MsgBox("選択宛先を削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If TxtToAddress.Items.Count > 0 Then
                Dim FLG As Integer = -1
                For i As Integer = 0 To TxtToAddress.Items.Count - 1
                    Dim _T As String = TxtToAddress.Items(i)
                    If _T.ToUpper = TxtToAddress.Text.ToUpper Then
                        FLG = i
                        Exit For
                    End If
                Next
                If FLG > -1 Then
                    TxtToAddress.Items.RemoveAt(FLG)
                End If
            End If
        End If
    End Sub
End Class