Module ModuleErrorStack
    Public Function GetStack(exd As Exception) As StackDataCollection
        Dim lineNumber As Integer = 0
        Dim _LocalStacData As New StackDataCollection
        Try
            Dim stackTrace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(exd, True)
            _LocalStacData.Message = exd.Message
            If stackTrace.GetFrames.Count > 0 Then
                _LocalStacData.ClassName = stackTrace.GetFrame(0).GetMethod.DeclaringType.Name.ToString
                _LocalStacData.MetodName = stackTrace.GetFrame(0).GetMethod.Name.ToString
                _LocalStacData.LineNo = stackTrace.GetFrame(0).GetFileLineNumber()
            End If

            'Dim StFrame As New StackFrame(1)
            'aaa.Message = exd.Message
            'aaa.ClassName = StFrame.GetMethod.DeclaringType.Name.ToString
            'aaa.MetodName = StFrame.GetMethod.Name.ToString
            'aaa.LineNo = lineNumber
        Catch ex As Exception
        End Try

        Return _LocalStacData
    End Function
    Public Function ExMessCreater(ST As StackDataCollection) As String
        If IsNothing(ST) Then
            Return (ST.Message)
        Else
            Return (ST.Message & vbCrLf & String.Format("Location:[{0}]-[{1}](Line:{2})", ST.ClassName, ST.MetodName, ST.LineNo))
        End If
    End Function
End Module
Public Class StackDataCollection
    Public Message As String
    Public ClassName As String
    Public MetodName As String
    Public LineNo As Integer
End Class
