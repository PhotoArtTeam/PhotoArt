using PhotoArt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Controls
{
    public partial class UserGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<UserViewModel> UsersGrid_GetData(object sender, EventArgs e)
        {
            var db = new PhotoArt.Data.PhotoArtDbContext();
            return db.Users
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    Country = x.Country,
                    Email = x.Email,
                    Albums = x.Portfolio.Albums.Count,
                    CoverUrlPath = x.Portfolio.Albums.FirstOrDefault() != null ?
                    x.Portfolio.Albums.FirstOrDefault().Images.FirstOrDefault() != null ?
                            x.Portfolio.Albums.FirstOrDefault().Images.FirstOrDefault().Url : null
                    : null
                });
        }
    }
}