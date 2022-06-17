using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class PrijedloziFilmova
    {
        public int PrijedlogId { get; set; }
        public string PrijedlogIme { get; set; } 
        public string Opis { get; set; }
        public DateTime DatumPrijedloga { get; set; }
        public bool Odgovoren { get; set; }
        public bool Pregledan { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; } 
    }
}
