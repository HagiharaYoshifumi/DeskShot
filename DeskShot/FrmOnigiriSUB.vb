Public Class FrmOnigiriSUB
    Dim _SetText As String = ""
    Dim _SetFont As Font
    Dim _SetFontColor As Color
    Dim _UseBack As Boolean = False
    Dim _MojiBackColor As Color
    Dim _IsInitialed As Boolean = False
#Region "プロパティ"
    ''' <summary>
    ''' 描写文字列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SetText As String
        Get
            Return _SetText
        End Get
        Set(value As String)
            _SetText = value
        End Set
    End Property
    ''' <summary>
    ''' 文字フォント
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SetFont As Font
        Get
            Return _SetFont
        End Get
        Set(value As Font)
            _SetFont = value
        End Set
    End Property
    ''' <summary>
    ''' 文字色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SetFontColor As Color
        Get
            Return _SetFontColor
        End Get
        Set(value As Color)
            _SetFontColor = value
        End Set
    End Property
    ''' <summary>
    ''' 背景使用？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UseBack As Boolean
        Get
            Return _UseBack
        End Get
        Set(value As Boolean)
            _UseBack = value
        End Set
    End Property
    ''' <summary>
    ''' 背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MojiBackColor As Color
        Get
            Return _MojiBackColor
        End Get
        Set(value As Color)
            _MojiBackColor = value
        End Set
    End Property
    ''' <summary>
    ''' 背景左余白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShiftLeft As Integer
    ''' <summary>
    ''' 背景右余白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShiftRight As Integer
    ''' <summary>
    ''' 背景上余白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShiftTop As Integer
    ''' <summary>
    ''' 背景下余白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ShiftBottom As Integer

