<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="PhotoArt.Web.Controls.Carousel" %>
<asp:UpdatePanel ID="UpdatePanelCarousel" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div class="panel panel-warning panel-dark text-center">
            <asp:Image runat="server" ID="CoverImage" Width="600px" />

        </div>
        <div class="panel  panel-warning carousel-row">
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-1 text-left">
                        <asp:LinkButton runat="server" ID="CarouselPrev" CssClass="btn btn-opacity-vertical" OnClick="Carousel_Prev" AutoPostBack="True">
                                 <span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xs-1 btn-carousel-right text-right">
                        <asp:LinkButton runat="server" ID="CarouselNext" CssClass="btn btn-opacity-vertical" OnClick="Carousel_Next" AutoPostBack="True">
                                 <span aria-hidden="true" class="glyphicon glyphicon-arrow-right"></span>
                        </asp:LinkButton>

                    </div>
                    <div class="col-xs-10 text-center">
                        <asp:Repeater ID="CarouselRepeater" runat="server" ItemType="PhotoArt.Web.ViewModels.ImageViewModel" SelectMethod="GetImages">
                            <ItemTemplate>

                                <asp:ImageButton runat="server" ImageUrl='<%#: string.Format("~/{0}",Eval("Url")) %>' CssClass="row img" OnClick="Carousel_Selected" />


                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
            </div>
        </div>
        <script>
            $('input[type="image"]').on('click', function (e) {
                var target = $(e.target);
                console.log(target.attr('id'));

            })
        </script>
    </ContentTemplate>
</asp:UpdatePanel>
