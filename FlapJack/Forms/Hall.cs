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
                dgvMatches.Columns["isValid"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            updateMatches((MatchType)cmbTypes.SelectedItem);
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
    }
}
