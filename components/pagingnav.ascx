<%@ Control Language="vb" %>
<script language="vb" runat="server">

	Public current_page As Integer
	Public pages As Integer
	Public items_per_page As Integer
	Public total_items As Integer
	
	function get_pages()
	
        Dim i, bottom_p, top_p, dif As Integer
        Dim pages_str As String = ""

        dif = 7

        If current_page - dif < 1 Then
            bottom_p = 1
            dif += dif - current_page + 1
        Else
            bottom_p = current_page - dif
        End If

        If current_page + dif > pages Then
            top_p = pages
            dif = (current_page + dif) - pages
            If dif > 0 Then
                If bottom_p - dif < 1 Then
                    bottom_p = 1
                Else
                    bottom_p = bottom_p - dif
                End If
            End If
        Else
            top_p = current_page + dif
        End If
		
		dim quary_str as string = request.servervariables("QUERY_STRING")
		dim quary_str_arr() as string = split(quary_str,"&")
		dim quary_str_arr1() as string = filter(quary_str_arr,"page=",false)
		quary_str = join(quary_str_arr1,"&")

        For i = bottom_p To top_p
            If i = current_page Then
                pages_str &= "&nbsp;<font color=#666666><b>" & i & "</b></font>&nbsp;"
            Else
                pages_str &= "&nbsp;<a href=" & Request.CurrentExecutionFilePath & "?" & quary_str & "&page=" & i & ">" & i &"</a>&nbsp; "
            End If
        Next

        If bottom_p <> 1 Then
            pages_str = "&nbsp;<a href=""" & Request.CurrentExecutionFilePath & "?" & quary_str & "&page=1"">...</a>" & pages_str
        End If

        If top_p <> pages Then
            pages_str &= "<a href=""" & Request.CurrentExecutionFilePath & "?" & quary_str & "&page=" & pages & """>...</a>"
        End If

        lblCurrentPage.Text = pages_str
        lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath & "?" & quary_str & "&page=" & current_page - 1
        lnkNext.NavigateUrl = Request.CurrentExecutionFilePath & "?" & quary_str & "&page=" & current_page + 1
        If pages = 1 Then
            lnkPrev.Visible = False
            lnkNext.Visible = False
        End If

        If current_page = 1 Then
            lnkPrev.Visible = False
        End If

        If current_page = pages Then
            lnkNext.Visible = False
        End If

        Dim bottom_range As Integer = (current_page - 1) * items_per_page + 1

        Dim top_range As Integer = current_page * items_per_page

        If top_range > total_items Then
            top_range = total_items
        End If

        total_pages.Text = "מראה תוצאות <b>" & bottom_range & "-" & top_range & "</b> מתוך <b>" & total_items & "</b>"
	
	end function

</script>
<%get_pages()%>
<TABLE cellSpacing="0" cellPadding="5" width="100%" bgColor="#f3f3f3" border="0" runat="server" class="pagenav">
	<TR>
        <TD align="left"><asp:label id="total_pages" runat="server"></asp:label></TD>
        <TD align="right">
			<asp:hyperlink id="lnkPrev" runat="server"><img src='img/paging_arrow_right.gif' width='7' height='9' border="0"> קודם</asp:hyperlink><asp:label id="lblCurrentPage" runat="server"></asp:label>
			<asp:hyperlink id="lnkNext" runat="server">הבא <img src='img/paging_arrow_left.gif' width='7' height='9' border="0"></asp:hyperlink>
		</TD>
	</TR>
</TABLE>
