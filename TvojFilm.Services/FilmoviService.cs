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
    public class FilmoviService : BaseCRUDService<Model.Filmovi, FilmoviSearchRequest, Database.Filmovi, FilmoviInsertRequest, FilmoviInsertRequest>
    {
        public FilmoviService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Filmovi> Get(FilmoviSearchRequest search)
        {
            var query = _db.Filmovi.Include(x => x.Redatelj).Include(x => x.Zanr).Include(x => x.Drzava).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivFilma))
            {
                query = query.Where(x => x.NazivFilma.ToLower().Contains(search.NazivFilma.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Redatelj))
            {
                query = query.Where(x => x.Redatelj.Ime.ToLower().Contains(search.Redatelj.ToLower()) || x.Redatelj.Prezime.ToLower().Contains(search.Redatelj.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.ZanrId.ToString()))
            {
                query = query.Where(x => x.ZanrId == search.ZanrId);
            }
            if (!string.IsNullOrWhiteSpace(search?.DrzavaId.ToString()))
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Filmovi>>(list);
        }


    }
}
