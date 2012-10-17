Imports cs3.DataLayer

Partial Class components_basketpanel
    Inherits System.Web.UI.UserControl

    Dim _fieldLogic As New fieldLogic
    Dim userLogic As New userLogic
    Dim _basketLogic As New basketLogic
    Dim _couponsLogic As New couponsLogic
    Dim basketItems As pList(Of basketViewRow)
    Public shippingId As Integer = 0
    Public payments As Double = 1
    Public discount As Double = 0
    Public calculateShipping As Boolean = False
    Public showCheckoutBut As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	
        Dim myURL As String = Request.Url.ToString()
        'If myURL.IndexOf("localhost") = -1 Then
        'If Request.ServerVariables("https") = "off" Then
        'Dim quary_str As String = Request.ServerVariables("QUERY_STRING")
        'Dim strurl As String = "https://www.shopsite.co.il/" & IO.Path.GetFileName(myURL) ' & "?" & quary_str
        'Response.Redirect(strurl)
        'End If
        'End If

        Response.Expires = 0
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        loadCoupon()
        addToBasket()
        deleteFromBasket()
        updateQuantity()
        loadBasket()
        loadRelatedProducts()

    End Sub

    Sub loadBasket()

        basketItems = _basketLogic.getUserBasket()

        baskettable.DataSource = basketItems
        baskettable.DataBind()

        If baskettable.DataSource.Count = 0 Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "לא נמצאו פריטים בסל הקניות")
            Exit Sub
        End If

        priceSummary()

    End Sub

    Sub priceSummary()

        If Request("calculateShipping") = "1" Then
            calculateShipping = True
        End If

        If IsNumeric(Request("shippingid")) Then
            shippingId = CInt(Request("shippingid"))
        ElseIf IsNumeric(Request("deliveryid")) Then
            shippingId = CInt(Request("deliveryid"))
        Else
            If calculateShipping Then
                Dim _dataTableAdapter As New TableAdapter
                shippingId = cs3.utils.databaseLogic.toInt(_dataTableAdapter.ExecuteScalar(Data.CommandType.Text, "SELECT TOP 1 deliveryid FROM delivery WHERE isnull(hide,0)<>1 ORDER BY sort"))
            End If
        End If

        If IsNumeric(Request("payment")) Then
            payments = CInt(Request("payment"))
        End If

        Dim totalPrice As Double = _basketLogic.getTotalPrice(basketItems)
        Dim shippingPrice As Double = _basketLogic.getShippmentPrice(shippingId)
        Dim interestSum As Double = _basketLogic.getInterestSum(totalPrice, payments)
        Dim couponDiscount As Double = _couponsLogic.getCouponsDiscount(basketItems)

        totalPricelbl.Text = String.Format("{0:#,###}", totalPrice)
        If shippingPrice > 0 Then
            shippingPricelbl.Text = shippingPrice
        Else
            shippingPricelbl.Text = ""
        End If

        If interestSum > 0 Then
            interestSumlbl.Text = interestSum
        Else
            interestSumlbl.Text = ""
        End If

        If couponDiscount > 0 Then
            couponsDiscountlbl.Text = couponDiscount
        Else
            couponsDiscountlbl.Text = ""
        End If

        sumlbl.Text = String.Format("{0:#,###}", totalPrice + shippingPrice + interestSum - couponDiscount)

    End Sub

    Sub addToBasket()
        Dim productid As String = Request("pid")
        Dim childproductid As String = Request("cpid")
        Dim quantity As String = Request("quantity")
        If Not IsNumeric(childproductid) Then
            childproductid = "0"
        End If
        If Not IsNumeric(quantity) Then
            quantity = "1"
        End If
        If IsNumeric(productid) Then
            Dim addname As String = ""
            If Request("color") <> "" Then
                addname = "צבע: " & Request("color")
            End If
            If Request("size") <> "" Then
                If addname <> "" Then addname &= ", "
                addname &= "מידה: " & Request("size")
            End If
            If Request("addname") <> "" Then
                If addname <> "" Then addname &= ", "
                addname &= Request("addname")
            End If
            If _basketLogic.addBasketItem(productid, CInt(childproductid), CInt(quantity), addname, Request("catalognum")) Then
                _fieldLogic.showError(fieldLogic.messageType.notify, "הפריט נוסף בהצלחה")
                Response.Redirect("basket.aspx")
            End If
        End If
    End Sub

    Sub deleteFromBasket()
        Dim basketid As String = Request("delid")
        If IsNumeric(basketid) Then
            If _basketLogic.deleteBasketItem(basketid) Then
                Response.Redirect("basket.aspx")
            End If
        End If
    End Sub

    Sub loadCoupon()
        If Request("couponcode") = "" Then Exit Sub
        If _couponsLogic.loadCoupon(Request("couponcode")) Then
            Response.Redirect(Request.CurrentExecutionFilePath)
        End If
    End Sub

    Sub updateQuantity()
        Dim basketid As String = Request("bid")
        Dim quantity As String = Request("quantity")
        If Not IsNumeric(quantity) Then
            quantity = "1"
        End If
        If IsNumeric(basketid) Then
            'If _basketLogic.updateQuantity(basketid, CInt(quantity)) Then
            'Response.Redirect("basket.aspx")
            'End If
        End If
    End Sub

    Sub loadRelatedProducts()
        If Not basketItems Is Nothing Then
            Dim quary As String = ""
            Dim slist As String = ""
            For Each item As basketViewRow In basketItems
                'If item.relatedproducts <> "" Then
                'slist &= item.relatedproducts
                'End If
            Next
            If slist.EndsWith(",") Then
                slist = slist.Remove(slist.Length - 1, 1)
            End If
            If slist.StartsWith(",") Then
                slist = slist.Remove(0, 1)
            End If
            If slist <> "" And slist <> "," Then
                quary = "productsid IN(" & slist & ")"
            End If
            If quary <> "" Then
                Dim productsAdapter As New productsAdapter
                grid1.dataSource = productsAdapter.GetList(quary)
                grid1.DataBind()
            End If
        End If
    End Sub

End Class
