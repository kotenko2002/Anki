using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnkiAPI.Models;

namespace AnkiAPI.Date
{
    public interface IDataRepo
    {
        bool SaveChanges();

        Task<IEnumerable<Card>> GetAllCardsFromDesk(int id);
        //Task<IEnumerable<Card>> GetAllCardsFromUser(int id);
        Task<IEnumerable<Desk>> GetAllDesksFromUser(int id);


        IEnumerable<User> GetAllUsers();
        //IEnumerable<Desk> GetAllDesks();//убрать
        IEnumerable<Card> GetAllCards();//убрать
        User GetUserByTgId(int tgId);
        Desk GetDeskById(int id);
        Card GetCardById(int id);

        void CreateCard(Card card);
        void CreateDesk(Desk desk); 
        void CreateUser(User user);

        void DeleteCard(Card card);
        void DeleteCardsFromDesk(int id);
        void DeleteDesk(Desk desk);
        Task<Translation> Translate(string text, string toLang);
        Task<Translation> PartialTranslation(string text, string toLang);
    }
}
