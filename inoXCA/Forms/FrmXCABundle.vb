Imports System.IO

Public Class FrmXCABundle
    Private cCert As New ClsCerts

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub PrintRecursive(ByVal treeNode As TreeNode, PEMfile As StreamWriter)
        For Each tn As TreeNode In treeNode.Nodes
            PrintRecursive(tn, PEMfile)
        Next
        PEMfile.WriteLine(treeNode.Text)
        PEMfile.WriteLine(cCert.PEMString(treeNode.Tag, ClsCerts.CertType.Certificate))
    End Sub

    Private Sub CallRecursive(ByVal treeView As TreeView, FilePath As String)
        Dim PEMfile As System.IO.StreamWriter
        PEMfile = My.Computer.FileSystem.OpenTextFileWriter(Me.TxtPEM.Text, False)

        Dim nodes As TreeNodeCollection = treeView.Nodes

        For Each n As TreeNode In nodes
            PrintRecursive(n, PEMfile)
        Next

        PEMfile.Close()
    End Sub

    Private Sub CmdFileXCA_Click(sender As Object, e As EventArgs) Handles CmdFileXCA.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = String.Format("{0} | *.xdb", clsLang.rm.getString("FileXCA"))
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                Me.TxtFileXCA.Text = .FileName
                Dim cDB As New ClsDB
                cDB.PopulateTreeviewNodesFromDB(Me.TxtFileXCA.Text, TvCerts)
            End If
        End With
    End Sub

    Private Sub CmdFilePEM_Click(sender As Object, e As EventArgs) Handles CmdFilePEM.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .Filter = String.Format("{0} | *.pem", clsLang.rm.getString("FilePEM"))
            If .ShowDialog = DialogResult.OK Then
                Me.TxtPEM.Text = .FileName
                CallRecursive(TvCerts, TxtPEM.Text)
            End If
        End With

    End Sub

    Private Sub FrmXCABundle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = clsLang.rm.getString("PemTitle")
        Me.LblXCA.Text = clsLang.rm.getString("PemXCA")
        Me.LblPEM.Text = clsLang.rm.getString("PemPem")
        Me.CmdClose.Text = clsLang.rm.getString("CmdClose")

        TxtInfo.Text = clsLang.rm.getString("PemInfo1") & vbNewLine & clsLang.rm.getString("PemInfo2")
        CmdFilePEM.Enabled = False
    End Sub

    Private Sub TxtFileXCA_TextChanged(sender As Object, e As EventArgs) Handles TxtFileXCA.TextChanged
        CmdFilePEM.Enabled = File.Exists(Me.TxtFileXCA.Text)
    End Sub
End Class
