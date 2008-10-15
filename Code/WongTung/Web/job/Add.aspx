<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="WongTung.Web.job.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_CO_CODE" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_NAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CON
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_CON" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OPEN_BAL_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OPEN_BAL_HOUR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_YTD_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_YTD_HOUR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OPEN_BAL_AMT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OPEN_BAL_AMT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_YTD_AMT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_YTD_AMT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_REC
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_REC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OS_BAL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OS_BAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_BUD_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_BUD_HOUR" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CO_ORD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_CO_ORD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_ADMIN
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_ADMIN" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_DESIGN
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_DESIGN" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_LEV1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_LEV2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_LEV3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CHARGE_OUT
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_CHARGE_OUT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_DAILY
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_DAILY" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_MON
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_MON" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_PERIOD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_PERIOD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_PERIOD_VAL
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_PERIOD_VAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OFF_INCHG_AD
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OFF_INCHG_AD" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OFF_INCHG_DES
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_OFF_INCHG_DES" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_1
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH_1" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_2
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH_2" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_3
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH_3" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_4
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH_4" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_5
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_AUTH_5" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_INDEX
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_INDEX" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME_S
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_NAME_S" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME_T
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtJOB_NAME_T" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
