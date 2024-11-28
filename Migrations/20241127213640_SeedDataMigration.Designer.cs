﻿// <auto-generated />
using System;
using Bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bibliotekssystem_AE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241127213640_SeedDataMigration")]
    partial class SeedDataMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bibliotekssystem.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            Name = "J.K. Rowling",
                            Nationality = "British"
                        },
                        new
                        {
                            AuthorID = 2,
                            Name = "George R.R. Martin",
                            Nationality = "American"
                        },
                        new
                        {
                            AuthorID = 3,
                            Name = "Agatha Christie",
                            Nationality = "British"
                        });
                });

            modelBuilder.Entity("Bibliotekssystem.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            ReleaseDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            BookID = 2,
                            ReleaseDate = new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Game of Thrones"
                        },
                        new
                        {
                            BookID = 3,
                            ReleaseDate = new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Murder on the Orient Express"
                        });
                });

            modelBuilder.Entity("Bibliotekssystem.Models.BookToAuthor", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.HasKey("BookID", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookToAuthors");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            AuthorID = 1
                        },
                        new
                        {
                            BookID = 2,
                            AuthorID = 2
                        },
                        new
                        {
                            BookID = 3,
                            AuthorID = 3
                        });
                });

            modelBuilder.Entity("Bibliotekssystem.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanID");

                    b.HasIndex("BookID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanID = 1,
                            BookID = 1,
                            LoanDate = new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            LoanID = 2,
                            BookID = 2,
                            LoanDate = new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Bibliotekssystem.Models.BookToAuthor", b =>
                {
                    b.HasOne("Bibliotekssystem.Models.Author", "Author")
                        .WithMany("BookToAuthors")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotekssystem.Models.Book", "Book")
                        .WithMany("BookToAuthors")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bibliotekssystem.Models.Loan", b =>
                {
                    b.HasOne("Bibliotekssystem.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bibliotekssystem.Models.Author", b =>
                {
                    b.Navigation("BookToAuthors");
                });

            modelBuilder.Entity("Bibliotekssystem.Models.Book", b =>
                {
                    b.Navigation("BookToAuthors");

                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
