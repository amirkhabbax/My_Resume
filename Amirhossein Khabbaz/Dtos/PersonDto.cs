using Amirhossein_Khabbaz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 255)]
        public String Name { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDateTime { get; set; }

        [Required]
        [Range(1, 4)]
        public string CountryPhonePrefix { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Range(1, 100)]
        public String Email { get; set; }

        public List<Skill> Skills { get; set; }

        [Required]
        public List<int> SkillsIds { get; set; }
    }
}