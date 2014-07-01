using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertTapping.PokerCodeTest.Data.Models
{
    public class CardModel
    {
        public CardRank CardRank { get; set; }
        public CardSuite CardSuite { get; set; }
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
        
    }

    public enum CardSuite
    {
        Hearts = 1,
        Diamonds = 2,
        Spades = 3,
        Clubs = 4
    }
}
