using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public sealed class Bot
    {
        private static Bot _instance;

        public static Bot GetInstance()
        {
            return _instance ?? (_instance = new Bot());
        }

        private List<CardModel> HandSortedByValue = new List<CardModel>();
        private List<int> TableCards = new List<int>();

        private int IslandTotal = 0;
        private int CurrentRound = 0;

        public void UpdateTable(int IslandTotal, int CurrentRound, List<int> TableCards)
        {
            Bot b = GetInstance();
            b.CurrentRound = CurrentRound;
            b.IslandTotal = IslandTotal;
            b.TableCards = TableCards;
        }

        public void Initialize(List<string> cards)
        {
            List<CardModel> cardsList = cards.Select(c => Server.GetCardById(c)).ToList();

            Bot b = GetInstance();
            b.HandSortedByValue = cardsList;
            b.HandSortedByValue.Sort(delegate(CardModel x, CardModel y)
            {
                return x.CardId.CompareTo(y.CardId);
            });

            b.CurrentRound = 1;
        }

        public string ChoseGoatCard()
        {
            CardModel cardToPlay = HandSortedByValue[0];

            if (CurrentRound == 1)
            {
                var middleRandom = new Random().Next(3, 5);
                cardToPlay = HandSortedByValue[middleRandom];
            }

            HandSortedByValue = HandSortedByValue.Where(card => card.CardId != cardToPlay.CardId).ToList();
            return cardToPlay.CardId;
        }

        public string ChoseIslandCard(string[] IslandsToChoose)
        {
            if (CurrentRound == 1)
            {
                var random = new Random().Next(2);
                return IslandsToChoose[random];
            }

            return IslandsToChoose[0];
        }
    }
}
