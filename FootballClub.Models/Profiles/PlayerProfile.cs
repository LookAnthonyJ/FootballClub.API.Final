using AutoMapper;
using FootballClub.Data.Entities;
using FootballClub.Models.Models.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Models.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerBaseModel>().ReverseMap();
            CreateMap<Player, PlayerExtendedModel>().ReverseMap();

            CreateMap<PlayerCreateModel, Player>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Club, opt => opt.Ignore());
            CreateMap<PlayerUpdateModel, Player>()
                .ForMember(dest => dest.Club, opt => opt.Ignore());
        }
    }
}
