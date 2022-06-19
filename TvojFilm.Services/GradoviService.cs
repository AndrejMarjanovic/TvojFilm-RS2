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
    public class GradoviService : BaseCRUDService<Model.Gradovi, GradoviSearchRequest, Database.Gradovi, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }
        public override List<Model.Gradovi> Get(GradoviSearchRequest search)
        {
            var query = _db.Gradovi.Include(x => x.Drzava).AsQueryable();


            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                query = query.Where(x => x.Drzava.Naziv.ToLower().Contains(search.Drzava.ToLower()));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Gradovi>>(list);
        }
    }
}
