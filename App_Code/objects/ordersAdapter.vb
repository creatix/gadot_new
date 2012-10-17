Imports cs3.utils.databaseLogic

Public Class ordersRow
    Implements IGenericRow

    Private _ordersid As Integer
    Public Property ordersid() As Integer
        Get
            Return _ordersid
        End Get
        Set(ByVal Value As Integer)
            _ordersid = Value
        End Set
    End Property

    Private _userid As Integer
    Public Property userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal Value As Integer)
            _userid = Value
        End Set
    End Property

    Private _deliveryaddressid As Integer
    Public Property deliveryaddressid() As Integer
        Get
            Return _deliveryaddressid
        End Get
        Set(ByVal Value As Integer)
            _deliveryaddressid = Value
        End Set
    End Property

    Private _billingaddressid As Integer
    Public Property billingaddressid() As Integer
        Get
            Return _billingaddressid
        End Get
        Set(ByVal Value As Integer)
            _billingaddressid = Value
        End Set
    End Property

    Private _deliveryid As Integer
    Public Property deliveryid() As Integer
        Get
            Return _deliveryid
        End Get
        Set(ByVal Value As Integer)
            _deliveryid = Value
        End Set
    End Property

    Private _cardid As Integer
    Public Property cardid() As Integer
        Get
            Return _cardid
        End Get
        Set(ByVal Value As Integer)
            _cardid = Value
        End Set
    End Property

    Private _totalprice As Double
    Public Property totalprice() As Double
        Get
            Return _totalprice
        End Get
        Set(ByVal Value As Double)
            _totalprice = Value
        End Set
    End Property

    Private _deliveryprice As Double
    Public Property deliveryprice() As Double
        Get
            Return _deliveryprice
        End Get
        Set(ByVal Value As Double)
            _deliveryprice = Value
        End Set
    End Property

    Private _discount As Double
    Public Property discount() As Double
        Get
            Return _discount
        End Get
        Set(ByVal Value As Double)
            _discount = Value
        End Set
    End Property

    Private _tax As Double
    Public Property tax() As Double
        Get
            Return _tax
        End Get
        Set(ByVal Value As Double)
            _tax = Value
        End Set
    End Property

    Private _payments As Double
    Public Property payments() As Double
        Get
            Return _payments
        End Get
        Set(ByVal Value As Double)
            _payments = Value
        End Set
    End Property

    Private _insertdate As DateTime
    Public Property insertdate() As DateTime
        Get
            Return _insertdate
        End Get
        Set(ByVal Value As DateTime)
            _insertdate = Value
        End Set
    End Property

    Private _usercomments As String
    Public Property usercomments() As String
        Get
            Return _usercomments
        End Get
        Set(ByVal Value As String)
            _usercomments = Value
        End Set
    End Property

    Private _admincomments As String
    Public Property admincomments() As String
        Get
            Return _admincomments
        End Get
        Set(ByVal Value As String)
            _admincomments = Value
        End Set
    End Property

    Private _paymentmethod As String
    Public Property paymentmethod() As String
        Get
            Return _paymentmethod
        End Get
        Set(ByVal Value As String)
            _paymentmethod = Value
        End Set
    End Property

    Private _referrersite As String
    Public Property referrersite() As String
        Get
            Return _referrersite
        End Get
        Set(ByVal Value As String)
            _referrersite = Value
        End Set
    End Property

    Private _ip As String
    Public Property ip() As String
        Get
            Return _ip
        End Get
        Set(ByVal Value As String)
            _ip = Value
        End Set
    End Property

    Private _statusid As Integer
    Public Property statusid() As Integer
        Get
            Return _statusid
        End Get
        Set(ByVal Value As Integer)
            _statusid = Value
        End Set
    End Property

    Private _coupon As String
    Public Property coupon() As String
        Get
            Return _coupon
        End Get
        Set(ByVal Value As String)
            _coupon = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _ordersid = toNothing(reader("ordersid"))
        _userid = toNothing(reader("userid"))
        _deliveryaddressid = toNothing(reader("deliveryaddressid"))
        _billingaddressid = toNothing(reader("billingaddressid"))
        _deliveryid = toNothing(reader("deliveryid"))
        _cardid = toNothing(reader("cardid"))
        _totalprice = toNothing(reader("totalprice"))
        _deliveryprice = toNothing(reader("deliveryprice"))
        _discount = toNothing(reader("discount"))
        _tax = toNothing(reader("tax"))
        _payments = toNothing(reader("payments"))
        _insertdate = toNothing(reader("insertdate"))
        _statusid = toNothing(reader("statusid"))
        _coupon = toNothing(reader("coupon"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "ordersid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "orders"
        End Get
    End Property

    Private _rowState As New rowInfo
    Public Property rowState() As rowInfo Implements IGenericRow.rowState
        Get
            Return _rowState
        End Get
        Set(ByVal Value As rowInfo)
            _rowState = Value
        End Set
    End Property

End Class

Public Class ordersAdapter
    Inherits baseAdapter(Of ordersRow)

End Class