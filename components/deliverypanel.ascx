<%@ Control Language="VB" AutoEventWireup="false" CodeFile="deliverypanel.ascx.vb" Inherits="components_deliverypanel" %>

<div id="deliverydiv">
<table border="0" cellpadding="0" cellspacing="0" style="direction:rtl;">
<tr>

<asp:Repeater ID="deliveryrepeater" runat="server">
    <ItemTemplate>
        <td>
            <label for="deliveryid<%#Eval("deliveryid")%>" class="deliveryoption">
                <div class="r">
                  <input type="radio" name="deliveryid" id="deliveryid<%#Eval("deliveryid")%>" value="<%#Eval("deliveryid")%>" onclick="shippingSelected('<%#Eval("deliveryid")%>');" <%#showChecked(Eval("deliveryid"))%> />
                </div>
                <div class="t"><span><%#Eval("name")%></span><br />
                <%#Eval("deliverytime")%><br />
                    <b><%#Eval("price")%> ₪</b>
                </div>
            </label>
        </td>
        <%=dropline()%>
    </ItemTemplate>
</asp:Repeater>

</tr>
</table>
</div>