<%@ Control Language="VB" AutoEventWireup="false" CodeFile="pagesheader.ascx.vb" Inherits="components_pagesheader" %>

<asp:Repeater ID="rptPages" runat="server">
    <ItemTemplate>
    	<li>
        	<a href="<%#pageLogic.GetPageURL(Eval("url"),Eval("page_link"))%>"><%#Eval("name")%></a>
        </li>
    </ItemTemplate>
    <separatortemplate>
    </separatortemplate>
</asp:Repeater>



