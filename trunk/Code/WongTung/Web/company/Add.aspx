<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.company.Add" Title="增加页" %>

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
		CO_SCR_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_SCR_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_RPT_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_RPT_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_LB_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_LB_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_LE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_LE_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_CB_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_CB_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_CE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_CE_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_CURR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_CURR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_PERIOD_FROM
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_PERIOD_FROM" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CO_PERIOD_TO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCO_PERIOD_TO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
