Public Class FrmPosiForm
    Dim WithEvents FCF As New ClassFormControl
    Dim _PanelHeight As Integer = 0

    Private Sub FrmPosiForm_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Call Menu_MoveForm_Click(Nothing, Nothing)
    End Sub
    Private Sub FrmPosiForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmPosiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FCF.TargetForm = Me

        Select Case True
            Case ReadReg("General", "FormOpacity", enum_Type.er_Integer) < 30
                FCF.Opacity = 0.7
                Me.Opacity = 0.7
            Case ReadReg("General", "FormOpacity", enum_Type.er_Integer) > 100
                FCF.Opacity = 0.7
                Me.Opacity = 0.7
            Case Else
                FCF.Opacity = ReadReg("General", "FormOpacity", enum_Type.er_Integer) / 100
                Me.Opacity = ReadReg("General", "FormOpacity", enum_Type.er_Integer) / 100
        End Select

    End Sub
    Private Sub FCF_FormMoved() Handles FCF.FormMoved
        If _FormPosition.Count > 0 Then
            For i As Integer = 0 To _FormPosition.Count - 1
                If _FormPosition(i).ID = Me.Tag Then
                    _FormPosition(i).Position = Me.Location
                    _FormPosition(i).FormSize = Me.Size
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' ポジション削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_DeleteForm_Click(sender As Object, e As EventArgs) Handles Menu_DeleteForm.Click
        If MsgBox("この位置を削除してもいいですか？", 4 + 32, "確認") = MsgBoxResult.Yes Then
            If _FormPosition.Count > 0 Then
                For i As Integer = 0 To _FormPosition.Count - 1
                    If _FormPosition(i).ID = Me.Tag Then
                        _FormPosition.RemoveAt(i)
                        Exit For
                    End If
                Next

                For i As Integer = 0 To _FormPositionForm.Count - 1
                    If _FormPositionForm(i).Tag = Me.Tag Then
                        _FormPositionForm.RemoveAt(i)
                        Exit For
                    End If
                Next
                Me.Close()
            End If
        End If
    End Sub
    ''' <summary>
    ''' ここに移動メニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_MoveForm_Click(sender As Object, e As EventArgs) Handles Menu_MoveForm.Click
        If FrmMain.Panel1.Dock = DockStyle.Top Then
            FrmMain.Location = New Point(Me.Left, Me.Top - FrmMain.Panel1.Height)
            FrmMain.Size = New Size(Me.Width, Me.Height + FrmMain.Panel1.Height)
        Else
            FrmMain.Location = Me.Location
            FrmMain.Size = New Size(Me.Width, Me.Height + FrmMain.Panel1.Height)
        End If
        If FrmMain.WindowState = FormWindowState.Minimized Then
            FrmMain.WindowState = FormWindowState.Normal
        End If
        If FrmMain.MenuFormPosition_AutoFollow.Checked Then
            FrmMain.MenuFormPosition_AutoFollow.Checked = False
            FrmMain.Timer_AutoFollow.Enabled = False
            FrmMain.MenuAutoFollow.Checked = False
            FrmMain.BtnFitSize.Image = My.Resources.zoom_fit_icon
        End If
        Call FrmMain.MenuFormPosition_Close_Click(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' ポジションコピー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_CopyForm_Click(sender As Object, e As EventArgs) Handles Menu_CopyForm.Click
        Dim _T As New ClassFormPosition
        _T.ID = CreateID()
        _T.Position = Me.Location
        _T.FormSize = Me.Size
        _FormPosition.Add(_T)

        Dim FR As New FrmPosiForm
        FR.Show()
        FR.Tag = _T.ID
        FR.Location = New Point(_T.Position)
        FR.Size = New Size(_T.FormSize)
        _FormPositionForm.Add(FR)
    End Sub
    ''' <summary>
    ''' キャンセルメニュー
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        If FrmMain.WindowState = FormWindowState.Minimized Then
            FrmMain.WindowState = FormWindowState.Normal
        End If
        Call FrmMain.MenuFormPosition_Close_Click(Nothing, Nothing)
    End Sub
    Private Sub FrmPosiForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call MenuCancel_Click(Nothing, Nothing)
        End If
    End Sub

End Class