Imports cs3.tableLogic

Partial Class components_bannerslideshow
    Inherits System.Web.UI.UserControl

    Public bannerName As String = ""
    Public width As Integer = 200
    Public height As Integer = 50
    Public bannersList As pList(Of bannersRow)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadBanners()
    End Sub

    Sub loadBanners()
        If bannerName = "" Then Exit Sub
        Dim _bannersAdapter As New bannersAdapter
        bannersList = _bannersAdapter.GetList("name='" & bannerName & "'", "NEWID()")
        buildJavascript()
        If bannersList.Count > 0 Then
            If Not bannersList(0).link Is Nothing Then
                If bannersList(0).link.ToString() = "" Then
                    bannersList(0).link = "#"
                End If
            End If
        End If
    End Sub

    Sub buildJavascript()
        Dim i As Integer
        Dim str As String = "<script type='text/javascript'>"
        str &= " var arr = new Array(); "
        For i = 0 To bannersList.Count - 1
            str &= " arr[" & i & "] = 'images/" & bannersList(i).pic & "'; "
        Next
        str &= " var arrlinks = new Array(); "
        For i = 0 To bannersList.Count - 1
            str &= " arrlinks[" & i & "] = '" & bannersList(i).link & "'; "
        Next
        str &= "</script>"
        ltrPictures.Text = str
    End Sub

End Class
