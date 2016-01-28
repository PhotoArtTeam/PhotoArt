using PhotoArt.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Update : BasePage
    {
        private static int currentAlbumId;
        private static string imageDirectory = "Images/{0}";
        private static string imagePath = "Images/{0}/{1}_{2}.jpg";
        private static ImageResizeService imageResizer = new ImageResizeService();
        private static FileSystemService fileService = new FileSystemService();

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
                currentAlbumId = album.Id;
                this.AlbumName.Text = album.Name;
                this.AlbumDescription.Text = album.Description;
                this.currentAlbum.DataSource = album.Images;
                this.currentAlbum.DataBind();
            }
        }

        protected void UpdateAlbum_Click(object sender, EventArgs e)
        {


            var id = int.Parse(Request.Params["Id"]);

            if (Request.Params["Id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            var album = this.Data.Albums
                .FirstOrDefault(x => x.Id == id);

            if (Page.IsPostBack)
            {
                album.Name = this.AlbumName.Text;
                album.Description = this.AlbumDescription.Text;
                this.Data.SaveChanges();
                currentAlbumId = album.Id;
                this.DataBind();
            }
            Response.Redirect("~/Portfolios/YourPortfolio.aspx");
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
                }
            }
        }
    }
}