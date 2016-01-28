using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var albums = this.Data.Albums
                    .Where(x => x.Images.Count>0)
                    .ToList()
                    .Select(x => new
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        CreatedOn = x.CreatedOn,
                        IsApproved = x.IsApproved,
                        Url = x.Images.FirstOrDefault().Url,
                        CoverImage1 = "data:image/jpeg;base64," + x.Images.FirstOrDefault().Content,
                        CoverImage = "data:image/jpeg;base64," + Convert.ToBase64String(x.Images.FirstOrDefault().Content)
                    })
                    .ToList();
            // this.Image1.ImageUrl = pendingAlbums.FirstOrDefault().CoverImage;
            if (!Page.IsPostBack)
            {
                this.albums.DataSource = albums;
                this.albums.DataBind();
            }
        }
    }
}