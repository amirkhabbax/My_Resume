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
                
            return View("PersonForm",person);
        }

        public ActionResult New()
        {
            return View("PersonForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Person person)
        {
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
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Persons");
        }
    }
}