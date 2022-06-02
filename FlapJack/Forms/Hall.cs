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
    public partial class Hall : Form
    {
        private bool isJoin = true;

        private Match SelectedMatch
        {
            get {
                if (dgvMatches.SelectedRows.Count > 0)
                {
                    return (Match)dgvMatches.SelectedRows[0].DataBoundItem;
                } else
                {
                    return null;
                }
            }
            set => SelectMatch(value);
        }

        public Hall()
        {
            InitializeComponent();
        }

        private void UpdateSelectedMatches()
        {
            UpdateMatches((MatchType)cmbTypes.SelectedItem);
        }

        private void UpdateAllMatches()
        {
            if (cmbTypes.SelectedIndex == 0)
            {
                UpdateSelectedMatches();
            }

            cmbTypes.SelectedIndex = 0;
        }

        private void UpdateMatches(MatchType type)
        {
            dgvMatches.DataSource = new List<Match>{};
            
            try
            {
                List<Match> matches = Server.GetMatches(type.type);
                dgvMatches.DataSource = matches;
            }
            catch (Exception ex)
            {
                eBtnJoin.Error = ex.Message;
            }
        }

        private void ResetCmbTypes()
        {
            cmbTypes.DataSource = Server.GetMatchTypes();
            this.UpdateMatches(MatchType.FromType('T'));
        }

        private void Hall_Load(object sender, EventArgs e)
        {
            ResetCmbTypes();
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedMatches();
        }

        private void tmrMatches_Tick(object sender, EventArgs e)
        {
            UpdateSelectedMatches();
        }

        private void SelectLastCreatedMatch(Match createdMatch)
        {
            UpdateAllMatches();
            dgvMatches.ClearSelection();

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                Match m = (Match)row.DataBoundItem;
                if (m.id == createdMatch.id)
                {
                    row.Selected = true;
                }
            }

            dgvMatches.FirstDisplayedScrollingRowIndex = dgvMatches.RowCount - 1;
        }

        private void btnCreateMatch_Click(object sender, EventArgs e)
        {
            CreateMatch createMatch = new CreateMatch();
            createMatch.WindowClosed += SelectLastCreatedMatch;
            createMatch.ShowDialog(this);
        }

        private void ToggleEnterButtonEnable()
        {
            eBtnJoin.Enabled = (SelectedMatch != null);
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            eBtnJoin.Error = "";

            if (dgvMatches.SelectedRows.Count > 0)
            {
                SelectedMatch = (Match)dgvMatches.SelectedRows[0].DataBoundItem;
            } else
            {
                SelectedMatch = null;
            }
        }

        private void eBtnUpdate_OnClick(object sender, EventArgs e)
        {
            UpdateMatches((MatchType)cmbTypes.SelectedItem);
        }

        private bool JoinMatchValidate()
        {
            eTxtPlayer.Validate();
            eTxtPassword.Validate();

            return !eTxtPlayer.HasError && !eTxtPassword.HasError;
        }

        public void SelectMatch(Match newSelectedMatch)
        {
            eTxtPassword.Value = "";
            eTxtPassword.Error = "";
            eTxtPlayer.Error = "";

            if (newSelectedMatch == null)
            {
                gbxMatch.Visible = false;
            } else
            {
                if (newSelectedMatch.type.type == 'A')
                {
                    gbxMatch.Visible = true;
                    gbxMatch.Text = SelectedMatch.name;
                } else
                {
                    gbxMatch.Visible = false;
                }
            }

            UpdatePlayersList();
            ToggleEnterButtonEnable();
            ResetJoinButton();
        }

        private void UpdatePlayersList()
        {
            try
            {
                if (SelectedMatch != null)
                {
                    SelectedMatch.players = Server.GetPlayers(SelectedMatch.id);
                    pltHall.Players = SelectedMatch.players;

                    if (Server.MatchHasStarted(SelectedMatch) && User.GetInstance().id != null)
                    {
                        CurrentMatch.SetCurrentMatch(SelectedMatch, User.GetInstance());
                        OpenGameRoom();
                    }
                }
            }
            catch (Exception ex)
            {
                eBtnJoin.Error = ex.Message;
            }
        }

        private void tmrPlayersList_Tick(object sender, EventArgs e)
        {
            tmrPlayersList.Enabled = false;
            UpdatePlayersList();
            tmrPlayersList.Enabled = true;
        }

        private void ToggleJoinButtonToStart()
        {
            isJoin = false;

            eTxtPlayer.Visible = false;
            eTxtPassword.Visible = false;
            eBtnJoin.Label = "Começar Partida";
        }

        private void ResetJoinButton()
        {
            isJoin = true;

            eTxtPlayer.Visible = true;
            eTxtPassword.Visible = true;
            eBtnJoin.Label = "Entrar";
        }


        private void OpenGameRoom()
        {
            GameRoom gameMatch = new GameRoom();
            gameMatch.ShowDialog(this);
        }

        private void eBtnJoin_OnClick(object sender, EventArgs e)
        {
            if (isJoin)
            {
                if (JoinMatchValidate())
                {
                    try
                    {
                        Player player = new Player();
                        player.name = eTxtPlayer.Value;

                        Server.JoinMatch(SelectedMatch, player, eTxtPassword.Value);
                        UpdatePlayersList();
                        ToggleJoinButtonToStart();

                    }
                    catch (Exception ex)
                    {
                        eBtnJoin.Error = ex.Message;
                    }
                }
            } else
            {
                Server.StartMatch(SelectedMatch);
                OpenGameRoom();

                //if (pltHall.Players.Count == 1)
                //{
                //    eBtnJoin.Error = "Você não pode começar uma partida sozinho";
                //} else
                //{
                //    Server.StartMatch(SelectedMatch);
                //    GameRoom gameMatch = new GameRoom();
                //    gameMatch.ShowDialog(this);
                //}
            }
        }
    }
}
