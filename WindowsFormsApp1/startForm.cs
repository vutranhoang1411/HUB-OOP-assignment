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
    public partial class startForm : Form
    {
        private bool loginSuccessed;
        public startForm()
        {
            this.loginSuccessed = false;
            InitializeComponent();
        }

        //Handle login
        private void getLoginResult(object sender, FormClosedEventArgs e)
        {
            this.loginSuccessed = ((loginForm)(sender)).getLoginState();
            if (this.loginSuccessed)
            {
                this.logout.Visible = true;
            }
        }
        private void login_Click(object sender, EventArgs e)
        {
            if (this.loginSuccessed)
            {
                MessageBox.Show("You have already logged in!");
            }
            else
            {
                loginForm newLogin = new loginForm();
                newLogin.FormClosed += new FormClosedEventHandler(this.getLoginResult);
                newLogin.ShowDialog(); 
            }
            
        }
        

        // info handle
        private void info_Click(object sender, EventArgs e)
        {
            info infoForm = new info();
            infoForm.Show();
            
        }

        //Checking login state before using
        private bool loginCheck()
        {
            if (!this.loginSuccessed)
            {
                DialogResult dialog = MessageBox.Show("You haven't logged in yet. Do you want to log in?", "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    this.login.PerformClick();
                }
            }
            return this.loginSuccessed;
        }

        //handle book control
        private void bookManager_Click(object sender, EventArgs e)
        {
            if (loginCheck())
            {
                bookControlForm bookControl = new bookControlForm();
                bookControl.ShowDialog();
            }
        }

        //handle student manager
        private void studentManager_Click(object sender, EventArgs e)
        {
           if (loginCheck())
            {
                studentManagerForm studentManager = new studentManagerForm();
                studentManager.ShowDialog();
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.loginSuccessed = false;
            this.logout.Visible = false;
            MessageBox.Show("logout success!");
        }

        private void startForm_Load(object sender, EventArgs e)
        {
            this.logout.Visible = false;
        }
        private void keyDownhandler(object sender, KeyEventArgs e)
        {
            if ( e.Alt && e.KeyCode == Keys.F4)
            {
                this.Close();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                this.bookManager.PerformClick();
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                this.studentManager.PerformClick();
            }
            else if (e.KeyCode == Keys.F1)
            {
                this.info.PerformClick();
            }
        }
    }
}
