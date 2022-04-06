using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public class Player
    {
        public string id { get; set; }
        public string name { get; set; }

        static public Player FromServer(string serverPlayer)
        {
            Player player = new Player();

            string[] data = serverPlayer.Split(',');
            player.id = data[0];
            player.name = data[1];

            return player;
        }

        public override string ToString()
        {
            User user = User.GetInstance();
            string currentPlayerId = CurrentMatch.GetCurrentPlayer().id;

            string result = name;
            if (user.id == id)
            {
                result += " (Você)";
            }

            if (currentPlayerId == id)
            {
                result += " (jogando)";
            }

            return result;
        }
    }
}
