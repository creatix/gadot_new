Imports cs3.DataLayer
Imports cs3.utils.databaseLogic
Imports System.Net
Imports System.IO
Imports System.Xml

Public Class basketViewRow
    Inherits basketRow

    Private _productsid As Integer
    Public Property productsid() As Integer
        Get
            Return _productsid
        End Get
        Set(ByVal Value As Integer)
            _productsid = Value
        End Set
    End Property

    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
        End Set
    End Property

    Private _price As Double
    Public Property price() As Double
        Get
            Return _price
        End Get
        Set(ByVal Value As Double)
            _price = Value
        End Set
    End Property

    Private _catalogno As String
    Public Property catalogno() As String
        Get
            Return _catalogno
        End Get
        Set(ByVal Value As String)
            _catalogno = Value
        End Set
    End Property

    Private _catid As Integer
    Public Property catid() As Integer
        Get
            Return _catid
        End Get
        Set(ByVal Value As Integer)
            _catid = Value
        End Set
    End Property

    Private _pic As String
    Public Property pic() As String
        Get
            Return _pic
        End Get
        Set(ByVal Value As String)
            _pic = Value
        End Set
    End Property

    Private _shipping As String
    Public Property shipping() As String
        Get
            Return _shipping
        End Get
        Set(ByVal Value As String)
            _shipping = Value
        End Set
    End Property

    Public ReadOnly Property totalprice() As Double
        Get
            Return (_price + addprice) * itemscount
        End Get
    End Property

    Public ReadOnly Property displayname() As String
        Get
            If addname <> "" Then Return name & "<br>" & addname
            Return name
        End Get
    End Property

    Public Overrides Sub Fill(ByVal reader As System.Data.IDataReader)
        basketid = toNothing(reader("basketid"))
        userid = toNothing(reader("userid"))
        productid = toNothing(reader("productid"))
        itemscount = toNothing(reader("itemscount"))
        insertdate = toNothing(reader("insertdate"))
        productsid = toNothing(reader("productsid"))
        name = toNothing(reader("name"))
        price = toNothing(reader("price"))
        catalogno = toNothing(reader("catalogno"))
        catid = toNothing(reader("catid"))
        pic = toNothing(reader("pic"))
        addprice = toNothing(reader("addprice"))
        addname = toNothing(reader("addname"))
        childproductid = toNothing(reader("childproductid"))
        shipping = toNothing(reader("shipping"))
    End Sub

End Class

