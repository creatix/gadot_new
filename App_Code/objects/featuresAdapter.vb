Imports cs3.utils.databaseLogic

Public Class featuresRow
    Implements IGenericRow

    Private _featuresid As Integer
    Public Property featuresid() As Integer
        Get
            Return _featuresid
        End Get
        Set(ByVal Value As Integer)
            _featuresid = Value
        End Set
    End Property

    Private _content1 As String
    Public Property content1() As String
        Get
            Return _content1
        End Get
        Set(ByVal Value As String)
            _content1 = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "featuresid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "features"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _featuresid = getReaderObject(reader, "featuresid")
        _content1 = getReaderObject(reader, "content1")
        _productid = getReaderObject(reader, "productid")
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

Public Class featuresAdapter
    Inherits baseAdapter(Of featuresRow)

End Class
