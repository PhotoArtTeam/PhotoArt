using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoArt.Web.ViewModels
{
    public class AlbumViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CoverUrlPath { get; set; }

        public bool IsApproved { get; set; }

        public int PortfolioId { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }
    }
}