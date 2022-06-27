using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvojFilm.Model;
using TvojFilm.Services.Database;
using TvojFilm.Services;

namespace TvojFilm.Services
{
    public class RecomendedService : IRecommendedService
    {
        private readonly TvojFilmContext _context;
        private readonly IMapper _mapper;
        public RecomendedService(TvojFilmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        Dictionary<int, List<Database.FilmoviOcjene>> proizvodi = new Dictionary<int, List<Database.FilmoviOcjene>>();

        private List<Database.Filmovi> LoadSimilar(int proizvodid)
        {
            LoadOtherProduct(proizvodid);
            List<Database.FilmoviOcjene> ratingOfCurrent = _context.FilmoviOcjene.Where(x => x.FilmId == proizvodid).OrderBy(x => x.KorisnikId).ToList();

            List<Database.FilmoviOcjene> ratings1 = new List<Database.FilmoviOcjene>();
            List<Database.FilmoviOcjene> ratings2 = new List<Database.FilmoviOcjene>();
            List<Database.Filmovi> recommendedProduct = new List<Database.Filmovi>();

            foreach (var product in proizvodi)
            {
                foreach (Database.FilmoviOcjene rating in ratingOfCurrent)
                {
                    if (product.Value.Where(w => w.KorisnikId == rating.KorisnikId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(product.Value.Where(w => w.KorisnikId == rating.KorisnikId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recommendedProduct.Add(_context.Filmovi.Where(w => w.FilmId == product.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedProduct;
        }

        private double GetSimilarity(List<Database.FilmoviOcjene> ratings1, List<Database.FilmoviOcjene> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }
            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].Ocjena * ratings2[i].Ocjena;
                y1 += ratings1[i].Ocjena * ratings1[i].Ocjena;
                y2 += ratings2[i].Ocjena * ratings2[i].Ocjena;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }
        private void LoadOtherProduct(int proizvodid)
        {
            List<Database.Filmovi> list = _context.Filmovi.Where(w => w.FilmId != proizvodid).ToList();
            List<Database.FilmoviOcjene> ratings = new List<Database.FilmoviOcjene>();
            foreach (var item in list)
            {
                ratings = _context.FilmoviOcjene.Where(w => w.FilmId == item.FilmId).OrderBy(w => w.FilmId).ToList();
                if (ratings.Count > 0)
                {
                    proizvodi.Add(item.FilmId, ratings);
                }
            }

        }

        public List<Model.Filmovi> RecommendedProduct(int proizvodid)
        {

            var tmp = LoadSimilar(proizvodid);
            return _mapper.Map<List<Model.Filmovi>>(tmp);

        }
    }
}
