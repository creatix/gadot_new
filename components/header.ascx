<%@ Control Language="VB" AutoEventWireup="false" CodeFile="header.ascx.vb" Inherits="components_header" %>
<%@ Register TagPrefix="modulus" TagName="pagesheader" Src="~/components/pagesheader.ascx" %>


    
    
    <div class="headerwrapper">


 
  
  
  
  <header class="clearfix">
    <h1>09-8350101</h1>
    <!-- navigation tag  starts from here -->
    <nav>
      <ul>
        <li><a class="Lorem" href="myaccount.aspx" title="">החשבון שלי</a></li>
        <li><span>|</span></li>
        <li><a class="Lorem" href="basket.aspx" title="">סל קניות (<%=basketitems%>) פריטים</a></li>
        <li><span>|</span></li>
        <modulus:pagesheader id="pagesheader1" runat="server" />
      </ul>
    </nav>
  </header>
</div>