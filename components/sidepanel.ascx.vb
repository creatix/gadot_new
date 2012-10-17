
Partial Class components_sidepanel
    Inherits System.Web.UI.UserControl

    Dim _pagesAdapter As New pagesAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadpages()
    End Sub

    Sub loadpages()
        rptPages.DataSource = _pagesAdapter.GetList("fatherid=0 AND isnull(hide, 0) <> 1", "sort")
        rptPages.DataBind()
    End Sub

End Class
