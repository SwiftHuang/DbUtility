<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.workstage.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		WT_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWT_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WT_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWT_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WT_DESC
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWT_DESC" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WT_DESC_T
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWT_DESC_T" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		WT_DESC_S
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWT_DESC_S" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
