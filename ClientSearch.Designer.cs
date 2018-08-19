namespace KISDatabase
{
    partial class ClientSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGivenName = new System.Windows.Forms.Label();
            this.txtGivenName = new System.Windows.Forms.TextBox();
            this.txtFamilyName = new System.Windows.Forms.TextBox();
            this.lblFamilyName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.MaskedTextBox();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnSearchID = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuReporting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditServices = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.btnNationality = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGivenName
            // 
            this.lblGivenName.AutoSize = true;
            this.lblGivenName.Location = new System.Drawing.Point(12, 67);
            this.lblGivenName.Name = "lblGivenName";
            this.lblGivenName.Size = new System.Drawing.Size(110, 19);
            this.lblGivenName.TabIndex = 0;
            this.lblGivenName.Text = "Given Name:";
            // 
            // txtGivenName
            // 
            this.txtGivenName.Location = new System.Drawing.Point(128, 64);
            this.txtGivenName.Name = "txtGivenName";
            this.txtGivenName.Size = new System.Drawing.Size(286, 30);
            this.txtGivenName.TabIndex = 2;
            this.txtGivenName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGivenName_KeyPress);
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.Location = new System.Drawing.Point(128, 33);
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(286, 30);
            this.txtFamilyName.TabIndex = 1;
            this.txtFamilyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamilyName_KeyPress);
            // 
            // lblFamilyName
            // 
            this.lblFamilyName.AutoSize = true;
            this.lblFamilyName.Location = new System.Drawing.Point(12, 36);
            this.lblFamilyName.Name = "lblFamilyName";
            this.lblFamilyName.Size = new System.Drawing.Size(84, 19);
            this.lblFamilyName.TabIndex = 2;
            this.lblFamilyName.Text = "Surname:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(11, 110);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(214, 19);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "ID or Certificate Number:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(231, 107);
            this.txtID.Mask = "aaaaaaaaaaaaaaaaaaaa";
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(183, 30);
            this.txtID.TabIndex = 4;
            this.txtID.Enter += new System.EventHandler(this.txtID_Enter);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 18;
            this.lstClients.Location = new System.Drawing.Point(15, 237);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(635, 184);
            this.lstClients.TabIndex = 10;
            this.lstClients.DoubleClick += new System.EventHandler(this.lstClients_DoubleClick);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Location = new System.Drawing.Point(427, 64);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(153, 31);
            this.btnSearchName.TabIndex = 3;
            this.btnSearchName.Text = "Search by Name";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnSearchID
            // 
            this.btnSearchID.Location = new System.Drawing.Point(427, 107);
            this.btnSearchID.Name = "btnSearchID";
            this.btnSearchID.Size = new System.Drawing.Size(153, 31);
            this.btnSearchID.TabIndex = 5;
            this.btnSearchID.Text = "Search by ID";
            this.btnSearchID.UseVisualStyleBackColor = true;
            this.btnSearchID.Click += new System.EventHandler(this.btnSearchID_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(590, 33);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 31);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReporting,
            this.mnuEditServices});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 31);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuReporting
            // 
            this.mnuReporting.Name = "mnuReporting";
            this.mnuReporting.Size = new System.Drawing.Size(98, 27);
            this.mnuReporting.Text = "Reporting";
            this.mnuReporting.Click += new System.EventHandler(this.mnuReporting_Click);
            // 
            // mnuEditServices
            // 
            this.mnuEditServices.Name = "mnuEditServices";
            this.mnuEditServices.Size = new System.Drawing.Size(118, 27);
            this.mnuEditServices.Text = "Edit Services";
            this.mnuEditServices.Click += new System.EventHandler(this.mnuEditServices_Click);
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(12, 153);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(147, 19);
            this.lblNationality.TabIndex = 11;
            this.lblNationality.Text = "Country of Birth:";
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(165, 150);
            this.txtNationality.MaxLength = 30;
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(286, 30);
            this.txtNationality.TabIndex = 6;
            this.txtNationality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNationality_KeyPress);
            // 
            // btnNationality
            // 
            this.btnNationality.Location = new System.Drawing.Point(464, 150);
            this.btnNationality.Name = "btnNationality";
            this.btnNationality.Size = new System.Drawing.Size(183, 30);
            this.btnNationality.TabIndex = 7;
            this.btnNationality.Text = "Search by Country";
            this.btnNationality.UseVisualStyleBackColor = true;
            this.btnNationality.Click += new System.EventHandler(this.btnNationality_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 198);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(89, 19);
            this.lblLanguage.TabIndex = 14;
            this.lblLanguage.Text = "Language:";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(165, 195);
            this.txtLanguage.MaxLength = 20;
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(286, 30);
            this.txtLanguage.TabIndex = 8;
            this.txtLanguage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLanguage_KeyPress);
            // 
            // btnLanguage
            // 
            this.btnLanguage.Location = new System.Drawing.Point(464, 195);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(183, 29);
            this.btnLanguage.TabIndex = 9;
            this.btnLanguage.Text = "Search by Language";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // ClientSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(737, 437);
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.btnNationality);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearchID);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtFamilyName);
            this.Controls.Add(this.lblFamilyName);
            this.Controls.Add(this.txtGivenName);
            this.Controls.Add(this.lblGivenName);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientSearch";
            this.Text = "Client Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientSearch_FormClosed);
            this.SizeChanged += new System.EventHandler(this.ClientSearch_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGivenName;
        private System.Windows.Forms.TextBox txtGivenName;
        private System.Windows.Forms.TextBox txtFamilyName;
        private System.Windows.Forms.Label lblFamilyName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.MaskedTextBox txtID;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Button btnSearchID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuReporting;
        private System.Windows.Forms.ToolStripMenuItem mnuEditServices;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Button btnNationality;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Button btnLanguage;
    }
}