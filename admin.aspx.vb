Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Partial Class admin
    Inherits System.Web.UI.Page

    Protected Sub btCreate_Click(sender As Object, e As EventArgs) Handles btCreate.Click

        Dim myCommand As SqlCommand
        Dim insertCmd As String

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("myDB").ConnectionString)
        con.Open()

        ' Drop users table
        insertCmd = "Drop TABLE users;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

        End Try

        ' Drop vehicles table
        insertCmd = "Drop TABLE vehicles;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

        End Try


        ' Drop shops table
        insertCmd = "Drop TABLE shops;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

        End Try


        ' Drop tasks table
        insertCmd = "Drop TABLE tasks;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

        End Try


        ' Create users table
        insertCmd = "CREATE TABLE users (" & _
            "ID int IDENTITY(1,1) PRIMARY KEY, " & _
            "lName varchar (100) NULL," & _
            "fName varchar (50)  NULL," & _
            "bDate date null ," & _
            "licenseExp date null );"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

            Dim mp As New site()

            mp.msgLog("Error Creating Users Table", insertCmd)

        End Try


        ' Create vehicles table
        insertCmd = "CREATE TABLE vehicles (" & _
            "ID int IDENTITY(1,1) PRIMARY KEY, " & _
            "userId int null, " & _
            "year varchar (4)  NULL, " & _
            "manufacturer varchar (100)  NULL, " & _
            "model varchar (50) NULL) ;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

            Dim mp As New site()

            mp.msgLog("Error Creating Vehciles Table", insertCmd)

        End Try


        ' Create shops table
        insertCmd = "CREATE TABLE shops (" & _
            "ID int IDENTITY(1,1) PRIMARY KEY, " & _
            "userId int null, " & _
            "shopName varchar (100)  NULL, " & _
            "shopAddress varchar (255)  NULL, " & _
            "shopPhone varchar (20)  NULL, " & _
            "shopWebsite varchar (150)  NULL, " & _
            "contact varchar (100) NULL) ;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

            Dim mp As New site()

            mp.msgLog("Error Creating Shops Table", insertCmd)

        End Try


        ' Create tasks table
        insertCmd = "CREATE TABLE tasks (" & _
            "ID int IDENTITY(1,1) PRIMARY KEY, " & _
            "userId int null, " & _
            "vehicle varchar (50) null, " & _
            "shop varchar (50) null, " & _
            "completeDate date  NULL, " & _
            "scheduleDate date NULL, " & _
            "scheduleMileage varchar (20) NULL, " & _
            "serviceReason varchar (255) NULL  ) ;"

        myCommand = New SqlCommand(insertCmd, con)
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As SqlException

            Dim mp As New site()

            mp.msgLog("Error Creating Tasks Table", insertCmd)

        End Try
    End Sub
End Class
