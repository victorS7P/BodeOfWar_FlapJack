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
    public partial class GoatCardControl : UserControl
    {
        public String CardId { get; set; } = "1";

        public GoatCardControl()
        {
            InitializeComponent();
        }

        private void UpdateCard()
        {
            if (CardId != null)
            {
                CardModel card = Server.GetCards().First(c => c.CardId == CardId);

                if (card != null)
                {
                    pnlCard.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("b" + card.ImageId);
                    lblGoats.Text = card.Goats;
                    lblId.Text = card.CardId;
                }
            }
        }

        private void Card_Load(object sender, EventArgs e)
        {
            UpdateCard();
        }

        private void pnlCard_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
    }
}
