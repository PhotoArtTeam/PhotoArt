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
            if (Session[CAROUSEL_OFFSET] == null)
            {
                Session[CAROUSEL_OFFSET] = 0;
            }

            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            var id = int.Parse(Request.Params["Id"]);
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
            if (album == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            // TODO: check for null
            var cover = this.Data.Albums
                .Where(x => x.Id == id)
                .Select(x => x.Images
                .FirstOrDefault())
                .FirstOrDefault();

            if (cover != null)
            {
                this.CoverImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(cover.Content);
            }

            this.Carousel.DataSource = album.Images.Skip(0).Take(5);
            this.DataBind();

            // TODO: For cover maybe?
            //this.ImagUrlLabel.Text = image.OriginalName;
            //this.ImageContainer.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(image.Content);
        }

        protected void Carousel_Prev(object sender, EventArgs e)
        {
            Session[CAROUSEL_OFFSET] = (int)Session[CAROUSEL_OFFSET] - 1;

            var id = int.Parse(Request.Params["Id"]);
            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            GetImageCollection(id);
        }

        protected void Carousel_Next(object sender, EventArgs e)
        {
            // TODO: max offset???
            Session[CAROUSEL_OFFSET] = (int)Session[CAROUSEL_OFFSET] + 1;

            var id = int.Parse(Request.Params["Id"]);
            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }
            GetImageCollection(id);
        }

        private void GetImageCollection(int id)
        {
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

            int skip = (int)Session[CAROUSEL_OFFSET];
            // TODO: check for null
            var cover = this.Data.Albums
                .Where(x => x.Id == id)
                .Select(x => x.Images
                .FirstOrDefault())
                .FirstOrDefault();
            this.CoverImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(cover.Content);
            this.Carousel.DataSource = album.Images.Skip(skip).Take(MAX_CAROUSEL_COLLECTION_COUNT);
            this.DataBind();
        }

        protected void Carousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Models.Image;
            if(item != null)
            {
                e.Item.ID = item.Id.ToString();
            }
        }

        protected void Carousel_Selected(int id)
        {

            var imageContent = this.Data.Images.Where(x => x.Id == id).Select(x => x.Content).FirstOrDefault();

            this.CoverImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageContent);
        }
    }
}