using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class EducationFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Degree { get; set; }

        [Required]
        [StringLength(255)]
        public string University { get; set; }

        [Required]
        public int? PersonId { get; set; }

        public EducationFormViewModel(int personId)
        {
            Id = 0;
            PersonId = personId;
        }

        public EducationFormViewModel(Education education)
        {
            Id = education.Id;
            PersonId = education.PersonId;
            University = education.University;
            Degree = education.Degree;
        }
    }
}