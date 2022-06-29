using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Filmovi
    {
        public int FilmId { get; set; }
        public string NazivFilma { get; set; }
        public DateTime Godina { get; set; }
        public byte[] Poster { get; set; }
        public double Cijena { get; set; }
        public double Ocjena { get; set; }
        public string FilmLink { get; set; }
        public string Opis { get; set; }

        public int RedateljId { get; set; }
        public virtual Redatelji Redatelj { get; set; }

        public int GlumacId { get; set; }
        public virtual Glumci Glumac { get; set; }

        public int ZanrId { get; set; }
        public virtual Zanrovi Zanr { get; set; }

        public int DrzavaId { get; set; }
        public virtual Drzave Drzava { get; set; }

        public override string ToString()
        {
            return NazivFilma;
        }

    }
}
