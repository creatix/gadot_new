<%@ Control Language="VB" AutoEventWireup="false" CodeFile="basketpanel_side.ascx.vb" Inherits="components_basketpanel_side" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>

<modulus:msgpanel id="msgpanel1" runat="server"></modulus:msgpanel>
<asp:Label ID="msglbl" runat="server" style="color:#999; font-size:16px;"></asp:Label>

<% if baskettable.DataSource.Count > 0 then %>
<table class="tablestyle_sidebasket" align="center" width="100%" border="0" cellpadding="0" cellspacing="0">

<asp:Repeater ID="baskettable" runat="server">
	<headertemplate>
    </headertemplate>
    <itemtemplate>
    		<tr class="itemrow">
            	<td width="60"><div><b><%#Eval("totalprice")%></b> <%=siteLogic.currency%></div></td>
                <td width="10"><div class="lightgraytext">=</div></td>
                <td width="10"><div><b><%#Eval("itemscount")%></b></div></td>
                <td width="10"><div class="lighttext">X</div></td>
                <td width="40"><div style="white-space:nowrap;"><span><%#String.Format("{0:#,###}", Eval("totalprice"))%></span> <%=siteLogic.currency%></div></td>
                <td><div><a href="<%#pageLogic.GetLink("product", Eval("productsid"), Eval("name"), "")%>"><b><%#Eval("displayname")%></b></a></div></td>
			</tr>
    </itemtemplate>
    <footertemplate>
    </footertemplate>
</asp:Repeater>
	
    <tr class="summaryrow">
   	  <td colspan="7" height="20">&nbsp;</td>
    </tr>
    <tr class="summaryrow">
        <td><b><asp:Label ID="totalPricelbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="6"><div class="summarytitle">מחיר לפני משלוח:</div></td>
    </tr>
    <% if shippingPricelbl.text <> "" %>
    <tr class="summaryrow">
        <td><b><asp:Label ID="shippingPricelbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="6"><div class="summarytitle">מחיר משלוח:</div></td>
    </tr>
    <% end if %>
  	<% if interestSumlbl.text <> "" %>
    <tr class="summaryrow">
        <td><b><asp:Label ID="interestSumlbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="6"><div class="summarytitle">ריבית:</div></td>
    </tr>
    <% end if %>
    <% If couponsDiscountlbl.Text <> "" Then%>
    <tr class="summaryrow">
        <td><b><asp:Label ID="couponsDiscountlbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="6"><div class="summarytitle">הנחת קופון:</div></td>
    </tr>
    <% end if %>
  <% if shippingPricelbl.text <> "" or interestSumlbl.Text <> "" or couponsDiscountlbl.Text <> "" %>
    <tr class="summaryrow">
        <td class="sitemaincolor"><b style="font-size:18px;"><asp:Label ID="sumlbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="6"><div class="summarytitle sitemaincolor"><b>סה"כ:</b></div></td>
    </tr>
    <% end if %>
    <tr class="summaryrow">
    	<td colspan="7" height="20">&nbsp;</td>
    </tr>
</table>

<% if showCheckoutBut then %>
<table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td height="20" colspan="2" align="left">&nbsp;</td>
  </tr>
	<tr>
    	<td align="left"><a href="checkout.aspx"><img src="img/checkoutbut.gif" title="המשך לקופה" border="0" /></a></td>
		<td align="right"><img src="img/arrowright.gif" width="7" height="11" border="0" align="absmiddle" /> <a href="javascript:window.history.back(-1);" class="continuelink">המשך בקניות באתר</a></td>
  </tr>
</table>
<% end if %>

<% end if %>
