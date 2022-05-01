<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OriginTheme1 = New Dns_Clear.OriginTheme()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SecondOriginButton1 = New Dns_Clear.SecondOriginButton()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.OriginButton1 = New Dns_Clear.OriginButton()
        Me.OriginTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'OriginTheme1
        '
        Me.OriginTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.OriginTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.OriginTheme1.Controls.Add(Me.Label1)
        Me.OriginTheme1.Controls.Add(Me.SecondOriginButton1)
        Me.OriginTheme1.Controls.Add(Me.RichTextBox1)
        Me.OriginTheme1.Controls.Add(Me.OriginButton1)
        Me.OriginTheme1.Customization = "JiYn//////8="
        Me.OriginTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OriginTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.OriginTheme1.Image = Nothing
        Me.OriginTheme1.Location = New System.Drawing.Point(0, 0)
        Me.OriginTheme1.Movable = True
        Me.OriginTheme1.Name = "OriginTheme1"
        Me.OriginTheme1.NoRounding = False
        Me.OriginTheme1.Sizable = True
        Me.OriginTheme1.Size = New System.Drawing.Size(359, 177)
        Me.OriginTheme1.SmartBounds = True
        Me.OriginTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.OriginTheme1.TabIndex = 0
        Me.OriginTheme1.Text = "Clear"
        Me.OriginTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.OriginTheme1.Transparent = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Crimson
        Me.Label1.Location = New System.Drawing.Point(236, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Not Cleared"
        '
        'SecondOriginButton1
        '
        Me.SecondOriginButton1.Customization = "wMDA/4CAgP///////////w=="
        Me.SecondOriginButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SecondOriginButton1.Image = Nothing
        Me.SecondOriginButton1.Location = New System.Drawing.Point(12, 38)
        Me.SecondOriginButton1.Name = "SecondOriginButton1"
        Me.SecondOriginButton1.NoRounding = False
        Me.SecondOriginButton1.Size = New System.Drawing.Size(113, 23)
        Me.SecondOriginButton1.TabIndex = 4
        Me.SecondOriginButton1.Text = "Start Cleaner"
        Me.SecondOriginButton1.Transparent = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Green
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 67)
        Me.RichTextBox1.MaxLength = 0
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(335, 98)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'OriginButton1
        '
        Me.OriginButton1.Customization = "AKX/////////////"
        Me.OriginButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.OriginButton1.Image = Nothing
        Me.OriginButton1.Location = New System.Drawing.Point(337, 2)
        Me.OriginButton1.Name = "OriginButton1"
        Me.OriginButton1.NoRounding = False
        Me.OriginButton1.Size = New System.Drawing.Size(19, 23)
        Me.OriginButton1.TabIndex = 2
        Me.OriginButton1.Text = "X"
        Me.OriginButton1.Transparent = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 177)
        Me.Controls.Add(Me.OriginTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Dns Clear"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.OriginTheme1.ResumeLayout(False)
        Me.OriginTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OriginTheme1 As OriginTheme
    Friend WithEvents OriginButton1 As OriginButton
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents SecondOriginButton1 As SecondOriginButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
End Class
