<%@ Control Language="VB" AutoEventWireup="false" CodeFile="basketpanel.ascx.vb" Inherits="components_basketpanel" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %> 

<modulus:msgpanel id="msgpanel1" runat="server"></modulus:msgpanel>

<% if baskettable.DataSource.Count > 0 then %>
<table class="tablestyle" align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<th>סה"כ</th>
        <th>כמות</th>
        <th>מחיר</th>
        <th colspan="2">שם המוצר</th>
    </tr>

<asp:Repeater ID="baskettable" runat="server">
	<headertemplate>
    </headertemplate>
    <itemtemplate>
    		<tr class="itemrow">
            	<td width="80"><div><b><%#String.Format("{0:#,###}", Eval("totalprice"))%> <%=siteLogic.currency%></div></td>
                <td><div>
                <select style="margin-bottom:8px;" onchange="changeQuantity('<%#Eval("basketid")%>',this.value);">
                	<option value="<%#Eval("itemscount")%>"><%#Eval("itemscount")%></option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                </select>
                <br />
                <a href="?delid=<%#Eval("basketid")%>"><img src="img/trashico.gif" width="9" height="12" align="absmiddle" /> הסר מהסל</a></div></td>
                <td><div><b><%#String.Format("{0:#,###}", Eval("price"))%></b> <%=siteLogic.currency%></div></td>
                <td><div><a href="<%#pageLogic.GetLink("product", Eval("productsid"), Eval("name"), "")%>" style="color:#666;"><b><%#Eval("displayname")%></b><br />מק"ט: <%#Eval("catalogno")%></a></div></td>
                <td width="160"><a href="<%#pageLogic.GetLink("product", Eval("productsid"), Eval("name"), "")%>"><img src="components/img.aspx?img=images\<%#Eval("pic")%>&width=150&height=100" width="150" height="100" style="padding:0px;border:0px;" /></a></td>
			</tr>
    </itemtemplate>
    <footertemplate>
    </footertemplate>
</asp:Repeater>
	
    <tr class="summaryrow">
   	  <td colspan="5" height="20">&nbsp;</td>
    </tr>
    <tr class="summaryrow">
        <td><b><asp:Label ID="totalPricelbl" runat="server"></asp:Label></b> <%=siteLogic.currency%></td>
        <td align="left" colspan="2"><div class="summarytitle">מחיר לפני משלוח:</div></td>
        <td colspan="3" align="right" style=" padding-right:20px;">
        	<div class="coupontitle">טען קוד קופון</div>
            <div class="coupontext">הכנס כאן את קוד הקופון במידה והוא קיים ברשותך</div>
	    	<div><input type="text" name="couponcode" id="couponcode" class="coupontextbox" /> <input type="button" value="החל הנחה" class="couponbut" onclick="document.location='?couponcode='+document.getElementById('couponcode').value;" /></div>
        </td>
    </tr>
    <% if shippingPricelbl.text <> "" %>
    <tr class="summaryrow">
        <td><b><asp:Label ID="shippingPricelbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></td>
        <td align="left" colspan="4"><div class="summarytitle">מחיר משלוח:</div></td>
    </tr>
    <% end if %>
  	<% if interestSumlbl.text <> "" %>
    <tr class="summaryrow">
        <td><b><asp:Label ID="interestSumlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></td>
        <td align="left" colspan="4"><div class="summarytitle">ריבית:</div></td>
    </tr>
    <% end if %>
    <% If couponsDiscountlbl.Text <> "" Then%>
    <tr class="summaryrow">
        <td><b><asp:Label ID="couponsDiscountlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></td>
        <td align="left" colspan="4"><div class="summarytitle">הנחת קופון:</div></td>
    </tr>
    <% end if %>
  <% if shippingPricelbl.text <> "" or interestSumlbl.Text <> "" or couponsDiscountlbl.Text <> "" %>
    <tr class="summaryrow">
        <td><b><asp:Label ID="sumlbl" runat="server"></asp:Label> <%=siteLogic.currency%></b></td>
        <td align="left" colspan="4"><div class="summarytitle">סה"כ:</div></td>
    </tr>
    <% end if %>
    <tr class="summaryrow">
    	<td colspan="5" height="20">&nbsp;</td>
    </tr>
</table>

<% if showCheckoutBut then %>
<table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td height="20" colspan="2" align="left">&nbsp;</td>
  </tr>
	<tr>
    	<td align="left"><a href="checkout.aspx" class="butstyle" style="float:left;">המשך לקופה <img src="img/arrowbut.gif" width="8" height="11" /></a></td>
		<td align="right"><img src="img/arrowright.gif" width="7" height="11" border="0" align="absmiddle" /> <a href="javascript:window.history.back(-1);" class="continuelink">המשך בקניות באתר</a></td>
  </tr>
</table>
<% end if %>

<% if not grid1.datasource is nothing then
if grid1.datasource.count > 0 then %>
<br /><br />
<h1 class="pagetitle1">מוצרים של הרגע האחרון</h1><br /><br />
<modulus:grid id="grid1" runat="server" view="product1" colNum="5" table_width="" />
<% end if
end if %>

<% end if %>

<script>
	function changeQuantity(bid, quantity) {
		window.location = 'basket.aspx?bid='+bid+'&quantity='+quantity;	
	}
</script>