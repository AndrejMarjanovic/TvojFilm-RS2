﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvojFilm.Services.Database;

#nullable disable

namespace TvojFilm.Services.Migrations
{
    [DbContext(typeof(TvojFilmContext))]
    partial class TvojFilmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TvojFilm.Services.Database.Drzave", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrzavaId"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Filmovi", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"), 1L, 1);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("FilmLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlumacId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Godina")
                        .HasColumnType("datetime2");

                    b.Property<string>("NazivFilma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ocjena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RedateljId")
                        .HasColumnType("int");

                    b.Property<int>("ZanrId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GlumacId");

                    b.HasIndex("RedateljId");

                    b.HasIndex("ZanrId");

                    b.ToTable("Filmovi");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.FilmoviKomentari", b =>
                {
                    b.Property<int>("FilmKomentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmKomentarId"), 1L, 1);

                    b.Property<DateTime>("DatumKomentara")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("FilmKomentarId");

                    b.HasIndex("FilmId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("FilmoviKomentari");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.FilmoviOcjene", b =>
                {
                    b.Property<int>("FilmOcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmOcjenaId"), 1L, 1);

                    b.Property<DateTime>("DatumOcjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<double>("Ocjena")
                        .HasColumnType("float");

                    b.HasKey("FilmOcjenaId");

                    b.HasIndex("FilmId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("FilmoviOcjene");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Glumci", b =>
                {
                    b.Property<int>("GlumacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlumacId"), 1L, 1);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlumacId");

                    b.ToTable("Glumci");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Gradovi", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradId"), 1L, 1);

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikId"), 1L, 1);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikId");

                    b.HasIndex("GradId");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.KupnjaFilmova", b =>
                {
                    b.Property<int>("KupnjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KupnjaId"), 1L, 1);

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<bool?>("Odobreno")
                        .HasColumnType("bit");

                    b.HasKey("KupnjaId");

                    b.HasIndex("FilmId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("KupnjaFilmova");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.PrijedloziFilmova", b =>
                {
                    b.Property<int>("PrijedlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrijedlogId"), 1L, 1);

                    b.Property<DateTime>("DatumPrijedloga")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrijedlogIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrijedlogId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("PrijedloziFilmova");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Redatelji", b =>
                {
                    b.Property<int>("RedateljId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RedateljId"), 1L, 1);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RedateljId");

                    b.ToTable("Redatelji");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlogaId"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Zanrovi", b =>
                {
                    b.Property<int>("ZanrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZanrId"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZanrId");

                    b.ToTable("Zanrovi");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Filmovi", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Drzave", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Glumci", "Glumac")
                        .WithMany()
                        .HasForeignKey("GlumacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Redatelji", "Redatelj")
                        .WithMany()
                        .HasForeignKey("RedateljId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Zanrovi", "Zanr")
                        .WithMany()
                        .HasForeignKey("ZanrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");

                    b.Navigation("Glumac");

                    b.Navigation("Redatelj");

                    b.Navigation("Zanr");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.FilmoviKomentari", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Filmovi", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.FilmoviOcjene", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Filmovi", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Gradovi", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Drzave", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.Korisnici", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Gradovi", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Uloge", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.KupnjaFilmova", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Filmovi", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvojFilm.Services.Database.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("TvojFilm.Services.Database.PrijedloziFilmova", b =>
                {
                    b.HasOne("TvojFilm.Services.Database.Korisnici", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });
#pragma warning restore 612, 618
        }
    }
}
