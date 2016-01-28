using PhotoArt.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Details : BasePage
    {
        private const int MAX_CAROUSEL_COLLECTION_COUNT = 5;
        private const string CAROUSEL_OFFSET = "CarouselOffset";
        private const string PENDING_ALBUMS_URL = "~/Admin/Albums/Pending.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: For cover maybe?
            //this.ImagUrlLabel.Text = image.OriginalName;
            //this.ImageContainer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image.Content);
        }
             
    }
}