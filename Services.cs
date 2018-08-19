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
    //Display a list of available services with the ability to select from among them.
    public partial class Services : Form
    {
        private int ClientID;
        private bool Visit;
        private int VisitID;
        public string ServiceList;

        public Services(int ID, bool readOnly, bool visit = false, int visitID = 0)
        {
            InitializeComponent();
            ServiceList = "";
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ClientID = ID;
            Visit = visit;
            //Services are now always associated with a visit
            VisitID = visitID;
            if (Visit) Text = "Services Received During Visit";
            OdbcCommand query = new OdbcCommand("select DISTINCT service.id, service.service_name, service.category, received_services.client from service LEFT JOIN received_services on (service.id = received_services.service AND received_services.client = '" + ClientID + "' AND received_services.year = '" + Utilities.getReportingYear(DateTime.Now) + "') ORDER BY service.category, service.service_name", Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            int currentTop = 30;
            int currentLeft = 20;
            string category = "";
            if (results.HasRows)
            {
                //Write out services in columns sized to comfortably fit on the screen
                while (results.Read())
                {
                    currentTop += 40;
                    if (currentTop > Screen.GetBounds(this).Height / 1.5)
                    {
                        currentTop = 70;
                        currentLeft += 260;
                    }
                    if (category != results["category"].ToString())
                    {
                        category = results["category"].ToString();
                        Label lblCat = new Label();
                        lblCat.Name = "lbl" + results["category"];
                        lblCat.Left = currentLeft;
                        lblCat.Top = currentTop;
                        lblCat.Width = 200;
                        lblCat.Height = 23;
                        lblCat.Text = results["category"].ToString();
                        lblCat.Font = new Font(lblCat.Font, FontStyle.Bold);
                        Controls.Add(lblCat);
                        currentTop += 40;
                    }
                    Label lbl = new Label();
                    CheckBox chk = new CheckBox();
                    lbl.Name = "lbl" + results["service_name"].ToString();
                    lbl.Left = currentLeft + 9;
                    lbl.Top = currentTop;
                    lbl.Width = 200;
                    lbl.Height = 25;
                    lbl.Text = results["service_name"].ToString() + ":";
                    Controls.Add(lbl);
                    chk.Name = "chk" + results["id"].ToString();
                    chk.Left = currentLeft + 218;
                    chk.Top = currentTop-2;
                    chk.Width = 20;
                    chk.Text = "";
                    if (!Visit) chk.Checked = (results["client"] != DBNull.Value);
                    Controls.Add(chk);
                }
            }
            else
            {
                new Message("Error: No services defined.");
                Close();
            }
            if (readOnly)
            {
                foreach (Control child in this.Controls)
                {
                    if (child is CheckBox)
                        child.Enabled = false;
                }
                btnSave.Visible = false;
            }
            ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OdbcCommand query = new OdbcCommand("", Utilities.kis_clients);
            foreach (Control con in Controls)
            {
                if (con is CheckBox chk)
                {
                    if (chk.Checked)
                    {
                        string serviceID = chk.Name.Substring(3);
                        if (ServiceList != "") ServiceList += ",";
                        ServiceList += "'" + serviceID + "'";
                        if (ClientID > 0)
                        {
                            int staffID = (Visit ? UserData.userID : 0);
                            query.CommandText = "INSERT INTO received_services VALUES ('" + ClientID + "','" + serviceID + "', '" + Utilities.getReportingYear(DateTime.Now) + "', '" + staffID + "', '" + VisitID + "')";
                            if (query.ExecuteNonQuery() == 0)
                            {
                                new Message("SQL Error: Could not save service record.");
                                Close();
                            }
                        }
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
