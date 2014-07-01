using RobertTapping.PokerCodeTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertTapping.PokerCodeTest.Data.Repositories
{
    public class PokerDataRespository
    {

        private static PokerDataRespository _instance;

        private static PokerDataRespository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PokerDataRespository();


                return _instance;
            }
        }

        public List<CardModel> _deckOfCards;
        public List<CardModel> DeckOfCards { get { return _deckOfCards; } set { _deckOfCards = value; } }
        public List<PokerHand> PokerHands { get; set; }

        public PokerDataRespository()
        {
            DeckOfCards = new List<CardModel>();
            PokerHands = new List<PokerHand>();

            Enum.GetValues(typeof(CardSuite)).Cast<CardSuite>().ToList().ForEach(suite =>
                {
                      Enum.GetValues(typeof(CardRank)).Cast<CardRank>().ToList().ForEach(rank =>
                       {

                           DeckOfCards.Add(new CardModel() { CardRank = rank, CardSuite = suite });

                       });
                });
        }


        public PokerHand CreateNewPokerHand(string pokerHandsName)
        {
            var hand = new PokerHand(ref _deckOfCards)
            {
                PokerHandName = pokerHandsName,
                PokerHandID = Guid.NewGuid()
            };

            this.PokerHands.Add(hand);


            return hand;
        }


        public PokerHand GetPokerHandByGuid(Guid id)
        {
            return this.PokerHands.Where(a => a.PokerHandID == id).SingleOrDefault();
        }

        public bool UpdatePokerHand(Guid id, PokerHand item)
        {
            var pokerHand = this.PokerHands.Where(a => a.PokerHandID == id).SingleOrDefault();
            if(pokerHand != null)
            {
                pokerHand.PokerHandName = item.PokerHandName;
                return true;
            }
            return false;
        }

    }
}
