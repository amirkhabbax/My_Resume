using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amirhossein_Khabbaz.Dtos;
using Amirhossein_Khabbaz.Models;
using AutoMapper;

namespace Amirhossein_Khabbaz.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Person, PersonDto>();
            Mapper.CreateMap<PersonDto, Person>();
        }

    }
}