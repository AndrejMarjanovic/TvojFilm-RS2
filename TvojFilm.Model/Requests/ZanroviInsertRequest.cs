using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class ZanroviInsertRequest
    {
        [Required(ErrorMessage = "Unesite naziv žanra.")]

        public string Naziv { get; set; }
    }
}
