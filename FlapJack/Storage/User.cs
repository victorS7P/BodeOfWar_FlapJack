using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public sealed class User : Player
    {
        private User() { }
        private static User _instance;

        public string password;

        public static User GetInstance()
        {
            return _instance ?? (_instance = new User());
        }

        public static void SetUser(string serverUser, Player player)
        {
            string[] data = serverUser.Split(',');

            User u = GetInstance();
            u.id = data[0];
            u.password = data[1];
            u.name = player.name;
        }

        public string[] GetGoatCards()
        {
            return Server.GetPlayerGoatCards(GetInstance());
        }

        public string[] GetIslandCards()
        {
            return Server.GetPlayerIslandCards(GetInstance());
        }
    }
}
