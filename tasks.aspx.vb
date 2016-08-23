Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI

Partial Class tasks
    Inherits System.Web.UI.Page

    Protected Sub resetFields()
        tbComplete.Text = ""
        tbSchedule.Text = ""
        tbService.Text = ""
        btDelete.Visible = False
        lbTasks.SelectedIndex = -1  ' reset selected to none
        Session("taskID") = -1
    End Sub

    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String

        If Session("taskID") <> -1 Then
            insertCmd = "Update tasks set vehicle = '" & ddVehicle.Text & "', " &
                "shop = '" & ddShop.Text & "', " &
                "scheduleDate = '" & tbSchedule.Text & "', " &
                "completeDate = '" & tbComplete.Text & "', " &
                "serviceReason = '" & tbService.Text & "' where id = " & Session("taskID")

        Else
            insertCmd = "insert into tasks (userId,vehicle,shop,scheduleDate,completeDate,serviceReason) values " & _
            " ('" & Session("userID") & _
            "','" & ddVehicle.Text & _
            "','" & ddShop.Text & _
            "','" & tbSchedule.Text & _
            "','" & tbComplete.Text & _
            "','" & tbService.Text & _
            "');"
        End If

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadTasks()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Tasks Table", insertCmd)
        End Try
        loadTasks()


    End Sub

    Private Sub loadTask()


        Dim myCommand As SqlCommand

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim selectCmd As String
        Dim dr As SqlDataReader

        selectCmd = "Select vehicle,shop,scheduleDate,completeDate,serviceReason,id from tasks where id = " & Session("taskID")
        myCommand = New SqlCommand(selectCmd, con)
        dr = myCommand.ExecuteReader()


        Do While dr.Read()
            ddVehicle.Text = dr.GetString(0)
            ddShop.Text = dr.GetString(1)
            tbSchedule.Text = dr.GetDateTime(2).ToString("yyyy-MM-dd")
            tbComplete.Text = dr.GetDateTime(3).ToString("yyyy-MM-dd")
            tbService.Text = dr.GetString(4)

            btDelete.Visible = True

        Loop

    End Sub

    Private Sub loadTasks()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select ID,vehicle,shop,scheduleDate from tasks where userId = " & Session("userID") & "order by scheduleDate;", con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            lbTasks.Items.Clear()
            lbIDs.Items.Clear()

            Do While reader.Read()
                lbTasks.Items.Add(reader.GetString(1) & " @ " & reader.GetString(2) & " @ " & reader.GetDateTime(3).ToString("yyyy-MM-dd"))
                lbIDs.Items.Add(reader.GetInt32(0).ToString())
            Loop


        Else
            lbTasks.Items.Add("No Tasks")
        End If


    End Sub

    Private Sub loadVehicles()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select manufacturer,model from vehicles where userId = " & Session("userID"), con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            ddVehicle.Items.Clear()

            Do While reader.Read()
                ddVehicle.Items.Add(reader.GetString(0) & " " & reader.GetString(1))
            Loop


        Else
            ddVehicle.Items.Add("No Vehicles")
        End If


    End Sub

    Private Sub loadShops()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select shopName from shops where userId = " & Session("userID"), con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            ddShop.Items.Clear()

            Do While reader.Read()
                ddShop.Items.Add(reader.GetString(0))
            Loop


        Else
            ddVehicle.Items.Add("No Shops")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("userID") = -1 Then
            MsgBox("Must select a user.")
            Response.Redirect("Default.aspx")
        ElseIf Not Page.IsPostBack Then
            resetFields()
            loadVehicles()
            loadShops()
            loadTasks()
            Session("tasksID") = -1
        End If
    End Sub

    Protected Sub lbTasks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbTasks.SelectedIndexChanged
        Dim index As Integer

        index = -1
        Dim li As ListItem
        For Each li In lbTasks.Items
            index += 1
            If li.Selected = True Then
                Exit For
            End If
        Next

        Session("taskID") = lbIDs.Items(index).ToString()

        loadTask()
    End Sub

    Protected Sub bDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String


        insertCmd = "Delete from tasks where id = " & Session("taskID")

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadTasks()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Tasks Table", insertCmd)
        End Try
        loadTasks()
    End Sub

End Class
