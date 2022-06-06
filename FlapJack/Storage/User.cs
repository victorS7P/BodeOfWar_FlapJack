using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public sealed class User : Player
    {
        private static User _instance;
        public static User GetInstance()
        {
            return _instance ?? (_instance = new User());
        }

        public string password;

        public void Reset()
        {
            _instance = null;
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
