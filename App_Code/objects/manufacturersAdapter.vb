Imports cs3.utils.databaseLogic

Public Class manufacturersRow
    Implements IGenericRow

    Private _manufacturersid As Integer
    Public Property manufacturersid() As Integer
        Get
            Return _manufacturersid
        End Get
        Set(ByVal Value As Integer)
            _manufacturersid = Value
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

    Private _logo As String
    Public Property logo() As String
        Get
            Return _logo
        End Get
        Set(ByVal Value As String)
            _logo = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "manufacturersid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "manufacturers"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _manufacturersid = getReaderObject(reader, "manufacturersid")
        _name = getReaderObject(reader, "name")
        _logo = getReaderObject(reader, "logo")
        _description = getReaderObject(reader, "description")
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

Public Class manufacturersAdapter
    Inherits baseAdapter(Of manufacturersRow)

End Class
