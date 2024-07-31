Imports System.Data.OleDb
Public Class search
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        fillsearch()
    End Sub
    Private Sub fillsearch()
        ds = New DataSet
        Dim searchname = TextBox1.Text
        Dim dtp As New OleDbDataAdapter("select * from student where name like '%" & searchname & "%' ", connection)
        dtp.Fill(ds, "records")
        DataGridView1.DataSource = ds.Tables("records")
    End Sub







End Class