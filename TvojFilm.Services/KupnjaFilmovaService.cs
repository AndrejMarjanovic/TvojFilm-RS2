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
    public class KupnjaFilmovaService : BaseCRUDService<Model.KupnjaFilmova, KupnjaFilmovaSearchRequest, Database.KupnjaFilmova, KupnjaFilmovaInsertRequest, KupnjaFilmovaInsertRequest>
    {
        public KupnjaFilmovaService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.KupnjaFilmova> Get(KupnjaFilmovaSearchRequest search)
        {
            var query = _db.KupnjaFilmova.AsQueryable();


            if (search?.FilmId.HasValue == true)
            {
                query = query.Where(x => x.FilmId == search.FilmId);
            }
            if (search?.KorisnikId.HasValue == true)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.KupnjaFilmova>>(list);
        }
    }
}
