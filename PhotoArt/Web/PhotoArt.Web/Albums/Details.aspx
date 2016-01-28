<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="PhotoArt.Web.Albums.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 col-md-offset-1">
        <asp:Repeater ID="currentAlbum" runat="server">
            <ItemTemplate>
                <asp:Image runat="server" ImageUrl='<%#: string.Format("~/{0}",Eval("Url")) %>' />
                   <%-- <img src="<%#: string.Format("~/{0}",DataBinder.Eval(Container.DataItem, "Url")) %>" class="gallery-images" />--%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
