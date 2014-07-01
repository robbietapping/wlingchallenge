using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertTapping.PokerCodeTest.Data.Models
{
    public class PokerHand : Dictionary<int, CardModel>
    {

        public string PokerHandName { get; set; }
        public Guid PokerHandID { get; set; }

        public PokerHand(ref List<CardModel> playingDeck)
            : base()
        {
            DealHand(ref playingDeck);
        }

        public void DealHand(ref List<CardModel> playingDeck)
        {
            for (var i = 0; i <= 4; i++)
            {
                int randomNumber = new Random(1).Next(52);
                this.Add(this.Count() + 1, playingDeck[randomNumber]);
                playingDeck.RemoveAt(randomNumber);
            }            
        }


        /*
         * Below this point is the Model Workings to find out what type of Hand Rank a Player has
         * at any one given type of dealing a hand
         */


        public CardRank[] GetOrderedCardRanks()
        {
            return this.OrderBy(a => a.Value.CardRank).ToList().Select(a => a.Value.CardRank).ToArray();
        }

        public IDictionary<CardSuite, int> GetSuiteCardCounts()
        {

            Dictionary<CardSuite, int> collection = new Dictionary<CardSuite, int>();

            var query = from card in this.Select(a => new { a.Key, a.Value.CardSuite }).ToList()
                        group card.CardSuite by card.CardSuite into groupedCards
                        select new KeyValuePair<CardSuite, int>(groupedCards.Key, groupedCards.Count());

            query.ToList().ForEach(a => collection.Add(a.Key, a.Value));

            return collection;
        }

        public IDictionary<CardRank, int> GetRankCardCounts()
        {

            Dictionary<CardRank, int> collection = new Dictionary<CardRank, int>();

            var query = from card in this.Select(a => new { a.Key, a.Value.CardRank }).ToList()
                        group card.CardRank by card.CardRank into groupedCards
                        select new KeyValuePair<CardRank, int>(groupedCards.Key, groupedCards.Count());

            query.ToList().ForEach(a => collection.Add(a.Key, a.Value));

            return collection;
        }

        public bool IsStraightFlush
        {
            get
            {
                if (GetSuiteCardCounts().Max(a => a.Value) == 5)
                {
                    var remainder = GetOrderedCardRanks().Max() - GetOrderedCardRanks().Min();

                    return remainder == 4 ? true : false;
                }
                return false;
            }

        }

        public bool isFourOfTheSame
        {
            get
            {
                if (GetRankCardCounts().Max(b => b.Value) == 4)
                {
                    return true;
                }
                return false;
            }
        }

        public bool isThreeOfTheSame
        {
            get
            {
                if (GetRankCardCounts().Max(b => b.Value) == 3)
                {
                    return true;
                }
                return false;
            }
        }

        public bool isFullHouse
        {
        get {
            if (GetRankCardCounts().Where(a => a.Value == 3).Any() && GetRankCardCounts().Where(a => a.Value == 2).Any())
            {
                return true;
            }
            return false;
        }
        }

        public bool isFlush
        {get {
            if (GetSuiteCardCounts().Max(a => a.Value) == 5)
            {
                return true;
            }
            return false;
        }
        }

        public bool isStraight
        { get {
            var remainder = GetOrderedCardRanks().Max() - GetOrderedCardRanks().Min();

            return remainder == 4 ? true : false;
        }
        }


        public bool isTwoPair
        {get{
            var rankPairs = GetRankCardCounts().Where(a => a.Value == 2).ToList();

            return rankPairs.Count() == 2 ? true : false;
        }
        }

        public bool isPair
        { get {
            var rankPairs = GetRankCardCounts().Where(a => a.Value == 2).Any();

            return rankPairs;
        }
        }


        public bool isHighCard
        {
            get
            {
                var rankPairs = GetRankCardCounts().Where(a => a.Value == 1).ToList();

                return rankPairs.Count() == 5 ? true : false;
            }
        }

    }
}
