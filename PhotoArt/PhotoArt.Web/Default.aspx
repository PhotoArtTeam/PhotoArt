<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoArt.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/images-style.css" rel="stylesheet" />

    <h1>Home Page</h1>
    <div class="col-md-12">
        <a class="polaroid pull-left col-md-3" href="#">
            <img src="Content/images/vintage-header.jpg" class="gallery-images" alt="">
        </a>
        <a class="polaroid pull-left to-the-right col-md-3" href="#">
            <img src="Content/images/pergaament-pattern.jpg" class="gallery-images" alt="">
        </a>
    </div>


</asp:Content>
