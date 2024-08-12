﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Data;

#nullable disable

namespace Travel.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    [Migration("20240812085503_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Travel.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrganizerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripID");

                    b.HasIndex("OrganizerID");

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("Travel.Models.TripParticipant", b =>
                {
                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TripId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TripParticipants");
                });

            modelBuilder.Entity("Travel.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripUser", b =>
                {
                    b.Property<int>("ParticipantsUserID")
                        .HasColumnType("int");

                    b.Property<int>("TripsTripID")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsUserID", "TripsTripID");

                    b.HasIndex("TripsTripID");

                    b.ToTable("TripUser");
                });

            modelBuilder.Entity("Travel.Models.Trip", b =>
                {
                    b.HasOne("Travel.Models.User", "Organizer")
                        .WithMany("OrganizedTrips")
                        .HasForeignKey("OrganizerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Travel.Models.TripParticipant", b =>
                {
                    b.HasOne("Travel.Models.Trip", "RelatedTrip")
                        .WithMany("TripParticipants")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Travel.Models.User", "RelatedUser")
                        .WithMany("TripParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RelatedTrip");

                    b.Navigation("RelatedUser");
                });

            modelBuilder.Entity("TripUser", b =>
                {
                    b.HasOne("Travel.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel.Models.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsTripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travel.Models.Trip", b =>
                {
                    b.Navigation("TripParticipants");
                });

            modelBuilder.Entity("Travel.Models.User", b =>
                {
                    b.Navigation("OrganizedTrips");

                    b.Navigation("TripParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
