Imports System.IO

Partial Class components_grid
    Inherits System.Web.UI.UserControl

    Public dataSource As Object
    Public pageSize As Integer = 10
    Public currentPage As Integer = 1
    Public colNum As Integer = 4
    Public view As String = "product"
    Public table_width As String = "width='100%'"
    Public hrImg As String = ""
    Public vrImg As String = ""
    Public hrColor As String = "#EAEAEA"
    Public vrColor As String = "#EAEAEA"
    Public showHr As Boolean = False
    Public showVr As Boolean = False
    Public direction As String = "rtl"
    Public showPaging As Boolean = False
    Public showPagingTop As Boolean = False
    Public emptyMessage As String = "לא נמצאו פריטים"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        generateGrid()
    End Sub

    Sub generateGrid()

        If dataSource Is Nothing Then
            Exit Sub
        End If

        If dataSource.Count = 0 Then
            gridltl.Text = "<div class=""backgroundmsg"">" & emptyMessage & "</div>"
            Exit Sub
        End If

        Dim str As String = ""

        If showPagingTop Then
            str &= getPaging()
        End If

        str &= "<table " & table_width & " style='direction:" & direction & "' cellpadding='0' cellspacing='1' border='0'><tr>"
        Dim i As Integer
        Dim p_count As Integer = 0

        For i = 0 To dataSource.Count - 1

            str &= "<td valign='top'>"
            str &= getProductTumb(dataSource(i))
            str &= "</td>"
            p_count += 1

            If i <> dataSource.Count - 1 Then
                If ((p_count Mod colNum) = 0) Then
                    str &= "</tr>"
                    If showHr Then
                        Dim temp As Integer = colNum
                        If showVr Then temp += colNum - 1
                        Dim img_temp As String = ""
                        If hrImg <> "" Then
                            img_temp = "background='img/" & hrImg & "'"
                        End If
                        str &= "<tr>"
                        str &= "<td bgcolor='" & hrColor & "' colspan='" & temp & "' " & img_temp & "><img src='img/pixel.gif' width='1' height='1'></td>"
                        str &= "</tr>"
                    End If
                    str &= "<tr>"
                Else
                    If showVr Then
                        Dim img_temp As String = ""
                        If vrImg <> "" Then
                            img_temp = "background='img/" & vrImg & "'"
                        End If
                        str &= "<td bgcolor='" & vrColor & "' " & img_temp & "><img src='img/pixel.gif' width='1' height='1'></td>"
                    End If
                End If
            End If

        Next
        str &= "</tr></table>"

        If showPaging Then
            str &= getPaging()
        End If

        gridltl.Text = str

    End Sub

    Function getProductTumb(ByVal itemObj As Object) As String
        Dim sw As New StringWriter
        Dim tw As New HtmlTextWriter(sw)
        Dim uc As Object
        uc = LoadControl("~/components/thumb_" & view & ".ascx")
        uc.dataSource = itemObj
        uc.RenderControl(tw)
        Return sw.ToString()
    End Function

    Function getPaging() As String
        Dim sw As New StringWriter
        Dim tw As New HtmlTextWriter(sw)
        Dim uc As Object
        uc = LoadControl("~/components/pagingnav.ascx")
        uc.current_page = dataSource.currentPage
        uc.pages = dataSource.totalPages
        uc.items_per_page = dataSource.itemsPerPage
        uc.total_items = dataSource.totalItems
        uc.RenderControl(tw)
        Return sw.ToString()
    End Function

End Class
