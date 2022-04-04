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
        private Match SelectedMatch
        {
            get => (Match)dgvMatches.SelectedRows[0].DataBoundItem;
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
                //SelectMatch(newSelectedMatch);
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

            gbxMatch.Visible = true;
            gbxMatch.Text = SelectedMatch.name;

            UpdatePlayersList();
            ToggleEnterButtonEnable();
        }

        private void UpdatePlayersList()
        {
            try
            {
                List<Player> players = Server.GetPlayers(SelectedMatch.id);
                lbxPlayers.DataSource = players;
            }
            catch (Exception ex)
            {
                eBtnJoin.Error = ex.Message;
            }
        }

        private void tmrPlayersList_Tick(object sender, EventArgs e)
        {
            UpdatePlayersList();
        }

        private void eBtnJoin_OnClick(object sender, EventArgs e)
        {
            if (JoinMatchValidate())
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
    }
}
