Imports System.Data.OleDb
Public Class sort
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub sort_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
        fillgridstudent()
    End Sub
    Private Sub fillgridstudent()
        ds = New DataSet
        Dim dtp As New OleDbDataAdapter("select * from marks order by mark ", connection)
        dtp.Fill(ds, "records")
        DataGridView1.DataSource = ds.Tables("records")

    End Sub


End Class