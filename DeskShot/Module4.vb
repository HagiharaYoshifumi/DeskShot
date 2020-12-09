Imports System.Text
Imports System.Security.Cryptography
Module Module4
    Public _PosiShift As New List(Of PosiShift_Collection)
    Dim _Count As Integer = 0
    Public WithEvents _Tim As New Timer
    Public Function GetSiftPosi() As PosiShift_Collection
        FrmMain.Label1.Text = ""
        If _PosiShift.Count > 0 Then
            Dim _T As PosiShift_Collection = _PosiShift(_Count)
            _Count += 1
            If _Count > _PosiShift.Count - 1 Then
                _Count = 0
            End If
            _Tim.Enabled = False : _Tim.Enabled = True
            Return _T
        Else
            _Tim.Enabled = False

            Return New PosiShift_Collection(False, 0, 0, 0, 0)
        End If
    End Function
    Private Sub _Tim_Tick(sender As Object, e As EventArgs) Handles _Tim.Tick
        _Count = 0
        _Tim.Enabled = False
        FrmMain.Label1.Text = "T-Reset"
        FrmMain.Timer2.Enabled = True
    End Sub
    ''' <summary>
    ''' 特殊フォルダパスを検索する
    ''' </summary>
    ''' <param name="TargetFolder">対象となる特殊フォルダ</param>
    ''' <param name="FileName">ファイル名</param>
    ''' <returns>ファイル名を含むフルパス</returns>
    ''' <remarks>ファイル名指定時
    ''' ファイル名指定時はファイル名を含むフルパスを返します。(特殊フォルダ名＋固定フォルダ名＋ファイル名)またその特殊フォルダが無い場合は自動的に作成されます。
    ''' ファイル名が未指定の場合は特殊フォルダのパスを返します。(特殊フォルダ名＋固定フォルダ）但しこのフォルダの自動作成は行われません
    ''' 　　また、特殊フォルダ自体が存在しない場合は””が帰ります。
    ''' </remarks>
    Public Function SystemFullPath(TargetFolder As System.Environment.SpecialFolder, Optional FileName As String = "") As String
        'http://dobon.net/vb/dotnet/file/getfolderpath.html
        Dim _Folder As System.Environment.SpecialFolder = Environment.SpecialFolder.ApplicationData
        Dim _LocalApricationName As String = "NKS\DeskShot" '←アプリケーションによって変更してください。

        Try
            If FileName = "" Then
                'フォルダが存在しない時は空の文字列を返す（既定）
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.None)
                If _SysPath = "" Then
                    Return ""
                Else
                    Return My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                End If
            Else
                'フォルダが存在しない時は作成して、パスを返す
                Dim _SysPath As String = Environment.GetFolderPath(TargetFolder, Environment.SpecialFolderOption.Create)
                Dim _Path2 As String = My.Computer.FileSystem.CombinePath(_SysPath, _LocalApricationName)
                If Not System.IO.Directory.Exists(_Path2) Then
                    System.IO.Directory.CreateDirectory(_Path2)
                End If
                Return My.Computer.FileSystem.CombinePath(_Path2, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try

    End Function
    Public Function CreateID() As String
        Dim StrAry As String = "ABCDEFGHIJKLNMOPQRSTUVWXYZ" _
                            & "abcdefghijklnmopqrstuvwxyz" _
                            & "0123456789"

        Dim PasW As StringBuilder = New StringBuilder
        For Count As Integer = 0 To 9
            PasW.Append(StrAry.Chars(RollDice(StrAry.Length)))
        Next

        Return PasW.ToString
    End Function
    Private Function RollDice(ByVal NumSides As Integer) As Integer
        Dim randomNumber(0) As Byte
        Dim Gen As New RNGCryptoServiceProvider()
        Gen.GetBytes(randomNumber)
        Dim rand As Integer = Convert.ToInt32(randomNumber(0))
        Return rand Mod NumSides
    End Function 'RollDice

End Module
Public Class PosiShift_Collection
    Public IsUse As Boolean
    Public X As Integer
    Public Y As Integer
    Public Width As Integer
    Public Height As Integer
    Sub New()
        Me.IsUse = False
        Me.X = 0
        Me.Y = 0
        Me.Width = 0
        Me.Height = 0
    End Sub
    Sub New(Use As Boolean, X As Integer, Y As Integer, Width As Integer, Height As Integer)
        Me.IsUse = Use
        Me.X = X
        Me.Y = Y
        Me.Width = Width
        Me.Height = Height
    End Sub
End Class