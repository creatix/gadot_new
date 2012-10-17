
Partial Class components_breadcrumbs
    Inherits System.Web.UI.UserControl

    Public catid As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If catid = 0 Then Exit Sub

        Dim _catLogic As New catLogic
        Dim _catList As pList(Of catsRow) = _catLogic.getCatTree(catid)
        _catList.Reverse()

        catsrepeater.DataSource = _catList
        catsrepeater.DataBind()

    End Sub

    Public Function getLast(ByVal id As Integer) As String
        If id = catsrepeater.DataSource(catsrepeater.DataSource.Count - 1).catsid Then
            Return "style=""background:none;"""
        End If
        Return ""
    End Function

End Class
