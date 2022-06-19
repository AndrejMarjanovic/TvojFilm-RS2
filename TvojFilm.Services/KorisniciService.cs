using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TvojFilm.Model.Requests;
using TvojFilm.Services.Database;

namespace TvojFilm.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly TvojFilmContext db;
        private readonly IMapper mapper;

        public KorisniciService(TvojFilmContext _db, IMapper map)
        {
            db = _db;
            mapper = map;

        }

        public List<Model.Korisnici> Get(KorisnikSearchRequest search)
        {
            var query = db.Korisnici.Include(x => x.Grad).Include(x => x.Uloga).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().Contains(search.Ime.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().Contains(search.Prezime.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search?.UlogaId.ToString()))
            {
                query = query.Where(x => x.UlogaId == search.UlogaId);
            }

            var list = query.ToList();
            return mapper.Map<List<TvojFilm.Model.Korisnici>>(list);

        }

        public Model.Korisnici GetbyId(int id)
        {
            var k = db.Korisnici.Find(id);

            return mapper.Map<TvojFilm.Model.Korisnici>(k);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }

        public Model.Korisnici Insert(KorisnikInsertRequest request)
        {
            var k = mapper.Map<Korisnici>(request);

            db.Add(k);

            if (request.Password != request.PasswordConfirm)
            {
                throw new System.Exception("Lozinke se ne poklapaju");
            }

            k.PasswordSalt = GenerateSalt();
            k.PasswordHash = GenerateHash(k.PasswordSalt, request.Password);

            db.SaveChanges();

            return mapper.Map<Model.Korisnici>(k);
        }


        public Model.Korisnici Update(int id, KorisnikUpdateRequest request)
        {
            var k = db.Korisnici.Find(id);

            k.Ime = request.Ime;
            k.Username = request.Username;
            k.Prezime = request.Prezime;
            k.Telefon = request.Telefon;
            k.GradId = request.GradId;
            k.UlogaId = request.UlogaId;
            k.Email = request.Email;
            k.DatumRodjenja = request.DatumRodjenja;
            k.Slika = request.Slika;

            db.SaveChanges();
            return mapper.Map<Model.Korisnici>(k);

        }

        public void Delete(int id)
        {
            var entity = db.Korisnici.Find(id);
            db.Remove(entity);
            db.SaveChanges();

        }
    }
}
