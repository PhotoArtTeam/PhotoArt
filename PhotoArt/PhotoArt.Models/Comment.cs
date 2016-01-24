namespace PhotoArt.Models
{
    using Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string Content { get; set; }
    }
}
