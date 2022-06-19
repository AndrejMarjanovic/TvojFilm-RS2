using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class DrzaveInsertRequest
    {
        [Required(ErrorMessage = "Unesite naziv drzave.")]

        public string Naziv { get; set; }
    }
}
