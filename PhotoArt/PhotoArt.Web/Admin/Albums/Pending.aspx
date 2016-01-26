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
    <asp:GridView ID="GridPendingAlbums" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" DataKeyNames="ID"
        OnPageIndexChanging="GridPendingAlbums_PageIndexChanging"
        OnSelectedIndexChanged="GridPendingAlbums_SelectedIndexChanged"
        OnRowDataBound="GridPendingAlbums_RowDataBound"
        CssClass="table table-striped table-bordered table-condensed">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField runat="server">
                <ItemTemplate>
                    <img src="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" width="200px" height="100px" />
                    <%-- <asp:Image ImageUrl="<%#: DataBinder.Eval(Container.DataItem, "CoverImage") %>" Width="200" Height="100" />--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="CreatedOn" HeaderText="Created" />
            <%-- <asp:BoundField DataField="EMail" HeaderText="E-Mail" />--%>
            <asp:CheckBoxField DataField="IsApproved" HeaderText="Approved" />
            <asp:HyperLinkField Text="View Details" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="Details.aspx?id={0}" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="LabelSelectedItem" runat="server"></asp:Label>
    <%--</form>--%>
</asp:Content>
