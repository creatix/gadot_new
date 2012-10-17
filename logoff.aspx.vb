
Partial Class logoff
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.Session("loggedUser") = Nothing
        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
    End Sub

End Class
