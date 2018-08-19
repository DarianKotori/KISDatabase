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
using System.IO;

namespace KISDatabase
{
    public partial class Attachments : Form
    {
        private int ClientID;

        public Attachments(int ID) //load by client ID
        {
            InitializeComponent();
            ClientID = ID;
            InitializeAttachments();
            ShowDialog();
        }

        private void InitializeAttachments()
        {
            byte[] rawdata;
            int length;
            List<Attachment> newData = new List<Attachment>();
            OdbcCommand query = new OdbcCommand("SELECT id, name, data, length(data) as length FROM attachment WHERE client = " + ClientID, Utilities.kis_clients);
            OdbcDataReader results = query.ExecuteReader();
            while (results.Read())
            {
                length = Int32.Parse(results["length"].ToString());
                rawdata = new byte[length];
                results.GetBytes(2, 0, rawdata, 0, length);
                newData.Add(new Attachment(Int32.Parse(results["id"].ToString()), results["name"].ToString(), rawdata));
            }
            lstFiles.DataSource = newData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private class Attachment
        {
            //attachments stored as raw binary data
            public int ID;
            public string Name;
            public byte[] Data;

            public Attachment(int inID, string inName, byte[] inData)
            {
                ID = inID;
                Name = inName;
                Data = inData;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                btnOpen.Enabled = false;
                btnOpen.Cursor = Cursors.WaitCursor;
                //write file to temp folder
                Attachment file = (Attachment)lstFiles.SelectedItem;
                string temp = Path.GetTempPath();
                temp += file.Name;
                File.WriteAllBytes(temp, file.Data);
                //open using system default application
                System.Diagnostics.Process.Start(temp);
                btnOpen.Enabled = true;
                btnOpen.Cursor = Cursors.Arrow;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = opnFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                Stream fileData = opnFile.OpenFile();
                MemoryStream ms = new MemoryStream();
                fileData.CopyTo(ms);
                byte[] data = ms.ToArray();
                OdbcCommand query = new OdbcCommand("INSERT INTO attachment (client, name, data) VALUES (?, ?, ?)", Utilities.kis_clients);
                OdbcParameterCollection parameters = query.Parameters;
                query.Parameters.Add("client", OdbcType.Int);
                query.Parameters.Add("name", OdbcType.VarChar);
                query.Parameters.Add("data", OdbcType.Binary);
                query.Parameters["client"].Value = ClientID;
                query.Parameters["name"].Value = opnFile.FileName.Substring(opnFile.FileName.LastIndexOf("\\")+1);
                query.Parameters["data"].Value = data;
                if (query.ExecuteNonQuery() == 0)
                    new Message("Failed to save attachment.");
                else
                    InitializeAttachments();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > -1)
            {
                Attachment file = (Attachment)lstFiles.SelectedItem;
                OdbcCommand query = new OdbcCommand("DELETE FROM attachment WHERE id = " + file.ID, Utilities.kis_clients);
                query.ExecuteNonQuery();
                InitializeAttachments();
            }
        }
    }
}
