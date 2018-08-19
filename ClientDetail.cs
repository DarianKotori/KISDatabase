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
    //Displays and edits minor client details
    public partial class ClientDetail : Form
    {
        private int ClientID;
        private bool ReadOnly;
        private bool Unlock;
        private bool NeedAddress;
        private AutoCompleteStringCollection NOCData = new AutoCompleteStringCollection();

        public ClientDetail(int ID, out bool outNeedAddress, bool read = false, bool unlock = false)
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ClientID = ID;
            ReadOnly = read; //if another user has the record open
            Unlock = unlock; //used if the form was opened in the process of creating a new record, which must be unlocked when done
            string NOC;
            OdbcCommand query = new OdbcCommand("SELECT client.*, staff.username, noc.description from client LEFT JOIN staff ON client.edit_locked = staff.id LEFT JOIN noc on client.occupation = noc.code where client.id = '" + ID + "'");
            query.Connection = Utilities.kis_clients;
            OdbcDataReader results = query.ExecuteReader();
            if (results.HasRows)
            {
                results.Read();
                if (ReadOnly)
                {
                    foreach (Control child in this.Controls)
                    {
                        if (child != btnCancel)
                            child.Enabled = false;
                    }
                    Text = "Client Details (read-only; locked by " + results["username"].ToString() + ")";
                }
            }
            chkFedResearch.Checked = (results["research_consent_fed"].ToString() == "1");
            chkProvResearch.Checked = (results["research_consent_prov"].ToString() == "1");
            txtHomeLanguage.Text = results["home_language"].ToString();
            cmbPrefLanguage.SelectedIndex = cmbPrefLanguage.FindStringExact(results["preferred_language"].ToString());
            cmbEducation.SelectedIndex = cmbEducation.FindStringExact(results["education"].ToString());
            NOC = longNOC((results["occupation"] is DBNull ? 0 : (int)results["occupation"]), results["description"].ToString());
            txtArrival.Text = results["arrival_year"].ToString();
            cmbProvince.SelectedIndex = cmbProvince.FindStringExact(results["land_province"].ToString());
            int idx;
            if (results["sex"].ToString() == "-") idx = 1;
            else if (results["sex"].ToString() == "F") idx = 2;
            else if (results["sex"].ToString() == "M") idx = 3;
            else idx = 0;
            cmbSex.SelectedIndex = idx;
            if (results["dob"] != DBNull.Value) {
                dtpDOB.Value = DateTime.Parse(results["dob"].ToString());
            }
            txtBirthCountry.Text = results["birth_country"].ToString();
            cmbImmClass.Text = results["immigration_class"].ToString();
            chkNotifications.Checked = (results["notifications"].ToString() == "1");
            results.Close();
            query.CommandText = "SELECT * from noc";
            results = query.ExecuteReader();
            NOCData.Add("");
            while (results.Read())
            {
                NOCData.Add(results["description"].ToString() + " " + ((int)results["code"]).ToString("0000"));
            }
            cmbOccupation.AutoCompleteCustomSource = NOCData;
            cmbOccupation.DataSource = NOCData;
            cmbOccupation.Text = NOC;
            results.Close();
            NeedAddress = chkFedResearch.Checked || chkProvResearch.Checked;
            ShowDialog();
            outNeedAddress = NeedAddress;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                int arrival = (txtArrival.Text == "" ? 0 : Int32.Parse(txtArrival.Text));
                string sex = "NULL";
                if (cmbSex.Text == "X") sex = "'-'";
                else if (cmbSex.Text != "") sex = "'" + cmbSex.Text + "'";
                string queryText = "UPDATE client SET " +
                    "research_consent_fed = '" + (chkFedResearch.Checked ? 1 : 0) + "', " +
                    "research_consent_prov = '" + (chkProvResearch.Checked ? 1 : 0) + "', " +
                    "home_language = '" + Utilities.MySQL_String(txtHomeLanguage.Text) + "', " +
                    "preferred_language = '" + cmbPrefLanguage.Text + "', " +
                    "education = '" + Utilities.MySQL_String(cmbEducation.Text) + "', " +
                    "occupation = " + extractNOC(cmbOccupation.Text) + ", " +
                    "arrival_year = '" + arrival + "', " +
                    "land_province = '" + cmbProvince.Text + "', " +
                    "sex = " + sex + ", " +
                    (dtpDOB.Value != DateTime.Today ? "dob = '" + dtpDOB.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', " : "") +
                    "birth_country = '" + Utilities.MySQL_String(txtBirthCountry.Text) + "', " +
                    "immigration_class = '" + Utilities.MySQL_String(cmbImmClass.Text) + "', " +
                    "notifications = '" + (chkNotifications.Checked ? 1 : 0) + "' " +
                    "WHERE id = '" + ClientID + "'";
                OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
                if ((int)query.ExecuteNonQuery() == 0)
                {
                    new Message("SQL Error: Data cannot be saved as written.");
                }
                else
                {
                    NeedAddress = chkFedResearch.Checked || chkProvResearch.Checked;
                    Close();
                }
            }
        }

        private void SetErrorProviders()
        {
            erpArrival.SetIconAlignment(txtArrival, ErrorIconAlignment.MiddleRight);
            erpArrival.SetIconPadding(txtArrival, 2);
        }

        public string extractNOC(string inText)
        {
            string outText;
            int outInt;
            if (inText.Length < 4)
            {
                return "NULL";
            }
            else
            {
                outText = inText.Substring(inText.Length - 5);
                if (int.TryParse(outText, out outInt))
                {
                    return outText;
                }
                else
                {
                    return "NULL";
                }
            }
        }

        public string longNOC(int code, string description)
        {
            if (description == "")
            {
                return "";
            }
            else
            {
                return description + " " + code.ToString("0000");
            }
        }

        private void ClientDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Unlock) //unlock the main client record for these details, because it's newly created and already closed
            {
                string queryText = "UPDATE client SET edit_locked = 0 WHERE id = '" + ClientID + "'";
                OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
                if ((int)query.ExecuteNonQuery() == 0)
                {
                    new Message("SQL Error: Record cannot be unlocked.");
                }
                new ClientRecord(ClientID);
            }
        }

        private void txtArrival_Validating(object sender, CancelEventArgs e)
        {
            if (txtArrival.Text.Length > 0 && txtArrival.Text.Length < 4)
            {
                erpArrival.SetError(txtArrival, "Please enter year as 4 digits.");
                e.Cancel = true;
            }
            else
            {
                erpArrival.SetError(txtArrival, String.Empty);
            }
        }

        private void dtpDOB_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDOB.Value < DateTime.Parse("1900-01-01"))
            {
                erpDOB.SetError(dtpDOB, "Please enter a date of birth, or use the default value (1900-01-01) if unknown.");
                e.Cancel = true;
            }
            else
            {
                erpDOB.SetError(dtpDOB, String.Empty);
            }
        }

        //Determine the skill level of the selected NOC code (0-D)
        private void cmbOccupation_TextChanged(object sender, EventArgs e)
        {
            if (cmbOccupation.Text.Length > 3)
            {
                string first = cmbOccupation.Text.Substring(cmbOccupation.Text.Length - 4, 1);
                string second = cmbOccupation.Text.Substring(cmbOccupation.Text.Length - 3, 1);
                string third = cmbOccupation.Text.Substring(cmbOccupation.Text.Length - 2, 1);
                if (first == "0" && second == "0" && third == "0") lblSkillLevel.Text = "N/A"; //some artificial NOC codes (student, etc.) were added to the beginning of the list
                else if (first == "0") lblSkillLevel.Text = "0";
                else if (second == "0" || second == "1") lblSkillLevel.Text = "A";
                else if (second == "2" || second == "3") lblSkillLevel.Text = "B";
                else if (second == "4" || second == "5") lblSkillLevel.Text = "C";
                else if (second == "6" || second == "7") lblSkillLevel.Text = "D";
            }
            else
            {
                lblSkillLevel.Text = "N/A";
            }
        }

        //auto-progress the cursor through day-month-year subfields when entering data
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send(".");
        }

        //set the cursor to the beginning of an empty masked field, or the end of the entered text
        private void txtArrival_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (txtArrival.Text == "" || txtArrival.Text == "0")
                {
                    txtArrival.Select(0, 0);
                }
                else
                {
                    txtArrival.Select(txtArrival.Text.Length, 0);
                }
            });
        }
    }
}
