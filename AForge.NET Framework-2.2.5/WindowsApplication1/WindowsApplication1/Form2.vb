Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class Form2
    Private DeviceExist As Boolean = False
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice = Nothing

    Private Sub getCamList()
        Try
            videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            ComboBox1.Items.Clear()
            If (Me.videoDevices.Count = 0) Then
                Throw New ApplicationException
            End If

            DeviceExist = True
            For Each device As FilterInfo In Me.videoDevices
                ComboBox1.Items.Add(device.Name)
            Next
            ComboBox1.SelectedIndex = 0
            'make dafault to first cam
        Catch ex As ApplicationException
            DeviceExist = False
            ComboBox1.Items.Add("No capture device on your system")
        End Try

    End Sub

    'refresh button
    Private Sub rfsh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rfsh.Click
        Call getCamList()
    End Sub

    'toggle start and stop button
    Private Sub start_Click(ByVal sender As Object, ByVal e As EventArgs) Handles start.Click
        If (start.Text = "&Start") Then
            If DeviceExist Then
                videoSource = New VideoCaptureDevice(videoDevices(ComboBox1.SelectedIndex).MonikerString)
                AddHandler videoSource.NewFrame, AddressOf video_NewFrame
                Call CloseVideoSource()
                videoSource.DesiredFrameSize = New Size(160, 120)
                'videoSource.DesiredFrameRate = 10;
                Call videoSource.Start()
                Label2.Text = "Device running..."
                start.Text = "&Stop"
                Timer1.Enabled = True
            Else
                Label2.Text = "Error: No Device selected."
            End If

        ElseIf videoSource.IsRunning Then
            Timer1.Enabled = False
            Call CloseVideoSource()
            Label2.Text = "Device stopped."
            start.Text = "&Start"
        End If

    End Sub

    'eventhandler if new frame is ready
    Private Sub video_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Dim img As Bitmap = CType(eventArgs.Frame.Clone, Bitmap)
        'do processing here
        PictureBox1.Image = img
    End Sub

    'close the device safely
    Private Sub CloseVideoSource()
        If Not (videoSource Is Nothing) Then
            If videoSource.IsRunning Then
                videoSource.SignalToStop()
                videoSource = Nothing
            End If
        End If
    End Sub

    'get total received frame at 1 second tick
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Label2.Text = ("Device running... " + (Me.videoSource.FramesReceived.ToString + " FPS"))
    End Sub

    'prevent sudden close while device is running
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Call CloseVideoSource()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class