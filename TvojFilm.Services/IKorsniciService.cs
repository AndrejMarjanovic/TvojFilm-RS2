using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model;

namespace TvojFilm.Services
{
    public interface IKorisniciService
    {
        IEnumerable<Korisnici> Get();
        public Korisnici GetbyId(int id);

    }
}
