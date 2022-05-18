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
        public CurrentMatch GameMatch;
        public User GameUser;
        public Bot GameBot;

        public TableModel CurrentTable = new TableModel();
        public RoundModel CurrentRound = new RoundModel();

        public string[] UserCards = {};
        public string[] IslandCards = {};

        public GameRoom()
        {
            InitializeComponent();
        }

        private void GameMatch_Load(object sender, EventArgs e)
        {
            Owner.Hide();
            Initialize();
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
            if (shouldSelect && !goatsCards)
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
            } else
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
            }

            plsRoom.Refresh();
        }

        private void UpdateMatchRound()
        {
            if (CurrentRound.roundStatus == 'B' && CurrentRound.player.id == GameUser.id)
            {
                UserShouldSelectGoatCard();
            }
            else if (CurrentRound.roundStatus == 'I' && CurrentRound.player.id == GameUser.id)
            {
                UserShouldSelectIslandCard();
            }
            else if (CurrentRound.roundStatus == 'B')
            {
                UserShouldAwaitForGoatCard();
            }
            else if (CurrentRound.roundStatus == 'I')
            {
                UserShouldAwaitForIslandCard();
            } else if (CurrentRound.roundStatus == 'E')
            {
                CompleteMatch();
            }
        }

        private void SelectGoatCard(object sender, EventArgs e)
        {
            GoatCardControl card = (GoatCardControl)sender;
            Server.PlayAGoatCard(card.CardId);
            UpdateMatchRound();
        }

        private void SelectIslandCard(object sender, EventArgs e)
        {
            IslandCardControl card = (IslandCardControl)sender;
            Server.PlayAIslandCard(card.Value);
            UpdateMatchRound();
        }

        private void UserShouldSelectGoatCard()
        {
            gbxCards.Text = "Sua mão | Jogue uma carta";
            UpdateCardsPanel(true, true);
            Server.PlayAGoatCard(GameBot.ChoseGoatCard());
        }

        private void UserShouldSelectIslandCard()
        {
            gbxCards.Text = "Sua mão | Você perdeu a rodada, escolha uma ilha";
            UpdateCardsPanel(false, true);
            Server.PlayAIslandCard(GameBot.ChoseIslandCard(IslandCards));
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

        private void Initialize()
        {
            CurrentMatch.GetInstance().players = Server.GetPlayers(CurrentMatch.GetInstance().id);
            GameMatch = CurrentMatch.GetInstance();
            plsRoom.Players = GameMatch.players;

            GameUser = User.GetInstance();
            UserCards = GameUser.GetGoatCards();

            GameBot = Bot.GetInstance();
            GameBot.Initialize(UserCards.ToList());
        }

        private void Think()
        {
            TableModel NextTable = Server.GetTable();
            RoundModel NextRound = Server.GetMatchRound();

            bool ChangedTable = (
                NextTable.LastPlayer != CurrentTable.LastPlayer ||
                NextTable.PlayersCards.Count != CurrentTable.PlayersCards.Count
            );

            bool ChangedRound = (
                NextRound.roundNumber != CurrentRound.roundNumber ||
                NextRound.roundStatus != CurrentRound.roundStatus ||
                NextRound.player.id != CurrentRound.player.id ||
                NextRound.roundStatus == 'E'
            );

            bool NeedToUpdate = ChangedTable || ChangedRound;

            if (NeedToUpdate)
            {
                CurrentTable = NextTable;
                CurrentRound = NextRound;

                UpdateMatchRound();
            }
        }
        
        private void tmrSelect_Tick(object sender, EventArgs e)
        {
            tmrSelect.Enabled = false;
            Think();
            
            if (CurrentRound.roundStatus != 'E')
            {
                tmrSelect.Enabled = true;
            }
        }
    }
}
