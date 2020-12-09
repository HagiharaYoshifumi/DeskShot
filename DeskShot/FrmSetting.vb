Public Class FrmSetting
    Dim _MainSeze As Size
    ''' <summary>
    ''' メインフォームの大きさ
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    WriteOnly Property MainSize As Size
        Set(value As Size)
            _MainSeze = value
        End Set
    End Property

    Private Sub FrmSetting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub LoadSetting()
        Try
            TxtFolder.Text = ReadReg("General", "SaveFolder")
            Call SetNumericValue("General", "ShotInterval", TxtInterval)
            Call SetNumericValue("General", "ImageLoop", TxtRoop)

            Call SetNumericValue("General", "FormOpacity", TxtOpacity)
            Call SetNumericValue("General", "GifDelayTime", TxtDelayTime)

            ChkAutoOnigiriClose.Checked = ReadReg("General", "AutoOnigiriClose", enum_Type.er_Boolean)
            Call SetNumericValue("General", "OnigiriDrawPenSize", TxtPenSize)
            Call SetNumericValue("General", "OnigiriDrawArrowHead", TxtArrowHead)
            ChkAutoSmall.Checked = ReadReg("General", "AutoSmall", enum_Type.er_Boolean)

            ChkShiftUse0.Checked = ReadReg("SizeShift", "Use0", enum_Type.er_Boolean)
            Call SetNumericValue("SizeShift", "X0", TxtShiftX0)
            Call SetNumericValue("SizeShift", "Y0", TxtShiftY0)
            Call SetNumericValue("SizeShift", "Width0", TxtShiftWidth0)
            Call SetNumericValue("SizeShift", "Height0", TxtShiftHeight0)

            ChkShiftUse1.Checked = ReadReg("SizeShift", "Use1", enum_Type.er_Boolean)
            Call SetNumericValue("SizeShift", "X1", TxtShiftX1)
            Call SetNumericValue("SizeShift", "Y1", TxtShiftY1)
            Call SetNumericValue("SizeShift", "Width1", TxtShiftWidth1)
            Call SetNumericValue("SizeShift", "Height1", TxtShiftHeight1)

            ChkShiftUse2.Checked = ReadReg("SizeShift", "Use2", enum_Type.er_Boolean)
            Call SetNumericValue("SizeShift", "X2", TxtShiftX2)
            Call SetNumericValue("SizeShift", "Y2", TxtShiftY2)
            Call SetNumericValue("SizeShift", "Width2", TxtShiftWidth2)
            Call SetNumericValue("SizeShift", "Height2", TxtShiftHeight2)

            ChkShiftUse3.Checked = ReadReg("SizeShift", "Use3", enum_Type.er_Boolean)
            Call SetNumericValue("SizeShift", "X3", TxtShiftX3)
            Call SetNumericValue("SizeShift", "Y3", TxtShiftY3)
            Call SetNumericValue("SizeShift", "Width3", TxtShiftWidth3)
            Call SetNumericValue("SizeShift", "Height3", TxtShiftHeight3)

            Call SetNumericValue("SizeShift", "ShiftTimerInterva", TxtShiftTimerInterval)

            LblVer.Text = String.Format("バージョン：{0}", My.Application.Info.Version.ToString)
            If _Is64Bit Then
                LblVer.Text &= " ( 64ビットOS )"
            Else
                LblVer.Text &= " ( 32ビットOS )"
            End If

            Dim Y As New ColorConverter
            Dim _C As Color = Y.ConvertFromString(ReadReg("General", "DrawColor"))
            If _C.IsEmpty Then
                TxtDrawColor.SelectedColor = Color.Red
            Else
                TxtDrawColor.SelectedColor = _C
            End If

            ChkWordpadSave.Checked = ReadReg("General", "WordpadSave", enum_Type.er_Boolean)
            ChkShotTimerClear.Checked = ReadReg("General", "ShotTimerClear", enum_Type.er_Boolean)
            ChkTimeStamp.Checked = ReadReg("General", "TimeStamp", enum_Type.er_Boolean)
            ChkImageTimeStamp.Checked = ReadReg("General", "ImageTimeStamp", enum_Type.er_Boolean)
            GroupBox5.Enabled = ChkImageTimeStamp.Checked
            CmbTimeStampType.Enabled = ChkImageTimeStamp.Checked
            ChkSizeWarning.Checked = ReadReg("General", "OnigiriSizeWarning", enum_Type.er_Boolean)

            Select Case ReadReg("General", "ImageTimeStampPosi", enum_Type.er_Integer)
                Case 1 : OptTimeStampPosi1.Checked = True
                Case 2 : OptTimeStampPosi2.Checked = True
                Case 3 : OptTimeStampPosi3.Checked = True
                Case 4 : OptTimeStampPosi4.Checked = True
                Case Else : OptTimeStampPosi0.Checked = True
            End Select
            CmbTimeStampType.SelectedIndex = ReadReg("General", "ImageTimeStampType", enum_Type.er_Integer)

            'マウスキャプチャー
            ChkMC_UseDefSize.Checked = ReadReg("General", "MouseShot_UseSize", enum_Type.er_Boolean)
            Call SetNumericValue("General", "MouseShot_Width", TxtMC_SizeWidth)
            Call SetNumericValue("General", "MouseShot_Height", TxtMC_SizeHeight)
            ChkMC_SizeSave.Checked = ReadReg("General", "MouseShot_UserSizeSave", enum_Type.er_Boolean)


            'その他
            ChkNotFollow.Checked = ReadReg("General", "NotFollow", enum_Type.er_Boolean)

            'メール
            TxtMail_Server.Text = ReadReg("Mail", "Server")
            TxtMail_Port.Text = ReadReg("Mail", "Port")
            TxtMail_ID.Text = ReadReg("Mail", "UserID")
            TxtMail_Password.Text = ReadReg("Mail", "UserPassword")
            TxtMail_FromAddress.Text = ReadReg("Mail", "FromAddress")
            'TxtMail_ToAddress.Text = ReadReg("Mail", "ToAddress")
            'TxtMail_Note.Text = ReadReg("Mail", "Note")
            ChkMail_SendNoAccept.Checked = ReadReg("Mail", "SendNoAccept", enum_Type.er_Boolean)

        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
    End Sub
    Private Function SaveSetting() As Boolean
        Try
            Call WriteReg("General", "SaveFolder", TxtFolder.Text)
            Call WriteReg("General", "ShotInterval", TxtInterval.Value)
            Call WriteReg("General", "ImageLoop", TxtRoop.Value)
            Call WriteReg("General", "FormOpacity", TxtOpacity.Value)
            Call WriteReg("General", "AutoOnigiriClose", ChkAutoOnigiriClose.Checked)
            Call WriteReg("General", "OnigiriDrawPenSize", TxtPenSize.Value)
            Call WriteReg("General", "OnigiriDrawArrowHead", TxtArrowHead.Value)
            Call WriteReg("General", "GifDelayTime", TxtDelayTime.Value)
            Call WriteReg("General", "AutoSmall", ChkAutoSmall.Checked)

            Call WriteReg("SizeShift", "Use0", ChkShiftUse0.Checked)
            Call WriteReg("SizeShift", "X0", TxtShiftX0.Value)
            Call WriteReg("SizeShift", "Y0", TxtShiftY0.Value)
            Call WriteReg("SizeShift", "Width0", TxtShiftWidth0.Value)
            Call WriteReg("SizeShift", "Height0", TxtShiftHeight0.Value)

            Call WriteReg("SizeShift", "Use1", ChkShiftUse1.Checked)
            Call WriteReg("SizeShift", "X1", TxtShiftX1.Value)
            Call WriteReg("SizeShift", "Y1", TxtShiftY1.Value)
            Call WriteReg("SizeShift", "Width1", TxtShiftWidth1.Value)
            Call WriteReg("SizeShift", "Height1", TxtShiftHeight1.Value)

            Call WriteReg("SizeShift", "Use2", ChkShiftUse2.Checked)
            Call WriteReg("SizeShift", "X2", TxtShiftX2.Value)
            Call WriteReg("SizeShift", "Y2", TxtShiftY2.Value)
            Call WriteReg("SizeShift", "Width2", TxtShiftWidth2.Value)
            Call WriteReg("SizeShift", "Height2", TxtShiftHeight2.Value)

            Call WriteReg("SizeShift", "Use3", ChkShiftUse3.Checked)
            Call WriteReg("SizeShift", "X3", TxtShiftX3.Value)
            Call WriteReg("SizeShift", "Y3", TxtShiftY3.Value)
            Call WriteReg("SizeShift", "Width3", TxtShiftWidth3.Value)
            Call WriteReg("SizeShift", "Height3", TxtShiftHeight3.Value)

            Call WriteReg("SizeShift", "ShiftTimerInterva", TxtShiftTimerInterval.Value)

            Dim Y As New ColorConverter
            Call WriteReg("General", "DrawColor", Y.ConvertToString(TxtDrawColor.SelectedColor))
            Call WriteReg("General", "WordpadSave", ChkWordpadSave.Checked)
            Call WriteReg("General", "ShotTimerClear", ChkShotTimerClear.Checked)
            Call WriteReg("General", "TimeStamp", ChkTimeStamp.Checked)
            Call WriteReg("General", "ImageTimeStamp", ChkImageTimeStamp.Checked)
            Call WriteReg("General", "OnigiriSizeWarning", ChkSizeWarning.Checked)

            Dim i As Integer = 0
            Select Case True
                Case OptTimeStampPosi1.Checked : i = 1
                Case OptTimeStampPosi2.Checked : i = 2
                Case OptTimeStampPosi3.Checked : i = 3
                Case OptTimeStampPosi4.Checked : i = 4
                Case Else : i = 0
            End Select
            Call WriteReg("General", "ImageTimeStampPosi", i)
            Call WriteReg("General", "ImageTimeStampType", CmbTimeStampType.SelectedIndex)

            'マウスキャプチャー
            Call WriteReg("General", "MouseShot_UseSize", ChkMC_UseDefSize.Checked)
            Call WriteReg("General", "MouseShot_Width", TxtMC_SizeWidth.Value)
            Call WriteReg("General", "MouseShot_Height", TxtMC_SizeHeight.Value)
            Call WriteReg("General", "MouseShot_UserSizeSave", ChkMC_SizeSave.Checked)

            'その他
            Call WriteReg("General", "NotFollow", ChkNotFollow.Checked)

            'メール
            Call WriteReg("Mail", "Server", TxtMail_Server.Text)
            Call WriteReg("Mail", "Port", TxtMail_Port.Text)
            Call WriteReg("Mail", "UserID", TxtMail_ID.Text)
            Call WriteReg("Mail", "UserPassword", TxtMail_Password.Text)
            Call WriteReg("Mail", "FromAddress", TxtMail_FromAddress.Text)
            'Call WriteReg("Mail", "ToAddress", TxtMail_ToAddress.Text)
            'Call WriteReg("Mail", "Note", TxtMail_Note.Text)
            Call WriteReg("Mail", "SendNoAccept", ChkMail_SendNoAccept.Checked)

            Return True
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
        Return False
    End Function
    Private Sub FrmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadSetting()
    End Sub
    Private Sub SetNumericValue(Value As Integer, TargetObj As NumericUpDown)
        Select Case Value
            Case Is < TargetObj.Minimum
                TargetObj.Value = TargetObj.Minimum
            Case Is > TargetObj.Maximum
                TargetObj.Value = TargetObj.Maximum
            Case Else
                TargetObj.Value = Value
        End Select
    End Sub
    Private Sub SetNumericValue(SectionName As String, KeyName As String, TargetObj As NumericUpDown)
        Dim _Tmp As Integer = CInt(ReadReg(SectionName, KeyName, enum_Type.er_Integer))
        Call SetNumericValue(_Tmp, TargetObj)
    End Sub

    Private Sub BtbCancel_Click(sender As Object, e As EventArgs) Handles BtbCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If SaveSetting() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Using FBD As New FolderBrowserDialog
        '    With FBD
        '        .ShowNewFolderButton = True
        '        If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '            TxtFolder.Text = .SelectedPath
        '        End If
        '    End With
        'End Using
        Dim OokiiDiag As New Ookii.Dialogs.VistaFolderBrowserDialog
        With OokiiDiag
            .UseDescriptionForTitle = True
            .Description = "保存フォルダ選択"
            If TxtFolder.Text <> "" AndAlso System.IO.Directory.Exists(TxtFolder.Text) Then
                .SelectedPath = TxtFolder.Text
            End If
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtFolder.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub ChkShiftUse0_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShiftUse0.CheckedChanged
        TxtShiftX0.Enabled = ChkShiftUse0.Checked
        TxtShiftY0.Enabled = ChkShiftUse0.Checked
        TxtShiftWidth0.Enabled = ChkShiftUse0.Checked
        TxtShiftHeight0.Enabled = ChkShiftUse0.Checked
    End Sub

    Private Sub ChkShiftUse1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShiftUse1.CheckedChanged
        TxtShiftX1.Enabled = ChkShiftUse1.Checked
        TxtShiftY1.Enabled = ChkShiftUse1.Checked
        TxtShiftWidth1.Enabled = ChkShiftUse1.Checked
        TxtShiftHeight1.Enabled = ChkShiftUse1.Checked
    End Sub

    Private Sub ChkShiftUse2_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShiftUse2.CheckedChanged
        TxtShiftX2.Enabled = ChkShiftUse2.Checked
        TxtShiftY2.Enabled = ChkShiftUse2.Checked
        TxtShiftWidth2.Enabled = ChkShiftUse2.Checked
        TxtShiftHeight2.Enabled = ChkShiftUse2.Checked
    End Sub

    Private Sub ChkShiftUse3_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShiftUse3.CheckedChanged
        TxtShiftX3.Enabled = ChkShiftUse3.Checked
        TxtShiftY3.Enabled = ChkShiftUse3.Checked
        TxtShiftWidth3.Enabled = ChkShiftUse3.Checked
        TxtShiftHeight3.Enabled = ChkShiftUse3.Checked
    End Sub
    ''' <summary>
    ''' 値の入替
    ''' </summary>
    ''' <typeparam name="t"></typeparam>
    ''' <param name="Value1"></param>
    ''' <param name="Value2"></param>
    ''' <remarks></remarks>
    Private Sub SwapValue(Of T)(ByRef Value1 As T, ByRef Value2 As T)
        Dim _T As T = Value1
        Value1 = Value2
        Value2 = _T
    End Sub

    Private Sub BtnSwap1_Click(sender As Object, e As EventArgs) Handles BtnSwap1.Click
        Try
            Call SwapValue(ChkShiftUse0.Checked, ChkShiftUse1.Checked)
            Call SwapValue(TxtShiftX0.Value, TxtShiftX1.Value)
            Call SwapValue(TxtShiftY0.Value, TxtShiftY1.Value)
            Call SwapValue(TxtShiftWidth0.Value, TxtShiftWidth1.Value)
            Call SwapValue(TxtShiftHeight0.Value, TxtShiftHeight1.Value)
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
        
    End Sub

    Private Sub BtnSwap2_Click(sender As Object, e As EventArgs) Handles BtnSwap2.Click
        Try
            Call SwapValue(ChkShiftUse1.Checked, ChkShiftUse2.Checked)
            Call SwapValue(TxtShiftX1.Value, TxtShiftX2.Value)
            Call SwapValue(TxtShiftY1.Value, TxtShiftY2.Value)
            Call SwapValue(TxtShiftWidth1.Value, TxtShiftWidth2.Value)
            Call SwapValue(TxtShiftHeight1.Value, TxtShiftHeight2.Value)
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
      
    End Sub

    Private Sub BtnSwap3_Click(sender As Object, e As EventArgs) Handles BtnSwap3.Click
        Try
            Call SwapValue(ChkShiftUse2.Checked, ChkShiftUse3.Checked)
            Call SwapValue(TxtShiftX2.Value, TxtShiftX3.Value)
            Call SwapValue(TxtShiftY2.Value, TxtShiftY3.Value)
            Call SwapValue(TxtShiftWidth2.Value, TxtShiftWidth3.Value)
            Call SwapValue(TxtShiftHeight2.Value, TxtShiftHeight3.Value)
        Catch ex As Exception
            MsgBox(ExMessCreater(GetStack(ex)), 48, "エラー")

        End Try
      
    End Sub

    Private Sub ChkImageTimeStamp_CheckedChanged(sender As Object, e As EventArgs) Handles ChkImageTimeStamp.CheckedChanged
        GroupBox5.Enabled = ChkImageTimeStamp.Checked
        CmbTimeStampType.Enabled = ChkImageTimeStamp.Checked
    End Sub

    Private Sub ChkMC_UseDefSize_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMC_UseDefSize.CheckedChanged
        Panel_MC.Enabled = ChkMC_UseDefSize.Checked
    End Sub

    Private Sub BtnGetMCSize_Click(sender As Object, e As EventArgs) Handles BtnGetMCSize.Click
        If Not IsNothing(_MainSeze) Then
            If MsgBox("現在のメイン画面サイズを適用しますか？？", 4 + 32, "確認") = MsgBoxResult.Yes Then
                TxtMC_SizeWidth.Value = _MainSeze.Width
                TxtMC_SizeHeight.Value = _MainSeze.Height
            End If
        End If
    End Sub

    Private Sub BtnMailSendTest_Click(sender As Object, e As EventArgs) Handles BtnMailSendTest.Click
        If SaveSetting() Then
            If MailSettingCheck() Then
                LblMail.Text = "メール送信中..."
                Application.DoEvents()
                If SendTestMail() Then
                    MsgBox("テストメールを送信しました。", 64, "情報")
                Else
                    MsgBox("テストメール送信に失敗しました。", 48, "エラー")
                End If
                LblMail.Text = ""
            End If

        End If
    End Sub

    Private Sub TxtMail_Password_GotFocus(sender As Object, e As EventArgs) Handles TxtMail_Password.GotFocus
        TxtMail_Password.PasswordChar = ""
    End Sub

    Private Sub TxtMail_Password_LostFocus(sender As Object, e As EventArgs) Handles TxtMail_Password.LostFocus
        TxtMail_Password.PasswordChar = "*"
    End Sub

    Private Sub TxtMail_Password_TextChanged(sender As Object, e As EventArgs) Handles TxtMail_Password.TextChanged

    End Sub
End Class