<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.plan_pos.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_CO
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblPLA_POS_CO" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_OFF
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblPLA_POS_OFF" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblPLA_POS_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_NUM
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_NUM" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_NOR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_NOR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_OT1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_OT1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_OT2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_OT2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_OT3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_OT3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_T1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_T1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_T2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_T2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PLA_POS_T3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPLA_POS_T3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
