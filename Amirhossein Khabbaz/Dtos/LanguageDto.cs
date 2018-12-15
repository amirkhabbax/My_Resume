using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Dtos
{
    public class LanguageDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        public byte CurrentValue { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}