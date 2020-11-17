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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnroll));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.btnImportVideo = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpTemplates = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblQuantityRecords = new System.Windows.Forms.Label();
            this.btnDownRecords = new System.Windows.Forms.Button();
            this.btnUploadRecords = new System.Windows.Forms.Button();
            this.flpDatabase = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTipBtn = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStopLoadFile = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.gbUser);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.lblQuantityRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnDownRecords);
            this.splitContainer1.Panel2.Controls.Add(this.btnUploadRecords);
            this.splitContainer1.Panel2.Controls.Add(this.flpDatabase);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            // 
            // gbUser
            // 
            resources.ApplyResources(this.gbUser, "gbUser");
            this.gbUser.BackColor = System.Drawing.Color.Transparent;
            this.gbUser.Controls.Add(this.btnImportVideo);
            this.gbUser.Controls.Add(this.btnCamera);
            this.gbUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbUser.ForeColor = System.Drawing.Color.Black;
            this.gbUser.Name = "gbUser";
            this.gbUser.TabStop = false;
            // 
            // btnImportVideo
            // 
            this.btnImportVideo.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnImportVideo, "btnImportVideo");
            this.btnImportVideo.ForeColor = System.Drawing.Color.Transparent;
            this.btnImportVideo.Image = global::WhoIsDemo.Properties.Resources.video_account;
            this.btnImportVideo.Name = "btnImportVideo";
            this.btnImportVideo.Tag = "0";
            this.btnImportVideo.UseVisualStyleBackColor = true;
            this.btnImportVideo.Click += new System.EventHandler(this.btnImportVideo_Click);
            this.btnImportVideo.MouseHover += new System.EventHandler(this.btnImportVideo_MouseHover);
            // 
            // btnCamera
            // 
            this.btnCamera.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCamera, "btnCamera");
            this.btnCamera.ForeColor = System.Drawing.Color.Transparent;
            this.btnCamera.Image = global::WhoIsDemo.Properties.Resources.video_box;
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            this.btnCamera.MouseHover += new System.EventHandler(this.btnCamera_MouseHover);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.flpTemplates);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // flpTemplates
            // 
            resources.ApplyResources(this.flpTemplates, "flpTemplates");
            this.flpTemplates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTemplates.Name = "flpTemplates";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::WhoIsDemo.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "0";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblQuantityRecords
            // 
            resources.ApplyResources(this.lblQuantityRecords, "lblQuantityRecords");
            this.lblQuantityRecords.ForeColor = System.Drawing.Color.Black;
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
            // flpDatabase
            // 
            resources.ApplyResources(this.flpDatabase, "flpDatabase");
            this.flpDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDatabase.Name = "flpDatabase";
            this.flpDatabase.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flpDatabase_Scroll);
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
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnStopLoadFile);
            this.groupBox2.Controls.Add(this.btnFile);
            this.groupBox2.Controls.Add(this.btnImages);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
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
            // btnFile
            // 
            this.btnFile.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFile, "btnFile");
            this.btnFile.ForeColor = System.Drawing.Color.White;
            this.btnFile.Image = global::WhoIsDemo.Properties.Resources.file_account;
            this.btnFile.Name = "btnFile";
            this.btnFile.Tag = "0";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            this.btnFile.MouseHover += new System.EventHandler(this.btnFile_MouseHover);
            // 
            // btnImages
            // 
            this.btnImages.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnImages, "btnImages");
            this.btnImages.ForeColor = System.Drawing.Color.White;
            this.btnImages.Image = global::WhoIsDemo.Properties.Resources.folder_account;
            this.btnImages.Name = "btnImages";
            this.btnImages.Tag = "0";
            this.btnImages.UseVisualStyleBackColor = true;
            this.btnImages.Click += new System.EventHandler(this.btnImages_Click);
            this.btnImages.MouseHover += new System.EventHandler(this.btnImages_MouseHover);
            // 
            // frmEnroll
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownRecords;
        private System.Windows.Forms.Button btnUploadRecords;
        private System.Windows.Forms.Label lblQuantityRecords;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.FlowLayoutPanel flpTemplates;
        private System.Windows.Forms.Button btnImportVideo;
        private System.Windows.Forms.ToolTip toolTipBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopLoadFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnImages;
    }
}