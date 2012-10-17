
Partial Class components_pagebreadcrumbs
    Inherits System.Web.UI.UserControl

    Public pageid As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If pageid = 0 Then Exit Sub

        Dim _pageLogic As New pageLogic
        Dim _pageList As pList(Of pagesRow) = _pageLogic.getPageTree(pageid)
        _pageList.Reverse()

        pagesrepeater.DataSource = _pageList
        pagesrepeater.DataBind()

    End Sub

    Public Function getLast(ByVal id As Integer) As String
        If id = pagesrepeater.DataSource(pagesrepeater.DataSource.Count - 1).pagesid Then
            Return "style=""background:none;"""
        End If
        Return ""
    End Function

End Class
