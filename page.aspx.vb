Imports cs3

Partial Class page
    Inherits BasePage

    Public table As tableLogic.tableAdapter
    Public PageName As String = ""
    Public father_id As String = ""
    Public father_name As String = ""
    Public tr As cs3.tableLogic.tableRow = Nothing
    Public pageRow As pagesRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim page_id As String = Request("id")

        If Not IsNumeric(page_id) Then
            Exit Sub
        End If

        Dim pagesA As New pagesAdapter
        pageRow = pagesA.GetItem(CInt(page_id))

        Dim pl As New pageLogic
        pl.setPageTitle(pageRow.metatitle, pageRow.metadescription, pageRow.metakeywords, Page)

        pagebreadcrumbs1.pageid = page_id

    End Sub

    Public Function getSiteLeftImage() As String
        If Not pageRow Is Nothing Then
            If pageRow.leftbanner = "" Then
                Return "img/leftsidepic.jpg"
            Else
                Return "components/img.aspx?img=images\" & pageRow.leftbanner & "&width=651&cropheight=1000"
            End If
        End If
        Return "img/leftsidepic.jpg"
    End Function

End Class

