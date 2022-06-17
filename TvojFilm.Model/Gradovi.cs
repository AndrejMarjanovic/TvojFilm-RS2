using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Gradovi
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }
        public virtual Drzave Drzava { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
