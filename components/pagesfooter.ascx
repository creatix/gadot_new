<%@ Control Language="VB" AutoEventWireup="false" CodeFile="pagesfooter.ascx.vb" Inherits="components_pagesfooter" %>

<asp:Repeater ID="rptPages" runat="server">
    <ItemTemplate>
        	<li><a href="<%#pageLogic.GetPageURL(Eval("url"), Eval("page_link"))%>"><%#pageLogic.getPageName(Eval("name"),Eval("menuname"))%></a></li>
    </ItemTemplate>
    <separatortemplate><li><span>|</span></li></separatortemplate>
</asp:Repeater>

