<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.position.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		POS_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblPOS_CODE" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_DESC
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_DESC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_FEE_LEV1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_FEE_LEV1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_FEE_LEV2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_FEE_LEV2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_FEE_LEV3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_FEE_LEV3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_RATE_OUT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_RATE_OUT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_RATE_DAILY
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_RATE_DAILY" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_RATE_MON
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_RATE_MON" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_RATE_OT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_RATE_OT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_MON_TOTAL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_MON_TOTAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_MON_UTILIST
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_MON_UTILIST" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_MON_REV
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_MON_REV" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_SAL_FROM
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_SAL_FROM" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_SAL_TO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_SAL_TO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_DALIY_COST
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_DALIY_COST" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_MON_COST
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_MON_COST" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_CLASS
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_CLASS" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		POS_PLAN
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPOS_PLAN" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
