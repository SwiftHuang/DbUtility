<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.non.Show" Title="ÏÔÊ¾Ò³" %>
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
		STAFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSTAFF_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDATE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TYPE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTYPE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ANNUAL
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblANNUAL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SICK
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSICK" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ADMIN
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblADMIN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OT_PAY
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOT_PAY" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
