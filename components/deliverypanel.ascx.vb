
Partial Class components_deliverypanel
    Inherits System.Web.UI.UserControl

    Public userbasket As pList(Of basketViewRow)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadDeliveries()
    End Sub

    Sub loadDeliveries()
        Dim quary As String = "isnull(hide,0)<>1"
        If Not userbasket Is Nothing Then
            Dim str As String = ""
            Dim slist As String = ""
            For Each item As basketViewRow In userbasket
                If item.shipping <> "" Then
                    slist &= item.shipping & ","
                End If
            Next
            If slist.EndsWith(",") Then
                slist = slist.Remove(slist.Length - 1, 1)
            End If
            If slist.StartsWith(",") Then
                slist = slist.Remove(0, 1)
            End If
            If slist <> "" Then
                quary = "deliveryid IN(" & slist & ")"
            End If
        End If
        Dim _deliveryAdapter As New deliveryAdapter
        deliveryrepeater.DataSource = _deliveryAdapter.GetList(quary, "isnull(sort,1000)")
        deliveryrepeater.DataBind()
    End Sub

    Public Function showChecked(ByVal deliveryid As Integer) As String
        Return ""
        If IsNumeric(Request("deliveryid")) Then
            If deliveryid = CInt(Request("deliveryid")) Then
                Return "checked"
            End If
        Else
            If deliveryrepeater.DataSource(deliveryrepeater.DataSource.count - 1).deliveryid = deliveryid Then
                Return "checked"
            End If
        End If
        Return ""
    End Function

    Dim linecount As Integer = 0
    Public Function dropline() As String
        linecount += 1
        If linecount Mod 3 = 0 Then
            Return "</tr><tr>"
        End If
        Return ""
    End Function

End Class
