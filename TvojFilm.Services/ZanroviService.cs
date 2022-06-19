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
    public class ZanroviService : BaseCRUDService<Model.Zanrovi, ZanroviSearchRequest, Database.Zanrovi, ZanroviInsertRequest, ZanroviInsertRequest>
    {
        public ZanroviService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Zanrovi> Get(ZanroviSearchRequest search)
        {
            var query = _db.Zanrovi.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Zanrovi>>(list);
        }
    }
}
