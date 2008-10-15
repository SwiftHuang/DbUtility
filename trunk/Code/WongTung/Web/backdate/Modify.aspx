<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.backdate.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		BK_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_USER
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_USER" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_RAN_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_RAN_NO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_EMP
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_EMP" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_RAN_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_RAN_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_CRE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_CRE_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BK_STATUS
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBK_STATUS" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
