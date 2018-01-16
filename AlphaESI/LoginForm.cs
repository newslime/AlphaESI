using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AlphaESI
{
    public partial class LoginForm : Form
    {
        public LoginForm(int x, int y)
        {
            InitializeComponent();

            errorLabel.Location = new Point(okBtn.Location.X, okBtn.Location.Y - errorLabel.Height - 5);
            this.Location = new Point(x, y);
            this.ActiveControl = errorLabel;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == "")
            {
                errorLabel.Text = "Please Enter User";
                errorLabel.Visible = true;
                return;
            }

            if (passTextBox.Text == "")
            {
                errorLabel.Text = "Please Enter Password";
                errorLabel.Visible = true;
                return;
            }

            if (String.Compare("admin", userTextBox.Text, true) == 0 && String.Compare("123456", passTextBox.Text, true) == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void userTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Visible = false;
        }
    }
}
