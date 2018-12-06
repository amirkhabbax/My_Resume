using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;
using Amirhossein_Khabbaz.ViewModels;

namespace Amirhossein_Khabbaz.Controllers
{
    public class EducationController : Controller
    {
        private ApplicationDbContext _context;

        public EducationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Education
        public ActionResult Index(int personId)
        {
            var educations = _context.Educations.Where(e => e.PersonId == personId).ToList();
            var viewModel = new EducationsViewModel
            {
                Educations = educations,
                PersonId = personId
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var education = _context.Educations.SingleOrDefault(e => e.Id == id);
            if (education == null)
                return HttpNotFound();

            var viewModel = new EducationFormViewModel(education);

            ViewBag.Title = "Edit Degree";
            return View("EducationForm", viewModel);
        }

        public ActionResult New(int personId)
        {
            ViewBag.Title = "New Degree";
            var viewModel = new EducationFormViewModel(personId);
            return View("EducationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Education education)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EducationFormViewModel(education);
                return View("EducationForm", viewModel);
            }

            if (education.Id == 0)
            {
                _context.Educations.Add(education);
            }
            else
            {
                var educationInDb = _context.Educations.Single(e => e.Id == education.Id);

                educationInDb.Degree = education.Degree;
                educationInDb.University = education.University;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Education", new {personId = education.PersonId});
        }
    }
}