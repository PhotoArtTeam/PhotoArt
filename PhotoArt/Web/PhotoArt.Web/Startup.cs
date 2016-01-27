using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoArt.Web.Startup))]
namespace PhotoArt.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
