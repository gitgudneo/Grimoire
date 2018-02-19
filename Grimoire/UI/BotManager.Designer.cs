namespace Grimoire.UI
{
    partial class BotManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotManager));
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.lstBoosts = new System.Windows.Forms.ListBox();
            this.lstDrops = new System.Windows.Forms.ListBox();
            this.lstQuests = new System.Windows.Forms.ListBox();
            this.lstSkills = new System.Windows.Forms.ListBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cbLists = new System.Windows.Forms.ComboBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.combatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCommands
            // 
            this.lstCommands.BackColor = System.Drawing.Color.White;
            this.lstCommands.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCommands.ForeColor = System.Drawing.Color.Black;
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.HorizontalScrollbar = true;
            this.lstCommands.Location = new System.Drawing.Point(12, 27);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.Size = new System.Drawing.Size(201, 238);
            this.lstCommands.TabIndex = 1;
            this.lstCommands.DoubleClick += new System.EventHandler(this.lstCommands_DoubleClick);
            // 
            // lstBoosts
            // 
            this.lstBoosts.BackColor = System.Drawing.Color.White;
            this.lstBoosts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoosts.ForeColor = System.Drawing.Color.Black;
            this.lstBoosts.FormattingEnabled = true;
            this.lstBoosts.HorizontalScrollbar = true;
            this.lstBoosts.Location = new System.Drawing.Point(12, 27);
            this.lstBoosts.Name = "lstBoosts";
            this.lstBoosts.Size = new System.Drawing.Size(201, 238);
            this.lstBoosts.TabIndex = 25;
            // 
            // lstDrops
            // 
            this.lstDrops.BackColor = System.Drawing.Color.White;
            this.lstDrops.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDrops.ForeColor = System.Drawing.Color.Black;
            this.lstDrops.FormattingEnabled = true;
            this.lstDrops.HorizontalScrollbar = true;
            this.lstDrops.Location = new System.Drawing.Point(12, 27);
            this.lstDrops.Name = "lstDrops";
            this.lstDrops.Size = new System.Drawing.Size(201, 238);
            this.lstDrops.TabIndex = 26;
            // 
            // lstQuests
            // 
            this.lstQuests.BackColor = System.Drawing.Color.White;
            this.lstQuests.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQuests.ForeColor = System.Drawing.Color.Black;
            this.lstQuests.FormattingEnabled = true;
            this.lstQuests.HorizontalScrollbar = true;
            this.lstQuests.Location = new System.Drawing.Point(12, 27);
            this.lstQuests.Name = "lstQuests";
            this.lstQuests.Size = new System.Drawing.Size(201, 238);
            this.lstQuests.TabIndex = 27;
            // 
            // lstSkills
            // 
            this.lstSkills.BackColor = System.Drawing.Color.White;
            this.lstSkills.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSkills.ForeColor = System.Drawing.Color.Black;
            this.lstSkills.FormattingEnabled = true;
            this.lstSkills.HorizontalScrollbar = true;
            this.lstSkills.Location = new System.Drawing.Point(12, 27);
            this.lstSkills.Name = "lstSkills";
            this.lstSkills.Size = new System.Drawing.Size(201, 238);
            this.lstSkills.TabIndex = 28;
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(12, 265);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(102, 23);
            this.btnDown.TabIndex = 37;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(112, 265);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(101, 23);
            this.btnUp.TabIndex = 38;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(138, 294);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 39;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 294);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(88, 298);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAll.Size = new System.Drawing.Size(48, 17);
            this.chkAll.TabIndex = 41;
            this.chkAll.Text = "all ->";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // cbLists
            // 
            this.cbLists.FormattingEnabled = true;
            this.cbLists.Items.AddRange(new object[] {
            "Commands",
            "Skills",
            "Quests",
            "Drops",
            "Boosts"});
            this.cbLists.Location = new System.Drawing.Point(12, 321);
            this.cbLists.Name = "cbLists";
            this.cbLists.Size = new System.Drawing.Size(118, 21);
            this.cbLists.TabIndex = 42;
            this.cbLists.SelectedIndexChanged += new System.EventHandler(this.cbLists_SelectedIndexChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(136, 323);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(77, 17);
            this.chkEnable.TabIndex = 101;
            this.chkEnable.Text = "Enable bot";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.Click += new System.EventHandler(this.chkEnable_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combatToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.questToolStripMenuItem,
            this.miscToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.botsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 109;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // combatToolStripMenuItem
            // 
            this.combatToolStripMenuItem.Name = "combatToolStripMenuItem";
            this.combatToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.combatToolStripMenuItem.Text = "Combat";
            this.combatToolStripMenuItem.Click += new System.EventHandler(this.combatToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // questToolStripMenuItem
            // 
            this.questToolStripMenuItem.Name = "questToolStripMenuItem";
            this.questToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.questToolStripMenuItem.Text = "Quest";
            this.questToolStripMenuItem.Click += new System.EventHandler(this.questToolStripMenuItem_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.miscToolStripMenuItem.Text = "Misc";
            this.miscToolStripMenuItem.Click += new System.EventHandler(this.miscToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // botsToolStripMenuItem
            // 
            this.botsToolStripMenuItem.Name = "botsToolStripMenuItem";
            this.botsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.botsToolStripMenuItem.Text = "Bots";
            this.botsToolStripMenuItem.Click += new System.EventHandler(this.botsToolStripMenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContainer.Location = new System.Drawing.Point(219, 27);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(395, 327);
            this.pnlContainer.TabIndex = 110;
            // 
            // BotManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 354);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.cbLists);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.lstSkills);
            this.Controls.Add(this.lstQuests);
            this.Controls.Add(this.lstDrops);
            this.Controls.Add(this.lstBoosts);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(371, 396);
            this.Name = "BotManager";
            this.Text = " Bot";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BotManager_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.ListBox lstSkills;
        private System.Windows.Forms.ListBox lstQuests;
        private System.Windows.Forms.ListBox lstDrops;
        private System.Windows.Forms.ListBox lstBoosts;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cbLists;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem combatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContainer;
    }
}