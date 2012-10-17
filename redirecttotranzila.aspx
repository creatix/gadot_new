<%@ Page Language="VB" AutoEventWireup="false" CodeFile="redirecttotranzila.aspx.vb" Inherits="redirecttotranzila" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
<form ACTION="https://direct.tranzila.com/<%=siteLogic.Config("payment_tranzilausername")%>/" method="POST" id="form1" name="form1" >
<input type="hidden" name="expyear" value="">
<input type="hidden" name="pdesc" size=40 value="">
<input type="hidden" name="currency" value="1">
<input type="hidden" name="sum" value="<%=request("amount")%>">
<input type="hidden" name="oldprice" value="">
<input type="hidden" name="TranzilaToken" value="<%=request("oid")%>">
<h2>Optional fields</h2>
<b>Customer full name</b> <br>
<input type="text" name="contact" value=""><br><br>
<b>Company</b> <br>
<input type="text" name="company" value=""><br><br>
<b>Email</b> <br>
<input type="text" name="email" value=""><br><br>
<b>Phone</b> <br>
<input type="text" name="phone" value=""><br><br>
<h2>Payments</h2>
<b>cred_type</b> <br>
<input type="text" name="cred_type" value=""><br><br>
<b>fpay</b> <br>
<input type="text" name="fpay" value=""><br><br>
<b>spay</b> <br>
<input type="text" name="spay" value=""><br><br>
<b>npay</b> <br>
<input type="text" name="npay" value=""><br><br>
<p><input type="submit" value=" Send ">
</div>
</form>

<script>
	document.form1.submit();
</script>

</body>
</html>
