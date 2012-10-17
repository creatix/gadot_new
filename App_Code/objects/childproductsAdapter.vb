Imports cs3.utils.databaseLogic

Public Class childproductsRow
    Implements IGenericRow

    Private _childproductsid As Integer
    Public Property childproductsid() As Integer
        Get
            Return _childproductsid
        End Get
        Set(ByVal Value As Integer)
            _childproductsid = Value
        End Set
    End Property

    Private _fatherid As Integer
    Public Property fatherid() As Integer
        Get
            Return _fatherid
        End Get
        Set(ByVal Value As Integer)
            _fatherid = Value
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

    Private _carat As Double
    Public Property carat() As Double
        Get
            Return _carat
        End Get
        Set(ByVal Value As Double)
            _carat = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _childproductsid = toNothing(reader("childproductsid"))
        _fatherid = toNothing(reader("fatherid"))
        _name = toNothing(reader("name"))
        _price = toNothing(reader("price"))
        _carat = toNothing(reader("carat"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "childproductsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "childproducts"
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

Public Class childproductsAdapter
    Inherits baseAdapter(Of childproductsRow)

End Class