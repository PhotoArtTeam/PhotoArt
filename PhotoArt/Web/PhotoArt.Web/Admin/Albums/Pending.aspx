<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="PhotoArt.Web.Admin.Albums.Pending" %>

<asp:Content ID="PendingAlbumsContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:Repeater ID="PendingAlbums" runat="server">
        <ItemTemplate>
            <%#: DataBinder.Eval(Container.DataItem, "Content") %>
            <br />
        </ItemTemplate>
    </asp:Repeater>--%>

    <%--<form id="formMain" runat="server">--%>
    <%--<asp:Image Id="Image1" runat="server" />--%>
    <asp:GridView runat="server" ID="GridPendingAlbums"
        ItemType="PhotoArt.Web.ViewModels.AlbumViewModel"
        SelectMethod="PendingAlbumsGrid_GetData"
        DataKeyNames="Id"
        AllowPaging="True"
        AllowSorting="True"
        AutoGenerateColumns="False"
        PageSize="10"
        CssClass="table table-striped table-bordered table-condensed table-hover">
        <Columns>
            <%--<asp:TemplateField runat="server">
                <ItemTemplate>
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" width="200px" height="100px" />
                     <asp:Image ImageUrl="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" Width="200" Height="100" />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:ImageField DataImageUrlField="CoverUrlPath" DataImageUrlFormatString="~/{0}" />
            <asp:DynamicField DataField="Name" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:DynamicField DataField="CreatedOn" HeaderText="Created" />
            <%-- <asp:BoundField DataField="EMail" HeaderText="E-Mail" />--%>
            <asp:CheckBoxField DataField="IsApproved" HeaderText="Approved" />
            <asp:HyperLinkField Text="View Details" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="Details.aspx?id={0}" />
        </Columns>
        <PagerSettings Mode="NumericFirstLast" />
    </asp:GridView>
    <asp:Label ID="LabelSelectedItem" runat="server"></asp:Label>
    <%--</form>--%>
</asp:Content>
