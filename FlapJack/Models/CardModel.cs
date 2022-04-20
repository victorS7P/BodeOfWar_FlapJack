using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public class CardModel
    {
        public string CardId;
        public string Goats;
        public string ImageId;

        static public CardModel FromServer(string serverCard)
        {
            CardModel card = new CardModel();

            string[] data = serverCard.Split(',');
            card.CardId = data[0];
            card.Goats = data[1];
            card.ImageId = data[2];

            return card;
        }
    }
}
