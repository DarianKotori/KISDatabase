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
    //The main record for a client.
    public partial class ClientRecord : Form
    {
        private int ClientID;
        private bool ReadOnly = false;
        private bool NeedAddress = false;

        public ClientRecord()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            btnServices.Visible = false;
            btnDetails.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
            btnAttachments.Visible = false;
            lstComments.Visible = false;
            lblComments.Visible = false;
            btnVisitAdd.Visible = false;
            lstVisits.Visible = false;
            lblVisit.Visible = false;
            ClientID = 0;
            SetErrorProviders();
            Show();
        }

        public ClientRecord(int ID)
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ClientID = ID;
            OdbcCommand query = new OdbcCommand("SELECT client.*, staff.username from client LEFT JOIN staff ON client.edit_locked = staff.id where client.id = '" + ID + "'");
            query.Connection = Utilities.kis_clients;
            OdbcDataReader results = query.ExecuteReader();
            if (results.HasRows)
            {
                results.Read();
                if ((int)results["edit_locked"] > 0) //someone else has the record open
                {
                    foreach (Control child in this.Controls)
                    {
                        if (child != lstComments && child != lstVisits && child != btnCancel && child != btnDetails && child != lstComments && child != btnServices)
                            child.Enabled = false;
                    }
                    ReadOnly = true;
                    Text = "Client Record (read-only; locked by " + results["username"].ToString() + ")";
                    if (UserData.username == results["username"].ToString())
                    {
                        btnUnlock.Visible = true;
                        btnUnlock.Enabled = true;
                    }
                }
                else //lock it yourself
                {
                    OdbcCommand query2 = new OdbcCommand("UPDATE client SET edit_locked = '" + UserData.userID + "' " +
                        "where id = '" + ID + "' AND edit_locked = '0'");
                    query2.Connection = Utilities.kis_clients;
                    if (query2.ExecuteNonQuery() == 0)
                    {
                        new Message("SQL Error or multiple simultaneous access attempts. Please try again.");
                        results.Close();
                        Close();
                    }
                }
                txtGivenName.Text = results["given_name"].ToString();
                txtFamilyName.Text = results["family_name"].ToString();
                txtAddress.Text = results["address"].ToString();
                txtCity.Text = results["city"].ToString();
                txtPostal.Text = results["postal_code"].ToString();
                txtPhone.Text = asPhone(results["phone"].ToString());
                txtPhone2.Text = results["phone2"].ToString();
                txtEmail.Text = results["email"].ToString();
                txtIDNum.Text = results["client_id"].ToString();
                txtCitizenCert.Text = results["citizen_cert"].ToString();
                cmbContract.Text = results["contract_type"].ToString();
                cmbStatus.Text = results["contract_status"].ToString();
                chkVP.Checked = (results["vp"].ToString() == "1");
                NeedAddress = (results["research_consent_fed"].ToString() == "1" || results["research_consent_prov"].ToString() == "1");
                results.Close();
                InitializeComments();
                InitializeVisits();
                SetErrorProviders();
                Show();
            }
            else
            {
                results.Close();
                new Message("Error: Client record not found.");
                Close();
            }
        }

        private void ClientRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (txtGivenName.Enabled) //unlock records on writeable form close
            {
                OdbcCommand query = new OdbcCommand("UPDATE client set edit_locked = 0 where id = '" + ClientID + "'", Utilities.kis_clients);
                query.ExecuteNonQuery();
            }
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private string asPhone(string phone)
        {
            if (phone.Length == 10)
            {
                return phone.Substring(0, 3) + "-" + phone.Substring(3, 3) + "-" + phone.Substring(6, 4);
            }
            else return phone;
        }

        private string asNumber(string phone)
        {
            if (phone != "   -   -") //blank masked text field
            {
                return phone.Substring(0, 3) + phone.Substring(4, 3) + phone.Substring(8, 4);
            }
            else return phone;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                string queryText = "";
                if (ClientID > 0) //existing record
                {
                    queryText = "UPDATE client SET " +
                        "client_id = '" + txtIDNum.Text + "', " +
                        "citizen_cert = '" + txtCitizenCert.Text + "', " +
                        "given_name = '" + Utilities.MySQL_String(txtGivenName.Text) + "', " +
                        "family_name = '" + Utilities.MySQL_String(txtFamilyName.Text) + "', " +
                        "contract_type = '" + cmbContract.Text + "', " +
                        "contract_status = '" + Utilities.MySQL_String(cmbStatus.Text) + "', " +
                        "address = '" + Utilities.MySQL_String(txtAddress.Text) + "', " +
                        "city = '" + Utilities.MySQL_String(txtCity.Text) + "', " +
                        "postal_code = '" + Utilities.MySQL_String(txtPostal.Text) + "', " +
                        "phone = '" + asNumber(txtPhone.Text) + "', " +
                        "phone2 = '" + txtPhone2.Text + "', " +
                        "email = '" + Utilities.MySQL_String(txtEmail.Text) + "', " +
                        "vp = '" + (chkVP.Checked ? 1 : 0) + "' " +
                        "WHERE id = '" + ClientID + "'";
                }
                else //new record
                {
                    queryText = "INSERT INTO client (" +
                            "client_id, citizen_cert, given_name, family_name, contract_type, " +
                            "contract_status, address, city, postal_code, phone, phone2, email, vp, edit_locked) VALUES ('" + txtIDNum.Text + "', " +
                            "'" + txtCitizenCert.Text + "', " +
                            "'" + Utilities.MySQL_String(txtGivenName.Text) + "', " +
                            "'" + Utilities.MySQL_String(txtFamilyName.Text) + "', " +
                            "'" + cmbContract.Text + "', " +
                            "'" + Utilities.MySQL_String(cmbStatus.Text) + "', " +
                            "'" + Utilities.MySQL_String(txtAddress.Text) + "', " +
                            "'" + Utilities.MySQL_String(txtCity.Text) + "', " +
                            "'" + Utilities.MySQL_String(txtPostal.Text) + "', " +
                            "'" + asNumber(txtPhone.Text) + "', " +
                            "'" + txtPhone2.Text + "', " +
                            "'" + Utilities.MySQL_String(txtEmail.Text) + "', " +
                            "'" + (chkVP.Checked ? 1 : 0) + "', " +
                            "'" + UserData.userID + "')";
                }
                OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
                if ((int)query.ExecuteNonQuery() == 0)
                {
                    new Message("SQL Error: Data cannot be saved as written.");
                }
                else
                {
                    if (ClientID == 0) //new record, open details form for further data entry
                    {
                        queryText = "SELECT MAX(id) FROM client";
                        query.CommandText = queryText;
                        ClientID = (int)query.ExecuteScalar();
                        new ClientDetail(ClientID, out NeedAddress, ReadOnly, true  );
                    }
                    Close();
                }
            }
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            new Services(ClientID, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CommentAdd(ClientID);
            InitializeComments(); //refresh list
        }

        private void btnVisitAdd_Click(object sender, EventArgs e)
        {
            new CommentAdd(ClientID, true);
            InitializeVisits(); //refresh list
        }

        private void lstComments_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(lstComments.Items[e.Index].ToString(), lstComments.Font, lstComments.Width).Height;
        }

        private void lstComments_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index > -1)  
                e.Graphics.DrawString(lstComments.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void lstVisits_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(lstVisits.Items[e.Index].ToString(), lstVisits.Font, lstVisits.Width).Height;
        }

        private void lstVisits_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index > -1)
                e.Graphics.DrawString(lstVisits.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void lstComments_DoubleClick(object sender, EventArgs e)
        {
            if (lstComments.SelectedIndex > -1)
            {
                Comment selComment = (Comment)lstComments.SelectedItem;
                if (ReadOnly) new CommentAdd(selComment.FullText, selComment.Date);
                else
                {
                    new CommentAdd(selComment.FullText, selComment.Date, selComment.IntID);
                    InitializeComments();
                }
            }
        }

        private void lstVisits_DoubleClick(object sender, EventArgs e)
        {
            if (lstVisits.SelectedIndex > -1)
            {
                Comment selVisit = (Comment)lstVisits.SelectedItem;
                if (ReadOnly) new CommentAdd(selVisit.FullText, selVisit.Date);
                else
                {
                    new CommentAdd(selVisit.FullText, selVisit.Date, selVisit.IntID, true);
                    InitializeVisits();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            new ClientDetail(ClientID, out NeedAddress, ReadOnly);
        }

        private void InitializeComments()
        {
            List<Comment> newData = new List<Comment>();
            OdbcCommand query = new OdbcCommand("SELECT comment.id, client, comment_date, staff, comment_text, given_name, family_name from comment, staff " +
                "WHERE client = '" + ClientID + "' AND comment.staff = staff.id", Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            if (results.HasRows)
            {
                while (results.Read())
                {
                    newData.Add(new Comment((int)results["id"], results["comment_date"].ToString(),
                        results["family_name"].ToString() + ", " + results["given_name"].ToString(), results["comment_text"].ToString()));
                }
            }
            lstComments.DataSource = newData;
            lstComments.SelectedIndex = -1;
            results.Close();
        }

        private void InitializeVisits()
        {
            List<Comment> newData = new List<Comment>();
            OdbcCommand query = new OdbcCommand("SELECT visit.id, client, comment_date, staff, comment_text, given_name, family_name from visit, staff " +
                "WHERE client = '" + ClientID + "' AND visit.staff = staff.id", Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            if (results.HasRows)
            {
                while (results.Read())
                {
                    newData.Add(new Comment((int)results["id"], results["comment_date"].ToString(),
                        results["family_name"].ToString() + ", " + results["given_name"].ToString(), results["comment_text"].ToString()));
                }
            }
            lstVisits.DataSource = newData;
            lstVisits.SelectedIndex = -1;
            results.Close();
        }

        private void SetErrorProviders()
        {
            erpAddress.SetIconAlignment(txtAddress, ErrorIconAlignment.MiddleRight);
            erpAddress.SetIconPadding(txtAddress, 2);

            erpCity.SetIconAlignment(txtCity, ErrorIconAlignment.MiddleRight);
            erpCity.SetIconPadding(txtCity, 2);

            erpPostal.SetIconAlignment(txtPostal, ErrorIconAlignment.MiddleRight);
            erpPostal.SetIconPadding(txtPostal, 2);

            erpContract.SetIconAlignment(cmbContract, ErrorIconAlignment.MiddleRight);
            erpContract.SetIconPadding(cmbContract, 2);

            erpStatus.SetIconAlignment(cmbStatus, ErrorIconAlignment.MiddleRight);
            erpStatus.SetIconPadding(cmbStatus, 2);

            erpPhone.SetIconAlignment(txtPhone, ErrorIconAlignment.MiddleRight);
            erpPhone.SetIconPadding(txtPhone, 2);

            erpEmail.SetIconAlignment(txtEmail, ErrorIconAlignment.MiddleRight);
            erpEmail.SetIconPadding(txtEmail, 2);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (NeedAddress && txtAddress.Text.Length == 0) //Consent values (NeedAddress) are checked in ClientDetail
            {
                erpAddress.SetError(txtAddress, "Clients who consent to research must provide a full address.");
                e.Cancel = true;
            }
            else
            {
                erpAddress.SetError(txtAddress, String.Empty);
            }
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (NeedAddress && txtCity.Text.Length == 0) //Consent values (NeedAddress) are checked in ClientDetail
            {
                erpCity.SetError(txtCity, "Clients who consent to research must provide a full address.");
                e.Cancel = true;
            }
            else
            {
                erpCity.SetError(txtCity, String.Empty);
            }
        }

        private void txtPostal_Validating(object sender, CancelEventArgs e)
        {
            if (txtPostal.Text.Length != 6)
            {
                erpPostal.SetError(txtPostal, "Postal code is required.");
                e.Cancel = true;
            }
            else
            {
                erpPostal.SetError(txtPostal, String.Empty);
            }
        }

        private void cmbContract_Validating(object sender, CancelEventArgs e)
        {
            if (cmbContract.SelectedIndex == -1)
            {
                erpContract.SetError(cmbContract, "A contract must be selected.");
                e.Cancel = true;
            }
            else
            {
                erpContract.SetError(cmbContract, String.Empty);
            }
        }

        private void cmbStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cmbStatus.Text == "")
            {
                erpStatus.SetError(cmbStatus, "A status must be selected.");
                e.Cancel = true;
            }
            else
            {
                erpStatus.SetError(cmbStatus, String.Empty);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhone.Text.Length != 12 && txtPhone.Text != "   -   -")
            {
                erpPhone.SetError(txtPhone, "Please enter the full 10 digits if providing a phone number.");
                e.Cancel = true;
            }
            else
            {
                erpPhone.SetError(txtPhone, String.Empty);
            }
        }
        //Phone2 is also for international number use and thus not validated for format

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Length != 0 && (txtEmail.Text.IndexOf("@") == -1 || txtEmail.Text.Substring(txtEmail.Text.IndexOf("@")).IndexOf(".") == -1))
            {
                erpEmail.SetError(txtEmail, "Please check the format of the provided email address (x@y.z).");
                e.Cancel = true;
            }
            else
            {
                erpEmail.SetError(txtEmail, String.Empty);
            }
        }

        public class Comment
        {
            public int IntID;
            public string DisplayText;
            public string FullText;
            public string Date;

            public Comment(int inIntID, string inDate, string inStaffName, string inComment)
            {
                IntID = inIntID;
                Date = inDate;
                int length = (inComment.Length < 100) ? inComment.Length : 100; //show a preview for especially long comments
                DisplayText = DateTime.Parse(Date).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + " | " + inStaffName + " | " + inComment.Substring(0, length);
                FullText = inComment;
            }

            override public string ToString()
            {
                return DisplayText;
            }
        }

        //set the cursor to the beginning of an empty masked field, or the end of the entered text
        private void txtIDNum_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (txtIDNum.Text == "" || txtIDNum.Text == "0")
                {
                    txtIDNum.Select(0,1);
                }
                else
                {
                    txtIDNum.Select(txtIDNum.Text.Length, 0);
                }
            });
        }

        //set the cursor to the beginning of an empty masked field, or the end of the entered text
        private void txtCitizenCert_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (txtCitizenCert.Text == "" || txtCitizenCert.Text == "0")
                {
                    txtCitizenCert.Select(0, 1);
                }
                else
                {
                    txtCitizenCert.Select(txtCitizenCert.Text.Length, 0);
                }
            });
        }

        //set the cursor to the beginning of an empty masked field, or the end of the entered text
        private void txtPostal_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (txtPostal.Text == "" || txtPostal.Text == "0")
                {
                    txtPostal.Select(0, 0);
                }
                else
                {
                    txtPostal.Select(txtPostal.Text.Length, 0);
                }
            });
        }

        //set the cursor to the beginning of an empty masked field, or the end of the entered text
        private void txtPhone_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (txtPhone.Text == "" || txtPhone.Text == "0" || txtPhone.Text == "   -   -")
                {
                    txtPhone.Select(0, 0);
                }
                else
                {
                    txtPhone.Select(txtPhone.Text.Length, 0);
                }
            });
        }

        //set the cursor to the beginning of an empty field, or the end of the entered text
        private void txtPhone2_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (txtPhone2.Text == "" || txtPhone2.Text == "0")
                {
                    txtPhone2.Select(0, 0);
                }
                else
                {
                    txtPhone2.Select(txtPhone2.Text.Length, 0);
                }
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var confirm = new Authorize()) //Ensure deletions aren't done accidentally
            {
                var result = confirm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OdbcCommand query = new OdbcCommand("DELETE from client where id = '" + ClientID + "'", Utilities.kis_clients);
                    query.ExecuteNonQuery();
                    Close();
                }
            }
        }

        //unlock a record that is stuck locked (e.g. if a hard crash occurred while a record was open)
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            using (var confirm = new Authorize()) //Get the user to confirm that they haven't just double-opened the record before unlocking
            {
                var result = confirm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OdbcCommand query = new OdbcCommand("UPDATE client SET edit_locked = 0 WHERE id = " + ClientID, Utilities.kis_clients);
                    query.ExecuteNonQuery();
                    Close();
                    new ClientRecord(ClientID);
                }
            }
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            new Attachments(ClientID);
        }
    }
}
