<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sidecats.ascx.vb" Inherits="components_sidecats" %>

	<div class="sidecats">
        <ul>
        <asp:Repeater ID="catsRepeater" runat="server">
        		<itemtemplate>
                	<li <%#getlast(Eval("catsid"))%>>
        				<a href="<%# pageLogic.GetLink("cat", Eval("catsid"), Eval("name"), "")%>">
                          <%#Eval("name")%>                           
                        </a>
                        
                        <%#getSubCats(Eval("catsid"),1)%>
                        
					</li>
        		</itemtemplate>
                <separatortemplate>
                 <div class="clear"></div>
                </separatortemplate>
    		</asp:Repeater>
		</ul>
    </div>
