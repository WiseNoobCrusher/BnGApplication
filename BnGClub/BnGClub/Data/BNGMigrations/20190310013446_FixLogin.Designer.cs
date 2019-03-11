﻿// <auto-generated />
using System;
using BnGClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BnGClub.Data.BNGMigrations
{
    [DbContext(typeof(BnGClubContext))]
    [Migration("20190310013446_FixLogin")]
    partial class FixLogin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BNG")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BnGClub.Models.Activitys", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("actAvailablePlace")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("actCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("actDescription")
                        .IsRequired();

                    b.Property<string>("actName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("actRequirement")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("acttypeID");

                    b.Property<int>("leaderID");

                    b.HasKey("id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("BnGClub.Models.ActType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("acttypeDescription")
                        .IsRequired();

                    b.Property<string>("acttypeName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("ActTypes");
                });

            modelBuilder.Entity("BnGClub.Models.Announcement", b =>
                {
                    b.Property<int>("id");

                    b.Property<int>("actID");

                    b.Property<DateTime?>("annDate")
                        .IsRequired();

                    b.Property<string>("annMessage")
                        .IsRequired();

                    b.Property<int>("leaderID");

                    b.HasKey("id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("BnGClub.Models.Child", b =>
                {
                    b.Property<int>("id");

                    b.Property<DateTime?>("childDOB")
                        .IsRequired();

                    b.Property<string>("childFName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("childLName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("childMName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("userID");

                    b.HasKey("id");

                    b.ToTable("Childs");
                });

            modelBuilder.Entity("BnGClub.Models.childEnrolled", b =>
                {
                    b.Property<int>("actID");

                    b.Property<int>("childID");

                    b.Property<int>("id");

                    b.HasKey("actID", "childID");

                    b.HasIndex("id");

                    b.ToTable("childEnrolleds");
                });

            modelBuilder.Entity("BnGClub.Models.Leader", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("leaderEmail")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("leaderFName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("leaderLName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("leaderMName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("leaderPhone");

                    b.HasKey("id");

                    b.ToTable("Leaders");
                });

            modelBuilder.Entity("BnGClub.Models.LeaderMessage", b =>
                {
                    b.Property<int>("id");

                    b.Property<int>("leaderID");

                    b.Property<DateTime?>("msgDate")
                        .IsRequired();

                    b.Property<string>("msgDescription")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("LeaderMessages");
                });

            modelBuilder.Entity("BnGClub.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("userFName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("userLName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("userMName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("userPhone");

                    b.HasKey("ID");

                    b.HasIndex("userEmail")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BnGClub.Models.Activitys", b =>
                {
                    b.HasOne("BnGClub.Models.ActType", "ActType")
                        .WithMany("Activities")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BnGClub.Models.Leader", "Leader")
                        .WithMany("Activities")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BnGClub.Models.Announcement", b =>
                {
                    b.HasOne("BnGClub.Models.Activitys", "Activitys")
                        .WithMany("Announcements")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BnGClub.Models.Leader", "Leader")
                        .WithMany("Announcements")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BnGClub.Models.Child", b =>
                {
                    b.HasOne("BnGClub.Models.User", "User")
                        .WithMany("Childs")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BnGClub.Models.childEnrolled", b =>
                {
                    b.HasOne("BnGClub.Models.Activitys", "Activitys")
                        .WithMany("ChildEnrolleds")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BnGClub.Models.Child", "Child")
                        .WithMany("ChildEnrolleds")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BnGClub.Models.LeaderMessage", b =>
                {
                    b.HasOne("BnGClub.Models.Leader", "Leader")
                        .WithMany("LeaderMessages")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
