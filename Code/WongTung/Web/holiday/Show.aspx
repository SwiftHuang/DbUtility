<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.holiday.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		HD_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHD_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHD_EMP_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_LINE_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHD_LINE_NO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHD_DATE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_LEVE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHD_LEVE_CODE" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
