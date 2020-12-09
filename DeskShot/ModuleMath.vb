''' <summary>
''' 画像回転用の座標計算を行う
''' </summary>
''' <remarks></remarks>
Module ModuleMath
    ''' <summary>
    ''' 指定座標の回転後の座標を求める
    ''' </summary>
    ''' <param name="Value">回転前座標</param>
    ''' <param name="Rot">回転角（度）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RotP(Value As PointF, Rot As Integer) As PointF
        '回転前の中心からの距離
        Dim R As Double = Math.Sqrt(((Value.X - 0) ^ 2) + ((Value.Y - 0) ^ 2))
        '回転前の中心からの角度
        Dim Ang_Deg As Double = Math.Atan2(Value.Y, Value.X) * (180 / Math.PI)

        '角度の加算
        Ang_Deg = Ang_Deg + Rot

        'ラジアンに変換
        Dim radian As Double = Ang_Deg * (Math.PI / 180)
        '回転後の半径から座標を求める
        Dim y2 As Double = Math.Sin(radian) * R
        Dim x2 As Double = Math.Cos(radian) * R

        Return New PointF(x2, y2)
    End Function
    ''' <summary>
    ''' 指定座標の回転後の座標を求める
    ''' </summary>
    ''' <param name="Org">回転原点座標</param>
    ''' <param name="Value">回転座標</param>
    ''' <param name="Rot">回転角（度）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RotP(Org As PointF, Value As PointF, Rot As Integer) As PointF
        '回転前の中心からの距離
        Dim R As Double = Math.Sqrt(((Value.X - Org.X) ^ 2) + ((Value.Y - Org.Y) ^ 2))
        '回転前の中心からの角度
        Dim Ang_Deg As Double = Math.Atan2(Value.Y - Org.Y, Value.X - Org.X) * (180 / Math.PI)

        '角度の加算
        Ang_Deg = Ang_Deg + Rot

        'ラジアンに変換
        Dim radian As Double = Ang_Deg * (Math.PI / 180)
        '回転後の半径から座標を求める
        Dim y2 As Double = Math.Sin(radian) * R
        Dim x2 As Double = Math.Cos(radian) * R

        Return New PointF(x2 + Org.X, y2 + Org.Y)
    End Function
    ''' <summary>
    ''' 指定座標の回転後の座標を求める
    ''' </summary>
    ''' <param name="ValueX">回転前X座標</param>
    ''' <param name="ValueY">回転前Y座標</param>
    ''' <param name="Rot">回転角（度）</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RotP(ValueX As Double, ValueY As Double, Rot As Integer) As PointF
        Return RotP(New PointF(ValueX, ValueY), Rot)

    End Function
    ''' <summary>
    ''' 座標点を中心とする画像回転用３点計算
    ''' </summary>
    ''' <param name="X">原点（回転中心）Ｘ座標</param>
    ''' <param name="Y">原点（回転中心）Ｙ座標</param>
    ''' <param name="ImageWidth">画像幅</param>
    ''' <param name="ImageHeight">画像高さ</param>
    ''' <param name="Angle">回転角</param>
    ''' <returns> {左上座標, 右上座標, 左下座標}</returns>
    ''' <remarks>
    ''' ［使用方法］
    ''' Dim destinationPoints() As PointF = Calc3Point(_BoxSPosi.X, _BoxSPosi.Y, img2.Width * imgz, img2.Height * imgz, imga)
    ''' g.DrawImage(img2, destinationPoints)
    ''' </remarks>
    Public Function Calc3Point(X As Integer, Y As Integer, ImageWidth As Integer, ImageHeight As Integer, Angle As Integer) As PointF()
        Dim P0 As PointF = New PointF(X, Y) '座標原点

        Dim P1 As PointF = New PointF(X - (ImageWidth / 2), Y - (ImageHeight / 2)) '回転前左上座標
        Dim P2 As PointF = New PointF(X + (ImageWidth / 2), Y - (ImageHeight / 2)) '回転前右上座標
        Dim P3 As PointF = New PointF(X - (ImageWidth / 2), Y + (ImageHeight / 2)) '回転前左下座標

        Dim PX1 As PointF = RotP(P0, P1, Angle) '回転後左上座標
        Dim PX2 As PointF = RotP(P0, P2, Angle) '回転後右上座標
        Dim PX3 As PointF = RotP(P0, P3, Angle) '回転後左下座標

        Return {PX1, PX2, PX3}
    End Function
End Module
