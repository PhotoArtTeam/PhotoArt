using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoArt.Models
{
    public enum TechnologyTypeEnum 
    {
        None = 1,
        Photoshop = 2,
        FinalCut = 3,
        StudioPhotography = 4,
        MotionVideo = 5
    }

    [Table("TechnologyTypes")]
    public class TechnologyType : EnumBase<TechnologyTypeEnum>
    {
    }
}
