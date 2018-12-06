using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;
using Amirhossein_Khabbaz.ViewModels;

namespace Amirhossein_Khabbaz.Controllers
{
    public class LanguagesController : Controller
    {
        private ApplicationDbContext _context;

        public LanguagesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Languages
        public ActionResult Index(int personId)
        {
            var languages = _context.Languages.Where( l => l.PersonId == personId).ToList();
            var viewModel = new LanguagesViewModel
            {
                Languages = languages,
                PersonId = personId
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var language = _context.Languages.SingleOrDefault(l => l.Id == id);
            if (language == null)
                return HttpNotFound();

            var viewModel = new LanguageFormViewModel(language);

            ViewBag.Title = "Edit language";
            return View("LanguageForm", viewModel);
        }

        public ActionResult New(int personId)
        {
            ViewBag.Title = "New language";
            var viewModel = new LanguageFormViewModel(personId);
            return View("LanguageForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Language language)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LanguageFormViewModel(language);
                
                return View("LanguageForm", viewModel);
            }

            if (language.Id == 0)
            {
                _context.Languages.Add(language);
            }
            else
            {
                var languageInDb = _context.Languages.Single(l => l.Id == language.Id);

                languageInDb.Name = language.Name;
                languageInDb.CurrentValue = language.CurrentValue;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Languages", new{personId = language.PersonId});
        }
    }
}