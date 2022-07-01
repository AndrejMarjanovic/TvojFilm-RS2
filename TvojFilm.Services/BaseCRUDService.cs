using AutoMapper;
using TvojFilm.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvojFilm.Services
{
    public class BaseCRUDService<TModel, TSearch, TDb, TInsert, TUpdate> : BaseService<TModel, TSearch, TDb>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDb : class
    {
        public BaseCRUDService(TvojFilmContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDb>(request);
            _db.Set<TDb>().Add(entity);

            BeforeInsert(request, entity);

            _db.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _db.Set<TDb>().Find(id);
            _mapper.Map(request, entity);
            if (entity != null)
            {
                _db.Set<TDb>().Attach(entity);
                _db.Set<TDb>().Update(entity);
            }
           
            _db.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
        public virtual void Delete(int id)
        {
            var entity = _db.Set<TDb>().Find(id);
            _db.Remove(entity);
            _db.SaveChanges();

        }
        public virtual void BeforeInsert(TInsert insert, TDb entity)
        {

        }
    }

}
