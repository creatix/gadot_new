Imports cs3.tableLogic

Partial Class cat
    Inherits BasePage

    Dim catid As String = ""
    Public catitem As catsRow
    Public firstProduct As productsRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        catid = Request("id")

        If Not IsNumeric(catid) And Request("man") = "" Then
            Exit Sub
        End If

        loadProducts()
        loadCat()

    End Sub

    Sub loadProducts()

        Dim currentPage As Integer

        If IsNumeric(Request("page")) Then
            currentPage = CInt(Request("page"))
        End If

        Dim query As String = ""
        If Request("man") <> "" Then
            query = "manname='" & Request("man") & "'"
            catid = 0
        End If

        Dim _productLogic As New productLogic
        Dim productsList As pList(Of productsRow) = _productLogic.getProductsList(catid, 18, query, True)

        grid1.dataSource = productsList
        grid1.view = "product"

    End Sub

    Sub loadCat()
        Dim _catsAdapter As New catsAdapter
        catitem = _catsAdapter.GetItem(catid)
        catbreadcrumbs1.catid = catid
        setPageTitle()
    End Sub

    Sub setPageTitle()
        If Not catitem Is Nothing Then
            Dim pl As New pageLogic
            If catitem.metatitle = "" Then
                catitem.metatitle = catitem.name
            End If
            pl.setPageTitle(catitem.metatitle, catitem.metadescription, catitem.metakeywords, Page)
            pl.addCanonical(pageLogic.GetLink("cat", catitem.catsid, catitem.name), Page)
        End If
    End Sub

End Class
