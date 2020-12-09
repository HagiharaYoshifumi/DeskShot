Module ModuleBarcode
    ''' <summary>
    ''' イメージからバーコードを読み込む
    ''' </summary>
    ''' <param name="ParetForm"></param>
    ''' <param name="Img"></param>
    ''' <remarks></remarks>
    ''' https://www.atmarkit.co.jp/ait/articles/1803/14/news020.html
    ''' https://github.com/micjahn/ZXing.Net
    Public Function ReadBarcode(ParetForm As Form, Img As Image) As Boolean
        Try
            Dim reader As ZXing.BarcodeReader = New ZXing.BarcodeReader
            reader.Options.CharacterSet = "Shift_JIS"

            Dim ret As ZXing.Result = reader.Decode(Img)

            If Not IsNothing(ret) Then
                Dim format As String = ret.BarcodeFormat.ToString
                Dim moji As String = ret.Text

                With FrmOnigiriBarcode
                    .ReadedData = moji
                    If .ShowDialog(ParetForm) = Windows.Forms.DialogResult.OK Then

                    End If
                End With
                Return True
            Else
                MsgBox("バーコードを認識出来ませんでした。" & vbCrLf & "(読み取りバーコードを大きくすると読める場合があります)", 64, "情報")
                Return False
            End If

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "バーコー読み取りエラー")
            Return False
        End Try
    End Function
End Module
