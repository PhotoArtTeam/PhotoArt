<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoArt.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/images-style.css" rel="stylesheet" />

    <h1>Home Page</h1>
    <div>
        <a class="polaroid pull-left" href="#">
            <img src="Content/images/vintage-header.jpg" class="gallery-images" alt="">
            <p class="caption">Found this little cutie on a walk in New Zealand!</p>
        </a>
        <a class="polaroid pull-left to-the-right" href="#">
            <img src="Content/images/pergaament-pattern.jpg" class="gallery-images" alt="">
            <p class="caption">Found this little cutie on a walk in New Zealand!</p>
        </a>
    </div>


</asp:Content>
