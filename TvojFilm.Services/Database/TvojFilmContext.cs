using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;


namespace TvojFilm.Services.Database
{
    public partial class TvojFilmContext : DbContext
    {
        public TvojFilmContext()
        { }

        public TvojFilmContext(DbContextOptions<TvojFilmContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Drzave> Drzave { get; set; } = null!;
        public DbSet<Gradovi> Gradovi { get; set; } = null!;
        public DbSet<Filmovi> Filmovi { get; set; } = null!;
        public DbSet<Redatelji> Redatelji { get; set; } = null!;
        public DbSet<Korisnici> Korisnici { get; set; } = null!;
        public DbSet<Uloge> Uloge { get; set; } = null!;
        public DbSet<FilmoviKomentari> FilmoviKomentari { get; set; } = null!;
        public DbSet<FilmoviOcjene> FilmoviOcjene { get; set; } = null!;
        public DbSet<KupnjaFilmova> KupnjaFilmova { get; set; } = null!;
        public DbSet<PrijedloziFilmova> PrijedloziFilmova { get; set; } = null!;
        public DbSet<Zanrovi> Zanrovi { get; set; } = null!;
    }


}
