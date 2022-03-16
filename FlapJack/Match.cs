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
        public string status { get; set; }

        static public Match FromServer(string serverMatch)
        {
            Match match = new Match();

            string[] data = serverMatch.Split(',');
            match.id = int.Parse(data[0]);
            match.name = data[1];
            match.date = data[2];
            match.status = data[3].Replace("\r", "");

            return match;
        }
    }
}
