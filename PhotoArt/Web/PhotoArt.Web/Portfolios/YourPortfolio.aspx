<%@ Page Title="Your Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YourPortfolio.aspx.cs" Inherits="PhotoArt.Web.Portfolios.YourPortfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/file-upload-style.css" rel="stylesheet" />
    <script src="../Scripts/CustomScripts/previewImageScript.js"></script>

    <asp:UpdatePanel ID="UpdatePanelPortfolio" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelPorfolio" runat="server" Visible="true">
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="AddAlbum_Click" ID="AddAlbum" AutoPostBack="True" Text="Add Album" CssClass="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="AddAlbum" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelAlbums" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelAlbums" runat="server" Visible="false">
                <h4>Create new Album</h4>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AlbumName" CssClass="col-md-2 control-label">Album Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="AlbumName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AlbumName"
                            CssClass="text-danger" ErrorMessage="The album name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AlbumDescription" CssClass="col-md-2 control-label">Album Description</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="AlbumDescription" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AlbumDescription"
                            CssClass="text-danger" ErrorMessage="The album description field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ID="CreateAlbum" OnClick="CreateAlbum_Click" AutoPostBack="True" Text="Create Album" CssClass="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CreateAlbum" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelImages" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelImages" runat="server" Visible="false">
                <%--<div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ImageDescription" CssClass="col-md-2 control-label">Image Description</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="ImageDescription" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ImageDescription"
                                CssClass="text-danger" ErrorMessage="The image description field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ImageLocation" CssClass="col-md-2 control-label">Image Location</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="ImageLocation" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ImageLocation"
                                CssClass="text-danger" ErrorMessage="The image location field is required." />
                        </div>
                    </div>--%>
                <label class="file-upload">
                    <span><strong>Upload Images</strong></span>
                    <asp:FileUpload ID="fileuploadControl" runat="server" AllowMultiple="true" />
                </label>
                <div id="dvPreview">
                </div>
                <asp:Button runat="server" ID="AddImages" Text="Add Pictures" OnClick="AddImages_Click" />
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="AddImages" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:GridView ID="GridAlbums" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" DataKeyNames="ID"
        OnPageIndexChanging="GridAlbums_PageIndexChanging"
        OnRowDataBound="GridAlbums_RowDataBound"
        CssClass="table table-striped table-bordered table-condensed">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="CreatedOn" HeaderText="Created" />
            <asp:HyperLinkField Text="Update Album" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/Albums/Update.aspx?id={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
