using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Model.Requests
{
    public class UlogeInsertRequest
    {


        [Required(ErrorMessage = "Unesite naziv uloge!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Unesite opis uloge!")]
        public string Opis { get; set; }

    }
}
