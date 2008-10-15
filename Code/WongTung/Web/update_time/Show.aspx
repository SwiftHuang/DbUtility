<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.update_time.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		UT_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_DATE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_TIME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_TIME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_FRE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_FRE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_UPDATE_USER
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_UPDATE_USER" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_UPDATE_DT
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_UPDATE_DT" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		UT_INF
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUT_INF" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