Public Class basketLogic

    Dim _basketAdapter As New baseAdapter(Of basketRow)
    Dim _userLogic As New userLogic

    Function getUserBasket() As pList(Of basketViewRow)

        Dim _basketViewAdapter As New baseAdapter(Of basketViewRow)
        Dim basketList As pList(Of basketViewRow) = _basketViewAdapter.GetList("userid=" & _userLogic.getUserID(), , , , "basketView")
        setBasketSession(basketList)
        Return basketList

    End Function

    Function addBasketItem(ByVal productid As Integer, Optional ByVal childproductid As Integer = 0, Optional ByVal quantity As Integer = 1, Optional ByVal addname As String = "", Optional ByVal catalognum As String = "") As Boolean

        Dim basketList As pList(Of basketRow) = _basketAdapter.GetList("userid=" & _userLogic.getUserID())
        Dim addNewRow As Boolean = True

        For Each basketRow As basketRow In basketList
            If basketRow.productid = productid And basketRow.childproductid = childproductid Then
                basketRow.rowState.setState(RowState.Updated)
                basketRow.itemscount += quantity
                addNewRow = False
                Exit For
            End If
        Next

        If addNewRow Then
            basketList.Add(getNewRow(productid, childproductid, quantity, addname, catalognum))
        End If

        _basketAdapter.UpdateList(basketList)

        Return True

    End Function

    Function getNewRow(ByVal productid As Integer, Optional ByVal childproductid As Integer = 0, Optional ByVal quantity As Integer = 1, Optional ByVal addname As String = "", Optional ByVal catalognum As String = "") As basketRow
        Dim newBasketRow As New basketRow
        newBasketRow.rowState.setState(RowState.Inserted)
        newBasketRow.productid = productid
        newBasketRow.userid = _userLogic.getUserID()
        newBasketRow.itemscount = quantity
        newBasketRow.addname = addname
        newBasketRow.catalogno = catalognum
        Dim _childRow As childproductsRow = getChildProduct(childproductid)
        If Not _childRow Is Nothing Then
            newBasketRow.childproductid = childproductid
            newBasketRow.addname = _childRow.displayname
            newBasketRow.addprice = _childRow.price
        End If
        Return newBasketRow
    End Function

    Function getChildProduct(ByVal childproductid As Integer) As childproductsRow
        If childproductid <= 0 Then Return Nothing
        Dim _childproductsAdapter As New childproductsAdapter
        Return _childproductsAdapter.GetItem(childproductid)
    End Function

    Function deleteBasketItem(ByVal basketid As Integer) As Boolean
        If _basketAdapter.Delete(basketid) Then
            Return True
        End If
    End Function

    Function getTotalPrice(ByVal basketItems As pList(Of basketViewRow)) As Double
        Dim totalPrice As Double = 0
        For Each basketItem As basketViewRow In basketItems
            totalPrice += basketItem.totalprice
        Next
        Return totalPrice
    End Function

    Function getShippmentPrice(ByVal shippingid As Integer) As Double
        If shippingid > 0 Then
            Dim _deliveryAdapter As New deliveryAdapter
            Dim deliveryRow As deliveryRow = _deliveryAdapter.GetItem(shippingid)
            If Not deliveryRow Is Nothing Then
                Return deliveryRow.price
            End If
        End If
        Return 0
    End Function

    Function getInterestSum(ByVal totalPrice As Double, ByVal payments As Integer) As Double
        Return Math.Round(getInterest(payments) / 100 * totalPrice)
    End Function

    Function getInterest(ByVal payments As Integer) As Double
        Dim _paymentinterestAdapter As New paymentinterestAdapter
        Dim _paymentinterestRow As paymentinterestRow = _paymentinterestAdapter.GetItem(payments)
        If Not _paymentinterestRow Is Nothing Then
            Return _paymentinterestRow.interest
        End If
        Return 0
    End Function

    Sub setBasketSession(ByVal basketList As pList(Of basketViewRow))
        Dim itemscount As Integer = 0
        If Not basketList Is Nothing Then
            For Each basketRow As basketRow In basketList
                itemscount += basketRow.itemscount
            Next
        End If
        HttpContext.Current.Session("basketitemscount") = itemscount
    End Sub

    Function getBasketSession() As Integer
        Dim itemscount As Integer = 0
        If IsNumeric(HttpContext.Current.Session("basketitemscount")) Then
            itemscount = HttpContext.Current.Session("basketitemscount")
        End If
        Return itemscount
    End Function

End Class

Public Class couponsLogic

    Dim _fieldLogic As New fieldLogic
    Dim _couponsAdapter As New couponsAdapter

    Function getCouponCode() As String
        If HttpContext.Current.Session("coupons") Is Nothing Then
            Return ""
        End If
        Return HttpContext.Current.Session("coupons")
    End Function

    Sub setCouponCode(ByVal value As String)
        HttpContext.Current.Session("coupons") = value
    End Sub

    Function loadCoupon(ByVal code As String) As Boolean

        If code = "" Then
            _fieldLogic.showError("error", "אנא הכנס קופון")
            Return False
        End If

        Dim couponRow As couponsRow = getCoupon(code)

        If couponRow Is Nothing Then
            _fieldLogic.showError("error", "קופון לא נמצא")
            Return False
        End If

        If couponRow.isactive <> 1 Then
            _fieldLogic.showError("error", "קופון לא פעיל")
            Return False
        End If

        If Now < couponRow.startdate Or Now > couponRow.enddate Then
            _fieldLogic.showError("error", "קופון לא בתוקף")
            Return False
        End If

        setCouponCode(couponRow.code)

        Return True

    End Function

    Function getCoupon(ByVal code As String) As couponsRow
        Dim couponRow As couponsRow = _couponsAdapter.GetItem(0, "code='" & code & "'")
        Return couponRow
    End Function

    Function getCouponsDiscount(ByVal basketItems As pList(Of basketViewRow)) As Integer

        Dim coupons As String = getCouponCode()
        If coupons = "" Then
            Return 0
        End If

        Dim couponRow As couponsRow = getCoupon(coupons)

        Return getCouponDiscount(couponRow, basketItems)

    End Function

    Function getCouponDiscount(ByVal couponsRow As couponsRow, ByVal basketItems As pList(Of basketViewRow)) As Integer
        If couponsRow Is Nothing Then
            Return 0
        End If
        Select Case couponsRow.type
            Case "1"
                Dim totalPrice As Double = 0
                For Each basketItem As basketViewRow In basketItems
                    totalPrice += basketItem.totalprice
                Next
                If couponsRow.discountop = "%" Then
                    Return (couponsRow.discount / 100) * totalPrice
                ElseIf couponsRow.discountop = "₪" Then
                    Return couponsRow.discount
                End If
                Return totalPrice
            Case "2"
            Case "3"
        End Select
    End Function

    Sub couponUsed(ByVal code As String, ByVal orderid As Integer)
        If code = "" Then
            Exit Sub
        End If
        Dim couponRow As couponsRow = getCoupon(code)
        If Not couponRow Is Nothing Then
            If couponRow.isonetime = 1 Then
                couponRow.isactive = 0
                couponRow.useddate = Now
                couponRow.orderid = orderid
                _couponsAdapter.Update(couponRow)
            End If
        End If
    End Sub

