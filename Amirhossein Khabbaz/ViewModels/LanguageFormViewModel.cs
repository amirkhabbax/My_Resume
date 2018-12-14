using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class LanguageFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Language")]
        public string Name { get; set; }

        [Required]
        public byte MaximumValue { get; set; }

        [Required]
        [Display(Name = "Measure of your Knowledge in scale of 5")]
        public byte? CurrentValue { get; set; }

        [Required]
        public int? PersonId { get; set; }

        public LanguageFormViewModel(int personId)
        {
            PersonId = personId;
            Id = 0;
            MaximumValue = 5;
        }

        public LanguageFormViewModel(Language language)
        {
            Id = language.Id;
            PersonId = language.PersonId;
            CurrentValue = language.CurrentValue;
            MaximumValue = 5;
            Name = language.Name;
        }
    }
}