using AutoMapper;
using TvojFilm.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvojFilm.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Drzave, Model.Requests.DrzaveInsertRequest>().ReverseMap();
            CreateMap<Drzave, Model.Drzave>().ReverseMap();

            CreateMap<Gradovi, Model.Requests.GradoviInsertRequest>().ReverseMap();
            CreateMap<Gradovi, Model.Gradovi>().ReverseMap();

            CreateMap<Zanrovi, Model.Requests.ZanroviInsertRequest>().ReverseMap();
            CreateMap<Zanrovi, Model.Zanrovi>().ReverseMap();

            CreateMap<Uloge, Model.Requests.UlogeInsertRequest>().ReverseMap();
            CreateMap<Uloge, Model.Uloge>().ReverseMap();

            CreateMap<Redatelji, Model.Requests.RedateljiInsertRequest>().ReverseMap();
            CreateMap<Redatelji, Model.Redatelji>().ReverseMap();
            
            CreateMap<Glumci, Model.Requests.GlumciInsertRequest>().ReverseMap();
            CreateMap<Glumci, Model.Glumci>().ReverseMap();

            CreateMap<Filmovi, Model.Requests.FilmoviInsertRequest>().ReverseMap();
            CreateMap<Filmovi, Model.Filmovi>().ReverseMap();

            CreateMap<Korisnici, Model.Requests.KorisnikInsertRequest>().ReverseMap();
            CreateMap<Korisnici, Model.Requests.KorisnikRegisterRequest>().ReverseMap();
            CreateMap<Korisnici, Model.Korisnici>().ReverseMap();

            CreateMap<FilmoviKomentari, Model.Requests.FilmoviKomentariInsertRequest>().ReverseMap();
            CreateMap<FilmoviKomentari, Model.FilmoviKomentari>().ReverseMap();

            CreateMap<FilmoviOcjene, Model.Requests.FilmoviOcjeneInsertRequest>().ReverseMap();
            CreateMap<FilmoviOcjene, Model.FilmoviOcjene>().ReverseMap();

            CreateMap<KupnjaFilmova, Model.Requests.KupnjaFilmovaInsertRequest>().ReverseMap();
            CreateMap<KupnjaFilmova, Model.KupnjaFilmova>().ReverseMap();

            CreateMap<PrijedloziFilmova, Model.Requests.PrijedloziFilmovaInsertRequest>().ReverseMap();
            CreateMap<PrijedloziFilmova, Model.PrijedloziFilmova>().ReverseMap();


        }
    }
}
