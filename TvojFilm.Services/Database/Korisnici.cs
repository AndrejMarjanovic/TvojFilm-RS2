using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class Korisnici
    {
        [Key]
        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }

        public byte[]? Slika { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public virtual Gradovi Grad { get; set; } = null!;

        [ForeignKey(nameof(Uloga))]
        public int UlogaId { get; set; }
        public virtual Uloge Uloga { get; set; } = null!;

        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
    }
}
