
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;

namespace TvojFilm.Services
{
    public interface IUlogeService : ICRUDService<Model.Uloge, UlogeSearchRequest, UlogeInsertRequest, UlogeInsertRequest>
    {
    }
}