using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public sealed class CurrentMatch : Match
    {
        private CurrentMatch() { }
        private static CurrentMatch _instance;

        private Player currentPlayer;

        public static CurrentMatch GetInstance()
        {
            return _instance ?? (_instance = new CurrentMatch());
        }

        public static void SetCurrentMatch(Match match, Player currentPlayer)
        {
            CurrentMatch m = GetInstance();
            m.id = match.id;
            m.date = match.date;
            m.type = match.type;
            m.name = match.name;
            m.players = match.players;
        }

        public static Player GetCurrentPlayer()
        {
            CurrentMatch m = GetInstance();

            foreach (Player player in m.players)
            {
                if (player.id == m.currentPlayer.id)
                {
                    return player;
                }
            }

            return null;
        }
    }
}
