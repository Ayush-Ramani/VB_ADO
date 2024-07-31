Imports System.Data.OleDb
Public Class student
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
        fillgridstudent()
    End Sub
    Private Sub fillgridstudent()
        ds = New DataSet
        Dim dtp As New OleDbDataAdapter("select * from student", connection)
        dtp.Fill(ds, "records")
        DataGridView1.DataSource = ds.Tables("records")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            connection.Open()
            Dim qry As String
            qry = "insert into student values (?,?,?)"
            Dim command As New OleDbCommand(qry, connection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
            command.Parameters.AddWithValue("?", TextBox2.Text)
            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem.ToString)
            Dim insrow = command.ExecuteNonQuery()
            connection.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            ComboBox1.Text = ""

            If (insrow >= 1) Then
                MessageBox.Show("inserted succesfullly.")
                fillgridstudent()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            connection.Close()

        End Try
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try

            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(1).Value
            ComboBox1.SelectedItem = DataGridView1.SelectedRows(0).Cells(2).Value
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            connection.Open()
            Dim qry As String
            qry = "update student set name = ?,gender = ? where rollno = ?"
            Dim command As New OleDbCommand(qry, connection)
            command.Parameters.AddWithValue("?", TextBox2.Text)
            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem.ToString)
            command.Parameters.AddWithValue("?", TextBox1.Text)
            Dim insrow = command.ExecuteNonQuery()
            connection.Close()
            If (insrow >= 1) Then
                MessageBox.Show("updated successfully.")
                fillgridstudent()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            connection.Close()
        End Try
    End Sub





    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            connection.Open()
            Dim qry As String
            qry = "delete from student where rollno = ?"
            Dim command As New OleDbCommand(qry, connection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
            Dim insrow = command.ExecuteNonQuery()
            connection.Close()
            If (insrow >= 1) Then
                MessageBox.Show("deleted succesfully.")
                fillgridstudent()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            connection.Close()
        End Try
    End Sub


End Class