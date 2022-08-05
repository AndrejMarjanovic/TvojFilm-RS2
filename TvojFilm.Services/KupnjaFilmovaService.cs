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
    public class KupnjaFilmovaService : BaseCRUDService<Model.KupnjaFilmova, KupnjaFilmovaSearchRequest, Database.KupnjaFilmova, KupnjaFilmovaInsertRequest, KupnjaFilmovaInsertRequest>
    {
        public KupnjaFilmovaService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.KupnjaFilmova> Get(KupnjaFilmovaSearchRequest search)
        {
            var query = _db.KupnjaFilmova.Include(x => x.Film).Include(x=>x.Film.Redatelj).Include(x => x.Film.Glumac).Include(x => x.Film.Zanr).Include(x => x.Korisnik).AsQueryable();


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

        public override void BeforeInsert(KupnjaFilmovaInsertRequest insert, KupnjaFilmova entity)
        {
            //entity.KorisnikId
            entity.DatumKupovine = DateTime.Now;
            base.BeforeInsert(insert, entity);
        }

    }
}
