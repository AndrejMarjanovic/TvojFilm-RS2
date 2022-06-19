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
    public class RedateljiService : BaseCRUDService<Model.Redatelji, RedateljiSearchRequest, Database.Redatelji, RedateljiInsertRequest, RedateljiInsertRequest>
    {
        public RedateljiService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Redatelji> Get(RedateljiSearchRequest search)
        {
            var query = _db.Redatelji.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().Contains(search.Ime.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().Contains(search.Prezime.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Redatelji>>(list);
        }
    }
}
