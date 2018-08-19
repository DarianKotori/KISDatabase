namespace KISDatabase
{
    partial class ClientRecord
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
            this.txtGivenName = new System.Windows.Forms.TextBox();
            this.lblGivenName = new System.Windows.Forms.Label();
            this.lblFamilyName = new System.Windows.Forms.Label();
            this.txtFamilyName = new System.Windows.Forms.TextBox();
            this.txtIDNum = new System.Windows.Forms.MaskedTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblPostal = new System.Windows.Forms.Label();
            this.txtPostal = new System.Windows.Forms.MaskedTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.lstComments = new System.Windows.Forms.ListBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.lblContract = new System.Windows.Forms.Label();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVP = new System.Windows.Forms.Label();
            this.chkVP = new System.Windows.Forms.CheckBox();
            this.erpAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpPostal = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnVisitAdd = new System.Windows.Forms.Button();
            this.lblVisit = new System.Windows.Forms.Label();
            this.lstVisits = new System.Windows.Forms.ListBox();
            this.lblClientID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCitizenCert = new System.Windows.Forms.MaskedTextBox();
            this.txtPhone2 = new System.Windows.Forms.MaskedTextBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.erpContract = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpStatus = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPostal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGivenName
            // 
            this.txtGivenName.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtGivenName.Location = new System.Drawing.Point(166, 43);
            this.txtGivenName.MaxLength = 100;
            this.txtGivenName.Name = "txtGivenName";
            this.txtGivenName.Size = new System.Drawing.Size(273, 36);
            this.txtGivenName.TabIndex = 1;
            // 
            // lblGivenName
            // 
            this.lblGivenName.AutoSize = true;
            this.lblGivenName.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGivenName.Location = new System.Drawing.Point(12, 51);
            this.lblGivenName.Name = "lblGivenName";
            this.lblGivenName.Size = new System.Drawing.Size(131, 19);
            this.lblGivenName.TabIndex = 1;
            this.lblGivenName.Text = "Given Name(s):";
            // 
            // lblFamilyName
            // 
            this.lblFamilyName.AutoSize = true;
            this.lblFamilyName.Location = new System.Drawing.Point(12, 15);
            this.lblFamilyName.Name = "lblFamilyName";
            this.lblFamilyName.Size = new System.Drawing.Size(84, 19);
            this.lblFamilyName.TabIndex = 2;
            this.lblFamilyName.Text = "Surname:";
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFamilyName.Location = new System.Drawing.Point(166, 7);
            this.txtFamilyName.MaxLength = 100;
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(273, 36);
            this.txtFamilyName.TabIndex = 0;
            // 
            // txtIDNum
            // 
            this.txtIDNum.Location = new System.Drawing.Point(98, 92);
            this.txtIDNum.Mask = "aaaaaaaaaaaaaaaaaaaa";
            this.txtIDNum.Name = "txtIDNum";
            this.txtIDNum.Size = new System.Drawing.Size(162, 30);
            this.txtIDNum.TabIndex = 3;
            this.txtIDNum.ValidatingType = typeof(int);
            this.txtIDNum.Enter += new System.EventHandler(this.txtIDNum_Enter);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 168);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "",
            "PR",
            "Approval in principle",
            "NC",
            "PNP",
            "TFW",
            "Student",
            "Refugee Claimant",
            "Visitor",
            "Born Canadian",
            "1st Generation"});
            this.cmbStatus.Location = new System.Drawing.Point(98, 165);
            this.cmbStatus.MaxDropDownItems = 11;
            this.cmbStatus.MaxLength = 30;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(188, 26);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cmbStatus_Validating);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 205);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(78, 19);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsReturn = true;
            this.txtAddress.Location = new System.Drawing.Point(98, 202);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(317, 48);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(12, 267);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(46, 19);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.AutoCompleteCustomSource.AddRange(new string[] {
            "100 Mile House",
            "108 Mile House",
            "108 Mile Ranch",
            "150 Mile House",
            "Abbotsford",
            "Agassiz",
            "Ahousat",
            "Aldergrove",
            "Alert Bay",
            "Alexis Creek",
            "Alkali Lake",
            "Armstrong",
            "Ashcroft",
            "Atlin",
            "Avola",
            "Balfour",
            "Bamfield",
            "Barriere",
            "Beach Grove",
            "Bear Lake",
            "Beaver Cove",
            "Beaverdell",
            "Bella Bella",
            "Bella Coola",
            "Black Creek",
            "Black Point",
            "Blue River",
            "Bob Quinn Lake",
            "Boston Bar",
            "Boswell",
            "Bowen Island",
            "Bowser",
            "Bridge Lake",
            "Britannia Beach",
            "Burnaby",
            "Burns Lake",
            "Cache Creek",
            "Campbell River",
            "Canal Flats",
            "Cassiar",
            "Castlegar",
            "Celista",
            "Chase",
            "Chemainus",
            "Chetwynd",
            "Chilliwack",
            "Christina Lake",
            "Clearwater",
            "Clinton",
            "Cobble Hill",
            "Colwood",
            "Comox",
            "Coquitlam",
            "Courtenay",
            "Cowichan Bay",
            "Cranbrook",
            "Crawford Bay",
            "Crescent Beach",
            "Creston",
            "Cumberland",
            "Dawson Creek",
            "Dease Lake",
            "Delta",
            "Donald",
            "Douglas Lake",
            "Duncan",
            "Dunster",
            "D`Arcy",
            "East Pine",
            "Elkford",
            "Elko",
            "Enderby",
            "Estevan Point",
            "Fairmont Hot Springs",
            "Falkland",
            "Fauquier",
            "Fernie",
            "Field",
            "Flatrock",
            "Forest Grove",
            "Fort Fraser",
            "Fort Nelson",
            "Fort St. James",
            "Fort St. John",
            "Fraser Lake",
            "Fruitvale",
            "Gabriola",
            "Galiano Island",
            "Ganges",
            "Gibsons",
            "Giscome",
            "Gold Bridge",
            "Gold River",
            "Golden",
            "Good Hope Lake",
            "Grand Forks",
            "Granisle",
            "Grasmere",
            "Grassy Plains",
            "Greenville",
            "Greenwood",
            "Hartley Bay",
            "Hazelton",
            "Hedley",
            "Hemlock Valley",
            "Hendrix Lake",
            "Hixon",
            "Holberg",
            "Hope",
            "Horsefly",
            "Houston",
            "Hudson`s Hope",
            "Invermere",
            "Iskut",
            "Jaffray",
            "Kamloops",
            "Kaslo",
            "Kelowna",
            "Kemano",
            "Keremeos",
            "Kimberley",
            "Kincolith",
            "Kitimat",
            "Kitkatla",
            "Kitsault",
            "Kitwanga",
            "Klemtu",
            "Kyuquot",
            "Lac la Hache",
            "Ladysmith",
            "Lake Cowichan",
            "Langara",
            "Langley",
            "Lantzville",
            "Likely",
            "Lillooet",
            "Little Fort",
            "Logan Lake",
            "Loos",
            "Lower Post",
            "Lumby",
            "Lytton",
            "Mackenzie",
            "Maple Ridge",
            "Masset",
            "McBride",
            "McLeese Lake",
            "McLeod Lake",
            "Merritt",
            "Mica Creek",
            "Midway",
            "Mission",
            "Montney",
            "Moyie",
            "Muncho Lake",
            "Nakusp",
            "Nanaimo",
            "Naramata",
            "Nelson",
            "New Aiyansh",
            "New Denver",
            "New Westminster",
            "Nimpo Lake",
            "North Saanich",
            "North Vancouver",
            "Ocean Falls",
            "Ocean Park",
            "Okanagan Falls",
            "Oliver",
            "Osoyoos",
            "Oyama",
            "Parksville",
            "Parson",
            "Peachland",
            "Pemberton",
            "Penticton",
            "Pitt Meadows",
            "Port Alberni",
            "Port Alice",
            "Port Clements",
            "Port Coquitlam",
            "Port Edward",
            "Port Hardy",
            "Port McNeill",
            "Port Mellon",
            "Port Moody",
            "Port Renfrew",
            "Pouce Coupe",
            "Powell River",
            "Prespatou",
            "Prince George",
            "Prince Rupert",
            "Princeton",
            "Prophet River",
            "Quadra Island",
            "Qualicum Beach",
            "Queen Charlotte",
            "Quesnel",
            "Radium Hot Springs",
            "Red Rock",
            "Revelstoke",
            "Richmond",
            "Riondel",
            "Riske Creek",
            "Rock Creek",
            "Rolla",
            "Rossland",
            "Saanich",
            "Salmo",
            "Salmon Arm",
            "Salmon Valley",
            "Sandspit",
            "Savona",
            "Sayward",
            "Sechelt",
            "Shalalth",
            "Sicamous",
            "Sidney",
            "Skookumchuck",
            "Slocan",
            "Smithers",
            "Sointula",
            "Sooke",
            "Sorrento",
            "South Slocan",
            "Sparwood",
            "Spences Bridge",
            "Spillimacheen",
            "Squamish",
            "Stewart",
            "Summerland",
            "Summit Lake",
            "Surrey",
            "Tachie",
            "Tahsis",
            "Tatla Lake",
            "Taylor",
            "Telegraph Creek",
            "Telkwa",
            "Terrace",
            "Thrums",
            "Toad River",
            "Tofino",
            "Topley",
            "Trail",
            "Trout Lake",
            "Tsay Keh Dene",
            "Tumbler Ridge",
            "Ucluelet",
            "Valemount",
            "Vallican",
            "Van Anda",
            "Vancouver",
            "Vanderhoof",
            "Vavenby",
            "Vernon",
            "Victoria",
            "View Royal",
            "Wells",
            "West Vancouver",
            "Westbank",
            "Westwold",
            "Whistler",
            "White Rock",
            "Williams Lake",
            "Willowbrook",
            "Winfield",
            "Winter Harbour",
            "Wonowon",
            "Wynndel",
            "Yahk",
            "Yale",
            "Youbou",
            "Zeballos"});
            this.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCity.Location = new System.Drawing.Point(98, 264);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(188, 30);
            this.txtCity.TabIndex = 9;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtCity_Validating);
            // 
            // lblPostal
            // 
            this.lblPostal.AutoSize = true;
            this.lblPostal.Location = new System.Drawing.Point(12, 305);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(112, 19);
            this.lblPostal.TabIndex = 12;
            this.lblPostal.Text = "Postal Code:";
            // 
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(125, 302);
            this.txtPostal.Mask = "L0L0L0";
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(67, 30);
            this.txtPostal.TabIndex = 10;
            this.txtPostal.Enter += new System.EventHandler(this.txtPostal_Enter);
            this.txtPostal.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostal_Validating);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 343);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 19);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(89, 340);
            this.txtPhone.Mask = "000-000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(103, 30);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // lstComments
            // 
            this.lstComments.ColumnWidth = 40;
            this.lstComments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstComments.FormattingEnabled = true;
            this.lstComments.ItemHeight = 15;
            this.lstComments.Location = new System.Drawing.Point(573, 7);
            this.lstComments.Name = "lstComments";
            this.lstComments.Size = new System.Drawing.Size(422, 229);
            this.lstComments.TabIndex = 19;
            this.lstComments.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstComments_DrawItem);
            this.lstComments.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstComments_MeasureItem);
            this.lstComments.DoubleClick += new System.EventHandler(this.lstComments_DoubleClick);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(467, 13);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(100, 19);
            this.lblComments.TabIndex = 17;
            this.lblComments.Text = "Comments:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(123, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.CausesValidation = false;
            this.btnDetails.Location = new System.Drawing.Point(230, 461);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(99, 30);
            this.btnDetails.TabIndex = 16;
            this.btnDetails.Text = "Details...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(279, 95);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(86, 19);
            this.lblContract.TabIndex = 21;
            this.lblContract.Text = "Contract:";
            // 
            // cmbContract
            // 
            this.cmbContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContract.FormattingEnabled = true;
            this.cmbContract.Items.AddRange(new object[] {
            "Fed",
            "Prov",
            "Non"});
            this.cmbContract.Location = new System.Drawing.Point(371, 92);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Size = new System.Drawing.Size(64, 26);
            this.cmbContract.TabIndex = 4;
            this.cmbContract.Validating += new System.ComponentModel.CancelEventHandler(this.cmbContract_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 419);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(55, 19);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(89, 416);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(326, 30);
            this.txtEmail.TabIndex = 13;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // btnServices
            // 
            this.btnServices.CausesValidation = false;
            this.btnServices.Location = new System.Drawing.Point(348, 461);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(177, 30);
            this.btnServices.TabIndex = 17;
            this.btnServices.Text = "Service Summary...";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.CausesValidation = false;
            this.btnAdd.Location = new System.Drawing.Point(471, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblVP
            // 
            this.lblVP.AutoSize = true;
            this.lblVP.Location = new System.Drawing.Point(304, 168);
            this.lblVP.Name = "lblVP";
            this.lblVP.Size = new System.Drawing.Size(37, 19);
            this.lblVP.TabIndex = 27;
            this.lblVP.Text = "VP:";
            // 
            // chkVP
            // 
            this.chkVP.AutoSize = true;
            this.chkVP.Location = new System.Drawing.Point(347, 170);
            this.chkVP.Name = "chkVP";
            this.chkVP.Size = new System.Drawing.Size(18, 17);
            this.chkVP.TabIndex = 7;
            this.chkVP.UseVisualStyleBackColor = true;
            // 
            // erpAddress
            // 
            this.erpAddress.ContainerControl = this;
            // 
            // erpCity
            // 
            this.erpCity.ContainerControl = this;
            // 
            // erpPostal
            // 
            this.erpPostal.ContainerControl = this;
            // 
            // erpPhone
            // 
            this.erpPhone.ContainerControl = this;
            // 
            // erpEmail
            // 
            this.erpEmail.ContainerControl = this;
            // 
            // btnVisitAdd
            // 
            this.btnVisitAdd.CausesValidation = false;
            this.btnVisitAdd.Location = new System.Drawing.Point(471, 270);
            this.btnVisitAdd.Name = "btnVisitAdd";
            this.btnVisitAdd.Size = new System.Drawing.Size(75, 30);
            this.btnVisitAdd.TabIndex = 20;
            this.btnVisitAdd.Text = "Add...";
            this.btnVisitAdd.UseVisualStyleBackColor = true;
            this.btnVisitAdd.Click += new System.EventHandler(this.btnVisitAdd_Click);
            // 
            // lblVisit
            // 
            this.lblVisit.AutoSize = true;
            this.lblVisit.Location = new System.Drawing.Point(467, 248);
            this.lblVisit.Name = "lblVisit";
            this.lblVisit.Size = new System.Drawing.Size(58, 19);
            this.lblVisit.TabIndex = 29;
            this.lblVisit.Text = "Visits:";
            // 
            // lstVisits
            // 
            this.lstVisits.ColumnWidth = 40;
            this.lstVisits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstVisits.FormattingEnabled = true;
            this.lstVisits.ItemHeight = 15;
            this.lstVisits.Location = new System.Drawing.Point(573, 242);
            this.lstVisits.Name = "lstVisits";
            this.lstVisits.Size = new System.Drawing.Size(422, 229);
            this.lstVisits.TabIndex = 21;
            this.lstVisits.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstVisits_DrawItem);
            this.lstVisits.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstVisits_MeasureItem);
            this.lstVisits.DoubleClick += new System.EventHandler(this.lstVisits_DoubleClick);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Location = new System.Drawing.Point(12, 95);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(84, 19);
            this.lblClientID.TabIndex = 31;
            this.lblClientID.Text = "Client ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Citizenship Certificate:";
            // 
            // txtCitizenCert
            // 
            this.txtCitizenCert.Location = new System.Drawing.Point(213, 129);
            this.txtCitizenCert.Mask = "aaaaaaaaaaaaaaaaaaaa";
            this.txtCitizenCert.Name = "txtCitizenCert";
            this.txtCitizenCert.Size = new System.Drawing.Size(152, 30);
            this.txtCitizenCert.TabIndex = 5;
            this.txtCitizenCert.ValidatingType = typeof(int);
            this.txtCitizenCert.Enter += new System.EventHandler(this.txtCitizenCert_Enter);
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(174, 378);
            this.txtPhone2.Mask = "####################";
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(167, 30);
            this.txtPhone2.TabIndex = 12;
            this.txtPhone2.Enter += new System.EventHandler(this.txtPhone2_Enter);
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(12, 381);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(156, 19);
            this.lblPhone2.TabIndex = 35;
            this.lblPhone2.Text = "Secondary Phone:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(16, 498);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 30);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(230, 498);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(233, 30);
            this.btnUnlock.TabIndex = 36;
            this.btnUnlock.Text = "Unlock Record (override)";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnAttachments
            // 
            this.btnAttachments.Location = new System.Drawing.Point(573, 477);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(195, 30);
            this.btnAttachments.TabIndex = 37;
            this.btnAttachments.Text = "Attachments...";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // erpContract
            // 
            this.erpContract.ContainerControl = this;
            // 
            // erpStatus
            // 
            this.erpStatus.ContainerControl = this;
            // 
            // ClientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1026, 540);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.lblPhone2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCitizenCert);
            this.Controls.Add(this.lblClientID);
            this.Controls.Add(this.btnVisitAdd);
            this.Controls.Add(this.lblVisit);
            this.Controls.Add(this.lstVisits);
            this.Controls.Add(this.chkVP);
            this.Controls.Add(this.lblVP);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.cmbContract);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.lstComments);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtIDNum);
            this.Controls.Add(this.txtFamilyName);
            this.Controls.Add(this.lblFamilyName);
            this.Controls.Add(this.lblGivenName);
            this.Controls.Add(this.txtGivenName);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ClientRecord";
            this.Text = "Client Record";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientRecord_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.erpAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPostal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGivenName;
        private System.Windows.Forms.Label lblGivenName;
        private System.Windows.Forms.Label lblFamilyName;
        private System.Windows.Forms.TextBox txtFamilyName;
        private System.Windows.Forms.MaskedTextBox txtIDNum;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.MaskedTextBox txtPostal;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.ListBox lstComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblVP;
        private System.Windows.Forms.CheckBox chkVP;
        private System.Windows.Forms.ErrorProvider erpAddress;
        private System.Windows.Forms.ErrorProvider erpCity;
        private System.Windows.Forms.ErrorProvider erpPostal;
        private System.Windows.Forms.ErrorProvider erpPhone;
        private System.Windows.Forms.ErrorProvider erpEmail;
        private System.Windows.Forms.Button btnVisitAdd;
        private System.Windows.Forms.Label lblVisit;
        private System.Windows.Forms.ListBox lstVisits;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtCitizenCert;
        private System.Windows.Forms.MaskedTextBox txtPhone2;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.ErrorProvider erpContract;
        private System.Windows.Forms.ErrorProvider erpStatus;
    }
}

