<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoArt.Web.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin Home Page</h1>


    <div class="row">
       <a runat="server" href="~/Admin/Albums/Pending">
            <div id="btn-pendingAlbumsLink" class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box-custom bg-yellow">
                <span class="info-box-custom-icon"><span class="glyphicon glyphicon-camera"></span></span>
                <div class="info-box-custom-content">

                    <span class="info-box-custom-text">Pending Albums</span><span class="info-box-custom-number">
                        <asp:Label runat="server" ID="PendingAlbums" ItemType="Product">     
                        </asp:Label>
                    </span>
                </div>
            </div>
        </div>
       </a>
        <div class="col-md-6 col-sm-6 col-xs-12">
            <div id="eventInfo" style="display: none" class="bg-yellow row nav navbar navbar-nav">
                <li class="col-md-4"><i class="material-icons">bookmark</i><div id="title"></div>
                </li>
                <li class="divider"><i></i></li>
                <li class="col-md-4"><i class="material-icons">person_add</i><div id="speakers"></div>
                </li>
                <li class="divider"><i></i></li>
                <li class="col-md-3"><i class="material-icons">room</i><div id="location"></div>
                </li>
            </div>
        </div>
    </div>

</asp:Content>
