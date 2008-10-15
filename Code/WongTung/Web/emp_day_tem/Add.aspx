<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.emp_day_tem.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_4
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_4" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_5
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_5" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_6
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_6" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_7
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_7" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_8
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_8" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_9
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_9" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ED_JS_10
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtED_JS_10" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
