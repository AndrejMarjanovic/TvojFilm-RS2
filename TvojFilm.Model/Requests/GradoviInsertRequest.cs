using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class GradoviInsertRequest
    {


        [Required(ErrorMessage = "Unesite naziv grada")]

        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

    }
}
