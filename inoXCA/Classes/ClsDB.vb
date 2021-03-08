
Imports Microsoft.Data
Imports Microsoft.Data.Sqlite


Public Class ClsDB

    Friend Class IdNode
        Inherits TreeNode

        Public Property Id As Object
        Public Property ParentId As Object
    End Class

    Public Sub PopulateNodesFromDB(DBPath As String, tvCerts As TreeView)
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
                .Name = SQLreader("name"),
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
End Class
