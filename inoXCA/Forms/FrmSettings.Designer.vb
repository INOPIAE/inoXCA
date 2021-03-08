<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSettings
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
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdOK = New System.Windows.Forms.Button()
        Me.LblLanguage = New System.Windows.Forms.Label()
        Me.CboLanguage = New System.Windows.Forms.ComboBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(48, 158)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(129, 41)
        Me.CmdCancel.TabIndex = 10
        Me.CmdCancel.Text = "Abbrechen"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'CmdOK
        '
        Me.CmdOK.Location = New System.Drawing.Point(330, 158)
        Me.CmdOK.Name = "CmdOK"
        Me.CmdOK.Size = New System.Drawing.Size(129, 41)
        Me.CmdOK.TabIndex = 8
        Me.CmdOK.Text = "OK"
        Me.CmdOK.UseVisualStyleBackColor = True
        '
        'LblLanguage
        '
        Me.LblLanguage.AutoSize = True
        Me.LblLanguage.Location = New System.Drawing.Point(45, 88)
        Me.LblLanguage.Name = "LblLanguage"
        Me.LblLanguage.Size = New System.Drawing.Size(39, 13)
        Me.LblLanguage.TabIndex = 6
        Me.LblLanguage.Text = "Label2"
        '
        'CboLanguage
        '
        Me.CboLanguage.FormattingEnabled = True
        Me.CboLanguage.Location = New System.Drawing.Point(133, 85)
        Me.CboLanguage.Name = "CboLanguage"
        Me.CboLanguage.Size = New System.Drawing.Size(131, 21)
        Me.CboLanguage.TabIndex = 7
        '
        'CmdSave
        '
        Me.CmdSave.Location = New System.Drawing.Point(189, 158)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(129, 41)
        Me.CmdSave.TabIndex = 9
        Me.CmdSave.Text = "Übernehmen"
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'FrmSettings
        '
        Me.AcceptButton = Me.CmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(577, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.CboLanguage)
        Me.Controls.Add(Me.LblLanguage)
        Me.Controls.Add(Me.CmdOK)
        Me.Controls.Add(Me.CmdCancel)
        Me.Name = "FrmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdCancel As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents LblLanguage As Label
    Friend WithEvents CboLanguage As ComboBox
    Friend WithEvents CmdSave As Button
End Class
