namespace WhoIsDemo.form
{
    partial class frmConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            this.tcConfiguration = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnTestChannel = new System.Windows.Forms.Button();
            this.txtDescriptionChannel = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbTypeChannelDevice = new System.Windows.Forms.RadioButton();
            this.rbTypeChannelFile = new System.Windows.Forms.RadioButton();
            this.rbTypeChannelIP = new System.Windows.Forms.RadioButton();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveConfiguration = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboRegisterUser = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBestMatched = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtASimilarity = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboDetectForced = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboIdentificationSpeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboTrackMotion = new System.Windows.Forms.ComboBox();
            this.cboTrackSpeed = new System.Windows.Forms.ComboBox();
            this.cboTrackingMode = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTrackingOk = new System.Windows.Forms.Label();
            this.chkDeepTrack = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMinEyeTrack = new System.Windows.Forms.TextBox();
            this.txtRefreshTrack = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtConfidenceTrack = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaxEyeTrack = new System.Windows.Forms.TextBox();
            this.lblOkDetect = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtModelQuality = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboExtractionMode = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboDetectorMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccurancy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMinEye = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaxEye = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxDetect = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOkClearDatabase = new System.Windows.Forms.Label();
            this.btnClearDatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcConfiguration.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcConfiguration
            // 
            this.tcConfiguration.Controls.Add(this.tabPage1);
            this.tcConfiguration.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tcConfiguration, "tcConfiguration");
            this.tcConfiguration.Name = "tcConfiguration";
            this.tcConfiguration.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.btnSaveConfiguration);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.lblOkDetect);
            this.tabPage1.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnTestChannel);
            this.groupBox7.Controls.Add(this.txtDescriptionChannel);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.cboChannel);
            this.groupBox7.Controls.Add(this.label16);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // btnTestChannel
            // 
            this.btnTestChannel.FlatAppearance.BorderSize = 0;
            this.btnTestChannel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnTestChannel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnTestChannel, "btnTestChannel");
            this.btnTestChannel.Image = global::WhoIsDemo.Properties.Resources.test_tube;
            this.btnTestChannel.Name = "btnTestChannel";
            this.btnTestChannel.UseVisualStyleBackColor = true;
            this.btnTestChannel.Click += new System.EventHandler(this.btnTestChannel_Click);
            // 
            // txtDescriptionChannel
            // 
            resources.ApplyResources(this.txtDescriptionChannel, "txtDescriptionChannel");
            this.txtDescriptionChannel.Name = "txtDescriptionChannel";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbTypeChannelDevice);
            this.groupBox8.Controls.Add(this.rbTypeChannelFile);
            this.groupBox8.Controls.Add(this.rbTypeChannelIP);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // rbTypeChannelDevice
            // 
            resources.ApplyResources(this.rbTypeChannelDevice, "rbTypeChannelDevice");
            this.rbTypeChannelDevice.Name = "rbTypeChannelDevice";
            this.rbTypeChannelDevice.TabStop = true;
            this.rbTypeChannelDevice.UseVisualStyleBackColor = true;
            // 
            // rbTypeChannelFile
            // 
            resources.ApplyResources(this.rbTypeChannelFile, "rbTypeChannelFile");
            this.rbTypeChannelFile.Name = "rbTypeChannelFile";
            this.rbTypeChannelFile.TabStop = true;
            this.rbTypeChannelFile.UseVisualStyleBackColor = true;
            // 
            // rbTypeChannelIP
            // 
            resources.ApplyResources(this.rbTypeChannelIP, "rbTypeChannelIP");
            this.rbTypeChannelIP.Name = "rbTypeChannelIP";
            this.rbTypeChannelIP.TabStop = true;
            this.rbTypeChannelIP.UseVisualStyleBackColor = true;
            // 
            // cboChannel
            // 
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Items.AddRange(new object[] {
            resources.GetString("cboChannel.Items"),
            resources.GetString("cboChannel.Items1"),
            resources.GetString("cboChannel.Items2"),
            resources.GetString("cboChannel.Items3")});
            resources.ApplyResources(this.cboChannel, "cboChannel");
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.SelectedIndexChanged += new System.EventHandler(this.cboChannel_SelectedIndexChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveConfiguration.BackgroundImage = global::WhoIsDemo.Properties.Resources.ic_save_black_48dp;
            resources.ApplyResources(this.btnSaveConfiguration, "btnSaveConfiguration");
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.UseVisualStyleBackColor = false;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboRegisterUser);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtBestMatched);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtASimilarity);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.cboDetectForced);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.cboIdentificationSpeed);
            this.groupBox6.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // cboRegisterUser
            // 
            this.cboRegisterUser.FormattingEnabled = true;
            this.cboRegisterUser.Items.AddRange(new object[] {
            resources.GetString("cboRegisterUser.Items"),
            resources.GetString("cboRegisterUser.Items1")});
            resources.ApplyResources(this.cboRegisterUser, "cboRegisterUser");
            this.cboRegisterUser.Name = "cboRegisterUser";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtBestMatched
            // 
            resources.ApplyResources(this.txtBestMatched, "txtBestMatched");
            this.txtBestMatched.Name = "txtBestMatched";
            this.txtBestMatched.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBestMatched_KeyPress);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // txtASimilarity
            // 
            resources.ApplyResources(this.txtASimilarity, "txtASimilarity");
            this.txtASimilarity.Name = "txtASimilarity";
            this.txtASimilarity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtASimilarity_KeyPress);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // cboDetectForced
            // 
            this.cboDetectForced.FormattingEnabled = true;
            this.cboDetectForced.Items.AddRange(new object[] {
            resources.GetString("cboDetectForced.Items"),
            resources.GetString("cboDetectForced.Items1"),
            resources.GetString("cboDetectForced.Items2"),
            resources.GetString("cboDetectForced.Items3"),
            resources.GetString("cboDetectForced.Items4"),
            resources.GetString("cboDetectForced.Items5"),
            resources.GetString("cboDetectForced.Items6"),
            resources.GetString("cboDetectForced.Items7"),
            resources.GetString("cboDetectForced.Items8"),
            resources.GetString("cboDetectForced.Items9"),
            resources.GetString("cboDetectForced.Items10"),
            resources.GetString("cboDetectForced.Items11"),
            resources.GetString("cboDetectForced.Items12"),
            resources.GetString("cboDetectForced.Items13"),
            resources.GetString("cboDetectForced.Items14"),
            resources.GetString("cboDetectForced.Items15"),
            resources.GetString("cboDetectForced.Items16"),
            resources.GetString("cboDetectForced.Items17"),
            resources.GetString("cboDetectForced.Items18"),
            resources.GetString("cboDetectForced.Items19")});
            resources.ApplyResources(this.cboDetectForced, "cboDetectForced");
            this.cboDetectForced.Name = "cboDetectForced";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboIdentificationSpeed
            // 
            this.cboIdentificationSpeed.FormattingEnabled = true;
            this.cboIdentificationSpeed.Items.AddRange(new object[] {
            resources.GetString("cboIdentificationSpeed.Items"),
            resources.GetString("cboIdentificationSpeed.Items1"),
            resources.GetString("cboIdentificationSpeed.Items2"),
            resources.GetString("cboIdentificationSpeed.Items3"),
            resources.GetString("cboIdentificationSpeed.Items4"),
            resources.GetString("cboIdentificationSpeed.Items5"),
            resources.GetString("cboIdentificationSpeed.Items6"),
            resources.GetString("cboIdentificationSpeed.Items7"),
            resources.GetString("cboIdentificationSpeed.Items8"),
            resources.GetString("cboIdentificationSpeed.Items9"),
            resources.GetString("cboIdentificationSpeed.Items10")});
            resources.ApplyResources(this.cboIdentificationSpeed, "cboIdentificationSpeed");
            this.cboIdentificationSpeed.Name = "cboIdentificationSpeed";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboTrackMotion);
            this.groupBox5.Controls.Add(this.cboTrackSpeed);
            this.groupBox5.Controls.Add(this.cboTrackingMode);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.lblTrackingOk);
            this.groupBox5.Controls.Add(this.chkDeepTrack);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txtMinEyeTrack);
            this.groupBox5.Controls.Add(this.txtRefreshTrack);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtConfidenceTrack);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txtMaxEyeTrack);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // cboTrackMotion
            // 
            this.cboTrackMotion.FormattingEnabled = true;
            this.cboTrackMotion.Items.AddRange(new object[] {
            resources.GetString("cboTrackMotion.Items"),
            resources.GetString("cboTrackMotion.Items1"),
            resources.GetString("cboTrackMotion.Items2"),
            resources.GetString("cboTrackMotion.Items3")});
            resources.ApplyResources(this.cboTrackMotion, "cboTrackMotion");
            this.cboTrackMotion.Name = "cboTrackMotion";
            // 
            // cboTrackSpeed
            // 
            this.cboTrackSpeed.FormattingEnabled = true;
            this.cboTrackSpeed.Items.AddRange(new object[] {
            resources.GetString("cboTrackSpeed.Items"),
            resources.GetString("cboTrackSpeed.Items1"),
            resources.GetString("cboTrackSpeed.Items2")});
            resources.ApplyResources(this.cboTrackSpeed, "cboTrackSpeed");
            this.cboTrackSpeed.Name = "cboTrackSpeed";
            // 
            // cboTrackingMode
            // 
            this.cboTrackingMode.FormattingEnabled = true;
            this.cboTrackingMode.Items.AddRange(new object[] {
            resources.GetString("cboTrackingMode.Items"),
            resources.GetString("cboTrackingMode.Items1"),
            resources.GetString("cboTrackingMode.Items2")});
            resources.ApplyResources(this.cboTrackingMode, "cboTrackingMode");
            this.cboTrackingMode.Name = "cboTrackingMode";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // lblTrackingOk
            // 
            resources.ApplyResources(this.lblTrackingOk, "lblTrackingOk");
            this.lblTrackingOk.ForeColor = System.Drawing.Color.Red;
            this.lblTrackingOk.Name = "lblTrackingOk";
            // 
            // chkDeepTrack
            // 
            resources.ApplyResources(this.chkDeepTrack, "chkDeepTrack");
            this.chkDeepTrack.Name = "chkDeepTrack";
            this.chkDeepTrack.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txtMinEyeTrack
            // 
            resources.ApplyResources(this.txtMinEyeTrack, "txtMinEyeTrack");
            this.txtMinEyeTrack.Name = "txtMinEyeTrack";
            this.txtMinEyeTrack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinEyeTrack_KeyPress);
            // 
            // txtRefreshTrack
            // 
            resources.ApplyResources(this.txtRefreshTrack, "txtRefreshTrack");
            this.txtRefreshTrack.Name = "txtRefreshTrack";
            this.txtRefreshTrack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefreshTrack_KeyPress);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txtConfidenceTrack
            // 
            resources.ApplyResources(this.txtConfidenceTrack, "txtConfidenceTrack");
            this.txtConfidenceTrack.Name = "txtConfidenceTrack";
            this.txtConfidenceTrack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfidenceTrack_KeyPress);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtMaxEyeTrack
            // 
            resources.ApplyResources(this.txtMaxEyeTrack, "txtMaxEyeTrack");
            this.txtMaxEyeTrack.Name = "txtMaxEyeTrack";
            this.txtMaxEyeTrack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxEyeTrack_KeyPress);
            // 
            // lblOkDetect
            // 
            resources.ApplyResources(this.lblOkDetect, "lblOkDetect");
            this.lblOkDetect.ForeColor = System.Drawing.Color.Red;
            this.lblOkDetect.Name = "lblOkDetect";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtModelQuality);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboExtractionMode);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.cboDetectorMode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtAccurancy);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtMinEye);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMaxEye);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMaxDetect);
            this.groupBox3.Controls.Add(this.label7);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txtModelQuality
            // 
            resources.ApplyResources(this.txtModelQuality, "txtModelQuality");
            this.txtModelQuality.Name = "txtModelQuality";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cboExtractionMode
            // 
            this.cboExtractionMode.FormattingEnabled = true;
            this.cboExtractionMode.Items.AddRange(new object[] {
            resources.GetString("cboExtractionMode.Items"),
            resources.GetString("cboExtractionMode.Items1")});
            resources.ApplyResources(this.cboExtractionMode, "cboExtractionMode");
            this.cboExtractionMode.Name = "cboExtractionMode";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // cboDetectorMode
            // 
            this.cboDetectorMode.FormattingEnabled = true;
            this.cboDetectorMode.Items.AddRange(new object[] {
            resources.GetString("cboDetectorMode.Items"),
            resources.GetString("cboDetectorMode.Items1")});
            resources.ApplyResources(this.cboDetectorMode, "cboDetectorMode");
            this.cboDetectorMode.Name = "cboDetectorMode";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtAccurancy
            // 
            resources.ApplyResources(this.txtAccurancy, "txtAccurancy");
            this.txtAccurancy.Name = "txtAccurancy";
            this.txtAccurancy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccurancy_KeyPress);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtMinEye
            // 
            resources.ApplyResources(this.txtMinEye, "txtMinEye");
            this.txtMinEye.Name = "txtMinEye";
            this.txtMinEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinEye_KeyPress);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtMaxEye
            // 
            resources.ApplyResources(this.txtMaxEye, "txtMaxEye");
            this.txtMaxEye.Name = "txtMaxEye";
            this.txtMaxEye.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxEye_KeyPress);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtMaxDetect
            // 
            resources.ApplyResources(this.txtMaxDetect, "txtMaxDetect");
            this.txtMaxDetect.Name = "txtMaxDetect";
            this.txtMaxDetect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxDetect_KeyPress);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOkClearDatabase);
            this.groupBox2.Controls.Add(this.btnClearDatabase);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lblOkClearDatabase
            // 
            resources.ApplyResources(this.lblOkClearDatabase, "lblOkClearDatabase");
            this.lblOkClearDatabase.ForeColor = System.Drawing.Color.Red;
            this.lblOkClearDatabase.Name = "lblOkClearDatabase";
            // 
            // btnClearDatabase
            // 
            this.btnClearDatabase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearDatabase.BackgroundImage = global::WhoIsDemo.Properties.Resources.cached;
            resources.ApplyResources(this.btnClearDatabase, "btnClearDatabase");
            this.btnClearDatabase.Name = "btnClearDatabase";
            this.btnClearDatabase.UseVisualStyleBackColor = false;
            this.btnClearDatabase.Click += new System.EventHandler(this.btnClearDatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveDatabase);
            this.groupBox1.Controls.Add(this.txtConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameDatabase);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveDatabase.BackgroundImage = global::WhoIsDemo.Properties.Resources.lock_reset;
            resources.ApplyResources(this.btnSaveDatabase, "btnSaveDatabase");
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.UseVisualStyleBackColor = false;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);
            // 
            // txtConnect
            // 
            resources.ApplyResources(this.txtConnect, "txtConnect");
            this.txtConnect.Name = "txtConnect";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtNameDatabase
            // 
            resources.ApplyResources(this.txtNameDatabase, "txtNameDatabase");
            this.txtNameDatabase.Name = "txtNameDatabase";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.BackgroundImage = global::WhoIsDemo.Properties.Resources.ic_clear_black_48dp;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConfiguration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguration_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.Shown += new System.EventHandler(this.frmConfiguration_Shown);
            this.tcConfiguration.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfiguration;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveDatabase;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearDatabase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAccurancy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMinEye;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaxEye;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxDetect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOkDetect;
        private System.Windows.Forms.Label lblOkClearDatabase;
        private System.Windows.Forms.ComboBox cboDetectorMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMaxEyeTrack;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMinEyeTrack;
        private System.Windows.Forms.TextBox txtRefreshTrack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtConfidenceTrack;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDeepTrack;
        private System.Windows.Forms.Label lblTrackingOk;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboDetectForced;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboIdentificationSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBestMatched;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtASimilarity;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSaveConfiguration;
        private System.Windows.Forms.ComboBox cboTrackMotion;
        private System.Windows.Forms.ComboBox cboTrackSpeed;
        private System.Windows.Forms.ComboBox cboTrackingMode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboExtractionMode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtDescriptionChannel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rbTypeChannelDevice;
        private System.Windows.Forms.RadioButton rbTypeChannelFile;
        private System.Windows.Forms.RadioButton rbTypeChannelIP;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtModelQuality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRegisterUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnTestChannel;
    }
}