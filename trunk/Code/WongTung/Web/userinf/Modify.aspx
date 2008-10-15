<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.userinf.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		USER_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblUSER_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_EMP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_RAND
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_RAND" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_CURDATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_CURDATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_RAND_BACK
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_RAND_BACK" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_ACTIVATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_ACTIVATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		USER_CHNAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtUSER_CHNAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
