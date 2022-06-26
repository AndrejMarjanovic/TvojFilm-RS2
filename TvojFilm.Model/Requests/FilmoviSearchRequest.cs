using System;
using System.Collections.Generic;
using System.Text;

namespace TvojFilm.Model.Requests
{
    public class FilmoviSearchRequest
    {
        public string NazivFilma { get; set; }
        public string Redatelj { get; set; }
        public string Glumac { get; set; }
        public int? ZanrId { get; set; }
        public int? DrzavaId { get; set; }
    }
}
