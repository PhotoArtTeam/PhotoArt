using PhotoArt.Models;
using PhotoArt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Pending : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        public IQueryable<AlbumViewModel> PendingAlbumsGrid_GetData(object sender, EventArgs e)
        {
            return this.Data.Albums
                    .Where(x => !x.IsApproved)
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
    }
}