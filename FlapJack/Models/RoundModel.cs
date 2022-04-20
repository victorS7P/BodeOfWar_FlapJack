using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public class RoundModel
    {
        public static Dictionary<char, string> ROUND_STATUS = new Dictionary<char, string>
        {
            { 'B', "Bode" },
            { 'I', "Ilha" },
            { 'F', "Finalizada" }
        };

        public Player player;
        public int roundNumber;
        public char roundStatus;
        
        static public RoundModel FromServer(string serverRound)
        {
            RoundModel round = new RoundModel();

            string[] data = serverRound.Split(',');
            round.player = CurrentMatch.GetPlayer(data[1]);
            round.roundNumber = int.Parse(data[2]);
            round.roundStatus = char.Parse(data[3]);

            return round;
        }
    }
}
