Public Class FrmShotcats

    Dim _Datas As New List(Of ShortCatDataCollection)
    Dim _DatasO As New List(Of ShortCatDataCollection)
    Private Sub Data()

        _Datas.Add(New ShortCatDataCollection("●基本", ""))
        _Datas.Add(New ShortCatDataCollection("[HOME]", "スクリーンショット"))
        _Datas.Add(New ShortCatDataCollection("[CTL]+[矢印キー]", "移動"))
        _Datas.Add(New ShortCatDataCollection("[SHIFT]+[CTL]+[矢印キー]", "高速移動"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[矢印キー]", "サイズ変更"))
        _Datas.Add(New ShortCatDataCollection("[SHIFT]+[ALT]+[矢印キー]", "サイズ変更（高速）"))
        _Datas.Add(New ShortCatDataCollection("[SHIFT]+[↓]", "最小化"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[PAUSE]", "デスクトップ"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[Scroll]", "ウィンドウフィット"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[HOME]", "ダイアログキャプチャー"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[Insert]", "メニュー上付／下付"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[Del]", "メニュー表示"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[Enter]", "キャプチャー範囲指定"))
        _Datas.Add(New ShortCatDataCollection("[CTL]+[HOME]", "フォルダを開く"))
        _Datas.Add(New ShortCatDataCollection("[CTL]+[Q]", "自動追尾"))

        _Datas.Add(New ShortCatDataCollection("●ショットタイマ", ""))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[1]", "ショットタイマ(３秒)"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[2]", "ショットタイマ(５秒)"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[3]", "ショットタイマ(１０秒)"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[4]", "ショットタイマ(１５秒)"))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[5]", "ショットタイマ(２０秒)"))
        _Datas.Add(New ShortCatDataCollection("●フレーム", ""))
        _Datas.Add(New ShortCatDataCollection("[CTL]+[Insert]", "フレーム位置記録"))
        _Datas.Add(New ShortCatDataCollection("[CTL]+[Del]", "フレーム位置表示"))
        _Datas.Add(New ShortCatDataCollection("●その他", ""))
        _Datas.Add(New ShortCatDataCollection("[ALT]+[CTL]+[HOME]", "パニックキー"))

        _DatasO.Add(New ShortCatDataCollection("[Space]", "クリップボードに送る"))
        _DatasO.Add(New ShortCatDataCollection("[ESC]", "終了／文字モード終了"))
        _DatasO.Add(New ShortCatDataCollection("[Enter]", "ワードパッド連携"))
        _DatasO.Add(New ShortCatDataCollection("[Back]", "アンドゥ"))
        _DatasO.Add(New ShortCatDataCollection("●描写", ""))
        _DatasO.Add(New ShortCatDataCollection("[なし]", "自由線"))
        _DatasO.Add(New ShortCatDataCollection("[CTL]", "矩形"))
        _DatasO.Add(New ShortCatDataCollection("[Shift]", "直線"))
        _DatasO.Add(New ShortCatDataCollection("[ALT]", "楕円"))
        _DatasO.Add(New ShortCatDataCollection("[CTL]＋[Shift]", "片矢印付き直線"))
        _DatasO.Add(New ShortCatDataCollection("[CTL]＋[Shift]＋[ALT]", "両矢印付き直線"))
        _DatasO.Add(New ShortCatDataCollection("[CTL]＋[ALT]", "塗り潰し矩形"))
        _DatasO.Add(New ShortCatDataCollection("●図形", ""))
        _DatasO.Add(New ShortCatDataCollection("[↑↓]", "図形拡大・縮小"))
        _DatasO.Add(New ShortCatDataCollection("[←→]", "図形回転"))

    End Sub

    Private Sub FrmShotcats_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmMain._FrmShotcats = Nothing
        Me.Dispose()
    End Sub

    Private Sub FrmShotcats_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Data()
        With DataGridView1
            .RowCount = 0
            For Each Itm As ShortCatDataCollection In _Datas
                .RowCount += 1
                With .Rows(.RowCount - 1)
                    .Cells(0).Value = Itm.Keys
                    .Cells(1).Value = Itm.Note
                End With
            Next
        End With
        With DataGridView2
            .RowCount = 0
            For Each Itm As ShortCatDataCollection In _DatasO
                .RowCount += 1
                With .Rows(.RowCount - 1)
                    .Cells(0).Value = Itm.Keys
                    .Cells(1).Value = Itm.Note
                End With
            Next
        End With
        Dim x As Integer = My.Computer.Screen.WorkingArea.Width - Me.Width
        Dim y As Integer = My.Computer.Screen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)
    End Sub
End Class
Public Class ShortCatDataCollection
    Public Keys As String
    Public Note As String
    Sub New()
        Me.Keys = ""
        Me.Note = ""
    End Sub
    Sub New(Keys As String, Note As String)
        Me.Keys = Keys
        Me.Note = Note
    End Sub
End Class