using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Uloge
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
