using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KISDatabase
{
    //Generic alert popup
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            ShowDialog();
        }

        public Message(string newMessage)
        {
            InitializeComponent();
            MaximumSize = new Size(Screen.GetBounds(this).Width, Screen.GetBounds(this).Height - 50);
            lblMessage.Text = newMessage;
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
