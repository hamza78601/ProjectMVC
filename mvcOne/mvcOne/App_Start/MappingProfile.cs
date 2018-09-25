using AutoMapper;
using mvcOne.Dtos;
using mvcOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcOne.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Customers Mapping Profile
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            //Movies Mapping Profile
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<MovieType, MovieTypeDto>();
            Mapper.CreateMap<MovieTypeDto, MovieType>();
        }
    }
}