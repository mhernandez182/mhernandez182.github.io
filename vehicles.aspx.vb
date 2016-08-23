Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI

Partial Class vehicles
    Inherits System.Web.UI.Page

    Protected Sub resetFields()
        tbYear.Text = ""
        tbManufacturer.Text = ""
        tbModel.Text = ""
        btDelete.Visible = False
        lbVehicles.SelectedIndex = -1  ' reset selected to none
        Session("vehicleID") = -1
    End Sub

    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String

        If Session("vehicleID") <> -1 Then
            insertCmd = "Update vehicles set year = '" & tbYear.Text & "', " &
                "manufacturer = '" & tbManufacturer.Text & "', " &
                "model = '" & tbModel.Text & "' where id = " & Session("vehicleID")

        Else
            insertCmd = "insert into vehicles (userId,year,manufacturer,model) values " & _
            " ('" & Session("userID") & _
            "','" & tbYear.Text & _
            "','" & tbManufacturer.Text & _
            "','" & tbModel.Text & _
            "');"
        End If

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadVehicles()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Vehicles Table", insertCmd)
        End Try
        loadVehicles()


    End Sub

    Private Sub loadVehicle()


        Dim myCommand As SqlCommand

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim selectCmd As String
        Dim dr As SqlDataReader

        selectCmd = "Select year,manufacturer,model,id from vehicles where id = " & Session("vehicleID")
        myCommand = New SqlCommand(selectCmd, con)
        dr = myCommand.ExecuteReader()


        Do While dr.Read()
            tbYear.Text = dr.GetString(0)
            tbManufacturer.Text = dr.GetString(1)
            tbModel.Text = dr.GetString(2)

            btDelete.Visible = True

        Loop

    End Sub

    Private Sub loadVehicles()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select ID,year,manufacturer,model from vehicles where userId = " & Session("userID") & "order by year, manufacturer;", con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            lbVehicles.Items.Clear()
            lbIDs.Items.Clear()

            Do While reader.Read()
                lbVehicles.Items.Add(reader.GetString(1) & " " & reader.GetString(2) & " " & reader.GetString(3))
                lbIDs.Items.Add(reader.GetInt32(0).ToString())
            Loop


        Else
            lbVehicles.Items.Add("No Vehicles")
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("userID") = -1 Then
            MsgBox("Must select a user.")
            Response.Redirect("Default.aspx")
        ElseIf Not Page.IsPostBack Then
            resetFields()
            loadVehicles()
            Session("vehicleID") = -1
        End If
    End Sub

    Protected Sub lbVehicles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbVehicles.SelectedIndexChanged
        Dim index As Integer

        index = -1
        Dim li As ListItem
        For Each li In lbVehicles.Items
            index += 1
            If li.Selected = True Then
                Exit For
            End If
        Next

        Session("vehicleID") = lbIDs.Items(index).ToString()

        loadVehicle()
    End Sub

    Protected Sub bDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String


        insertCmd = "Delete from vehicles where id = " & Session("vehicleID")

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadVehicles()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Vehicles Table", insertCmd)
        End Try
        loadVehicles()
    End Sub
End Class
