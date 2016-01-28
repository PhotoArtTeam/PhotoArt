using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoArt.Web.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string CoverUrlPath { get; set; }

        public int Albums { get; set; }
    }
}