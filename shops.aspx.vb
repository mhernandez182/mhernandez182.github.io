Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI

Partial Class shops
    Inherits System.Web.UI.Page

    Protected Sub resetFields()
        tbName.Text = ""
        tbAddress.Text = ""
        tbPhone.Text = ""
        tbWebsite.Text = ""
        tbContact.Text = ""
        btDelete.Visible = False
        lbShops.SelectedIndex = -1  ' reset selected to none
        Session("shopID") = -1
    End Sub

    Protected Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String

        If Session("shopID") <> -1 Then
            insertCmd = "Update shops set shopName = '" & tbName.Text & "', " &
                "shopAddress = '" & tbAddress.Text & "', " &
                "shopPhone = '" & tbPhone.Text & "', " &
                "shopWebsite = '" & tbWebsite.Text & "', " &
                "contact = '" & tbContact.Text & "' where id = " & Session("shopID")

        Else
            insertCmd = "insert into shops (userId,shopName,shopAddress,shopPhone,shopWebsite,contact) values " & _
            " ('" & Session("userID") & _
            "','" & tbName.Text & _
            "','" & tbAddress.Text & _
            "','" & tbPhone.Text & _
            "','" & tbWebsite.Text & _
            "','" & tbContact.Text & _
            "');"
        End If

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadShops()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Shops Table", insertCmd)
        End Try
        loadShops()


    End Sub

    Private Sub loadShop()


        Dim myCommand As SqlCommand

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim selectCmd As String
        Dim dr As SqlDataReader

        selectCmd = "Select shopName,shopAddress,shopPhone,shopWebsite,contact,id from shops where id = " & Session("shopID")
        myCommand = New SqlCommand(selectCmd, con)
        dr = myCommand.ExecuteReader()


        Do While dr.Read()
            tbName.Text = dr.GetString(0)
            tbAddress.Text = dr.GetString(1)
            tbPhone.Text = dr.GetString(2)
            tbWebsite.Text = dr.GetString(3)
            tbContact.Text = dr.GetString(4)

            btDelete.Visible = True

        Loop

    End Sub

    Private Sub loadShops()
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim command As SqlCommand = New SqlCommand("select ID,shopName,shopAddress from shops where userId = " & Session("userID") & "order by shopName;", con)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then

            lbShops.Items.Clear()
            lbIDs.Items.Clear()

            Do While reader.Read()
                lbShops.Items.Add(reader.GetString(1) & " @ " & reader.GetString(2))
                lbIDs.Items.Add(reader.GetInt32(0).ToString())
            Loop


        Else
            lbShops.Items.Add("No Shops")
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("userID") = -1 Then
            MsgBox("Must select a user.")
            Response.Redirect("Default.aspx")
        ElseIf Not Page.IsPostBack Then
            resetFields()
            loadShops()
            Session("shopID") = -1
        End If
    End Sub

    Protected Sub lbShops_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShops.SelectedIndexChanged
        Dim index As Integer

        index = -1
        Dim li As ListItem
        For Each li In lbShops.Items
            index += 1
            If li.Selected = True Then
                Exit For
            End If
        Next

        Session("shopID") = lbIDs.Items(index).ToString()

        loadShop()
    End Sub

    Protected Sub bDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        Dim myCommand As SqlCommand
        Dim insertCmd As String


        insertCmd = "Delete from shops where id = " & Session("shopID")

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
            resetFields()
            loadShops()

        Catch ex As SqlException


            Dim mp As New site()

            mp.msgLog("Error Creating Shops Table", insertCmd)
        End Try
        loadShops()
    End Sub
End Class