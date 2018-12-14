using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Models
{
    public class Interests
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Interest")]
        public string Name { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}