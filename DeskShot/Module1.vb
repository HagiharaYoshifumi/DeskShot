Imports System.Drawing
Imports System.IO

Module Module1

    ''' <summary>
    ''' 複数の画像をGIFアニメーションとして保存する
    ''' </summary>
    ''' <param name="fileName">保存先のファイルのパス。</param>
    ''' <param name="baseImages">GIFアニメにする画像。</param>
    ''' <param name="delayTime">遅延時間（100分の1秒単位）。</param>
    ''' <param name="loopCount">繰り返す回数。0で無限。</param>
    Public Sub SaveAnimatedGif(ByVal fileName As String, ByVal baseImages As Bitmap(), ByVal delayTime As UInt16, ByVal loopCount As UInt16)
        '書き込み先のファイルを開く
        Dim writerFs As New FileStream(fileName, _
            FileMode.Create, FileAccess.Write, FileShare.None)
        'BinaryWriterで書き込む
        Dim writer As New BinaryWriter(writerFs)

        Dim ms As New MemoryStream()
        Dim hasGlobalColorTable As Boolean = False
        Dim colorTableSize As Integer = 0

        Dim imagesCount As Integer = baseImages.Length
        For i As Integer = 0 To imagesCount - 1
            '画像をGIFに変換して、MemoryStreamに入れる
            Dim bmp As Bitmap = baseImages(i)
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            ms.Position = 0

            If i = 0 Then
                'ヘッダを書き込む
                'Header
                writer.Write(ReadBytes(ms, 6))

                'Logical Screen Descriptor
                Dim screenDescriptor As Byte() = ReadBytes(ms, 7)
                'Global Color Tableがあるか確認
                If (screenDescriptor(4) And &H80) <> 0 Then
                    'Color Tableのサイズを取得
                    colorTableSize = screenDescriptor(4) And &H7
                    hasGlobalColorTable = True
                Else
                    hasGlobalColorTable = False
                End If
                'Global Color Tableを使わない
                '広域配色表フラグと広域配色表の寸法を消す
                screenDescriptor(4) = CByte(screenDescriptor(4) And &H78)
                writer.Write(screenDescriptor)

                'Application Extension
                writer.Write(GetApplicationExtension(loopCount))
            Else
                'HeaderとLogical Screen Descriptorをスキップ
                ms.Position += 6 + 7
            End If

            Dim colorTable As Byte() = Nothing
            If hasGlobalColorTable Then
                'Color Tableを取得
                colorTable = ReadBytes(ms, CInt(Math.Pow(2, colorTableSize + 1)) * 3)
            End If

            'Graphics Control Extension
            writer.Write(GetGraphicControlExtension(delayTime))
            '基のGraphics Control Extensionをスキップ
            If ms.GetBuffer()(ms.Position) = &H21 Then
                ms.Position += 8
            End If

            'Image Descriptor
            Dim imageDescriptor As Byte() = ReadBytes(ms, 10)
            If Not hasGlobalColorTable Then
                'Local Color Tableを持っているか確認
                If (imageDescriptor(9) And &H80) = 0 Then
                    Throw New Exception("Not found color table.")
                End If
                'Color Tableのサイズを取得
                colorTableSize = imageDescriptor(9) And 7
                'Color Tableを取得
                colorTable = ReadBytes(ms, CInt(Math.Pow(2, colorTableSize + 1)) * 3)
            End If
            '狭域配色表フラグ (Local Color Table Flag) と狭域配色表の寸法を追加
            imageDescriptor(9) = CByte(imageDescriptor(9) Or &H80 Or colorTableSize)
            writer.Write(imageDescriptor)

            'Local Color Tableを書き込む
            writer.Write(colorTable)

            'Image Dataを書き込む (終了部は書き込まない)
            writer.Write(ReadBytes(ms, CInt(ms.Length - ms.Position - 1)))

            If i = imagesCount - 1 Then
                '終了部 (Trailer)
                writer.Write(CByte(&H3B))
            End If

            'MemoryStreamをリセット
            ms.SetLength(0)
        Next

        '後始末
        ms.Close()
        writer.Close()
        writerFs.Close()
    End Sub

    ''' <summary>
    ''' MemoryStreamの現在の位置から指定されたサイズのバイト配列を読み取る
    ''' </summary>
    ''' <param name="ms">読み取るMemoryStream</param>
    ''' <param name="count">読み取るバイトのサイズ</param>
    ''' <returns>読み取れたバイト配列</returns>
    Private Function ReadBytes(ByVal ms As MemoryStream, ByVal count As Integer) As Byte()
        Dim bs As Byte() = New Byte(count - 1) {}
        ms.Read(bs, 0, count)
        Return bs
    End Function

    ''' <summary>
    ''' Netscape Application Extensionブロックを返す。
    ''' </summary>
    ''' <param name="loopCount">繰り返す回数。0で無限。</param>
    ''' <returns>Netscape Application Extensionブロックのbyte配列。</returns>
    Private Function GetApplicationExtension(ByVal loopCount As UInt16) As Byte()
        Dim bs As Byte() = New Byte(18) {}

        '拡張導入符 (Extension Introducer)
        bs(0) = &H21
        'アプリケーション拡張ラベル (Application Extension Label)
        bs(1) = &HFF
        'ブロック寸法 (Block Size)
        bs(2) = &HB
        'アプリケーション識別名 (Application Identifier)
        bs(3) = CByte(AscW("N"c))
        bs(4) = CByte(AscW("E"c))
        bs(5) = CByte(AscW("T"c))
        bs(6) = CByte(AscW("S"c))
        bs(7) = CByte(AscW("C"c))
        bs(8) = CByte(AscW("A"c))
        bs(9) = CByte(AscW("P"c))
        bs(10) = CByte(AscW("E"c))
        'アプリケーション確証符号 (Application Authentication Code)
        bs(11) = CByte(AscW("2"c))
        bs(12) = CByte(AscW("."c))
        bs(13) = CByte(AscW("0"c))
        'データ副ブロック寸法 (Data Sub-block Size)
        bs(14) = &H3
        '詰め込み欄 [ネットスケープ拡張コード (Netscape Extension Code)]
        bs(15) = &H1
        '繰り返し回数 (Loop Count)
        Dim loopCountBytes As Byte() = BitConverter.GetBytes(loopCount)
        bs(16) = loopCountBytes(0)
        bs(17) = loopCountBytes(1)
        'ブロック終了符 (Block Terminator)
        bs(18) = &H0

        Return bs
    End Function

    ''' <summary>
    ''' Graphic Control Extensionブロックを返す。
    ''' </summary>
    ''' <param name="delayTime">遅延時間（100分の1秒単位）。</param>
    ''' <returns>Graphic Control Extensionブロックのbyte配列。</returns>
    Private Function GetGraphicControlExtension(ByVal delayTime As UInt16) As Byte()
        Dim bs As Byte() = New Byte(7) {}

        '拡張導入符 (Extension Introducer)
        bs(0) = &H21
        'グラフィック制御ラベル (Graphic Control Label)
        bs(1) = &HF9
        'ブロック寸法 (Block Size)
        bs(2) = &H4
        '詰め込み欄 透過色指標を使う時は1
        bs(3) = &H0
        '遅延時間 (Delay Time)
        Dim delayTimeBytes As Byte() = BitConverter.GetBytes(delayTime)
        bs(4) = delayTimeBytes(0)
        bs(5) = delayTimeBytes(1)
        '透過色指標 (Transparency Index, Transparent Color Index)
        bs(6) = &H0
        'ブロック終了符 (Block Terminator)
        bs(7) = &H0

        Return bs
    End Function
End Module
