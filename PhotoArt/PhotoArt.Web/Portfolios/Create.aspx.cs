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
            var currentUser = Context.User.Identity.Name;
            var crUser = this.Data.Users.Where(u => u.UserName == currentUser).FirstOrDefault();

            if (crUser.PortfolioId == null)
            {
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
            }
            else
            {

            }

        }
    }
}