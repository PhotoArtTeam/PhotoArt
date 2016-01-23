namespace PhotoArt.Models
{
    public class Technology
    {
        public int Id { get; set; }

        public decimal Percentage { get; set; }

        public int TechnologyTypeId { get; set; }

        public virtual TechnologyType TechnologyType { get; set; }
    }
}
