Imports System.Resources

Public NotInheritable Class FrmAbout

    Private Sub FrmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Legen Sie den Titel des Formulars fest.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format(clsLang.rm.GetString("AboutInfo"), ApplicationTitle)
        ' Initialisieren Sie den gesamten Text, der im Infofeld angezeigt wird.
        ' TODO: Die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
        '    Projekteigenschaften (im Menü "Projekt") anpassen.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format(clsLang.rm.GetString("AboutVersion"), My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = String.Format(clsLang.rm.GetString("ApplicationCopyright"), Year(Now))
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = BuildDescription()

        Me.CmdLicense.Text = clsLang.rm.GetString("CmdLicense")
        Me.OKButton.Text = clsLang.rm.GetString("CmdOK")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub CmdLicense_Click(sender As Object, e As EventArgs) Handles CmdLicense.Click
        FrmLicence.Show()
    End Sub

    Private Function BuildDescription() As String
        Dim description As String = clsLang.rm.GetString("ApplicationDescription")
        Return description
    End Function
End Class
