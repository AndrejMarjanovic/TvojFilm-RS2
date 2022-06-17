using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class Zanrovi
    {
        [Key]
        public int ZanrId { get; set; }
        public string Naziv { get; set; } = null!;
    }
}

