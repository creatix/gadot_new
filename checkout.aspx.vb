Imports System.IO

Partial Class checkout
    Inherits BasePage

    Dim _fieldLogic As New fieldLogic
    Public _userLogic As New userLogic
    Dim _basketLogic As New basketLogic
    Dim _couponsLogic As New couponsLogic
    Dim _ordersAdapter As New ordersAdapter
    Dim _paymentLogic As New paymentLogic
    Dim _mailLogic As New mailLogic
    Dim userRow As usersRow
    Dim addressid As Integer
    Dim cardid As Integer
    Dim orderid As Integer
    Dim basketItems As pList(Of basketViewRow)
    Dim orderObj As ordersRow
    Dim orderTotalPrice As Double = 0

    Dim pelecard_userName As String = "PeleTest"
    Dim pelecard_password As String = "Pelecard@Test"
    Dim pelecard_termNo As String = "0962210"
    Dim authrizenumber As String = ""

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error

        Dim objError As Exception = Server.GetLastError.GetBaseException

        Dim msg, subject As String
        msg &= "<style type='text/css'><!--"
        msg &= "td {font-family:  Arial, Verdana, Geneva, Helvetica, sans-serif;font-size: 12px;direction:rtl;}"
        msg &= "table {direction:ltr;}"
        msg &= "--></style>"
        msg &= "<table align='center'><tr><td>"
        msg &= "<b>באג באתר</b><br>"
        msg &= "<b>Source Name:</b> " & objError.Source & "<br>"
        msg &= "<b>Erorr Message:</b> " & objError.Message & "<br>"
        msg &= "<b>Stack Trace:</b> " & objError.StackTrace & "<br>"
        'msg &= "<b>Inner Exception:</b> " & objError.InnerException.ToString & "<br>"
        msg &= "<b>User Ip:</b> " & HttpContext.Current.Request.UserHostName & "<br>"
        msg &= "<b>Page URL:</b> " & HttpContext.Current.Request.RawUrl & "<br>"
        msg &= "</td></tr></table>"

        subject = "באג חדש"

        Try
            _mailLogic.sendMail(subject, msg, siteLogic.Config("siteemail"), "elismargon@gmail.com")
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _paymentLogic.finishOrder()
        showPanels()
        loadOrderData()

    End Sub

    ' ----------------- Load data ---------------------------------------------

    Sub loadOrderData()
        loadUserBasket()
        If Not Page.IsPostBack Then
            loadPaymentsInterest()
            initCardsPanel()
            loadUserData()
        End If
    End Sub

    Sub loadPaymentsInterest()
        Dim _paymentinterestAdapter As New paymentinterestAdapter
        paymentsselect.DataSource = _paymentinterestAdapter.GetList("isnull(showover,0)<=" & orderTotalPrice)
        paymentsselect.DataTextField = "payment"
        paymentsselect.DataValueField = "payment"
        paymentsselect.DataBind()
    End Sub

    Sub initCardsPanel()
        expirationyearselect.Items.Add(New ListItem("שנה", ""))
        For i As Integer = 0 To 12
            expirationyearselect.Items.Add(New ListItem(Now.Year + i, Now.Year + i))
        Next
        Dim _cardTypesAdapter As New cardTypesAdapter
        cardtypeselect.DataTextField = "name"
        cardtypeselect.DataValueField = "name"
        cardtypeselect.DataSource = _cardTypesAdapter.GetList()
        cardtypeselect.DataBind()
        cardtypeselect.Items.Insert(0, "")
    End Sub

    Sub loadUserData()
        If _userLogic.isUserLogged() Then
            connectedUser.Text = _userLogic.getLoggedUser.firstname & " " & _userLogic.getLoggedUser.lastname & " | <a href=""changedetails.aspx"">שנה פרטים</a> | <a href=""logoff.aspx"">התנתק</a>"
        End If
    End Sub

    Sub loadUserBasket()
        basketItems = _basketLogic.getUserBasket()
        If basketItems.Count = 0 Then

            _fieldLogic.showError(fieldLogic.messageType.alert, "לא נמצאו פריטים בסל הקניות. <a href=""index.aspx"">לחץ כאן</a> בכדי להמשיך לגלוש באתר")
            checkoutpagepanel.Visible = False
        End If
        deliverypanel1.userbasket = basketItems
        orderTotalPrice = _basketLogic.getTotalPrice(basketItems) - _couponsLogic.getCouponsDiscount(basketItems)
        If IsNumeric(Request("deliveryid")) Then
            orderTotalPrice += _basketLogic.getShippmentPrice(Request("deliveryid"))
        End If
    End Sub

    ' ----------------- Checkout ---------------------------------------------

    Protected Sub buynow_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles buynow.ServerClick
        processCheckout()
    End Sub

    Sub processCheckout()

        If Not _userLogic.isUserLogged() Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "הלקוח לא נמצא - אנא התחבר או הרשם")
            Exit Sub
        End If

        If Not checkFields() Then
            Exit Sub
        End If

        userRow = _userLogic.getLoggedUser()
        If userRow.usersid = 0 Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי הלקוח - אנא נסה שוב")
            Exit Sub
        End If

        addressid = insertAddress()
        If addressid = 0 Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי כתובת הלקוח - אנא נסה שוב")
            Exit Sub
        End If

        If Request("paymentmethod") = "chargewithcreditcard" Then
            cardid = insertCard()
            If cardid = 0 Then
                _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי כרטיס האשראי - אנא נסה שוב")
                Exit Sub
            End If
        End If

        basketItems = _basketLogic.getUserBasket()

        orderid = insertOrder()
        If orderid = 0 Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי ההזמנה - אנא נסה שוב")
            Exit Sub
        End If

        If insertOrderProducts() = 0 Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי מוצרי ההזמנה - אנא נסה שוב")
            Exit Sub
        End If

        _couponsLogic.couponUsed(_couponsLogic.getCouponCode, orderid)

        sendOrderMail()

        Dim total As Double = orderObj.totalprice + orderObj.deliveryprice + orderObj.tax - orderObj.discount

        _paymentLogic.redirectOrder(orderid, total)

    End Sub

    Sub sendOrderMail()

        Dim _encryptionLogic As New encryptionLogic
        Dim placeholders As New Dictionary(Of String, String)
        placeholders.Add("orderid", orderid)
        placeholders.Add("firstname", userRow.firstname)
        placeholders.Add("orderdate", Format(Now, "dd/MM/yyyy"))
        placeholders.Add("userpassword", _encryptionLogic.Decrypt(userRow.password))
        placeholders.Add("invoice", loadOrderSummary(orderid))
        _mailLogic.sendMailTemplate("OrderMail", siteLogic.Config("siteemail"), userRow.email, placeholders)

    End Sub

    Function loadOrderSummary(ByVal orderid As Integer) As String
        Dim panelContent As String = ""
        Dim page As Page = New Page()
        Dim userControl As components_ordersummary = page.LoadControl("components/ordersummary.ascx")
        userControl.orderid = orderid
        page.Controls.Add(userControl)
        Dim textWriter As StringWriter = New StringWriter()
        HttpContext.Current.Server.Execute(page, textWriter, True)
        panelContent = textWriter.ToString()
        Return panelContent
    End Function

    ' ----------------- Check fields ---------------------------------------------

    Function checkFields() As Boolean
        If Not IsNumeric(Request("deliveryid")) Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "אנא בחר את אופן המשלוח")
            Return False
        End If
        If Not checkAddressFields() Then
            Return False
        End If
        If Request("paymentmethod") = "chargewithcreditcard" Then
            If Not checkCardFields() Then
                Return False
            End If
        End If
        Return True
    End Function

    Function checkAddressFields() As Boolean
        If _fieldLogic.isEmptyField(addressfirstnametxt, "אנא הכנס שם פרטי") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(addresslastnametxt, "אנא הכנס שם משפחה") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(addresscitytxt, "אנא הכנס עיר") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(addressstreettxt, "אנא הכנס רחוב") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(addresshousenumtxt, "אנא הכנס מס' בית") Then
            Return False
        End If
        'If _fieldLogic.isEmptyField(addressapptnumtxt, "אנא הכנס מס' דירה") Then
        'Return False
        'End If
        'If _fieldLogic.isEmptyField(addressziptxt, "אנא הכנס מיקוד") Then
        'Return False
        'End If
        Return True
    End Function

    Function checkCardFields() As Boolean
        If _fieldLogic.isEmptyField(numbertxt, "אנא הכנס מס' כרטיס אשראי") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(cardholdernametxt, "אנא הכנס את שם בעל הכרטיס") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(cvvtxt, "אנא הכנס קוד אימות") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(expirationmonthselect, "אנא בחר את חודש תאריך התפוגה") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(expirationyearselect, "אנא בחר את שנת תאריך התפוגה") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(cardtypeselect, "אנא בחר את סוג כרטיס האשראי") Then
            Return False
        End If
        If _fieldLogic.isEmptyField(idcardtxt, "אנא הכנס תעודת זהות") Then
            Return False
        End If
        Return True
    End Function

    ' ----------------- Insert data ---------------------------------------------

    Function insertAddress() As Integer
        Dim _addressAdapter As New addressAdapter
        Dim newAddress As New addressRow
        newAddress.userid = userRow.usersid
        newAddress.firstname = addressfirstnametxt.Value
        newAddress.lastname = addresslastnametxt.Value
        newAddress.city = addresscitytxt.Value
        newAddress.street = addressstreettxt.Value
        newAddress.housenum = addresshousenumtxt.Value
        newAddress.apartmentnum = addressapptnumtxt.Value
        newAddress.zipcode = addressziptxt.Value
        newAddress.phone = addressphonetxt.Value
        newAddress.comments = addresscommentstxt.Value
        Return _addressAdapter.Insert(newAddress)
    End Function

    Function insertCard() As Integer
        Dim creditnum As String = numbertxt.Value
        If creditnum.Length > 4 Then
            creditnum = creditnum.Substring(creditnum.Length - 4, 4)
        End If
        Dim _encryptionLogic As New encryptionLogic
        Dim _cardsAdapter As New cardsAdapter
        Dim newCard As New cardsRow
        newCard.userid = userRow.usersid
        newCard.number = _encryptionLogic.Encrypt(creditnum)
        newCard.cardholdername = cardholdernametxt.Value
        'newCard.cvv = _encryptionLogic.Encrypt(cvvtxt.Value)
        newCard.expirationmonth = expirationmonthselect.Value
        newCard.expirationyear = expirationyearselect.Value
        newCard.idcard = idcardtxt.Value
        Return _cardsAdapter.Insert(newCard)
    End Function

    Function insertOrderProducts() As Integer
        If basketItems Is Nothing Then
            _fieldLogic.showError(fieldLogic.messageType.alert, "לא נמצאו מוצרים להזמנה זו - אנא נסה שוב")
            Return 0
        End If
        For Each product As basketViewRow In basketItems
            If insertOrderProduct(product) = 0 Then
                _fieldLogic.showError(fieldLogic.messageType.alert, "אירעה שגיאה בהכנסת פרטי מוצרי ההזמנה - אנא נסה שוב")
                Return 0
            End If
        Next
        Return orderid
    End Function

    Function insertOrderProduct(ByVal product As basketViewRow) As Integer
        Dim _orderedproductsAdapter As New orderedproductsAdapter
        Dim newOrderedProduct As New orderedproductsRow
        newOrderedProduct.orderid = orderid
        newOrderedProduct.userid = userRow.usersid
        newOrderedProduct.productid = product.productid
        newOrderedProduct.catalogno = product.catalogno
        newOrderedProduct.name = product.name
        newOrderedProduct.price = product.price
        newOrderedProduct.catid = product.catid
        newOrderedProduct.pic = product.pic
        newOrderedProduct.shortdescription = ""
        newOrderedProduct.itemscount = product.itemscount
        newOrderedProduct.addprice = product.addprice
        newOrderedProduct.addname = product.addname
        Return _orderedproductsAdapter.Insert(newOrderedProduct)
    End Function

    Function insertOrder() As Integer
        Dim newOrder As New ordersRow
        newOrder.userid = userRow.usersid
        newOrder.deliveryaddressid = addressid
        newOrder.billingaddressid = addressid
        newOrder.deliveryid = Request("deliveryid")
        newOrder.cardid = cardid
        newOrder.totalprice = _basketLogic.getTotalPrice(basketItems)
        newOrder.deliveryprice = _basketLogic.getShippmentPrice(Request("deliveryid"))
        newOrder.discount = _couponsLogic.getCouponsDiscount(basketItems)
        newOrder.payments = paymentsselect.Value
        newOrder.tax = _basketLogic.getInterestSum(newOrder.totalprice, newOrder.payments)
        newOrder.paymentmethod = Request("paymentmethod")
        newOrder.ip = Request.UserHostAddress()
        newOrder.coupon = _couponsLogic.getCouponCode
        newOrder.statusid = 1
        newOrder.usercomments = ordercomments.value
        orderid = _ordersAdapter.Insert(newOrder)
        newOrder.ordersid = orderid
        orderObj = newOrder
        Return orderid
    End Function

    ' ----------------- Misc ---------------------------------------------

    Protected Sub loginbut_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginbut.ServerClick
        If Not _userLogic.userLogin(loginemailtxt.Value, loginpasswordtxt.Value) Is Nothing Then
            Response.Redirect("checkout.aspx")
        End If
    End Sub

    Function showCardsPanel() As String
        If siteLogic.Config("chargewithcreditcard") <> "1" Or Request("paymentmethod") = "chargebyphone" Then
            Return "style=""display:none;"""
        End If
        Return ""
    End Function

    Sub showPanels()
        If Request("success") = "true" Then
            successpanel.Visible = True
            checkoutpanel.Visible = False
            checkoutpagepanel.Visible = False
            msgpanel1.Visible = False
        Else
            If Request("success") = "false" Then
                _fieldLogic.showError(fieldLogic.messageType.alert, "ישנם בעיות עם נתוני כרטיס האשראי - אנא נסה שוב")
            End If
            successpanel.Visible = False
            checkoutpanel.Visible = True
            checkoutpagepanel.Visible = True
            If Not _userLogic.isUserLogged() Then
                loginpanel.Visible = True
                shippingpanel.Visible = False
                paymentpanel.Visible = False
            Else
                loginpanel.Visible = False
                shippingpanel.Visible = True
                paymentpanel.Visible = True
            End If
        End If
    End Sub

End Class
