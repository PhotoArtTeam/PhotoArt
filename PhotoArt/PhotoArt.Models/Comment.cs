namespace PhotoArt.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Comment : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string Content { get; set; }
    }
}
