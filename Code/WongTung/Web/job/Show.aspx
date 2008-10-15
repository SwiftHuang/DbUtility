<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="WongTung.Web.job.Show" Title="ÏÔÊ¾Ò³" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CO_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_CO_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CODE
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_CODE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_NAME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CON
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_CON" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OPEN_BAL_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_OPEN_BAL_HOUR" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_YTD_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_YTD_HOUR" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OPEN_BAL_AMT
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_OPEN_BAL_AMT" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_YTD_AMT
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_YTD_AMT" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_REC
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_REC" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OS_BAL
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_OS_BAL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_BUD_HOUR
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_BUD_HOUR" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CO_ORD
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_CO_ORD" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_ADMIN
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_ADMIN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_DESIGN
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_DESIGN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV1
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_LEV1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV2
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_LEV2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_LEV3
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_LEV3" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_CHARGE_OUT
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_CHARGE_OUT" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_DAILY
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_DAILY" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_MON
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_MON" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_PERIOD
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_PERIOD" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_PERIOD_VAL
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_PERIOD_VAL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OFF_INCHG_AD
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_OFF_INCHG_AD" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_OFF_INCHG_DES
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_OFF_INCHG_DES" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_1
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH_1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_2
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH_2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_3
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH_3" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_4
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH_4" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_AUTH_5
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_AUTH_5" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_INDEX
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_INDEX" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME_S
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_NAME_S" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		JOB_NAME_T
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblJOB_NAME_T" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
