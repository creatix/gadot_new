
Partial Class components_ordersummary
    Inherits System.Web.UI.UserControl

    Public orderid As Integer = 0
    Public orderRow As ordersRow
    Public _userLogic As New userLogic

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request("oid")) Then
            orderid = CInt(Request("oid"))
        End If
        If Request("success") <> "true" Then
            Exit Sub
        End If
        If Not loadOrder() Then
            Exit Sub
        End If
        loadProducts()
        loadUserDetails()
    End Sub

    Function loadOrder() As Boolean
        If orderid = 0 Then Return False
        Dim _ordersAdapter As New ordersAdapter
        orderRow = _ordersAdapter.GetItem(orderid)
        If Request("admin") <> "true" Then
            If _userLogic.isUserLogged() Then
                If _userLogic.getLoggedUser.usersid <> orderRow.userid Then
                    Return False
                End If
            Else
                Response.Redirect("login.aspx?ret=" & Server.UrlEncode("checkout.aspx?success=true&oid=" & Request("oid")))
                Return False
            End If
        End If
        totalPricelbl.Text = String.Format("{0:#,###}", orderRow.totalprice)
        shippingPricelbl.Text = orderRow.deliveryprice
        interestSumlbl.Text = orderRow.tax
        couponsDiscountlbl.Text = orderRow.discount
        sumlbl.Text = String.Format("{0:#,###}", orderRow.totalprice + orderRow.deliveryprice + orderRow.tax - orderRow.discount)
        Return True
    End Function

    Sub loadProducts()
        If orderid = 0 Then Exit Sub
        Dim _orderedproductsAdapter As New orderedproductsAdapter
        productsrepeater.DataSource = _orderedproductsAdapter.GetList("orderid=" & orderid)
        productsrepeater.DataBind()
    End Sub

    Sub loadUserDetails()
        If orderid = 0 Then Exit Sub
        Dim _usersAdapter As New usersAdapter
        Dim userRow As usersRow = _usersAdapter.GetItem(orderRow.userid)
        userdetailslbl.Text &= "<h2>פרטי הלקוח</h2>"
        userdetailslbl.Text &= getDetailRow("שם פרטי", userRow.firstname)
        userdetailslbl.Text &= getDetailRow("שם משפחה", userRow.lastname)
        userdetailslbl.Text &= getDetailRow("אימייל", userRow.email)
        Dim _addressAdapter As New addressAdapter
        Dim addressRow As addressRow = _addressAdapter.GetItem(orderRow.deliveryaddressid)
        userdetailslbl.Text &= "<br><br>"
        userdetailslbl.Text &= "<h2>כתובת למשלוח</h2>"
        userdetailslbl.Text &= getDetailRow("שם פרטי", addressRow.firstname)
        userdetailslbl.Text &= getDetailRow("שם משפחה", addressRow.lastname)
        userdetailslbl.Text &= getDetailRow("עיר", addressRow.city)
        userdetailslbl.Text &= getDetailRow("רחוב", addressRow.street)
        userdetailslbl.Text &= getDetailRow("מס' בית", addressRow.housenum)
        userdetailslbl.Text &= getDetailRow("מס' דירה", addressRow.apartmentnum)
        userdetailslbl.Text &= getDetailRow("מיקוד", addressRow.zipcode)
        userdetailslbl.Text &= getDetailRow("טלפון", addressRow.phone)
        If orderRow.cardid > 0 Then
            Dim _cardsAdapter As New cardsAdapter
            Dim cardsRow As cardsRow = _cardsAdapter.GetItem(orderRow.cardid)
            Dim _encryptionLogic As New encryptionLogic
            userdetailslbl.Text &= "<br><br>"
            userdetailslbl.Text &= "<h2>פרטי כרטיס אשראי</h2>"
            userdetailslbl.Text &= getDetailRow("שם בעל כרטיס האשראי", cardsRow.cardholdername)
            userdetailslbl.Text &= getDetailRow("4 ספרות אחרונות של כרטיס האשראי", _encryptionLogic.Decrypt(cardsRow.number))
            userdetailslbl.Text &= getDetailRow("תאריך תפוגה - חודש", cardsRow.expirationmonth)
            userdetailslbl.Text &= getDetailRow("תאריך תפוגה - שנה", cardsRow.expirationyear)
            userdetailslbl.Text &= getDetailRow("תעודת זהות", cardsRow.idcard)
        End If
        userdetailslbl.Text &= "<br><br>"
        userdetailslbl.Text &= getDetailRow("הערות", addressRow.comments)
    End Sub

    Function getDetailRow(ByVal name As String, ByVal value As String) As String
        If value = "" Then Return ""
        Return "<b>" & name & ":</b> <span>" & value & "</span>&nbsp;&nbsp;&nbsp; "
    End Function

End Class
