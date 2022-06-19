using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;

namespace TvojFilm.Services
{
    public interface IDrzaveService : ICRUDService<Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest>
    {
    }
}
