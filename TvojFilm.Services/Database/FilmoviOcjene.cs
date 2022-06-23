using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class FilmoviOcjene
    {
        [Key]
        public int FilmOcjenaId { get; set; }
        public double Ocjena { get; set; }
        public DateTime DatumOcjene { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; } = null!;

        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public virtual Filmovi Film { get; set; } = null!;
    }
}
