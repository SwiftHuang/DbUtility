<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportExcel.ascx.cs"
    Inherits="WongTung.WebSite.Components.ImportExcel" %>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
<div>
    <h4>
        Select a file to upload:</h4>
    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
    <br />
    <br />
    <asp:Button ID="UploadButton" Text="Upload file" OnClick="UploadButton_Click" runat="server">
    </asp:Button>
    <hr />
    <asp:Label ID="UploadStatusLabel" runat="server">
    </asp:Label>
</div>
