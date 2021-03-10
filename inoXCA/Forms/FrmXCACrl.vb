Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class FrmXCACrl
    Private cDB As New ClsDB
    Private cCert As New ClsCerts
    Private blnPathChanged As Boolean = False

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub CmdFileXCA_Click(sender As Object, e As EventArgs) Handles CmdFileXCA.Click
        If My.Settings.CertFolder = vbNullString Then
            MessageBox.Show(clsLang.rm.getString("MsgMissingCertFolder"), clsLang.rm.getString("MsgHint"))
            FrmSettings.Show()
            Exit Sub
        End If
        If blnPathChanged = True Then
            SaveFile()
        End If
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = String.Format("{0} | *.xdb", clsLang.rm.getString("FileXCA"))
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                Me.TxtFileXCA.Text = .FileName
                cDB.PopulateDataGridViewFromDB(Me.TxtFileXCA.Text, DgvCRL)
                FillPath()
            End If
        End With
    End Sub

    Private Sub SaveFile()
        Dim saveFile As System.IO.StreamWriter
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        saveFile = My.Computer.FileSystem.OpenTextFileWriter(SaveFileName(TxtFileXCA.Text), False, utf8WithoutBom)
        For Each row As DataGridViewRow In DgvCRL.Rows
            saveFile.WriteLine(row.Cells("CrlName").Value & "|" & row.Cells("CRLPath").Value)
        Next
        saveFile.Close()
    End Sub

    Private Sub CmdFile_Click(sender As Object, e As EventArgs) Handles CmdFile.Click
        If DgvCRL.SelectedRows.Count = 1 Then
            Dim sfd As New SaveFileDialog
            With sfd
                .Filter = String.Format("{0} | *.crl", clsLang.rm.getString("FileCRL"))
                If .ShowDialog = DialogResult.OK Then
                    DgvCRL.SelectedRows(0).Cells("CRLPath").Value = .FileName
                    blnPathChanged = True
                End If
            End With
        End If
    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click
        Dim PEMfile As System.IO.StreamWriter
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        For Each row As DataGridViewRow In DgvCRL.Rows
            If row.Cells("export").Value = True Then
                If row.Cells("CRLPath").Value = vbNullString Then
                    MessageBox.Show(String.Format(clsLang.rm.getString("MsgMissingPath"), row.Cells("CrlName").Value), clsLang.rm.getString("MsgHint"))
                Else
                    PEMfile = My.Computer.FileSystem.OpenTextFileWriter(row.Cells("CRLPath").Value, False, utf8WithoutBom)
                    PEMfile.WriteLine(cCert.PEMString(row.Cells("CRL").Value, ClsCerts.CertType.CRL))
                    PEMfile.Close()
                End If
            End If
        Next
    End Sub

    Private Sub FillPath()
        Dim filename As String = SaveFileName(TxtFileXCA.Text)
        If File.Exists(filename) Then
            Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
            Dim reader As New StreamReader(filename, utf8WithoutBom)

            Dim line As String
            line = reader.ReadLine
            Do
                Dim data() As String = line.Split("|")
                For Each row As DataGridViewRow In DgvCRL.Rows
                    If row.Cells("CrlName").Value = data(0) Then
                        row.Cells("CRLPath").Value = data(1)
                        Exit For
                    End If
                Next
                line = reader.ReadLine
            Loop Until line Is Nothing

            reader.Close()
        End If
    End Sub

    Private Sub FrmXCACrl_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If blnPathChanged = True Then
            SaveFile()
        End If
    End Sub

    Private Sub FrmXCACrl_Load(sender As Object, e As EventArgs) Handles Me.Load
        DgvCRL.RowHeadersWidth = 20
        DgvCRL.Columns("id").Visible = False
        DgvCRL.Columns("export").HeaderText = clsLang.rm.getString("ExportCRLExport")
        DgvCRL.Columns("CRLname").HeaderText = clsLang.rm.getString("ExportCRLName")
        DgvCRL.Columns("NextUpdate").HeaderText = clsLang.rm.getString("ExportCRLUpdate")
        DgvCRL.Columns("Numbers").Width = 60
        DgvCRL.Columns("Numbers").HeaderText = clsLang.rm.getString("ExportCRLNoRevoked")
        DgvCRL.Columns("CRL").Visible = False
        DgvCRL.Columns("CRLPath").HeaderText = clsLang.rm.getString("ExportCRLPath")

        CmdFile.Text = clsLang.rm.getString("CmdFileSelect")
        CmdExport.Text = clsLang.rm.getString("CmdExport")
        CmdClose.Text = clsLang.rm.getString("CmdClose")
        Me.Text = clsLang.rm.getString("ExportCRLTitle")
        Me.LblXCA.Text = clsLang.rm.getString("PemXCA")
    End Sub

    Private Function SaveFileName(filepath As String) As String
        Dim file As String = Path.GetFileName(filepath)
        Return My.Settings.CertFolder & "\" & file.Replace("xdb", "inoxca")
    End Function
End Class