﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model
{
    public class Redatelji
    {
        public int RedateljId { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; } 
        public DateTime DatumRodjenja { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

        public string ImePrezime => $"{Ime} {Prezime}";

    }
}
