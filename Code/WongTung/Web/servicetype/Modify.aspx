<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.servicetype.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ST_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_JOB_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_JOB_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_SER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_SER_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC_T1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC_T1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC_S1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC_S1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC_T2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC_T2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ST_DESC_S2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtST_DESC_S2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
