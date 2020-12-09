Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            End
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            '使用OSが３２ビットか６４ビットかを判別する
            If System.Environment.Is64BitOperatingSystem Then
                _Is64Bit = True
                Console.WriteLine("64ビットOSです。")
            Else
                _Is64Bit = False
                Console.WriteLine("32ビットOSです。")
            End If
            If My.Settings.UpdateRequired = False Then
                My.Settings.Upgrade()
                My.Settings.UpdateRequired = True
                My.Settings.Save()
            End If
        End Sub
    End Class


End Namespace

