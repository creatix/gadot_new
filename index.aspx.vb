
Partial Class index
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim pagesA As New pagesAdapter
        Dim pl As New pageLogic
        Dim pageRow As pagesRow = pagesA.GetItem(29)
        pl.setPageTitle(pageRow.metatitle, pageRow.metadescription, pageRow.metakeywords, Page)

    End Sub

End Class
