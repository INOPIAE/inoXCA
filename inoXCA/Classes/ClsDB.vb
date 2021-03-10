
Imports System.Globalization
Imports Microsoft.Data
Imports Microsoft.Data.Sqlite


Public Class ClsDB

    Friend Class IdNode
        Inherits TreeNode

        Public Property Id As Object
        Public Property ParentId As Object
    End Class

    Public Sub PopulateTreeviewNodesFromDB(DBPath As String, tvCerts As TreeView)
        tvCerts.BeginUpdate()
        tvCerts.Nodes.Clear()
        Dim connect As New Sqlite.SqliteConnection()
        Dim command As New SqliteCommand
        connect.ConnectionString = "Data Source='" & DBPath & "'"
        connect.Open()

        command = connect.CreateCommand

        command.CommandText = "SELECT * FROM view_certs"

        Dim SQLreader As SqliteDataReader = command.ExecuteReader()

        While SQLreader.Read()
            tvCerts.Nodes.Add(New IdNode() With {
                .Name = String.Format("{0}|{1}", SQLreader("name"), SQLreader("pkey")),
                .Text = SQLreader("name"),
                .Id = SQLreader("id"),
                .ParentId = SQLreader("issuer"),
                .Tag = SQLreader("cert")
            })

        End While
        command.Dispose()
        connect.Close()

        For Each idnode As IdNode In GetAllNodes(tvCerts).OfType(Of IdNode)()

            For Each newparent As IdNode In GetAllNodes(tvCerts).OfType(Of IdNode)()

                If newparent.Id.Equals(idnode.ParentId) And idnode.ParentId <> idnode.Id Then
                    tvCerts.Nodes.Remove(idnode)
                    newparent.Nodes.Add(idnode)
                    Exit For
                End If
            Next
        Next

        tvCerts.EndUpdate()

    End Sub


    Public Shared Function GetAllNodes(ByVal tv As TreeView) As List(Of TreeNode)
        Dim result As List(Of TreeNode) = New List(Of TreeNode)()

        For Each child As TreeNode In tv.Nodes
            result.AddRange(GetAllNodes(child))
        Next

        Return result
    End Function


    Public Shared Function GetAllNodes(ByVal tn As TreeNode) As List(Of TreeNode)
        Dim result As List(Of TreeNode) = New List(Of TreeNode)()
        result.Add(tn)

        For Each child As TreeNode In tn.Nodes
            result.AddRange(GetAllNodes(child))
        Next

        Return result
    End Function

    Public Function GetPrivateKey(DBPath As String, id As Long) As String
        Dim connect As New Sqlite.SqliteConnection()
        Dim command As New SqliteCommand
        connect.ConnectionString = "Data Source='" & DBPath & "'"
        connect.Open()

        command = connect.CreateCommand

        command.CommandText = "SELECT * FROM private_keys WHERE item = " & id

        Dim SQLreader As SqliteDataReader = command.ExecuteReader()
        Dim key As String = vbNullString
        While SQLreader.Read()
            key = SQLreader("private")
            Exit While
        End While
        command.Dispose()
        connect.Close()
        Return key
    End Function

    Public Sub PopulateDataGridViewFromDB(DBPath As String, dgv As DataGridView)
        dgv.Rows.Clear()

        Dim connect As New Sqlite.SqliteConnection()
        Dim command As New SqliteCommand
        connect.ConnectionString = "Data Source='" & DBPath & "'"
        connect.Open()

        command = connect.CreateCommand

        command.CommandText = "SELECT * FROM view_crls ORDER BY name, date desc"

        Dim SQLreader As SqliteDataReader = command.ExecuteReader()
        Dim lastName As String = vbNullString
        While SQLreader.Read()
            Dim RowCount As Integer = dgv.RowCount '- 1 ' hier zählst du die vorhanden Eintrräge
            If lastName <> SQLreader("name") Then
                dgv.Rows.Add() ' 
                dgv.BeginEdit(CBool(RowCount))
                dgv.Rows(RowCount).Cells("id").Value = SQLreader("id")
                dgv.Rows(RowCount).Cells("CrlName").Value = SQLreader("name")
                dgv.Rows(RowCount).Cells("NextUpdate").Value = TimeCodeToDate(SQLreader("date"))
                dgv.Rows(RowCount).Cells("Numbers").Value = SQLreader("num")
                dgv.Rows(RowCount).Cells("CRL").Value = SQLreader("crl")
                dgv.Update()
                dgv.EndEdit()
                lastName = SQLreader("name")
            End If
        End While
        command.Dispose()
        connect.Close()


    End Sub

    Public Function TimeCodeToDate(timecode As String) As DateTime
        Dim time As String = timecode.Substring(0, 14)
        Return DateTime.ParseExact(time, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None)
    End Function
End Class
