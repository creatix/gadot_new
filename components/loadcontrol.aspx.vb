
Partial Class components_loadcontrol
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request("cn") <> "" Then
            Me.Controls.Add(LoadControl(Request("cn") & ".ascx"))
        End If

    End Sub

End Class
