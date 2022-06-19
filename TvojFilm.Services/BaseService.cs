using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Services.Database;

namespace TvojFilm.Services
{
    public class BaseService<TModel, TSearch, TDb> : IService<TModel, TSearch> where TDb : class
    {
        protected readonly TvojFilmContext _db;
        protected readonly IMapper _mapper;

        public BaseService(TvojFilmContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public virtual List<TModel> Get(TSearch search)
        {
            var list = _db.Set<TDb>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _db.Set<TDb>().Find(id);
            return _mapper.Map<TModel>(entity);

        }
    }
}
