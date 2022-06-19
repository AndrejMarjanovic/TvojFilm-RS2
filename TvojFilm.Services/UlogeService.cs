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
    public class UlogeService : BaseCRUDService<Model.Uloge, UlogeSearchRequest, Database.Uloge, UlogeInsertRequest, UlogeInsertRequest>
    {
        public UlogeService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Uloge> Get(UlogeSearchRequest search)
        {
            var query = _db.Uloge.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Uloge>>(list);
        }
    }
}
