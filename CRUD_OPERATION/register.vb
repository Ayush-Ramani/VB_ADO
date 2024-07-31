Imports System.Data.OleDb
Public Class register
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim userid As String
        Dim name As String
        userid = TextBox1.Text
        name = TextBox2.Text


        Dim insqry As New String("insert into information values(?,?)")

        Try
            connection.Open()
            Dim cmd As New OleDbCommand(insqry, connection)
            cmd.Parameters.AddWithValue("?", userid)
            cmd.Parameters.AddWithValue("?", name)

            Dim effectrow = cmd.ExecuteNonQuery()
            If (effectrow >= 1) Then
                MsgBox("Hurrah! Succesfully registered , Login Now")
                connection.Close()
                Form1.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox("userid has been already taken")
            MsgBox(ex.Message)
            connection.Close()
        End Try
    End Sub


End Class