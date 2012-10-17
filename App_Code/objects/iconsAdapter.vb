Imports cs3.utils.databaseLogic

Public Class iconsRow
    Implements IGenericRow

    Private _iconsid As Integer
    Public Property iconsid() As Integer
        Get
            Return _iconsid
        End Get
        Set(ByVal Value As Integer)
            _iconsid = Value
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

    Private _pic As String
    Public Property pic() As String
        Get
            Return _pic
        End Get
        Set(ByVal Value As String)
            _pic = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "iconsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "icons"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _iconsid = getReaderObject(reader, "iconsid")
        _name = getReaderObject(reader, "name")
        _pic = getReaderObject(reader, "pic")
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

Public Class iconsAdapter
    Inherits baseAdapter(Of iconsRow)

End Class
