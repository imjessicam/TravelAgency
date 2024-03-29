﻿using AutoMapper;
using DTO.Models.Skipper;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class SkipperProfile : Profile
    {
        public SkipperProfile()
        {
            // Defining of mapping
            CreateMap<Skipper, SkipperDetails>();

            // Create
            CreateMap<CreateSkipperModel, Skipper>();

            // Update
            CreateMap<UpdateSkipperModel, Skipper>();
        }
    }
}
