<%@ Page Language="VB" AutoEventWireup="false" CodeFile="myaccount.aspx.vb" Inherits="myaccount" MasterPageFile="~/main.master" %>
<%@ Register TagPrefix="modulus" TagName="myaccountbar" Src="~/components/myaccountbar.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<link rel="stylesheet" href="css/store.css" type="text/css" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">חשבון שלי</h1></td>
  </tr>
  
  <tr>
    <td>
    
    <modulus:myaccountbar id="myaccountbar1" runat="server" />
    
    <br /><br />

<% if orderstable.datasource.count > 0 then %>

<table class="tablestyle" align="center" width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom:0px;">
	<tr>
    	<th>תאריך ההזמנה</th>
    	<th>סטטוס</th>
		<th>מחיר סופי</th>
        <th>תוכן ההזמנה</th>
        <th>מס' הזמנה</th>
    </tr>

<asp:Repeater ID="orderstable" runat="server">
	<headertemplate>
    </headertemplate>
    <itemtemplate>
    		<tr class="itemrow">
            	<td><%#Format(Eval("insertdate"), "hh:mm dd/MM/yyyy")%></td>
            	<td><%#getStatusName(Eval("statusid"))%></td>
            	<td>₪<%#String.Format("{0:#,###}", Eval("totalprice"))%></td>
            	<td><%#getOrderContent(Eval("ordersid"))%></td>
            	<td><strong><%#Eval("ordersid")%></strong></td>
			</tr>
    </itemtemplate>
    <footertemplate>
    </footertemplate>
</asp:Repeater>
	
</table>

<% else %>
	<b>לא נמצאו הזמנות</b>
<% end if %>

<br /><br /></td>
  </tr>
  </table>
  
<%=siteLogic.Config("helptext")%>
<br>

</asp:Content>