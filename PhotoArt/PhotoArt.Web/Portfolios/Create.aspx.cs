using PhotoArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Portfolios
{
    public partial class Create : BasePage
    {
    
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
                }
            }
        }
    }
}