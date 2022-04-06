using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlapJack
{
    public partial class PlayersList : UserControl
    {
        public List<Player> Players
        {
            get => (List<Player>)lbxPlayers.DataSource;
            set => lbxPlayers.DataSource = value;
        }

        public Player CurrentPlayer;

        public PlayersList()
        {
            InitializeComponent();
        }
    }
}
