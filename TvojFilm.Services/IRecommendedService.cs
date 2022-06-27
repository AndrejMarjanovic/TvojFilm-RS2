using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvojFilm.Services
{
    public interface IRecommendedService
    {
        List<Model.Filmovi> RecommendedProduct(int id);

    }
}
