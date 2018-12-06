using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.ViewModels
{
    public class LanguagesViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public int PersonId { get; set; }
    }
}