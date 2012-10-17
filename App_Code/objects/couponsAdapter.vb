Imports cs3.utils.databaseLogic

Public Class couponsRow
    Implements IGenericRow

    Private _couponsid As Integer
    Public Property couponsid() As Integer
        Get
            Return _couponsid
        End Get
        Set(ByVal Value As Integer)
            _couponsid = Value
        End Set
    End Property

    Private _code As String
    Public Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal Value As String)
            _code = Value
        End Set
    End Property

    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Private _discount As Integer
    Public Property discount() As Integer
        Get
            Return _discount
        End Get
        Set(ByVal Value As Integer)
            _discount = Value
        End Set
    End Property

    Private _discountop As String
    Public Property discountop() As String
        Get
            Return _discountop
        End Get
        Set(ByVal Value As String)
            _discountop = Value
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

    Private _productslist As String
    Public Property productslist() As String
        Get
            Return _productslist
        End Get
        Set(ByVal Value As String)
            _productslist = Value
        End Set
    End Property

    Private _startdate As DateTime
    Public Property startdate() As DateTime
        Get
            Return _startdate
        End Get
        Set(ByVal Value As DateTime)
            _startdate = Value
        End Set
    End Property

    Private _enddate As DateTime
    Public Property enddate() As DateTime
        Get
            Return _enddate
        End Get
        Set(ByVal Value As DateTime)
            _enddate = Value
        End Set
    End Property

    Private _isonetime As Integer
    Public Property isonetime() As Integer
        Get
            Return _isonetime
        End Get
        Set(ByVal Value As Integer)
            _isonetime = Value
        End Set
    End Property

    Private _description As String
    Public Property description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _isactive As Integer
    Public Property isactive() As Integer
        Get
            Return _isactive
        End Get
        Set(ByVal Value As Integer)
            _isactive = Value
        End Set
    End Property

    Private _orderid As Integer
    Public Property orderid() As Integer
        Get
            Return _orderid
        End Get
        Set(ByVal Value As Integer)
            _orderid = Value
        End Set
    End Property

    Private _useddate As DateTime
    Public Property useddate() As DateTime
        Get
            Return _useddate
        End Get
        Set(ByVal Value As DateTime)
            _useddate = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _couponsid = toNothing(reader("couponsid"))
        _code = toNothing(reader("code"))
        _type = toNothing(reader("type"))
        _discount = toNothing(reader("discount"))
        _discountop = toNothing(reader("discountop"))
        _catid = toNothing(reader("catid"))
        _productslist = toNothing(reader("productslist"))
        _startdate = toNothing(reader("startdate"))
        _enddate = toNothing(reader("enddate"))
        _isonetime = toNothing(reader("isonetime"))
        _description = toNothing(reader("description"))
        _isactive = toNothing(reader("isactive"))
        _orderid = toNothing(reader("orderid"))
        _useddate = toNothing(reader("useddate"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "couponsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "coupons"
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

Public Class couponsAdapter
    Inherits baseAdapter(Of couponsRow)

End Class