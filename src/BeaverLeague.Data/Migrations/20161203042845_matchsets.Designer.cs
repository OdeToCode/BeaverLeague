using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeaverLeague.Data;

namespace BeaverLeague.Data.Migrations
{
    [DbContext(typeof(LeagueDb))]
    [Migration("20161203042845_matchsets")]
    partial class matchsets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeaverLeague.Core.Models.Golfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<float>("Handicap");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<int>("MembershipId");

                    b.Property<string>("PasswordHash")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("MembershipId")
                        .IsUnique();

                    b.ToTable("Golfers");
                });

            modelBuilder.Entity("BeaverLeague.Core.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GolferAId");

                    b.Property<int?>("GolferBId");

                    b.Property<int?>("MatchSetId");

                    b.HasKey("Id");

                    b.HasIndex("GolferAId");

                    b.HasIndex("GolferBId");

                    b.HasIndex("MatchSetId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BeaverLeague.Core.Models.MatchSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MatchSetNumber");

                    b.Property<int>("SeasonId");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("MatchSets");
                });

            modelBuilder.Entity("BeaverLeague.Core.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("BeaverLeague.Core.Models.Match", b =>
                {
                    b.HasOne("BeaverLeague.Core.Models.Golfer", "GolferA")
                        .WithMany()
                        .HasForeignKey("GolferAId");

                    b.HasOne("BeaverLeague.Core.Models.Golfer", "GolferB")
                        .WithMany()
                        .HasForeignKey("GolferBId");

                    b.HasOne("BeaverLeague.Core.Models.MatchSet")
                        .WithMany("Matches")
                        .HasForeignKey("MatchSetId");
                });

            modelBuilder.Entity("BeaverLeague.Core.Models.MatchSet", b =>
                {
                    b.HasOne("BeaverLeague.Core.Models.Season")
                        .WithMany("MatchSets")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
