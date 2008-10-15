<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.icpinq.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ICP_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICP_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ICP_OFFICE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICP_OFFICE_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ICP_OFFICE_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICP_OFFICE_NAME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ICP_EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICP_EMP_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ICP_EMP_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICP_EMP_NAME" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
