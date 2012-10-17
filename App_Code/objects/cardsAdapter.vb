Imports cs3.utils.databaseLogic

Public Class cardsRow
    Implements IGenericRow

    Private _cardsid As Integer
    Public Property cardsid() As Integer
        Get
            Return _cardsid
        End Get
        Set(ByVal Value As Integer)
            _cardsid = Value
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

    Private _cardholdername As String
    Public Property cardholdername() As String
        Get
            Return _cardholdername
        End Get
        Set(ByVal Value As String)
            _cardholdername = Value
        End Set
    End Property

    Private _number As String
    Public Property number() As String
        Get
            Return _number
        End Get
        Set(ByVal Value As String)
            _number = Value
        End Set
    End Property

    Private _cvv As String
    Public Property cvv() As String
        Get
            Return _cvv
        End Get
        Set(ByVal Value As String)
            _cvv = Value
        End Set
    End Property

    Private _expirationmonth As String
    Public Property expirationmonth() As String
        Get
            Return _expirationmonth
        End Get
        Set(ByVal Value As String)
            _expirationmonth = Value
        End Set
    End Property

    Private _expirationyear As String
    Public Property expirationyear() As String
        Get
            Return _expirationyear
        End Get
        Set(ByVal Value As String)
            _expirationyear = Value
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

    Private _idcard As String
    Public Property idcard() As String
        Get
            Return _idcard
        End Get
        Set(ByVal Value As String)
            _idcard = Value
        End Set
    End Property

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _cardsid = toNothing(reader("cardsid"))
        _cardholdername = toNothing(reader("cardholdername"))
        _number = toNothing(reader("number"))
        _cvv = toNothing(reader("cvv"))
        _expirationmonth = toNothing(reader("expirationmonth"))
        _expirationyear = toNothing(reader("expirationyear"))
        _type = toNothing(reader("type"))
        _idcard = toNothing(reader("idcard"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "cardsid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "cards"
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

Public Class cardsAdapter
    Inherits baseAdapter(Of cardsRow)

End Class