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
    public class FilmoviOcjeneService : BaseCRUDService<Model.FilmoviOcjene, FilmoviOcjeneSearchRequest, Database.FilmoviOcjene, FilmoviOcjeneInsertRequest, FilmoviOcjeneInsertRequest>
    {
        public FilmoviOcjeneService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.FilmoviOcjene> Get(FilmoviOcjeneSearchRequest search)
        {
            var query = _db.FilmoviOcjene.Include(x => x.Film).Include(x => x.Korisnik).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.FilmId.ToString()))
            {
                query = query.Where(x => x.FilmId == search.FilmId);
            }

            if (!string.IsNullOrWhiteSpace(search?.KorisnikId.ToString()))
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }



            var list = query.ToList();
            return _mapper.Map<List<Model.FilmoviOcjene>>(list);
        }

        public override void BeforeInsert(FilmoviOcjeneInsertRequest insert, FilmoviOcjene entity)
        {
            entity.DatumOcjene = DateTime.Now;
            base.BeforeInsert(insert, entity);
        }
    }
}
