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
using System.Globalization;

namespace KISDatabase
{
    //Add, view, edit, or delete staff comments and records of client visits
    public partial class CommentAdd : Form
    {
        private int ClientID;
        private bool Visit;
        private int RecordID;

        public CommentAdd(int client, bool visit = false)
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ClientID = client;
            Visit = visit;
            btnDelete.Visible = false;
            dtpDate.Value = DateTime.Now;
            if (Visit) Text = "Record New Visit";
            ShowDialog();
        }

        public CommentAdd(string text, string date, int comment = 0, bool visit = false)
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            Visit = visit;
            RecordID = comment;
            txtComment.Text = text;
            if (RecordID == 0)
            {
                txtComment.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                dtpDate.Enabled = false;
            }
            dtpDate.Value = DateTime.Parse(date);
            Text = "Comment";
            ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OdbcCommand query = new OdbcCommand("", Utilities.kis_clients);
            if (RecordID == 0)
            {
                query.CommandText = "INSERT INTO " + (Visit ? "visit" : "comment") + " (client, comment_date, staff, comment_text) VALUES ('" +
                    ClientID + "','" + dtpDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "','" + UserData.userID + "','" + Utilities.MySQL_String(txtComment.Text) + "')";
            }
            else
            {
                query.CommandText = "UPDATE " + (Visit ? "visit" : "comment") + " SET comment_date = '" + dtpDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', " +
                    "comment_text = '" + Utilities.MySQL_String(txtComment.Text) + "' WHERE id = " + RecordID;
            }
            if (query.ExecuteNonQuery() == 0)
            {
                new Message("SQL Error: Could not save " + (Visit ? "visit" : "comment") + ".");
            }
            else
            {
                if (Visit && RecordID == 0) //new visit, need to select services provided during visit
                {
                    query.CommandText = "SELECT id FROM visit WHERE client = '" + ClientID + "' AND staff = '" + UserData.userID + "' ORDER BY id DESC";
                    RecordID = Int32.Parse(query.ExecuteScalar().ToString());
                    new Services(ClientID, false, true, RecordID);
                }
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OdbcCommand query = new OdbcCommand("DELETE FROM " + (Visit ? "visit" : "comment") + " WHERE id = " + RecordID, Utilities.kis_clients);
            if (query.ExecuteNonQuery() == 0)
            {
                new Message("SQL Error: Could not delete " + (Visit ? "visit" : "comment") + ".");
            }
            else
            {
                Close();
            }
        }
    }
}
