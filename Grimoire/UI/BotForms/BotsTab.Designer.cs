namespace Grimoire.UI.BotForms
{
    partial class BotsTab
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
            this.lblBoosts = new System.Windows.Forms.Label();
            this.lblDrops = new System.Windows.Forms.Label();
            this.lblQuests = new System.Windows.Forms.Label();
            this.lblSkills = new System.Windows.Forms.Label();
            this.lblCommands = new System.Windows.Forms.Label();
            this.txtSavedDesc = new System.Windows.Forms.TextBox();
            this.txtSavedAuthor = new System.Windows.Forms.TextBox();
            this.lblBots = new System.Windows.Forms.Label();
            this.treeBots = new System.Windows.Forms.TreeView();
            this.txtSavedAdd = new System.Windows.Forms.TextBox();
            this.btnSavedAdd = new System.Windows.Forms.Button();
            this.txtSaved = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBoosts
            // 
            this.lblBoosts.AutoSize = true;
            this.lblBoosts.Location = new System.Drawing.Point(298, 286);
            this.lblBoosts.Name = "lblBoosts";
            this.lblBoosts.Size = new System.Drawing.Size(42, 13);
            this.lblBoosts.TabIndex = 37;
            this.lblBoosts.Text = "Boosts:";
            // 
            // lblDrops
            // 
            this.lblDrops.AutoSize = true;
            this.lblDrops.Location = new System.Drawing.Point(233, 286);
            this.lblDrops.Name = "lblDrops";
            this.lblDrops.Size = new System.Drawing.Size(38, 13);
            this.lblDrops.TabIndex = 36;
            this.lblDrops.Text = "Drops:";
            // 
            // lblQuests
            // 
            this.lblQuests.AutoSize = true;
            this.lblQuests.Location = new System.Drawing.Point(165, 286);
            this.lblQuests.Name = "lblQuests";
            this.lblQuests.Size = new System.Drawing.Size(43, 13);
            this.lblQuests.TabIndex = 35;
            this.lblQuests.Text = "Quests:";
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(107, 286);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(34, 13);
            this.lblSkills.TabIndex = 34;
            this.lblSkills.Text = "Skills:";
            // 
            // lblCommands
            // 
            this.lblCommands.AutoSize = true;
            this.lblCommands.Location = new System.Drawing.Point(12, 273);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(62, 26);
            this.lblCommands.TabIndex = 33;
            this.lblCommands.Text = "Number of\r\nCommands:";
            // 
            // txtSavedDesc
            // 
            this.txtSavedDesc.Location = new System.Drawing.Point(218, 101);
            this.txtSavedDesc.Multiline = true;
            this.txtSavedDesc.Name = "txtSavedDesc";
            this.txtSavedDesc.Size = new System.Drawing.Size(221, 168);
            this.txtSavedDesc.TabIndex = 32;
            this.txtSavedDesc.Text = "Description";
            this.txtSavedDesc.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSavedDesc.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtSavedAuthor
            // 
            this.txtSavedAuthor.Location = new System.Drawing.Point(218, 77);
            this.txtSavedAuthor.Name = "txtSavedAuthor";
            this.txtSavedAuthor.Size = new System.Drawing.Size(221, 20);
            this.txtSavedAuthor.TabIndex = 31;
            this.txtSavedAuthor.Text = "Author";
            this.txtSavedAuthor.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSavedAuthor.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // lblBots
            // 
            this.lblBots.AutoSize = true;
            this.lblBots.Location = new System.Drawing.Point(218, 61);
            this.lblBots.Name = "lblBots";
            this.lblBots.Size = new System.Drawing.Size(83, 13);
            this.lblBots.TabIndex = 30;
            this.lblBots.Text = "Number of Bots:";
            // 
            // treeBots
            // 
            this.treeBots.Location = new System.Drawing.Point(12, 38);
            this.treeBots.Name = "treeBots";
            this.treeBots.Size = new System.Drawing.Size(200, 231);
            this.treeBots.TabIndex = 29;
            this.treeBots.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeBots_AfterExpand);
            this.treeBots.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeBots_AfterSelect);
            // 
            // txtSavedAdd
            // 
            this.txtSavedAdd.Location = new System.Drawing.Point(218, 38);
            this.txtSavedAdd.Name = "txtSavedAdd";
            this.txtSavedAdd.Size = new System.Drawing.Size(140, 20);
            this.txtSavedAdd.TabIndex = 28;
            // 
            // btnSavedAdd
            // 
            this.btnSavedAdd.Location = new System.Drawing.Point(364, 36);
            this.btnSavedAdd.Name = "btnSavedAdd";
            this.btnSavedAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSavedAdd.TabIndex = 27;
            this.btnSavedAdd.Text = "Add folder";
            this.btnSavedAdd.UseVisualStyleBackColor = true;
            this.btnSavedAdd.Click += new System.EventHandler(this.btnSavedAdd_Click);
            // 
            // txtSaved
            // 
            this.txtSaved.Location = new System.Drawing.Point(12, 12);
            this.txtSaved.Name = "txtSaved";
            this.txtSaved.Size = new System.Drawing.Size(427, 20);
            this.txtSaved.TabIndex = 26;
            // 
            // BotsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 314);
            this.Controls.Add(this.lblBoosts);
            this.Controls.Add(this.lblDrops);
            this.Controls.Add(this.lblQuests);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.lblCommands);
            this.Controls.Add(this.txtSavedDesc);
            this.Controls.Add(this.txtSavedAuthor);
            this.Controls.Add(this.lblBots);
            this.Controls.Add(this.treeBots);
            this.Controls.Add(this.txtSavedAdd);
            this.Controls.Add(this.btnSavedAdd);
            this.Controls.Add(this.txtSaved);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BotsTab";
            this.Text = "Bots";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBoosts;
        private System.Windows.Forms.Label lblDrops;
        private System.Windows.Forms.Label lblQuests;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.Label lblCommands;
        private System.Windows.Forms.TextBox txtSavedDesc;
        private System.Windows.Forms.TextBox txtSavedAuthor;
        private System.Windows.Forms.Label lblBots;
        private System.Windows.Forms.TreeView treeBots;
        private System.Windows.Forms.TextBox txtSavedAdd;
        private System.Windows.Forms.Button btnSavedAdd;
        private System.Windows.Forms.TextBox txtSaved;
    }
}