using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class SkillFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte? MaximumValue { get; set; }

        [Required]
        [Display(Name = "Measure of your Knowledge in scale of 100")]
        public byte? CurrentValue { get; set; }

        [Required]
        public int? PersonId { get; set; }

        public SkillFormViewModel(int personId)
        {
            Id = 0;
            PersonId = personId;
            MaximumValue = 100;
        }

        public SkillFormViewModel(Skill skill)
        {
            MaximumValue = 100;
            Id = skill.Id;
            PersonId = skill.PersonId;
            CurrentValue = skill.CurrentValue;
            Name = skill.Name;
        }
    }
}