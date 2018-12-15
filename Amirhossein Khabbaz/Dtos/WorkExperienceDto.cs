using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amirhossein_Khabbaz.Dtos
{
    public class WorkExperienceDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Company { get; set; }

        [Required]
        public byte Years { get; set; }

        [Required]
        [StringLength(255)]
        public string ReasonOfDeparture { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}