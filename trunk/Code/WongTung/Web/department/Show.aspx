<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.department.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		DEPT_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDEPT_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DEPT_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDEPT_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DEPT_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDEPT_NAME" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
