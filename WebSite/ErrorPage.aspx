<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="WongTung.WebSite.ErrorPage" %>

<%@ Register Src="Components/ErrorPanel.ascx" TagName="ErrorPanel" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profiles</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0px" cellpadding="1px" cellspacing="1px" width="100%">
            <tr>
                <td align="center">
                    <br />
                    <table border="0px" cellpadding="0px" cellspacing="0px" width="610px">
                        <tr>
                            <td class="tbBorder1-lt" />
                            <td class="tbBorder1-mt" />
                            <td class="tbBorder1-rt" />
                        </tr>
                        <tr>
                            <td class="tbBorder1-l" />
                            <td align="center">
                                <uc1:ErrorPanel ID="ErrorPanel1" runat="server" />
                            </td>
                            <td class="tbBorder1-r" />
                        </tr>
                        <tr>
                            <td class="tbBorder1-lb" />
                            <td class="tbBorder1-mb" />
                            <td class="tbBorder1-rb" />
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
