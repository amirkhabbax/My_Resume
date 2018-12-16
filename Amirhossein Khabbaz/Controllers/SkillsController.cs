using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amirhossein_Khabbaz.Models;
using Amirhossein_Khabbaz.ViewModels;

namespace Amirhossein_Khabbaz.Controllers
{
    public class SkillsController : Controller
    {
        private ApplicationDbContext _context;

        public SkillsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Skills
        public ActionResult Index(int id)
        {
            var skills = _context.Skills.Where(s => s.PersonId == id).ToList();
            var viewModel = new SkillstViewModel
            {
                Skills = skills,
                PersonId = id
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.Id == id);
            if (skill == null)
                return HttpNotFound();

            var viewModel = new SkillFormViewModel(skill);

            ViewBag.Title = "Edit Skill";
            return View("SkillForm", viewModel);
        }

        public ActionResult New(int personId)
        {
            ViewBag.Title = "New Skill";
            var viewModel = new SkillFormViewModel(personId);
            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SkillFormViewModel(skill);
                return View("SkillForm",viewModel);
            }

            if (skill.Id == 0)
            {
                _context.Skills.Add(skill);
            }
            else
            {
                var skillInDb = _context.Skills.Single(s => s.Id == skill.Id);

                skillInDb.Name = skill.Name;
                skillInDb.CurrentValue = skill.CurrentValue;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Skills", new{id = skill.PersonId});
        }
    }
}