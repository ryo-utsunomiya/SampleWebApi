﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SampleWebApi.Data;

namespace SampleWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170103064754_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleWebApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("PrefectureId");

                    b.HasKey("Id");

                    b.HasIndex("PrefectureId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SampleWebApi.Models.Prefecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Prefecture");
                });

            modelBuilder.Entity("SampleWebApi.Models.Person", b =>
                {
                    b.HasOne("SampleWebApi.Models.Prefecture", "Prefegture")
                        .WithMany()
                        .HasForeignKey("PrefectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
