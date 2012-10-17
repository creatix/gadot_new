Imports cs3.utils.databaseLogic

Public Class deliveryRow
    Implements IGenericRow

    Private _deliveryid As Integer
    Public Property deliveryid() As Integer
        Get
            Return _deliveryid
        End Get
        Set(ByVal Value As Integer)
            _deliveryid = Value
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

    Private _deliverytime As String
    Public Property deliverytime() As String
        Get
            Return _deliverytime
        End Get
        Set(ByVal Value As String)
            _deliverytime = Value
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

    Public Overridable Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _deliveryid = toNothing(reader("deliveryid"))
        _name = toNothing(reader("name"))
        _price = toNothing(reader("price"))
        _deliverytime = toNothing(reader("deliverytime"))
        _sort = toNothing(reader("sort"))
    End Sub

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "deliveryid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "delivery"
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

Public Class deliveryAdapter
    Inherits baseAdapter(Of deliveryRow)

End Class