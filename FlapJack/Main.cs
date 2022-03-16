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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void toggleAllVisibility(bool show)
        {
            lblTitle.Visible = show;
            btnPlay.Visible = show;
            btnExit.Visible = show;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblVersion.Text = lblVersion.Text.Replace("@.@", Server.version);
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            this.toggleAllVisibility(true);
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            this.toggleAllVisibility(false);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.toggleAllVisibility(false);

            Hall hall = new Hall();
            hall.ShowDialog();
        }
    }
}
