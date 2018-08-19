namespace KISDatabase
{
    partial class Reporting
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
            this.components = new System.ComponentModel.Container();
            this.lblStaff = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblReport = new System.Windows.Forms.Label();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.mnuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.lblContract = new System.Windows.Forms.Label();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAllTime = new System.Windows.Forms.Label();
            this.chkAllTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.mnuEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(21, 31);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(122, 19);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "Staff Member:";
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(149, 28);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(240, 26);
            this.cmbStaff.TabIndex = 1;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(21, 72);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(68, 19);
            this.lblReport.TabIndex = 2;
            this.lblReport.Text = "Report:";
            // 
            // cmbReport
            // 
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Items.AddRange(new object[] {
            "Services Provided",
            "Services By Status",
            "Services By Status And Type",
            "First Languages",
            "Clients Served By Country of Birth",
            "Clients Served By Skill Level",
            "Clients Served By Age",
            "Clients Served By Years In Canada",
            "Client Mailing List",
            "Client Contact Information"});
            this.cmbReport.Location = new System.Drawing.Point(149, 69);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(240, 26);
            this.cmbReport.TabIndex = 2;
            this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.cmbReport_SelectedIndexChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(21, 162);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(98, 19);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy/MM/dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(149, 154);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(240, 30);
            this.dtpStart.TabIndex = 4;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy/MM/dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(149, 195);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(240, 30);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(21, 203);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(87, 19);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "End Date:";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToOrderColumns = true;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReport.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.ContextMenuStrip = this.mnuEdit;
            this.dgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReport.Location = new System.Drawing.Point(433, 28);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(816, 555);
            this.dgvReport.TabIndex = 9;
            // 
            // mnuEdit
            // 
            this.mnuEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuSelectAll});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(141, 52);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(140, 24);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(140, 24);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(21, 114);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(86, 19);
            this.lblContract.TabIndex = 9;
            this.lblContract.Text = "Contract:";
            // 
            // cmbContract
            // 
            this.cmbContract.FormattingEnabled = true;
            this.cmbContract.Items.AddRange(new object[] {
            "All Contracts",
            "Federal",
            "Provincial",
            "Non-Eligible"});
            this.cmbContract.Location = new System.Drawing.Point(149, 111);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Size = new System.Drawing.Size(240, 26);
            this.cmbContract.TabIndex = 3;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(21, 273);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 30);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(116, 273);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAllTime
            // 
            this.lblAllTime.AutoSize = true;
            this.lblAllTime.Location = new System.Drawing.Point(47, 236);
            this.lblAllTime.Name = "lblAllTime";
            this.lblAllTime.Size = new System.Drawing.Size(78, 19);
            this.lblAllTime.TabIndex = 13;
            this.lblAllTime.Text = "All Time:";
            // 
            // chkAllTime
            // 
            this.chkAllTime.AutoSize = true;
            this.chkAllTime.Location = new System.Drawing.Point(149, 238);
            this.chkAllTime.Name = "chkAllTime";
            this.chkAllTime.Size = new System.Drawing.Size(18, 17);
            this.chkAllTime.TabIndex = 6;
            this.chkAllTime.UseVisualStyleBackColor = true;
            this.chkAllTime.CheckedChanged += new System.EventHandler(this.chkAllTime_CheckedChanged);
            // 
            // Reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 595);
            this.Controls.Add(this.chkAllTime);
            this.Controls.Add(this.lblAllTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.cmbContract);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.cmbReport);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.lblStaff);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Reporting";
            this.Text = "Reporting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reporting_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Reporting_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.mnuEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAllTime;
        private System.Windows.Forms.CheckBox chkAllTime;
        private System.Windows.Forms.ContextMenuStrip mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
    }
}