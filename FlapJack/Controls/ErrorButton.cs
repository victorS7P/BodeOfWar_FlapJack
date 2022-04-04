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
    public partial class ErrorButton : UserControl
    {
        public string Error
        {
            get => lblError.Text;
            set => lblError.Text = value;
        }

        public string Label
        {
            get => btnErrror.Text;
            set => btnErrror.Text = value;
        }

        public new event EventHandler OnClick;

        public ErrorButton()
        {
            InitializeComponent();
        }

        private void ErrorButton_Load(object sender, EventArgs e)
        {

        }

        private void btnErrror_Click(object sender, EventArgs e)
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
