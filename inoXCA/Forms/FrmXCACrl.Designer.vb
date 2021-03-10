<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmXCACrl
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
        Me.CmdFileXCA = New System.Windows.Forms.Button()
        Me.TxtFileXCA = New System.Windows.Forms.TextBox()
        Me.LblXCA = New System.Windows.Forms.Label()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.DgvCRL = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Export = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CrlName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numbers = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CRLPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdFile = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        CType(Me.DgvCRL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdFileXCA
        '
        Me.CmdFileXCA.Location = New System.Drawing.Point(441, 26)
        Me.CmdFileXCA.Name = "CmdFileXCA"
        Me.CmdFileXCA.Size = New System.Drawing.Size(35, 19)
        Me.CmdFileXCA.TabIndex = 2
        Me.CmdFileXCA.Text = "..."
        Me.CmdFileXCA.UseVisualStyleBackColor = True
        '
        'TxtFileXCA
        '
        Me.TxtFileXCA.Location = New System.Drawing.Point(120, 25)
        Me.TxtFileXCA.Name = "TxtFileXCA"
        Me.TxtFileXCA.Size = New System.Drawing.Size(315, 20)
        Me.TxtFileXCA.TabIndex = 1
        '
        'LblXCA
        '
        Me.LblXCA.AutoSize = True
        Me.LblXCA.Location = New System.Drawing.Point(25, 29)
        Me.LblXCA.Name = "LblXCA"
        Me.LblXCA.Size = New System.Drawing.Size(44, 13)
        Me.LblXCA.TabIndex = 0
        Me.LblXCA.Text = "XCA file"
        '
        'CmdClose
        '
        Me.CmdClose.Location = New System.Drawing.Point(589, 334)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(85, 41)
        Me.CmdClose.TabIndex = 6
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'DgvCRL
        '
        Me.DgvCRL.AllowUserToAddRows = False
        Me.DgvCRL.AllowUserToDeleteRows = False
        Me.DgvCRL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCRL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Export, Me.CrlName, Me.NextUpdate, Me.Numbers, Me.CRL, Me.CRLPath})
        Me.DgvCRL.Location = New System.Drawing.Point(120, 90)
        Me.DgvCRL.Name = "DgvCRL"
        Me.DgvCRL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCRL.Size = New System.Drawing.Size(461, 285)
        Me.DgvCRL.TabIndex = 3
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 20
        '
        'Export
        '
        Me.Export.HeaderText = "Export"
        Me.Export.Name = "Export"
        Me.Export.Width = 50
        '
        'CrlName
        '
        Me.CrlName.HeaderText = "Name"
        Me.CrlName.Name = "CrlName"
        Me.CrlName.ReadOnly = True
        '
        'NextUpdate
        '
        Me.NextUpdate.HeaderText = "Next Update"
        Me.NextUpdate.Name = "NextUpdate"
        Me.NextUpdate.ReadOnly = True
        Me.NextUpdate.Width = 120
        '
        'Numbers
        '
        Me.Numbers.HeaderText = "Number revoked"
        Me.Numbers.Name = "Numbers"
        Me.Numbers.ReadOnly = True
        '
        'CRL
        '
        Me.CRL.HeaderText = "CRL"
        Me.CRL.Name = "CRL"
        Me.CRL.ReadOnly = True
        Me.CRL.Width = 20
        '
        'CRLPath
        '
        Me.CRLPath.HeaderText = "CRLPath"
        Me.CRLPath.Name = "CRLPath"
        '
        'CmdFile
        '
        Me.CmdFile.Location = New System.Drawing.Point(589, 90)
        Me.CmdFile.Name = "CmdFile"
        Me.CmdFile.Size = New System.Drawing.Size(85, 41)
        Me.CmdFile.TabIndex = 4
        Me.CmdFile.Text = "File"
        Me.CmdFile.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.Location = New System.Drawing.Point(589, 140)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(85, 41)
        Me.CmdExport.TabIndex = 5
        Me.CmdExport.Text = "Export"
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'FrmXCACrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DgvCRL)
        Me.Controls.Add(Me.CmdFileXCA)
        Me.Controls.Add(Me.TxtFileXCA)
        Me.Controls.Add(Me.LblXCA)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdFile)
        Me.Controls.Add(Me.CmdClose)
        Me.Name = "FrmXCACrl"
        Me.Text = "FrmXCACrl"
        CType(Me.DgvCRL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmdFileXCA As Button
    Friend WithEvents TxtFileXCA As TextBox
    Friend WithEvents LblXCA As Label
    Friend WithEvents CmdClose As Button
    Friend WithEvents DgvCRL As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Export As DataGridViewCheckBoxColumn
    Friend WithEvents CrlName As DataGridViewTextBoxColumn
    Friend WithEvents NextUpdate As DataGridViewTextBoxColumn
    Friend WithEvents Numbers As DataGridViewTextBoxColumn
    Friend WithEvents CRL As DataGridViewTextBoxColumn
    Friend WithEvents CRLPath As DataGridViewTextBoxColumn
    Friend WithEvents CmdFile As Button
    Friend WithEvents CmdExport As Button
End Class
