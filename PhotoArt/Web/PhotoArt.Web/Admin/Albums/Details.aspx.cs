using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Details : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request.Params["Id"]);
            if (Request.Params["Id"] == null)
            {
                Response.Redirect("GridViewDemo.aspx");
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
            // TODO: check for null

            this.Carousel.DataSource = album.Images.Skip(0).Take(5);
            this.DataBind();

            // TODO: For cover maybe?
            //this.ImagUrlLabel.Text = image.OriginalName;
            //this.ImageContainer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image.Content);
        }
    }
}