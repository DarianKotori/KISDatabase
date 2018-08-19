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
    //Generate a selection of user-customizable reports
    public partial class Reporting : Form
    {
        private int StaffID = 0;
        private string Contract = "";
        public Reporting()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            //Populate staff list
            string userString = "All Users";
            cmbStaff.Items.Add(userString);
            OdbcCommand query = new OdbcCommand("SELECT * FROM staff", Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                userString = results["id"].ToString() + " " + results["given_name"] + " " + results["family_name"].ToString();
                cmbStaff.Items.Add(userString);
            }
            results.Close();
            cmbStaff.SelectedIndex = 0;
            cmbContract.SelectedIndex = 0;
            cmbReport.SelectedIndex = 0;
            dtpStart.Value = Utilities.getReportingYearStart(DateTime.Now);
            dtpEnd.Value = Utilities.getReportingYearEnd(DateTime.Now);
            CheckValid();
            Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();
            string staff = cmbStaff.SelectedItem.ToString();
            //Assign user-selected variables
            StaffID = (cmbStaff.SelectedIndex == 0 ? 0 : Int32.Parse(staff.Substring(0, staff.IndexOf(" "))));
            if (cmbContract.SelectedIndex == 0) Contract = "";
            else if (cmbContract.SelectedIndex == 1) Contract = "Fed";
            else if (cmbContract.SelectedIndex == 2) Contract = "Prov";
            else Contract = "Non";
            if (cmbReport.SelectedItem.ToString() == "Provincial Quarterly Data")
            {
                dgvReport.ColumnCount = 7;
                ServicesByStatus();
                ServicesByStatusAndType();
            }
            else if (cmbReport.SelectedItem.ToString() == "Services Provided")
            {
                dgvReport.ColumnCount = 3;
                ServicesProvided();
            }
            else if (cmbReport.SelectedItem.ToString() == "Services By Status")
            {
                ServicesByStatus();
            }
            else if (cmbReport.SelectedItem.ToString() == "Services By Status And Type")
            {
                ServicesByStatusAndType();
            }
            else if (cmbReport.SelectedItem.ToString() == "First Languages")
            {
                dgvReport.ColumnCount = 2;
                FirstLanguages();
            }
            else if (cmbReport.SelectedItem.ToString() == "Clients Served By Country of Birth")
            {
                CountriesOfBirth();
            }
            else if (cmbReport.SelectedItem.ToString() == "Clients Served By Skill Level")
            {
                ClientsServedBySkillLevel();
            }
            else if (cmbReport.SelectedItem.ToString() == "Clients Served By Age")
            {
                ClientsServedByAge();
            }
            else if (cmbReport.SelectedItem.ToString() == "Clients Served By Years In Canada")
            {
                ClientsServedByYearsInCanada();
            }
            else if (cmbReport.SelectedItem.ToString() == "Client Mailing List")
            {
                dgvReport.ColumnCount = 2;
                ClientMailingList();
            }
            else if (cmbReport.SelectedItem.ToString() == "Client Contact Information")
            {
                dgvReport.ColumnCount = 11;
                ClientContactInformation();
            }
            dgvReport.Focus();
        }
        
        //Displays the number of unique clients each individual service was provided to
        private void ServicesProvided()
        {
            string[] titles = { "Category", "Service", "Clients Served" };
            dgvReport.Rows.Add(titles);
            string queryText = "SELECT service.category, service.service_name, count(DISTINCT client) AS count " +
                "FROM service LEFT JOIN (select received_services.* from received_services JOIN client ON (received_services.client = client.id" +
                (Contract == "" ? "" : " AND client.contract_type = '" + Contract + "'") +
                ")" +
                (chkAllTime.Checked ? "" : " JOIN visit ON received_services.visit = visit.id AND visit.comment_date >= '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date <= '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "'") +
                ") AS received_services ON (service.id = received_services.service" + 
                (StaffID != 0 ? " AND received_services.staff = '" + StaffID + "'" : "") + 
                ") GROUP BY service.category, service.service_name";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                string[] row = {results["category"].ToString(), results["service_name"].ToString(), results["count"].ToString()};
                dgvReport.Rows.Add(row);
            }
        }

        //Displays the number of unique clients who received any service, divided by immigration status
        private void ServicesByStatus()
        {
            List<int> counts = new List<int>();
            List<string> statuses = new List<string>();
            string queryText = "SELECT contract_status, count(DISTINCT received_services.client) AS count " +
                "FROM client JOIN received_services ON (client.id = received_services.client) " + 
                (chkAllTime.Checked ? "" : " JOIN visit ON (received_services.visit = visit.id AND visit.comment_date >= '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date <= '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "') ") +
                "WHERE client.id > 0" +
                (Contract == "" ? "" : " AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND received_services.staff = '" + StaffID + "'" : "") +
                " GROUP BY contract_status ORDER BY contract_status";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                counts.Add(Int32.Parse(results["count"].ToString()));
                statuses.Add(results["contract_status"].ToString());
            }
            dgvReport.ColumnCount = statuses.Count + 2;
            string[] row = new string[statuses.Count + 2];
            for (int i = 1; i <= statuses.Count; i++)
            {
                row[i] = statuses[i - 1];
            }
            row[0] = "Services";
            row[statuses.Count + 1] = "Total";
            dgvReport.Rows.Add(row);
            List<string> countRow = new List<string>();
            countRow.Add("");
            foreach(int count in counts)
            {
                countRow.Add(count.ToString());
            }
            countRow.Add(counts.Sum().ToString());
            dgvReport.Rows.Add(countRow.ToArray());
        }

        //Displays the number of unique users who received at least one of a selected list of services, divided by immigration status
        private void ServicesByStatusAndType()
        {
            string services = "";
            //Display services form to user, collect list of desired services
            using (Services serviceForm = new Services(0, false))
            {
                if (serviceForm.DialogResult == DialogResult.OK)
                {
                    services = serviceForm.ServiceList;
                }
            }
            if (services == "")
            {
                new Message("No services selected.");
            }
            else
            {
                List<int> counts = new List<int>();
                List<string> statuses = new List<string>();
                string queryText = "SELECT contract_status, count(DISTINCT received_services.client) AS count " +
                    "FROM client JOIN received_services ON (client.id = received_services.client) " +
                    (chkAllTime.Checked ? "" : " JOIN visit ON (received_services.visit = visit.id AND visit.comment_date >= '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date <= '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "') ") +
                    "WHERE received_services.service IN (" + services + ")" +
                    (Contract == "" ? "" : " AND client.contract_type = '" + Contract + "' ") +
                    (StaffID != 0 ? " AND received_services.staff = '" + StaffID + "'" : "") +
                    " GROUP BY contract_status ORDER BY contract_status";
                OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
                OdbcDataReader results = query.ExecuteReader();
                while (results.Read())
                {
                    counts.Add(Int32.Parse(results["count"].ToString()));
                    statuses.Add(results["contract_status"].ToString());
                }
                dgvReport.ColumnCount = statuses.Count + 2;
                string[] row = new string[statuses.Count + 2];
                for (int i = 1; i <= statuses.Count; i++)
                {
                    row[i] = statuses[i - 1];
                }
                row[0] = "Services";
                row[statuses.Count + 1] = "Total";
                dgvReport.Rows.Add(row);
                List<string> countRow = new List<string>();
                countRow.Add("Selected Services");
                foreach (int count in counts)
                {
                    countRow.Add(count.ToString());
                }
                countRow.Add(counts.Sum().ToString());
                dgvReport.Rows.Add(countRow.ToArray());
            }
        }

        //Display the number of users who received at least one service, divided by language spoken at home and immigration status
        private void FirstLanguages()
        {
            string[] titles = { "Language", "Clients" };
            dgvReport.Rows.Add(titles);
            string queryText = "SELECT client.id, client.home_language, count(DISTINCT client.id) as count FROM client " + 
                (chkAllTime.Checked ? "" : "JOIN visit ON client.id = visit.client AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") +
                (Contract == "" ? "" : "WHERE contract_type = '" + Contract + "' ") + 
                "GROUP BY home_language";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                string[] row = { results["home_language"].ToString(), results["count"].ToString() };
                dgvReport.Rows.Add(row);
            }
        }

        //Display the number of users who received at least one service, divided by country of birth and immigration status
        private void CountriesOfBirth()
        {
            List<int[]> counts = new List<int[]>();
            List<string> statuses = new List<string>();
            string status = "", country;
            int index;
            bool first = true;
            //get list of represented countries
            string queryText = "SELECT DISTINCT (client.birth_country) " +
                "FROM client JOIN visit ON(client.id = visit.client " +
                (Contract == "" ? "" : "AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND visit.staff = '" + StaffID + "'" : "") +
                (chkAllTime.Checked ? "" : " AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") +
                ") ORDER BY client.birth_country";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            List<string> countries = new List<string>();
            while (results.Read())
            {
                countries.Add(results["birth_country"].ToString());
            }
            int[] clients = new int[countries.Count];
            results.Close();
            //get represented statuses and clients
            queryText = "SELECT DISTINCT (client.id), client.birth_country, client.contract_status " +
                "FROM client JOIN visit ON(client.id = visit.client " +
                (Contract == "" ? "" : "AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND visit.staff = '" + StaffID + "'" : "") +
                (chkAllTime.Checked ? "" : " AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") +
                ") ORDER BY client.contract_status";
            query.CommandText = queryText;
            results = query.ExecuteReader();
            while (results.Read())
            {
                //total statuses in turn
                if (status != results["contract_status"].ToString())
                {
                    if (status != "" || !first)
                    {
                        statuses.Add(status);
                        counts.Add(clients.ToArray());
                        clients = new int[countries.Count];
                    }
                    status = results["contract_status"].ToString();
                }
                country = results["birth_country"].ToString();
                index = countries.IndexOf(country);
                if (index > -1)
                {
                    clients[index]++;
                }
                first = false;
            }
            statuses.Add(status);
            counts.Add(clients.ToArray());
            dgvReport.ColumnCount = statuses.Count + 2;
            string[] row = new string[statuses.Count + 2];
            int total;
            for (int i = 1; i <= statuses.Count; i++)
            {
                row[i] = statuses[i - 1];
            }
            row[0] = "Country of Birth";
            row[statuses.Count + 1] = "Total";
            dgvReport.Rows.Add(row);
            for (int i = 0; i < countries.Count; i++)
            {
                total = 0;
                row[0] = countries[i];
                for (int j = 1; j <= statuses.Count; j++)
                {
                    row[j] = counts[j - 1][i].ToString();
                    total += counts[j - 1][i];
                }
                row[statuses.Count + 1] = total.ToString();
                dgvReport.Rows.Add(row);
            }
        }

        //Display the number of users who received at least one service, divided by immigration status and age category
        private void ClientsServedByAge()
        {
            int[] clients = { 0, 0, 0, 0, 0 };
            string[] levels = { "Unknown", "Under 6", "6-18", "19-64", "65 and over" };
            List<int[]> counts = new List<int[]>();
            List<string> statuses = new List<string>();
            string status = "";
            int age = 0;
            bool first = true;
            DateTime dob, def;
            def = new DateTime(1900, 1, 1);
            string queryText = "SELECT DISTINCT (client.id), client.DOB, client.contract_status " +
                "FROM client JOIN visit ON(client.id = visit.client " +
                (Contract == "" ? "" : "AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND visit.staff = '" + StaffID + "'" : "") +
                (chkAllTime.Checked ? "" : " AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") +
                ") ORDER BY client.contract_status";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                if (status != results["contract_status"].ToString())
                {
                    if (status != "" || !first)
                    {
                        statuses.Add(status);
                        counts.Add(clients.ToArray());
                        clients = new int[] { 0, 0, 0, 0, 0 };
                    }
                    status = results["contract_status"].ToString();
                }
                if (DateTime.TryParse(results["DOB"].ToString(), out dob))
                {
                    if (DateTime.Compare(dob, def) > 0)
                    {
                        age = DateTime.Now.Year - dob.Year;
                        if (DateTime.Now.DayOfYear < dob.DayOfYear) age--;
                        if (age < 6) clients[1]++;
                        else if (age < 19) clients[2]++;
                        else if (age < 65) clients[3]++;
                        else clients[4]++;
                    }
                    else
                    {
                        clients[0]++;
                    }
                }
                else
                {
                    clients[0]++;
                }
                first = false;
            }
            statuses.Add(status);
            counts.Add(clients.ToArray());
            dgvReport.ColumnCount = statuses.Count + 2;
            string[] row = new string[statuses.Count + 2];
            int total;
            for (int i = 1; i <= statuses.Count; i++)
            {
                row[i] = statuses[i - 1];
            }
            row[0] = "Age";
            row[statuses.Count + 1] = "Total";
            dgvReport.Rows.Add(row);
            for (int i = 0; i < levels.Length; i++)
            {
                total = 0;
                row[0] = levels[i];
                for (int j = 1; j <= statuses.Count; j++)
                {
                    row[j] = counts[j - 1][i].ToString();
                    total += counts[j - 1][i];
                }
                row[statuses.Count + 1] = total.ToString();
                dgvReport.Rows.Add(row);
            }
        }

        //Display the number of users who received at least one service, divided by immigration status and years in Canada
        private void ClientsServedByYearsInCanada()
        {
            int[] clients = { 0, 0, 0, 0, 0, 0 };
            string[] levels = { "Unknown", "Under 1 year", "1-3 years", "4-5 years", "6-10 years", "Over 10 years" };
            List<int[]> counts = new List<int[]>();
            List<string> statuses = new List<string>();
            string status = "";
            int year, years = 0;
            bool first = true;
            string queryText = "SELECT DISTINCT (client.id), client.arrival_year, client.contract_status " +
                "FROM client JOIN visit ON(client.id = visit.client " +
                (Contract == "" ? "" : "AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND visit.staff = '" + StaffID + "'" : "") +
                (chkAllTime.Checked ? "" : " AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") +
                ") ORDER BY client.contract_status";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                if (status != results["contract_status"].ToString())
                {
                    if (status != "" || !first)
                    {
                        statuses.Add(status);
                        counts.Add(clients.ToArray());
                        clients = new int[] { 0, 0, 0, 0, 0, 0 };
                    }
                    status = results["contract_status"].ToString();
                }
                if (Int32.TryParse(results["arrival_year"].ToString(), out year))
                {
                    if (year > 0)
                    {
                        years = DateTime.Now.Year - year;
                        if (years < 1) clients[1]++;
                        else if (years < 4) clients[2]++;
                        else if (years < 6) clients[3]++;
                        else if (years < 11) clients[4]++;
                        else clients[5]++;
                    }
                    else
                    {
                        clients[0]++;
                    }
                }
                else
                {
                    clients[0]++;
                }
                first = false;
            }
            statuses.Add(status);
            counts.Add(clients.ToArray());
            dgvReport.ColumnCount = statuses.Count + 2;
            string[] row = new string[statuses.Count + 2];
            int total;
            for (int i = 1; i <= statuses.Count; i++)
            {
                row[i] = statuses[i - 1];
            }
            row[0] = "Years in Canada";
            row[statuses.Count + 1] = "Total";
            dgvReport.Rows.Add(row);
            for (int i = 0; i < levels.Length; i++)
            {
                total = 0;
                row[0] = levels[i];
                for (int j = 1; j <= statuses.Count; j++)
                {
                    row[j] = counts[j - 1][i].ToString();
                    total += counts[j - 1][i];
                }
                row[statuses.Count + 1] = total.ToString();
                dgvReport.Rows.Add(row);
            }
        }

        //Display a list of all clients who have provided permission to send email notices and their email addresses
        private void ClientMailingList()
        {
            string[] titles = { "Name", "Email Address" };
            dgvReport.Rows.Add(titles);
            string queryText = "SELECT client.id, client.given_name, client.family_name, client.email FROM client " +
                "WHERE notifications = 1" + 
                (Contract == "" ? "" : " AND contract_type = '" + Contract + "'");
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                string[] row = { results["family_name"].ToString() + ", " + results["given_name"].ToString(), results["email"].ToString() };
                dgvReport.Rows.Add(row);
            }
        }

        //Display contact information for all clients
        private void ClientContactInformation()
        {
            string[] titles = { "Surname", "Given Name", "Phone", "Secondary Phone", "Email Address", "Email Consent", "Client ID", "Date of Birth", "Address", "City", "Postal Code" };
            dgvReport.Rows.Add(titles);
            string queryText = "SELECT client.client_id, client.given_name, client.family_name, client.email, client.phone, client.phone2, client.notifications, client.dob, client.address, client.city, client.postal_code FROM client" +
                (Contract == "" ? "" : " WHERE contract_type = '" + Contract + "'")
                + " ORDER BY client.family_name";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            DateTime dob = new DateTime();
            string dobOut = "";
            while (results.Read())
            {
                if (DateTime.TryParse(results["dob"].ToString(), out dob))
                    dobOut = dob.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                else
                    dobOut = "";
                string[] row = { results["family_name"].ToString(), results["given_name"].ToString(), results["phone"].ToString(),
                    results["phone2"].ToString(), results["email"].ToString(), (results["notifications"].ToString() == "1" ? "Y" : "N"),
                    results["client_id"].ToString(), dobOut, results["address"].ToString(), results["city"].ToString(), results["postal_code"].ToString() };
                dgvReport.Rows.Add(row);
            }
        }

        //Display the number of users who received at least one service, divided by immigration status and job skill level (per NOC)
        private void ClientsServedBySkillLevel()
        {
            int[] clients = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string[] levels = { "N/A", "Student", "Retired", "Unemployed", "0", "A", "B", "C", "D" };
            List<int[]> counts = new List<int[]>();
            List<string> statuses = new List<string>();
            string status = "", occupation, first, second, third;
            int noc = 0;
            bool firstRec = true;
            string queryText = "SELECT DISTINCT (client.id), client.occupation, client.contract_status " +
                "FROM client JOIN visit ON(client.id = visit.client " +
                (Contract == "" ? "" : "AND client.contract_type = '" + Contract + "' ") +
                (StaffID != 0 ? " AND visit.staff = '" + StaffID + "'" : "") +
                (chkAllTime.Checked ? "" : " AND visit.comment_date > '" + dtpStart.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' AND visit.comment_date < '" + dtpEnd.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "' ") + 
                ") ORDER BY client.contract_status";
            OdbcCommand query = new OdbcCommand(queryText, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                if (status != results["contract_status"].ToString())
                {
                    if (status != "" || !firstRec)
                    {
                        statuses.Add(status);
                        counts.Add(clients.ToArray());
                        clients = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                    status = results["contract_status"].ToString();
                }
                Int32.TryParse(results["occupation"].ToString(), out noc);
                occupation = noc.ToString("0000");
                if (occupation.Length > 3)
                {
                    first = occupation.Substring(occupation.Length - 4, 1);
                    second = occupation.Substring(occupation.Length - 3, 1);
                    third = occupation.Substring(occupation.Length - 2, 1);
                    if (occupation == "0001") clients[1]++;
                    else if (occupation == "0002") clients[2]++;
                    else if (occupation == "0003") clients[3]++;
                    else if (first == "0" && second == "0" && third == "0") clients[0]++;
                    else if (first == "0") clients[4]++;
                    else if (second == "0" || second == "1") clients[5]++;
                    else if (second == "2" || second == "3") clients[6]++;
                    else if (second == "4" || second == "5") clients[7]++;
                    else if (second == "6" || second == "7") clients[8]++;
                }
                else
                {
                    clients[0]++;
                }
                firstRec = false;
            }
            statuses.Add(status);
            counts.Add(clients.ToArray());
            dgvReport.ColumnCount = statuses.Count + 2;
            string[] row = new string[statuses.Count + 2];
            int total;
            for (int i = 1; i <= statuses.Count; i++) {
                row[i] = statuses[i-1];
            }
            row[0] = "Level";
            row[statuses.Count + 1] = "Total";
            dgvReport.Rows.Add(row);
            for (int i = 0; i < levels.Length; i++)
            {
                total = 0;
                row[0] = levels[i];
                for (int j = 1; j <= statuses.Count; j++)
                {
                    row[j] = counts[j-1][i].ToString();
                    total += counts[j-1][i];
                }
                row[statuses.Count + 1] = total.ToString();
                dgvReport.Rows.Add(row);
            }
        }

        private void Reporting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        private void chkAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = !chkAllTime.Checked;
            dtpEnd.Enabled = !chkAllTime.Checked;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.CompareTo(dtpEnd.Value) > 0)
            {
                dtpEnd.Value = dtpStart.Value;
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.CompareTo(dtpEnd.Value) > 0)
            {
                dtpStart.Value = dtpEnd.Value;
            }
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        //Enables or disables certain options based on the report selected
        private void CheckValid()
        {
            cmbStaff.Enabled = true;
            cmbContract.Enabled = true;
            chkAllTime.Enabled = true;
            if (!chkAllTime.Checked)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            if (cmbReport.SelectedItem.ToString() == "Provincial Quarterly Data")
            {
                cmbContract.SelectedIndex = 2;
                cmbContract.Enabled = false;
                cmbStaff.SelectedIndex = 0;
                cmbStaff.Enabled = false;
            }
            else if (cmbReport.SelectedItem.ToString() == "First Languages")
            {
                cmbStaff.Enabled = false;
            }
            else if (cmbReport.SelectedItem.ToString() == "Client Mailing List")
            {
                cmbStaff.Enabled = false;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                chkAllTime.Enabled = false;
            }
            else if (cmbReport.SelectedItem.ToString() == "Client Contact Information")
            {
                cmbStaff.Enabled = false;
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                chkAllTime.Enabled = false;
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^c");
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^a");
        }

        //Auto-sizes report grid to match window
        private void Reporting_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height > 642) dgvReport.Height = this.Height - 87;
            else dgvReport.Height = 555;
            if (this.Width > 1279) dgvReport.Width = this.Width - 463;
            else dgvReport.Width = 816;
        }
    }
}