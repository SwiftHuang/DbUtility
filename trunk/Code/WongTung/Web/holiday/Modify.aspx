<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.holiday.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		HD_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHD_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHD_EMP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_LINE_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHD_LINE_NO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHD_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HD_LEVE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtHD_LEVE_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
