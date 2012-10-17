<%@ Control Language="VB" AutoEventWireup="false" CodeFile="catbreadcrumbs.ascx.vb" Inherits="components_breadcrumbs" %>

<div class="brdcrmb">
        <ul>
<asp:Repeater ID="catsrepeater" runat="server">
	<headertemplate>
    	<li style="padding-left:0px;"><a href="index.aspx">ראשי</a></li>
    </headertemplate>
    <ItemTemplate>
    	<li><img src="img/arrowleft.gif" width="7" height="9" /></li>
    	<li <%#getLast(Eval("catsid"))%>><a href="<%# pageLogic.GetLink("cat", Eval("catsid"), Eval("name"), "")%>"><%# Eval("name")%></a></li>
    </ItemTemplate>
</asp:Repeater>
	</ul>
    <div class="clear"></div>
</div>