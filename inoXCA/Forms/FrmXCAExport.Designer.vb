<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmXCAExport
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
        Me.TvCerts = New System.Windows.Forms.TreeView()
        Me.CmdFilePEM = New System.Windows.Forms.Button()
        Me.CmdFileXCA = New System.Windows.Forms.Button()
        Me.TxtPEM = New System.Windows.Forms.TextBox()
        Me.LblPEM = New System.Windows.Forms.Label()
        Me.TxtFileXCA = New System.Windows.Forms.TextBox()
        Me.LblXCA = New System.Windows.Forms.Label()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.gpType = New System.Windows.Forms.GroupBox()
        Me.RbP12Chain = New System.Windows.Forms.RadioButton()
        Me.RbP12 = New System.Windows.Forms.RadioButton()
        Me.RbPrivKey = New System.Windows.Forms.RadioButton()
        Me.LblPWDB = New System.Windows.Forms.Label()
        Me.TxtPWDB = New System.Windows.Forms.TextBox()
        Me.LblPWFile = New System.Windows.Forms.Label()
        Me.TxtPWFile = New System.Windows.Forms.TextBox()
        Me.gpType.SuspendLayout()
        Me.SuspendLayout()
        '
        'TvCerts
        '
        Me.TvCerts.CheckBoxes = True
        Me.TvCerts.Location = New System.Drawing.Point(172, 128)
        Me.TvCerts.Name = "TvCerts"
        Me.TvCerts.Size = New System.Drawing.Size(315, 291)
        Me.TvCerts.TabIndex = 11
        '
        'CmdFilePEM
        '
        Me.CmdFilePEM.Location = New System.Drawing.Point(493, 74)
        Me.CmdFilePEM.Name = "CmdFilePEM"
        Me.CmdFilePEM.Size = New System.Drawing.Size(35, 19)
        Me.CmdFilePEM.TabIndex = 7
        Me.CmdFilePEM.Text = "..."
        Me.CmdFilePEM.UseVisualStyleBackColor = True
        '
        'CmdFileXCA
        '
        Me.CmdFileXCA.Location = New System.Drawing.Point(493, 21)
        Me.CmdFileXCA.Name = "CmdFileXCA"
        Me.CmdFileXCA.Size = New System.Drawing.Size(35, 19)
        Me.CmdFileXCA.TabIndex = 2
        Me.CmdFileXCA.Text = "..."
        Me.CmdFileXCA.UseVisualStyleBackColor = True
        '
        'TxtPEM
        '
        Me.TxtPEM.Location = New System.Drawing.Point(172, 74)
        Me.TxtPEM.Name = "TxtPEM"
        Me.TxtPEM.Size = New System.Drawing.Size(315, 20)
        Me.TxtPEM.TabIndex = 6
        '
        'LblPEM
        '
        Me.LblPEM.AutoSize = True
        Me.LblPEM.Location = New System.Drawing.Point(21, 79)
        Me.LblPEM.Name = "LblPEM"
        Me.LblPEM.Size = New System.Drawing.Size(46, 13)
        Me.LblPEM.TabIndex = 5
        Me.LblPEM.Text = "PEM file"
        '
        'TxtFileXCA
        '
        Me.TxtFileXCA.Location = New System.Drawing.Point(172, 20)
        Me.TxtFileXCA.Name = "TxtFileXCA"
        Me.TxtFileXCA.Size = New System.Drawing.Size(315, 20)
        Me.TxtFileXCA.TabIndex = 1
        '
        'LblXCA
        '
        Me.LblXCA.AutoSize = True
        Me.LblXCA.Location = New System.Drawing.Point(21, 26)
        Me.LblXCA.Name = "LblXCA"
        Me.LblXCA.Size = New System.Drawing.Size(44, 13)
        Me.LblXCA.TabIndex = 0
        Me.LblXCA.Text = "XCA file"
        '
        'CmdClose
        '
        Me.CmdClose.Location = New System.Drawing.Point(493, 376)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(85, 27)
        Me.CmdClose.TabIndex = 13
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.Location = New System.Drawing.Point(493, 343)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(85, 27)
        Me.CmdExport.TabIndex = 12
        Me.CmdExport.Text = "Export"
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'gpType
        '
        Me.gpType.Controls.Add(Me.RbP12Chain)
        Me.gpType.Controls.Add(Me.RbP12)
        Me.gpType.Controls.Add(Me.RbPrivKey)
        Me.gpType.Location = New System.Drawing.Point(493, 128)
        Me.gpType.Name = "gpType"
        Me.gpType.Size = New System.Drawing.Size(188, 128)
        Me.gpType.TabIndex = 10
        Me.gpType.TabStop = False
        Me.gpType.Text = "File Type"
        '
        'RbP12Chain
        '
        Me.RbP12Chain.AutoSize = True
        Me.RbP12Chain.Location = New System.Drawing.Point(15, 65)
        Me.RbP12Chain.Name = "RbP12Chain"
        Me.RbP12Chain.Size = New System.Drawing.Size(74, 17)
        Me.RbP12Chain.TabIndex = 2
        Me.RbP12Chain.Text = "P12 Chain"
        Me.RbP12Chain.UseVisualStyleBackColor = True
        '
        'RbP12
        '
        Me.RbP12.AutoSize = True
        Me.RbP12.Location = New System.Drawing.Point(15, 42)
        Me.RbP12.Name = "RbP12"
        Me.RbP12.Size = New System.Drawing.Size(44, 17)
        Me.RbP12.TabIndex = 1
        Me.RbP12.Text = "P12"
        Me.RbP12.UseVisualStyleBackColor = True
        '
        'RbPrivKey
        '
        Me.RbPrivKey.AutoSize = True
        Me.RbPrivKey.Checked = True
        Me.RbPrivKey.Location = New System.Drawing.Point(15, 19)
        Me.RbPrivKey.Name = "RbPrivKey"
        Me.RbPrivKey.Size = New System.Drawing.Size(79, 17)
        Me.RbPrivKey.TabIndex = 0
        Me.RbPrivKey.TabStop = True
        Me.RbPrivKey.Text = "PrivKey DB"
        Me.RbPrivKey.UseVisualStyleBackColor = True
        '
        'LblPWDB
        '
        Me.LblPWDB.AutoSize = True
        Me.LblPWDB.Location = New System.Drawing.Point(21, 52)
        Me.LblPWDB.Name = "LblPWDB"
        Me.LblPWDB.Size = New System.Drawing.Size(43, 13)
        Me.LblPWDB.TabIndex = 3
        Me.LblPWDB.Text = "DB PW"
        '
        'TxtPWDB
        '
        Me.TxtPWDB.Location = New System.Drawing.Point(172, 47)
        Me.TxtPWDB.Name = "TxtPWDB"
        Me.TxtPWDB.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPWDB.Size = New System.Drawing.Size(315, 20)
        Me.TxtPWDB.TabIndex = 4
        '
        'LblPWFile
        '
        Me.LblPWFile.AutoSize = True
        Me.LblPWFile.Location = New System.Drawing.Point(21, 106)
        Me.LblPWFile.Name = "LblPWFile"
        Me.LblPWFile.Size = New System.Drawing.Size(44, 13)
        Me.LblPWFile.TabIndex = 8
        Me.LblPWFile.Text = "PW File"
        '
        'TxtPWFile
        '
        Me.TxtPWFile.Location = New System.Drawing.Point(172, 101)
        Me.TxtPWFile.Name = "TxtPWFile"
        Me.TxtPWFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPWFile.Size = New System.Drawing.Size(315, 20)
        Me.TxtPWFile.TabIndex = 9
        '
        'FrmXCAExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 450)
        Me.Controls.Add(Me.gpType)
        Me.Controls.Add(Me.TvCerts)
        Me.Controls.Add(Me.CmdFilePEM)
        Me.Controls.Add(Me.CmdFileXCA)
        Me.Controls.Add(Me.TxtPEM)
        Me.Controls.Add(Me.LblPEM)
        Me.Controls.Add(Me.TxtPWFile)
        Me.Controls.Add(Me.LblPWFile)
        Me.Controls.Add(Me.TxtPWDB)
        Me.Controls.Add(Me.LblPWDB)
        Me.Controls.Add(Me.TxtFileXCA)
        Me.Controls.Add(Me.LblXCA)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClose)
        Me.Name = "FrmXCAExport"
        Me.Text = "FrmXCAExport"
        Me.gpType.ResumeLayout(False)
        Me.gpType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TvCerts As TreeView
    Friend WithEvents CmdFilePEM As Button
    Friend WithEvents CmdFileXCA As Button
    Friend WithEvents TxtPEM As TextBox
    Friend WithEvents LblPEM As Label
    Friend WithEvents TxtFileXCA As TextBox
    Friend WithEvents LblXCA As Label
    Friend WithEvents CmdClose As Button
    Friend WithEvents CmdExport As Button
    Friend WithEvents gpType As GroupBox
    Friend WithEvents RbP12 As RadioButton
    Friend WithEvents RbPrivKey As RadioButton
    Friend WithEvents LblPWDB As Label
    Friend WithEvents TxtPWDB As TextBox
    Friend WithEvents LblPWFile As Label
    Friend WithEvents TxtPWFile As TextBox
    Friend WithEvents RbP12Chain As RadioButton
End Class
