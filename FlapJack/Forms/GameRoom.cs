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
            UpdateUserCards();
        }

        private void UpdateUserCards()
        {
            Cards = User.GetInstance().GetCards();

            pnlCards.Controls.Clear();
            foreach (var item in Cards.Select((cardId, i) => new { cardId, i }))
            {
                Card cardCpp = new Card();

                cardCpp.Height = (pnlCards.Height - 30);
                cardCpp.CardId = item.cardId;
                cardCpp.Location = new Point(item.i * cardCpp.Width, 15);

                pnlCards.Controls.Add(cardCpp);
            }
        }
    }
}
