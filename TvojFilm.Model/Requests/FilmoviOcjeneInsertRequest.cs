using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Model.Requests
{
    public class FilmoviOcjeneInsertRequest
    {
        public double Ocjena { get; set; }
        public int KorisnikId { get; set; }
        public int FilmId { get; set; }
    }
}