#End Region

    Private Sub FrmOnigiriSUB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmOnigiriSUB_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = _SetText
        Label1.Text = _SetText
        Label1.Font = _SetFont
        Label1.ForeColor = _SetFontColor
        ChkUseBack.Checked = _UseBack
        Label1.BackColor = _MojiBackColor
        TxtColorFore.SelectedColor = _SetFontColor
        TxtColorBack.SelectedColor = _MojiBackColor
        TxtOnigiriBack_Left.Value = _ShiftLeft
        TxtOnigiriBack_Right.Value = _ShiftRight
        TxtOnigiriBack_Top.Value = _ShiftTop
        TxtOnigiriBack_Bottom.Value = _ShiftBottom
        If My.Settings.OnigiriSet_CountGO Then
            If TxtCount.Maximum <= My.Settings.OnigiriSet_Count + 1 Then
                TxtCount.Value = TxtCount.Maximum
            Else
                TxtCount.Value = My.Settings.OnigiriSet_Count + 1
            End If
        Else
            TxtCount.Value = My.Settings.OnigiriSet_Count
        End If
        My.Settings.OnigiriSet_CountGO = False
        My.Settings.Save()
        Call AddEvent()
    End Sub
    Private Sub FrmOnigiriSUB_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _IsInitialed = True
        Call DeawData()
    End Sub
    ''' <summary>
    ''' イベントの追加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddEvent()
        AddHandler TextBox1.TextChanged, AddressOf DeawData

        AddHandler ChkUseBack.CheckStateChanged, AddressOf DeawData
        AddHandler TxtOnigiriBack_Left.ValueChanged, AddressOf DeawData
        AddHandler TxtOnigiriBack_Right.ValueChanged, AddressOf DeawData
        AddHandler TxtOnigiriBack_Top.ValueChanged, AddressOf DeawData
        AddHandler TxtOnigiriBack_Bottom.ValueChanged, AddressOf DeawData
    End Sub
  
    ''' <summary>
    ''' 文字フォント選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectFont_Click(sender As Object, e As EventArgs) Handles BtnSelectFont.Click
        Try
            With FontDialog1
                .Font = Label1.Font
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Label1.Font = .Font
                End If
            End With
            Call DeawData()

        Catch ex As Exception
            MsgBox("文字フォント設定に失敗しました", 48, "エラー")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label1.Text = TextBox1.Text
    End Sub
    ''' <summary>
    ''' ＯＫボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _SetText = Label1.Text
        _SetFont = Label1.Font
        _SetFontColor = Label1.ForeColor
        _OnigiriFont = Label1.Font
        _UseBack = ChkUseBack.Checked
        _MojiBackColor = Label1.BackColor
        _ShiftLeft = TxtOnigiriBack_Left.Value
        _ShiftRight = TxtOnigiriBack_Right.Value
        _ShiftTop = TxtOnigiriBack_Top.Value
        _ShiftBottom = TxtOnigiriBack_Bottom.Value

        My.Settings.OnigiriSet_Count = TxtCount.Value
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    ''' <summary>
    ''' キャンセルボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
  
    Private Sub ChkUseBack_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUseBack.CheckedChanged
        GroupBox2.Enabled = ChkUseBack.Checked
        If ChkUseBack.Checked Then
            If _MojiBackColor = Color.Transparent Then
                _MojiBackColor = Color.White
            End If
            Label1.BackColor = _MojiBackColor
        Else
            Label1.BackColor = Color.Transparent
        End If

    End Sub
    ''' <summary>
    ''' プレビュー作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeawData()
        If _IsInitialed Then

            'クリックする事によりPictureBox2の内容をPictureBox1転記しても文字モードから抜け出す
            Dim canvas As New Bitmap(PictureBox10.Width, PictureBox10.Height)
            'ImageオブジェクトのGraphicsオブジェクトを作成する

            Using g As Graphics = Graphics.FromImage(canvas)
                Dim img As Image = PictureBox10.Image
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                If ChkUseBack.Checked Then
                    '塗りつぶし背景を使用する
                    Dim StringWidth As Integer = g.MeasureString(TextBox1.Text, Label1.Font).Width
                    Dim StringHeight As Integer = g.MeasureString(TextBox1.Text, Label1.Font).Height
                    Using b As New SolidBrush(_MojiBackColor)
                        g.FillRectangle(b, 0, 0, StringWidth + TxtOnigiriBack_Left.Value + TxtOnigiriBack_Right.Value, StringHeight + TxtOnigiriBack_Top.Value + TxtOnigiriBack_Bottom.Value)

                    End Using
                End If

                Dim _UBrush As Brush = New SolidBrush(Label1.ForeColor)
                g.DrawString(TextBox1.Text, Label1.Font, _UBrush, TxtOnigiriBack_Left.Value, TxtOnigiriBack_Top.Value)
            End Using
            PictureBox10.Image = canvas
        End If

    End Sub


    ''' <summary>
    ''' 文字色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtColorFore_SelectedColorChanged(sender As Object, e As EventArgs) Handles TxtColorFore.SelectedColorChanged
        Try
            Label1.ForeColor = TxtColorFore.SelectedColor
            Call DeawData()

        Catch ex As Exception
            MsgBox("文字色設定に失敗しました", 48, "エラー")
        End Try
    End Sub
    ''' <summary>
    ''' 背景色選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtColorBack_SelectedColorChanged(sender As Object, e As EventArgs) Handles TxtColorBack.SelectedColorChanged
        Try
            Label1.BackColor = TxtColorBack.SelectedColor
            _MojiBackColor = TxtColorBack.SelectedColor
            Call DeawData()
        Catch ex As Exception
            MsgBox("文字色設定に失敗しました", 48, "エラー")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = TxtCount.Value
        My.Settings.OnigiriSet_CountGO = True
        My.Settings.Save()
        BtnOK.PerformClick()
    End Sub

    Private Sub TxtCount_ValueChanged(sender As Object, e As EventArgs) Handles TxtCount.ValueChanged

    End Sub
End Class