Imports cs3.utils.databaseLogic

Public Class templatesRow
    Implements IGenericRow

    Private _templatesid As Integer
    Public Property templatesid() As Integer
        Get
            Return _templatesid
        End Get
        Set(ByVal Value As Integer)
            _templatesid = Value
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

    Private _folder As String
    Public Property folder() As String
        Get
            Return _folder
        End Get
        Set(ByVal Value As String)
            _folder = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "templatesid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "templates"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _templatesid = getReaderObject(reader, "templatesid")
        _name = getReaderObject(reader, "name")
        _pic = getReaderObject(reader, "pic")
        _folder = getReaderObject(reader, "folder")
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

Public Class templatesAdapter
    Inherits baseAdapter(Of templatesRow)

End Class
