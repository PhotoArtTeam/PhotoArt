using PhotoArt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Portfolios
{
    public partial class Create : BasePage
    {
        private static int currentAlbumId;
    
        protected void CreatePortfolio_Click(object sender, EventArgs e)
        {
            this.PanelAlbums.Visible = true;
            this.PanelPorfolio.Visible = false;
            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            //if (crUser.PortfolioId == null)
            // {
            if (Page.IsValid)
            {
                var currentPortfolio = this.Data.Portfolios.Add(new Portfolio()
                {
                    Name = this.Name.Text
                });
                crUser.PortfolioId = currentPortfolio.Id;
                
                this.Data.SaveChanges();
                this.DataBind();
            }
            else
            {

            }
            // }
            //else
            //{

            // }
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
                currentAlbumId = currentAlbum.Id;
                this.Data.SaveChanges();
                this.DataBind();
            }
            else
            {

            }

        }

        protected void AddImages_Click(object sender, EventArgs e)
        {
            if (ImagesUploadControl.HasFile)
            {
                foreach (var image in ImagesUploadControl.PostedFiles)
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
                        var currentImageUpload = this.Data.Images.Add(new Models.Image()
                        {
                            AlbumId = currentAlbumId,
                            Content = imgdata,
                            FileExtension = imageExtension,
                            OriginalName = strname
                        });
                        this.Data.SaveChanges();
                        this.DataBind();
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}