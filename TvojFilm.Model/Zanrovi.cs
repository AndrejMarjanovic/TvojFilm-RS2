using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Zanrovi
    {
        public int ZanrId { get; set; }
        public string Naziv { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
