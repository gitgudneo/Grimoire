namespace Grimoire.UI.BotForms
{
    partial class OptionsTab
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
            this.chkEnableSettings = new System.Windows.Forms.CheckBox();
            this.chkDisableAnims = new System.Windows.Forms.CheckBox();
            this.txtSoundItem = new System.Windows.Forms.TextBox();
            this.btnSoundAdd = new System.Windows.Forms.Button();
            this.btnSoundDelete = new System.Windows.Forms.Button();
            this.btnSoundClear = new System.Windows.Forms.Button();
            this.btnSoundTest = new System.Windows.Forms.Button();
            this.lstSoundItems = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numWalkSpeed = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSkipCutscenes = new System.Windows.Forms.CheckBox();
            this.chkHidePlayers = new System.Windows.Forms.CheckBox();
            this.chkLag = new System.Windows.Forms.CheckBox();
            this.chkMagnet = new System.Windows.Forms.CheckBox();
            this.chkProvoke = new System.Windows.Forms.CheckBox();
            this.chkInfiniteRange = new System.Windows.Forms.CheckBox();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.cbServers = new System.Windows.Forms.ComboBox();
            this.chkRelogRetry = new System.Windows.Forms.CheckBox();
            this.chkRelog = new System.Windows.Forms.CheckBox();
            this.numRelogDelay = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEnableSettings
            // 
            this.chkEnableSettings.AutoSize = true;
            this.chkEnableSettings.Location = new System.Drawing.Point(183, 195);
            this.chkEnableSettings.Name = "chkEnableSettings";
            this.chkEnableSettings.Size = new System.Drawing.Size(97, 43);
            this.chkEnableSettings.TabIndex = 150;
            this.chkEnableSettings.Text = "Enable options\r\nwithout starting\r\nthe bot";
            this.chkEnableSettings.UseVisualStyleBackColor = true;
            this.chkEnableSettings.Click += new System.EventHandler(this.chkEnableSettings_Click);
            // 
            // chkDisableAnims
            // 
            this.chkDisableAnims.AutoSize = true;
            this.chkDisableAnims.Location = new System.Drawing.Point(174, 151);
            this.chkDisableAnims.Name = "chkDisableAnims";
            this.chkDisableAnims.Size = new System.Drawing.Size(122, 17);
            this.chkDisableAnims.TabIndex = 149;
            this.chkDisableAnims.Text = "Disable player anims";
            this.chkDisableAnims.UseVisualStyleBackColor = true;
            this.chkDisableAnims.CheckedChanged += new System.EventHandler(this.chkDisableAnims_CheckedChanged);
            // 
            // txtSoundItem
            // 
            this.txtSoundItem.Location = new System.Drawing.Point(19, 268);
            this.txtSoundItem.Name = "txtSoundItem";
            this.txtSoundItem.Size = new System.Drawing.Size(149, 20);
            this.txtSoundItem.TabIndex = 148;
            // 
            // btnSoundAdd
            // 
            this.btnSoundAdd.Location = new System.Drawing.Point(181, 294);
            this.btnSoundAdd.Name = "btnSoundAdd";
            this.btnSoundAdd.Size = new System.Drawing.Size(47, 23);
            this.btnSoundAdd.TabIndex = 147;
            this.btnSoundAdd.Text = "Add";
            this.btnSoundAdd.UseVisualStyleBackColor = true;
            this.btnSoundAdd.Click += new System.EventHandler(this.btnSoundAdd_Click);
            // 
            // btnSoundDelete
            // 
            this.btnSoundDelete.Location = new System.Drawing.Point(128, 294);
            this.btnSoundDelete.Name = "btnSoundDelete";
            this.btnSoundDelete.Size = new System.Drawing.Size(47, 23);
            this.btnSoundDelete.TabIndex = 146;
            this.btnSoundDelete.Text = "Delete";
            this.btnSoundDelete.UseVisualStyleBackColor = true;
            this.btnSoundDelete.Click += new System.EventHandler(this.btnSoundDelete_Click);
            // 
            // btnSoundClear
            // 
            this.btnSoundClear.Location = new System.Drawing.Point(75, 294);
            this.btnSoundClear.Name = "btnSoundClear";
            this.btnSoundClear.Size = new System.Drawing.Size(47, 23);
            this.btnSoundClear.TabIndex = 145;
            this.btnSoundClear.Text = "Clear";
            this.btnSoundClear.UseVisualStyleBackColor = true;
            this.btnSoundClear.Click += new System.EventHandler(this.btnSoundClear_Click);
            // 
            // btnSoundTest
            // 
            this.btnSoundTest.Location = new System.Drawing.Point(22, 294);
            this.btnSoundTest.Name = "btnSoundTest";
            this.btnSoundTest.Size = new System.Drawing.Size(47, 23);
            this.btnSoundTest.TabIndex = 144;
            this.btnSoundTest.Text = "Test";
            this.btnSoundTest.UseVisualStyleBackColor = true;
            this.btnSoundTest.Click += new System.EventHandler(this.btnSoundTest_Click);
            // 
            // lstSoundItems
            // 
            this.lstSoundItems.FormattingEnabled = true;
            this.lstSoundItems.Location = new System.Drawing.Point(19, 193);
            this.lstSoundItems.Name = "lstSoundItems";
            this.lstSoundItems.Size = new System.Drawing.Size(149, 69);
            this.lstSoundItems.TabIndex = 143;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 26);
            this.label9.TabIndex = 142;
            this.label9.Text = "If any of the following items\r\nare dropped, play a sound";
            // 
            // numWalkSpeed
            // 
            this.numWalkSpeed.Location = new System.Drawing.Point(237, 169);
            this.numWalkSpeed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numWalkSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkSpeed.Name = "numWalkSpeed";
            this.numWalkSpeed.Size = new System.Drawing.Size(33, 20);
            this.numWalkSpeed.TabIndex = 141;
            this.numWalkSpeed.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numWalkSpeed.ValueChanged += new System.EventHandler(this.numWalkSpeed_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 140;
            this.label8.Text = "Walk speed";
            // 
            // chkSkipCutscenes
            // 
            this.chkSkipCutscenes.AutoSize = true;
            this.chkSkipCutscenes.Location = new System.Drawing.Point(174, 128);
            this.chkSkipCutscenes.Name = "chkSkipCutscenes";
            this.chkSkipCutscenes.Size = new System.Drawing.Size(99, 17);
            this.chkSkipCutscenes.TabIndex = 139;
            this.chkSkipCutscenes.Text = "Skip cutscenes";
            this.chkSkipCutscenes.UseVisualStyleBackColor = true;
            this.chkSkipCutscenes.CheckedChanged += new System.EventHandler(this.chkSkipCutscenes_CheckedChanged);
            // 
            // chkHidePlayers
            // 
            this.chkHidePlayers.AutoSize = true;
            this.chkHidePlayers.Location = new System.Drawing.Point(174, 105);
            this.chkHidePlayers.Name = "chkHidePlayers";
            this.chkHidePlayers.Size = new System.Drawing.Size(84, 17);
            this.chkHidePlayers.TabIndex = 138;
            this.chkHidePlayers.Text = "Hide players";
            this.chkHidePlayers.UseVisualStyleBackColor = true;
            this.chkHidePlayers.CheckedChanged += new System.EventHandler(this.chkHidePlayers_CheckedChanged);
            // 
            // chkLag
            // 
            this.chkLag.AutoSize = true;
            this.chkLag.Location = new System.Drawing.Point(174, 82);
            this.chkLag.Name = "chkLag";
            this.chkLag.Size = new System.Drawing.Size(68, 17);
            this.chkLag.TabIndex = 137;
            this.chkLag.Text = "Lag killer";
            this.chkLag.UseVisualStyleBackColor = true;
            this.chkLag.CheckedChanged += new System.EventHandler(this.chkLag_CheckedChanged);
            // 
            // chkMagnet
            // 
            this.chkMagnet.AutoSize = true;
            this.chkMagnet.Location = new System.Drawing.Point(174, 59);
            this.chkMagnet.Name = "chkMagnet";
            this.chkMagnet.Size = new System.Drawing.Size(96, 17);
            this.chkMagnet.TabIndex = 136;
            this.chkMagnet.Text = "Enemy magnet";
            this.chkMagnet.UseVisualStyleBackColor = true;
            this.chkMagnet.CheckedChanged += new System.EventHandler(this.chkMagnet_CheckedChanged);
            // 
            // chkProvoke
            // 
            this.chkProvoke.AutoSize = true;
            this.chkProvoke.Location = new System.Drawing.Point(174, 36);
            this.chkProvoke.Name = "chkProvoke";
            this.chkProvoke.Size = new System.Drawing.Size(111, 17);
            this.chkProvoke.TabIndex = 135;
            this.chkProvoke.Text = "Provoke monsters";
            this.chkProvoke.UseVisualStyleBackColor = true;
            this.chkProvoke.CheckedChanged += new System.EventHandler(this.chkProvoke_CheckedChanged);
            // 
            // chkInfiniteRange
            // 
            this.chkInfiniteRange.AutoSize = true;
            this.chkInfiniteRange.Location = new System.Drawing.Point(174, 13);
            this.chkInfiniteRange.Name = "chkInfiniteRange";
            this.chkInfiniteRange.Size = new System.Drawing.Size(120, 17);
            this.chkInfiniteRange.TabIndex = 134;
            this.chkInfiniteRange.Text = "Infinite attack range";
            this.chkInfiniteRange.UseVisualStyleBackColor = true;
            this.chkInfiniteRange.CheckedChanged += new System.EventHandler(this.chkInfiniteRange_CheckedChanged);
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.cbServers);
            this.grpLogin.Controls.Add(this.chkRelogRetry);
            this.grpLogin.Controls.Add(this.chkRelog);
            this.grpLogin.Controls.Add(this.numRelogDelay);
            this.grpLogin.Controls.Add(this.label7);
            this.grpLogin.Location = new System.Drawing.Point(12, 12);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(156, 131);
            this.grpLogin.TabIndex = 133;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Auto relogin";
            // 
            // cbServers
            // 
            this.cbServers.FormattingEnabled = true;
            this.cbServers.Location = new System.Drawing.Point(6, 19);
            this.cbServers.Name = "cbServers";
            this.cbServers.Size = new System.Drawing.Size(143, 21);
            this.cbServers.TabIndex = 0;
            // 
            // chkRelogRetry
            // 
            this.chkRelogRetry.AutoSize = true;
            this.chkRelogRetry.Location = new System.Drawing.Point(6, 108);
            this.chkRelogRetry.Name = "chkRelogRetry";
            this.chkRelogRetry.Size = new System.Drawing.Size(143, 17);
            this.chkRelogRetry.TabIndex = 88;
            this.chkRelogRetry.Text = "Relog again if in battleon";
            this.chkRelogRetry.UseVisualStyleBackColor = true;
            // 
            // chkRelog
            // 
            this.chkRelog.AutoSize = true;
            this.chkRelog.Location = new System.Drawing.Point(6, 46);
            this.chkRelog.Name = "chkRelog";
            this.chkRelog.Size = new System.Drawing.Size(82, 17);
            this.chkRelog.TabIndex = 1;
            this.chkRelog.Text = "Auto relogin";
            this.chkRelog.UseVisualStyleBackColor = true;
            // 
            // numRelogDelay
            // 
            this.numRelogDelay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRelogDelay.Location = new System.Drawing.Point(6, 82);
            this.numRelogDelay.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numRelogDelay.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRelogDelay.Name = "numRelogDelay";
            this.numRelogDelay.Size = new System.Drawing.Size(54, 20);
            this.numRelogDelay.TabIndex = 86;
            this.numRelogDelay.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Delay before starting the bot";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 329);
            this.Controls.Add(this.chkEnableSettings);
            this.Controls.Add(this.chkDisableAnims);
            this.Controls.Add(this.txtSoundItem);
            this.Controls.Add(this.btnSoundAdd);
            this.Controls.Add(this.btnSoundDelete);
            this.Controls.Add(this.btnSoundClear);
            this.Controls.Add(this.btnSoundTest);
            this.Controls.Add(this.lstSoundItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numWalkSpeed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkSkipCutscenes);
            this.Controls.Add(this.chkHidePlayers);
            this.Controls.Add(this.chkLag);
            this.Controls.Add(this.chkMagnet);
            this.Controls.Add(this.chkProvoke);
            this.Controls.Add(this.chkInfiniteRange);
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWalkSpeed)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelogDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableSettings;
        private System.Windows.Forms.CheckBox chkDisableAnims;
        private System.Windows.Forms.TextBox txtSoundItem;
        private System.Windows.Forms.Button btnSoundAdd;
        private System.Windows.Forms.Button btnSoundDelete;
        private System.Windows.Forms.Button btnSoundClear;
        private System.Windows.Forms.Button btnSoundTest;
        private System.Windows.Forms.ListBox lstSoundItems;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numWalkSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSkipCutscenes;
        private System.Windows.Forms.CheckBox chkHidePlayers;
        private System.Windows.Forms.CheckBox chkLag;
        private System.Windows.Forms.CheckBox chkMagnet;
        private System.Windows.Forms.CheckBox chkProvoke;
        private System.Windows.Forms.CheckBox chkInfiniteRange;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.ComboBox cbServers;
        private System.Windows.Forms.CheckBox chkRelogRetry;
        private System.Windows.Forms.CheckBox chkRelog;
        private System.Windows.Forms.NumericUpDown numRelogDelay;
        private System.Windows.Forms.Label label7;
    }
}