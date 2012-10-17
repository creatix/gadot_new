<%@ Control Language="VB" AutoEventWireup="false" CodeFile="maincats.ascx.vb" Inherits="components_maincats" %>

        <ul>
        <asp:Repeater ID="catsRepeater" runat="server">
        		<itemtemplate>
                	<li <%#getselected(Eval("catsid"))%>>
        				<a href="<%# pageLogic.GetLink("maincat", Eval("catsid"), Eval("name"), "")%>">
                          <%#pageLogic.getEditableDataField("cats", "name", Eval("productsid"), Eval("name"))%>                      
                        </a>
					</li>
        		</itemtemplate>
                <separatortemplate>
                 <div class="clear"></div>
                </separatortemplate>
    		</asp:Repeater>

</ul>
