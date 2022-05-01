Imports System.IO
Public Class Form1
    Private Sub Form_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub


    Private Sub AÇToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AÇToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        Dim a As String = OpenFileDialog1.FileName
        Dim b As String = File.ReadAllText(a)
        RichTextBox1.Text = b
    End Sub

    Private Sub KAYDETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KAYDETToolStripMenuItem.Click
        Try
            SaveFileDialog1.Filter = "Metin Belgesi (*.txt)|*.txt"
            SaveFileDialog1.ShowDialog()
            Dim a As String = SaveFileDialog1.FileName
            File.WriteAllText(a, RichTextBox1.Text)
            MsgBox("Kaydedildi!!!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Hata" & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub FARKLIKAYDETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FARKLIKAYDETToolStripMenuItem.Click

        Try
            SaveFileDialog1.Filter = "Tüm Dosyalar (*.*)|*.*"
            SaveFileDialog1.ShowDialog()
            Dim a As String = SaveFileDialog1.FileName
            File.WriteAllText(a, RichTextBox1.Text)
            MsgBox("Kaydedildi!!!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Hata" & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub GERİALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GERİALToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub KOPYALAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KOPYALAToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub YAPIŞTIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAPIŞTIRToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub KESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KESToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub YAZITİPİToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAZITİPİToolStripMenuItem.Click

        FontDialog1.ShowDialog()
        RichTextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            renk.Start()
        Else
            If CheckBox1.Checked = False Then
                renk.Stop()
                RichTextBox1.ForeColor = Color.Gold
            End If
        End If
    End Sub

    Private Sub renk_Tick(sender As Object, e As EventArgs) Handles renk.Tick

        RichTextBox1.ForeColor = Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)

    End Sub


    Private Sub YENİSAYFAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YENİSAYFAToolStripMenuItem.Click
        RichTextBox1.Clear()

    End Sub

    Private Sub İLERİALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles İLERİALToolStripMenuItem.Click
        RichTextBox1.Redo()

    End Sub

    Private Sub SAATToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAATToolStripMenuItem.Click
        RichTextBox1.SelectedText = TimeOfDay
    End Sub


    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs) Handles FontDialog1.Apply

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Label1.Text.Substring(1) + Label1.Text.Substring(0, 1)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Beyaz" Then
            RichTextBox1.ForeColor = Color.Black
            RichTextBox1.BackColor = Color.White
        End If
        If ComboBox1.SelectedItem = "Mavi" Then
            RichTextBox1.ForeColor = Color.Black
            RichTextBox1.BackColor = Color.Blue
        End If
        If ComboBox1.SelectedItem = "Siyah" Then
            RichTextBox1.ForeColor = Color.White
            RichTextBox1.BackColor = Color.Black
        End If
        If ComboBox1.SelectedItem = "Kırmızı" Then
            RichTextBox1.ForeColor = Color.Black
            RichTextBox1.BackColor = Color.Red
        End If
        If ComboBox1.SelectedItem = "Mor" Then
            RichTextBox1.ForeColor = Color.Black
            RichTextBox1.BackColor = Color.Purple
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "Kırmızı" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Red
        End If
        If ComboBox2.SelectedItem = "Yeşil" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Green
        End If
        If ComboBox2.SelectedItem = "Mavi" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Blue
        End If
        If ComboBox2.SelectedItem = "Siyah" Then
            RichTextBox1.BackColor = Color.White
            RichTextBox1.ForeColor = Color.Black

        End If
        If ComboBox2.SelectedItem = "Beyaz" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.White
        End If
        If ComboBox2.SelectedItem = "Altın" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Gold
        End If
        If ComboBox2.SelectedItem = "Sarı" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Yellow
        End If
        If ComboBox2.SelectedItem = "Mor" Then
            RichTextBox1.BackColor = Color.Black
            RichTextBox1.ForeColor = Color.Purple
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        System.Diagnostics.Process.Start("www.facebook.com/liveenes")
    End Sub

    Private Sub DÜZENToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DÜZENToolStripMenuItem.Click

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Label1.Show()
            CheckBox3.Text = "Jazzcorp Txt ON"
            CheckBox3.ForeColor = Color.Green
        Else
            Label1.Hide()
            CheckBox3.Text = "Jazzcorp Txt OFF"
            CheckBox3.ForeColor = Color.Red
        End If
    End Sub
End Class
