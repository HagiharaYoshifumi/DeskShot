Imports System.Runtime.InteropServices
Module ModuleProcess

    Public _Is64Bit As Boolean = False '使用OSが６４ビットならTrue

    ''' <summary>
    ''' 起動プロセスの列挙(32ビット)
    ''' </summary>
    ''' <param name="searchFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessesByFileName(searchFileName As String) As System.Diagnostics.Process()
        searchFileName = searchFileName.ToLower()
        Dim list As New System.Collections.ArrayList()

        Try
            'すべてのプロセスを列挙する
            For Each p As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                Dim fileName As String
                Try
                    'メインモジュールのパスを取得する
                    fileName = p.MainModule.FileName
                Catch generatedExceptionName As System.ComponentModel.Win32Exception
                    'MainModuleの取得に失敗
                    fileName = ""
                End Try
                If 0 < fileName.Length Then
                    'ファイル名の部分を取得する
                    fileName = System.IO.Path.GetFileName(fileName)
                    '探しているファイル名と一致した時、コレクションに追加
                    If searchFileName.Equals(fileName.ToLower()) Then
                        list.Add(p)
                    End If
                End If
            Next

            'コレクションを配列にして返す
            Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)), System.Diagnostics.Process())
        Catch ex As Exception
            MsgBox(ex.Message, 48, "プロセス列挙エラー32")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' 起動プロセスの列挙(64ビット)
    ''' </summary>
    ''' <param name="searchFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProcessesByFileName64(searchFileName As String) As System.Diagnostics.Process()
        searchFileName = searchFileName.ToLower()
        Dim list As New System.Collections.ArrayList()
        Dim dic As New Dictionary(Of String, String)
        Try
            Using mc As New System.Management.ManagementClass("Win32_Process")
                Using moc As System.Management.ManagementObjectCollection = mc.GetInstances()
                    Dim mo As System.Management.ManagementObject
                    For Each mo In moc
                        Console.WriteLine("プロセス名:{0}", mo("Name"))
                        Console.WriteLine("プロセスID:{0}", mo("ProcessId"))
                        Console.WriteLine("ファイル名:{0}", mo("ExecutablePath"))
                        If Not IsNothing(mo("ExecutablePath")) Then
                            If mo("ExecutablePath").ToString.ToLower.IndexOf(searchFileName) > -1 Then
                                dic.Add(mo("ProcessId").ToString(), mo("ExecutablePath").ToString())
                            End If
                        End If
                        mo.Dispose()
                    Next
                End Using
            End Using

            '名前からプロセスを特定する
            For Each p As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                If p.MainWindowHandle <> IntPtr.Zero Then
                    If (dic.ContainsKey(p.Id.ToString())) Then
                        list.Add(p)
                    End If
                End If
            Next

            'コレクションを配列にして返す
            Return DirectCast(list.ToArray(GetType(System.Diagnostics.Process)), System.Diagnostics.Process())

        Catch ex As Exception
            MsgBox(ex.Message, 48, "プロセス列挙エラー64")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' ワードパッドへの貼り付け操作
    ''' </summary>
    ''' <param name="_WordpadStatus"></param>
    ''' <remarks></remarks>
    Public Sub WordPadWork(_WordpadStatus As Boolean)
        '画像を貼り付ける
        Call KeyEvent(VK_CTRL, KEY_DOWN)  'コントロールキーを押下
        Call KeyEvent(VK_V, KEY_DOWN)     '「ｖ」キー押下（貼り付け）
        Call KeyEvent(VK_V, KEY_UP)       '「ｖ」キーを離す
        Call KeyEvent(VK_CTRL, KEY_UP)    'コントロールキーを離す
        System.Threading.Thread.Sleep(200)

        '１段下げる
        My.Computer.Keyboard.SendKeys("{Enter}")

        'タイムスタンプを送る
        If ReadReg("General", "TimeStamp", enum_Type.er_Boolean) Then
            System.Threading.Thread.Sleep(200)
            Clipboard.SetText(String.Format("(上記取得:{0:yyyy/MM/dd HH:mm:ss})", Now))
            Call KeyEvent(VK_CTRL, KEY_DOWN)  'コントロールキーを押下
            Call KeyEvent(VK_V, KEY_DOWN)     '「ｖ」キー押下（貼り付け）
            Call KeyEvent(VK_V, KEY_UP)       '「ｖ」キーを離す
            Call KeyEvent(VK_CTRL, KEY_UP)    'コントロールキーを離す
            System.Threading.Thread.Sleep(200)
            My.Computer.Keyboard.SendKeys("{Enter}")
        End If

        'Wordpadを保存(CTRL+S）する
        If ReadReg("General", "WordpadSave", enum_Type.er_Boolean) Then
            System.Threading.Thread.Sleep(200)
            Call KeyEvent(VK_CTRL, KEY_DOWN)  'コントロールキーを押下
            Call KeyEvent(VK_S, KEY_DOWN)     '「S」キー押下（保存）
            Call KeyEvent(VK_S, KEY_UP)       '「S」キーを離す
            Call KeyEvent(VK_CTRL, KEY_UP)    'コントロールキーを離す
        End If

        'Wordpadが元々最小化なら、作業終了後に最小化にする
        If _WordpadStatus Then
            System.Threading.Thread.Sleep(200)
            Call KeyEvent(VK_STARTKEY, KEY_DOWN)  'Windowsキーを押下
            Call KeyEvent(VK_DOWN, KEY_DOWN)     '「↓」キー押下
            Call KeyEvent(VK_DOWN, KEY_UP)       '「↓」キーを離す
            Call KeyEvent(VK_STARTKEY, KEY_UP)    'Windowsキーを離す
        End If
    End Sub


    'http://kchon.blog111.fc2.com/blog-entry-128.html
    <DllImport("user32")> _
    Private Function GetWindowThreadProcessId(ByVal hwnd As Integer, ByRef lpdwprocessid As Integer) As Integer
    End Function
    ''' <summary>
    ''' ウィンドウハンドルをプロセスIDに変換する
    ''' </summary>
    ''' <param name="hwnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPidFromHwnd(ByVal hwnd As Integer) As Integer
        Dim pid As Integer
        Call GetWindowThreadProcessId(hwnd, pid)
        GetPidFromHwnd = pid
    End Function
End Module
