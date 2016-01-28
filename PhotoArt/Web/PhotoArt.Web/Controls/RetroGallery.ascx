<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RetroGallery.ascx.cs" Inherits="PhotoArt.Web.Controls.RetroGallery" %>
<%@ OutputCache Duration="300" VaryByParam="None" %>
 <div class="col-md-12 col-md-offset-1">
        <asp:Repeater ID="albums" runat="server">
            <ItemTemplate>
                <a class="polaroid pull-left col-md-2" href="Albums/Details.aspx?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>">
                <h4><%# DataBinder.Eval(Container.DataItem, "Name") %></h4>
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "Url") %>" class="gallery-images" />
                </a>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <a class="polaroid pull-left to-the-right col-md-2" href="Albums/Details.aspx?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>">
                    <h4><%# DataBinder.Eval(Container.DataItem, "Name") %></h4>
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "Url") %>" class="gallery-images" />
                </a>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>