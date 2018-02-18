namespace Grimoire.UI.BotForms
{
    partial class MiscTab
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
            this.chkRestartDeath = new System.Windows.Forms.CheckBox();
            this.chkMerge = new System.Windows.Forms.CheckBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.btnGotoLabel = new System.Windows.Forms.Button();
            this.btnAddLabel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelay = new System.Windows.Forms.Button();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBotDelay = new System.Windows.Forms.NumericUpDown();
            this.btnBotDelay = new System.Windows.Forms.Button();
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLoadCmd = new System.Windows.Forms.Button();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.btnStatementAdd = new System.Windows.Forms.Button();
            this.txtStatement2 = new System.Windows.Forms.TextBox();
            this.txtStatement1 = new System.Windows.Forms.TextBox();
            this.cbStatement = new System.Windows.Forms.ComboBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.txtPacket = new System.Windows.Forms.TextBox();
            this.btnPacket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBotDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRestartDeath
            // 
            this.chkRestartDeath.AutoSize = true;
            this.chkRestartDeath.Checked = true;
            this.chkRestartDeath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestartDeath.Location = new System.Drawing.Point(159, 236);
            this.chkRestartDeath.Name = "chkRestartDeath";
            this.chkRestartDeath.Size = new System.Drawing.Size(133, 17);
            this.chkRestartDeath.TabIndex = 145;
            this.chkRestartDeath.Text = "Restart bot upon dying";
            this.chkRestartDeath.UseVisualStyleBackColor = true;
            // 
            // chkMerge
            // 
            this.chkMerge.AutoSize = true;
            this.chkMerge.Location = new System.Drawing.Point(386, 66);
            this.chkMerge.Name = "chkMerge";
            this.chkMerge.Size = new System.Drawing.Size(56, 17);
            this.chkMerge.TabIndex = 144;
            this.chkMerge.Text = "Merge";
            this.chkMerge.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(367, 232);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 143;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(308, 178);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(134, 20);
            this.txtLabel.TabIndex = 142;
            this.txtLabel.Text = "Label name";
            this.txtLabel.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtLabel.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnGotoLabel
            // 
            this.btnGotoLabel.Location = new System.Drawing.Point(346, 204);
            this.btnGotoLabel.Name = "btnGotoLabel";
            this.btnGotoLabel.Size = new System.Drawing.Size(45, 23);
            this.btnGotoLabel.TabIndex = 141;
            this.btnGotoLabel.Text = "Goto";
            this.btnGotoLabel.UseVisualStyleBackColor = true;
            this.btnGotoLabel.Click += new System.EventHandler(this.btnGotoLabel_Click);
            // 
            // btnAddLabel
            // 
            this.btnAddLabel.Location = new System.Drawing.Point(397, 204);
            this.btnAddLabel.Name = "btnAddLabel";
            this.btnAddLabel.Size = new System.Drawing.Size(45, 23);
            this.btnAddLabel.TabIndex = 140;
            this.btnAddLabel.Text = "Add";
            this.btnAddLabel.UseVisualStyleBackColor = true;
            this.btnAddLabel.Click += new System.EventHandler(this.btnAddLabel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(308, 112);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(134, 58);
            this.txtDescription.TabIndex = 138;
            this.txtDescription.Text = "Description";
            this.txtDescription.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtDescription.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(308, 86);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(134, 20);
            this.txtAuthor.TabIndex = 139;
            this.txtAuthor.Text = "Author";
            this.txtAuthor.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtAuthor.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 137;
            this.label14.Text = "If...";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 136;
            this.btnSave.Text = "Save bot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelay
            // 
            this.btnDelay.Location = new System.Drawing.Point(170, 77);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(69, 23);
            this.btnDelay.TabIndex = 135;
            this.btnDelay.Text = "Delay";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(243, 79);
            this.numDelay.Maximum = new decimal(new int[] {
            71000,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(59, 20);
            this.numDelay.TabIndex = 134;
            this.numDelay.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "Bot delay";
            // 
            // numBotDelay
            // 
            this.numBotDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBotDelay.Location = new System.Drawing.Point(67, 203);
            this.numBotDelay.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numBotDelay.Name = "numBotDelay";
            this.numBotDelay.Size = new System.Drawing.Size(76, 20);
            this.numBotDelay.TabIndex = 132;
            this.numBotDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnBotDelay
            // 
            this.btnBotDelay.Location = new System.Drawing.Point(149, 203);
            this.btnBotDelay.Name = "btnBotDelay";
            this.btnBotDelay.Size = new System.Drawing.Size(90, 23);
            this.btnBotDelay.TabIndex = 131;
            this.btnBotDelay.Text = "Bot delay (cmd)";
            this.btnBotDelay.UseVisualStyleBackColor = true;
            this.btnBotDelay.Click += new System.EventHandler(this.btnBotDelay_Click);
            // 
            // txtPlayer
            // 
            this.txtPlayer.Location = new System.Drawing.Point(170, 106);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(132, 20);
            this.txtPlayer.TabIndex = 130;
            this.txtPlayer.Text = "Player name";
            this.txtPlayer.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtPlayer.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(170, 132);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(132, 23);
            this.btnGoto.TabIndex = 129;
            this.btnGoto.Text = "Goto";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(378, 39);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(64, 23);
            this.btnLoad.TabIndex = 128;
            this.btnLoad.Text = "Load bot";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(378, 10);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(64, 23);
            this.btnRestart.TabIndex = 127;
            this.btnRestart.Text = "Restart bot";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(308, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 23);
            this.btnStop.TabIndex = 126;
            this.btnStop.Text = "Stop bot";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLoadCmd
            // 
            this.btnLoadCmd.Location = new System.Drawing.Point(170, 49);
            this.btnLoadCmd.Name = "btnLoadCmd";
            this.btnLoadCmd.Size = new System.Drawing.Size(132, 23);
            this.btnLoadCmd.TabIndex = 125;
            this.btnLoadCmd.Text = "Load bot (command)";
            this.btnLoadCmd.UseVisualStyleBackColor = true;
            this.btnLoadCmd.Click += new System.EventHandler(this.btnLoadCmd_Click);
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Checked = true;
            this.chkSkip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkip.Location = new System.Drawing.Point(13, 186);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(219, 17);
            this.chkSkip.TabIndex = 124;
            this.chkSkip.Text = "Skip bot delay for if and index commands";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // btnStatementAdd
            // 
            this.btnStatementAdd.Location = new System.Drawing.Point(13, 157);
            this.btnStatementAdd.Name = "btnStatementAdd";
            this.btnStatementAdd.Size = new System.Drawing.Size(151, 23);
            this.btnStatementAdd.TabIndex = 123;
            this.btnStatementAdd.Text = "Add statement";
            this.btnStatementAdd.UseVisualStyleBackColor = true;
            this.btnStatementAdd.Click += new System.EventHandler(this.btnStatementAdd_Click);
            // 
            // txtStatement2
            // 
            this.txtStatement2.Location = new System.Drawing.Point(13, 131);
            this.txtStatement2.Name = "txtStatement2";
            this.txtStatement2.Size = new System.Drawing.Size(151, 20);
            this.txtStatement2.TabIndex = 122;
            // 
            // txtStatement1
            // 
            this.txtStatement1.Location = new System.Drawing.Point(13, 105);
            this.txtStatement1.Name = "txtStatement1";
            this.txtStatement1.Size = new System.Drawing.Size(151, 20);
            this.txtStatement1.TabIndex = 121;
            // 
            // cbStatement
            // 
            this.cbStatement.FormattingEnabled = true;
            this.cbStatement.Location = new System.Drawing.Point(13, 78);
            this.cbStatement.Name = "cbStatement";
            this.cbStatement.Size = new System.Drawing.Size(151, 21);
            this.cbStatement.TabIndex = 120;
            this.cbStatement.SelectedIndexChanged += new System.EventHandler(this.cbStatement_SelectedIndexChanged);
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Items.AddRange(new object[] {
            "Item",
            "This player",
            "Player",
            "Map",
            "Monster",
            "Quest"});
            this.cbCategories.Location = new System.Drawing.Point(13, 51);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(151, 21);
            this.cbCategories.TabIndex = 119;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // txtPacket
            // 
            this.txtPacket.Location = new System.Drawing.Point(12, 12);
            this.txtPacket.Name = "txtPacket";
            this.txtPacket.Size = new System.Drawing.Size(235, 20);
            this.txtPacket.TabIndex = 118;
            this.txtPacket.Text = "%xt%zm%.........";
            this.txtPacket.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtPacket.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnPacket
            // 
            this.btnPacket.Location = new System.Drawing.Point(253, 10);
            this.btnPacket.Name = "btnPacket";
            this.btnPacket.Size = new System.Drawing.Size(49, 23);
            this.btnPacket.TabIndex = 117;
            this.btnPacket.Text = "Packet";
            this.btnPacket.UseVisualStyleBackColor = true;
            this.btnPacket.Click += new System.EventHandler(this.btnPacket_Click);
            // 
            // MiscTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 274);
            this.Controls.Add(this.chkRestartDeath);
            this.Controls.Add(this.chkMerge);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.btnGotoLabel);
            this.Controls.Add(this.btnAddLabel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelay);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numBotDelay);
            this.Controls.Add(this.btnBotDelay);
            this.Controls.Add(this.txtPlayer);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLoadCmd);
            this.Controls.Add(this.chkSkip);
            this.Controls.Add(this.btnStatementAdd);
            this.Controls.Add(this.txtStatement2);
            this.Controls.Add(this.txtStatement1);
            this.Controls.Add(this.cbStatement);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.txtPacket);
            this.Controls.Add(this.btnPacket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MiscTab";
            this.Text = "Misc";
            this.Load += new System.EventHandler(this.Misc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBotDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRestartDeath;
        private System.Windows.Forms.CheckBox chkMerge;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button btnGotoLabel;
        private System.Windows.Forms.Button btnAddLabel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelay;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBotDelay;
        private System.Windows.Forms.Button btnBotDelay;
        private System.Windows.Forms.TextBox txtPlayer;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLoadCmd;
        private System.Windows.Forms.CheckBox chkSkip;
        private System.Windows.Forms.Button btnStatementAdd;
        private System.Windows.Forms.TextBox txtStatement2;
        private System.Windows.Forms.TextBox txtStatement1;
        private System.Windows.Forms.ComboBox cbStatement;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.TextBox txtPacket;
        private System.Windows.Forms.Button btnPacket;
    }
}