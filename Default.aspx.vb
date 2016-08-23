Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub resetFields()
        tbFirstName.Text = ""
        tbLastName.Text = ""
        tbBirthDate.Text = ""
        tbLicense.Text = ""
        btDelete.Visible = False
        lbUsers.SelectedIndex = -1  ' reset selected to none
        Session("userID") = -1
    End Sub

    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String

        If Session("userID") <> -1 Then
            insertCmd = "Update users set lName = '" & tbLastName.Text & "', " &
                "fName = '" & tbFirstName.Text & "', " &
                "bDate = '" & tbBirthDate.Text & "', " &
                "licenseExp = '" & tbLicense.Text & "' where id = " & Session("userID")

        Else
            insertCmd = "insert into users (lName,fName,bDate,licenseExp) values " & _
            " ('" & tbLastName.Text & _
            "','" & tbFirstName.Text & _
            "','" & tbBirthDate.Text & _
            "','" & tbLicense.Text & _
            "');"
        End If

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadUsers()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Users Table", insertCmd)
        End Try
        loadUsers()


    End Sub

    Private Sub loadUser()


        Dim myCommand As SqlCommand

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim selectCmd As String
        Dim dr As SqlDataReader

        selectCmd = "Select lName,fName,bDate,licenseExp,id from users where id = " & Session("userID")
        myCommand = New SqlCommand(selectCmd, con)
        dr = myCommand.ExecuteReader()


        Do While dr.Read()
            tbLastName.Text = dr.GetString(0)
            tbFirstName.Text = dr.GetString(1)
            tbBirthDate.Text = dr.GetDateTime(2).ToString("yyyy-MM-dd")
            tbLicense.Text = dr.GetDateTime(3).ToString("yyyy-MM-dd")

            btDelete.Visible = True

        Loop

    End Sub


    Private Sub loadUsers()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select ID,fName,lName from users order by lName, fName;", con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            lbUsers.Items.Clear()
            lbIDs.Items.Clear()

            Do While reader.Read()
                lbUsers.Items.Add(reader.GetString(2) & ", " & reader.GetString(1))
                lbIDs.Items.Add(reader.GetInt32(0).ToString())
            Loop


        Else
            lbUsers.Items.Add("No Users")
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            resetFields()
            loadUsers()
            Session("userID") = -1
        End If

    End Sub

    Protected Sub lbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbUsers.SelectedIndexChanged


        Dim index As Integer

        index = -1
        Dim li As ListItem
        For Each li In lbUsers.Items
            index += 1
            If li.Selected = True Then
                Exit For
            End If
        Next

        Session("userID") = lbIDs.Items(index).ToString()

        loadUser()


    End Sub

    Protected Sub bDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String


        insertCmd = "Delete from users where id = " & Session("userID")

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadUsers()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Users Table", insertCmd)
        End Try
        loadUsers()
    End Sub
End Class
