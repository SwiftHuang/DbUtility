<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.non_hist.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		STAFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSTAFF_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TYPE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTYPE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ANNUAL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtANNUAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SICK
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSICK" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ADMIN
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtADMIN" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OT_PAY
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOT_PAY" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
