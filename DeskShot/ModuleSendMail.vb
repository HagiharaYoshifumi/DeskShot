Module ModuleSendMail
    ''' <summary>
    ''' 設定確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MailSettingCheck() As Boolean
        Select Case True
            Case ReadReg("Mail", "Server") = ""
                Return False
            Case ReadReg("Mail", "Port") = ""
                Return False
            Case Not IsNumeric(ReadReg("Mail", "Port"))
                Return False
            Case CInt(ReadReg("Mail", "Port")) = 0
                Return False
            Case ReadReg("Mail", "UserID") = ""
                Return False
            Case ReadReg("Mail", "UserPassword") = ""
                Return False
            Case ReadReg("Mail", "FromAddress") = ""
                Return False
                'Case Is = ReadReg("Mail", "ToAddress") = ""
                '    Return False
        End Select
        Return True
    End Function
    ''' <summary>
    ''' メール送信
    ''' </summary>
    ''' <param name="FL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMail(FL As String, ToAddress As String, Note As String)
        'https://dobon.net/vb/dotnet/internet/smtpmail2.html

        If MailSettingCheck() Then
            If System.IO.File.Exists(FL) Then
                Dim _Server As String = ReadReg("Mail", "Server")
                Dim _Port As Integer = CInt(ReadReg("Mail", "Port"))
                Dim _ID As String = ReadReg("Mail", "UserID")
                Dim _Password As String = ReadReg("Mail", "UserPassword")
                Dim _FromAddress As String = ReadReg("Mail", "FromAddress")
                Dim _ToAddress As String = ReadReg("Mail", "ToAddress")
                Dim _Note As String = Note ' ReadReg("Mail", "Note")
                Try
                    'MailMessageの作成
                    Using msg As New System.Net.Mail.MailMessage()
                        '送信者
                        msg.From = New System.Net.Mail.MailAddress(_FromAddress)
                        '宛先
                        msg.To.Add(New System.Net.Mail.MailAddress(ToAddress))
                        ''あて先をもう一人追加
                        'msg.To.Add(New System.Net.Mail.MailAddress("sato@xxx.xxx"))
                        ''CC
                        'msg.CC.Add(New System.Net.Mail.MailAddress("cc@xxx.xxx"))
                        ''BCC
                        'msg.Bcc.Add(New System.Net.Mail.MailAddress("bcc@xxx.xxx"))
                        ''ReplyTo
                        'msg.ReplyToList.Add(New System.Net.Mail.MailAddress("replyto@xxx.xxx"))
                        ''.NET Framework 3.5以前では、以下のようにする
                        ''msg.ReplyTo = New System.Net.Mail.MailAddress("replyto@xxx.xxx")
                        'Sender
                        msg.Sender = New System.Net.Mail.MailAddress(_FromAddress)

                        '件名
                        msg.Subject = String.Format("[DeskShot]ショット画像送付({0:yyyyMMddHHmmss})", Now)
                        '本文
                        If _Note = "" Then
                            msg.Body = "このメールはDeskShotにて切り取られた画像送付メールです。"
                        Else
                            msg.Body = _Note
                        End If

                        '優先順位を「重要」にする
                        'msg.Priority = System.Net.Mail.MailPriority.High
                        'メールの配達が遅れたとき、失敗したとき、正常に配達されたときに通知する
                        msg.DeliveryNotificationOptions = _
                            System.Net.Mail.DeliveryNotificationOptions.Delay Or _
                            System.Net.Mail.DeliveryNotificationOptions.OnFailure Or _
                            System.Net.Mail.DeliveryNotificationOptions.OnSuccess

                        '添付ファイルを付ける
                        Dim AttachFile As New System.Net.Mail.Attachment(FL)
                        msg.Attachments.Add(AttachFile)

                        Using sc As New System.Net.Mail.SmtpClient()
                            'SMTPサーバーなどを設定する
                            sc.Host = _Server
                            sc.Port = _Port
                            sc.EnableSsl = False
                            sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                            'ユーザー名とパスワードを設定する
                            sc.Credentials = New System.Net.NetworkCredential(_ID, _Password)
                            sc.Timeout = 10000

                            'メッセージを送信する
                            sc.Send(msg)

                        End Using
                    End Using
                    Return True
                Catch ex As Exception

                End Try
            Else

            End If

        Else

        End If
        Return False


    End Function
    ''' <summary>
    ''' テストメール送信
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendTestMail()
        'https://dobon.net/vb/dotnet/internet/smtpmail2.html

        If MailSettingCheck() Then
            Dim _Server As String = ReadReg("Mail", "Server")
            Dim _Port As Integer = CInt(ReadReg("Mail", "Port"))
            Dim _ID As String = ReadReg("Mail", "UserID")
            Dim _Password As String = ReadReg("Mail", "UserPassword")
            Dim _FromAddress As String = ReadReg("Mail", "FromAddress")
            Dim _ToAddress As String = ReadReg("Mail", "ToAddress")
            Dim _Note As String = ReadReg("Mail", "Note")
            Try
                'MailMessageの作成
                Using msg As New System.Net.Mail.MailMessage()
                    '送信者
                    msg.From = New System.Net.Mail.MailAddress(_FromAddress)
                    '宛先
                    msg.To.Add(New System.Net.Mail.MailAddress(_ToAddress))
                    'Sender
                    msg.Sender = New System.Net.Mail.MailAddress(_FromAddress)
                    '件名
                    msg.Subject = String.Format("[DeskShot]テストメール({0:yyyyMMddHHmmss})", Now)
                    '本文
                    msg.Body = "このメールはDeskShotnoのテストメールです。"
                    

                    '優先順位を「重要」にする
                    'msg.Priority = System.Net.Mail.MailPriority.High
                    'メールの配達が遅れたとき、失敗したとき、正常に配達されたときに通知する
                    msg.DeliveryNotificationOptions = _
                        System.Net.Mail.DeliveryNotificationOptions.Delay Or _
                        System.Net.Mail.DeliveryNotificationOptions.OnFailure Or _
                        System.Net.Mail.DeliveryNotificationOptions.OnSuccess

                    Using sc As New System.Net.Mail.SmtpClient()
                        'SMTPサーバーなどを設定する
                        sc.Host = _Server
                        sc.Port = _Port
                        sc.EnableSsl = False
                        sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                        'ユーザー名とパスワードを設定する
                        sc.Credentials = New System.Net.NetworkCredential(_ID, _Password)
                        sc.Timeout = 10000

                        'メッセージを送信する
                        sc.Send(msg)

                    End Using
                End Using
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, 48, "送信エラー内容")
            End Try
        Else

        End If
        Return False


    End Function

End Module
