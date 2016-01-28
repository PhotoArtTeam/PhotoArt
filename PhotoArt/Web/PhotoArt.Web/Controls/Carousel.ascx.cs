using PhotoArt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Controls
{
    public partial class Carousel : System.Web.UI.UserControl
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
             var db = new PhotoArt.Data.PhotoArtDbContext();
             var id = int.Parse(Request.Params["Id"]);
            // var album = db.Albums
            //     .Where(x => x.Id == id)
            //     .Select(x => new
            //     {
            //         x.Id,
            //         x.Name,
            //         x.Description,
            //         Images = x.Images
            //         .Select(i => new
            //         {
            //             Id = i.Id,
            //             Url = i.Url
            //         })
            //     })
            //     .FirstOrDefault();
            // if (album == null)
            // {
            //     Response.Redirect(PENDING_ALBUMS_URL);
            // }

            // // TODO: check for null
            var cover = db.Albums
                .Where(x => x.Id == id)
                .Select(x => x.Images
                .FirstOrDefault())
                .FirstOrDefault();

            if (cover != null)
            {
                this.CoverImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(cover.Content);
            }

            //// this.Carousel.DataSource = album.Images.Skip(0).Take(5);
            // this.DataBind();

        }

        //protected void Carousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    var item = e.Item.DataItem as Models.Image;
        //    if (item != null)
        //    {
        //        e.Item.ID = item.Id.ToString();
        //    }
        //}

        public IQueryable<ImageViewModel> GetImages()
        {
            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            var id = int.Parse(Request.Params["Id"]);
            var skip = (int)Session[CAROUSEL_OFFSET];
            var db = new PhotoArt.Data.PhotoArtDbContext();
            return db.Images
                .Where(x => x.AlbumId == id)
                .Select(x => new ImageViewModel
                {
                    Id = x.Id,
                    Url = x.Url
                })
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(5);

        }

        protected void Carousel_Prev(object sender, EventArgs e)
        {
            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            Session[CAROUSEL_OFFSET] = (int)Session[CAROUSEL_OFFSET] - 1;
            if ((int)Session[CAROUSEL_OFFSET] < 0)
            {
                Session[CAROUSEL_OFFSET] = 0;
            }

            var id = int.Parse(Request.Params["Id"]);
            this.DataBind();
        }

        protected void Carousel_Next(object sender, EventArgs e)
        {
            // TODO: max offset???
            Session[CAROUSEL_OFFSET] = (int)Session[CAROUSEL_OFFSET] + 1;

            if (Request.Params["Id"] == null)
            {
                Response.Redirect(PENDING_ALBUMS_URL);
            }

            var id = int.Parse(Request.Params["Id"]);
            this.DataBind();
        }

        protected void Carousel_Selected(object sender, EventArgs e)
        {

            //TODO: Cry baby, cry (its easier than learning web forms for a week)

            var selectedImage = sender as Image;
            this.CoverImage.ImageUrl = selectedImage.ImageUrl;
          //  var imageContent = db.Images.Where(x => x.Id == id).Select(x => x.Content).FirstOrDefault();

            // this.CoverImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageContent);
        }
    }
}