using FootballClub.Data;
using FootballClub.Data.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Services.Test.Internal
{
    public abstract class SqlLiteContext : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        protected readonly FootballClubDbContext DbContext;
        protected DbContextOptions<FootballClubDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<FootballClubDbContext>()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlite(_connection)
                .Options;
        }
        protected SqlLiteContext(bool withData = false)
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            DbContext = new FootballClubDbContext(CreateOptions());
            _connection.Open();
            DbContext.Database.EnsureCreated();
            if (withData)
                SeedData(DbContext);
        }
        private void SeedData(FootballClubDbContext context)
        {
            var playersInClub1 = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 1,
                    TotalGoals = 68,
                    ClubId = 1
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 2,
                    TotalGoals = 66,
                    ClubId = 1
                },
                new Player
                {
                    Id = 3,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 3,
                    TotalGoals = 62,
                    ClubId = 1
                }
            };
            var playersInClub2 = new List<Player>
            {
                new Player
                {
                    Id = 4,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 1,
                    TotalGoals = 68,
                    ClubId = 2
                },
                new Player
                {
                    Id = 5,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 2,
                    TotalGoals = 66,
                    ClubId = 2
                },
                new Player
                {
                    Id = 6,
                    FirstName = "Anthony",
                    LastName = "Juzevski",
                    DOB = DateTime.Now.AddYears(-22),
                    SigningDate = DateTime.Now,
                    Rank = 3,
                    TotalGoals = 62,
                    ClubId = 2
                }
            };
            var clubs = new List<Club>
            {
                new Club
                {
                    Id = 1,
                    Name = "Anthony's Club",
                    Owner = "Anthony",
                    City = "Bitola",
                    Country = "Macedonia",
                    Players = playersInClub1
                },
                new Club
                {
                    Id = 2,
                    Name = "Anthony's Second Club",
                    Owner = "Anthony",
                    City = "Bitola",
                    Country = "Macedonia",
                    Players = playersInClub2
                }
            };
            context.AddRange(playersInClub1);
            context.AddRange(playersInClub2);
            context.AddRange(clubs);
            context.SaveChanges();
        }
        public void Dispose()
        {
            _connection.Close();
        }
    }
}
