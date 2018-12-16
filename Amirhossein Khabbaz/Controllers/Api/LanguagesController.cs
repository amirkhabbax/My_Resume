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
    public class LanguagesController : ApiController
    {
        private ApplicationDbContext _context;

        public LanguagesController()
        {
            _context = new ApplicationDbContext();
        }

        //// GET /api/languages/1
        //public IHttpActionResult GetLanguage(int id)
        //{
        //    var language = _context.Languages.SingleOrDefault(l => l.Id == id);
        //    if (language == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<Language, LanguageDto>(language));
        //}

        // GET /api/languages/1
        public IHttpActionResult GetLanguagesByPersonId(int personId)
        {
            var languages = _context.Languages.Where(l => l.PersonId == personId).ToList();
            if (languages.Count == 0)
                return NotFound();

            return Ok(languages.Select(Mapper.Map<Language, LanguageDto>));
        }

        // GET /api/languages
        public IHttpActionResult GetLanguages()
        {
            return Ok(_context.Languages.ToList().Select(Mapper.Map<Language, LanguageDto>));
        }

        // POST /api/languages
        [HttpPost]
        public IHttpActionResult CreateLanguage(LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var language = Mapper.Map<LanguageDto, Language>(languageDto);
            _context.Languages.Add(language);
            _context.SaveChanges();

            languageDto.Id = language.Id;

            return Created(new Uri(Request.RequestUri + "/" + language.Id), languageDto);
        }

        // PUT /api/languages/1
        [HttpPut]
        public IHttpActionResult UpdateLanguage(int id, LanguageDto languageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var languageInDb = _context.Languages.SingleOrDefault(l => l.Id == id);

            if (languageInDb == null)
                return NotFound();

            Mapper.Map(languageDto, languageInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/languages/1
        [HttpDelete]
        public IHttpActionResult DeleteLanguage(int id)
        {
            var languageInDb = _context.Languages.SingleOrDefault(l => l.Id == id);
            if (languageInDb == null)
                return NotFound();

            _context.Languages.Remove(languageInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
