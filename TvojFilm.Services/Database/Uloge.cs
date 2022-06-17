using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class Uloge
    {
        [Key]
        public int UlogaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
    }
}
