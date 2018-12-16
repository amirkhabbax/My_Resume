using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Amirhossein_Khabbaz.Dtos;
using Amirhossein_Khabbaz.Models;
using AutoMapper;

namespace Amirhossein_Khabbaz.Controllers.Api
{
    public class SkillsController : ApiController
    {
        private ApplicationDbContext _context;

        public SkillsController()
        {
            _context = new ApplicationDbContext();
        }

        //// GET /api/skills/1
        //public IHttpActionResult GetSkill(int id)
        //{
        //    var skill = _context.Skills.SingleOrDefault(s => s.Id == id);
        //    if (skill == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<Skill, SkillDto>(skill));
        //}

        // GET /api/skills
        public IHttpActionResult GetSkills()
        {
            return Ok(_context.Skills.ToList().Select(Mapper.Map<Skill, SkillDto>));
        }

        // GET /api/skills/1
        public IHttpActionResult GetSkillsByPersonId(int personId)
        {
            var skills = _context.Skills.Where(s => s.PersonId == personId).ToList();
            if (skills.Count == 0)
                return NotFound();

                return Ok(skills.Select(Mapper.Map<Skill, SkillDto>));
        }
        // POST /api/skills
        [HttpPost]
        public IHttpActionResult CreateSkill(SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var skill = Mapper.Map<SkillDto, Skill>(skillDto);
            _context.Skills.Add(skill);
            _context.SaveChanges();

            skillDto.Id = skill.Id;

            return Created(new Uri(Request.RequestUri + "/" + skill.Id), skillDto);
        }

        // PUT /api/skills/1
        [HttpPut]
        public IHttpActionResult UpdateSkill(int id, SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var skillInDb = _context.Skills.SingleOrDefault(s => s.Id == id);

            if (skillInDb == null)
                return NotFound();

            Mapper.Map(skillDto, skillInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/skills/1
        [HttpDelete]
        public IHttpActionResult DeleteSkill(int id)
        {
            var skillInDb = _context.Skills.SingleOrDefault(s => s.Id == id);
            if (skillInDb == null)
                return NotFound();

            _context.Skills.Remove(skillInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
