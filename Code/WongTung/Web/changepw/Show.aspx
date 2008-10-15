<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.changepw.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CP_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCP_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CP_USER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCP_USER_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CP_NEW_PWD
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCP_NEW_PWD" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
