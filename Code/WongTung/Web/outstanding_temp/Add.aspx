<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.outstanding_temp.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		OUT_OFF_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_OFF_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_OFF_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_OFF_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_EMP_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_EMP_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_EMP_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_EMP_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_DAY
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_DAY" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_POS_CLASS
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_POS_CLASS" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_POS_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOUT_POS_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		OUT_UPDATE_DATE
	</td>
	<td height="25" width="*" align="left">
		<INPUT onselectstart="return false;" onkeypress="return false" id="txtOUT_UPDATE_DATE" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server">
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
