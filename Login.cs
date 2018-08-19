using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace KISDatabase
{
    //Authorize users
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            //rehash password data, compare
            byte[] raw = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text);
            raw = new System.Security.Cryptography.SHA256Managed().ComputeHash(raw);
            String pwd = Utilities.buildPwd(raw);
            string query = "SELECT id, username from staff where username = '" + Utilities.MySQL_String(txtUsername.Text) +
                "' AND password = '" + pwd + "'";
            OdbcCommand kis_exe = new OdbcCommand(query, Utilities.kis_clients);
            OdbcDataReader match = kis_exe.ExecuteReader();
            if (match.HasRows) {
                //save user data for action tracking
                UserData.username = match["username"].ToString();
                UserData.userID = (int)match["id"];
                lblError.Text = "";
                new ClientSearch();
                Close();
            }
            else
            {
                lblError.Text = "Invalid login data.";
            }
            btnLogin.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new UserAdd();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnLogin_Click(sender, new EventArgs());
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnLogin_Click(sender, new EventArgs());
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}