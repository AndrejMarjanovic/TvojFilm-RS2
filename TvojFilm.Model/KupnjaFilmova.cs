using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class KupnjaFilmova
    {
        public int KupnjaId { get; set; }
        public DateTime DatumKupovine { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }

        public int FilmId { get; set; }
        public virtual Filmovi Film { get; set; }

    }
}
