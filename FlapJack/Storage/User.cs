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
            User user = GetInstance();

            string[] data = serverUser.Split(',');
            user.id = data[0];
            user.password = data[1];
            user.name = player.name;
        }
    }
}
