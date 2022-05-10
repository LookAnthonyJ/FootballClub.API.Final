using AutoMapper;
using FootballClub.Data.Entities;
using FootballClub.Models.Models.Club;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Models.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubBaseModel>().ReverseMap();
            CreateMap<Club, ClubExtendedModel>().ReverseMap();

            CreateMap<ClubCreateModel, Club>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Players, opt => opt.Ignore());

            CreateMap<ClubUpdateModel, Club>()
                .ForMember(dest => dest.Players, opt => opt.Ignore());
        }
    }
}
