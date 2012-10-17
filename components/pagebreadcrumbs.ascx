<%@ Control Language="VB" AutoEventWireup="false" CodeFile="pagebreadcrumbs.ascx.vb" Inherits="components_pagebreadcrumbs" %>

<div class="brdcrmb">
<asp:Repeater ID="pagesrepeater" runat="server">
	<headertemplate><a href="index.aspx">ראשי</a></headertemplate>
    <ItemTemplate><span>></span><a href="<%#pageLogic.GetPageURL(Eval("url"),Eval("page_link"))%>"><%# Eval("name")%></a></ItemTemplate>
</asp:Repeater>
    <div class="clear"></div>
</div>