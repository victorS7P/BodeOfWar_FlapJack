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
        private Match selectedMatch;

        public Hall()
        {
            InitializeComponent();
        }

        private void updateMatches(MatchType type)
        {
            dgvMatches.DataSource = new List<Match>{};
            
            try
            {
                List<Match> matches = Server.GetMatches(type.type);
                dgvMatches.DataSource = matches;
            }
            catch (Exception ex)
            {
                eBtnUpdate.Error = ex.Message;
            }
        }

        private void ResetCmbTypes()
        {
            cmbTypes.DataSource = Server.GetMatchTypes();
            this.updateMatches(MatchType.FromType('T'));
        }

        private void Hall_Load(object sender, EventArgs e)
        {
            ResetCmbTypes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateMatches((MatchType)cmbTypes.SelectedItem);
        }

        private void tmrMatches_Tick(object sender, EventArgs e)
        {
            updateMatches((MatchType)cmbTypes.SelectedItem);
        }

        private void btnCreateMatch_Click(object sender, EventArgs e)
        {
            Forms.CreateMatch createMatch = new Forms.CreateMatch();

            createMatch.FormClosed += btnUpdate_Click;
            createMatch.ShowDialog();
        }

        private void ToggleEnterButtonEnable()
        {
            eBtnJoin.Enabled = (selectedMatch != null);
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            eBtnJoin.Error = "";

            if (dgvMatches.SelectedRows.Count > 0)
            {
                Match newSelectedMatch = (Match)dgvMatches.SelectedRows[0].DataBoundItem;

                if (selectedMatch == null || newSelectedMatch.id != selectedMatch.id)
                {
                    selectedMatch = newSelectedMatch;
                    ToggleEnterButtonEnable();
                }
            }
        }

        private void eBtnJoin_OnClick(object sender, EventArgs e)
        {
            
            if (selectedMatch != null)
            {
                JoinMatch joinMatch = new JoinMatch();

                joinMatch.SelectedMatch = selectedMatch;
                joinMatch.ShowDialog();
            } else
            {
                eBtnJoin.Error = "Nenhuma partida selecionada!";
            }

            
        }

        private void eBtnUpdate_OnClick(object sender, EventArgs e)
        {
            updateMatches((MatchType)cmbTypes.SelectedItem);
        }

        private void dgvMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (selectedMatch.type.type == 'A')
                {
                    JoinMatch joinMatch = new JoinMatch();

                    joinMatch.SelectedMatch = selectedMatch;
                    joinMatch.ShowDialog();
                } else
                {
                    eBtnJoin.Error = "Só é possível entrar em partidas abertas.";
                }
            }
        }
    }
}
