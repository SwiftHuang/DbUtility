<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.spe_endorse.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		SPE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSPE_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SPE_CRE_EMP
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSPE_CRE_EMP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SPE_CRE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSPE_CRE_DATE" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
