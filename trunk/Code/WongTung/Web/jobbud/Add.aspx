<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.jobbud.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		JOB_STAFF
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_STAFF" runat="server" Width="200px"></asp:TextBox>
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
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
