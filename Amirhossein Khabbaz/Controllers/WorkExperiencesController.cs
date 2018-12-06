using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;
using Amirhossein_Khabbaz.ViewModels;

namespace Amirhossein_Khabbaz.Controllers
{
    public class WorkExperiencesController : Controller
    {
        private ApplicationDbContext _context;

        public WorkExperiencesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: WorkExperiences
        public ActionResult Index(int personId)
        {
            var workExperiences = _context.WorkExperiences.Where(w => w.PersonId == personId).ToList();
            var viewModel = new WorkExperiencesViewModel
            {
                WorkExperiences = workExperiences,
                PersonId = personId
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var workExperience = _context.WorkExperiences.SingleOrDefault(w => w.Id == id);
            if (workExperience == null)
                return HttpNotFound();

            var viewModel = new WorkExperiencesFormViewModel(workExperience);

            ViewBag.Title = "Edit work experience";
            return View("WorkExperiencesForm", viewModel);
        }

        public ActionResult New(int personId)
        {
            ViewBag.Title = "New work experience";
            var viewModel = new WorkExperiencesFormViewModel(personId);
            return View("WorkExperiencesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                var  viewModel = new WorkExperiencesFormViewModel(workExperience);
                return View("WorkExperiencesForm",viewModel);
            }

            if (workExperience.Id == 0)
            {
                _context.WorkExperiences.Add(workExperience);
            }
            else
            {
                var workExperienceInDb = _context.WorkExperiences.Single(w => w.Id == workExperience.Id);

                workExperienceInDb.Company = workExperience.Company;
                workExperienceInDb.Years = workExperience.Years;
                workExperienceInDb.ReasonOfDeparture = workExperience.ReasonOfDeparture;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "WorkExperiences", new { personId = workExperience.PersonId });
        }
    }
}