using PhotoArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Pending : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pendingAlbums = this.Data.Albums
                     .Where(x => !x.IsApproved)
                     .ToList()
                     .Select(x => new
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Description = x.Description,
                         CreatedOn = x.CreatedOn,
                         IsApproved = x.IsApproved,
                         CoverImage1 = "data:image/jpeg;base64," + x.Images.FirstOrDefault().Content,
                         CoverImage = "data:image/jpeg;base64," + Convert.ToBase64String(x.Images.FirstOrDefault().Content)
                     })
                     .ToList();
           // this.Image1.ImageUrl = pendingAlbums.FirstOrDefault().CoverImage;
            if (!Page.IsPostBack)
            {
                this.GridPendingAlbums.DataSource = pendingAlbums;
                this.GridPendingAlbums.DataBind();
            }
        }

        protected void GridPendingAlbums_PageIndexChanging(object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            var pendingAlbums = this.Data.Albums
                               .Where(x => !x.IsApproved)
                               .ToList();

            this.GridPendingAlbums.PageIndex = e.NewPageIndex;
            this.GridPendingAlbums.DataSource = pendingAlbums;
            this.GridPendingAlbums.DataBind();
        }

        protected void GridPendingAlbums_RowDataBound(object sender,
            GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] =
                    "this.style.background='#EEEEEE';this.style.cursor='hand'";
                e.Row.Attributes["onmouseout"] =
                    "this.style.background='white'";
                e.Row.Attributes["onclick"] =
                    ClientScript.GetPostBackClientHyperlink(
                    this.GridPendingAlbums, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridPendingAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LabelSelectedItem.Text =
                "Selected customer ID = " +
                this.GridPendingAlbums.SelectedDataKey.Value;
        }
    }
}