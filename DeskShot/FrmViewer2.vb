Public Class FrmViewer2
    Private Sub FrmViewer2_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Clipboard.ContainsImage() Then
            'クリップボードにあるデータの取得
            Dim img As Image = Clipboard.GetImage()
            If img IsNot Nothing Then
                'データが取得できたときは表示する

                Dim _Width As Integer = Me.Size.Width - PictureBox1.Size.Width
                Dim _Height As Integer = Me.Size.Height - PictureBox1.Size.Height
                Me.Size = New Size(img.Width + _Width, img.Height + _Height)
                PictureBox1.Image = img

                'MsgBox(String.Format("{0}-{1}", Me.Size.Width, Me.Size.Height))
                'MsgBox(String.Format("{0}-{1}", PictureBox1.Size.Width, PictureBox1.Size.Height))
            End If
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Clipboard.SetDataObject(PictureBox1.Image, True)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim _FileName As String = ""
        Using SFD As New SaveFileDialog
            With SFD
                .Filter = "GIF形式|*.gif|JPEG形式|*.jpeg|PNG形式|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    _FileName = .FileName
                End If
            End With
        End Using
        If _FileName <> "" Then
            Select Case System.IO.Path.GetExtension(_FileName).ToUpper
                Case ".GIF"

                    PictureBox1.Image.Save(_FileName, Imaging.ImageFormat.Gif)
                Case ".JPEG"
                    PictureBox1.Image.Save(_FileName, Imaging.ImageFormat.Jpeg)
                Case ".PNG"
                    PictureBox1.Image.Save(_FileName, Imaging.ImageFormat.Png)
            End Select
            MsgBox("保存完了", 64, "情報")
        End If

    End Sub


    Dim firstrunC As Boolean = True

    Private PenColorC As String
    Private dwnC As Boolean
    Dim brC As New Pen(Color.Red)
    Dim lstC As Point

    Dim UNDO As New List(Of Bitmap)

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        'Select Case True
        '    Case btnBlue.Checked
        '        PenColorC = "Blue" : dwnC = True
        '    Case btnBlack.Checked
        '        PenColorC = "Black" : dwnC = True
        '    Case btnRed.Checked
        '        PenColorC = "Red" : dwnC = True
        '    Case btnGreen.Checked
        '        PenColorC = "Green" : dwnC = True
        '    Case Else
        '        PenColorC = "White" : dwnC = True
        'End Select

        'If Not IsNothing(PictureBox1.Image) Then
        '    Dim MM As Bitmap = PictureBox1.Image
        '    UNDO.Add(New Bitmap(MM))
        '    BtnUndo.Enabled = True
        'End If

        PenColorC = "Blue" : dwnC = True
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If dwnC = True Then
            ''描画先とするImageオブジェクトを作成する
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
        '_EditFlg = True
    End Sub

End Class