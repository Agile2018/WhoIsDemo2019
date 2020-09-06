using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    partial class frmEnroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnroll));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.btnScoreEnroll = new System.Windows.Forms.Button();
            this.btnForcedEnroll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbVideo = new System.Windows.Forms.GroupBox();
            this.btnEnrollUserVideo = new System.Windows.Forms.Button();
            this.cboVideos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQuantityRecords = new System.Windows.Forms.Label();
            this.btnDownRecords = new System.Windows.Forms.Button();
            this.btnUploadRecords = new System.Windows.Forms.Button();
            this.btnStopLoadFile = new System.Windows.Forms.Button();
            this.flpDatabase = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.gbFile.SuspendLayout();
            this.gbVideo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbUser);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblQuantityRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnDownRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnUploadRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnStopLoadFile);
            this.splitContainer1.Panel2.Controls.Add(this.flpDatabase);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoadFile);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            // 
            // gbUser
            // 
            resources.ApplyResources(this.gbUser, "gbUser");
            this.gbUser.Controls.Add(this.gbFile);
            this.gbUser.Controls.Add(this.gbVideo);
            this.gbUser.ForeColor = System.Drawing.Color.DarkGray;
            this.gbUser.Name = "gbUser";
            this.gbUser.TabStop = false;
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.btnScoreEnroll);
            this.gbFile.Controls.Add(this.btnForcedEnroll);
            this.gbFile.Controls.Add(this.label3);
            this.gbFile.Controls.Add(this.label1);
            this.gbFile.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.gbFile, "gbFile");
            this.gbFile.Name = "gbFile";
            this.gbFile.TabStop = false;
            // 
            // btnScoreEnroll
            // 
            this.btnScoreEnroll.FlatAppearance.BorderSize = 0;
            this.btnScoreEnroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnScoreEnroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnScoreEnroll, "btnScoreEnroll");
            this.btnScoreEnroll.Image = global::WhoIsDemo.Properties.Resources.play;
            this.btnScoreEnroll.Name = "btnScoreEnroll";
            this.btnScoreEnroll.UseVisualStyleBackColor = true;
            this.btnScoreEnroll.Click += new System.EventHandler(this.btnScoreEnroll_Click);
            // 
            // btnForcedEnroll
            // 
            this.btnForcedEnroll.FlatAppearance.BorderSize = 0;
            this.btnForcedEnroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnForcedEnroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnForcedEnroll, "btnForcedEnroll");
            this.btnForcedEnroll.Image = global::WhoIsDemo.Properties.Resources.play;
            this.btnForcedEnroll.Name = "btnForcedEnroll";
            this.btnForcedEnroll.UseVisualStyleBackColor = true;
            this.btnForcedEnroll.Click += new System.EventHandler(this.btnForcedEnroll_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gbVideo
            // 
            this.gbVideo.Controls.Add(this.btnEnrollUserVideo);
            this.gbVideo.Controls.Add(this.cboVideos);
            this.gbVideo.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.gbVideo, "gbVideo");
            this.gbVideo.Name = "gbVideo";
            this.gbVideo.TabStop = false;
            // 
            // btnEnrollUserVideo
            // 
            this.btnEnrollUserVideo.FlatAppearance.BorderSize = 0;
            this.btnEnrollUserVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnEnrollUserVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnEnrollUserVideo, "btnEnrollUserVideo");
            this.btnEnrollUserVideo.Image = global::WhoIsDemo.Properties.Resources.play;
            this.btnEnrollUserVideo.Name = "btnEnrollUserVideo";
            this.btnEnrollUserVideo.Tag = "0";
            this.btnEnrollUserVideo.UseVisualStyleBackColor = true;
            this.btnEnrollUserVideo.Click += new System.EventHandler(this.btnEnrollUserVideo_Click);
            // 
            // cboVideos
            // 
            this.cboVideos.FormattingEnabled = true;
            resources.ApplyResources(this.cboVideos, "cboVideos");
            this.cboVideos.Name = "cboVideos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUser);
            this.groupBox1.Controls.Add(this.rbImport);
            this.groupBox1.Controls.Add(this.rbNone);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rbUser
            // 
            resources.ApplyResources(this.rbUser, "rbUser");
            this.rbUser.ForeColor = System.Drawing.Color.DarkGray;
            this.rbUser.Name = "rbUser";
            this.rbUser.TabStop = true;
            this.rbUser.UseVisualStyleBackColor = true;
            this.rbUser.Click += new System.EventHandler(this.rbUser_Click);
            // 
            // rbImport
            // 
            resources.ApplyResources(this.rbImport, "rbImport");
            this.rbImport.ForeColor = System.Drawing.Color.DarkGray;
            this.rbImport.Name = "rbImport";
            this.rbImport.TabStop = true;
            this.rbImport.UseVisualStyleBackColor = true;
            this.rbImport.Click += new System.EventHandler(this.rbImport_Click);
            // 
            // rbNone
            // 
            resources.ApplyResources(this.rbNone, "rbNone");
            this.rbNone.ForeColor = System.Drawing.Color.DarkGray;
            this.rbNone.Name = "rbNone";
            this.rbNone.TabStop = true;
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.Click += new System.EventHandler(this.rbNone_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Name = "label2";
            // 
            // lblQuantityRecords
            // 
            resources.ApplyResources(this.lblQuantityRecords, "lblQuantityRecords");
            this.lblQuantityRecords.ForeColor = System.Drawing.Color.DarkGray;
            this.lblQuantityRecords.Name = "lblQuantityRecords";
            // 
            // btnDownRecords
            // 
            resources.ApplyResources(this.btnDownRecords, "btnDownRecords");
            this.btnDownRecords.FlatAppearance.BorderSize = 0;
            this.btnDownRecords.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDownRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnDownRecords.Image = global::WhoIsDemo.Properties.Resources.arrow_down_bold;
            this.btnDownRecords.Name = "btnDownRecords";
            this.btnDownRecords.UseVisualStyleBackColor = true;
            this.btnDownRecords.Click += new System.EventHandler(this.btnDownRecords_Click);
            // 
            // btnUploadRecords
            // 
            this.btnUploadRecords.FlatAppearance.BorderSize = 0;
            this.btnUploadRecords.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnUploadRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnUploadRecords, "btnUploadRecords");
            this.btnUploadRecords.Image = global::WhoIsDemo.Properties.Resources.arrow_up_bold;
            this.btnUploadRecords.Name = "btnUploadRecords";
            this.btnUploadRecords.UseVisualStyleBackColor = true;
            this.btnUploadRecords.Click += new System.EventHandler(this.btnUploadRecords_Click);
            // 
            // btnStopLoadFile
            // 
            resources.ApplyResources(this.btnStopLoadFile, "btnStopLoadFile");
            this.btnStopLoadFile.FlatAppearance.BorderSize = 0;
            this.btnStopLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnStopLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnStopLoadFile.Image = global::WhoIsDemo.Properties.Resources.timer_off;
            this.btnStopLoadFile.Name = "btnStopLoadFile";
            this.btnStopLoadFile.UseVisualStyleBackColor = true;
            this.btnStopLoadFile.Click += new System.EventHandler(this.btnStopLoadFile_Click);
            // 
            // flpDatabase
            // 
            resources.ApplyResources(this.flpDatabase, "flpDatabase");
            this.flpDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDatabase.Name = "flpDatabase";
            this.flpDatabase.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpDatabase_Scroll);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.FlatAppearance.BorderSize = 0;
            this.btnLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnLoadFile, "btnLoadFile");
            this.btnLoadFile.Image = global::WhoIsDemo.Properties.Resources.file;
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanel1_Scroll);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Name = "label4";
            // 
            // frmEnroll
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEnroll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEnroll_FormClosing);
            this.Load += new System.EventHandler(this.frmEnroll_Load);
            this.Shown += new System.EventHandler(this.frmEnroll_Shown);
            this.Resize += new System.EventHandler(this.frmEnroll_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbUser.ResumeLayout(false);
            this.gbFile.ResumeLayout(false);
            this.gbFile.PerformLayout();
            this.gbVideo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnStopLoadFile;
        private System.Windows.Forms.Button btnDownRecords;
        private System.Windows.Forms.Button btnUploadRecords;
        private System.Windows.Forms.Label lblQuantityRecords;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.Button btnScoreEnroll;
        private System.Windows.Forms.Button btnForcedEnroll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbVideo;
        private System.Windows.Forms.Button btnEnrollUserVideo;
        private System.Windows.Forms.ComboBox cboVideos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.RadioButton rbNone;
    }
}