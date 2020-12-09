Module Module3
    Public _FormPosition As New List(Of ClassFormPosition)
    Public _FormPositionForm As New List(Of FrmPosiForm)
    Public _OnigiriFont As Font = Nothing


    Public Function AppFullPath(ByVal FileName As String) As String

        AppFullPath = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, FileName)

    End Function
    ''' <summary>
    ''' 一意のファイル名を生成します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateTempFileName() As String
        Dim StrAry As String = "abcdefghijklnmopqrstuvwxyz0123456789"
        Dim PasW As System.Text.StringBuilder
        PasW = New System.Text.StringBuilder
        For Count As Integer = 0 To 20
            PasW.Append(StrAry.Chars(RollDice(Len(StrAry))))
        Next

        Return PasW.ToString

    End Function
    Private Function RollDice(ByVal NumSides As Integer) As Integer
        Dim randomNumber(0) As Byte
        Dim Gen As New System.Security.Cryptography.RNGCryptoServiceProvider()
        Gen.GetBytes(randomNumber)

        Dim rand As Integer = Convert.ToInt32(randomNumber(0))
        Return rand Mod NumSides

    End Function 'RollDice
    ''' <summary>
    ''' メインフォームのあるスクリーン番号を取得する
    ''' </summary>
    ''' <param name="Frm">検証するフォーム</param>
    ''' <returns>スクリーン番号</returns>
    ''' <remarks>検証失敗時は-1を返します</remarks>
    Public Function GetScreenNo(Frm As Form) As Integer
        Dim MyX As Integer = 0, MyY As Integer = 0

        Try
            Select Case Frm.WindowState
                Case FormWindowState.Maximized
                    Frm.WindowState = FormWindowState.Normal
                    MyX = Frm.Location.X
                    MyY = Frm.Location.Y
                    Frm.WindowState = FormWindowState.Maximized
                Case FormWindowState.Minimized
                    Frm.WindowState = FormWindowState.Normal
                    MyX = Frm.Location.X
                    MyY = Frm.Location.Y
                    Frm.WindowState = FormWindowState.Minimized
                Case Else
                    MyX = Frm.Location.X
                    MyY = Frm.Location.Y
            End Select

            For i As Integer = 0 To Screen.AllScreens.Count - 1
                Dim a As Screen = Screen.AllScreens(i)
                With a.WorkingArea
                    If .X <= MyX AndAlso MyX <= .X + .Width Then
                        If .Y <= MyY AndAlso MyY <= .Y + .Height Then
                            Return i
                        End If
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
      
        Return -1
    End Function
#Region "ValueBetween"
    'Public Function ValueBetween(Value As Integer, Min As Integer, Max As Integer) As Integer
    '    Select Case True
    '        Case Value < Min : Return Min
    '        Case Value > Max : Return Max
    '        Case Else : Return Value
    '    End Select
    'End Function
    'Public Function ValueBetween(Value As Decimal, Min As Decimal, Max As Decimal) As Decimal
    '    Select Case True
    '        Case Value < Min : Return Min
    '        Case Value > Max : Return Max
    '        Case Else : Return Value
    '    End Select
    'End Function


    Public Function ValueBetween(Of T)(Value As T, Min As T, Max As T) As T
        Return ValueBetween(Value, Min, Max, Comparer(Of T).Default) ' デフォルトの比較子を指定
    End Function
    Public Function ValueBetween(Of T)(Value As T, Min As T, Max As T, ByVal comparer As IComparer(Of T)) As T
        Select Case True
            Case comparer.Compare(Value, Min) < 0 : Return Min
            Case comparer.Compare(Max, Value) < 0 : Return Max
            Case Else : Return Value
        End Select
    End Function
#End Region
   
End Module
Public Class WorkModeClass
    Enum enumWorkMode
        VideoSave = 0
        VideoSaveAs = 1
        PictureSave_Bitmap = 2
        PictureSave_JPEG = 3
        PictureSave_PNG = 4
        PictureSaveAs = 5
        PictureSaveClipbord = 6
        PicturePrintOut = 7
        PictureOnigiri = 8
        PictureSaveWordpad = 9
        PictureOnigiriSet = 10
    End Enum
End Class
