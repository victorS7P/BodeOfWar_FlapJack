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
        public string[] UserCards = {};
        public string[] IslandCards = {};

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

        private GoatCardControl CreateDefaultGoatCard (string cardId, int index)
        {
            GoatCardControl card = new GoatCardControl();
            card.Height = (pnlCards.Height - 50);
            card.CardId = cardId;
            card.Location = new Point(index * card.Width, 0);

            return card;
        }

        private IslandCardControl CreateDeafultIslandCard (string cardValue, int index)
        {
            IslandCardControl card = new IslandCardControl();
            card.Height = (pnlCards.Height / 2);
            card.Width = card.Height;
            card.Value = cardValue;
            card.Location = new Point((index * card.Width) + 100, (pnlCards.Height / 4));

            return card;
        }

        private void UpdateCardsPanel(bool goatsCards, bool shouldSelect)
        {
            pnlCards.Controls.Clear();

            if (goatsCards)
            {
                UserCards = User.GetInstance().GetGoatCards();

                foreach (var item in UserCards.Select((cardId, i) => new { cardId, i }))
                {
                    GoatCardControl card = CreateDefaultGoatCard(item.cardId, item.i);

                    if (shouldSelect)
                    {
                        card.Cursor = Cursors.Hand;
                        card.MouseClick += SelectGoatCard;
                    }

                    pnlCards.Controls.Add(card);
                }
            } else
            {
                IslandCards = User.GetInstance().GetIslandCards();

                foreach (var item in IslandCards.Select((cardValue, i) => new { cardValue, i }))
                {
                    IslandCardControl card = CreateDeafultIslandCard(item.cardValue, item.i);

                    if (shouldSelect)
                    {
                        card.Cursor = Cursors.Hand;
                        card.MouseClick += SelectIslandCard;
                    }

                    pnlCards.Controls.Add(card);
                }
            }

            plsRoom.Refresh();
        }

        private void UpdateMatchRound()
        {
            try
            {
                RoundModel round = Server.GetMatchRound();
                CurrentMatch.SetCurrentRound(round);

                if (round.roundStatus == 'B' && round.player.id == User.GetInstance().id)
                {
                    UserShouldSelectGoatCard();
                }
                else if (round.roundStatus == 'I' && round.player.id == User.GetInstance().id)
                {
                    UserShouldSelectIslandCard();
                }
                else if (round.roundStatus == 'B')
                {
                    UserShouldAwaitForGoatCard();
                }
                else if (round.roundStatus == 'I')
                {
                    UserShouldAwaitForIslandCard();
                }
            } catch
            {
                CompleteMatch();
            }
        }

        private void SelectGoatCard(object sender, EventArgs e)
        {
            GoatCardControl card = (GoatCardControl)sender;
            Server.PlayAGoatCard(card.CardId);
            System.Threading.Thread.Sleep(100);
            UpdateMatchRound();
        }

        private void SelectIslandCard(object sender, EventArgs e)
        {
            IslandCardControl card = (IslandCardControl)sender;
            Server.PlayAIslandCard(card.Value);
            System.Threading.Thread.Sleep(100);
            UpdateMatchRound();
        }

        private void UserShouldSelectGoatCard()
        {
            gbxCards.Text = "Sua mão | Jogue uma carta";
            UpdateCardsPanel(true, true);
        }

        private void UserShouldSelectIslandCard()
        {
            gbxCards.Text = "Sua mão | Você ganhou a rodada, escolha uma ilha";
            UpdateCardsPanel(false, true);
        }

        private void UserShouldAwaitForGoatCard()
        {
            gbxCards.Text = "Sua mão | Esperando adversários jogarem seus bodes...";
            UpdateCardsPanel(true, false);
        }

        private void UserShouldAwaitForIslandCard()
        {
            gbxCards.Text = "Sua mão | Esperando adversário definir ilha...";
            UpdateCardsPanel(false, false);
        }

        private void CompleteMatch()
        {
            string text = Server.GetWinnerText();
            MessageBox.Show(this, text, "Partida encerrada!");
            this.Close();
        }

        private void plsRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
