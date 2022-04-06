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
    public partial class GameRoom : Form
    {
        public GameRoom()
        {
            InitializeComponent();
        }

        private void GameMatch_Load(object sender, EventArgs e)
        {
            Owner.Hide();
            plsRoom.Players = CurrentMatch.GetInstance().players;
        }
    }
}
