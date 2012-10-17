Imports cs3.utils.databaseLogic

Public Class paymentinterestRow
    Implements IGenericRow

    Private _paymentinterestid As Integer
    Public Property paymentinterestid() As Integer
        Get
            Return _paymentinterestid
        End Get
        Set(ByVal Value As Integer)
            _paymentinterestid = Value
        End Set
    End Property

    Private _payment As Integer
    Public Property payment() As Integer
        Get
            Return _payment
        End Get
        Set(ByVal Value As Integer)
            _payment = Value
        End Set
    End Property

    Private _interest As Double
    Public Property interest() As Double
        Get
            Return _interest
        End Get
        Set(ByVal Value As Double)
            _interest = Value
        End Set
    End Property

    Public ReadOnly Property primaryKey() As String Implements IGenericRow.primaryKey
        Get
            Return "paymentinterestid"
        End Get
    End Property

    Public ReadOnly Property tableName() As String Implements IGenericRow.tableName
        Get
            Return "paymentinterest"
        End Get
    End Property

    Public Sub Fill(ByVal reader As System.Data.IDataReader) Implements IGenericRow.Fill
        _paymentinterestid = getReaderObject(reader, "paymentinterestid")
        _payment = getReaderObject(reader, "payment")
        _interest = getReaderObject(reader, "interest")
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

Public Class paymentinterestAdapter
    Inherits baseAdapter(Of paymentinterestRow)

End Class
