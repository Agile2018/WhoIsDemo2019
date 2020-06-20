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
    }
}