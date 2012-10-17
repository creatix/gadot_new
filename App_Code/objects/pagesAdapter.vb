Imports cs3.utils.databaseLogic

Public Class pagesRow
    Implements IGenericRow

    Private _pagesid As Integer
    Public Property pagesid() As Integer
        Get
            Return _pagesid
        End Get
        Set(ByVal Value As Integer)
            _pagesid = Value
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

    Private _content1 As String
    Public Property content1() As String
        Get
            Return _content1
        End Get
        Set(ByVal Value As String)
            _content1 = Value
        End Set
    End Property

    Private _fatherid As Double
    Public Property fatherid() As Double
        Get
            Return _fatherid
        End Get
        Set(ByVal Value As Double)
            _fatherid = Value
        End Set
    End Property

    Private _title As String
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property

    Private _page_link As String
    Public Property page_link() As String
        Get
            Return _page_link
        End Get
        Set(ByVal Value As String)
            _page_link = Value
        End Set
    End Property

    Private _content2 As String
    Public Property content2() As String
        Get
            Return _content2
        End Get
        Set(ByVal Value As String)
            _content2 = Value
        End Set
    End Property

    Private _hidefromfooter As String
    Public Property hidefromfooter() As String
        Get
            Return _hidefromfooter
        End Get
        Set(ByVal Value As String)
            _hidefromfooter = Value
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

    Private _hide As String
    Public Property hide() As String
        Get
            Return _hide
        End Get
        Set(ByVal Value As String)
            _hide = Value
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

    Private _url As String
    Public Property url() As String
        Get
            Return _url
        End Get
        Set(ByVal Value As String)
            _url = Value
        End Set
    End Property

    Private _menuname As String
    Public Property menuname() As String
        Get
            Return _menuname
        End Get
        Set(ByVal Value As String)
            _menuname = Value
        End Set
    End Property

    Private _leftbanner As String
    Public Property leftbanner() As String
        Get
            Return _leftbanner
        End Get
        Set(ByVal Value As String)
            _leftbanner = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "pagesid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "pages"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _pagesid = getReaderObject(reader, "pagesid")
        _name = getReaderObject(reader, "name")
        _content1 = getReaderObject(reader, "content1")
        _fatherid = getReaderObject(reader, "fatherid")
        _title = getReaderObject(reader, "title")
        _page_link = getReaderObject(reader, "page_link")
        _content2 = getReaderObject(reader, "content2")
        _hidefromfooter = getReaderObject(reader, "hidefromfooter")
        _sort = getReaderObject(reader, "sort")
        _hide = getReaderObject(reader, "hide")
        _metatitle = getReaderObject(reader, "metatitle")
        _metadescription = getReaderObject(reader, "metadescription")
        _metakeywords = getReaderObject(reader, "metakeywords")
        _url = getReaderObject(reader, "url")
        _menuname = getReaderObject(reader, "menuname")
        _leftbanner = getReaderObject(reader, "leftbanner")
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

Public Class pagesAdapter
    Inherits baseAdapter(Of pagesRow)

End Class

