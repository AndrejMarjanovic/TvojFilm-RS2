using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class FilmoviKomentari
    {
        public int FilmKomentarId { get; set; }
        public string Komentar { get; set; }
        public DateTime DatumKomentara { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public int FilmId { get; set; }
        public virtual Filmovi Film { get; set; }
    }
}
