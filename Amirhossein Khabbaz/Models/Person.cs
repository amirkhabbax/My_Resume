using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDateTime { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Country Phone Prefix")]
        public string CountryPhonePrefix { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        [Display(Name = "linkedin")]
        public string Linkedin { get; set; }

        [StringLength(255)]
        [Display(Name = "github")]
        public string Github { get; set; }

        [StringLength(255)]
        [Display(Name = "gitlab")]
        public string Gitlab { get; set; }

        [StringLength(255)]
        public string Twitter { get; set; }

        [StringLength(255)]
        public string Facebook { get; set; }

    }
}