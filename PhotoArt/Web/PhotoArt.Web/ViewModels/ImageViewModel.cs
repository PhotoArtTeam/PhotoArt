using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoArt.Web.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string OriginalName { get; set; }

        public string Url { get; set; }

    }
}