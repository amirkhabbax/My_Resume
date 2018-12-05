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
        public String Name { get; set; }

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
        public String Email { get; set; }

        [StringLength(255)]
        [Display(Name = "linkedin")]
        public String LinkediN { get; set; }

        [StringLength(255)]
        [Display(Name = "github")]
        public String Github { get; set; }

        [StringLength(255)]
        [Display(Name = "gitlab")]
        public String Gitlab { get; set; }

        [StringLength(255)]
        public String twitter { get; set; }

        [StringLength(255)]
        public String facebook { get; set; }

    }
}