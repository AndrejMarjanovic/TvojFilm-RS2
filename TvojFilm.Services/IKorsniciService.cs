using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model;
using TvojFilm.Model.Requests;

namespace TvojFilm.Services
{
    public interface IKorisniciService
    {
        public List<Korisnici> Get(KorisnikSearchRequest search);
        public Korisnici GetbyId(int id);
        public Korisnici Insert(KorisnikInsertRequest request);
        public Korisnici Update(int id, KorisnikUpdateRequest request);
        public void Delete(int id);
        public Model.Korisnici Login(string username, string pass);
    }
}