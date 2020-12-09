Imports System.IO
Public Class FrmViewer1
    Dim _FileName As String
    Property TargetFileName As String
        Get
            Return _FileName
        End Get
        Set(value As String)
            _FileName = value
        End Set
    End Property

    Private Sub FrmViewer1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(_FileName) Then
            If System.IO.File.Exists(_FileName) Then
                WebBrowser1.Url = New Uri(_FileName)
                Me.Text = System.IO.Path.GetFileName(_FileName)
            End If
        End If
    End Sub

    Private Sub SasaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuFileClip_Click(sender As Object, e As EventArgs) Handles MenuFileClip.Click
        If File.Exists(_FileName) Then
            Dim f As System.Collections.Specialized.StringCollection
            f = New System.Collections.Specialized.StringCollection()
            f.Add(_FileName)        ' ファイル

            ' ファイルやフォルダをクリップボードにコピーする
            System.Windows.Forms.Clipboard.SetFileDropList(f)
            MsgBox("クリップボードへ送りました", 64, "情報")
        End If
    End Sub


End Class