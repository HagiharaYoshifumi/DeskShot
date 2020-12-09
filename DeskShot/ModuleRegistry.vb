Imports Microsoft.Win32
Module ModuleRegistry
    Dim RegRoot As String = "SOFTWARE\NKS\DeskShot"
    Public Enum enum_Type
        er_String
        er_Integer
        er_Boolean
        er_DateTime
    End Enum
    Dim a As Boolean
    ''' <summary>
    ''' レジストリに書き込む
    ''' </summary>
    ''' <param name="Section">セクション名</param>
    ''' <param name="KeyName">キー名</param>
    ''' <param name="Value">書き込み値</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub WriteReg(ByVal Section As String, ByVal KeyName As String, ByVal Value As Object)
        Dim SetValue As String = ""
        Select Case Value.GetType.Name
            Case "Boolean"
                SetValue = IIf(Value, "1", "0")
            Case Else
                SetValue = Value.ToString
        End Select


        Dim RegData As RegistryKey
        ' レジストリ キーを作成します
        RegData = Registry.CurrentUser.CreateSubKey(RegRoot & "\" & Section)

        ' レジストリ キーが作成できた場合は値を設定します
        If (Not RegData Is Nothing) Then
            RegData.SetValue(KeyName, SetValue)
            RegData.Close()
        End If
    End Sub
    ''' <summary>
    ''' レジストリを読み込む
    ''' </summary>
    ''' <param name="Section">セクション名</param>
    ''' <param name="KeyName">キー名</param>
    ''' <param name="ValueType">値型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Function ReadReg(ByVal Section As String, ByVal KeyName As String, Optional ByVal ValueType As enum_Type = enum_Type.er_String) As Object
        Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegRoot & "\" & Section, True)

        If Not IsNothing(RegKey) Then
            Dim tmp As String = CStr(RegKey.GetValue(KeyName, ""))
            Select Case ValueType
                Case enum_Type.er_Integer
                    If Integer.TryParse(tmp, True) Then
                        Return Integer.Parse(tmp)
                    Else
                        Return Integer.Parse("0")
                    End If
                Case enum_Type.er_Boolean
                    Select Case tmp
                        Case ""
                            Return Boolean.Parse("False")
                        Case "1"
                            Return Boolean.Parse("True")
                        Case Else
                            Return Boolean.Parse("False")
                    End Select
                Case enum_Type.er_DateTime
                    If DateTime.TryParse(tmp, Now()) Then
                        Return DateTime.Parse(tmp)
                    Else
                        Return Nothing
                    End If
                Case Else
                    Return tmp
            End Select
            Return CStr(RegKey.GetValue(KeyName, ""))
        Else
            Select Case ValueType
                Case enum_Type.er_Integer
                    Return Integer.Parse("0")
                Case enum_Type.er_Boolean
                    Return Boolean.Parse("False")
                Case enum_Type.er_DateTime
                    Return Nothing
                Case Else
                    Return ""
            End Select
        End If
        RegKey.Close()

    End Function


End Module