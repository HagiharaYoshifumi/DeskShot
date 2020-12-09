Module Module5
    Public OnigiriSetStat As FrmOnigiriSet = Nothing
    Public Function CreateFormID() As String
        Dim guidValue As Guid = Guid.NewGuid()
        Return guidValue.ToString
    End Function
End Module
