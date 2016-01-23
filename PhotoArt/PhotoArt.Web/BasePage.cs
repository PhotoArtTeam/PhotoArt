namespace PhotoArt.Web
{
    using Data;
    using System.Web.UI;

    public abstract class BasePage : Page
    {
        private readonly PhotoArtDbContext data;

        public BasePage()
        {
            this.data = new PhotoArtDbContext();
        }

        protected PhotoArtDbContext Data
        {
            get { return this.data; }
        }
    }
}