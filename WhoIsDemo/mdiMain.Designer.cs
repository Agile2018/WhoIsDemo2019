namespace WhoIsDemo
{
    partial class mdiMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelHandlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.detecciónToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.channelHandlerToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            resources.ApplyResources(this.configuraciónToolStripMenuItem, "configuraciónToolStripMenuItem");
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // channelHandlerToolStripMenuItem
            // 
            this.channelHandlerToolStripMenuItem.Name = "channelHandlerToolStripMenuItem";
            resources.ApplyResources(this.channelHandlerToolStripMenuItem, "channelHandlerToolStripMenuItem");
            this.channelHandlerToolStripMenuItem.Click += new System.EventHandler(this.channelHandlerToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // detecciónToolStripMenuItem
            // 
            this.detecciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enrolamientoToolStripMenuItem,
            this.controlDeEntradaToolStripMenuItem});
            this.detecciónToolStripMenuItem.Name = "detecciónToolStripMenuItem";
            resources.ApplyResources(this.detecciónToolStripMenuItem, "detecciónToolStripMenuItem");
            // 
            // enrolamientoToolStripMenuItem
            // 
            this.enrolamientoToolStripMenuItem.Name = "enrolamientoToolStripMenuItem";
            resources.ApplyResources(this.enrolamientoToolStripMenuItem, "enrolamientoToolStripMenuItem");
            this.enrolamientoToolStripMenuItem.Click += new System.EventHandler(this.enrolamientoToolStripMenuItem_Click);
            // 
            // controlDeEntradaToolStripMenuItem
            // 
            this.controlDeEntradaToolStripMenuItem.Name = "controlDeEntradaToolStripMenuItem";
            resources.ApplyResources(this.controlDeEntradaToolStripMenuItem, "controlDeEntradaToolStripMenuItem");
            this.controlDeEntradaToolStripMenuItem.Click += new System.EventHandler(this.controlDeEntradaToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // mdiMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WhoIsDemo.Properties.Resources.agile;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mdiMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiMain_FormClosing);
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.Shown += new System.EventHandler(this.mdiMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detecciónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem enrolamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelHandlerToolStripMenuItem;
    }
}

