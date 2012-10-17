Imports cs3.utils.databaseLogic

Public Class productsRow
    Implements IGenericRow

    Private _productsid As Integer
    Public Property productsid() As Integer
        Get
            Return _productsid
        End Get
        Set(ByVal Value As Integer)
            _productsid = Value
        End Set
    End Property

    Private _catalogno As String
    Public Property catalogno() As String
        Get
            Return _catalogno
        End Get
        Set(ByVal Value As String)
            _catalogno = Value
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

    Private _price As Double
    Public Property price() As Double
        Get
            Return _price
        End Get
        Set(ByVal Value As Double)
            _price = Value
        End Set
    End Property

    Private _catid As Integer
    Public Property catid() As Integer
        Get
            Return _catid
        End Get
        Set(ByVal Value As Integer)
            _catid = Value
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

    Private _pic1 As String
    Public Property pic1() As String
        Get
            Return _pic1
        End Get
        Set(ByVal Value As String)
            _pic1 = Value
        End Set
    End Property

    Private _pic2 As String
    Public Property pic2() As String
        Get
            Return _pic2
        End Get
        Set(ByVal Value As String)
            _pic2 = Value
        End Set
    End Property

    Private _pic3 As String
    Public Property pic3() As String
        Get
            Return _pic3
        End Get
        Set(ByVal Value As String)
            _pic3 = Value
        End Set
    End Property

    Private _pic4 As String
    Public Property pic4() As String
        Get
            Return _pic4
        End Get
        Set(ByVal Value As String)
            _pic4 = Value
        End Set
    End Property

    Private _shortdescription As String
    Public Property shortdescription() As String
        Get
            Return _shortdescription
        End Get
        Set(ByVal Value As String)
            _shortdescription = Value
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

    Private _sort As Integer
    Public Property sort() As Integer
        Get
            Return _sort
        End Get
        Set(ByVal Value As Integer)
            _sort = Value
        End Set
    End Property

    Private _hide As Integer
    Public Property hide() As Integer
        Get
            Return _hide
        End Get
        Set(ByVal Value As Integer)
            _hide = Value
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

    Private _shipping_time As String
    Public Property shipping_time() As String
        Get
            Return _shipping_time
        End Get
        Set(ByVal Value As String)
            _shipping_time = Value
        End Set
    End Property

    Private _introduction As String
    Public Property introduction() As String
        Get
            Return _introduction
        End Get
        Set(ByVal Value As String)
            _introduction = Value
        End Set
    End Property

    Private _pdffile1 As String
    Public Property pdffile1() As String
        Get
            Return _pdffile1
        End Get
        Set(ByVal Value As String)
            _pdffile1 = Value
        End Set
    End Property

    Private _accessories As String
    Public Property accessories() As String
        Get
            Return _accessories
        End Get
        Set(ByVal Value As String)
            _accessories = Value
        End Set
    End Property

    Private _originalprice As Double
    Public Property originalprice() As Double
        Get
            Return _originalprice
        End Get
        Set(ByVal Value As Double)
            _originalprice = Value
        End Set
    End Property

    Private _icons As String
    Public Property icons() As String
        Get
            Return _icons
        End Get
        Set(ByVal Value As String)
            _icons = Value
        End Set
    End Property

    Private _desc2 As String
    Public Property desc2() As String
        Get
            Return _desc2
        End Get
        Set(ByVal Value As String)
            _desc2 = Value
        End Set
    End Property

    Private _shipping As String
    Public Property shipping() As String
        Get
            Return _shipping
        End Get
        Set(ByVal Value As String)
            _shipping = Value
        End Set
    End Property

    Private _description1 As String
    Public Property description1() As String
        Get
            Return _description1
        End Get
        Set(ByVal Value As String)
            _description1 = Value
        End Set
    End Property

    Private _description2 As String
    Public Property description2() As String
        Get
            Return _description2
        End Get
        Set(ByVal Value As String)
            _description2 = Value
        End Set
    End Property

    Private _relatedproducts As String
    Public Property relatedproducts() As String
        Get
            Return _relatedproducts
        End Get
        Set(ByVal Value As String)
            _relatedproducts = Value
        End Set
    End Property

    Private _manname As String
    Public Property manname() As String
        Get
            Return _manname
        End Get
        Set(ByVal Value As String)
            _manname = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "productsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "products"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _productsid = getReaderObject(reader, "productsid")
        _catalogno = getReaderObject(reader, "catalogno")
        _name = getReaderObject(reader, "name")
        _price = getReaderObject(reader, "price")
        _catid = getReaderObject(reader, "catid")
        _pic = getReaderObject(reader, "pic")
        _shortdescription = getReaderObject(reader, "shortdescription")
        _description = getReaderObject(reader, "description")
        _metatitle = getReaderObject(reader, "metatitle")
        _metadescription = getReaderObject(reader, "metadescription")
        _metakeywords = getReaderObject(reader, "metakeywords")
        _pic1 = getReaderObject(reader, "pic1")
        _pic2 = getReaderObject(reader, "pic2")
        _pic3 = getReaderObject(reader, "pic3")
        _pic4 = getReaderObject(reader, "pic4")
        _sort = getReaderObject(reader, "sort")
        _hide = getReaderObject(reader, "hide")
        _introduction = getReaderObject(reader, "introduction")
        _pdffile1 = getReaderObject(reader, "pdffile1")
        _accessories = getReaderObject(reader, "accessories")
        _originalprice = getReaderObject(reader, "originalprice")
        _icons = getReaderObject(reader, "icons")
        _desc2 = getReaderObject(reader, "desc2")
        _shipping = getReaderObject(reader, "shipping")
        _description1 = getReaderObject(reader, "description1")
        _description2 = getReaderObject(reader, "description2")
        _relatedproducts = getReaderObject(reader, "relatedproducts")
        _manname = getReaderObject(reader, "manname")
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

Public Class productsAdapter
    Inherits baseAdapter(Of productsRow)

End Class
