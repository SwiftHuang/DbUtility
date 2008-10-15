<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.backspecial.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		BS_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBS_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BS_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBS_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BS_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBS_DATE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BS_CURDATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBS_CURDATE" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
