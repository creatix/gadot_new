
Partial Class myaccount
    Inherits BasePage

    Dim userRow As usersRow
    Dim _orderedproductsAdapter As New orderedproductsAdapter
    Dim _statusAdapter As New statusAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadUser()
        loadOrders()
    End Sub

    Sub loadUser()
        Dim _userLogic As New userLogic
        userRow = _userLogic.getLoggedUser()
        If userRow Is Nothing Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    Sub loadOrders()
        If userRow Is Nothing Then Exit Sub
        Dim _ordersAdapter As New ordersAdapter
        orderstable.DataSource = _ordersAdapter.GetList("userid=" & userRow.usersid)
        orderstable.DataBind()
    End Sub

    Public Function getOrderContent(ByVal orderid As Integer) As String
        Dim str As String = ""
        Dim count As Integer = 0
        Dim orderedproducts As pList(Of orderedproductsRow) = _orderedproductsAdapter.GetList("orderid=" & orderid)
        For Each op As orderedproductsRow In orderedproducts
            count += op.itemscount
            str &= op.name & vbNewLine
        Next
        Return "<a alt=""" & str & """ title=""" & str & """>" & count & " פריטים</a>"
    End Function

    Public Function getStatusName(ByVal statusid As Integer) As String
        Return _statusAdapter.GetItem(statusid).name
    End Function

End Class
