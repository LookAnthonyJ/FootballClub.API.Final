﻿// <auto-generated />
using System;
using FootballClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballClub.Data.FootballClub.Data.Migrations
{
    [DbContext(typeof(FootballClubDbContext))]
    [Migration("20220510155047_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballClub.Data.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("FootballClub.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<DateTime>("SigningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalGoals")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootballClub.Data.Entities.Player", b =>
                {
                    b.HasOne("FootballClub.Data.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
