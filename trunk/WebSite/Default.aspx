<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WongTung.WebSite._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" src="Components/Calendar/calendar-debug.js"></script>

    <script type="text/javascript" src="Components/Calendar/Lang/calendar-en-debug.js"></script>

    <link href="Components/Calendar/calendar-brown.css" rel="stylesheet" type="text/css" />
</head>
<body onload="SetupCalendar();" style="font-size: 12px;">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        New1<br />
        <asp:Label ID="Label2" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        <br />
        New2<br />
        <asp:Label ID="Label4" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        <br />
        Table<br />
        <asp:Label ID="Label6" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
        <asp:Label ID="Label7" runat="server" Text="Label" EnableViewState="false"></asp:Label><br />
    </div>
    <input id="txtDep" readonly="readonly" class="txt" style="width: 70px;" type="text"
        maxlength="12" /><input type="button" id="cal-dep" />

    <script language="javascript" type="text/javascript">
    function SetupCalendar()
    {
        //RegCss("../Components/calendar/calendar-brown.css");
        //RegJs("../Components/calendar/lang/calendar-en.js");
        
	    Calendar.setup({
		    inputField     :    "txtDep",  
		    ifFormat       :    "%d/%m/%Y", 
		    showsTime      :    false,      
		    button         :    "cal-dep",
		    singleClick    :    true,
		    step           :    1 
	    });
	    /*
	    Calendar.setup({
	        inputField     :    "txtRet",  
	        ifFormat       :    "%d/%m/%Y", 
	        showsTime      :    false,      
	        button         :    "cal-ret",
	        singleClick    :    true,
	        step           :    1 
        });*/
    }
    </script>

    <asp:Localize ID="Localize1" runat="server"></asp:Localize>
    <asp:Panel ID="Panel1" runat="server">
        <table border="0px" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    Select
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSelect" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Insert
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtInsert" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Update
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtUpdate" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Delete
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtDel" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
