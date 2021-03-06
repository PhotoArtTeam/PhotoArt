﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pendingAlbums = this.Data.Albums.Where(x => x.IsApproved == false).Count();
            PendingAlbums.Text = pendingAlbums.ToString();
        }
    }
}