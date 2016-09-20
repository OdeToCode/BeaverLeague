using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeaverLeague.Data;

namespace BeaverLeague.Data.Migrations
{
    [DbContext(typeof(LeagueDb))]
    [Migration("20160920032340_v1.000")]
    partial class v1000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeaverLeague.Core.Models.Golfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<float>("Handicap");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<int>("MembershipId");

                    b.Property<string>("PasswordHash")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Username")
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");

                    b.HasIndex("MembershipId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Golfers");
                });
        }
    }
}
