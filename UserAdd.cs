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
    //Add new users to the database
    public partial class UserAdd : Form
    {
        public UserAdd()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirm.Text != "") lblPasswordError.Visible = (txtPassword.Text != txtConfirm.Text);
            lblFieldError.Visible = false;
            lblUsernameError.Visible = false;
        }

        private void txtConfirm_Leave(object sender, EventArgs e)
        {
            lblPasswordError.Visible = (txtPassword.Text != txtConfirm.Text);
            lblFieldError.Visible = false;
            lblUsernameError.Visible = false;
        }
        
        //For beta testing purposes, there are currently no special permissions required to create a user account,
        //as they're only used for action tracking and reporting purposes.  This may change based on future customer decisions.
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            lblPasswordError.Visible = (txtPassword.Text != txtConfirm.Text);
            lblFieldError.Visible = false;
            lblUsernameError.Visible = false;
            if (lblPasswordError.Visible == false)
            {
                if (txtGivenName.Text == "" | txtFamilyName.Text == "" | txtUsername.Text == "" | txtPassword.Text == "" | txtConfirm.Text == "")
                {
                    lblFieldError.Visible = true;
                }
                else
                {
                    string query = "SELECT id FROM staff where username = '" + Utilities.MySQL_String(txtUsername.Text) + "'";
                    OdbcCommand command = new OdbcCommand(query, Utilities.kis_clients);
                    OdbcDataReader results = command.ExecuteReader();
                    if (results.HasRows)
                    {
                        lblUsernameError.Visible = true;
                        results.Close();
                    }
                    else
                    {
                        results.Close();
                        byte[] raw = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text);
                        raw = new System.Security.Cryptography.SHA256Managed().ComputeHash(raw);
                        String pwd = Utilities.buildPwd(raw);
                        query = "INSERT INTO staff (given_name, family_name, title, username, password) VALUES ('" +
                            Utilities.MySQL_String(txtGivenName.Text) + "', '" +
                            Utilities.MySQL_String(txtFamilyName.Text) + "', '" +
                            Utilities.MySQL_String(txtTitle.Text) + "', '" +
                            Utilities.MySQL_String(txtUsername.Text) + "', '" +
                            pwd + "')";
                        command.CommandText = query;
                        if (command.ExecuteNonQuery() == 1)
                        {
                            new Message("User successfully added.");
                            Close();
                        }
                        else
                        {
                            new Message("SQL Error.");
                        }
                    }
                }
            }
        }
    }
}
