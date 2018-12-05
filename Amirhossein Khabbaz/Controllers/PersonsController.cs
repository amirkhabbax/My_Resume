using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;

namespace Amirhossein_Khabbaz.Controllers
{
    public class PersonsController : Controller
    {

        private ApplicationDbContext _context;

        public PersonsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Persons
        public ActionResult Index()
        {
            var person = _context.Persons.ToList();
            // if (person.Count ==0)
            //  return HttpNotFound();

            return View(person);
        }

        public ActionResult Edit(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            if (person == null)
                return HttpNotFound();

            ViewBag.Title = "Edit Person";
            return View("PersonForm", person);
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Person";
            return View("PersonForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonForm");
            }
            if (person.Id == 0)
                _context.Persons.Add(person);
            else
            {
                var personInDb = _context.Persons.Single(p => p.Id == person.Id);

                personInDb.Name = person.Name;
                personInDb.BirthDateTime = person.BirthDateTime;
                personInDb.Email = person.Email;
                personInDb.CountryPhonePrefix = person.CountryPhonePrefix;
                personInDb.PhoneNumber = person.PhoneNumber;
                personInDb.Github = person.Github;
                personInDb.Gitlab = person.Gitlab;
                personInDb.twitter = person.twitter;
                personInDb.facebook = person.facebook;
                personInDb.LinkediN = person.LinkediN;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Persons");
        }
    }
}