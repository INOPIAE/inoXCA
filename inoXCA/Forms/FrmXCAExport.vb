Imports System.IO

Public Class FrmXCAExport
    Private cDB As New ClsDB
    Private cCert As New ClsCerts
    Private cOpenSSL As New ClsOpenSSL

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub FrmXCAExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = clsLang.rm.getString("ExportXCATitle")
        Me.CmdClose.Text = clsLang.rm.getString("CmdClose")
        Me.CmdExport.Text = clsLang.rm.getString("CmdExport")
        Me.LblXCA.Text = clsLang.rm.getString("PemXCA")
        Me.LblPWDB.Text = clsLang.rm.getString("ExportXCADBPW")
        Me.LblPEM.Text = clsLang.rm.getString("ExportXCAPEMFile")
        Me.LblPWFile.Text = clsLang.rm.getString("ExportXCAPEMPW")
        Me.gpType.Text = clsLang.rm.getString("ExportXCAFileType")
        Me.RbPrivKey.Text = clsLang.rm.getString("ExportXCAPriv")
        Me.RbP12.Text = clsLang.rm.getString("ExportXCAP12")
        Me.RbP12Chain.Text = clsLang.rm.getString("ExportXCAP12Chain")
    End Sub

    Private Sub CmdFileXCA_Click(sender As Object, e As EventArgs) Handles CmdFileXCA.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "XCA-File | *.xdb"
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                Me.TxtFileXCA.Text = .FileName

                cDB.PopulateNodesFromDB(Me.TxtFileXCA.Text, TvCerts)
            End If
        End With
    End Sub

    Private Sub CmdFilePEM_Click(sender As Object, e As EventArgs) Handles CmdFilePEM.Click
        Dim sfd As New SaveFileDialog
        With sfd
            If RbP12.Checked Or RbP12Chain.Checked Then
                .Filter = "P12-File | *.p12"
            Else
                .Filter = "PEM-File | *.pem"
            End If

            If .ShowDialog = DialogResult.OK Then
                Me.TxtPEM.Text = .FileName
            End If
        End With
    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click
        If My.Settings.CertFolder = vbNullString Then
            MessageBox.Show(clsLang.rm.getString("MsgMissingCertFolder"), clsLang.rm.getString("MsgHint"))
            FrmSettings.Show()
            Exit Sub
        End If
        If File.Exists(Me.TxtFileXCA.Text) = False Then
            MessageBox.Show(clsLang.rm.getString("MsgNoXCA"), clsLang.rm.getString("MsgHint"))
            Me.TxtFileXCA.Select()
            Exit Sub
        End If
        If Me.TxtPWDB.Text.Trim = vbNullString Then
            MessageBox.Show(clsLang.rm.getString("MsgNoXCAPW"), clsLang.rm.getString("MsgHint"))
            Me.TxtPWDB.Select()
            Exit Sub
        End If
        If RbPrivKey.Checked = False Then
            If Me.TxtPEM.Text.Trim = vbNullString Then
                MessageBox.Show(clsLang.rm.getString("MsgNoPEM"), clsLang.rm.getString("MsgHint"))
                Me.TxtPEM.Select()
                Exit Sub
            End If
            If Me.TxtPWFile.Text.Trim = vbNullString Then
                MessageBox.Show(clsLang.rm.getString("MsgNoPEMPW"), clsLang.rm.getString("MsgHint"))
                Me.TxtPWFile.Select()
                Exit Sub
            End If
        End If
        If TvCerts.SelectedNode IsNot Nothing Then
            Dim data() As String = TvCerts.SelectedNode.Name.Split("|")
            If IsNumeric(data(1)) Then
                Dim privFile As String = cOpenSSL.privateKey
                If RbPrivKey.Checked Then
                    privFile = Me.TxtPEM.Text
                End If
                Dim privkey As String = cDB.GetPrivateKey(Me.TxtFileXCA.Text, data(1))
                Dim PEMfile As System.IO.StreamWriter
                Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
                PEMfile = My.Computer.FileSystem.OpenTextFileWriter(privFile, False, utf8WithoutBom)
                PEMfile.WriteLine(cCert.PEMString(privkey, ClsCerts.CertType.EncryptedPrivateKey))
                PEMfile.Close()
                If RbP12.Checked Then
                    PEMfile = My.Computer.FileSystem.OpenTextFileWriter(cOpenSSL.publicKey, False, utf8WithoutBom)
                    PEMfile.WriteLine(cCert.PEMString(TvCerts.SelectedNode.Tag, ClsCerts.CertType.Certificate))
                    PEMfile.Close()
                    cOpenSSL.CreateP12(Me.TxtPWDB.Text, Me.TxtPWFile.Text, Me.TxtPEM.Text)
                End If
                If RbP12Chain.Checked Then
                    PEMfile = My.Computer.FileSystem.OpenTextFileWriter(cOpenSSL.publicKey, False, utf8WithoutBom)

                    Dim certNodes As IEnumerable(Of TreeNode) = ParentNodes(TvCerts.SelectedNode)
                    For Each tn As TreeNode In certNodes
                        Debug.Print(tn.Name)
                        PEMfile.WriteLine(cCert.PEMString(tn.Tag, ClsCerts.CertType.Certificate))
                    Next
                    PEMfile.Close()
                    cOpenSSL.CreateP12(Me.TxtPWDB.Text, Me.TxtPWFile.Text, Me.TxtPEM.Text)
                End If
            Else
                MessageBox.Show(clsLang.rm.getString("MsgNoPrivKey"), clsLang.rm.getString("MsgHint"))
            End If
        Else
            MessageBox.Show(clsLang.rm.getString("MsgNoSelection"), clsLang.rm.getString("MsgHint"))
        End If

    End Sub

    Public Sub GetCheckedNodes(ByVal nodes As TreeNodeCollection)
        For Each aNode As TreeNode In nodes
            If aNode.Checked Then
                Debug.Print(aNode.Text)
            End If
            If aNode.Nodes.Count <> 0 Then GetCheckedNodes(aNode.Nodes)
        Next
    End Sub

    Private Function ParentNodes(fromNode As TreeNode) As IEnumerable(Of TreeNode)
        Dim result As New List(Of TreeNode)
        While fromNode IsNot Nothing
            result.Add(fromNode)
            fromNode = fromNode.Parent
        End While
        Return result
    End Function

    Private Sub RbPrivKey_CheckedChanged(sender As Object, e As EventArgs) Handles RbPrivKey.CheckedChanged, RbP12.CheckedChanged, RbP12Chain.CheckedChanged
        If Me.TxtPEM.Text <> vbNullString Then
            If RbP12.Checked Or RbP12Chain.Checked Then
                Me.TxtPEM.Text = Me.TxtPEM.Text.Replace(".pem", ".p12")
            End If
            If RbPrivKey.Checked Then
                Me.TxtPEM.Text = Me.TxtPEM.Text.Replace(".p12", ".pem")
            End If
        End If
    End Sub


End Class