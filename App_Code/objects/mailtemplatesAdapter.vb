Imports cs3.utils.databaseLogic

Public Class mailtemplatesRow
    Implements IGenericRow

    Private _mailtemplatesid As Integer
    Public Property mailtemplatesid() As Integer
        Get
            Return _mailtemplatesid
        End Get
        Set(ByVal Value As Integer)
            _mailtemplatesid = Value
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

    Private _subject As String
    Public Property subject() As String
        Get
            Return _subject
        End Get
        Set(ByVal Value As String)
            _subject = Value
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

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "mailtemplatesid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "mailtemplates"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _mailtemplatesid = getReaderObject(reader, "mailtemplatesid")
        _name = getReaderObject(reader, "name")
        _subject = getReaderObject(reader, "subject")
        _content1 = getReaderObject(reader, "content1")
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

Public Class mailtemplatesAdapter
    Inherits baseAdapter(Of mailtemplatesRow)

End Class
