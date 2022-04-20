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
    public partial class IslandCardControl : UserControl
    {
        public string Value
        {
            get => lblValue.Text;
            set => lblValue.Text = value;
        }

        public IslandCardControl()
        {
            InitializeComponent();
        }

        private void IslandCardControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(200, Color.White);
        }

        private void IslandCardControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, Color.White);
        }

        private void lblValue_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(200 , Color.White);
        }

        private void lblValue_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, Color.White);
        }

        private void lblValue_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
    }
}
