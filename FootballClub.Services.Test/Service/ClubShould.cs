using AutoMapper;
using FluentAssertions;
using FootballClub.Models.Models.Club;
using FootballClub.Models.Profiles;
using FootballClub.Services.Implementations;
using FootballClub.Services.Test.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballClub.Services.Test.Service
{
    public class ClubShould  : SqlLiteContext
    {
        private readonly IMapper _mapper;
        private readonly ClubService _service;
        public ClubShould() : base(true)
        {
            if (_mapper == null)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(ClubProfile));
                }).CreateMapper();
                _mapper = mapper;
            }
            _service = new ClubService(DbContext, _mapper);
        }
        [Fact]
        public async Task GetClubById()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.GetById(expected);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ClubExtendedModel>();
            result.Id.Should().Be(expected);
        }
        [Fact]
        public async Task InsertNewClub()
        {
            // Arrange
            var club = new ClubCreateModel
            {
                Name = "Anthony's Club",
                Owner = "Anthony",
                City = "Bitola",
                Country = "Macedonia",
            };

            // Act
            var result = await _service.Insert(club);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ClubBaseModel>();
            result.Id.Should().NotBe(0);
        }
        [Fact]
        public async Task DeleteClub()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.Delete(expected);
            var club = await _service.GetById(expected);

            // Assert
            result.Should().Be(true);
            club.Should().BeNull();
        }
    }
}
