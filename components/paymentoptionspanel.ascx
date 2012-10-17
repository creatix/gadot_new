<%@ Control Language="VB" AutoEventWireup="false" CodeFile="paymentoptionspanel.ascx.vb" Inherits="components_paymentoptionspanel" %>

<table border="0" cellpadding="0" cellspacing="0">
	<tr>
         
		<% if siteLogic.Config("chargebyphone") = "1" then %>
			<td><label for="chargebyphone" class="deliveryoption">
				<div class="r">
              		<input type="radio" name="paymentmethod" id="chargebyphone" value="chargebyphone" onclick="paymentOptionSelected('chargebyphone');" <%=showChecked("chargebyphone")%> />
            	</div>
            	<div class="t"><span>חיוב טלפוני</span></div>
            	</label>
			</td>
		<% end if %>
        <% if siteLogic.Config("chargewithpaypal") = "1" And siteLogic.Config("payment_paypalaccount") <> "" then %>
        	<td><label for="chargewithpaypal" class="deliveryoption">
            	<div class="r">
              		<input type="radio" name="paymentmethod" id="chargewithpaypal" value="chargewithpaypal" onclick="paymentOptionSelected('chargewithpaypals');" <%=showChecked("chargewithpaypal")%>  />
            	</div>
            	<div class="t"><span><img src="img/paypal.gif" width="79" height="19" /></span></div>
				</label>
        	</td>
        <% end if %>
        <% if siteLogic.Config("chargewithcreditcard") = "1" then %>
			<td><label for="chargewithcreditcard" class="deliveryoption">
            	<div class="r">
              		<input type="radio" name="paymentmethod" id="chargewithcreditcard" value="chargewithcreditcard" onclick="paymentOptionSelected('chargewithcreditcard');" <%=showChecked("chargewithcreditcard")%>  />
            	</div>
            	<div class="t"><span>חיוב כרטיס אשראי</span></div>
				</label>
        	</td>
		<% end if %>
        </tr>
      </table>