<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmXCABundle
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.LblXCA = New System.Windows.Forms.Label()
        Me.TxtFileXCA = New System.Windows.Forms.TextBox()
        Me.CmdFileXCA = New System.Windows.Forms.Button()
        Me.TvCerts = New System.Windows.Forms.TreeView()
        Me.LblPEM = New System.Windows.Forms.Label()
        Me.TxtPEM = New System.Windows.Forms.TextBox()
        Me.CmdFilePEM = New System.Windows.Forms.Button()
        Me.TxtInfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CmdClose
        '
        Me.CmdClose.Location = New System.Drawing.Point(466, 335)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(85, 27)
        Me.CmdClose.TabIndex = 8
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'LblXCA
        '
        Me.LblXCA.AutoSize = True
        Me.LblXCA.Location = New System.Drawing.Point(17, 17)
        Me.LblXCA.Name = "LblXCA"
        Me.LblXCA.Size = New System.Drawing.Size(44, 13)
        Me.LblXCA.TabIndex = 0
        Me.LblXCA.Text = "XCA file"
        '
        'TxtFileXCA
        '
        Me.TxtFileXCA.Location = New System.Drawing.Point(112, 13)
        Me.TxtFileXCA.Name = "TxtFileXCA"
        Me.TxtFileXCA.Size = New System.Drawing.Size(315, 20)
        Me.TxtFileXCA.TabIndex = 1
        '
        'CmdFileXCA
        '
        Me.CmdFileXCA.Location = New System.Drawing.Point(433, 14)
        Me.CmdFileXCA.Name = "CmdFileXCA"
        Me.CmdFileXCA.Size = New System.Drawing.Size(35, 19)
        Me.CmdFileXCA.TabIndex = 2
        Me.CmdFileXCA.Text = "..."
        Me.CmdFileXCA.UseVisualStyleBackColor = True
        '
        'TvCerts
        '
        Me.TvCerts.CheckBoxes = True
        Me.TvCerts.Location = New System.Drawing.Point(112, 71)
        Me.TvCerts.Name = "TvCerts"
        Me.TvCerts.Size = New System.Drawing.Size(315, 291)
        Me.TvCerts.TabIndex = 6
        '
        'LblPEM
        '
        Me.LblPEM.AutoSize = True
        Me.LblPEM.Location = New System.Drawing.Point(17, 49)
        Me.LblPEM.Name = "LblPEM"
        Me.LblPEM.Size = New System.Drawing.Size(46, 13)
        Me.LblPEM.TabIndex = 3
        Me.LblPEM.Text = "PEM file"
        '
        'TxtPEM
        '
        Me.TxtPEM.Location = New System.Drawing.Point(112, 45)
        Me.TxtPEM.Name = "TxtPEM"
        Me.TxtPEM.Size = New System.Drawing.Size(315, 20)
        Me.TxtPEM.TabIndex = 4
        '
        'CmdFilePEM
        '
        Me.CmdFilePEM.Location = New System.Drawing.Point(433, 46)
        Me.CmdFilePEM.Name = "CmdFilePEM"
        Me.CmdFilePEM.Size = New System.Drawing.Size(35, 19)
        Me.CmdFilePEM.TabIndex = 5
        Me.CmdFilePEM.Text = "..."
        Me.CmdFilePEM.UseVisualStyleBackColor = True
        '
        'TxtInfo
        '
        Me.TxtInfo.Enabled = False
        Me.TxtInfo.Location = New System.Drawing.Point(433, 71)
        Me.TxtInfo.Multiline = True
        Me.TxtInfo.Name = "TxtInfo"
        Me.TxtInfo.Size = New System.Drawing.Size(166, 176)
        Me.TxtInfo.TabIndex = 7
        '
        'FrmXCABundle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 450)
        Me.Controls.Add(Me.TxtInfo)
        Me.Controls.Add(Me.TvCerts)
        Me.Controls.Add(Me.CmdFilePEM)
        Me.Controls.Add(Me.CmdFileXCA)
        Me.Controls.Add(Me.TxtPEM)
        Me.Controls.Add(Me.LblPEM)
        Me.Controls.Add(Me.TxtFileXCA)
        Me.Controls.Add(Me.LblXCA)
        Me.Controls.Add(Me.CmdClose)
        Me.Name = "FrmXCABundle"
        Me.Text = "PEM bundle From XCA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmdClose As Button
    Friend WithEvents LblXCA As Label
    Friend WithEvents TxtFileXCA As TextBox
    Friend WithEvents CmdFileXCA As Button
    Friend WithEvents TvCerts As TreeView
    Friend WithEvents LblPEM As Label
    Friend WithEvents TxtPEM As TextBox
    Friend WithEvents CmdFilePEM As Button
    Friend WithEvents TxtInfo As TextBox
End Class
