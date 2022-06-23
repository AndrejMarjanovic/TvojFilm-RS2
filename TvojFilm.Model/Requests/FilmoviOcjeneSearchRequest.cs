using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class FilmoviOcjeneSearchRequest
    {
        public double Ocjena { get; set; }
        public int? FilmId { get; set; }
        public int? KorisnikId { get; set; }
    }
}
