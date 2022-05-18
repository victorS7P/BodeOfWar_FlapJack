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
        public static List<CardModel> GameGoatCards = new List<CardModel>();

        public static Dictionary<char, string> MATCHES_NAMES = new Dictionary<char, string>
        {
            { 'T', "Todas" },
            { 'A', "Aberta" },
            { 'J', "Jogando" },
            { 'E', "Encerrada" }
        };

        public static string[] GetStrData (string data)
        {
            if (data.Contains("ERRO:"))
            {
                throw new Exception(data.Replace("ERRO:", ""));
            }

            return data
                .Replace("\n\n", "\n")
                .Split('\n')
                .Select(id => id.Replace("\r", ""))
                .Where(c => c.Count() > 0)
                .ToArray();
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
                MatchType.FromType('E')
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

        public static bool MatchHasStarted(Match match)
        {
            return Jogo.ExibirNarracao(int.Parse(match.id)).Contains("iniciou a partida");
        }

        public static void StartMatch(Match match)
        {
            string serverStr = Jogo.IniciarPartida(int.Parse(User.GetInstance().id), User.GetInstance().password);
            string firstPlayerId = GetStrData(serverStr)[0];

            Player player = new Player();
            player.id = firstPlayerId;

            CurrentMatch.SetCurrentMatch(match, player);
        }

        public static List<CardModel> GetCards()
        {
            if (GameGoatCards.Count > 0)
            {
                return GameGoatCards;
            }

            string[] serverCards = GetStrData(Jogo.ListarCartas());
            List<CardModel> cards = serverCards
                .Select(c => CardModel.FromServer(c)).ToList();

            return cards;
        }

        public static string[] GetPlayerGoatCards(User user)
        {
            return GetStrData(Jogo.VerificarMao(int.Parse(user.id), user.password));
        }

        public static RoundModel GetMatchRound()
        {
            string matchId = CurrentMatch.GetInstance().id;
            string matchRound = GetStrData(Jogo.VerificarVez(int.Parse(matchId)))[0];
            return RoundModel.FromServer(matchRound);
        }

        public static void PlayAGoatCard(string idCarta)
        {
            User user = User.GetInstance();
            Jogo.Jogar(int.Parse(user.id), user.password, int.Parse(idCarta));
        }

        public static string[] GetPlayerIslandCards(User user)
        {
            return GetStrData(Jogo.VerificarIlha(int.Parse(user.id), user.password))[0].Split(',');
        }

        public static void PlayAIslandCard(string islandValue)
        {
            User user = User.GetInstance();
            Jogo.DefinirIlha(int.Parse(user.id), user.password, int.Parse(islandValue));
        }

        public static string[] GetHistory()
        {
            int matchId = int.Parse(CurrentMatch.GetInstance().id);
            return GetStrData(Jogo.ExibirNarracao(matchId));
        }

        public static string GetWinnerText()
        {
            return GetHistory()[0];
        }

        public static CardModel GetCardById(string cardId)
        {
            return GetCards().First(c => c.CardId == cardId);
        }

        public static TableModel GetTable()
        {
            int matchId = int.Parse(CurrentMatch.GetInstance().id);
            return TableModel.FromServer(GetStrData(Jogo.VerificarMesa(matchId)));
        }

        public static int UserRoundWonGoats(int RoundId)
        {
            int matchId = int.Parse(CurrentMatch.GetInstance().id);
            TableModel RoundTable = TableModel.FromServer(GetStrData(Jogo.VerificarMesa(matchId, RoundId)));

            if (RoundTable.PlayersCards.Count == 0)
            {
                return 0;
            }

            int WonCardValue = RoundTable.PlayersCards.Values.Select(v => int.Parse(v)).Max();
            int PlayerCardValue = int.Parse(RoundTable.PlayersCards[User.GetInstance().id]);
            
            if (WonCardValue != PlayerCardValue)
            {
                return 0;
            }

            return int.Parse(GetCardById(PlayerCardValue.ToString()).Goats);
        }

        public static int CountUserGoats(int CurrentRoundNumber)
        {
            int Total = 0;

            for(int i = 1; i < CurrentRoundNumber; i++)
            {
                Total += UserRoundWonGoats(i);
            }

            return Total;
        }
    }
}
