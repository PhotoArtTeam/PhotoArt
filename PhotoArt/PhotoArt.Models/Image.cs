namespace PhotoArt.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Contracts;
    using System.Collections.Generic;

    public class Image : AuditInfo, IDeletableEntity
    {
        private ICollection<Comment> comments;

        public Image()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category {get;set;}

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
        
        public string OriginalName { get; set; }

        public string Url { get; set; }

        public string FileExtension { get; set; }

        public byte[] Content { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
