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
    //Contains several separate client record searches.  Individual searches are LIKE and (for the names) AND.
    public partial class ClientSearch : Form
    {
        public ClientSearch()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            Show();
        }

        //open the selected record if extant
        private void lstClients_DoubleClick(object sender, EventArgs e)
        {
            if (lstClients.SelectedItem != null)
            {
                ShortRecord record = lstClients.SelectedItem as ShortRecord;
                if (record != null) new ClientRecord(record.IntID);
            }
        }

        //by first and last name
        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (txtFamilyName.Text == "" && txtGivenName.Text == "")
            {
                new Message("No data entered.");
            }
            else
            {
                List<ShortRecord> newData = new List<ShortRecord>();
                OdbcCommand query = new OdbcCommand("SELECT id, client_id, citizen_cert, given_name, family_name, dob, contract_type from client where " +
                    "given_name LIKE '%" + Utilities.MySQL_String(txtGivenName.Text) + "%' AND " +
                    "family_name LIKE '%" + Utilities.MySQL_String(txtFamilyName.Text) + "%'");
                query.Connection = Utilities.kis_clients;
                OdbcDataReader results = query.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        string extID;
                        if (results["citizen_cert"].ToString() != "")
                        {
                            extID = results["citizen_cert"].ToString();
                        }
                        else
                        {
                            extID = results["client_id"].ToString();
                        }
                        DateTime dob;
                        DateTime.TryParse(results["dob"].ToString(), out dob);
                        ShortRecord record = new ShortRecord((int)results["id"], extID, results["family_name"] + ", " + results["given_name"], dob, results["contract_type"].ToString());
                        newData.Add(record);
                    }
                }
                else
                {
                    new Message("No results found.");
                }
                results.Close();
                lstClients.DataSource = newData;
            }
        }

        //by client ID or citizenship certificate number (will match both)
        private void btnSearchID_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                new Message("No data entered.");
            }
            else
            {
                List<ShortRecord> newData = new List<ShortRecord>();
                OdbcCommand query = new OdbcCommand("SELECT id, client_id, citizen_cert, given_name, family_name, dob, contract_type from client where " +
                    "client_id LIKE '%" + Utilities.MySQL_String(txtID.Text) + "%' OR " +
                    "citizen_cert LIKE '%" + Utilities.MySQL_String(txtID.Text) + "%'");
                query.Connection = Utilities.kis_clients;
                OdbcDataReader results = query.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        string extID;
                        if (results["citizen_cert"].ToString() != "")
                        {
                            extID = results["citizen_cert"].ToString();
                        }
                        else
                        {
                            extID = results["client_id"].ToString();
                        }
                        ShortRecord record = new ShortRecord((int)results["id"], extID, results["family_name"] + ", " + results["given_name"], DateTime.Parse(results["dob"].ToString()), results["contract_type"].ToString());
                        newData.Add(record);
                    }
                }
                else
                {
                    new Message("No results found.");
                }
                results.Close();
                lstClients.DataSource = newData;
            }
        }

        //by country of birth
        private void btnNationality_Click(object sender, EventArgs e)
        {
            if (txtNationality.Text == "")
            {
                new Message("No data entered.");
            }
            else
            {
                List<ShortRecord> newData = new List<ShortRecord>();
                OdbcCommand query = new OdbcCommand("SELECT id, client_id, citizen_cert, given_name, family_name, dob, contract_type from client where " +
                    "birth_country LIKE '%" + Utilities.MySQL_String(txtNationality.Text) + "%'");
                query.Connection = Utilities.kis_clients;
                OdbcDataReader results = query.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        string extID;
                        if (results["citizen_cert"].ToString() != "")
                        {
                            extID = results["citizen_cert"].ToString();
                        }
                        else
                        {
                            extID = results["client_id"].ToString();
                        }
                        ShortRecord record = new ShortRecord((int)results["id"], extID, results["family_name"] + ", " + results["given_name"], DateTime.Parse(results["dob"].ToString()), results["contract_type"].ToString());
                        newData.Add(record);
                    }
                }
                else
                {
                    new Message("No results found.");
                }
                results.Close();
                lstClients.DataSource = newData;
            }
        }

        //by first language/language spoken at home
        private void btnLanguage_Click(object sender, EventArgs e)
        {

            if (txtLanguage.Text == "")
            {
                new Message("No data entered.");
            }
            else
            {
                List<ShortRecord> newData = new List<ShortRecord>();
                OdbcCommand query = new OdbcCommand("SELECT id, client_id, citizen_cert, given_name, family_name, dob, contract_type from client where " +
                    "home_language LIKE '%" + Utilities.MySQL_String(txtLanguage.Text) + "%'");
                query.Connection = Utilities.kis_clients;
                OdbcDataReader results = query.ExecuteReader();
                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        string extID;
                        if (results["citizen_cert"].ToString() != "")
                        {
                            extID = results["citizen_cert"].ToString();
                        }
                        else
                        {
                            extID = results["client_id"].ToString();
                        }
                        ShortRecord record = new ShortRecord((int)results["id"], extID, results["family_name"] + ", " + results["given_name"], DateTime.Parse(results["dob"].ToString()), results["contract_type"].ToString());
                        newData.Add(record);
                    }
                }
                else
                {
                    new Message("No results found.");
                }
                results.Close();
                lstClients.DataSource = newData;
            }
        }

        private void ClientSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void txtGivenName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnSearchName_Click(sender, new EventArgs());
            }
        }

        private void txtFamilyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnSearchName_Click(sender, new EventArgs());
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnSearchID_Click(sender, new EventArgs());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new ClientRecord();
        }

        private void mnuReporting_Click(object sender, EventArgs e)
        {
            new Reporting();
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (txtID.Text == "" || txtID.Text == "0")
                {
                    txtID.Select(0, 1);
                }
                else
                {
                    txtID.Select(txtID.Text.Length, 0);
                }
            });
        }

        private void mnuEditServices_Click(object sender, EventArgs e)
        {
            new EditServices();
        }

        private void txtNationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnNationality_Click(sender, new EventArgs());
            }
        }

        private void txtLanguage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                e.Handled = true;
                btnLanguage_Click(sender, new EventArgs());
            }
        }

        //autosize the result list to match the window
        private void ClientSearch_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height > 484) lstClients.Height = this.Height - 300;
            else lstClients.Height = 184;
        }
    }

    //quick display of pertinent details for the result list
    public class ShortRecord
    {
        public int IntID;
        public string DisplayText;

        public ShortRecord(int inIntID, string inExtID, string inName, DateTime DOB, string inContract)
        {
            IntID = inIntID;
            DisplayText = inName + " | " + inExtID + " | " + DOB.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + " | " + inContract;
        }

        override public string ToString()
        {
            return DisplayText;
        }
    }
}
