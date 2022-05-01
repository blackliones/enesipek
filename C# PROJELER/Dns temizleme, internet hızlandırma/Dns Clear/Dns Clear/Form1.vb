Public Class Form1
    Private Sub OriginButton1_Click(sender As Object, e As EventArgs) Handles OriginButton1.Click
        Me.Close()

    End Sub
    Private Sub SecondOriginButton1_Click(sender As Object, e As EventArgs) Handles SecondOriginButton1.Click
        RichTextBox1.Text = "ipconfig /release"
        System.Threading.Thread.Sleep(1000)
        RichTextBox1.Text = RichTextBox1.Text + vbCrLf & "ipconfig /flushdns"

        RichTextBox1.Text = RichTextBox1.Text + vbCrLf & "ipconfig /renew..."
        Timer1.Start()
        Label1.ForeColor = Color.Green
        Label1.Text = "Dns Cleaning Up.."
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.ForeColor = Color.Crimson
        Label1.Text = "Dns Not Cleared"
        RichTextBox1.ForeColor = Color.Crimson
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Shell("ipconfig /release")
        System.Threading.Thread.Sleep(1000)
        Shell("ipconfig /flushdns")
        System.Threading.Thread.Sleep(1000)
        Shell("ipconfig /renew")
        System.Threading.Thread.Sleep(1000)
        Label1.Text = "Dns Cleaned √"
        RichTextBox1.Text = RichTextBox1.Text + vbCrLf & "Clear Success"
        RichTextBox1.ForeColor = Color.Green
        Timer1.Stop()
    End Sub
End Class
