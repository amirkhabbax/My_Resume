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
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime BirthDateTime { get; set; }

        [Required]
        [StringLength(5)]
        public string CountryPhonePrefix { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string LinkedIn { get; set; }

        [StringLength(255)]
        public string Github { get; set; }

        [StringLength(255)]
        public string Gitlab { get; set; }

        [StringLength(255)]
        public string Twitter { get; set; }

        [StringLength(255)]
        public string Facebook { get; set; }
    }
}