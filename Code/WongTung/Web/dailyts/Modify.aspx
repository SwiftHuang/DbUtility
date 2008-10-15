<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WongTung.Web.dailyts.Modify" Title="修改页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		DT_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_STAFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_STAFF_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_WORK_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_WORK_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_LINE_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_LINE_NO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_APP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_APP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_JOB_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_JOB_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_SER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_SER_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_NOR_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_NOR_HOUR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_OVER_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_OVER_HOUR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_TYPE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_TYPE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_PERIOD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_PERIOD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_SUBMIT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_SUBMIT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_UPDATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_UPDATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_RAMNO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_RAMNO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DT_UPDATE_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDT_UPDATE_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
