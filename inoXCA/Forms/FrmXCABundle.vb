Imports System.IO

Public Class FrmXCABundle
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub PrintRecursive(ByVal treeNode As TreeNode, PEMfile As StreamWriter)

        For Each tn As TreeNode In treeNode.Nodes
            PrintRecursive(tn, PEMfile)
        Next
        PEMfile.WriteLine(treeNode.Text)
        PEMfile.WriteLine("-----BEGIN CERTIFICATE-----")
        Dim strings As New List(Of String)

        For i As Integer = 0 To treeNode.Tag.Length - 1 Step 64
            If Len(treeNode.Tag.Substring(i)) > 64 Then
                PEMfile.WriteLine(treeNode.Tag.Substring(i, 64))
            Else
                PEMfile.WriteLine(treeNode.Tag.Substring(i))
            End If
        Next
        PEMfile.WriteLine("-----END CERTIFICATE-----")
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
            .Filter = "XCA-File | *.xdb"
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                Me.TxtFileXCA.Text = .FileName
                Dim cDB As New ClsDB
                cDB.PopulateNodesFromDB(Me.TxtFileXCA.Text, TvCerts)
            End If
        End With
    End Sub

    Private Sub CmdFilePEM_Click(sender As Object, e As EventArgs) Handles CmdFilePEM.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .Filter = "PEM-File | *.pem"
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
