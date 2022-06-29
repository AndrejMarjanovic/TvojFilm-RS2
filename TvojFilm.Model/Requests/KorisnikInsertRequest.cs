using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Model.Requests
{
    public class KorisnikInsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public int GradId { get; set; }
        public int UlogaId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

    }
}