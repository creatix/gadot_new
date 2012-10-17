<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ordersummary.ascx.vb" Inherits="components_ordersummary" %>

<table class="tablestyle" align="center" width="100%" border="0" cellpadding="6" cellspacing="0" style="direction:rtl;">
	<tr>
    	<th></th>
        <th style="text-align:right;">שם המוצר</th>
        <th style="text-align:right;">פרטים</th>
        <th style="text-align:right;">כמות</th>
        <th style="text-align:right;">מחיר</th>
	</tr>
<asp:Repeater ID="productsrepeater" runat="server">
    <ItemTemplate>
    	<tr style="background-color:#eaeaea;">
        		<td></td>
                <td><a href="<%#siteLogic.Config("siteurl") & pageLogic.GetLink("product", Eval("productid"), Eval("name"), "")%>"><%#Eval("name")%></a></td>
                <td><%#Eval("addname")%></td>
                <td><%#Eval("itemscount")%></td>
                <td><%#Eval("price")%> <%=siteLogic.currency%></td>
			</tr>
    </ItemTemplate>
</asp:Repeater>

    <tr>
        <th align="left" style="text-align:left;" class="summarytext" colspan="4">מחיר לפני משלוח:</th>
        <th class="summarytext" style="text-align:right;"><b><asp:Label ID="totalPricelbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></th>
    </tr>
    <% if shippingPricelbl.text <> "" %>
    <tr>
        <th align="left" style="text-align:left;" class="summarytext" colspan="4">מחיר משלוח:</th>
        <th class="summarytext" style="text-align:right;"><b><asp:Label ID="shippingPricelbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></th>
    </tr>
    <% end if %>
    <% if interestSumlbl.text <> "" and interestSumlbl.text <> "0" %>
    <tr>
    	<th align="left" style="text-align:left;" class="summarytext" colspan="4">ריבית:</th>
        <th class="summarytext" style="text-align:right;"><b><asp:Label ID="interestSumlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></th>
    </tr>
    <% end if %>
    <% If couponsDiscountlbl.Text <> "" and couponsDiscountlbl.text <> "0" Then%>
    <tr>
    	<th align="left" style="text-align:left;" class="summarytext" colspan="4">הנחת קופון:</th>
        <th class="summarytext" style="text-align:right;"><b><asp:Label ID="couponsDiscountlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></th>
    </tr>
    <% end if %>
    <% if shippingPricelbl.text <> "" %>
    <tr>
        <th align="left" style="text-align:left;" class="summarytext" colspan="4">סה"כ:</th>
        <th class="summarytext" style="text-align:right;"><b><asp:Label ID="sumlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></th>
    </tr>
    <% end if %>
</table>

<div class="summarydetailstxt">
<asp:Label ID="userdetailslbl" runat="server"></asp:Label>
</div>