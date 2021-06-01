using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkiAPI.Date;
using AnkiAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AnkiAPI.Controllers
{
    [ApiController]
    public class AnkiApiController : ControllerBase
    {
        private readonly IDataRepo _repository;
        public AnkiApiController(IDataRepo repository)
        {
            _repository = repository;
            Helper.InitializeClient();
        }

        [Route("api/translate")]
        [HttpGet]
        public ActionResult<Card> SecTranslate([FromQuery] string text, string toLang)
        {
            var translation = _repository.Translate(text,toLang);
            return Ok(translation.Result);
        }
        

        [Route("api/part/translate")]
        [HttpGet]
        public ActionResult<Card> PartialTranslation([FromQuery] string text, string toLang)
        {
            var translation = _repository.PartialTranslation(text, toLang);
            return Ok(translation.Result);
        }

        [Route("api/cardshelp")]
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            var cardItems = _repository.GetAllCards();

            return Ok(cardItems);
        }

        [Route("api/cards/{id}")]
        [HttpGet]
        public ActionResult<Card> GetCardById(string id)
        {
            var cardItem = _repository.GetCardById(Convert.ToInt32(id));
            if(cardItem != null)
            {
                return Ok(cardItem);
            }
                
            return NotFound();
        }

        [Route("api/cards")]
        [HttpPost]
        public ActionResult<Card> CreateCard(Card card)
        {
            _repository.CreateCard(card);
            _repository.SaveChanges();

            return Ok(card);
        }

        [Route("api/users")]
        [HttpPost]
        public ActionResult<Card> CreateUser(User user)
        {
            _repository.CreateUser(user);
            _repository.SaveChanges();

            return Ok(user);
        }

        [Route("api/cards/{id}")]
        [HttpDelete]
        public ActionResult DeleteCard(string id)
        {
            var cardModelFromRepo = _repository.GetCardById(Convert.ToInt32(id));
            if (cardModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCard(cardModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [Route("api/desks/{id}")]
        [HttpDelete]
        public ActionResult DeleteDesk(string id)
        {
            var deskModelFromRepo = _repository.GetDeskById(Convert.ToInt32(id));
            if (deskModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCardsFromDesk(Convert.ToInt32(id));
            _repository.DeleteDesk(deskModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //[Route("api/deskshelp")]
        //[HttpGet]
        //public ActionResult<IEnumerable<Desk>> GetAllDesks()
        //{
        //    var deskItems = _repository.GetAllDesks();

        //    return Ok(deskItems);
        //}

        [Route("api/users")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();

            return Ok(userItems);
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public ActionResult<Card> GetUserByTgId(string id)
        {
            var cardItem = _repository.GetUserByTgId(Convert.ToInt32(id));
            if (cardItem != null)
            {
                return Ok(cardItem);
            }

            return NotFound();
        }
        [Route("api/desks/{id}")]
        [HttpGet]
        public async Task<IEnumerable<Card>> GetAllCardsFromDesk(string id)
        {
            var cards = await _repository.GetAllCardsFromDesk(Convert.ToInt32(id));

            return cards;
        }

        [Route("api/users/desks/{id}")]
        [HttpGet]
        public async Task<IEnumerable<Desk>> GetAllDesksFromUser(string id)
        {
            var desks = await _repository.GetAllDesksFromUser(Convert.ToInt32(id));

            return desks;
        }

        [Route("api/desks")]
        [HttpPost]
        public ActionResult<Desk> CreateDesk(Desk desk)
        {
            _repository.CreateDesk(desk);
            _repository.SaveChanges();

            return Ok(desk);
        }

        [Route("api/cards/{id}")]
        [HttpPatch]
        public ActionResult PartialInfoUpdate(string id, [FromBody] JsonPatchDocument<Card> patchDoc)
        {
            var cardModelFromRepo = _repository.GetCardById(Convert.ToInt32(id));
            if (cardModelFromRepo == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(cardModelFromRepo, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.SaveChanges();
            return NoContent();
        }

        //[Route("api/cards/{id}")]
        //[HttpPut]
    }
}
