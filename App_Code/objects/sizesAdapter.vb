Imports cs3.utils.databaseLogic

Public Class sizesRow
    Implements IGenericRow

    Private _sizesid As Integer
    Public Property sizesid() As Integer
        Get
            Return _sizesid
        End Get
        Set(ByVal Value As Integer)
            _sizesid = Value
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

    Private _productid As Integer
    Public Property productid() As Integer
        Get
            Return _productid
        End Get
        Set(ByVal Value As Integer)
            _productid = Value
        End Set
    End Property

    Private _catalognum As String
    Public Property catalognum() As String
        Get
            Return _catalognum
        End Get
        Set(ByVal Value As String)
            _catalognum = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "sizesid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "sizes"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _sizesid = getReaderObject(reader, "sizesid")
        _name = getReaderObject(reader, "name")
        _productid = getReaderObject(reader, "productid")
        _catalognum = getReaderObject(reader, "catalognum")
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

Public Class sizesAdapter
    Inherits baseAdapter(Of sizesRow)

End Class
