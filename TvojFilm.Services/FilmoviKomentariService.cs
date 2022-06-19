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
    public class FilmoviKomentariService : BaseCRUDService<Model.FilmoviKomentari, FilmoviKomentariSearchRequest, Database.FilmoviKomentari, FilmoviKomentariInsertRequest, FilmoviKomentariInsertRequest>
    {
        public FilmoviKomentariService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.FilmoviKomentari> Get(FilmoviKomentariSearchRequest search)
        {
            var query = _db.FilmoviKomentari.Include(x => x.Film).Include(x => x.Korisnik).AsQueryable();


            if (!string.IsNullOrWhiteSpace(search?.Komentar))
            {
                query = query.Where(x => x.Komentar.ToLower().Contains(search.Komentar.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.FilmId.ToString()))
            {
                query = query.Where(x => x.FilmId == search.FilmId);
            }


            var list = query.ToList();
            return _mapper.Map<List<TvojFilm.Model.FilmoviKomentari>>(list);
        }
    }
}
