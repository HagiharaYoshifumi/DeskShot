Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Public Class Form1

    Dim T As Bitmap
    Dim b As New List(Of Bitmap)
    Dim _ImageSize As Size

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        b.Clear()

        ''画像ファイルのパス
        Dim filePath As String = "" ' "C:\SnapShot\20140711155029.gif"
        Using OFD As New OpenFileDialog
            OFD.RestoreDirectory = True
            If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                filePath = OFD.FileName
            End If
        End Using
        Dim img As Image = Image.FromFile(filePath)
        'FrameDimensionを取得する
        Dim fd As New FrameDimension(img.FrameDimensionsList(0))
        'フレーム数を取得する
        Dim frameCount As Integer = img.GetFrameCount(fd)
        Dim y As Integer = 0
        Dim i As Integer
        For i = 0 To frameCount - 1


            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(img.Size.Width, img.Size.Height)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)

            'フレームを選択する
            img.SelectActiveFrame(fd, i)
            '画像を描画する
            g.DrawImage(img, 0, 0, img.Width, img.Height)
            _ImageSize = img.Size
            y += img.Height

            b.Add(canvas)

            g.Dispose()

        Next i

        TrackBar1.Maximum = frameCount - 1
        'リソースを解放する
        img.Dispose()
        'PictureBox1に表示する
        Beep()
    End Sub
    
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        PictureBox1.Image = b(TrackBar1.Value)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            Call SaveAnimatedGif(FN, b.ToArray, 1, _IL)
        End If
    End Sub
    Private brC As New Pen(Color.Red)
    Private dwnC As Boolean
    Private lstC As Point
    Private firstrunC As Boolean = True
    Private PenColorC As String

    Dim UNDO As New List(Of Bitmap)

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If btnBlue.Checked = True Then
            PenColorC = "Blue"
            dwnC = True
        End If

        If btnBlack.Checked = True Then
            PenColorC = "Black"
            dwnC = True
        End If

        If btnRed.Checked = True Then
            PenColorC = "Red"
            dwnC = True
        End If

        If btnGreen.Checked = True Then
            PenColorC = "Green"
            dwnC = True
        End If

        If btnEraser.Checked = True Then
            PenColorC = "White"
            dwnC = True
        End If
        If Not IsNothing(PictureBox1.Image) Then
            Dim MM As Bitmap = PictureBox1.Image
            UNDO.Add(New Bitmap(MM))
        End If
      
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If dwnC = True Then
            ''描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            ''ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim img As Image = PictureBox1.Image

            g.DrawImage(img, 0, 0, img.Width, img.Height)

            Dim sC As Integer
            Dim xyC As Point
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            sC = 2
            brC.Color = Color.FromName(PenColorC)
            brC.Width = 2
            If PenColorC = "White" Then brC.Width = 8
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
      
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If UNDO.Count > 0 Then
            PictureBox1.Image = Nothing
            PictureBox1.Image = New Bitmap(UNDO(UNDO.Count - 1))
            UNDO.RemoveAt(UNDO.Count - 1)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With b(TrackBar1.Value).Size
            MsgBox(String.Format("W:{0} H:{1}", .Width, .Height))

        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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
        b(TrackBar1.Value) = PP.Image
        UNDO.Clear()
    End Sub
End Class