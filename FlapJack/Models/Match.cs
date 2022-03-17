using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    internal class Match
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public MatchType type { get; set; }

        static public Match FromServer(string serverMatch)
        {
            Match match = new Match();

            string[] data = serverMatch.Split(',');
            match.id = int.Parse(data[0]);
            match.name = data[1];
            match.date = data[2];
            match.type = MatchType.FromType(data[3].Replace("\r", "").ToCharArray()[0]);

            return match;
        }
    }
}
