<%@ Control Language="VB" AutoEventWireup="false" CodeFile="myaccountbar.ascx.vb" Inherits="components_myaccountbar" %>
<div id="myaccountbar">
    	<a href="myaccount.aspx" <%=getSelected("myaccount.aspx")%>>מעקב הזמנות</a>
        <a href="changedetails.aspx" <%=getSelected("changedetails.aspx")%>>שינוי פרטים</a>
        <a href="changepassword.aspx" <%=getSelected("changepassword.aspx")%>>שינוי סיסמא</a>
        <a href="logoff.aspx" class="logoff">התנתק</a>
    </div>