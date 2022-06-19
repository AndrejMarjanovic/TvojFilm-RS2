using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;
using TvojFilm.Services.Database;

namespace TvojFilm.Services
{
    public class DrzaveService : BaseCRUDService<Model.Drzave, DrzaveSearchRequest, Database.Drzave, DrzaveInsertRequest, DrzaveInsertRequest>
    {
        public DrzaveService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Drzave> Get(DrzaveSearchRequest search)
        {
            var query = _db.Drzave.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Drzave>>(list);
        }
    }
}
