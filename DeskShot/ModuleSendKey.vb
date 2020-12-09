Imports System.Runtime.InteropServices
Module ModuleSendKey
    'http://mt-soft.sakura.ne.jp/web_dl/vb-parts/key_sendinput/
    'http://kts.sakaiweb.com/virtualkeycodes.html
    Public Const KEY_DOWN As Short = 0 'キー押下
    Public Const KEY_UP As Short = 1 'キーアップ


    Structure KEYBDINPUT
        Dim wVk As Short
        Dim wScan As Short
        Dim dwFlags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
        Dim no_use1 As Integer
        Dim no_use2 As Integer
    End Structure

    <StructLayout(LayoutKind.Explicit)> _
    Structure INPUT_TYPE
        <FieldOffset(0)> Dim dwType As Integer
        <FieldOffset(4)> Dim xi As KEYBDINPUT
    End Structure


    '仮想キーコード
    Public Const VK_CTRL As Short = &H11S 'Contorol
    Public Const VK_RETURN As Short = &H13S 'Enter
    Public Const VK_STARTKEY As Short = &H5B '[LeftWindows]
    Public Const VK_DOWN As Short = &H28 '[Down]
    Public Const VK_S As Short = &H53S '「S」
    Public Const VK_V As Short = &H56S '「V」

    Private Const KEYEVENTF_KEYUP As Short = &H2S 'キーアップ
    Private Const KEYEVENTF_EXTENDEDKEY As Short = &H1S 'スキャンコードは拡張コード
    Private Const INPUT_KEYBOARD As Short = 1 '入力タイプ：キーボード

    '仮想キーコード・ASCII値・スキャンコード間でコードを変換する
    Declare Function MapVirtualKey Lib "user32" _
                                Alias "MapVirtualKeyA" (ByVal wCode As Integer, _
                                                       ByVal wMapType As Integer) As Integer
    '
    ' 仮想キーコードをスキャンコード、または文字の値（ASCII 値）へ変換。
    ' また、スキャンコードを仮想コードへ変換も可。
    '
    '［入力]
    ' 　wCode：キーの仮想キーコード、またはスキャンコードを指定。
    '　　　　　この値の解釈方法は、wMapType パラメータの値に依存。
    '
    ' 　uMapType:実行したい変換の種類を指定。
    ' 　このパラメータの値に基づいて、uCode パラメータの値は次のように解釈。
    '
    '　　値 意味
    ' 　　0 wCode は仮想キーコードであり、スキャンコードへ変換。
    ' 　　　左右のキーを区別しない仮想キーコードのときは、関数は左側のスキャンコードを返却。
    ' 　　1 wCode はスキャンコードであり、仮想キーコードへ変換。
    ' 　　　この仮想キーコードは、左右のキーを区別。
    ' 　　2 wCode は仮想キーコードであり、戻り値の下位ワードにシフトなしの ASCII 値が格納。
    ' 　　　デッドキー（ 分音符号）は、戻り値の上位ビットをセットすることにより明示される。
    ' 　　3 Windows NT/2000：uCode はスキャンコードであり、左右のキーを区別する仮想キーコードへ変換。
    '
    ' 　　　いづれも、変換されないときは、関数は 0 を返す。



    'キーボード入力、マウスボタンのクリックをシミュレートする
    Declare Function SendInput Lib "user32.dll" (ByVal nInputs As Integer, _
                                             ByRef pInputs As INPUT_TYPE, _
                                             ByVal cbSize As Integer) As Integer
    '
    ' nInputs:構造体の数を指定
    ' pInputs:配列へのポインタ INPUT 構造
    ' 　　　　各構造体には、キーボードまたはマウス入力動作に対応するイベントを表す
    ' cbSize :構造体のサイズを指定


    Sub KeyEvent(ByRef VkKey As Short, ByRef UpDown As Short)
        '
        ' 簡略化のためにAPIへは1文字ずつ入力⇒構造体は１つ
        '
        ' VkKey:仮想キーコード
        ' UpDown:動作(KEY_DOWN/KEY_UP)
        '
        Dim inputevents As INPUT_TYPE
        With inputevents
            .dwType = INPUT_KEYBOARD
            With .xi
                .wVk = VkKey '操作キーコード
                .wScan = MapVirtualKey(VkKey, 0) 'スキャンコード
                If UpDown = KEY_DOWN Then 'キーDown
                    .dwFlags = KEYEVENTF_EXTENDEDKEY Or 0
                Else 'キーＵＰ
                    .dwFlags = KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP
                End If
                .time = 0
                .dwExtraInfo = 0
            End With
        End With
        Call SendInput(1, inputevents, Len(inputevents))
    End Sub
End Module
