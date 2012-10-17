<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkout.aspx.vb" Inherits="checkout" MasterPageFile="~/main.master" title="קופה" %>
<%@ Register TagPrefix="modulus" TagName="msgpanel" Src="~/components/msgpanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="basketpanel" Src="~/components/basketpanel_side.ascx" %>
<%@ Register TagPrefix="modulus" TagName="deliverypanel" Src="~/components/deliverypanel.ascx" %>
<%@ Register TagPrefix="modulus" TagName="ordersummary" Src="~/components/ordersummary.ascx" %>
<%@ Register TagPrefix="modulus" TagName="paymentoptionspanel" Src="~/components/paymentoptionspanel.ascx" %>

<asp:Content ID="header" ContentPlaceHolderID="header" runat="server">

    <script src="js/mootools-1.2.4-core-yc.js"></script>
	<script src="js/mootools-1.2.3.1-more.js"></script>
    <script src="js/ajax.js"></script>
    <script src="js/checkout.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

<form id="form1" runat="server" class="formcontainer" onsubmit="return formSubmited()">

<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><h1 class="pagetitle">קופה</h1></td>
  </tr>
  </table>
  <br />
  <modulus:msgpanel id="msgpanel1" runat="server" />
  
  <asp:Panel ID="checkoutpagepanel" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
    <div class="sidebaskettile">
    	<h2 class="subtitle1">סל הקניות שלך</h2>
        <div><a href="basket.aspx" class="linkbut">עידכון סל קניות</a></div>
    </div>
    <div id="basketpaneldiv">
    	<modulus:basketpanel id="basketpanel1" runat="server"></modulus:basketpanel>
	</div>
    <br />
    <br />
    <%=siteLogic.Config("helptext")%>
    </td>
    <td width="30" valign="top"><img src="img/pixel.gif" width="30" height="1" /></td>
    <td width="386" valign="top">
    
    	<asp:Panel ID="checkoutpanel" runat="server">
            <div class="checkoutpaneltitle"><span class="num">1</span><span class="text">פרטי הלקוח</span><span class="link"><asp:Literal ID="connectedUser" runat="server"></asp:Literal></span></div>
            
            <asp:Panel ID="loginpanel" runat="server">
                <div class="checkoutpanel">
                
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="50%" valign="top">
                                <div class="loginpanel">
                                    <h2 class="subtitle1">התחברות לאתר</h2>
                                    <br />
                                    <label>דואר אלקטרוני</label>
                                    <input type="text" name="loginemailtxt" id="loginemailtxt" runat="server" class="textltr" tabindex="4" />
                                    <label>סיסמא &nbsp;&nbsp;&nbsp; <a href="forgotpassword.aspx">שכחת את הסיסמא?</a></label>
                                    <input type="password" name="loginpasswordtxt" id="loginpasswordtxt" runat="server" class="textltr" tabindex="4" />
                                    <br /><br />
                                    <input type="submit" id="loginbut" runat="server" value="התחברות" class="butstyle loginpanelbut" />
                                </div>
                            </td>
                            <td class="panelsep"></td>
                            <td width="50%" valign="top">
                                <div class="loginpanel">
                                    <h2 class="subtitle1">הרשמה ללקוחות חדשים</h2>
                                    <br /><br />
                                    <div>בכדי להמשיך בתהליך הקניה עליכם להרשם. במידה ואינכם רשומים, לחצו על כפתור “הרשמה” למטה או לחצו על הכפתור המשך כאורח</div>
                                    <br /><br /><br /><br />
                                    <a href="register.aspx" class="butstyle loginpanelbut" style="color:#FFF;">הרשמה</a>
                                    
                                </div>
                            </td>
                        </tr>
                    </table>
        
                    <div class="clear"></div>
                    
                </div>
            </asp:Panel>
            <br />
            <div class="checkoutpaneltitle"><span class="num">2</span><span class="text">פרטי משלוח</span><span class="link" id="shippingPanelLink"></span></div>
            
            <asp:Panel ID="shippingpanel" runat="server">
                <div class="checkoutpanel" id="shippingpanel">
                    <div class="checkoutsubpanel">
                    
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="50%" valign="top">
                                    <label>שם משפחה</label>
                                    <input type="text" name="addresslastnametxt" id="addresslastnametxt" runat="server" tabindex="8" />
                                </td>
                                <td width="50%" valign="top">
                                    <label>שם פרטי</label>
                                    <input type="text" name="addressfirstnametxt" id="addressfirstnametxt" runat="server" tabindex="7" />
                                </td>
                            </tr>
                            <tr>
                              <td valign="top">
                                    <div class="smalltextbox">
                                        <label>מס' בית</label>
                                        <input type="text" name="addresshousenumtxt" id="addresshousenumtxt" runat="server" tabindex="10" />
                                    </div>
                                    <div class="smalltextbox">
                                        <label>מס' דירה</label>
                                        <input type="text" name="addressapptnumtxt" id="addressapptnumtxt" runat="server" tabindex="11" />
                                    </div>
                              </td>
                              <td valign="top">
                                <label>רחוב</label><input type="text" name="addressstreettxt" id="addressstreettxt" runat="server" tabindex="9" />
                              </td>
                          </tr>
                            <tr>
                              <td valign="top">
                                <label>טלפון</label>
                                <input type="text" name="addressphonetxt" id="addressphonetxt" runat="server" tabindex="14" />
                              </td>
                              <td valign="top">
                                <div class="smalltextbox">
                                    <label>עיר</label>
                                    <input type="text" name="addresscitytxt" id="addresscitytxt" runat="server" tabindex="12" />
                                </div>
                                <div class="smalltextbox">
                                    <label>מיקוד</label>
                                    <input type="text" name="addressziptxt" id="addressziptxt" runat="server" tabindex="13" />
                                </div>
                            </td>
                          </tr>
                            <tr>
                              <td colspan="2" valign="top">
                                <label>הערות נוספות</label>
                                <textarea name="addresscommentstxt" id="addresscommentstxt" cols="45" rows="2" style="width:452px;" runat="server" tabindex="15"></textarea>
                              </td>
                            </tr>
                        </table>
                        
                        <div class="clear"></div>
                  </div>
                    <div class="panelsepline"></div>
                    <div class="checkoutsubpanel">
                        <h2 class="subtitle1">אופן המשלוח</h2>
                        <br />
                        <div id="deliveryalert"></div>
                      <modulus:deliverypanel id="deliverypanel1" runat="server" />
                        <br /><br /><input type="button" id="continuebut1" runat="server" value="המשך" class="butstyle" onclick="shippingSubmit();" />
                        
                        <div class="clear"></div>
                    </div>
                </div>
            </asp:Panel>
            
            <br />
            <div class="checkoutpaneltitle"><span class="num">3</span><span class="text">פרטי תשלום</span></div>
            
            <asp:Panel ID="paymentpanel" runat="server">
                <div class="checkoutpanel" id="paymentpanel" style="display:none;">
                    <div class="checkoutsubpanel">
                        <h2 class="subtitle1">אופן התשלום</h2>
                                    <br />
                                    <modulus:paymentoptionspanel id="paymentoptionspanel1" runat="server" />
                                    <br />
                        <div id="cardpanel" <%=showCardsPanel()%>>
          
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="50%" valign="top">
                                        <label>מס' כרטיס אשראי </label>
                                        <input type="text" name="numbertxt" id="numbertxt" runat="server" tabindex="17" autocomplete="off" />
                                    </td>
                                    <td width="50%" valign="top">
                                        <label>שם בעל כרטיס האשראי</label>
                                        <input type="text" name="cardholdernametxt" id="cardholdernametxt" runat="server" tabindex="16" /></td>
                                </tr>
                                
                                <tr>
                                  <td valign="top">
                                    <label>תאריך תפוגה</label>
                                    <div class="smalltextbox">
                                        <select id="expirationmonthselect" runat="server" name="expirationmonthselect" tabindex="19" style="width:80px;">
                                          <option value="">חודש</option>
                                          <option value="01">1</option>
                                          <option value="02">2</option>
                                          <option value="03">3</option>
                                          <option value="04">4</option>
                                          <option value="05">5</option>
                                          <option value="06">6</option>
                                          <option value="07">7</option>
                                          <option value="08">8</option>
                                          <option value="09">9</option>
                                          <option value="10">10</option>
                                          <option value="11">11</option>
                                          <option value="12">12</option>
                                        </select>
                                    </div>
                                    <div class="smalltextbox">
                                    	<select id="expirationyearselect" runat="server" name="expirationyearselect" tabindex="20" style="width:80px;"></select>
                                    </div>
                                </td>
                                  <td valign="top">
                                    <label>סוג כרטיס האשראי</label>
                                    <select id="cardtypeselect" name="cardtypeselect" runat="server" tabindex="18">
                                        <option Value=""></option>
                                        <option Value="Visa">Visa</option>
                                        <option Value="LeumiCard">LeumiCard</option>
                                        <option Value="IsraCard">IsraCard</option>
                                        <option Value="MasterCard">MasterCard</option>
                                        <option Value="American Express">American Express</option>
                                    </select>
                                </td>
                              </tr>
                                <tr>
                                  <td valign="top">
                                  <div class="smalltextbox">
                                        <label>קוד אימות <a onclick="open_popup('cvv.html',400,400);" style="cursor:hand;"><img src="img/question.png" width="15" height="15" /></a></label>
                                        <input type="text" name="cvvtxt" id="cvvtxt" runat="server" tabindex="22" />
                                    </div>
                                    
                                    <div class="smalltextbox">
                                        <label>מספר תשלומים</label>
                                        <select id="paymentsselect" runat="server" name="paymentsselect" tabindex="23" style="width:80px;" onchange="paymentSelected(this.value);">
                                     </select>
                                    </div>
                                    
                                  </td>
                                  <td valign="top">
                                  	
                                    <label>תעודת זהות</label>
                                        <input type="text" name="idcardtxt" id="idcardtxt" runat="server" tabindex="21" />
                                    
                                </td>
                              </tr>
                            </table>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="panelsepline"></div>
                    <div class="checkoutsubpanel">
                        <label>הערות הלקוח</label>
                        <textarea name="ordercomments" id="ordercomments" cols="45" rows="3" style="width:452px;" tabindex="24" runat="server"></textarea>
                    </div>
                    
                    <div class="panelsepline"></div>
                    
                    <div class="checkoutsubpanel">
                        <br />
                        <label><input name="agreecheck" id="agreecheck" type="checkbox" tabindex="25" />
                        <b>אני קראתי ומסכים <a href="javascript:open_popup('takanon.aspx',1080,800);" style="cursor:hand; text-decoration:underline;">לתקנון</a></b></label>
                        <br /><br />
                        <input type="submit" id="buynow" name="buynow" value="אישור והשלמת הרכישה" runat="server" class="butstyle" tabindex="26" />
                        
                        <div class="clear"></div>
                    </div>
                </div>
            
            </asp:Panel>
            
        </asp:Panel>
        
    </td>
  </tr>
  </table>
  </asp:Panel>
<br />



<asp:Panel ID="successpanel" runat="server">
	<table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
		<tr>
    		<td>
				<div class="ordersuccess">ההזמנה עברה בהצלחה</div>
                <div style="color:#666;">פרטי ההזמנה שלך נשלחים ברגעים אילו למייל שלך</div>
                <br />
                <h1 style="color:#666;" class="subtitles">מספר ההזמנה: <%=Request("oid")%></h1>
                <br />
    			<modulus:ordersummary id="ordersummary1" runat="server" />
                <br />
                <h1 style="color:#666;" class="subtitles"><a href="index.aspx"><img src="img/arrowright.gif" width="7" height="11" align="absmiddle" /> חזרה לאתר</a></h1>
            </td>
        </tr>
    </table>
</asp:Panel>


<div class="clear"></div>

    
    
    
  </form>
    <br /><br />
    
</asp:Content>