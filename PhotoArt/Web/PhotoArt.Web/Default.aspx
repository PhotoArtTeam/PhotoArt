<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoArt.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/images-style.css" rel="stylesheet" />

    <h1>Home Page</h1>
    <pha:retroGallery runat="server" />
</asp:Content>
