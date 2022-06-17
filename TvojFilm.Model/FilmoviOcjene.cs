using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class FilmoviOcjene
    {
        public int FIlmOcjenaId { get; set; }
        public double Ocjena { get; set; }
        public DateTime DatumOcjene { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; } 

        public int FilmId { get; set; }
        public virtual Filmovi Film { get; set; }
    }
}
