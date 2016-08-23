
Partial Class site
    Inherits System.Web.UI.MasterPage

    Public Sub msgLog(src As String, msg As String)

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("h:\myAspNet.txt", True)

        file.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                                        DateTime.Now.ToLongDateString())
        file.WriteLine("{0} -msg- {1}", src, msg)

        file.Close()

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class

