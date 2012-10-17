
Partial Class search
    Inherits BasePage

    Dim catitem As catsRow
    Dim keyword As String = ""
    Dim _fieldLogic As New fieldLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        keyword = Request("keyword")

        If keyword = "" Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אנא הכנס מילת חיפוש")
            Exit Sub
        End If

        loadProducts()

    End Sub

    Sub loadProducts()
        productslist1.quary = "name LIKE '%" & keyword & "%' OR catalogno LIKE '%" & keyword & "%' OR shortdescription LIKE '%" & keyword & "%' OR description LIKE '%" & keyword & "%' OR description1 LIKE '%" & keyword & "%'"
        productslist1.pageSize = 12
    End Sub

    Public Function getPageName() As String
        Dim str As String = "חיפוש"
        If keyword <> "" Then
            str &= ": '" & keyword & "'"
        End If
        Return str
    End Function

End Class
