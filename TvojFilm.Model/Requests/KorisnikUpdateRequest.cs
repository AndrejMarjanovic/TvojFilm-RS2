﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int GradId { get; set; }
        public int UlogaId { get; set; }
        public byte[] Slika { get; set; }
        public string Username { get; set; }
    }
}
