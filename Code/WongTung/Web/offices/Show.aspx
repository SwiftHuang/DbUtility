<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.offices.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		OFF_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOFF_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOFF_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OFF_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOFF_NAME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OFF_ENDORSE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOFF_ENDORSE" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
