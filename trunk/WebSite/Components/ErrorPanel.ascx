<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorPanel.ascx.cs"
    Inherits="WongTung.WebSite.Components.ErrorPanel" %>
<div>
    <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
        <tr>
            <td valign="top" style="width: 80px;" align="left">
                <img alt="" src="images/erroricon.jpg" />
            </td>
            <td style="width: 5px;">
            </td>
            <td align="left" style="width: 99%;" valign="top">
                <asp:Label ID="lblErrTitle" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtErrMessage" runat="server" BorderWidth="0px" ReadOnly="true"
                    Width="100%"></asp:TextBox>
                <hr noshade="noshade" size="0" />
                <asp:TextBox ID="txtErrDetail" runat="server" TextMode="MultiLine" BorderWidth="0px"
                    CssClass="content" Style="overflow: auto;" ReadOnly="true" Width="100%" Rows="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <hr noshade="noshade" size="0" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnRedirect" runat="server" Text="Return login page" OnClick="btnRedirect_Click" />
            </td>
        </tr>
    </table>
</div>
