<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="PhotoArt.Web.Admin.Albums.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Details</h1>
    <%-- <asp:Label ID="ImagUrlLabel" runat="server" />
    <asp:Image ID="ImageContainer" runat="server" />--%>
    <asp:Repeater ID="Carousel" runat="server">
        <ItemTemplate>
            <asp:Image runat="server" ImageUrl='<%#: string.Format("~/{0}",Eval("Url")) %>' />
            <%--              <img src="<%#: DataBinder.Eval(Container.DataItem, "Url") %>" width="200px" height="100px" />--%>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
