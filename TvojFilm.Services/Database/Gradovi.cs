using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services.Database
{
    public class Gradovi
    {
        [Key]
        public int GradId { get; set; }
        public string Naziv { get; set; } = null!;

        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
        public virtual Drzave Drzava { get; set; } = null!;
    }
}
