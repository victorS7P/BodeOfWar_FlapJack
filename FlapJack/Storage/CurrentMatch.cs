using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public sealed class CurrentMatch : Match
    {
        private static CurrentMatch _instance;
        public static CurrentMatch GetInstance()
        {
            return _instance ?? (_instance = new CurrentMatch());
        }

        private RoundModel currentRound = null;
        public Player currentPlayer = new Player();

        public void Reset()
        {
            _instance = null;
        }

        public static void SetCurrentMatch(Match match, Player currentPlayer)
        {
            CurrentMatch m = GetInstance();
            m.id = match.id;
            m.date = match.date;
            m.type = match.type;
            m.name = match.name;
            m.players = match.players;
            m.currentPlayer = currentPlayer;
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

            return new Player();
        }

        public static Player GetPlayer(string playerId)
        {
            return GetInstance().players.First(p => p.id == playerId);
        }

        public static void SetCurrentRound (RoundModel round)
        {
            CurrentMatch m = GetInstance();
            m.currentRound = round;
            m.currentPlayer = round.player;
        }

        public static RoundModel GetCurrentRound()
        {
            return GetInstance().currentRound;
        }
    }
}
