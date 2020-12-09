Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Module Module1

    Public Const SRCCOPY As Integer = 13369376
    Public Const CAPTUREBLT As Integer = 1073741824

    <DllImport("user32.dll")> _
    Public Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")> _
    Public Function BitBlt(ByVal hDestDC As IntPtr, _
        ByVal x As Integer, ByVal y As Integer, _
        ByVal nWidth As Integer, ByVal nHeight As Integer, _
        ByVal hSrcDC As IntPtr, _
        ByVal xSrc As Integer, ByVal ySrc As Integer, _
        ByVal dwRop As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Function ReleaseDC(ByVal hwnd As IntPtr, _
        ByVal hdc As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' プライマリスクリーンの画像を取得する
    ''' </summary>
    ''' <returns>プライマリスクリーンの画像</returns>
    Public Function CaptureScreen() As Bitmap
        'プライマリモニタのデバイスコンテキストを取得
        Dim disDC As IntPtr = GetDC(IntPtr.Zero)
        'Bitmapの作成
        Dim bmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, 0, 0, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(IntPtr.Zero, disDC)

        Return bmp
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    <DllImport("user32.dll")> _
    Public Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Function GetWindowRect(ByVal hwnd As IntPtr, _
    ByRef lpRect As RECT) As Integer
    End Function
    <DllImport("dwmapi.dll")> _
    Public Function DwmGetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As RECT, ByVal cbAttribute As Integer) As Integer

    End Function

    ''' <summary>
    ''' アクティブなウィンドウの画像を取得する
    ''' </summary>
    ''' <returns>アクティブなウィンドウの画像</returns>
    Public Function CaptureActiveWindow(Value As PosiShift_Collection) As Bitmap

        Dim _ShiftX As Integer = Value.X
        Dim _ShiftY As Integer = Value.Y
        Dim _ShiftHeight As Integer = Value.Height
        Dim _SiiftWidth As Integer = Value.Width

        'アクティブなウィンドウのデバイスコンテキストを取得
        Dim hWnd As IntPtr = GetForegroundWindow()
        Dim winDC As IntPtr = GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New RECT
        'GetWindowRect(hWnd, winRect)
        Dim DWMWA_EXTENDED_FRAME_BOUNDS As Integer = 9
        DwmGetWindowAttribute(hWnd, DWMWA_EXTENDED_FRAME_BOUNDS, winRect, 4 * 4)

        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.right - winRect.left + _SiiftWidth, winRect.bottom - winRect.top + _ShiftHeight)
        'Dim bmp As New Bitmap(100, 100)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0 - _ShiftX, 0 - _ShiftY, bmp.Width, bmp.Height, winDC, 0, 0, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(hWnd, winDC)

        Return bmp
    End Function

    Public Function CaptureAria(Top As Integer, Left As Integer, Width As Integer, Height As Integer) As Bitmap
        'プライマリモニタのデバイスコンテキストを取得
        Dim disDC As IntPtr = GetDC(IntPtr.Zero)
        'Bitmapの作成
        Dim bmp As New Bitmap(Width, Height)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, Top, Left, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(IntPtr.Zero, disDC)

        Return bmp
    End Function
End Module
Public Class PosiShift_Collection
    Public IsUse As Boolean
    Public X As Integer
    Public Y As Integer
    Public Width As Integer
    Public Height As Integer
    Sub New()
        Me.IsUse = False
        Me.X = 0
        Me.Y = 0
        Me.Width = 0
        Me.Height = 0
    End Sub
    Sub New(Use As Boolean, X As Integer, Y As Integer, Width As Integer, Height As Integer)
        Me.IsUse = Use
        Me.X = X
        Me.Y = Y
        Me.Width = Width
        Me.Height = Height
    End Sub
End Class