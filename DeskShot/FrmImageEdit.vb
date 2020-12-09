Public Class FrmImageEdit
    Dim _TmpBmp As New List(Of Bitmap)
    Dim _OrgBmp As New List(Of Bitmap)
    Dim _ImageSize As Size
    Dim _EditFlg As Boolean = False

    Property BmpData As List(Of Bitmap)
        Get
            Return _TmpBmp
        End Get
        Set(value As List(Of Bitmap))
            _TmpBmp = value
        End Set
    End Property
    Private Sub FrmImageEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmImageEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        With _TmpBmp(0).Size
            _ImageSize = New Size(.Width, .Height)
        End With
        For Each III As Bitmap In _TmpBmp
            _OrgBmp.Add(III)
        Next
        TrackBar1.Maximum = _TmpBmp.Count - 1
        PictureBox1.Image = _TmpBmp(0)

        PictureBox2.Parent = PictureBox1
        PictureBox2.Location = New Point(0, 0)
        PictureBox2.Size = New Size(PictureBox1.Size)
    End Sub

    Dim _OldValue As Integer = -1
    ''' <summary>
    ''' タイムライン移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        If _EditFlg Then
            If MsgBox("変更を反映せずに移動してもいいですか？", 4 + 32, "確認") = MsgBoxResult.No Then
                Return
            End If
        End If
        PictureBox1.Image = _TmpBmp(TrackBar1.Value)
        _OldValue = TrackBar1.Value
        _EditFlg = False
    End Sub
    ''' <summary>
    ''' タイムライン前へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMoveDown_Click(sender As Object, e As EventArgs) Handles BtnMoveDown.Click
        If TrackBar1.Value > TrackBar1.Minimum Then
            TrackBar1.Value -= 1
            Call TrackBar1_Scroll(Nothing, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' タイムライン後へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMoveUp_Click(sender As Object, e As EventArgs) Handles BtnMoveUp.Click
        If TrackBar1.Value < TrackBar1.Maximum Then
            TrackBar1.Value += 1
            Call TrackBar1_Scroll(Nothing, Nothing)
        End If
    End Sub
    ''' <summary>
    ''' フレーム削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnDelCell_Click(sender As Object, e As EventArgs) Handles BtnDelCell.Click
        If _TmpBmp.Count > 1 Then
            If MsgBox("選択画像を削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                _TmpBmp.RemoveAt(TrackBar1.Value)
                _OrgBmp.RemoveAt(TrackBar1.Value)
                TrackBar1.Maximum = _TmpBmp.Count - 1
                PictureBox1.Image = _TmpBmp(TrackBar1.Value)
            End If
        End If
    End Sub
    ''' <summary>
    ''' フレーム画像保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSaveCell_Click(sender As Object, e As EventArgs) Handles BtnSaveCell.Click
        Dim FN As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                '.DefaultExt = ".bmp"
                .FileName = String.Format("{0:yyyyMMddHHmmss}-{1}", Now, TrackBar1.Value)
                .Filter = "ビットマップファイル(*.BMP)|*.bmp|PNGファイル(*.PNG)|*.png|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .RestoreDirectory = True
                .Title = "保存"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FN = .FileName
                End If
            End With
        End Using

        If Not String.IsNullOrEmpty(FN) Then
            Dim PP As New PictureBox

            PP.Size = New Size(_ImageSize.Width, _ImageSize.Height)
            Dim canvas As New Bitmap(PP.Width, PP.Height)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)

            Dim srcRect As New Rectangle(0, 0, _ImageSize.Width, _ImageSize.Height)
            '描画する部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100で描画する
            Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
            '画像の一部を描画する
            g.DrawImage(PictureBox1.Image, desRect, srcRect, GraphicsUnit.Pixel)
            PP.Image = canvas

            If System.IO.Path.GetExtension(FN).ToUpper = ".BMP" Then
                PP.Image.Save(FN, System.Drawing.Imaging.ImageFormat.Bmp)
            Else
                PP.Image.Save(FN, System.Drawing.Imaging.ImageFormat.Png)
            End If
        End If

    End Sub
    ''' <summary>
    ''' 終了ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' リサイズボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnResize_Click(sender As Object, e As EventArgs) Handles BtnResize.Click
        Dim SZ As Size = Nothing
        With FrmImageResize
            .SampleImage = _TmpBmp(0)
            .ShowDialog()
            SZ = .UserSize
        End With
        If SZ <> Nothing Then
            If MsgBox("指定されたサイズに変更してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                Dim _TmpPic As New PictureBox
                _TmpPic.Size = New Size(SZ.Width, SZ.Height)
                For i As Integer = 0 To _TmpBmp.Count - 1

                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(_TmpPic.Width, _TmpPic.Height)
                    'ImageオブジェクトのGraphicsオブジェクトを作成する
                    Using g As Graphics = Graphics.FromImage(canvas)
                        Using img As Image = _TmpBmp(i)
                            Dim WW As Integer = img.Width * (_TmpPic.Width / img.Width)
                            Dim HH As Integer = img.Height * (_TmpPic.Height / img.Height)
                            g.DrawImage(img, 0, 0, WW, HH)
                        End Using
                    End Using
                    _TmpPic.Image = canvas
                    _TmpBmp(i) = _TmpPic.Image

                Next
                TrackBar1.Value = 0
                PictureBox1.Image = _TmpBmp(TrackBar1.Value)
            End If
        End If

    End Sub
    ''' <summary>
    ''' 動画の保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuSaveVideo_Click(sender As Object, e As EventArgs) Handles MenuSaveVideo.Click
        Dim FN As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .CheckPathExists = True
                .DefaultExt = ".gif"
                .FileName = String.Format("{0:yyyyMMddHHmmss}.gif", Now)
                .Filter = "GIFファイル(*.GIF)|*.gif|全てのファイル(*.*)|*.*"
                .FilterIndex = 0
                .OverwritePrompt = True
                .RestoreDirectory = True
                .Title = "保存"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FN = .FileName
                End If
            End With
        End Using
        If Not String.IsNullOrEmpty(FN) Then
            Dim _IL As Integer = ReadReg("General", "ImageLoop", enum_Type.er_Integer)
            If _IL = 0 Then _IL = 100
            Call SaveAnimatedGif(FN, _TmpBmp.ToArray, 1, _IL)
            Me.Close()
        End If
    End Sub

    Dim firstrunC As Boolean = True

    Private PenColorC As String
    Private dwnC As Boolean
    Dim brC As New Pen(Color.Red)
    Dim lstC As Point

    Dim UNDO As New List(Of Bitmap)

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Select Case True
            Case btnBlue.Checked
                PenColorC = "Blue" : dwnC = True
            Case btnBlack.Checked
                PenColorC = "Black" : dwnC = True
            Case btnRed.Checked
                PenColorC = "Red" : dwnC = True
            Case btnGreen.Checked
                PenColorC = "Green" : dwnC = True
            Case Else
                PenColorC = "White" : dwnC = True
        End Select

        If Not IsNothing(PictureBox1.Image) Then
            Dim MM As Bitmap = PictureBox1.Image
            UNDO.Add(New Bitmap(MM))
            BtnUndo.Enabled = True
        End If

    End Sub
    Dim _BoxSPosi As Point
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If dwnC = True Then
            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            ''ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim img As Image = PictureBox1.Image

            g.DrawImage(img, 0, 0, img.Width, img.Height)

            Dim sC As Integer = 2
            Dim xyC As Point
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            brC.Color = Color.FromName(PenColorC)
            brC.Width = 2
            xyC.X = e.X
            xyC.Y = e.Y
            If firstrunC = True Then
                lstC = xyC
                firstrunC = False
            End If
            g.DrawLine(brC, lstC, xyC)
            lstC = xyC

            PictureBox1.Image = canvas
           
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        dwnC = False
        firstrunC = True
        _EditFlg = True
    End Sub
    Dim _MB As Bitmap
    ''' <summary>
    ''' フレーム更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim PP As New PictureBox

        PP.Size = New Size(_ImageSize.Width, _ImageSize.Height)
        Dim canvas As New Bitmap(PP.Width, PP.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        Dim srcRect As New Rectangle(0, 0, _ImageSize.Width, _ImageSize.Height)
        '描画する部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100で描画する
        Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        '画像の一部を描画する
        g.DrawImage(PictureBox1.Image, desRect, srcRect, GraphicsUnit.Pixel)
        PP.Image = canvas

        _TmpBmp(TrackBar1.Value) = PP.Image
        _MB = PP.Image
        'With Form2
        '    .PictureBox1.Image = _TmpBmp(TrackBar1.Value)
        '    .PictureBox2.Image = _OrgBmp(TrackBar1.Value)
        '    .ShowDialog()
        'End With
        UNDO.Clear()
        BtnUndo.Enabled = False
        _EditFlg = False
    End Sub

    ''' <summary>
    ''' アンドゥ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click

        If UNDO.Count > 0 Then
            PictureBox1.Image = Nothing
            PictureBox1.Image = New Bitmap(UNDO(UNDO.Count - 1))
            UNDO.RemoveAt(UNDO.Count - 1)
        Else
            BtnUndo.Enabled = False
        End If
    End Sub

    Private Sub FrmImageEdit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If MsgBox("このセルをリセットしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            Dim Index As Integer = TrackBar1.Value
            'With Form2
            '    .PictureBox1.Image = _TmpBmp(Index)
            '    .PictureBox2.Image = _OrgBmp(Index)
            '    .ShowDialog()
            'End With
            _TmpBmp(Index) = _OrgBmp(Index)
            PictureBox1.Image = _TmpBmp(Index)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If MsgBox("全てのセルをリセットしてもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            ''_TmpBmp.Clear()
            '_TmpBmp = _OrgBmp
            'TrackBar1.Maximum = _TmpBmp.Count - 1
            'PictureBox1.Image = _TmpBmp(0)

            For i As Integer = 0 To _OrgBmp.Count - 1
                _TmpBmp(i) = _OrgBmp(i)
            Next
            PictureBox1.Image = _TmpBmp(TrackBar1.Value)
        End If
    End Sub

    Private Sub PictureBox1_SizeChanged(sender As Object, e As EventArgs) Handles PictureBox1.SizeChanged
        PictureBox2.Size = PictureBox1.Size
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick

    End Sub
End Class