using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class PrijedloziFilmovaInsertRequest
    {
        public string PrijedlogIme { get; set; }
        public string Opis { get; set; }
        public int KorisnikId { get; set; }
    }
}
