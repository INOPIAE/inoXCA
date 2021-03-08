Imports System.IO

Public Class FrmLicence

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        Me.Close()
    End Sub

    Private Sub FrmLicence_Load(sender As Object, e As EventArgs) Handles Me.Load
        TxtLicense.Text = File.ReadAllText(Application.StartupPath & "\License")
        CmdOK.Text = clsLang.rm.getString("CmdOK")
    End Sub
End Class