End Class

Public Class paymentLogic

    Function charge() As Boolean

    End Function

    Sub redirectOrder(orderid As Integer, total As Double)
        If HttpContext.Current.Request("paymentmethod") = "chargewithpaypal" And HttpContext.Current.Request("payment_paypalaccount") <> "" Then
            HttpContext.Current.Response.Redirect("redirecttopaypal.aspx?oid=" & orderid & "&amount=" & total)
        ElseIf HttpContext.Current.Request("paymentmethod") = "chargewithcreditcard" Then
            If siteLogic.Config("paymentmethod") = "Tranzila" Then
                HttpContext.Current.Response.Redirect("redirecttotranzila.aspx?oid=" & orderid & "&amount=" & total)
            End If
            If siteLogic.Config("paymentmethod") = "CreditGuard" Then
                redirectToCreditGuard(orderid, total)
            End If
        End If
        HttpContext.Current.Response.Redirect("checkout.aspx?success=true&oid=" & orderid)
    End Sub

    Sub redirectToCreditGuard(orderid As Integer, total As Double)

        Dim _userLogic As New userLogic
        total = total * 100

        Dim paymentsNum As Integer = 1

        Dim firstpayment As Double = 0
        Dim periodicalPayment As Double = 0
        Dim creditType As String = "RegularCredit"

        If paymentsNum > 1 Then
            firstpayment = total / paymentsNum
            periodicalPayment = total / paymentsNum
            creditType = "Payments"
            paymentsNum -= 1
        End If

        Dim xml_data As String = "<ashrait>"
        xml_data &= "<request>"
        xml_data &= "<version>1000</version>"
        xml_data &= "<language>HEB</language>"
        xml_data &= "<dateTime/>"
        xml_data &= "<command>doDeal</command>"
        xml_data &= "<requestid/>"
        xml_data &= "<doDeal>"
        xml_data &= "<terminalNumber>" & siteLogic.Config("payment_creditguardterminalnumber") & "</terminalNumber>"
        xml_data &= "<cardNo>CGMPI</cardNo>"
        xml_data &= "<total>" & total & "</total>"
        xml_data &= "<transactionType>Debit</transactionType>"
        xml_data &= "<creditType>" & creditType & "</creditType>"
        xml_data &= "<currency>ILS</currency>"
        xml_data &= "<transactionCode>Phone</transactionCode>"
        xml_data &= "<validation>TxnSetup</validation>"
        xml_data &= "<user>request identifier</user>"
        xml_data &= "<eci></eci>"
        xml_data &= "<mid>" & siteLogic.Config("payment_creditguardmid") & "</mid>"
        xml_data &= "<uniqueid>" & orderid & "</uniqueid>"
        xml_data &= "<mpiValidation>AutoComm</mpiValidation>"
        xml_data &= "<description>" & "תשלום באתר טולמנס" & "</description>"
        xml_data &= "<email>" & _userLogic.getLoggedUser.email & "</email>"
        If paymentsNum > 1 Then
            xml_data &= "<firstPayment>" & firstpayment & "</firstPayment>"
            xml_data &= "<periodicalPayment>" & periodicalPayment & "</periodicalPayment>"
            xml_data &= "<numberOfPayments>" & paymentsNum & "</numberOfPayments>"
        End If
        xml_data &= "<customerData>"
        xml_data &= "<userData1/>"
        xml_data &= "<userData2/>"
        xml_data &= "<userData3/>"
        xml_data &= "<userData4/>"
        xml_data &= "<userData5/>"
        xml_data &= "<userData6/>"
        xml_data &= "<userData7/>"
        xml_data &= "<userData8/>"
        xml_data &= "<userData9/>"
        xml_data &= "<userData10/>"
        xml_data &= "</customerData>"
        xml_data &= "</doDeal>"
        xml_data &= "</request>"
        xml_data &= "</ashrait>"

        Dim post_data As String = "user=" & siteLogic.Config("payment_creditguardusername") & "&password=" & siteLogic.Config("payment_creditguardpassword") & "&int_in=" & xml_data

        'Dim uri As String = "https://server.creditguard.co.il/xpo/Relay"
        Dim uri As String = "https://cgpay3.creditguard.co.il/xpo/Relay"

        Dim _request As HttpWebRequest = WebRequest.Create(uri)
        _request.KeepAlive = False
        _request.ProtocolVersion = HttpVersion.Version10
        _request.Method = "POST"

        'byte[] postBytes = Encoding.ASCII.GetBytes(post_data);
        Dim postBytes As Byte() = Encoding.GetEncoding("UTF-8").GetBytes(post_data)

        _request.ContentType = "application/x-www-form-urlencoded"
        _request.ContentLength = postBytes.Length
        Dim requestStream As Stream = _request.GetRequestStream()

        requestStream.Write(postBytes, 0, postBytes.Length)
        requestStream.Close()

        Dim _response As HttpWebResponse = _request.GetResponse()
        Dim strXML As String = New StreamReader(_response.GetResponseStream(), Encoding.GetEncoding("UTF-8")).ReadToEnd()
        'Response.Write(str)

        Dim doc As XmlDocument = New XmlDocument()
        doc.LoadXml(strXML)
        Dim RootNode As XmlElement = doc.DocumentElement
        Dim nodeList As XmlNodeList = RootNode.GetElementsByTagName("mpiHostedPageUrl")

        'Try
        HttpContext.Current.Response.Redirect(nodeList(0).InnerText)
        'Catch ex As Exception
        'Dim _mailLogic As New mailLogic
        '_mailLogic.sendMail("באג בטולמנס", strXML, siteLogic.Config("siteemail"), "elismargon@gmail.com")
        '_fieldLogic.showError("error", "שגיאה בעמוד סליקה")
        'End Try

    End Sub

    Sub finishOrder()
        If IsNumeric(HttpContext.Current.Request("spo")) Then
            Dim _ordersAdapter As New ordersAdapter
            Dim oi As ordersRow = _ordersAdapter.GetItem(CInt(HttpContext.Current.Request("spo")))
            If Not oi Is Nothing Then
                oi.admincomments = oi.admincomments & vbNewLine & "Paypal order: Approved"
                _ordersAdapter.Update(oi)
                HttpContext.Current.Response.Redirect("checkout.aspx?oid=" & HttpContext.Current.Request("spo") & "&success=true")
            End If
        End If
        If IsNumeric(HttpContext.Current.Request("TranzilaToken")) Then
            Dim _ordersAdapter As New ordersAdapter
            Dim _order As ordersRow = _ordersAdapter.GetItem(CInt(HttpContext.Current.Request("TranzilaToken")))
            If Not _order Is Nothing Then
                If HttpContext.Current.Request("Response") = "000" Then
                    _order.admincomments = _order.admincomments & vbNewLine & "Tranzila order" & vbNewLine & "ConfirmationCode: " & HttpContext.Current.Request("ConfirmationCode")
                    _ordersAdapter.Update(_order)
                    HttpContext.Current.Response.Redirect("checkout.aspx?oid=" & HttpContext.Current.Request("TranzilaToken") & "&success=true")
                Else
                    _order.admincomments = _order.admincomments & vbNewLine & "Tranzila order" & vbNewLine & "ישנה בעיה בסליקה: " & HttpContext.Current.Request("Response")
                    _ordersAdapter.Update(_order)
                    HttpContext.Current.Response.Redirect("checkout.aspx?success=false")
                End If
            End If
        End If
        If IsNumeric(HttpContext.Current.Request("uniqueID")) Then
            Dim _ordersAdapter As New ordersAdapter
            Dim oi As ordersRow = _ordersAdapter.GetItem(CInt(HttpContext.Current.Request("uniqueID")))
            If Not IsNumeric(HttpContext.Current.Request("ErrorCode")) Then
                oi.admincomments = oi.admincomments & vbNewLine & "Authorization Number: " & HttpContext.Current.Request("authNumber")
                _ordersAdapter.Update(oi)
                HttpContext.Current.Response.Redirect("checkout.aspx?oid=" & HttpContext.Current.Request("uniqueID") & "&success=true")
            Else
                oi.admincomments = oi.admincomments & vbNewLine & "ErrorCode: " & HttpContext.Current.Request("ErrorCode") & vbNewLine & "ErrorText: " & HttpContext.Current.Request("ErrorText")
                _ordersAdapter.Update(oi)
                HttpContext.Current.Response.Redirect("checkout.aspx?success=false")
            End If
        End If
    End Sub

End Class