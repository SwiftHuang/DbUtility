<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.plan_emp.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_NUM
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_NUM" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_NOR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_NOR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_OT1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_OT1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_OT2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_OT2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_OT3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_OT3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_T1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_T1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_T2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_T2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_EMP_T3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_EMP_T3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
