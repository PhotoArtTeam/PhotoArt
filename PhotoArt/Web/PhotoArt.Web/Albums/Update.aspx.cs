using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoArt.Web.Admin.Albums
{
    public partial class Update : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(Request.Params["Id"]);


        }
    }
}