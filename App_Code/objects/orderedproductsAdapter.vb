Imports cs3.utils.databaseLogic

Public Class orderedproductsRow
    Implements IGenericRow

    Private _productid As Integer
    Public Property productid() As Integer
        Get
            Return _productid
        End Get
        Set(ByVal Value As Integer)
            _productid = Value
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

    Private _userid As Integer
    Public Property userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal Value As Integer)
            _userid = Value
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

    Private _shortdescription As String
    Public Property shortdescription() As String
        Get
            Return _shortdescription
        End Get
        Set(ByVal Value As String)
            _shortdescription = Value
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

    Private _itemscount As Integer
    Public Property itemscount() As Integer
        Get
            Return _itemscount
        End Get
        Set(ByVal Value As Integer)
            _itemscount = Value
        End Set
    End Property

    Private _addname As String
    Public Property addname() As String
        Get
            Return _addname
        End Get
        Set(ByVal Value As String)
            _addname = Value
        End Set
    End Property

    Private _addprice As String
    Public Property addprice() As String
        Get
            Return _addprice
        End Get
        Set(ByVal Value As String)
            _addprice = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "orderedproductsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "orderedproducts"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _productid = toNothing(reader("productid"))
        _orderid = toNothing(reader("orderid"))
        _userid = toNothing(reader("userid"))
        _catalogno = toNothing(reader("catalogno"))
        _name = toNothing(reader("name"))
        _price = toNothing(reader("price"))
        _catid = toNothing(reader("catid"))
        _pic = toNothing(reader("pic"))
        _itemscount = toNothing(reader("itemscount"))
        _shortdescription = toNothing(reader("shortdescription"))
        _addname = toNothing(reader("addname"))
        _addprice = toNothing(reader("addprice"))
    End Sub

    Private _rowState As rowInfo
    Public Property rowState() As rowInfo Implements IGenericRow.rowState
        Get
            Return _rowState
        End Get
        Set(ByVal Value As rowInfo)
            _rowState = Value
        End Set
    End Property

End Class

Public Class orderedproductsAdapter
    Inherits baseAdapter(Of orderedproductsRow)

End Class
