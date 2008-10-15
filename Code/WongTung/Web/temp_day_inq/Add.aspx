<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.temp_day_inq.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		TEM_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_STAFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_STAFF_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_WORK_DATE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_WORK_DATE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_LINE_NO
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_LINE_NO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_HOUR_TYPE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_HOUR_TYPE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_APP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_APP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_SER_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_SER_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_JOB_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_JOB_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_0
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_0" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_4
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_4" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_5
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_5" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_NOR_HOUR_6
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_NOR_HOUR_6" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_TYPE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_TYPE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEM_APP_FLAG
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTEM_APP_FLAG" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
