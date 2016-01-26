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

            var image = this.Data.Albums
                .FirstOrDefault(x => x.Id == id)
                .Images
                .FirstOrDefault();
              

            this.ImagUrlLabel.Text = image.OriginalName;
            this.ImageContainer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image.Content);
        }
    }
}