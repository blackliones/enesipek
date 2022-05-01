Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Timer1.Interval = 100
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Interaction.Shell("taskkill /F /IM " + ListBox1.SelectedItem + ".exe", AppWinStyle.MinimizedFocus, False, -1)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ListBox1.Items.Clear()
        For Each döngü As Process In Process.GetProcesses
            ListBox1.Items.Add(döngü.ProcessName)
            Timer1.Interval = 5000
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = ListBox1.SelectedItem
        If ListBox1.SelectionMode Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        For Each döngü As Process In Process.GetProcesses
            ListBox1.Items.Add(döngü.ProcessName)
            Timer1.Interval = 10000
        Next
        For i As Int32 = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i) = TextBox1.Text Then
                ListBox1.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
End Class
