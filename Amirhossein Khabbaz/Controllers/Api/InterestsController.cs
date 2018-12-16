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
    public class InterestsController : ApiController
    {
        private ApplicationDbContext _context;

        public InterestsController()
        {
            _context = new ApplicationDbContext();
        }

        //// GET /api/interests/1
        //public IHttpActionResult GetInterest(int id)
        //{
        //    var interest = _context.Interests.SingleOrDefault(i => i.Id == id);
        //    if (interest == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<Interests, InterestDto>(interest));
        //}

        // GET /api/interests/1
        public IHttpActionResult GetInterestsByPersonId(int personId)
        {
            var interests = _context.Interests.Where(i => i.PersonId == personId).ToList();
            if (interests.Count == 0)
                return NotFound();

            return Ok(interests.Select(Mapper.Map<Interests, InterestDto>));
        }

        // GET /api/interests
        public IHttpActionResult GetInterests()
        {
            return Ok(_context.Interests.ToList().Select(Mapper.Map<Interests, InterestDto>));
        }

        // POST /api/interests
        [HttpPost]
        public IHttpActionResult CreateInterest(InterestDto interestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var interest = Mapper.Map<InterestDto, Interests>(interestDto);
            _context.Interests.Add(interest);
            _context.SaveChanges();

            interestDto.Id = interest.Id;

            return Created(new Uri(Request.RequestUri + "/" + interest.Id), interestDto);
        }

        // PUT /api/interests/1
        [HttpPut]
        public IHttpActionResult UpdateInterest(int id, InterestDto interestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var interestInDb = _context.Interests.SingleOrDefault(i => i.Id == id);

            if (interestInDb == null)
                return NotFound();

            Mapper.Map(interestDto, interestInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/interests/1
        [HttpDelete]
        public IHttpActionResult DeleteInterest(int id)
        {
            var interestInDb = _context.Interests.SingleOrDefault(i => i.Id == id);
            if (interestInDb == null)
                return NotFound();

            _context.Interests.Remove(interestInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
