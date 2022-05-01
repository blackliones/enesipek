Public Class Form1

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.start()


        Shell("Metin2Client.bin")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer2.Start()
        Shell("Metin2")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = 1
            Timer1.Stop()

        Else
            ProgressBar1.Value = ProgressBar1.Value + 1

        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ProgressBar2.Value = ProgressBar2.Maximum Then
            ProgressBar2.Value = 1
            Timer1.Stop()
            MsgBox("METİN2 TORRENT GÜNCELLEME BAŞLATILIYOR...")

        Else
            ProgressBar2.Value = ProgressBar2.Value + 1

        End If
    End Sub
End Class
