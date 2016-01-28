using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Albums
{
    public partial class Details : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request.Params["Id"]);

            if (Request.Params["Id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            var album = this.Data.Albums
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    Images = x.Images
                    .Select(i => new
                    {
                        Id = i.Id,
                        Url = i.Url
                    })
                })
                .FirstOrDefault();

            if (!Page.IsPostBack)
            {
                this.currentAlbum.DataSource = album.Images;
                this.currentAlbum.DataBind();
            }
        }
    }
}