using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlapJack
{
    public partial class GameRoom : Form
    {
        public string[] Cards = {};

        public GameRoom()
        {
            InitializeComponent();
        }

        private void GameMatch_Load(object sender, EventArgs e)
        {
            Owner.Hide();
            plsRoom.Players = CurrentMatch.GetInstance().players;

            UpdateMatchRound();
        }

        private Card CreateDefaultCard (string cardId, int index)
        {
            Card card = new Card();
            card.Height = (pnlCards.Height - 50);
            card.CardId = cardId;
            card.Location = new Point(index * card.Width, 0);

            return card;
        }

        private void UpdateCardsPanel(bool shouldSelect)
        {
            pnlCards.Controls.Clear();
            foreach (var item in Cards.Select((cardId, i) => new { cardId, i }))
            {
                Card card = CreateDefaultCard(item.cardId, item.i);

                if (shouldSelect)
                {
                    card.Cursor = Cursors.Hand;
                    card.MouseClick += SelectGoatCard;
                }

                pnlCards.Controls.Add(card);
            }
        }

        private void UpdateMatchRound()
        {
            RoundModel round = Server.GetMatchRound();
            CurrentMatch.SetCurrentRound(round);

            Cards = User.GetInstance().GetCards();

            if (round.roundStatus == 'B' && round.player.id == User.GetInstance().id)
            {
                UserShouldSelectGoatCard();
            } else if (round.roundStatus == 'I' && round.player.id == User.GetInstance().id)
            {
                UserShouldSelectIslandCard();
            } else if (round.roundStatus == 'B')
            {
                UserShouldAwaitForGoatCard();
            } else if (round.roundStatus == 'I')
            {
                UserShouldAwaitForIslandCard();
            } else
            {
                CompleteMatch();
            }
        }

        private void SelectGoatCard(object sender, EventArgs e)
        {
            Card card = (Card)sender;
            Server.PlayACard(card.CardId);
            System.Threading.Thread.Sleep(100);
            UpdateMatchRound();
        }

        private void UserShouldSelectGoatCard()
        {
            gbxCards.Text = "Jogue uma carta";
            UpdateCardsPanel(true);
        }

        private void UserShouldSelectIslandCard()
        {
            gbxCards.Text = "Cartas na mão";
            UpdateCardsPanel(false);
        }

        private void UserShouldAwaitForGoatCard()
        {
            gbxCards.Text = "Cartas na mão";
            UpdateCardsPanel(false);
        }

        private void UserShouldAwaitForIslandCard()
        {
            gbxCards.Text = "Cartas na mão";
            UpdateCardsPanel(false);
        }

        private void CompleteMatch()
        {

        }
    }
}
