
Partial Class components_manufacturerspanel
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadMan()
    End Sub

    Sub loadMan()
        Dim _manufacturersAdapter As New manufacturersAdapter
        manrep.DataSource = _manufacturersAdapter.GetList()
        manrep.DataBind()
    End Sub
End Class
