using PhotoArt.Models;
using PhotoArt.Services;
using PhotoArt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Portfolios
{
    public partial class YourPortfolio : BasePage
    {
        private static int currentAlbumId;
        private static string imageDirectory = "Images/{0}";
        private static string imagePath = "Images/{0}/{1}_{2}.jpg";
        private static ImageResizeService imageResizer = new ImageResizeService();
        private static FileSystemService fileService = new FileSystemService();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            if (crUser.PortfolioId == null)
            {
                Response.Redirect("~/Portfolios/Create.aspx");
            }
        }

        public IQueryable<AlbumViewModel> AlbumsGrid_GetData(object sender, EventArgs e)
        {

            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            var portfolioId = crUser.PortfolioId;

            var portfolio = this.Data.Portfolios;
                return this.Data.Albums
                    .Where(x => x.PortfolioId == portfolioId)
                    .Select(x => new AlbumViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        CreatedOn = x.CreatedOn,
                        IsApproved = x.IsApproved,
                        // For DB image
                        // CoverImage = "data:image/jpeg;base64," + Convert.ToBase64String(x.Images.FirstOrDefault().Content)
                        CoverUrlPath = x.Images.FirstOrDefault() != null ? x.Images.FirstOrDefault().Url : "" // TODO: Constants - no available image
                    });
        }

        protected void AddAlbum_Click(object sender, EventArgs e)
        {
            this.PanelAlbums.Visible = true;
            this.PanelPorfolio.Visible = false;
        }
        protected void CreateAlbum_Click(object sender, EventArgs e)
        {
            this.PanelImages.Visible = true;
            this.PanelAlbums.Visible = false;
            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            var portfolioId = crUser.PortfolioId;

            if (Page.IsValid)
            {
                var currentAlbum = this.Data.Albums.Add(new Album()
                {
                    Name = this.AlbumName.Text,
                    Description = this.AlbumDescription.Text,
                    PortfolioId = (int)portfolioId
                });

                this.Data.SaveChanges();
                currentAlbumId = currentAlbum.Id;
                this.DataBind();
            }
            else
            {

            }

        }

        protected void AddImages_Click(object sender, EventArgs e)
        {
            if (fileuploadControl.HasFile)
            {
                foreach (var image in fileuploadControl.PostedFiles)
                {
                    var currentImage = image;
                    Stream img_strm = currentImage.InputStream;
                    int albumID = currentAlbumId;
                    int img_len = currentImage.ContentLength;
                    string strtype = currentImage.ContentType.ToString();
                    string strname = currentImage.FileName;
                    byte[] imgdata = new byte[img_len];
                    int n = img_strm.Read(imgdata, 0, img_len);
                    string imageExtension = strname.Substring(strname.LastIndexOf(".") + 1);


                    if (Page.IsValid)
                    {
                        var currentImageUpload = this.Data.Images.Add(new Models.Image
                        {
                            AlbumId = currentAlbumId,
                            Content = imgdata,
                            FileExtension = imageExtension,
                            OriginalName = strname
                        });


                        this.Data.SaveChanges();
                        currentImageUpload.Url = string.Format(imagePath, currentImageUpload.Id % 1000, currentImageUpload.Id, 200);
                        this.Data.SaveChanges();
                        this.DataBind();

                        // TODO: Constants for image sizes we need
                        var task = imageResizer.Resize(imgdata, 200);
                        fileService.Save(task, currentImageUpload.Url);
                    }
                    else
                    {

                    }
                }
                Response.Redirect("~/Portfolios/YourPortfolio.aspx");
            }
        }
    }
}