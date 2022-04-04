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
    public partial class JoinMatch : Form
    {
        private Match _SelectedMatch;

        public Match SelectedMatch
        {
            get { return _SelectedMatch; }
            set { _SelectedMatch = value; }
        }

        public JoinMatch()
        {
            InitializeComponent();
        }

        private new bool Validate()
        {
            eTxtPlayer.Validate();
            eTxtPassword.Validate();

            return !eTxtPlayer.HasError && !eTxtPassword.HasError;
        }

        private void eBtnJoin_OnClick(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    Player player = new Player();
                    player.name = eTxtPlayer.Value;

                    User user = Server.JoinMatch(SelectedMatch, player, eTxtPassword.Value);
                    UpdatePlayersList();
                }
                catch (Exception ex)
                {
                    eBtnJoin.Error = ex.Message;
                }
            }
        }

        private void UpdatePlayersList()
        {
            try
            {
                List<Player> players = Server.GetPlayers(_SelectedMatch.id);
                lbxPlayers.DataSource = players;
            }
            catch (Exception ex)
            {
                eBtnJoin.Error = ex.Message;
            }
        }

        private void JoinMatch_Load(object sender, EventArgs e)
        {
            Text = "Entrar na Partida " + _SelectedMatch.name;
            UpdatePlayersList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePlayersList();
        }
    }
}
