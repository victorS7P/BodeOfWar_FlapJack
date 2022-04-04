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
    public partial class CreateMatch : Form
    {
        public Match CreatedMatch;
        public delegate void CloseEvent(Match createdMatch);
        public CloseEvent WindowClosed;

        public CreateMatch()
        {
            InitializeComponent();
        }

        private new bool Validate()
        {
            eTxtName.Validate();
            eTxtPassword.Validate();
            eTxtConfirm.Validate();

            if (eTxtPassword.Value != eTxtConfirm.Value)
            {
                eTxtConfirm.Error = "As senhas não conferem!";
            }

            ToggleButtonEnable(null, null);
            return !HasError();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    CreatedMatch = Server.CreateMatch(eTxtName.Value, eTxtPassword.Value);
                    Close();
                } catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        private bool HasError()
        {
            return eTxtName.Error.Length > 0
                || eTxtPassword.Error.Length > 0
                || eTxtConfirm.Error.Length > 0;
        }

        private void ToggleButtonEnable(object sender, EventArgs e)
        {
            btnCreate.Enabled = !HasError();
        }

        private void eTxtName_OnType(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void CreateMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowClosed(CreatedMatch);
        }
    }
}
