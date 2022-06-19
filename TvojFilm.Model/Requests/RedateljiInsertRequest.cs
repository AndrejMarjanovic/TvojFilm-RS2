using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class RedateljiInsertRequest
    {
        [Required(ErrorMessage = "Unesite ime.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite prezime.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite datum rodjenja.")]
        public DateTime DatumRodjenja { get; set; }

    }
}
