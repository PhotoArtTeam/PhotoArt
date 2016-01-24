<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="PhotoArt.Web.Admin.Albums.Pending" %>

<asp:Content ID="PendingAlbumsContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="PendingAlbums" runat="server">
        <ItemTemplate>
            <%#: DataBinder.Eval(Container.DataItem, "Name") %>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
