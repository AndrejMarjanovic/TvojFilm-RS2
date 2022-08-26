using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;


namespace TvojFilm.Services.Database
{
    public partial class TvojFilmContext : DbContext
    {
        public TvojFilmContext(DbContextOptions<TvojFilmContext> options) : base(options){ }

        public TvojFilmContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrijedloziFilmova>()
                 .HasOne(pt => pt.Korisnik).WithMany().HasForeignKey(pt => pt.KorisnikId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FilmoviKomentari>()
                .HasOne(p => p.Korisnik).WithMany().HasForeignKey(p => p.KorisnikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FilmoviOcjene>()
                .HasOne(p => p.Korisnik).WithMany().HasForeignKey(p => p.KorisnikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KupnjaFilmova>()
                .HasOne(p => p.Korisnik).WithMany().HasForeignKey(p => p.KorisnikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<KupnjaFilmova>()
                .HasOne(p => p.Korisnik).WithMany().HasForeignKey(p => p.KorisnikId)
                .OnDelete(DeleteBehavior.Restrict);


          SeedUloge(modelBuilder);
          SeedDrzave(modelBuilder);
          SeedGradove(modelBuilder);
          SeedZanrove(modelBuilder);
          SeedKorisnike(modelBuilder);
          SeedRedatelje(modelBuilder);
          SeedGlumce(modelBuilder);
          SeedFilmove(modelBuilder);
          SeedPrijedlogFilma(modelBuilder);
          SeedFilmoviKomentari(modelBuilder);
          SeedFilmoviOcjene(modelBuilder);
          SeedKupnjaFilmova(modelBuilder);

        }

        public DbSet<Drzave> Drzave { get; set; } = null!;
        public DbSet<Gradovi> Gradovi { get; set; } = null!;
        public DbSet<Filmovi> Filmovi { get; set; } = null!;
        public DbSet<Redatelji> Redatelji { get; set; } = null!;
        public DbSet<Glumci> Glumci { get; set; } = null!;
        public DbSet<Korisnici> Korisnici { get; set; } = null!;
        public DbSet<Uloge> Uloge { get; set; } = null!;
        public DbSet<FilmoviKomentari> FilmoviKomentari { get; set; } = null!;
        public DbSet<FilmoviOcjene> FilmoviOcjene { get; set; } = null!;
        public DbSet<KupnjaFilmova> KupnjaFilmova { get; set; } = null!;
        public DbSet<PrijedloziFilmova> PrijedloziFilmova { get; set; } = null!;
        public DbSet<Zanrovi> Zanrovi { get; set; } = null!;


        private void SeedUloge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge { UlogaId = 1, Naziv = "Administrator", Opis = "Uloga koja ima pristup desktop dijelu aplikacije!" },
                new Uloge { UlogaId = 2, Naziv = "Korisnik", Opis = "Ova uloga ima isključivo pristup mobilnom dijelu!" }
                );
        }

        private void SeedDrzave(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzave>().HasData(
                new Drzave { DrzavaId = 1, Naziv = "Bosna i Hercegoviina" },
                new Drzave { DrzavaId = 2, Naziv = "Hrvatska" },
                new Drzave { DrzavaId = 3, Naziv = "SAD" },
                new Drzave { DrzavaId = 4, Naziv = "Srbija" }
                );
        }

        private void SeedGradove(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gradovi>().HasData(
                new Gradovi { GradId = 1, Naziv = "Sarajevo", DrzavaId = 1 },
                new Gradovi { GradId = 2, Naziv = "Zagreb", DrzavaId = 2 },
                new Gradovi { GradId = 3, Naziv = "Mostar", DrzavaId = 1 },
                new Gradovi { GradId = 4, Naziv = "Travnik", DrzavaId = 1 },
                new Gradovi { GradId = 5, Naziv = "Beograd", DrzavaId = 4 }
                );
        }

        private void SeedZanrove(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zanrovi>().HasData(
                 new Zanrovi { ZanrId = 1, Naziv = "Akcija" },
                 new Zanrovi { ZanrId = 2, Naziv = "Komedija" },
                 new Zanrovi { ZanrId = 3, Naziv = "Western" },
                 new Zanrovi { ZanrId = 4, Naziv = "Drama" },
                 new Zanrovi { ZanrId = 5, Naziv = "Znanstvena Fantastika" }
                 );
        }

        private void SeedKorisnike(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnici>().HasData(
                 new Korisnici
                 {
                     KorisnikId = 1,
                     Ime = "Admin",
                     Prezime = "Admin",
                     DatumRodjenja = DateTime.Now,
                     Email = "admin@gmail.com",
                     Telefon = "000000000",
                     UlogaId = 1,
                     GradId = 1,
                     Username = "admin",
                     PasswordHash = "NsWGalslR0eO9YFkWigokaLAptI=",
                     PasswordSalt = "vpMs5Pc7Cwa2unN1GWcvXA=="
                 },
                 new Korisnici
                 {
                     KorisnikId = 2,
                     Ime = "Korisnik",
                     Prezime = "Korisnik",
                     DatumRodjenja = DateTime.Now,
                     Email = "korisnik@gmail.com",
                     Telefon = "111000000",
                     UlogaId = 2,
                     GradId = 1,
                     Username = "korisnik1",
                     PasswordHash = "4Q+m2CJFGHDHfkZwYyiDu7eJLAM=",
                     PasswordSalt = "3i5f59BijRmLe2N+DMQxYw=="
                 },
                 new Korisnici
                 {
                     KorisnikId = 3,
                     Ime = "Korisnik2",
                     Prezime = "Korisnik2",
                     DatumRodjenja = DateTime.Now,
                     Email = "korisnik2@gmail.com",
                     Telefon = "222000000",
                     UlogaId = 2,
                     GradId = 2,
                     Username = "korisnik2",
                     PasswordHash = "lkPjzvRUL/yqjKIRYIikqh/gIwc=",
                     PasswordSalt = "G8EKrXwcUxdyGYHs7mcEIw=="
                 }
                 );
        }
        private void SeedRedatelje(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Redatelji>().HasData(
                new Redatelji { RedateljId = 1, Ime = "Christopher", Prezime = "Nolan", DatumRodjenja = DateTime.Parse("1970-07-30T00:00:00")},
                new Redatelji { RedateljId = 2, Ime = "Quentin", Prezime = "Tarantino", DatumRodjenja = DateTime.Parse("1963-03-27T00:00:00")},
                new Redatelji { RedateljId = 3, Ime = "Ryan", Prezime = "Coogler", DatumRodjenja = DateTime.Parse("1986-05-23T00:00:00")},
                new Redatelji { RedateljId = 4, Ime = "Alejandro", Prezime = "G. Iñárritu", DatumRodjenja = DateTime.Parse("1963-08-15T00:00:00")}
                );
        }

        private void SeedGlumce(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Glumci>().HasData(
                new Glumci { GlumacId = 1, Ime = "Christian", Prezime = "Bale", DatumRodjenja = DateTime.Parse("1974-01-30T00:00:00") },
                new Glumci { GlumacId = 2, Ime = "Jamie", Prezime = "Foxx", DatumRodjenja = DateTime.Parse("1967-12-13T00:00:00") },
                new Glumci { GlumacId = 3, Ime = "Leonardo", Prezime = "DiCaprio", DatumRodjenja = DateTime.Parse("1974-11-11T00:00:00") },
                new Glumci { GlumacId = 4, Ime = "Matthew", Prezime = "McConaughey", DatumRodjenja = DateTime.Parse("1969-11-04T00:00:00") },
                new Glumci { GlumacId = 5, Ime = "Michael B.", Prezime = "Jordan", DatumRodjenja = DateTime.Parse("1987-02-09T00:00:00") }
                );
        }

        private void SeedFilmove(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filmovi>().HasData(
                 new Filmovi
                 {
                     FilmId = 1,
                     NazivFilma = "Django Unchained",
                     Godina = DateTime.Parse("2012-02-14T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/Django.jpg"),
                     Cijena = 14,
                     Ocjena = 8.4,
                     Opis = "Radnja filma je smještena 1859. godine, 2 godine prije početka Američkog građanskog rata na dubokom Jugu i starom Zapadu, film prati oslobođenog roba (Foxx) koji skupa s lovcem na glave kreće u misiju spašavanja svoje supruge od okrutnog, sadističkog i karizmatičnog vlasnika plantaže.",
                     FilmLink = "https://youtu.be/_iH0UBYDI4g",
                     RedateljId = 2,
                     GlumacId = 2,
                     ZanrId = 3,
                     DrzavaId = 3
                 },
                 new Filmovi
                 {
                     FilmId = 2,
                     NazivFilma = "The Dark Knight",
                     Godina = DateTime.Parse("2008-07-18T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/TDK.jpg"),
                     Cijena = 14,
                     Ocjena = 9,
                     Opis = "Vitez tame drugi je nastavak Nolanovog filmskog serijala o Batmanu. Radnja filma prati Batmanovu borbu s novim zlikovcem, Jokerom i njegov odnos s okružnim tužiteljem Harveyjem Dentom.",
                     FilmLink = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                     RedateljId = 1,
                     GlumacId = 1,
                     ZanrId = 1,
                     DrzavaId = 3
                 },
                 new Filmovi
                 {
                     FilmId = 3,
                     NazivFilma = "Inception",
                     Godina = DateTime.Parse("2010-07-16T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/Inception.jpg"),
                     Cijena = 15,
                     Ocjena = 8.8,
                     Opis = "DiCaprio tumači ulogu Dominicka Cobba, lopova koji obavlja poslove industrijske špijunaže koristeći eksperimentalnu vojunu tehnologiju koja mu omogućava ulazak u podsvijest svojih meta.",
                     FilmLink = "https://www.youtube.com/watch?v=YoHD9XEInc0",
                     RedateljId = 1,
                     GlumacId = 3,
                     ZanrId = 5,
                     DrzavaId = 3
                 },
                 new Filmovi
                 {
                     FilmId = 4,
                     NazivFilma = "Interstellar",
                     Godina = DateTime.Parse("2014-08-26T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/Interstellar.jpg"),
                     Cijena = 14,
                     Ocjena = 8.6,
                     Opis = "Radnja filma vrti se oko skupine ljudi koja putuje u svemir i ulazi u crvotočinu kako bi pronašla novi planet na koji bi se ljudi mogli naseliti.",
                     FilmLink = "https://www.youtube.com/watch?v=2LqzF5WauAw",
                     RedateljId = 1,
                     GlumacId = 4,
                     ZanrId = 5,
                     DrzavaId = 3
                 },
                 new Filmovi
                 {
                     FilmId = 5,
                     NazivFilma = "Creed",
                     Godina = DateTime.Parse("2015-11-25T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/Creed.jpg"),
                     Cijena = 12,
                     Ocjena = 7.6,
                     Opis = "Sedmi film iz Rocky serijala, prati Adonisa Creeda koji putuje prema Philadeplphiji, gdje upoznaje Rockyja Balbou, bivšeg suparnika i prijatelja svoga oca i traži od njega da ga trenira.",
                     FilmLink = "https://www.youtube.com/watch?v=Uv554B7YHk4",
                     RedateljId = 3,
                     GlumacId = 5,
                     ZanrId = 4,
                     DrzavaId = 3
                 },
                 new Filmovi
                 {
                     FilmId = 6,
                     NazivFilma = "The Revenant",
                     Godina = DateTime.Parse("2015-12-16T00:00:00"),
                     Poster = File.ReadAllBytes("Assets/TheRevenant.jpg"),
                     Cijena = 15,
                     Ocjena = 8,
                     Opis = "Film baziran na istoimenoj noveli Michaela Punkea iz 2002., prati iskustva istraživača Hugha Glassa iz 1823. godine. Inspiriran istinitim događajima, Povratnik je uzbudljivo filmsko remek djelo koje prikazuje epsku avanturu preživljavanja jednoga muškarca i izuzetnu moć sna­ge ljudskoga duha.",
                     FilmLink = "https://www.youtube.com/watch?v=LoebZZ8K5N0",
                     RedateljId = 4,
                     GlumacId = 3,
                     ZanrId = 3,
                     DrzavaId = 3
                 }
                 );
        }
        private void SeedKupnjaFilmova(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KupnjaFilmova>().HasData(
                new KupnjaFilmova
                {
                    KupnjaId = 1,
                    KorisnikId = 2,
                    FilmId = 1,
                    DatumKupovine = DateTime.Now,
                },
                new KupnjaFilmova
                {
                    KupnjaId = 2,
                    KorisnikId = 2,
                    FilmId = 2,
                    DatumKupovine = DateTime.Now,
                },
                new KupnjaFilmova
                {
                    KupnjaId = 3,
                    KorisnikId = 3,
                    FilmId = 3,
                    DatumKupovine = DateTime.Now,
                },
                new KupnjaFilmova
                {
                    KupnjaId = 4,
                    KorisnikId = 3,
                    FilmId = 4,
                    DatumKupovine = DateTime.Now,
                },
                new KupnjaFilmova
                {
                    KupnjaId = 5,
                    KorisnikId = 2,
                    FilmId = 5,
                    DatumKupovine = DateTime.Now,
                },
                new KupnjaFilmova
                {
                    KupnjaId = 6,
                    KorisnikId = 3,
                    FilmId = 1,
                    DatumKupovine = DateTime.Now,
                }
                );
        }

        private void SeedFilmoviOcjene(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmoviOcjene>().HasData(
                new FilmoviOcjene
                {
                    FilmOcjenaId = 1,
                    KorisnikId = 2,
                    FilmId = 1,
                    Ocjena = 4.5,
                    DatumOcjene = DateTime.Now
                },
                new FilmoviOcjene
                {
                    FilmOcjenaId = 2,
                    KorisnikId = 2,
                    FilmId = 2,
                    Ocjena = 5,
                    DatumOcjene = DateTime.Now
                },
                new FilmoviOcjene
                {
                    FilmOcjenaId = 3,
                    KorisnikId = 3,
                    FilmId = 3,
                    Ocjena = 4,
                    DatumOcjene = DateTime.Now
                },
                new FilmoviOcjene
                {
                    FilmOcjenaId = 4,
                    KorisnikId = 3,
                    FilmId = 4,
                    Ocjena = 3,
                    DatumOcjene = DateTime.Now
                },
                new FilmoviOcjene
                {
                    FilmOcjenaId = 5,
                    KorisnikId = 2,
                    FilmId = 5,
                    Ocjena = 2.5,
                    DatumOcjene = DateTime.Now
                }
                );
        }
        private void SeedFilmoviKomentari(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmoviKomentari>().HasData(
                new FilmoviKomentari
                {
                    FilmKomentarId = 1,
                    KorisnikId = 2,
                    FilmId = 1,
                    DatumKomentara = DateTime.Now,
                    Komentar = "Odličan film..."
                },
                new FilmoviKomentari
                {
                    FilmKomentarId = 2,
                    KorisnikId = 2,
                    FilmId = 2,
                    DatumKomentara = DateTime.Now,
                    Komentar = "Odličan film...!"
                },
                new FilmoviKomentari
                {
                    FilmKomentarId = 3,
                    KorisnikId = 3,
                    FilmId = 1,
                    DatumKomentara = DateTime.Now,
                    Komentar = "Film je jako dobar, preporuke"
                }
                );
        }
        private void SeedPrijedlogFilma(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrijedloziFilmova>().HasData(
                new PrijedloziFilmova
                {
                    PrijedlogId = 1,
                    KorisnikId = 2,
                    PrijedlogIme = "Kum",
                    DatumPrijedloga = DateTime.Now,
                    Opis = "Coppolin klasik iz 1972."
                },
                new PrijedloziFilmova
                {
                    PrijedlogId = 2,
                    KorisnikId = 3,
                    PrijedlogIme = "Fury",
                    DatumPrijedloga = DateTime.Now,
                    Opis = "Ratni film iz 2014."
                }
                );
        }
    }
}
