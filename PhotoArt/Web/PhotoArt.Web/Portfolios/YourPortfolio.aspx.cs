using PhotoArt.Models;
using PhotoArt.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            var portfolioId = crUser.PortfolioId;

            var portfolio = this.Data.Portfolios
                .Where(x => x.Id == portfolioId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    Albums = x.Albums
                    .Select(a => new
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        CreatedOn = a.CreatedOn
                    })
                })
                .FirstOrDefault();

            if (!Page.IsPostBack)
            {
                this.GridAlbums.DataSource = portfolio.Albums;
                this.GridAlbums.DataBind();
            }
        }

        protected void GridAlbums_PageIndexChanging(object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            var portfolioId = crUser.PortfolioId;

            var portfolio = this.Data.Portfolios
                .Where(x => x.Id == portfolioId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    Albums = x.Albums
                    .Select(a => new
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        CreatedOn = a.CreatedOn
                    })
                })
                .FirstOrDefault();

            this.GridAlbums.PageIndex = e.NewPageIndex;
            this.GridAlbums.DataSource = portfolio.Albums;
            this.GridAlbums.DataBind();
        }

        protected void GridAlbums_RowDataBound(object sender,
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
                    this.GridAlbums, "Select$" + e.Row.RowIndex);
            }
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
                        int imageSize = Convert.ToInt32(ConfigurationManager.AppSettings["imageSize"]);
                        int folderDistributor = Convert.ToInt32(ConfigurationManager.AppSettings["folderDistributor"]);

                        var currentImageUpload = this.Data.Images.Add(new Models.Image
                        {
                            AlbumId = currentAlbumId,
                            Content = imgdata,
                            FileExtension = imageExtension,
                            OriginalName = strname
                        });


                        this.Data.SaveChanges();
                        currentImageUpload.Url = string.Format(imagePath, currentImageUpload.Id % folderDistributor, currentImageUpload.Id, imageSize);
                        this.Data.SaveChanges();
                        this.DataBind();

                        // TODO: Constants for image sizes we need
                        var task = imageResizer.Resize(imgdata, imageSize);
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