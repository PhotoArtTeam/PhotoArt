﻿namespace PhotoArt.Models
{
    using System;

    using PhotoArt.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Portfolio : IDeletableEntity
    {
        private ICollection<Album> albums;

        public Portfolio()
        {
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
