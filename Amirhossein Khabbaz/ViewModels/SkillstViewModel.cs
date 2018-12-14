using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class SkillstViewModel
    {
        public IEnumerable<Skill> Skills { get; set; }
        public int PersonId { get; set; }
    }
}