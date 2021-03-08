Imports System.Threading

Public Class FrmSettings

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        SaveSettings()
        Me.Close()
    End Sub

    Private Sub SaveSettings()
        Dim blnLanguage As Boolean = False
        If My.Settings.Language <> Me.CboLanguage.SelectedValue Then
            If MessageBox.Show(clsLang.rm.getString("SettingsRestart"), clsLang.rm.getString("MsgHint"), MessageBoxButtons.YesNo) = DialogResult.Yes Then
                blnLanguage = True
            End If
            My.Settings.Language = Me.CboLanguage.SelectedValue
            Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo(My.Settings.Language)
            Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo(My.Settings.Language)
        End If
        My.Settings.Save()
        If blnLanguage = True Then
            Application.Restart()
        End If
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text = clsLang.rm.getString("SettingsTitle")
        Me.LblLanguage.Text = clsLang.rm.getString("SettingsLanguage")
        Me.CmdCancel.Text = clsLang.rm.getString("CmdCancel")
        Me.CmdOK.Text = clsLang.rm.getString("CmdSaveClose")
        Me.CmdSave.Text = clsLang.rm.getString("CmdSave")

        Dim comboSource As New Dictionary(Of String, String) From {
            {"de-DE", "Deutsch"},
            {"en", "English"}
        }

        Me.CboLanguage.DataSource = New BindingSource(comboSource, Nothing)
        Me.CboLanguage.DisplayMember = "Value"
        Me.CboLanguage.ValueMember = "Key"
        If My.Settings.Language = vbNullString Then
            Me.CboLanguage.SelectedValue = Thread.CurrentThread.CurrentCulture.Name
            My.Settings.Language = Thread.CurrentThread.CurrentCulture.Name
            My.Settings.Save()
        Else
            Me.CboLanguage.SelectedValue = My.Settings.Language
        End If
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        SaveSettings()
    End Sub
End Class