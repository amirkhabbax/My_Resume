using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class WorkExperiencesFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Company you worked with")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Number of the years you cooperated with")]
        public byte? Years { get; set; }

        [Required]
        [Display(Name = "Reason of departure")]
        [StringLength(255)]
        public string ReasonOfDeparture { get; set; }

        [Required]
        public int? PersonId { get; set; }

        public WorkExperiencesFormViewModel(int personId)
        {
            Id = 0;
            PersonId = personId;
        }

        public WorkExperiencesFormViewModel(WorkExperience workExperience)
        {
            Id = workExperience.Id;
            PersonId = workExperience.PersonId;
            ReasonOfDeparture = workExperience.ReasonOfDeparture;
            Years = workExperience.Years;
            Company = workExperience.Company;
        }
    }
}