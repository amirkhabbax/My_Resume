using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class WorkExperiencesViewModel
    {
        public IEnumerable<WorkExperience> WorkExperiences { get; set; }
        public int PersonId { get; set; }
    }
}