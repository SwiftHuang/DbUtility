<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.leave_bak.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LEVAE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLEVAE_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LEVAE_DESC
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLEVAE_DESC" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
