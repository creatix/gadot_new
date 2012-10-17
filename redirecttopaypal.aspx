<%@ Page Language="VB" AutoEventWireup="false" CodeFile="redirecttopaypal.aspx.vb" Inherits="redirecttopaypal" %>

<div align="center"><strong>אנא המתן.</strong>
</div>

<form action="https://www.paypal.com/us/cgi-bin/webscr" method="post" id="form1" name="form1">
  <input type="hidden" name="cmd" value="_xclick">
  <input type="hidden" name="business" value="<%=siteLogic.Config("payment_paypalaccount")%>">
  <input type="hidden" name="item_name" value="Order for my user">
  <input type="hidden" name="item_number" value='<%=request("oid")%>'>
  <input type="hidden" name="currency_code" value="USD">
  <input type="hidden" name="amount" value='<%=request("amount")%>'>
  <input type="hidden" name="no_shipping" value='1'>
  <input type="hidden" name="no_note" value='1'>
  <input type="hidden" name="return" value='<%=siteLogic.Config("siteurlssl")%>checkout.aspx?success=true&spo=<%=request("oid")%>'>
  <input type="hidden" name="cancel_return" value='<%=siteLogic.Config("siteurlssl")%>/index.aspx'>
  <% if siteLogic.Config("payment_paypallogo") <> "" then %>
  <input type="hidden" name="image_URL" value='<%=siteLogic.Config("siteurlssl")%>images/<%=siteLogic.Config("payment_paypallogo")%>'>
  <input type="image" src="<%=siteLogic.Config("siteurlssl")%>images/<%=siteLogic.Config("payment_paypallogo")%>" name="submit" alt="Make payments with PayPal!">
  <% end if %>
  <input type="hidden" name="notify_url" value='https://www.online-devices.com/checkout.aspx?success=true&spo=<%=request("oid")%>'>
  
  <input type="hidden" name="supplier" value="<%=siteLogic.Config("sitename")%>">
  <input type="hidden" name="currency" value="1">
  <input type="hidden" name="sum" value="<%=request("amount")%>">
  <input type="text" name="pp_DESC" value="">
  <input type="hidden" name="rm" value="2">

</form>
<script>
	document.form1.submit();
</script>