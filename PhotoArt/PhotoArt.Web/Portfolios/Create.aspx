<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PhotoArt.Web.Portfolios.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/file-upload-style.css" rel="stylesheet" />
    <script src="../Scripts/CustomScripts/previewImageScript.js"></script>

    <h2><%: Title %>Create Portfolio</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">

        <asp:UpdatePanel ID="UpdatePanelPortfolio" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelPorfolio" runat="server" Visible="true">
                    <h4>Create new portfolio</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                CssClass="text-danger" ErrorMessage="The name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreatePortfolio_Click" ID="CreatePortfolio" AutoPostBack="True" Text="Create" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="CreatePortfolio" />
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
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="AlbumName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AlbumName"
                                CssClass="text-danger" ErrorMessage="The album name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="AlbumDescription" CssClass="col-md-2 control-label">Album Description</asp:Label>
                        <div class="col-md-6">
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


    </div>
</asp:Content>
