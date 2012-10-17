
Partial Class components_myaccountbar
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function getSelected(ByVal pageName As String) As String
        If Request.Url.AbsolutePath.IndexOf(pageName) > -1 Then
            Return "class=""selected"""
        End If
        Return ""
    End Function

End Class
