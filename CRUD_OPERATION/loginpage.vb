Imports System.Data.OleDb
Public Class loginpage
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub loginpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection_string As New String("data source=localhost; user id=ayush; password=ayush; provider=OraOledb.Oracle;")
        connection = New OleDbConnection(connection_string)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userid = TextBox1.Text
        Dim name = TextBox2.Text
        Try
            Dim qry As New String("select count(*) from information where id=? and name=?")
            Dim cmd As New OleDbCommand(qry, connection)
            cmd.Parameters.AddWithValue("?", userid)
            cmd.Parameters.AddWithValue("?", name)
            connection.Open()
            Dim countres = Convert.ToInt32(cmd.ExecuteScalar())
            If (countres > 0) Then
                MsgBox("succes")
                connection.Close()
                form11.Show()
                Me.Hide()
            Else
                MsgBox("wrong credentials")
                connection.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class