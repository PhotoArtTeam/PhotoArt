namespace PhotoArt.Models
{
    using System;
    using PhotoArt.Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    using System.Collections.Generic;

    public class Category : IDeletableEntity
    {
        private ICollection<Image> images;

        public Category()
        {
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

    }
}
