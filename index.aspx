<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" MasterPageFile="Main.master" %>
<%@ Register TagPrefix="modulus" TagName="banner" Src="~/components/banner.ascx" %>
<%@ Register TagPrefix="modulus" TagName="grid" Src="~/components/grid.ascx" %>
<%@ Register TagPrefix="modulus" TagName="bannerslideshow" Src="~/components/bannerslideshow.ascx" %>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

	<div class="si">
    	<modulus:banner id="bannerslideshow1" runat="server" bannerName="���� ���� ����" width="682" height="258" />
    	
    </div>
      <div class="details clearfix">
        <div class="details_left">
          <h2><img src="img/img1.png" alt="" align="absmiddle" />&nbsp;��������� </h2>
          <p>��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� </p>
          <a href="#">������ ������</a></a> </div>
        <div class="details_right">
          <h2><img src="img/img2.png" alt="" align="absmiddle" />&nbsp;������� ����</h2>
          <p>��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� </p>
          <a href="#">������ ������</a></a> </div>
      </div>
      <div class="boder">&nbsp;</div>
      <div class="details clearfix">
        <div class="details_left">
          <h2><img src="img/img3.png" alt="" align="absmiddle" />&nbsp;���� ������</h2>
          <p>��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� </p>
          <a href="#">������ ������</a></a> </div>
        <div class="details_right">
          <h2><img src="img/img4.png" alt="" align="absmiddle" />&nbsp;������� ����</h2>
          <p>��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� ��� </p>
          <a href="#">������ ������</a></a> </div>
      </div>
    
    
</asp:Content>
