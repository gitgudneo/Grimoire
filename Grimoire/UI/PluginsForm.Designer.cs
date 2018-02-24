namespace Grimoire.UI
{
    partial class PluginsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsForm));
            this.gbLoaded = new System.Windows.Forms.GroupBox();
            this.btnUnload = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lstLoaded = new System.Windows.Forms.ListBox();
            this.gbLoad = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtPlugin = new System.Windows.Forms.TextBox();
            this.chkAutoload = new System.Windows.Forms.CheckBox();
            this.gbLoaded.SuspendLayout();
            this.gbLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoaded
            // 
            this.gbLoaded.Controls.Add(this.btnUnload);
            this.gbLoaded.Controls.Add(this.txtDesc);
            this.gbLoaded.Controls.Add(this.lblAuthor);
            this.gbLoaded.Controls.Add(this.lstLoaded);
            this.gbLoaded.Location = new System.Drawing.Point(12, 95);
            this.gbLoaded.Name = "gbLoaded";
            this.gbLoaded.Size = new System.Drawing.Size(292, 267);
            this.gbLoaded.TabIndex = 12;
            this.gbLoaded.TabStop = false;
            this.gbLoaded.Text = "Loaded plugins";
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(155, 238);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(128, 23);
            this.btnUnload.TabIndex = 3;
            this.btnUnload.Text = "Unload selected plugin";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 120);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesc.Size = new System.Drawing.Size(277, 112);
            this.txtDesc.TabIndex = 2;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 104);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(92, 13);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Plugin created by:";
            // 
            // lstLoaded
            // 
            this.lstLoaded.FormattingEnabled = true;
            this.lstLoaded.Location = new System.Drawing.Point(6, 19);
            this.lstLoaded.Name = "lstLoaded";
            this.lstLoaded.ScrollAlwaysVisible = true;
            this.lstLoaded.Size = new System.Drawing.Size(277, 82);
            this.lstLoaded.TabIndex = 0;
            this.lstLoaded.SelectedIndexChanged += new System.EventHandler(this.lstLoaded_SelectedIndexChanged);
            // 
            // gbLoad
            // 
            this.gbLoad.Controls.Add(this.chkAutoload);
            this.gbLoad.Controls.Add(this.btnBrowse);
            this.gbLoad.Controls.Add(this.btnLoad);
            this.gbLoad.Controls.Add(this.txtPlugin);
            this.gbLoad.Location = new System.Drawing.Point(12, 12);
            this.gbLoad.Name = "gbLoad";
            this.gbLoad.Size = new System.Drawing.Size(292, 77);
            this.gbLoad.TabIndex = 11;
            this.gbLoad.TabStop = false;
            this.gbLoad.Text = "Load plugin";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(258, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(208, 46);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtPlugin
            // 
            this.txtPlugin.Location = new System.Drawing.Point(6, 19);
            this.txtPlugin.Name = "txtPlugin";
            this.txtPlugin.Size = new System.Drawing.Size(246, 20);
            this.txtPlugin.TabIndex = 4;
            // 
            // chkAutoload
            // 
            this.chkAutoload.AutoSize = true;
            this.chkAutoload.Location = new System.Drawing.Point(33, 50);
            this.chkAutoload.Name = "chkAutoload";
            this.chkAutoload.Size = new System.Drawing.Size(169, 17);
            this.chkAutoload.TabIndex = 9;
            this.chkAutoload.Text = "Auto load when Grimoire starts";
            this.chkAutoload.UseVisualStyleBackColor = true;
            // 
            // PluginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 370);
            this.Controls.Add(this.gbLoaded);
            this.Controls.Add(this.gbLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PluginsForm";
            this.Text = "Plugin Manager";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PluginManager_FormClosing);
            this.gbLoaded.ResumeLayout(false);
            this.gbLoaded.PerformLayout();
            this.gbLoad.ResumeLayout(false);
            this.gbLoad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbLoaded;
        public System.Windows.Forms.Button btnUnload;
        public System.Windows.Forms.TextBox txtDesc;
        public System.Windows.Forms.Label lblAuthor;
        public System.Windows.Forms.ListBox lstLoaded;
        public System.Windows.Forms.GroupBox gbLoad;
        public System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.TextBox txtPlugin;
        private System.Windows.Forms.CheckBox chkAutoload;
    }
}