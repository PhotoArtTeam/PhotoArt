<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGrid.ascx.cs" Inherits="PhotoArt.Web.Controls.UserGrid" %>
<%@ OutputCache Duration="300" VaryByParam="None" %>
<asp:GridView runat="server" ID="GridUsers"
    ItemType="PhotoArt.Web.ViewModels.UserViewModel"
    SelectMethod="UsersGrid_GetData"
    DataKeyNames="Id"
    AllowPaging="True"
    AllowSorting="True"
    AutoGenerateColumns="False"
    PageSize="10"
    CssClass="table table-striped table-bordered table-condensed table-hover user-grid">
    <Columns>
        <asp:ImageField DataImageUrlField="CoverUrlPath" DataImageUrlFormatString="~/{0}" />
        <asp:DynamicField DataField="Name" HeaderText="Name" />
        <asp:DynamicField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Albums" HeaderText="Albums" />
        <asp:BoundField DataField="Country" HeaderText="Country" />
        <asp:HyperLinkField Text="View Details" DataNavigateUrlFields="Id"
            DataNavigateUrlFormatString="Details.aspx?id={0}" />
    </Columns>
    <PagerSettings Mode="NumericFirstLast" />
</asp:GridView>
