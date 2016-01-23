namespace PhotoArt.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album : AuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;
        private ICollection<Technology> technologies;

        public Album()
        {
            this.images = new HashSet<Image>();
            this.technologies = new HashSet<Technology>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PortfolioId { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Technology> UsedTechnologies
        {
            get { return this.technologies; }
            set { this.technologies = value; }
        }

    }
}
