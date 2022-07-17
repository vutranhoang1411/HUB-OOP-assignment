using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class loginForm : Form
    {
        private bool loginSuccessed;
        public loginForm()
        {
            InitializeComponent();
            this.loginSuccessed = false;
        }

        //Handle the form
        private void loginForm_Load(object sender, EventArgs e)
        {
            this.ErrorLabel.Hide();
        }

        //login button handler
        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = this.userNameBox.Text;
            string password = this.passwordBox.Text;
            if (userName == "MRTHO" && password=="123")
            {
                this.loginSuccessed = true;
                this.Close();
            }
            else
            {
                this.userNameBox.Clear();
                this.passwordBox.Clear();
                this.ErrorLabel.Show();
                this.userNameBox.Focus(); ;
            }
        }

        
        //Exit handler
        private void handleExit(object sender, FormClosingEventArgs e)
        {
            if (!this.loginSuccessed)
            {
                DialogResult dialog = MessageBox.Show("Bạn muốn thoát không?", "", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.No)
                {
                    this.userNameBox.Focus();
                    e.Cancel = true;
                }
            }
            
        }


        //self-created function
        public bool getLoginState()
        {
            return this.loginSuccessed;
        }

    }
}
