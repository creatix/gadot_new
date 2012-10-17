Imports cs3.utils.databaseLogic

Public Class statusRow
    Implements IGenericRow

    Private _statusid As Integer
    Public Property statusid() As Integer
        Get
            Return _statusid
        End Get
        Set(ByVal Value As Integer)
            _statusid = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "statusid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "status"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _statusid = getReaderObject(reader, "statusid")
        _name = getReaderObject(reader, "name")
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

Public Class statusAdapter
    Inherits baseAdapter(Of statusRow)

End Class
