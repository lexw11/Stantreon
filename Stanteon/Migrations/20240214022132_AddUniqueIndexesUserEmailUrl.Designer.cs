﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StantreonApi.Models;

#nullable disable

namespace StantreonApi.Migrations
{
    [DbContext(typeof(StantreonContext))]
    [Migration("20240214022132_AddUniqueIndexesUserEmailUrl")]
    partial class AddUniqueIndexesUserEmailUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("StantreonApi.Models.Users.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<long>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("StantreonApi.Models.Users.Creator", b =>
                {
                    b.HasBaseType("StantreonApi.Models.Users.User");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("UrlHandle")
                        .IsUnique()
                        .HasFilter("[UrlHandle] IS NOT NULL");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("StantreonApi.Models.Users.Member", b =>
                {
                    b.HasBaseType("StantreonApi.Models.Users.User");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}