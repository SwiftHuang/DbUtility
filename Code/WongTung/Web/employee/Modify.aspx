<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.employee.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		EMP_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblEMP_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_POS_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_POS_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_DEP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_DEP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_INITIAL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_INITIAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_OFFICE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_OFFICE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_CHNAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_CHNAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_SPE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_SPE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_CRE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_CRE_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EMP_DEL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEMP_DEL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
