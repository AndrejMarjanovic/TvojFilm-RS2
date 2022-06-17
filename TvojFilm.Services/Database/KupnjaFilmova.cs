using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class KupnjaFilmova
    {
        [Key]
        public int KupnjaId { get; set; }
        public DateTime DatumKupovine { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; } = null!;

        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public virtual Filmovi Film { get; set; } = null!;

        public bool? Odobreno { get; set; }
    }
}
