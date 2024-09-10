﻿// <auto-generated />
using System;
using Bootcamp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bootcamp.Data.Migrations
{
    [DbContext(typeof(EngagementDbContext))]
    [Migration("20240910112004_Init_DB_3")]
    partial class Init_DB_3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bootcamp.Data.Models.Engagement", b =>
                {
                    b.Property<int>("EngagementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngagementId"));

                    b.Property<DateTimeOffset>("AuditEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("AuditStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Auditors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("EngagementId");

                    b.ToTable("Engagements");
                });
#pragma warning restore 612, 618
        }
    }
}
