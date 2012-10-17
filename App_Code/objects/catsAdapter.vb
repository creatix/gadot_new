Imports cs3.utils.databaseLogic

Public Class catsRow
    Implements IGenericRow

    Private _catsid As Integer
    Public Property catsid() As Integer
        Get
            Return _catsid
        End Get
        Set(ByVal Value As Integer)
            _catsid = Value
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

    Private _fatherid As Integer
    Public Property fatherid() As Integer
        Get
            Return _fatherid
        End Get
        Set(ByVal Value As Integer)
            _fatherid = Value
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

    Private _pic As String
    Public Property pic() As String
        Get
            Return _pic
        End Get
        Set(ByVal Value As String)
            _pic = Value
        End Set
    End Property

    Private _sort As String
    Public Property sort() As String
        Get
            Return _sort
        End Get
        Set(ByVal Value As String)
            _sort = Value
        End Set
    End Property

    Private _params As String
    Public Property params() As String
        Get
            Return _params
        End Get
        Set(ByVal Value As String)
            _params = Value
        End Set
    End Property

    Private _warranty As String
    Public Property warranty() As String
        Get
            Return _warranty
        End Get
        Set(ByVal Value As String)
            _warranty = Value
        End Set
    End Property

    Private _metatitle As String
    Public Property metatitle() As String
        Get
            Return _metatitle
        End Get
        Set(ByVal Value As String)
            _metatitle = Value
        End Set
    End Property

    Private _metadescription As String
    Public Property metadescription() As String
        Get
            Return _metadescription
        End Get
        Set(ByVal Value As String)
            _metadescription = Value
        End Set
    End Property

    Private _metakeywords As String
    Public Property metakeywords() As String
        Get
            Return _metakeywords
        End Get
        Set(ByVal Value As String)
            _metakeywords = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "catsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "cats"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _catsid = getReaderObject(reader, "catsid")
        _name = getReaderObject(reader, "name")
        _fatherid = getReaderObject(reader, "fatherid")
        _description = getReaderObject(reader, "description")
        _pic = getReaderObject(reader, "pic")
        _sort = getReaderObject(reader, "sort")
        _params = getReaderObject(reader, "params")
        _warranty = getReaderObject(reader, "warranty")
        _metatitle = getReaderObject(reader, "metatitle")
        _metadescription = getReaderObject(reader, "metadescription")
        _metakeywords = getReaderObject(reader, "metakeywords")
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

Public Class catsAdapter
    Inherits baseAdapter(Of catsRow)

End Class
