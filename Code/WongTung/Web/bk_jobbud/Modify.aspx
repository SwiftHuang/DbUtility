<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.bk_jobbud.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblJOB_CO_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblJOB_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_SER
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblJOB_SER" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_POS
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_POS" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_STAFF
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblJOB_STAFF" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_BUD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_BUD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NOR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_NOR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NOR_EXP
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_NOR_EXP" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OT_EXP
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OT_EXP" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
