
Partial Class login
    Inherits BasePage

    Public _userLogic As New userLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub loginbut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbut.ServerClick
        If Not _userLogic.userLogin(loginemailtxt.Value, loginpasswordtxt.Value) Is Nothing Then
            If Request("ret") <> "" Then
                Response.Redirect(Request("ret"))
            Else
                Response.Redirect("myaccount.aspx")
            End If
        End If
    End Sub

End Class
