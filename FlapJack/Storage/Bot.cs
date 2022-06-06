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

        private int Goats = 0;
        private int IslandTotal = 0;
        private int CurrentRoundNumber = 0;

        public void Reset()
        {
            _instance = null;
        }

        public void UpdateTable(List<int> NewTableCards)
        {
            Bot b = GetInstance();
            b.TableCards = NewTableCards;
        }

        public void UpdateRound(int NewIslandTotal, int NewCurrentRound, int NewGoats)
        {
            Bot b = GetInstance();
            b.CurrentRoundNumber = NewCurrentRound;
            b.IslandTotal = NewIslandTotal;
            b.Goats += NewGoats;
        }

        public void UpdateBotInfo()
        {
            TableModel CurrentTable = Server.GetTable();
            RoundModel CurrentRound = Server.GetMatchRound();

            TableCards = CurrentTable.GetTableCards();
            IslandTotal = CurrentTable.IslandValue;
            CurrentRoundNumber = CurrentRound.roundNumber;
            Goats = Server.CountUserGoats(CurrentRoundNumber);
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

            b.CurrentRoundNumber = 1;
        }

        public CardModel PickMiddleRandomCard()
        {
            int TotalCards = HandSortedByValue.Count();
            int MiddleCard = (TotalCards / 2);

            int MiddleRandom = MiddleCard;
            if (TotalCards >= 2 && TotalCards % 2 == 0)
            {
                MiddleRandom = new Random().Next((MiddleCard - 1), (MiddleCard + 1));
            }

            return HandSortedByValue[MiddleRandom];
        }

        public CardModel PickFirstHighCard()
        {
            int TotalCards = HandSortedByValue.Count();
            int MiddleCard = (TotalCards / 2);

            if (MiddleCard == (TotalCards - 1))
            {
                return HandSortedByValue[MiddleCard];
            }

            return HandSortedByValue[MiddleCard + 1];
        }

        public CardModel PickFirstLowerCard()
        {
            int TotalCards = HandSortedByValue.Count();
            int MiddleCard = (TotalCards / 2);

            if (MiddleCard == 0)
            {
                return HandSortedByValue[0];
            }

            return HandSortedByValue[MiddleCard - 1];
        }

        public CardModel PickCardToWinGoats(int MaxCardsOnTableToPickRandom)
        {
            if (TableCards.Count() <= MaxCardsOnTableToPickRandom)
            {
                return PickFirstHighCard();
            }

            try
            {
                return HandSortedByValue.First(c => int.Parse(c.CardId) > TableCards.Max());
            } catch
            {
                return PickFirstHighCard();
            }
        }

        public CardModel PickCardToChoseIsland(int MaxCardsOnTableToPickRandom)
        {
            if (TableCards.Count() <= MaxCardsOnTableToPickRandom)
            {
                return PickFirstLowerCard();
            }

            try
            {
                return HandSortedByValue.First(c => int.Parse(c.CardId) < TableCards.Min());
            } catch
            {
                return PickFirstLowerCard();
            }
        }

        public CardModel PickRandomCardAvoidingManyGoats(int LimitGoats)
        {
            CardModel Card = new CardModel();
            List<CardModel> HandBackup = new List<CardModel>(HandSortedByValue);

            while (true)
            {
                Card = PickMiddleRandomCard();

                if (Goats + int.Parse(Card.Goats) < LimitGoats)
                {
                    break;
                }

                HandSortedByValue.Remove(Card);

                if (HandSortedByValue.Count == 0)
                {
                    Card = PickMiddleRandomCard();
                    break;
                }
            }

            HandSortedByValue = new List<CardModel>(HandBackup);
            return Card;
        }

        public CardModel PickCardToWinGoatsAvoidingMany(int LimitGoats)
        {
            CardModel Card = new CardModel();
            List<CardModel> HandBackup = new List<CardModel>(HandSortedByValue);

            while (true)
            {
                Card = PickCardToWinGoats(1);

                if (Goats + int.Parse(Card.Goats) < LimitGoats)
                {
                    break;
                }

                HandSortedByValue.Remove(Card);

                if (HandSortedByValue.Count == 0)
                {
                    Card = PickCardToWinGoats(1);
                    break;
                }
            }

            HandSortedByValue = new List<CardModel>(HandBackup);
            return Card;
        }

        public CardModel TryToLoseCardWithManyGoats()
        {
            List<CardModel> HandByMostGoats = HandSortedByValue.OrderByDescending(c => int.Parse(c.Goats)).ToList();

            CardModel CardToLose = HandByMostGoats.First();
            CardModel CardToKeep = HandByMostGoats.Last();

            if (TableCards.Exists(value => value > int.Parse(CardToLose.CardId)))
            {
                return CardToLose;
            }

            if (TableCards.TrueForAll(value => value < int.Parse(CardToKeep.CardId)))
            {
                return CardToKeep;
            }

            return CardToLose;
        }

        public CardModel TryToWinWithMostGoats()
        {
            List<CardModel> HandByMostGoats = HandSortedByValue.OrderByDescending(c => int.Parse(c.Goats)).ToList();

            CardModel CardToWin = HandByMostGoats.First();
            CardModel OtherCard = HandByMostGoats.Last();

            if (TableCards.Count > 1 && TableCards.TrueForAll(value => int.Parse(CardToWin.CardId) > value))
            {
                return CardToWin;
            }

            return OtherCard;
        }

        public string ChoseGoatCard()
        {
            UpdateBotInfo();

            CardModel CardToPlay = HandSortedByValue[0];
            int RoundsLeft = (8 - CurrentRoundNumber);
            
            if (CurrentRoundNumber == 1)
            {
                CardToPlay = PickMiddleRandomCard();
            }

            else if (2 <= CurrentRoundNumber && CurrentRoundNumber <= 4)
            {
                int MinGoats = (IslandTotal / 2) - 1;
                int MaxGoats = (IslandTotal / 2) + 1;

                if (MinGoats <= Goats && Goats <= MaxGoats)
                {
                    CardToPlay = PickMiddleRandomCard();
                }

                else if (Goats < MinGoats)
                {
                    CardToPlay = PickCardToWinGoats(1);
                }

                else
                {
                    CardToPlay = PickCardToChoseIsland(1);
                }
            }

            else if (5 <= CurrentRoundNumber && CurrentRoundNumber <= 6)
            {
                double HandGoatsAVG = HandSortedByValue.Select(c => double.Parse(c.Goats)).Average();

                int MinGoats = ((2 / 3) * IslandTotal) - 1;
                int MaxGoats = ((2 / 3) * IslandTotal) + 1;

                if (MinGoats <= Goats && Goats <= MaxGoats)
                {
                    CardToPlay = PickRandomCardAvoidingManyGoats(IslandTotal - RoundsLeft + 1);
                }

                else if (Goats < MinGoats) 
                {
                    CardToPlay = PickCardToWinGoatsAvoidingMany(IslandTotal - RoundsLeft + 1);
                }

                else
                {
                    CardToPlay = PickCardToChoseIsland(1);
                }
            }

            else if (CurrentRoundNumber == 7)
            {
                List<CardModel> CardsToLoseCard = HandSortedByValue.Where(c => (int.Parse(c.Goats) + Goats) >= IslandTotal).ToList();
                bool ThereIsOneCardThatLose = (CardsToLoseCard.Count == 1);
                bool BothCardsLoss = (CardsToLoseCard.Count == 2);
                bool NeedBothCardsToWin = (HandSortedByValue.Select(c => int.Parse(c.Goats)).Sum() + Goats) <= IslandTotal;
                bool OnlyOneCardToWin = !NeedBothCardsToWin && !ThereIsOneCardThatLose && !BothCardsLoss;

                if (BothCardsLoss)
                {
                    CardToPlay = PickCardToChoseIsland(0);
                }

                else if (ThereIsOneCardThatLose)
                {
                    CardToPlay = TryToLoseCardWithManyGoats();
                }

                else if (NeedBothCardsToWin)
                {
                    CardToPlay = PickCardToWinGoats(0);
                }

                else if (OnlyOneCardToWin)
                {
                    CardToPlay = TryToWinWithMostGoats();
                }
            }

            HandSortedByValue = HandSortedByValue.Where(card => card.CardId != CardToPlay.CardId).ToList();
            return CardToPlay.CardId;
        }

        public string PlayLowestIsland(string[] IslandsToChoose)
        {
            return (int.Parse(IslandsToChoose[0]) > int.Parse(IslandsToChoose[1]))
                ? IslandsToChoose[1]
                : IslandsToChoose[0];
        }

        public string PlayHighestIsland(string[] IslandsToChoose)
        {
            return (int.Parse(IslandsToChoose[0]) < int.Parse(IslandsToChoose[1]))
                ? IslandsToChoose[1]
                : IslandsToChoose[0];
        }

        public string ChoseIslandCard(string[] IslandsToChoose)
        {
            UpdateBotInfo();

            int MinIslandPoints = (Goats * 2);

            bool FirstIslandFit = int.Parse(IslandsToChoose[0]) >= MinIslandPoints;
            bool SecondIslandFit = int.Parse(IslandsToChoose[1]) >= MinIslandPoints;

            if (!SecondIslandFit)
            {
                return IslandsToChoose[0];
            }

            else if (!FirstIslandFit)
            {
                return IslandsToChoose[1];
            }

            else if (!SecondIslandFit && !FirstIslandFit)
            {
                return PlayLowestIsland(IslandsToChoose);
            }

            else
            {
                return PlayHighestIsland(IslandsToChoose);
            }
        }
    }
}
