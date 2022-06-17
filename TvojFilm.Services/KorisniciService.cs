using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Services.Database;

namespace TvojFilm.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly TvojFilmContext db;
        private readonly IMapper mapper;

        public KorisniciService(TvojFilmContext _db, IMapper map)
        {
            db = _db;
            mapper = map;

        }

        public IEnumerable<Model.Korisnici> Get()
        {
            var result = db.Korisnici.ToList();

            return mapper.Map<List<Model.Korisnici>>(result);
        }

        public Model.Korisnici GetbyId(int id)
        {
            var k = db.Korisnici.Find(id);

            return mapper.Map<TvojFilm.Model.Korisnici>(k);
        }
    }
}
