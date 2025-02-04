﻿using System.ComponentModel.DataAnnotations;

namespace Amirhossein_Khabbaz.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        [Display(Name = "Measure of your Knowledge in scale of 100")]
        public byte CurrentValue { get; set; }

        [Required]
        public int PersonId { get; set; }

    }
}