using RobertTapping.PokerCodeTest.Data.Models;
using RobertTapping.PokerCodeTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RobertTapping.PokerCodeTest.WebApi.Controllers
{
    public class PokerController : ApiController
    {

        public PokerCodeTest.Data.Repositories.PokerDataRespository Context;

        public PokerController()
        {
            Context = new PokerDataRespository();
        }


        [Route("poker/createNewHand")]
        public PokerHand CreateNewHand([FromBody]string handName)
        {
          var response =  Context.CreateNewPokerHand(handName);
          return response;
        }

        [Route("poker/dealToHand")]
        public PokerHand DealToHand([FromBody]PokerHand hand)
        {
            var response = Context.PokerHands.Where(a => a.PokerHandID == hand.PokerHandID).SingleOrDefault();
            response.Clear();
            response.DealHand(ref Context._deckOfCards);
            return response;
        }

        [Route("poker/getAllHands")]
        public List<PokerHand> GetAllHands()
        {
            var response = Context.PokerHands.ToList();
            return response;
        }


        [Route("poker/getCurrentDeck")]
        public List<CardModel> GetCurrentDeck()
        {
            var response = Context.DeckOfCards.ToList();
            return response;
        }



    }
}
