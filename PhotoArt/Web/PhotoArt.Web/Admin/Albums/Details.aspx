<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="PhotoArt.Web.Admin.Albums.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Details</h1>
    <%-- <asp:Label ID="ImagUrlLabel" runat="server" />
    <asp:Image ID="ImageContainer" runat="server" />--%>
    <asp:UpdatePanel ID="UpdatePanelCarousel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="panel panel-warning panel-dark text-center">
                <asp:Image runat="server" ID="CoverImage" Width="600px" />

            </div>
            <div class="panel  panel-warning carousel-row">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-1 text-left">
                            <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-opacity-vertical" OnClick="Carousel_Prev" AutoPostBack="True">
                                 <span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span>
                            </asp:LinkButton>
                            <%--<a href="/#" class="btn btn-opacity-vertical" runat="server" onserverclick="Carousel_Prev"><i class="glyphicon glyphicon-arrow-left"></i></a>--%>
                        </div>
                        <div class="col-xs-1 btn-carousel-right text-right">
                            <asp:LinkButton runat="server" ID="CarouselNext" CssClass="btn btn-opacity-vertical" OnClick="Carousel_Next" AutoPostBack="True">
                                 <span aria-hidden="true" class="glyphicon glyphicon-arrow-right"></span>
                            </asp:LinkButton>
                            <%--  <a href="/#" class="btn btn-opacity-vertical" runat="server" id="CarouselNext" onserverclick="Carousel_Next"><i class="glyphicon glyphicon-arrow-right"></i></a>--%>
                        </div>
                        <div class="col-xs-10 text-center">
                            <asp:Repeater ID="Carousel" runat="server" OnItemDataBound="Carousel_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Image runat="server" ImageUrl='<%#: string.Format("~/{0}",Eval("Url")) %>' CssClass="row" />
                                    <%--              <img src="<%#: DataBinder.Eval(Container.DataItem, "Url") %>" width="200px" height="100px" />--%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
    $('img').on('click', function (e) {
        var target = $(e.target);
        console.log(target.attr('id'));

    })
</script>
</asp:Content>

