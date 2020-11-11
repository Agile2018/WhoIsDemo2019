namespace WhoIsDemo.form
{
    partial class frmAccessControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnControlEntryVideo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopLoadFile = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.ForeColor = System.Drawing.Color.White;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnControlEntryVideo);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnStopLoadFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadFile);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(81)))));
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            // 
            // btnControlEntryVideo
            // 
            this.btnControlEntryVideo.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnControlEntryVideo, "btnControlEntryVideo");
            this.btnControlEntryVideo.ForeColor = System.Drawing.Color.Transparent;
            this.btnControlEntryVideo.Image = global::WhoIsDemo.Properties.Resources.video_account;
            this.btnControlEntryVideo.Name = "btnControlEntryVideo";
            this.btnControlEntryVideo.Tag = "0";
            this.btnControlEntryVideo.UseVisualStyleBackColor = true;
            this.btnControlEntryVideo.Click += new System.EventHandler(this.btnControlEntryVideo_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::WhoIsDemo.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // btnLoadFile
            // 
            this.btnLoadFile.FlatAppearance.BorderSize = 0;
            this.btnLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            resources.ApplyResources(this.btnLoadFile, "btnLoadFile");
            this.btnLoadFile.Image = global::WhoIsDemo.Properties.Resources.file_account;
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // frmAccessControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAccessControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccessControl_FormClosing);
            this.Load += new System.EventHandler(this.frmAccessControl_Load);
            this.Shown += new System.EventHandler(this.frmAccessControl_Shown);
            this.Resize += new System.EventHandler(this.frmAccessControl_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnStopLoadFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnControlEntryVideo;
    }
}