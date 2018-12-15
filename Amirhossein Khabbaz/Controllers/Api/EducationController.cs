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
    public class EducationController : ApiController
    {
        private ApplicationDbContext _context;

        public EducationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/education/1
        public IHttpActionResult GetEducation(int id)
        {
            var education = _context.Educations.SingleOrDefault(e => e.Id == id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Education, EducationDto>(education));
        }

        // GET /api/education
        public IHttpActionResult GetEducations()
        {
            return Ok(_context.Educations.ToList().Select(Mapper.Map<Education, EducationDto>));
        }

        // POST /api/education
        [HttpPost]
        public IHttpActionResult CreateEducation(EducationDto educationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var education = Mapper.Map<EducationDto, Education>(educationDto);
            _context.Educations.Add(education);
            _context.SaveChanges();

            educationDto.Id = education.Id;

            return Created(new Uri(Request.RequestUri + "/" + education.Id), educationDto);
        }

        // PUT /api/education/1
        [HttpPut]
        public IHttpActionResult UpdateEducation(int id, EducationDto educationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var educationInDb = _context.Educations.SingleOrDefault(e => e.Id == id);

            if (educationInDb == null)
                return NotFound();

            Mapper.Map(educationDto, educationInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/education/1
        [HttpDelete]
        public IHttpActionResult DeleteEducation(int id)
        {
            var educationInDb = _context.Educations.SingleOrDefault(e => e.Id == id);
            if (educationInDb == null)
                return NotFound();

            _context.Educations.Remove(educationInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
