using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class PrijedloziFilmova
    {
        [Key]
        public int PrijedlogId { get; set; }
        public string PrijedlogIme { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime DatumPrijedloga { get; set; }
        public bool Odgovoren { get; set; }
        public bool Pregledan { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; } = null!;
    }
}
