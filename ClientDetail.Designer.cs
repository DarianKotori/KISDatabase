namespace KISDatabase
{
    partial class ClientDetail
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
            this.lblFedResearch = new System.Windows.Forms.Label();
            this.chkFedResearch = new System.Windows.Forms.CheckBox();
            this.chkProvResearch = new System.Windows.Forms.CheckBox();
            this.lblProvResearch = new System.Windows.Forms.Label();
            this.lblHomeLanguage = new System.Windows.Forms.Label();
            this.txtHomeLanguage = new System.Windows.Forms.TextBox();
            this.lblPrefLanguage = new System.Windows.Forms.Label();
            this.cmbPrefLanguage = new System.Windows.Forms.ComboBox();
            this.lblEducation = new System.Windows.Forms.Label();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.cmbOccupation = new System.Windows.Forms.ComboBox();
            this.lblArrival = new System.Windows.Forms.Label();
            this.txtArrival = new System.Windows.Forms.MaskedTextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblBirthCountry = new System.Windows.Forms.Label();
            this.txtBirthCountry = new System.Windows.Forms.TextBox();
            this.lblImmClass = new System.Windows.Forms.Label();
            this.cmbImmClass = new System.Windows.Forms.ComboBox();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.chkNotifications = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.erpArrival = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSkillLevel = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.erpDOB = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpArrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDOB)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFedResearch
            // 
            this.lblFedResearch.AutoSize = true;
            this.lblFedResearch.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblFedResearch.Location = new System.Drawing.Point(12, 9);
            this.lblFedResearch.Name = "lblFedResearch";
            this.lblFedResearch.Size = new System.Drawing.Size(304, 19);
            this.lblFedResearch.TabIndex = 0;
            this.lblFedResearch.Text = "Client consents to federal research:";
            // 
            // chkFedResearch
            // 
            this.chkFedResearch.AutoSize = true;
            this.chkFedResearch.Location = new System.Drawing.Point(357, 11);
            this.chkFedResearch.Name = "chkFedResearch";
            this.chkFedResearch.Size = new System.Drawing.Size(18, 17);
            this.chkFedResearch.TabIndex = 1;
            this.chkFedResearch.UseVisualStyleBackColor = true;
            // 
            // chkProvResearch
            // 
            this.chkProvResearch.AutoSize = true;
            this.chkProvResearch.Location = new System.Drawing.Point(357, 35);
            this.chkProvResearch.Name = "chkProvResearch";
            this.chkProvResearch.Size = new System.Drawing.Size(18, 17);
            this.chkProvResearch.TabIndex = 3;
            this.chkProvResearch.UseVisualStyleBackColor = true;
            // 
            // lblProvResearch
            // 
            this.lblProvResearch.AutoSize = true;
            this.lblProvResearch.Location = new System.Drawing.Point(12, 33);
            this.lblProvResearch.Name = "lblProvResearch";
            this.lblProvResearch.Size = new System.Drawing.Size(325, 19);
            this.lblProvResearch.TabIndex = 2;
            this.lblProvResearch.Text = "Client consents to provincial research:";
            // 
            // lblHomeLanguage
            // 
            this.lblHomeLanguage.AutoSize = true;
            this.lblHomeLanguage.Location = new System.Drawing.Point(12, 58);
            this.lblHomeLanguage.Name = "lblHomeLanguage";
            this.lblHomeLanguage.Size = new System.Drawing.Size(132, 19);
            this.lblHomeLanguage.TabIndex = 4;
            this.lblHomeLanguage.Text = "First Language:";
            // 
            // txtHomeLanguage
            // 
            this.txtHomeLanguage.AutoCompleteCustomSource.AddRange(new string[] {
            "Akan",
            "Amharic",
            "Arabic",
            "Assamese",
            "Awadhi",
            "Azerbaijani",
            "Balochi",
            "Belarusian",
            "Bengali",
            "Bhojpuri",
            "Burmese",
            "Cebuano",
            "Chewa",
            "Chhattisghari",
            "Chittagonian",
            "Czech",
            "Deccan",
            "Dhundhari",
            "Dutch",
            "Eastern Min",
            "English",
            "French",
            "Fula",
            "Gan Chinese",
            "German",
            "Greek",
            "Gujarati",
            "Haitian Creole",
            "Hakka",
            "Haryanvi",
            "Hausa",
            "Hiligaynon/Ilonggo",
            "Hindi",
            "Hmong",
            "Hungarian",
            "Igbo",
            "Ilocano",
            "Italian",
            "Japanese",
            "Javanese",
            "Jin",
            "Kannada",
            "Kazakh",
            "Khmer",
            "Kinyarwanda",
            "Kirundi",
            "Konkani",
            "Korean",
            "Kurdish",
            "Madurese",
            "Magahi",
            "Maithili",
            "Malagasy",
            "Malay",
            "Malayalam",
            "Mandarin",
            "Marathi",
            "Marwari",
            "Mossi",
            "Nepali",
            "Northern Min",
            "Odia",
            "Oromo",
            "Pashto",
            "Persian",
            "Polish",
            "Portuguese",
            "Punjabi",
            "Quechua",
            "Romanian",
            "Russian",
            "Saraiki",
            "Serbo-Croatian",
            "Shona",
            "Sindhi",
            "Sinhalese",
            "Somali",
            "Southern Min",
            "Spanish",
            "Sundanese",
            "Swedish",
            "Sylheti",
            "Tagalog",
            "Tamil",
            "Telugu",
            "Thai",
            "Turkish",
            "Turkmen",
            "Ukrainian",
            "Urdu",
            "Uyghur",
            "Uzbek",
            "Vietnamese",
            "Wu",
            "Xhosa",
            "Xiang",
            "Yoruba",
            "Yue (Cantonese)",
            "Zhuang",
            "Zulu"});
            this.txtHomeLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHomeLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHomeLanguage.Location = new System.Drawing.Point(357, 55);
            this.txtHomeLanguage.MaxLength = 20;
            this.txtHomeLanguage.Name = "txtHomeLanguage";
            this.txtHomeLanguage.Size = new System.Drawing.Size(121, 30);
            this.txtHomeLanguage.TabIndex = 5;
            // 
            // lblPrefLanguage
            // 
            this.lblPrefLanguage.AutoSize = true;
            this.lblPrefLanguage.Location = new System.Drawing.Point(12, 89);
            this.lblPrefLanguage.Name = "lblPrefLanguage";
            this.lblPrefLanguage.Size = new System.Drawing.Size(235, 19);
            this.lblPrefLanguage.TabIndex = 6;
            this.lblPrefLanguage.Text = "Preferred Official Language:";
            // 
            // cmbPrefLanguage
            // 
            this.cmbPrefLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrefLanguage.FormattingEnabled = true;
            this.cmbPrefLanguage.Items.AddRange(new object[] {
            "English",
            "French"});
            this.cmbPrefLanguage.Location = new System.Drawing.Point(357, 86);
            this.cmbPrefLanguage.Name = "cmbPrefLanguage";
            this.cmbPrefLanguage.Size = new System.Drawing.Size(121, 26);
            this.cmbPrefLanguage.TabIndex = 7;
            // 
            // lblEducation
            // 
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(12, 118);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(142, 19);
            this.lblEducation.TabIndex = 8;
            this.lblEducation.Text = "Education Level:";
            // 
            // cmbEducation
            // 
            this.cmbEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Items.AddRange(new object[] {
            "Unknown",
            "Not Complete",
            "High School",
            "Trade School",
            "Post Secondary",
            "Advanced Degree"});
            this.cmbEducation.Location = new System.Drawing.Point(357, 115);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(229, 26);
            this.cmbEducation.TabIndex = 9;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(12, 147);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(204, 19);
            this.lblOccupation.TabIndex = 10;
            this.lblOccupation.Text = "Occupation (Skill Level):";
            // 
            // cmbOccupation
            // 
            this.cmbOccupation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbOccupation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbOccupation.Location = new System.Drawing.Point(357, 144);
            this.cmbOccupation.Name = "cmbOccupation";
            this.cmbOccupation.Size = new System.Drawing.Size(321, 26);
            this.cmbOccupation.TabIndex = 11;
            this.cmbOccupation.TextChanged += new System.EventHandler(this.cmbOccupation_TextChanged);
            // 
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Location = new System.Drawing.Point(12, 176);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(199, 19);
            this.lblArrival.TabIndex = 12;
            this.lblArrival.Text = "Year Arrived in Canada:";
            // 
            // txtArrival
            // 
            this.txtArrival.Location = new System.Drawing.Point(357, 173);
            this.txtArrival.Mask = "0000";
            this.txtArrival.Name = "txtArrival";
            this.txtArrival.Size = new System.Drawing.Size(56, 30);
            this.txtArrival.TabIndex = 13;
            this.txtArrival.Enter += new System.EventHandler(this.txtArrival_Enter);
            this.txtArrival.Validating += new System.ComponentModel.CancelEventHandler(this.txtArrival_Validating);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(12, 238);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(72, 19);
            this.lblSex.TabIndex = 14;
            this.lblSex.Text = "Gender:";
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "",
            "X",
            "F",
            "M"});
            this.cmbSex.Location = new System.Drawing.Point(357, 235);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(38, 26);
            this.cmbSex.TabIndex = 15;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(12, 271);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(253, 19);
            this.lblDOB.TabIndex = 16;
            this.lblDOB.Text = "Date of Birth (YYYY/MM/DD):";
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "yyyy/MM/dd";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(357, 264);
            this.dtpDOB.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(121, 30);
            this.dtpDOB.TabIndex = 17;
            this.dtpDOB.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            this.dtpDOB.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDOB_Validating);
            // 
            // lblBirthCountry
            // 
            this.lblBirthCountry.AutoSize = true;
            this.lblBirthCountry.Location = new System.Drawing.Point(12, 298);
            this.lblBirthCountry.Name = "lblBirthCountry";
            this.lblBirthCountry.Size = new System.Drawing.Size(147, 19);
            this.lblBirthCountry.TabIndex = 18;
            this.lblBirthCountry.Text = "Country of Birth:";
            // 
            // txtBirthCountry
            // 
            this.txtBirthCountry.AutoCompleteCustomSource.AddRange(new string[] {
            "Afghanistan",
            "Åland Islands",
            "Albania",
            "Algeria",
            "American Samoa",
            "Andorra",
            "Angola",
            "Anguilla",
            "Antarctica",
            "Antigua & Barbuda",
            "Argentina",
            "Armenia",
            "Aruba",
            "Ascension Island",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia & Herzegovina",
            "Botswana",
            "Brazil",
            "British Indian Ocean Territory",
            "British Virgin Islands",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Canary Islands",
            "Cape Verde",
            "Caribbean Netherlands",
            "Cayman Islands",
            "Central African Republic",
            "Ceuta & Melilla",
            "Chad",
            "Chile",
            "China",
            "Christmas Island",
            "Cocos",
            "Colombia",
            "Comoros",
            "Congo - Brazzaville",
            "Congo - Kinshasa",
            "Cook Islands",
            "Costa Rica",
            "Côte d’Ivoire",
            "Croatia",
            "Cuba",
            "Curaçao",
            "Cyprus",
            "Czechia",
            "Denmark",
            "Diego Garcia",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Eurozone",
            "Falkland Islands",
            "Faroe Islands",
            "Fiji",
            "Finland",
            "France",
            "French Guiana",
            "French Polynesia",
            "French Southern Territories",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Gibraltar",
            "Greece",
            "Greenland",
            "Grenada",
            "Guadeloupe",
            "Guam",
            "Guatemala",
            "Guernsey",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hong Kong SAR China",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Isle of Man",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jersey",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macau SAR China",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Martinique",
            "Mauritania",
            "Mauritius",
            "Mayotte",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Montserrat",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Niue",
            "Norfolk Island",
            "North Korea",
            "Northern Mariana Islands",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestinian Territories",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Pitcairn Islands",
            "Poland",
            "Portugal",
            "Puerto Rico",
            "Qatar",
            "Réunion",
            "Romania",
            "Russia",
            "Rwanda",
            "Samoa",
            "San Marino",
            "São Tomé & Príncipe",
            "Saudi Arabia",
            "Scotland",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Sint Maarten",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Georgia & South Sandwich Islands",
            "South Korea",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "St. Barthélemy",
            "St. Helena",
            "St. Kitts & Nevis",
            "St. Lucia",
            "St. Martin",
            "St. Pierre & Miquelon",
            "St. Vincent & Grenadines",
            "Sudan",
            "Suriname",
            "Svalbard & Jan Mayen",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Timor-Leste",
            "Togo",
            "Tokelau",
            "Tonga",
            "Trinidad & Tobago",
            "Tristan da Cunha",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Turks & Caicos Islands",
            "Tuvalu",
            "U.S. Outlying Islands",
            "U.S. Virgin Islands",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United Nations",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City",
            "Venezuela",
            "Vietnam",
            "Wallis & Futuna",
            "Western Sahara",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.txtBirthCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBirthCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBirthCountry.Location = new System.Drawing.Point(357, 295);
            this.txtBirthCountry.MaxLength = 30;
            this.txtBirthCountry.Name = "txtBirthCountry";
            this.txtBirthCountry.Size = new System.Drawing.Size(195, 30);
            this.txtBirthCountry.TabIndex = 19;
            // 
            // lblImmClass
            // 
            this.lblImmClass.AutoSize = true;
            this.lblImmClass.Location = new System.Drawing.Point(12, 329);
            this.lblImmClass.Name = "lblImmClass";
            this.lblImmClass.Size = new System.Drawing.Size(156, 19);
            this.lblImmClass.TabIndex = 20;
            this.lblImmClass.Text = "Immigration Class:";
            // 
            // cmbImmClass
            // 
            this.cmbImmClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbImmClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbImmClass.FormattingEnabled = true;
            this.cmbImmClass.Items.AddRange(new object[] {
            "Business",
            "Experience (CEC)",
            "Family",
            "Skilled (Federal)",
            "Refugee-G",
            "Refugee-P",
            "Refugee-O",
            "H & C",
            "PNP",
            "Live-in",
            "XXX/XXX",
            "Others",
            "Unknown"});
            this.cmbImmClass.Location = new System.Drawing.Point(357, 326);
            this.cmbImmClass.Name = "cmbImmClass";
            this.cmbImmClass.Size = new System.Drawing.Size(195, 26);
            this.cmbImmClass.TabIndex = 21;
            // 
            // lblNotifications
            // 
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Location = new System.Drawing.Point(12, 356);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(234, 19);
            this.lblNotifications.TabIndex = 22;
            this.lblNotifications.Text = "Receive Email Notifications:";
            // 
            // chkNotifications
            // 
            this.chkNotifications.AutoSize = true;
            this.chkNotifications.Location = new System.Drawing.Point(357, 358);
            this.chkNotifications.Name = "chkNotifications";
            this.chkNotifications.Size = new System.Drawing.Size(18, 17);
            this.chkNotifications.TabIndex = 23;
            this.chkNotifications.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(90, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(190, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // erpArrival
            // 
            this.erpArrival.ContainerControl = this;
            // 
            // lblSkillLevel
            // 
            this.lblSkillLevel.AutoSize = true;
            this.lblSkillLevel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillLevel.Location = new System.Drawing.Point(684, 145);
            this.lblSkillLevel.Name = "lblSkillLevel";
            this.lblSkillLevel.Size = new System.Drawing.Size(42, 23);
            this.lblSkillLevel.TabIndex = 26;
            this.lblSkillLevel.Text = "N/A";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(12, 209);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(174, 19);
            this.lblProvince.TabIndex = 27;
            this.lblProvince.Text = "Province of Landing:";
            // 
            // cmbProvince
            // 
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Items.AddRange(new object[] {
            "",
            "AB",
            "BC",
            "MB",
            "NB",
            "NL",
            "NS",
            "NT",
            "NU",
            "ON",
            "PE",
            "QC",
            "SK",
            "YT"});
            this.cmbProvince.Location = new System.Drawing.Point(357, 206);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(56, 26);
            this.cmbProvince.TabIndex = 14;
            // 
            // erpDOB
            // 
            this.erpDOB.ContainerControl = this;
            // 
            // ClientDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(741, 436);
            this.Controls.Add(this.cmbProvince);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.lblSkillLevel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkNotifications);
            this.Controls.Add(this.lblNotifications);
            this.Controls.Add(this.cmbImmClass);
            this.Controls.Add(this.lblImmClass);
            this.Controls.Add(this.txtBirthCountry);
            this.Controls.Add(this.lblBirthCountry);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtArrival);
            this.Controls.Add(this.lblArrival);
            this.Controls.Add(this.cmbOccupation);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.cmbEducation);
            this.Controls.Add(this.lblEducation);
            this.Controls.Add(this.cmbPrefLanguage);
            this.Controls.Add(this.lblPrefLanguage);
            this.Controls.Add(this.txtHomeLanguage);
            this.Controls.Add(this.lblHomeLanguage);
            this.Controls.Add(this.chkProvResearch);
            this.Controls.Add(this.lblProvResearch);
            this.Controls.Add(this.chkFedResearch);
            this.Controls.Add(this.lblFedResearch);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientDetail";
            this.Text = "Client Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientDetail_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.erpArrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDOB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFedResearch;
        private System.Windows.Forms.CheckBox chkFedResearch;
        private System.Windows.Forms.CheckBox chkProvResearch;
        private System.Windows.Forms.Label lblProvResearch;
        private System.Windows.Forms.Label lblHomeLanguage;
        private System.Windows.Forms.TextBox txtHomeLanguage;
        private System.Windows.Forms.Label lblPrefLanguage;
        private System.Windows.Forms.ComboBox cmbPrefLanguage;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.ComboBox cmbEducation;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.ComboBox cmbOccupation;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.MaskedTextBox txtArrival;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblBirthCountry;
        private System.Windows.Forms.TextBox txtBirthCountry;
        private System.Windows.Forms.Label lblImmClass;
        private System.Windows.Forms.ComboBox cmbImmClass;
        private System.Windows.Forms.Label lblNotifications;
        private System.Windows.Forms.CheckBox chkNotifications;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider erpArrival;
        private System.Windows.Forms.Label lblSkillLevel;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.ErrorProvider erpDOB;
    }
}