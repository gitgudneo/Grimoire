namespace Grimoire.UI
{
    partial class Loaders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loaders));
            this.txtLoaders = new System.Windows.Forms.TextBox();
            this.cbLoad = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbGrab = new System.Windows.Forms.ComboBox();
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeGrabbed = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // txtLoaders
            // 
            this.txtLoaders.Location = new System.Drawing.Point(52, 12);
            this.txtLoaders.Name = "txtLoaders";
            this.txtLoaders.Size = new System.Drawing.Size(136, 20);
            this.txtLoaders.TabIndex = 29;
            // 
            // cbLoad
            // 
            this.cbLoad.FormattingEnabled = true;
            this.cbLoad.Items.AddRange(new object[] {
            "Hair shop",
            "Shop",
            "Quest",
            "Armor customizer"});
            this.cbLoad.Location = new System.Drawing.Point(52, 38);
            this.cbLoad.Name = "cbLoad";
            this.cbLoad.Size = new System.Drawing.Size(136, 21);
            this.cbLoad.TabIndex = 30;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(52, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(136, 23);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbGrab
            // 
            this.cbGrab.FormattingEnabled = true;
            this.cbGrab.Items.AddRange(new object[] {
            "Shop items",
            "Quest IDs",
            "Quest items, drop rates",
            "Inventory items",
            "Temp inventory items",
            "Bank items",
            "Monsters"});
            this.cbGrab.Location = new System.Drawing.Point(12, 301);
            this.cbGrab.Name = "cbGrab";
            this.cbGrab.Size = new System.Drawing.Size(217, 21);
            this.cbGrab.TabIndex = 33;
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(154, 328);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(75, 23);
            this.btnGrab.TabIndex = 34;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeGrabbed
            // 
            this.treeGrabbed.LabelEdit = true;
            this.treeGrabbed.Location = new System.Drawing.Point(12, 94);
            this.treeGrabbed.Name = "treeGrabbed";
            this.treeGrabbed.Size = new System.Drawing.Size(217, 201);
            this.treeGrabbed.TabIndex = 38;
            // 
            // Loaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 360);
            this.Controls.Add(this.treeGrabbed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.cbGrab);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbLoad);
            this.Controls.Add(this.txtLoaders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Loaders";
            this.Text = "Loaders and grabbers";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loaders_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLoaders;
        private System.Windows.Forms.ComboBox cbLoad;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cbGrab;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView treeGrabbed;
    }
}