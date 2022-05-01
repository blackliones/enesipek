Imports System.Collections.Specialized
Public Class Form1

    Private Property sekme As Object

    Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As System.Windows.Forms.Keys) As Short
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sekme As Integer = -1
        Dim webbrowser As New WebBrowser
        sekme = sekme + 1
        TabControl1.TabPages.Add("Yeni sekme " & sekme)
        webbrowser.Navigate("www.google.com")

        webbrowser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(webbrowser)
        If My.Settings.history IsNot Nothing Then
            For Each item In My.Settings.history
                ListBox1.Items.Add(item)
            Next
        End If
        If My.Settings.history2 IsNot Nothing Then
            For Each item2 In My.Settings.history2
                ListBox1.Items.Add(item2)
            Next
        End If
        Timer1.Start()
        MsgBox("EnesBrowser'e Hoş Geldin...")
        Button10.Hide()
        Button9.Hide()
        ListBox1.Hide()
        Label7.Hide()
        TextBox2.Hide()
        Label2.Hide()
        Button8.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label7.Show()
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
        Label7.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Stop()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button10.Show()
        Button9.Show()
        Button8.Show()
        Label2.Show()
        ListBox1.Show()
        TextBox2.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Button10.Hide()
        Button9.Hide()
        ListBox1.Hide()
        TextBox2.Hide()
        Label2.Hide()
        Button8.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox2.Text = "" Then
            ListBox1.Items.Add(TextBox1.Text)
        Else
            ListBox1.Items.Add(TextBox2.Text)
        End If

        If My.Settings.history Is Nothing Then
            My.Settings.history = New StringCollection
        End If

        My.Settings.history.Clear()
        For Each item In ListBox1.Items
            My.Settings.history.Add(item)
        Next
        My.Settings.Save()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If My.Settings.history2 Is Nothing Then
            My.Settings.history2 = New StringCollection
        End If
        My.Settings.history2.Clear()
        For Each item2 In ListBox1.Items
            My.Settings.history.Remove(item2)
        Next
        My.Settings.Save()
        ListBox1.Items.Clear()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If My.Settings.history3 Is Nothing Then
            My.Settings.history3 = New StringCollection
        End If

        My.Settings.history3.Clear()
        For Each item3 In ListBox1.SelectedItems
            My.Settings.history.Remove(item3)
        Next
        My.Settings.Save()
        MsgBox("Silindi...")
        Application.Restart()



    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        System.Diagnostics.Process.Start("www.facebook.com/LoqiTeqTR")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = ListBox1.SelectedItem
    End Sub

    Private Sub RichTextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseUp
        If RichTextBox1.Text = "Not Yazabileceğiniz Yer:" Then
            RichTextBox1.Text = ""
        End If
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("www.youtube.com")
    End Sub
    Private Sub TextBox2_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox2.DragEnter
        If TextBox2.Text = "" Then
            ListBox1.Items.Add(TextBox1.Text)
        Else
            ListBox1.Items.Add(TextBox2.Text)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles gizle.Tick
        If GetAsyncKeyState(Keys.F10) Then
            Button15.PerformClick()
        End If
    End Sub

    Private Sub goster_Tick(sender As Object, e As EventArgs) Handles goster.Tick
        If GetAsyncKeyState(Keys.F11) Then
            Button14.PerformClick()
        End If
        If GetAsyncKeyState(Keys.F5) Then
            Button3.PerformClick()
        End If
        If GetAsyncKeyState(Keys.Escape) Then
            Button6.PerformClick()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Me.Opacity = (100)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Opacity = (0)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If GetAsyncKeyState(Keys.Enter) Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
        End If
    End Sub
    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.SelectAll()
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text = ""
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        sekme = sekme - 1
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim webbrowser As New WebBrowser
        webbrowser.Navigate("www.google.com")
        sekme = sekme + 1
        TabControl1.TabPages.Add("Yeni sekme" & sekme)
        TabControl1.SelectedTab = (TabControl1.TabPages(sekme))
        TabControl1.SelectedTab.Controls.Add(webbrowser)
        webbrowser.Dock = DockStyle.Fill
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("www.facebook.com")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("www.sahibinden.com")

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("www.google.com")

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate("www.twitter.com")

    End Sub
End Class
