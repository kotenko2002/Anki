using AnkiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnkiAPI.Date
{
    public class SqlDataRepo : IDataRepo
    {
        private readonly AnkiDbContext _context;
        public SqlDataRepo(AnkiDbContext context)
        {
            _context = context;
        }

        public void CreateCard(Card card)
        {
            if(card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            _context.Cards.Add(card);
        }
        public void CreateDesk(Desk desk)
        {
            if (desk == null)
            {
                throw new ArgumentNullException(nameof(desk));
            }

            _context.Desks.Add(desk);
        }
        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public void DeleteCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }
            _context.Cards.Remove(card);
        }
        ///test
        public void DeleteCardsFromDesk(int id)
        {
            var desk = _context.Cards.Where(p => p.DeskId == id).ToList(); 
            _context.Cards.RemoveRange(desk);
        }

        public void DeleteDesk(Desk desk)
        {
            if (desk == null)
            {
                throw new ArgumentNullException(nameof(desk));
            }
            _context.Desks.Remove(desk);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards.ToList();
        }

        public async Task<IEnumerable<Card>> GetAllCardsFromDesk(int id)
        {
            return await _context.Cards.Where(p => p.DeskId == id).ToListAsync();
        }


        //public IEnumerable<Desk> GetAllDesks()
        //{
        //    return _context.Desks.ToList();
        //}

        public async Task<IEnumerable<Desk>> GetAllDesksFromUser(int id)
        {
            return await _context.Desks.Where(p => p.UserId == id).ToListAsync();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Card GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(p => p.Id == id);
        }

        public Desk GetDeskById(int id)
        {
            return _context.Desks.FirstOrDefault(p => p.Id == id);
        }

        public User GetUserByTgId(int tgId)
        {
            return _context.Users.FirstOrDefault(p => p.TgId == tgId);
        }

        public async Task<Translation> PartialTranslation(string text, string toLang)
        {
            if(toLang == "en")
            {
                Translation translation = new Translation();
                translation.Data = new Data();
                translation.Data.Translation = text;
                return translation;
            }
                
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://google-translate20.p.rapidapi.com/translate?text={text}&tl={toLang}"),
                Headers =
                {
                    { "x-rapidapi-key", "b95fa73ab0msh91303b3c6d9b433p1192cejsn54d92f111bed" },
                    { "x-rapidapi-host", "google-translate20.p.rapidapi.com" },
                },
            };
            using (var response = await Helper.ApiClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    Translation info = await response.Content.ReadAsAsync<Translation>();

                    return info;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<Translation> Translate(string text, string toLang)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://google-translate20.p.rapidapi.com/translate?text={text}&tl={toLang}"),
                Headers =
                {
                    { "x-rapidapi-key", "b95fa73ab0msh91303b3c6d9b433p1192cejsn54d92f111bed" },
                    { "x-rapidapi-host", "google-translate20.p.rapidapi.com" },
                },
            };
            using (var response = await Helper.ApiClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    Translation info = await response.Content.ReadAsAsync<Translation>();

                    return info;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
