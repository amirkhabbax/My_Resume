using System.ComponentModel.DataAnnotations;

namespace Amirhossein_Khabbaz.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [Range(1,255)]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        public byte CurrentValue { get; set; }
    }
}