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
    public class WorkExperiencesController : ApiController
    {
        private ApplicationDbContext _context;

        public WorkExperiencesController()
        {
            _context = new ApplicationDbContext();
        }

        //// GET /api/workExperiences/1
        //public IHttpActionResult GetWorkExperience(int id)
        //{
        //    var workExperience = _context.WorkExperiences.SingleOrDefault(w => w.Id == id);
        //    if (workExperience == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<WorkExperience, WorkExperienceDto>(workExperience));
        //}

        // GET /api/workExperiences/1
        public IHttpActionResult GetWorkExperiencesByPersonId(int personId)
        {
            var workExperiences = _context.WorkExperiences.Where(w => w.PersonId == personId).ToList();
            if (workExperiences.Count == 0)
                return NotFound();

            return Ok(workExperiences.Select(Mapper.Map<WorkExperience, WorkExperienceDto>));
        }

        // GET /api/workExperiences
        public IHttpActionResult GetWorkExperiences()
        {
            return Ok(_context.WorkExperiences.ToList().Select(Mapper.Map<WorkExperience, WorkExperienceDto>));
        }

        // POST /api/workExperiences
        [HttpPost]
        public IHttpActionResult CreateWorkExperience(WorkExperienceDto workExperienceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workExperience = Mapper.Map<WorkExperienceDto, WorkExperience>(workExperienceDto);
            _context.WorkExperiences.Add(workExperience);
            _context.SaveChanges();

            workExperienceDto.Id = workExperience.Id;

            return Created(new Uri(Request.RequestUri + "/" + workExperience.Id), workExperienceDto);
        }

        // PUT /api/workExperiences/1
        [HttpPut]
        public IHttpActionResult UpdateWorkExperience(int id, WorkExperienceDto workExperienceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workExperienceInDb = _context.WorkExperiences.SingleOrDefault(w => w.Id == id);

            if (workExperienceInDb == null)
                return NotFound();

            Mapper.Map(workExperienceDto, workExperienceInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/workExperiences/1
        [HttpDelete]
        public IHttpActionResult DeleteWorkExperience(int id)
        {
            var workExperienceInDb = _context.WorkExperiences.SingleOrDefault(w => w.Id == id);
            if (workExperienceInDb == null)
                return NotFound();

            _context.WorkExperiences.Remove(workExperienceInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
