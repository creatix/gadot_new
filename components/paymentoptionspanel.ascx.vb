
Partial Class components_paymentoptionspanel
    Inherits System.Web.UI.UserControl

    Public checkedOption As String = ""

    Function showChecked(ByVal optionName As String) As String
        If Request("paymentmethod") <> "" Then
            If Request("paymentmethod") = optionName Then
                Return "checked"
            End If
        Else
            If checkedOption = optionName Then
                Return "checked"
            End If
        End If
        Return ""
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If siteLogic.Config("chargebyphone") = "1" Then
            checkedOption = "chargebyphone"
        End If
        If siteLogic.Config("chargewithcreditcard") = "1" Then
            checkedOption = "chargewithcreditcard"
        End If
    End Sub

End Class
