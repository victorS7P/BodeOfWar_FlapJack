using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodeOfWarServer;

namespace FlapJack
{
    internal class Server
    {
        public static string version { get; set; } = Jogo.Versao;

        public static List<Match> getMatches(string status)
        {
            string matchesStr = Jogo.ListarPartidas(status);
            string[] matches = matchesStr.Replace("\n\n", "\n").Split('\n');

            return matches.Where(m => m != null && m.Length > 0).Select(m => Match.FromServer(m)).ToList();
        }
    }
}
