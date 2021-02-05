﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201219235404_InitialMiration")]
    partial class InitialMiration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Data.Entities.AppFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Core.Data.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Data.Entities.MoneyChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("MoneyChangeTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MoneyChanges");
                });

            modelBuilder.Entity("Core.Data.Entities.MoneyChangeTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MoneyChangeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MoneyChangeId");

                    b.ToTable("MoneyChangeTags");
                });

            modelBuilder.Entity("Core.Data.Entities.MoneyChangeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MoneyChangeTypes");
                });

            modelBuilder.Entity("Core.Data.Entities.AppUser", b =>
                {
                    b.HasOne("Core.Data.Entities.AppFamily", "Family")
                        .WithMany("Kinsmans")
                        .HasForeignKey("FamilyId");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Core.Data.Entities.MoneyChangeTag", b =>
                {
                    b.HasOne("Core.Data.Entities.MoneyChange", null)
                        .WithMany("Tags")
                        .HasForeignKey("MoneyChangeId");
                });

            modelBuilder.Entity("Core.Data.Entities.AppFamily", b =>
                {
                    b.Navigation("Kinsmans");
                });

            modelBuilder.Entity("Core.Data.Entities.MoneyChange", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
