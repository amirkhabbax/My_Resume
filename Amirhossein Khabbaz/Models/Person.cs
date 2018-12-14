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
<<<<<<< HEAD
        public string LinkedIn { get; set; }
=======
        public string Linkedin { get; set; }
>>>>>>> 33c1f823eabe2ea1251ace2a63e74304d0bd8b53

        [StringLength(255)]
        [Display(Name = "github")]
        public string Github { get; set; }

        [StringLength(255)]
        [Display(Name = "gitlab")]
        public string Gitlab { get; set; }

        [StringLength(255)]
<<<<<<< HEAD
        [Display(Name = "twitter")]
        public string Twitter { get; set; }

        [StringLength(255)]
        [Display(Name = "facebook")]
=======
        public string Twitter { get; set; }

        [StringLength(255)]
>>>>>>> 33c1f823eabe2ea1251ace2a63e74304d0bd8b53
        public string Facebook { get; set; }

    }
}