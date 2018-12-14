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
    public class PersonsController : ApiController
    {
        private ApplicationDbContext _context;

        public PersonsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/persons/1
        public IHttpActionResult GetPerson(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Person,PersonDto>(person));
        }
        // GET /api/persons
        public IHttpActionResult GetPersons()
        {
            return Ok(_context.Persons.ToList().Select(Mapper.Map<Person, PersonDto>));
        }
        // POST /api/persons
        [HttpPost]
        public IHttpActionResult CreatePerson(PersonDto personDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var person = Mapper.Map<PersonDto, Person>(personDto);
            _context.Persons.Add(person);
            _context.SaveChanges();

            personDto.Id = person.Id;

            return Created(new Uri(Request.RequestUri + "/" + person.Id), personDto);
        }

        // PUT /api/persons/1
        [HttpPut]
        public IHttpActionResult UpdatePerson(int id, PersonDto personDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var personInDb = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (personInDb == null)
                return NotFound();

            Mapper.Map(personDto, personInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE/api/persons/1
        [HttpDelete]
        public IHttpActionResult DeletePerson(int id)
        {
            var personInDb = _context.Persons.SingleOrDefault(p => p.Id == id);
            if (personInDb == null)
                return NotFound();

            _context.Persons.Remove(personInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
