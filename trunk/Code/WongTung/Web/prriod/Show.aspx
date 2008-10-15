<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.prriod.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PR_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPR_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PR_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPR_NO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PR_FROM
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPR_FROM" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PR_TO
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPR_TO" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
