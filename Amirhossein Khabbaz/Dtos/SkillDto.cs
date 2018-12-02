using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Dtos
{
    public class SkillDto
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 255)]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        public byte CurrentValue { get; set; }
    }
}