using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services
{
    public interface IService<T,TSearch> 
    {
        List<T> Get(TSearch search);
        T GetById(int id);
    }
}
