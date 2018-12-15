using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Dtos
{
    public class EducationDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Degree { get; set; }

        [Required]
        [StringLength(255)]
        public string University { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}