using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobertTapping.PokerCodeTest.WebApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_PokerHand_Dealing()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");
            var hand2 = repo.CreateNewPokerHand("Robbie2");
            var hand3 = repo.CreateNewPokerHand("Robbie3");
            var hand4 = repo.CreateNewPokerHand("Robbie4");

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand2.Count == 5);
            Assert.IsTrue(hand3.Count == 5);
            Assert.IsTrue(hand4.Count == 5);

        }

        [TestMethod]
        public void Test_Is_Straight_Flush()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Five, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Six, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Seven, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Eight, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Nine, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isStraight);

        }

        [TestMethod]
        public void Test_Is_Flush()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.King, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Six, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Two, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Eight, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Jack, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isFlush);

        }

        [TestMethod]
        public void Test_Is_Four_Of_A_Kind()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Diamonds });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Hearts });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Spades });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Nine, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isFourOfTheSame);

        }


        [TestMethod]
        public void Test_Is_Full_House()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.King, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.King, CardSuite = Data.Models.CardSuite.Diamonds });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.King, CardSuite = Data.Models.CardSuite.Hearts });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ten, CardSuite = Data.Models.CardSuite.Spades });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ten, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isFullHouse);

        }

        [TestMethod]
        public void Test_Is_Straight()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Five, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Six, CardSuite = Data.Models.CardSuite.Diamonds });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Seven, CardSuite = Data.Models.CardSuite.Hearts });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Eight, CardSuite = Data.Models.CardSuite.Spades });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Nine, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isStraight);

        }

        [TestMethod]
        public void Test_Is_Pair()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Diamonds });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Seven, CardSuite = Data.Models.CardSuite.Hearts });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Eight, CardSuite = Data.Models.CardSuite.Spades });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Nine, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isPair);

        }

        [TestMethod]
        public void Test_Is_TwoPair()
        {

            var repo = new PokerCodeTest.Data.Repositories.PokerDataRespository();
            var hand = repo.CreateNewPokerHand("Robbie");

            hand.Clear();
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Clubs });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Ace, CardSuite = Data.Models.CardSuite.Diamonds });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Two, CardSuite = Data.Models.CardSuite.Hearts });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Two, CardSuite = Data.Models.CardSuite.Spades });
            hand.Add(hand.Count + 1, new Data.Models.CardModel() { CardRank = Data.Models.CardRank.Nine, CardSuite = Data.Models.CardSuite.Clubs });

            Assert.IsTrue(hand.Count == 5);
            Assert.IsTrue(hand.isTwoPair);

        }
    }
}
