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
    //Edit the list of provided services and the categories they fall under
    public partial class EditServices : Form
    {
        public EditServices()
        {
            InitializeComponent();
            InitializeFields();
            ShowDialog();
        }

        private void InitializeFields()
        {
            List<Service> serviceData = new List<Service>();
            List<string> categories = new List<string>();
            string category = "";
            serviceData.Add(new Service(0, "New...", ""));
            OdbcCommand query = new OdbcCommand("SELECT * FROM service ORDER BY category", Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                serviceData.Add(new Service(Int32.Parse(results["id"].ToString()), results["service_name"].ToString(), results["category"].ToString()));
                if (category != results["category"].ToString())
                {
                    category = results["category"].ToString();
                    categories.Add(category);
                }
            }
            cmbService.DataSource = serviceData;
            cmbCategory.DataSource = categories;
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbService.SelectedIndex == 0) //new service
            {
                txtName.Text = "";
                btnDelete.Enabled = false;
            }
            else
            {
                Service current = (Service)cmbService.SelectedItem;
                cmbCategory.Text = current.Category;
                txtName.Text = current.Name;
                btnDelete.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            OdbcCommand query = new OdbcCommand("", Utilities.kis_clients);
            if (cmbService.SelectedIndex == 0)
            {
                query.CommandText = "INSERT INTO service(service_name, category) VALUES ('" + Utilities.MySQL_String(txtName.Text) + "', '"
                    + Utilities.MySQL_String(cmbCategory.Text) + "')";
            }
            else
            {
                Service current = (Service)cmbService.SelectedItem;
                query.CommandText = "UPDATE service SET service_name = '" + Utilities.MySQL_String(txtName.Text) + "', category = '" +
                    Utilities.MySQL_String(cmbCategory.Text) + "' WHERE id = " + current.ID;
            }
            query.ExecuteNonQuery();
            new Message("Update successful.");
            InitializeFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var confirm = new Authorize()) //Deleting a service also deletes records of its use, so require confirmation
            {
                var result = confirm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Service current = (Service)cmbService.SelectedItem;
                    OdbcCommand query = new OdbcCommand("DELETE from service where id = '" + current.ID + "'", Utilities.kis_clients);
                    query.ExecuteNonQuery();
                    Close();
                }
            }
        }
    }

    public class Service
    {
        public int ID;
        public string Name, Category;

        public Service(int id, string name, string category)
        {
            ID = id;
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
