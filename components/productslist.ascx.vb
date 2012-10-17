Imports cs3.tableLogic

Partial Class components_productslist
    Inherits System.Web.UI.UserControl

    Public quary As String
    Public catid As Integer = 0
    Public sortBy As String = ""
    Public currentPage As Integer = 1
    Public pageSize As Integer = 10
    Public style As String = "PD_area"
    Public view As String = "product2"
    Public colNum As Integer = 4
    Dim tl As tableList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadProducts()
    End Sub

    Sub loadProducts()

        If quary = "" And catid = 0 Then
            Exit Sub
        End If

        If IsNumeric(Request("page")) Then
            currentPage = CInt(Request("page"))
        End If

        'Dim productsAdapter As New productsAdapter
        'Dim productsList As pList(Of productsRow) = productsAdapter.GetList(quary, sortBy, currentPage, pageSize)
        Dim _productLogic As New productLogic
        Dim productsList As pList(Of productsRow) = _productLogic.getProductsList(catid, pageSize, quary, True)

        grid1.dataSource = productsList
        grid1.view = view
        grid1.colNum = colNum

    End Sub

End Class
