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
    public partial class ErrorTextBox : UserControl
    {
        public string Label
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string Value
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }

        public string Error
        {
            get => lblError.Text;
            set => lblError.Text = value;

        }

        public char PasswordChar
        {
            get => txtValue.PasswordChar;
            set => txtValue.PasswordChar = value;
        }

        public bool EnableEmpty
        {
            get;
            set;
        } = true;

        public bool Pure
        {
            get;
            set;
        } = true;

        public bool HasError
        {
            get => Error.Length > 0;
        }

        public ErrorTextBox()
        {
            InitializeComponent();
        }

        public event EventHandler OnValidate;
        public event EventHandler OnType;

        public new void Validate()
        {
            lblError.Text = "";

            if (!EnableEmpty && txtValue.Text.Length == 0)
            {
                lblError.Text = "Esse campo não pode estar vazio";
            }

            if (OnValidate != null)
            {
                OnValidate(this, new EventArgs());
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            Pure = false;

            if (OnType != null)
            {
                OnType(this, new EventArgs());
            }

            Validate();
        }
    }
}
