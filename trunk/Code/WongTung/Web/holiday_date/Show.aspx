<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.holiday_date.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		HO_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HO_LOC
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_LOC" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HO_DATE_START
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_DATE_START" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HO_DATE_END
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_DATE_END" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HO_DESC
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHO_DESC" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
