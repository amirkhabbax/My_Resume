using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class InterestFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Interest")]
        public string Name { get; set; }

        [Required]
        public int? PersonId { get; set; }

        public InterestFormViewModel(int personId)
        {
            PersonId = personId;
            Id = 0;
        }

        public InterestFormViewModel(Interests interests)
        {
            PersonId = interests.PersonId;
            Id = interests.Id;
            Name = interests.Name;
        }
    }
}