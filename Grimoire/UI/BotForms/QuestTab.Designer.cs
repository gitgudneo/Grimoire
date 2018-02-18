namespace Grimoire.UI.BotForms
{
    partial class QuestTab
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
            this.btnQuestAccept = new System.Windows.Forms.Button();
            this.btnQuestComplete = new System.Windows.Forms.Button();
            this.btnQuestAdd = new System.Windows.Forms.Button();
            this.numQuestItem = new System.Windows.Forms.NumericUpDown();
            this.chkQuestItem = new System.Windows.Forms.CheckBox();
            this.numQuestID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuestAccept
            // 
            this.btnQuestAccept.Location = new System.Drawing.Point(15, 109);
            this.btnQuestAccept.Name = "btnQuestAccept";
            this.btnQuestAccept.Size = new System.Drawing.Size(112, 23);
            this.btnQuestAccept.TabIndex = 20;
            this.btnQuestAccept.Text = "Accept command";
            this.btnQuestAccept.UseVisualStyleBackColor = true;
            this.btnQuestAccept.Click += new System.EventHandler(this.btnQuestAccept_Click);
            // 
            // btnQuestComplete
            // 
            this.btnQuestComplete.Location = new System.Drawing.Point(15, 80);
            this.btnQuestComplete.Name = "btnQuestComplete";
            this.btnQuestComplete.Size = new System.Drawing.Size(112, 23);
            this.btnQuestComplete.TabIndex = 19;
            this.btnQuestComplete.Text = "Complete command";
            this.btnQuestComplete.UseVisualStyleBackColor = true;
            this.btnQuestComplete.Click += new System.EventHandler(this.btnQuestComplete_Click);
            // 
            // btnQuestAdd
            // 
            this.btnQuestAdd.Location = new System.Drawing.Point(15, 51);
            this.btnQuestAdd.Name = "btnQuestAdd";
            this.btnQuestAdd.Size = new System.Drawing.Size(112, 23);
            this.btnQuestAdd.TabIndex = 18;
            this.btnQuestAdd.Text = "Add to quest list";
            this.btnQuestAdd.UseVisualStyleBackColor = true;
            this.btnQuestAdd.Click += new System.EventHandler(this.btnQuestAdd_Click);
            // 
            // numQuestItem
            // 
            this.numQuestItem.Enabled = false;
            this.numQuestItem.Location = new System.Drawing.Point(137, 25);
            this.numQuestItem.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuestItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestItem.Name = "numQuestItem";
            this.numQuestItem.Size = new System.Drawing.Size(112, 20);
            this.numQuestItem.TabIndex = 17;
            this.numQuestItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkQuestItem
            // 
            this.chkQuestItem.AutoSize = true;
            this.chkQuestItem.Location = new System.Drawing.Point(137, 9);
            this.chkQuestItem.Name = "chkQuestItem";
            this.chkQuestItem.Size = new System.Drawing.Size(60, 17);
            this.chkQuestItem.TabIndex = 16;
            this.chkQuestItem.Text = "Item ID";
            this.chkQuestItem.UseVisualStyleBackColor = true;
            this.chkQuestItem.CheckedChanged += new System.EventHandler(this.chkQuestItem_CheckedChanged);
            // 
            // numQuestID
            // 
            this.numQuestID.Location = new System.Drawing.Point(15, 25);
            this.numQuestID.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuestID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestID.Name = "numQuestID";
            this.numQuestID.Size = new System.Drawing.Size(112, 20);
            this.numQuestID.TabIndex = 15;
            this.numQuestID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Quest ID";
            // 
            // Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 146);
            this.Controls.Add(this.btnQuestAccept);
            this.Controls.Add(this.btnQuestComplete);
            this.Controls.Add(this.btnQuestAdd);
            this.Controls.Add(this.numQuestItem);
            this.Controls.Add(this.chkQuestItem);
            this.Controls.Add(this.numQuestID);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quest";
            this.Text = "Quest";
            ((System.ComponentModel.ISupportInitialize)(this.numQuestItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuestAccept;
        private System.Windows.Forms.Button btnQuestComplete;
        private System.Windows.Forms.Button btnQuestAdd;
        private System.Windows.Forms.NumericUpDown numQuestItem;
        private System.Windows.Forms.CheckBox chkQuestItem;
        private System.Windows.Forms.NumericUpDown numQuestID;
        private System.Windows.Forms.Label label4;
    }
}