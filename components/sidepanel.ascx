<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sidepanel.ascx.vb" Inherits="components_sidepanel" %>

<ul>
<asp:Repeater ID="rptPages" runat="server">
    <ItemTemplate>
    	<li>
        	<a href="<%#pageLogic.GetPageURL(Eval("url"),Eval("page_link"))%>"><%#Eval("name")%></a>
        </li>
    </ItemTemplate>
    <separatortemplate></separatortemplate>
</asp:Repeater>
</ul>
<div class="clearfix"></div>
<div style="border-bottom:#eaeaea 1px solid;"></div>

