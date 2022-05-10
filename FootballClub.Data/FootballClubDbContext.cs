using FootballClub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Data
{
    public class FootballClubDbContext : DbContext
    {
        public FootballClubDbContext(DbContextOptions<FootballClubDbContext> options) : base(options)
        {

        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(club => {
                club.Property(p => p.Id).IsRequired();
                club.Property(p => p.City).IsRequired().HasMaxLength(200);
                club.Property(p => p.Country).IsRequired().HasMaxLength(200);
                club.Property(p => p.Owner).IsRequired().HasMaxLength(200);
                club.HasKey(p => p.Id);
                club.HasMany(p => p.Players);
                
            });

            modelBuilder.Entity<Player>(player => {
                player.Property(p => p.Id).IsRequired();
                player.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
                player.Property(p => p.LastName).IsRequired().HasMaxLength(400);
                player.Property(p => p.DOB).IsRequired();
                player.Property(p => p.SigningDate).IsRequired();
                player.Property(p => p.Rank).IsRequired();
                player.Property(p => p.TotalGoals).IsRequired();
                player.Property(p => p.ClubId).IsRequired();
                player.HasKey(p => p.Id);
                player.HasOne(p => p.Club);
            });
        }
    }
}
