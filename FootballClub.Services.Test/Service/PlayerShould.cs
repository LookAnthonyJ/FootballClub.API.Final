using AutoMapper;
using FluentAssertions;
using FootballClub.Models.Models.Player;
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
    public class PlayerShould : SqlLiteContext
    {
        private readonly IMapper _mapper;
        private readonly PlayerService _service;
        public PlayerShould() : base(true)
        {
            if (_mapper == null)
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(PlayerProfile));
                }).CreateMapper();
                _mapper = mapper;
            }
            _service = new PlayerService(DbContext, _mapper);
        }
        [Fact]
        public async Task GetPlayerById()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.GetById(expected);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<PlayerExtendedModel>();
            result.Id.Should().Be(expected);
        }
        [Fact]
        public async Task InsertNewClub()
        {
            // Arrange
            var player = new PlayerCreateModel
            {
                FirstName = "Anthony",
                LastName = "Juzevski",
                DOB = DateTime.Now.AddYears(-22),
                SigningDate = DateTime.Now,
                Rank = 1,
                TotalGoals = 50,
                ClubId = 2
            };

            // Act
            var result = await _service.Insert(player);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<PlayerBaseModel>();
            result.Id.Should().NotBe(0);
        }
        [Fact]
        public async Task DeletePlayer()
        {
            // Arrange
            var expected = 1;

            // Act
            var result = await _service.Delete(expected);
            var player = await _service.GetById(expected);

            // Assert
            result.Should().Be(true);
            player.Should().BeNull();
        }
    }
}
