<%@ Page Title="Update Album" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="PhotoArt.Web.Admin.Albums.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/file-upload-style.css" rel="stylesheet" />
    <script src="../Scripts/CustomScripts/previewImageScript.js"></script>
    <link href="../Content/fotorama.css" rel="stylesheet" />
    <script src="../Scripts/CustomScripts/fotorama.js"></script>
    <asp:UpdatePanel ID="UpdatePanelAlbums" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelAlbums" runat="server">

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
                <div class="form-group col-md-12 col-md-offset-1">
                    <div class="fotorama col-md-offset-2" data-width="800" data-max-width="100%">
                        <asp:Repeater ID="currentAlbum" runat="server">
                            <ItemTemplate>
                                <asp:Image runat="server" ImageUrl='<%#: string.Format("~/{0}",Eval("Url")) %>' />
                                <%-- <img src="<%#: string.Format("~/{0}",DataBinder.Eval(Container.DataItem, "Url")) %>" class="gallery-images" />--%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <label class="file-upload">
                    <span><strong>Upload Images</strong></span>
                    <asp:FileUpload ID="fileuploadControl" runat="server" AllowMultiple="true" />
                </label>
                <div id="dvPreview">
                </div>
                <asp:Button runat="server" ID="AddImages" Text="Add Pictures" OnClick="AddImages_Click" />
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ID="UpdateAlbum" OnClick="UpdateAlbum_Click" Text="Update Album" CssClass="btn btn-primary" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="AddImages" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
