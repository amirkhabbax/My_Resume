using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Language")]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        [Display(Name = "Measure of your Knowledge in scale of 5")]
        public byte CurrentValue { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}