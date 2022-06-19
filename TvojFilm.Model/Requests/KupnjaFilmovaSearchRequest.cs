using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class KupnjaFilmovaSearchRequest
    {
        public int? KorisnikId { get; set; }
        public int? FilmId { get; set; }
    }
}
