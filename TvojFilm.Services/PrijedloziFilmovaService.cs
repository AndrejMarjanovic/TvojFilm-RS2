using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;
using TvojFilm.Services.Database;

namespace TvojFilm.Services
{
    public class PrijedloziFilmovaService : BaseCRUDService<Model.PrijedloziFilmova, PrijedloziFilmovaSearchRequest, Database.PrijedloziFilmova, PrijedloziFilmovaInsertRequest, PrijedloziFilmovaInsertRequest>
    {
        public PrijedloziFilmovaService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.PrijedloziFilmova> Get(PrijedloziFilmovaSearchRequest search)
        {
            var query = _db.PrijedloziFilmova.Include(x => x.Korisnik).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.PrijedlogIme))
            {
                query = query.Where(x => x.PrijedlogIme.ToLower().Contains(search.PrijedlogIme.ToLower()));
            }


            var list = query.ToList();
            return _mapper.Map<List<Model.PrijedloziFilmova>>(list);
        }
    }
}
