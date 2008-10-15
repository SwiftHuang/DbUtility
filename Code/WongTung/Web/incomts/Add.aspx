<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.incomts.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		IST_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_OFFCIE_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_OFFCIE_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_WORK_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_WORK_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_USER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_USER_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_USER_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_USER_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_INPUT_OK
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_INPUT_OK" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_APP
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_APP" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_NOR_HR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_NOR_HR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_OT_HR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_OT_HR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IST_PERIOD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIST_PERIOD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
