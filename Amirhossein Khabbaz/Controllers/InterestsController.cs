using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;
using Amirhossein_Khabbaz.ViewModels;

namespace Amirhossein_Khabbaz.Controllers
{
    public class InterestsController : Controller
    {
        private ApplicationDbContext _context;

        public InterestsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Interests
        public ActionResult Index(int personId)
        {
            var interests = _context.Interests.Where( i => i.PersonId == personId).ToList();
            var viewModel = new InterestViewModel
            {
                Interests = interests,
                PersonId = personId
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var interest = _context.Interests.SingleOrDefault(i => i.Id == id );
            if (interest == null)
                return HttpNotFound();

            var viewModel = new InterestFormViewModel(interest);

            ViewBag.Title = "Edit Interest";
            return View("InterestForm", viewModel);
        }

        public ActionResult New(int personId)
        {
            ViewBag.Title = "New Interest";
            var viewModel = new InterestFormViewModel(personId);
            return View("InterestForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Interests interest)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InterestFormViewModel(interest);
                return View("InterestForm",viewModel);
            }

            if (interest.Id == 0)
            {
                _context.Interests.Add(interest);
            }
            else
            {
                var interestInDb = _context.Interests.Single(i => i.Id == interest.Id);

                interestInDb.Name = interest.Name;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Interests" ,  new {personId = interest.PersonId});
        }
    }
}