Imports cs3.utils.databaseLogic

Public Class bannersRow
    Implements IGenericRow

    Private _bannersid As Integer
    Public Property bannersid() As Integer
        Get
            Return _bannersid
        End Get
        Set(ByVal Value As Integer)
            _bannersid = Value
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

    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
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

    Private _link As String
    Public Property link() As String
        Get
            Return _link
        End Get
        Set(ByVal Value As String)
            _link = Value
        End Set
    End Property

    Private _bannercontent As String
    Public Property bannercontent() As String
        Get
            Return _bannercontent
        End Get
        Set(ByVal Value As String)
            _bannercontent = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _bannersid = toNothing(reader("bannersid"))
        _name = toNothing(reader("name"))
        _type = toNothing(reader("type"))
        _pic = toNothing(reader("pic"))
        _link = toNothing(reader("link"))
        _bannercontent = toNothing(reader("bannercontent"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "bannersid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "banners"
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

Public Class bannersAdapter
    Inherits baseAdapter(Of bannersRow)

End Class