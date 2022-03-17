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
        public static Dictionary<char, string> MATCHES_NAMES = new Dictionary<char, string>
        {
            { 'T', "Todas" },
            { 'A', "Abertas" },
            { 'J', "Jogando" },
            { 'E', "Encerradas" }
        };

        public static string version { get; set; } = Jogo.Versao;

        public static List<Match> GetMatches(char type)
        {
            string matchesStr = Jogo.ListarPartidas(type.ToString());
            string[] matches = matchesStr.Replace("\n\n", "\n").Split('\n');

            return matches.Where(m => m != null && m.Length > 0).Select(m => Match.FromServer(m)).ToList();
        }

        public static List<MatchType> GetMatchTypes()
        {
            return new List<MatchType>
            {
                MatchType.FromType('T'),
                MatchType.FromType('A'),
                MatchType.FromType('J'),
                MatchType.FromType('E')
            };
        }
    }
}
