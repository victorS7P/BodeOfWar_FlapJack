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

        private void updateMatches(string status)
        {
            try
            {
                List<Match> matches = Server.getMatches(status);
                dgvMatches.DataSource = matches;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Hall_Load(object sender, EventArgs e)
        {
            this.updateMatches("T");
        }
    }
}
