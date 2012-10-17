
Partial Class components_header
    Inherits System.Web.UI.UserControl

    Public keyword As String = "חפש"
    Public basketitems As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        getBasket()
    End Sub

    Sub getBasket()
        Dim _basketLogic As New basketLogic
        basketitems = _basketLogic.getBasketSession()
    End Sub

    Public Function getSelected(ByVal link As String) As String
        If Request.CurrentExecutionFilePath.IndexOf(link) > -1 Then
            Return "class=""selected"""
        End If
        Return ""
    End Function

End Class
