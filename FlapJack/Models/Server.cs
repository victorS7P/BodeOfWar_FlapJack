using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodeOfWarServer;

namespace FlapJack
{
    public class Server
    {
        public static Dictionary<char, string> MATCHES_NAMES = new Dictionary<char, string>
        {
            { 'T', "Todas" },
            { 'A', "Abertas" },
            { 'J', "Jogando" },
            { 'F', "Finalizadas" }
        };

        public static string[] GetStrData (string data)
        {
            if (data.Contains("ERRO:"))
            {
                throw new Exception(data.Replace("ERRO:", ""));
            }

            return data.Replace("\n\n", "\n").Split('\n');
        }

        public static string version { get; set; } = Jogo.Versao;

        public static List<Match> GetMatches(char type)
        {
            string matchesStr = Jogo.ListarPartidas(type.ToString());
            string[] matchesStrList = GetStrData(matchesStr);

            return matchesStrList.Where(m => m != null && m.Length > 0).Select(m => Match.FromServer(m)).ToList();
        }

        public static List<Player> GetPlayers(string matchId)
        {
            string playersStr = Jogo.ListarJogadores(int.Parse(matchId));
            string[] playersStrList = GetStrData(playersStr);

            return playersStrList.Where(p => p != null && p.Length > 0).Select(p => Player.FromServer(p)).ToList();
        }

        public static List<MatchType> GetMatchTypes()
        {
            return new List<MatchType>
            {
                MatchType.FromType('T'),
                MatchType.FromType('A'),
                MatchType.FromType('J'),
                MatchType.FromType('F')
            };
        }

        public static Match CreateMatch(string name, string password)
        {
            string matchIdStr = Jogo.CriarPartida(name, password);
            string matchId = GetStrData(matchIdStr)[0];

            Match match = new Match();

            match.id = matchId;
            match.name = name;
            match.date = DateTime.Now.ToString("dd/MM/yyyy");
            match.type = MatchType.FromType('A');

            return match;
        }

        public static void JoinMatch(Match match, Player player, string password)
        {
            string serverStr = Jogo.EntrarPartida(int.Parse(match.id), player.name, password);
            string[] data = GetStrData(serverStr);

            User.SetUser(data[0], player);
        }

        public static void StartMatch(Match match)
        {
            string serverStr = Jogo.IniciarPartida(int.Parse(User.GetInstance().id), User.GetInstance().password);
            string firstPlayerId = GetStrData(serverStr)[0];

            Player player = new Player();
            player.id = firstPlayerId;

            CurrentMatch.SetCurrentMatch(match, player);
        }
    }
}
