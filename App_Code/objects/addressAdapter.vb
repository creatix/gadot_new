Imports cs3.utils.databaseLogic

Public Class addressRow
    Implements IGenericRow

    Private _addressid As Integer
    Public Property addressid() As Integer
        Get
            Return _addressid
        End Get
        Set(ByVal Value As Integer)
            _addressid = Value
        End Set
    End Property

    Private _userid As Integer
    Public Property userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal Value As Integer)
            _userid = Value
        End Set
    End Property

    Private _firstname As String
    Public Property firstname() As String
        Get
            Return _firstname
        End Get
        Set(ByVal Value As String)
            _firstname = Value
        End Set
    End Property

    Private _lastname As String
    Public Property lastname() As String
        Get
            Return _lastname
        End Get
        Set(ByVal Value As String)
            _lastname = Value
        End Set
    End Property

    Private _city As String
    Public Property city() As String
        Get
            Return _city
        End Get
        Set(ByVal Value As String)
            _city = Value
        End Set
    End Property

    Private _street As String
    Public Property street() As String
        Get
            Return _street
        End Get
        Set(ByVal Value As String)
            _street = Value
        End Set
    End Property

    Private _housenum As String
    Public Property housenum() As String
        Get
            Return _housenum
        End Get
        Set(ByVal Value As String)
            _housenum = Value
        End Set
    End Property

    Private _apartmentnum As String
    Public Property apartmentnum() As String
        Get
            Return _apartmentnum
        End Get
        Set(ByVal Value As String)
            _apartmentnum = Value
        End Set
    End Property

    Private _zipcode As String
    Public Property zipcode() As String
        Get
            Return _zipcode
        End Get
        Set(ByVal Value As String)
            _zipcode = Value
        End Set
    End Property

    Private _phone As String
    Public Property phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal Value As String)
            _phone = Value
        End Set
    End Property

    Private _comments As String
    Public Property comments() As String
        Get
            Return _comments
        End Get
        Set(ByVal Value As String)
            _comments = Value
        End Set
    End Property

    Private _insertdate As DateTime
    Public Property insertdate() As DateTime
        Get
            Return _insertdate
        End Get
        Set(ByVal Value As DateTime)
            _insertdate = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _addressid = toNothing(reader("addressid"))
        _userid = toNothing(reader("userid"))
        _firstname = toNothing(reader("firstname"))
        _lastname = toNothing(reader("lastname"))
        _city = toNothing(reader("city"))
        _street = toNothing(reader("street"))
        _housenum = toNothing(reader("housenum"))
        _apartmentnum = toNothing(reader("apartmentnum"))
        _zipcode = toNothing(reader("zipcode"))
        _phone = toNothing(reader("phone"))
        _comments = toNothing(reader("comments"))
        _insertdate = toNothing(reader("insertdate"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "addressid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "address"
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

Public Class addressAdapter
    Inherits baseAdapter(Of addressRow)

End Class