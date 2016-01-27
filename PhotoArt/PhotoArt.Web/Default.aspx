<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoArt.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/images-style.css" rel="stylesheet" />

    <h1>Home Page</h1>
    <div class="col-md-12 col-md-offset-1">
        <asp:Repeater ID="albums" runat="server">
            <ItemTemplate>
                <a class="polaroid pull-left col-md-2" href="#">
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" class="gallery-images" />
                </a>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <a class="polaroid pull-left to-the-right col-md-2" href="#">
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" class="gallery-images" />
                </a>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
