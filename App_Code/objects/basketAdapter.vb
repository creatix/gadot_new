Imports cs3.utils.databaseLogic

Public Class basketRow
    Implements IGenericRow

    Private _basketid As Integer
    Public Property basketid() As Integer
        Get
            Return _basketid
        End Get
        Set(ByVal Value As Integer)
            _basketid = Value
        End Set
    End Property

    Private _userid As Int64
    Public Property userid() As Int64
        Get
            Return _userid
        End Get
        Set(ByVal Value As Int64)
            _userid = Value
        End Set
    End Property

    Private _productid As Integer
    Public Property productid() As Integer
        Get
            Return _productid
        End Get
        Set(ByVal Value As Integer)
            _productid = Value
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

    Private _insertdate As DateTime
    Public Property insertdate() As DateTime
        Get
            Return _insertdate
        End Get
        Set(ByVal Value As DateTime)
            _insertdate = Value
        End Set
    End Property

    Private _addprice As Double
    Public Property addprice() As Double
        Get
            Return _addprice
        End Get
        Set(ByVal Value As Double)
            _addprice = Value
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

    Private _childproductid As String
    Public Property childproductid() As String
        Get
            Return _childproductid
        End Get
        Set(ByVal Value As String)
            _childproductid = Value
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

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _basketid = toNothing(reader("basketid"))
        _userid = toNothing(reader("userid"))
        _productid = toNothing(reader("productid"))
        _itemscount = toNothing(reader("itemscount"))
        _insertdate = toNothing(reader("insertdate"))
        _addprice = toNothing(reader("addprice"))
        _addname = toNothing(reader("addname"))
        _childproductid = toNothing(reader("childproductid"))
        _catalogno = toNothing(reader("catalogno"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "basketid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "basket"
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

Public Class basketAdapter
    Inherits baseAdapter(Of basketRow)

    'Dim _baseAdapter As New baseAdapter

    'Public Function GetItem(ByVal id As Integer) As basketRow
    '    Return _baseAdapter.GetItem(Of basketRow)(id)
    'End Function

    'Public Function GetList(Optional ByVal query As String = "", Optional ByVal sortBy As String = "", Optional ByVal currentPage As Integer = 1, Optional ByVal pageSize As Integer = 10, Optional ByVal view As String = "") As pList(Of basketRow)
    '    Return _baseAdapter.GetList(Of basketRow)(query, sortBy, currentPage, pageSize, view)
    'End Function

    'Public Function Update(ByVal _basketRow As basketRow) As Boolean
    '    Return _baseAdapter.Update(Of basketRow)(_basketRow)
    'End Function

    'Public Function Delete(ByVal id As Integer) As Boolean
    '    Return _baseAdapter.Delete(Of basketRow)(id)
    'End Function

End Class