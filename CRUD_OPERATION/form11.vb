Imports System.Data.OleDb
Public Class form11
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
        filldatagrid()
    End Sub
    Private Sub filldatagrid()
        ds = New DataSet
        Dim dtp As New OleDbDataAdapter("select s.rollno,name,m.mark from student s,marks m where s.rollno = m.rollno", connection)
        dtp.Fill(ds, "student")
        DataGridView1.DataSource = ds.Tables("student")

    End Sub


    Private Sub AddUpdateDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUpdateDeleteToolStripMenuItem.Click
        student.Show()
    End Sub

    Private Sub SortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SortToolStripMenuItem.Click
        sort.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        search.Show()
    End Sub


End Class
