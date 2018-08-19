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
    //Authorize re-collects the user's password to ensure especially consequential actions such as record deletion are undertaken knowingly
    public partial class Authorize : Form
    {
        public Authorize()
        {
            InitializeComponent();
            erpPassword.SetIconAlignment(txtPassword, ErrorIconAlignment.MiddleRight);
            erpPassword.SetIconPadding(txtPassword, 2);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            byte[] raw = System.Text.Encoding.ASCII.GetBytes(txtPassword.Text);
            raw = new System.Security.Cryptography.SHA256Managed().ComputeHash(raw);
            String pwd = Utilities.buildPwd(raw);
            string query = "SELECT id, username from staff where username = '" + Utilities.MySQL_String(UserData.username) +
                "' AND password = '" + pwd + "'";
            OdbcCommand kis_exe = new OdbcCommand(query, Utilities.kis_clients);
            OdbcDataReader match = kis_exe.ExecuteReader();
            if (match.HasRows)
            {
                DialogResult = DialogResult.OK;
                erpPassword.SetError(txtPassword, "");
                Close();
            }
            else
            {
                erpPassword.SetError(txtPassword, "Invalid password.");
                btnConfirm.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //auto-submit on enter
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnConfirm_Click(sender, new EventArgs());
            }
        }
    }
}
