Public Class FrmOnigiriSet
    Dim _OniCount As Integer = 0
    Dim _PictBoxArray As New List(Of PictureBox)
    Dim _PicImageArray As New List(Of Image)


    Private Sub FrmOnigiriSet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        OnigiriSetStat = Nothing
        My.Settings.OnigiriSet_Size = Me.Size
        My.Settings.OnigiriSet_TopMost = Me.TopMost
        My.Settings.Save()
        Me.Dispose()
    End Sub

    Private Sub FrmOnigiriSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        OnigiriSetStat = Me
        Dim _SZ As Size = My.Settings.OnigiriSet_Size
        If _SZ.Width > 100 AndAlso _SZ.Height > 100 Then
            Me.Size = New Size(_SZ)
        End If

        'フォームを右下に移動
        Dim h As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height
        Dim w As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
        Me.Location = New Point(w - Me.Width, h - Me.Height)
        Me.TopMost = My.Settings.OnigiriSet_TopMost
        MenuTopMost.Checked = My.Settings.OnigiriSet_TopMost
        TabControl1.TabPages.Clear()
    End Sub

    ''' <summary>
    ''' 新規におにぎりセットを作る
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPict()
        If FrmMain._OnigiriForm.Count > 0 Then
            For i As Integer = 0 To FrmMain._OnigiriForm.Count - 1
                Dim Fr As FrmOnigiri = FrmMain._OnigiriForm(i)
                _OniCount += 1
                TabControl1.TabPages.Add(String.Format("おにぎり{0}", _OniCount))

                Dim Pct As New PictureBox
                With Pct
                    .Name = "PictureBox" & i.ToString
                    .Dock = DockStyle.Fill
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .ContextMenuStrip = ContextMenuStrip1
                    .Image = Fr.PictureBox1.Image
                    TabControl1.TabPages(i).Controls.Add(Pct)
                End With
                _PictBoxArray.Add(Pct)
                _PicImageArray.Add(Fr.PictureBox1.Image)
            Next

            For i As Integer = FrmMain._OnigiriForm.Count - 1 To 0 Step -1
                Dim Fr As FrmOnigiri = FrmMain._OnigiriForm(i)
                Fr.Close()
            Next
        End If
    End Sub
    ''' <summary>
    ''' おにぎりセットに追加
    ''' </summary>
    ''' <param name="Img"></param>
    ''' <remarks></remarks>
    Public Sub AddPic(Img As Image)
        _OniCount += 1
        TabControl1.TabPages.Add(String.Format("おにぎり{0}", _OniCount))
        Dim Pct As New PictureBox
        With Pct
            .Name = "PictureBox" & TabControl1.TabPages.Count - 1
            .Dock = DockStyle.Fill
            .SizeMode = PictureBoxSizeMode.StretchImage
            .ContextMenuStrip = ContextMenuStrip1
            .Image = Img

            TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(Pct)
            TabControl1.SelectedIndex = TabControl1.TabPages.Count - 1
            _PictBoxArray.Add(Pct)
            _PicImageArray.Add(Img)

            Dim _A As Boolean = Me.TopMost
            Me.TopMost = True
            Me.TopMost = _A
        End With
    End Sub

    ''' <summary>
    ''' 前面表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuTopMost_Click(sender As Object, e As EventArgs) Handles MenuTopMost.Click
        MenuTopMost.Checked = Not MenuTopMost.Checked
        Me.TopMost = MenuTopMost.Checked
    End Sub
    ''' <summary>
    ''' 選択おにぎりを保存する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOutPic_SelOne_Click(sender As Object, e As EventArgs) Handles MenuOutPic_SelOne.Click
        Dim Index As Integer = TabControl1.SelectedIndex
        Dim _FL As String = ""

        Using oFD As New SaveFileDialog
            With oFD
                .AddExtension = True
                .CheckFileExists = False
                .CheckPathExists = True
                .FileName = TabControl1.TabPages(Index).Text
                .Filter = "BMPファイル(*.bmp)|*.bmp|JPEGPファイル(*.jpg)|*.jpg|PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .RestoreDirectory = True
                .Title = "画像保存"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _FL = .FileName
                End If
            End With
        End Using

        If _FL <> "" Then
            '画像を保存する
            Select Case System.IO.Path.GetExtension(_FL).ToUpper
                Case ".BMP"
                    _PicImageArray(Index).Save(_FL, System.Drawing.Imaging.ImageFormat.Bmp)
                Case ".JPG"
                    _PicImageArray(Index).Save(_FL, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case ".PMG"
                    _PicImageArray(Index).Save(_FL, System.Drawing.Imaging.ImageFormat.Png)
            End Select
            MsgBox("画像保存完了", 64, "情報")
        End If
    End Sub

    ''' <summary>
    ''' 全てのおにぎりを保存する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuOutPic_All_Click(sender As Object, e As EventArgs) Handles MenuOutPic_All.Click
        If Not IsNothing(_PicImageArray) AndAlso _PicImageArray.Count > 0 Then
            Dim RootFLD As String = ReadReg("General", "SaveFolder")
            Dim FLD As String = ""
            Dim OokiiDiag As New Ookii.Dialogs.VistaFolderBrowserDialog
            With OokiiDiag
                .UseDescriptionForTitle = True
                .Description = "画像保存フォルダ"
                If RootFLD <> "" AndAlso System.IO.Directory.Exists(RootFLD) Then
                    .SelectedPath = RootFLD
                End If
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FLD = .SelectedPath
                End If
            End With
            If FLD <> "" Then
                Dim FN As String = My.Computer.FileSystem.CombinePath(FLD, String.Format("{0:yyyyMMddHHmmss}", Now))
                For i As Integer = 0 To _PicImageArray.Count - 1
                    Dim FN2 As String = String.Format("{0}-{1}.png", FN, i + 1)
                    _PicImageArray(i).Save(FN2, System.Drawing.Imaging.ImageFormat.Png)
                Next
                MsgBox("画像保存完了", 64, "情報")
            End If
        End If
    End Sub
    ''' <summary>
    ''' おにぎりに戻す（選択タブ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuBackOnigiri_SelOne_Click(sender As Object, e As EventArgs) Handles MenuBackOnigiri_SelOne.Click
        Dim Index As Integer = TabControl1.SelectedIndex
        Clipboard.SetDataObject(_PicImageArray(Index), True)
        Dim FR As New FrmOnigiri
        With FR
            .UserTitle = TabControl1.TabPages(Index).Text
            .Show()
        End With
    End Sub
    ''' <summary>
    ''' おにぎりに戻す（全て）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuBackOnigiri_All_Click(sender As Object, e As EventArgs) Handles MenuBackOnigiri_All.Click
        If Not IsNothing(_PicImageArray) AndAlso _PicImageArray.Count > 0 Then
            For i As Integer = 0 To _PicImageArray.Count - 1
                Clipboard.SetDataObject(_PicImageArray(i), True)
                Dim FR As New FrmOnigiri
                With FR
                    .UserTitle = TabControl1.TabPages(i).Text
                    .Show()
                End With
            Next
        End If
    End Sub
    ''' <summary>
    ''' タブ削除（選択タブ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDelTab_SelOne_Click(sender As Object, e As EventArgs) Handles MenuDelTab_SelOne.Click
        Dim Index As Integer = TabControl1.SelectedIndex
        If MsgBox("このタブを削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _PictBoxArray.RemoveAt(Index)
            _PicImageArray.RemoveAt(Index)
            TabControl1.TabPages.RemoveAt(Index)
        End If
    End Sub
    ''' <summary>
    ''' タブ削除（全て）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuDelTab_All_Click(sender As Object, e As EventArgs) Handles MenuDelTab_All.Click
        Dim Index As Integer = TabControl1.SelectedIndex
        If MsgBox("全てのタブを削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            _PictBoxArray.Clear()
            _PicImageArray.Clear()
            TabControl1.TabPages.Clear()
            _OniCount = 0
        End If
    End Sub
    ''' <summary>
    ''' クリップボードに送る（選択タブ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendClip_SelOne_Click(sender As Object, e As EventArgs) Handles MenuSendClip_SelOne.Click
        Dim Index As Integer = TabControl1.SelectedIndex
        Clipboard.SetDataObject(_PicImageArray(Index), True)
    End Sub
    ''' <summary>
    ''' クリップボードに送る（全て）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendClip_All_Click(sender As Object, e As EventArgs) Handles MenuSendClip_All.Click
        If Not IsNothing(_PicImageArray) AndAlso _PicImageArray.Count > 0 Then
            Dim data As DataObject = New DataObject
            For Each Img As Image In _PicImageArray
                Clipboard.SetDataObject(Img, True)
            Next
            MsgBox("クリップボードにコピーしました", 64, "情報")
        End If
    End Sub
    ''' <summary>
    ''' ワードパッドに画像を送信（選択タブ）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendWordpad_SelOne_Click(sender As Object, e As EventArgs) Handles MenuSendWordpad_SelOne.Click
        If Not IsNothing(_PicImageArray) AndAlso _PicImageArray.Count > 0 Then
            If MsgBox("ワードパッドに選択画像を送信してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Dim _Title As String = Me.Text
                Dim _Flg As Boolean = False
                Dim i As Integer = TabControl1.SelectedIndex

                Me.Text = String.Format("{0}({1}を送信中...)", _Title, TabControl1.TabPages(i).Text)
                Application.DoEvents()

                Clipboard.Clear()
                Clipboard.SetDataObject(_PicImageArray(i), True)
                System.Threading.Thread.Sleep(500)
                Dim FR As New FrmOnigiri 'おにぎりのWordpad連携を使用
                With FR
                    .Show()
                    .Visible = False
                    _Flg = .SendWordpad(False)
                    .Close()
                End With
                'System.Threading.Thread.Sleep(1000)
                Application.DoEvents()
                Me.Text = _Title
                If Not _Flg Then
                    MessageBox.Show(Me, "ワードパッドへの画像送信を中止しました", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(Me, "ワードパッドへの画像送信完了", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'MsgBox("ワードパッドへの画像送信完了", 64, "情報")
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' ワードパッドに画像を送信（全て）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSendWordpad_All_Click(sender As Object, e As EventArgs) Handles MenuSendWordpad_All.Click
        If Not IsNothing(_PicImageArray) AndAlso _PicImageArray.Count > 0 Then
            If MsgBox("ワードパッドに全ての画像を送信してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Dim _Title As String = Me.Text
                Dim _Flg As Boolean = False
                For i As Integer = 0 To _PicImageArray.Count - 1
                    Me.Text = String.Format("{0}({1}を送信中...)", _Title, TabControl1.TabPages(i).Text)
                    Application.DoEvents()

                    Clipboard.Clear()
                    Clipboard.SetDataObject(_PicImageArray(i), True)
                    System.Threading.Thread.Sleep(500)
                    Dim FR As New FrmOnigiri 'おにぎりのWordpad連携を使用
                    With FR
                        .Show()
                        .Visible = False
                        _Flg = .SendWordpad(False)
                        .Close()
                    End With
                    'System.Threading.Thread.Sleep(1000)
                    Application.DoEvents()

                    If Not _Flg Then
                        Exit For
                    End If
                    Application.DoEvents()
                Next
                Me.Text = _Title
                If Not _Flg Then
                    MessageBox.Show(Me, "ワードパッドへの画像送信を中止しました", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(Me, "ワードパッドへの画像送信完了", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'MsgBox("ワードパッドへの画像送信完了", 64, "情報")
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 起動サイズに戻す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuStartSize_Click(sender As Object, e As EventArgs) Handles MenuStartSize.Click
        Dim _SZ As Size = My.Settings.OnigiriSet_Size
        If _SZ.Width > 100 AndAlso _SZ.Height > 100 Then
            Me.Size = New Size(_SZ)
        End If
    End Sub

End Class