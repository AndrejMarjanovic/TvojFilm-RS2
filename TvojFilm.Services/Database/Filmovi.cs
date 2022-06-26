using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TvojFilm.Services.Database;

namespace TvojFilm.Services.Database
{
    public class Filmovi
    {

        [Key]
        public int FilmId { get; set; }
        public string NazivFilma { get; set; } = null!;
        public DateTime Godina { get; set; } 
        public byte[]? Poster { get; set; } 
        public double Cijena { get; set; } 
        public double Ocjena { get; set; }
        public byte[]? FilmFile { get; set; }
        public string Opis { get; set; } = null!;
        public bool? FileDodan { get; set; }

        [ForeignKey(nameof(Redatelj))]
        public int RedateljId { get; set; }
        public virtual Redatelji Redatelj { get; set; } = null!;

        [ForeignKey(nameof(Glumac))]
        public int GlumacId { get; set; }
        public virtual Glumci Glumac { get; set; } = null!;

        [ForeignKey(nameof(Zanr))]
        public int ZanrId { get; set; }
        public virtual Zanrovi Zanr { get; set; } = null!;

        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public virtual Drzave Drzava { get; set; } = null!;

    }
}