using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class FilmoviInsertRequest
    {


        [Required(ErrorMessage = "Unesite naziv filma.")]
        public string NazivFilma { get; set; }

        [Required(ErrorMessage = "Unesite datum izlaska filma.")]
        public DateTime DatumIzdavanja { get; set; }

        public byte[] Poster { get; set; }
        [Required(ErrorMessage = "Unesite cijenu filma.")]
        public double Cijena { get; set; }
        [Required(ErrorMessage = "Unesite ocjenu za film.")]
        public double Ocjena { get; set; }

        public byte[] FilmFile { get; set; }
        public string Opis { get; set; }
        public bool FileDodan { get; set; }

        public int RedateljId { get; set; }
        public int ZanrId { get; set; }
        public int DrzavaId { get; set; }

    }
}
