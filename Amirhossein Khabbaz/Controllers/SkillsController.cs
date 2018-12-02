using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amirhossein_Khabbaz.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}