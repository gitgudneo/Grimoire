namespace Grimoire.UI.BotForms
{
    partial class CombatTab
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
            this.chkSafeMp = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKill = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.chkExistQuest = new System.Windows.Forms.CheckBox();
            this.numRestMP = new System.Windows.Forms.NumericUpDown();
            this.chkMP = new System.Windows.Forms.CheckBox();
            this.numRest = new System.Windows.Forms.NumericUpDown();
            this.chkHP = new System.Windows.Forms.CheckBox();
            this.numSkillD = new System.Windows.Forms.NumericUpDown();
            this.btnRestF = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numSafe = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSafe = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.numSkill = new System.Windows.Forms.NumericUpDown();
            this.chkExitRest = new System.Windows.Forms.CheckBox();
            this.chkSkillCD = new System.Windows.Forms.CheckBox();
            this.txtKillFQ = new System.Windows.Forms.TextBox();
            this.txtKillFItem = new System.Windows.Forms.TextBox();
            this.txtKillFMon = new System.Windows.Forms.TextBox();
            this.rbTemp = new System.Windows.Forms.RadioButton();
            this.rbItems = new System.Windows.Forms.RadioButton();
            this.btnKillF = new System.Windows.Forms.Button();
            this.txtMonster = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRestMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSafeMp
            // 
            this.chkSafeMp.AutoSize = true;
            this.chkSafeMp.Location = new System.Drawing.Point(233, 71);
            this.chkSafeMp.Name = "chkSafeMp";
            this.chkSafeMp.Size = new System.Drawing.Size(42, 17);
            this.chkSafeMp.TabIndex = 87;
            this.chkSafeMp.Text = "MP";
            this.chkSafeMp.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(276, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 86;
            this.label12.Text = "Rest if";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(365, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(365, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 84;
            this.label10.Text = "%";
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(12, 38);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(144, 23);
            this.btnKill.TabIndex = 83;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(173, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 82;
            this.label13.Text = "Skill delay";
            // 
            // chkExistQuest
            // 
            this.chkExistQuest.AutoSize = true;
            this.chkExistQuest.Checked = true;
            this.chkExistQuest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExistQuest.Location = new System.Drawing.Point(183, 214);
            this.chkExistQuest.Name = "chkExistQuest";
            this.chkExistQuest.Size = new System.Drawing.Size(197, 17);
            this.chkExistQuest.TabIndex = 81;
            this.chkExistQuest.Text = "Exit combat before completing quest";
            this.chkExistQuest.UseVisualStyleBackColor = true;
            // 
            // numRestMP
            // 
            this.numRestMP.Location = new System.Drawing.Point(279, 172);
            this.numRestMP.Name = "numRestMP";
            this.numRestMP.Size = new System.Drawing.Size(84, 20);
            this.numRestMP.TabIndex = 80;
            this.numRestMP.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkMP
            // 
            this.chkMP.AutoSize = true;
            this.chkMP.Location = new System.Drawing.Point(276, 149);
            this.chkMP.Name = "chkMP";
            this.chkMP.Size = new System.Drawing.Size(97, 17);
            this.chkMP.TabIndex = 79;
            this.chkMP.Text = "MP is less than";
            this.chkMP.UseVisualStyleBackColor = true;
            // 
            // numRest
            // 
            this.numRest.Location = new System.Drawing.Point(279, 123);
            this.numRest.Name = "numRest";
            this.numRest.Size = new System.Drawing.Size(84, 20);
            this.numRest.TabIndex = 78;
            this.numRest.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkHP
            // 
            this.chkHP.AutoSize = true;
            this.chkHP.Location = new System.Drawing.Point(276, 100);
            this.chkHP.Name = "chkHP";
            this.chkHP.Size = new System.Drawing.Size(96, 17);
            this.chkHP.TabIndex = 77;
            this.chkHP.Text = "HP is less than";
            this.chkHP.UseVisualStyleBackColor = true;
            // 
            // numSkillD
            // 
            this.numSkillD.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSkillD.Location = new System.Drawing.Point(164, 181);
            this.numSkillD.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numSkillD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSkillD.Name = "numSkillD";
            this.numSkillD.Size = new System.Drawing.Size(79, 20);
            this.numSkillD.TabIndex = 76;
            this.numSkillD.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnRestF
            // 
            this.btnRestF.Location = new System.Drawing.Point(276, 42);
            this.btnRestF.Name = "btnRestF";
            this.btnRestF.Size = new System.Drawing.Size(79, 23);
            this.btnRestF.TabIndex = 75;
            this.btnRestF.Text = "Rest fully";
            this.btnRestF.UseVisualStyleBackColor = true;
            this.btnRestF.Click += new System.EventHandler(this.btnRestF_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(276, 13);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(79, 23);
            this.btnRest.TabIndex = 74;
            this.btnRest.Text = "Rest";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "%";
            // 
            // numSafe
            // 
            this.numSafe.Location = new System.Drawing.Point(175, 136);
            this.numSafe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSafe.Name = "numSafe";
            this.numSafe.Size = new System.Drawing.Size(40, 20);
            this.numSafe.TabIndex = 72;
            this.numSafe.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 39);
            this.label1.TabIndex = 71;
            this.label1.Text = "Use safe skill\r\nwhen HP is\r\nless than";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddSafe
            // 
            this.btnAddSafe.Location = new System.Drawing.Point(164, 67);
            this.btnAddSafe.Name = "btnAddSafe";
            this.btnAddSafe.Size = new System.Drawing.Size(63, 23);
            this.btnAddSafe.TabIndex = 70;
            this.btnAddSafe.Text = "Safe skill";
            this.btnAddSafe.UseVisualStyleBackColor = true;
            this.btnAddSafe.Click += new System.EventHandler(this.btnAddSafe_Click);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(164, 38);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(75, 23);
            this.btnAddSkill.TabIndex = 69;
            this.btnAddSkill.Text = "Add skill";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // numSkill
            // 
            this.numSkill.Location = new System.Drawing.Point(164, 13);
            this.numSkill.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSkill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSkill.Name = "numSkill";
            this.numSkill.Size = new System.Drawing.Size(75, 20);
            this.numSkill.TabIndex = 68;
            this.numSkill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkExitRest
            // 
            this.chkExitRest.AutoSize = true;
            this.chkExitRest.Checked = true;
            this.chkExitRest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExitRest.Location = new System.Drawing.Point(12, 250);
            this.chkExitRest.Name = "chkExitRest";
            this.chkExitRest.Size = new System.Drawing.Size(148, 17);
            this.chkExitRest.TabIndex = 67;
            this.chkExitRest.Text = "Exit combat before resting";
            this.chkExitRest.UseVisualStyleBackColor = true;
            // 
            // chkSkillCD
            // 
            this.chkSkillCD.AutoSize = true;
            this.chkSkillCD.Location = new System.Drawing.Point(12, 214);
            this.chkSkillCD.Name = "chkSkillCD";
            this.chkSkillCD.Size = new System.Drawing.Size(165, 30);
            this.chkSkillCD.TabIndex = 66;
            this.chkSkillCD.Text = "Wait for all skills to cool down\r\nbefore attacking";
            this.chkSkillCD.UseVisualStyleBackColor = true;
            // 
            // txtKillFQ
            // 
            this.txtKillFQ.Location = new System.Drawing.Point(12, 180);
            this.txtKillFQ.Name = "txtKillFQ";
            this.txtKillFQ.Size = new System.Drawing.Size(144, 20);
            this.txtKillFQ.TabIndex = 65;
            this.txtKillFQ.Text = "Quantity (* = any)";
            this.txtKillFQ.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFQ.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtKillFItem
            // 
            this.txtKillFItem.Location = new System.Drawing.Point(11, 154);
            this.txtKillFItem.Name = "txtKillFItem";
            this.txtKillFItem.Size = new System.Drawing.Size(144, 20);
            this.txtKillFItem.TabIndex = 64;
            this.txtKillFItem.Text = "Item name";
            this.txtKillFItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtKillFMon
            // 
            this.txtKillFMon.Location = new System.Drawing.Point(12, 128);
            this.txtKillFMon.Name = "txtKillFMon";
            this.txtKillFMon.Size = new System.Drawing.Size(144, 20);
            this.txtKillFMon.TabIndex = 63;
            this.txtKillFMon.Text = "Monster (* = random)";
            this.txtKillFMon.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtKillFMon.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // rbTemp
            // 
            this.rbTemp.AutoSize = true;
            this.rbTemp.Location = new System.Drawing.Point(68, 105);
            this.rbTemp.Name = "rbTemp";
            this.rbTemp.Size = new System.Drawing.Size(79, 17);
            this.rbTemp.TabIndex = 62;
            this.rbTemp.Text = "Temp items";
            this.rbTemp.UseVisualStyleBackColor = true;
            // 
            // rbItems
            // 
            this.rbItems.AutoSize = true;
            this.rbItems.Checked = true;
            this.rbItems.Location = new System.Drawing.Point(12, 105);
            this.rbItems.Name = "rbItems";
            this.rbItems.Size = new System.Drawing.Size(50, 17);
            this.rbItems.TabIndex = 61;
            this.rbItems.TabStop = true;
            this.rbItems.Text = "Items";
            this.rbItems.UseVisualStyleBackColor = true;
            // 
            // btnKillF
            // 
            this.btnKillF.Location = new System.Drawing.Point(12, 76);
            this.btnKillF.Name = "btnKillF";
            this.btnKillF.Size = new System.Drawing.Size(144, 23);
            this.btnKillF.TabIndex = 60;
            this.btnKillF.Text = "Kill for...";
            this.btnKillF.UseVisualStyleBackColor = true;
            this.btnKillF.Click += new System.EventHandler(this.btnKillF_Click);
            // 
            // txtMonster
            // 
            this.txtMonster.Location = new System.Drawing.Point(12, 12);
            this.txtMonster.Name = "txtMonster";
            this.txtMonster.Size = new System.Drawing.Size(144, 20);
            this.txtMonster.TabIndex = 59;
            this.txtMonster.Text = "Monster (*  = random)";
            this.txtMonster.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtMonster.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // CombatTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 289);
            this.Controls.Add(this.chkSafeMp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chkExistQuest);
            this.Controls.Add(this.numRestMP);
            this.Controls.Add(this.chkMP);
            this.Controls.Add(this.numRest);
            this.Controls.Add(this.chkHP);
            this.Controls.Add(this.numSkillD);
            this.Controls.Add(this.btnRestF);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numSafe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSafe);
            this.Controls.Add(this.btnAddSkill);
            this.Controls.Add(this.numSkill);
            this.Controls.Add(this.chkExitRest);
            this.Controls.Add(this.chkSkillCD);
            this.Controls.Add(this.txtKillFQ);
            this.Controls.Add(this.txtKillFItem);
            this.Controls.Add(this.txtKillFMon);
            this.Controls.Add(this.rbTemp);
            this.Controls.Add(this.rbItems);
            this.Controls.Add(this.btnKillF);
            this.Controls.Add(this.txtMonster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CombatTab";
            this.Text = "Combat";
            ((System.ComponentModel.ISupportInitialize)(this.numRestMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkillD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSafeMp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkExistQuest;
        private System.Windows.Forms.NumericUpDown numRestMP;
        private System.Windows.Forms.CheckBox chkMP;
        private System.Windows.Forms.NumericUpDown numRest;
        private System.Windows.Forms.CheckBox chkHP;
        private System.Windows.Forms.NumericUpDown numSkillD;
        private System.Windows.Forms.Button btnRestF;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSafe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSafe;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.NumericUpDown numSkill;
        private System.Windows.Forms.CheckBox chkExitRest;
        private System.Windows.Forms.CheckBox chkSkillCD;
        private System.Windows.Forms.TextBox txtKillFQ;
        private System.Windows.Forms.TextBox txtKillFItem;
        private System.Windows.Forms.TextBox txtKillFMon;
        private System.Windows.Forms.RadioButton rbTemp;
        private System.Windows.Forms.RadioButton rbItems;
        private System.Windows.Forms.Button btnKillF;
        private System.Windows.Forms.TextBox txtMonster;
    }
}