using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; } 
        public string Email { get; set; } 
        public string Telefon { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public byte[] Slika { get; set; }

        public int GradId { get; set; }
        public virtual Gradovi Grad { get; set; } 

        public int UlogaId { get; set; }
        public virtual Uloge Uloga { get; set; } 

        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}
