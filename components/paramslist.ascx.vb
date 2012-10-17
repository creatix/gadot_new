
Partial Class components_paramslist
    Inherits System.Web.UI.UserControl

    Public productid As Integer = 0
    Public catid As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If productid > 0 Then
            Dim _paramsvaluesAdapter As New paramsvaluesAdapter
            Dim quary As String = ""
            If catid = 0 Then
                quary = "productid=" & productid
            Else
                quary = "productid=" & productid & " AND catid=" & catid
            End If
            paramsRepeater.DataSource = _paramsvaluesAdapter.GetList(quary, "paramsstructureid", , 0)
            paramsRepeater.DataBind()
        End If

    End Sub

    Dim _paramsstructureAdapter As New paramsstructureAdapter

    Public Function getParamName(ByVal paramsstructureid As Integer) As String
        Dim ps As paramsstructureRow
        ps = _paramsstructureAdapter.GetItem(paramsstructureid)
        Return ps.name
    End Function

    Public Function getValue(ByVal value As String, ByVal componentname As String) As String
        If componentname = "checkbox" Then
            If value = "0" Then
                Return "<img src=""img/x_ico.gif"" width=""12"" height=""12"" />"
            End If
            If value = "1" Then
                Return "<img src=""img/vi.png"" width=""17"" height=""16"" />"
            End If
        End If
        Return value
    End Function

    Public Function getParamRow(ByVal paramsstructureid As Integer, ByVal value As String) As String
        Dim str As String = ""
        Dim ps As paramsstructureRow
        ps = _paramsstructureAdapter.GetItem(paramsstructureid)
        value = getValue(value, ps.componentname)
        str &= "<td>" & value & "</td>"
        str &= "<th>" & ps.name & "</th>"
        Return str
    End Function

End Class
