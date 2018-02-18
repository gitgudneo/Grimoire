namespace Grimoire.UI.BotForms
{
    partial class MapTab
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
            this.btnWalkCur = new System.Windows.Forms.Button();
            this.btnWalk = new System.Windows.Forms.Button();
            this.numWalkY = new System.Windows.Forms.NumericUpDown();
            this.numWalkX = new System.Windows.Forms.NumericUpDown();
            this.btnCellSwap = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnCurrCell = new System.Windows.Forms.Button();
            this.txtPad = new System.Windows.Forms.TextBox();
            this.txtCell = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtJoinPad = new System.Windows.Forms.TextBox();
            this.txtJoinCell = new System.Windows.Forms.TextBox();
            this.txtJoin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWalkCur
            // 
            this.btnWalkCur.Location = new System.Drawing.Point(133, 177);
            this.btnWalkCur.Name = "btnWalkCur";
            this.btnWalkCur.Size = new System.Drawing.Size(92, 23);
            this.btnWalkCur.TabIndex = 51;
            this.btnWalkCur.Text = "Current position";
            this.btnWalkCur.UseVisualStyleBackColor = true;
            this.btnWalkCur.Click += new System.EventHandler(this.btnWalkCur_Click);
            // 
            // btnWalk
            // 
            this.btnWalk.Location = new System.Drawing.Point(133, 148);
            this.btnWalk.Name = "btnWalk";
            this.btnWalk.Size = new System.Drawing.Size(92, 23);
            this.btnWalk.TabIndex = 50;
            this.btnWalk.Text = "Walk to";
            this.btnWalk.UseVisualStyleBackColor = true;
            this.btnWalk.Click += new System.EventHandler(this.btnWalk_Click);
            // 
            // numWalkY
            // 
            this.numWalkY.Location = new System.Drawing.Point(133, 122);
            this.numWalkY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numWalkY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkY.Name = "numWalkY";
            this.numWalkY.Size = new System.Drawing.Size(92, 20);
            this.numWalkY.TabIndex = 49;
            this.numWalkY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numWalkX
            // 
            this.numWalkX.Location = new System.Drawing.Point(133, 96);
            this.numWalkX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numWalkX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWalkX.Name = "numWalkX";
            this.numWalkX.Size = new System.Drawing.Size(92, 20);
            this.numWalkX.TabIndex = 48;
            this.numWalkX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCellSwap
            // 
            this.btnCellSwap.Location = new System.Drawing.Point(167, 36);
            this.btnCellSwap.Name = "btnCellSwap";
            this.btnCellSwap.Size = new System.Drawing.Size(24, 23);
            this.btnCellSwap.TabIndex = 47;
            this.btnCellSwap.Text = "<";
            this.btnCellSwap.UseVisualStyleBackColor = true;
            this.btnCellSwap.Click += new System.EventHandler(this.btnCellSwap_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(217, 64);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(130, 23);
            this.btnJump.TabIndex = 46;
            this.btnJump.Text = "Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnCurrCell
            // 
            this.btnCurrCell.Location = new System.Drawing.Point(217, 38);
            this.btnCurrCell.Name = "btnCurrCell";
            this.btnCurrCell.Size = new System.Drawing.Size(130, 23);
            this.btnCurrCell.TabIndex = 45;
            this.btnCurrCell.Text = "Get current cell";
            this.btnCurrCell.UseVisualStyleBackColor = true;
            this.btnCurrCell.Click += new System.EventHandler(this.btnCurrCell_Click);
            // 
            // txtPad
            // 
            this.txtPad.Location = new System.Drawing.Point(285, 12);
            this.txtPad.Name = "txtPad";
            this.txtPad.Size = new System.Drawing.Size(62, 20);
            this.txtPad.TabIndex = 44;
            this.txtPad.Text = "Pad";
            this.txtPad.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtPad.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtCell
            // 
            this.txtCell.Location = new System.Drawing.Point(217, 12);
            this.txtCell.Name = "txtCell";
            this.txtCell.Size = new System.Drawing.Size(62, 20);
            this.txtCell.TabIndex = 43;
            this.txtCell.Text = "Cell";
            this.txtCell.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtCell.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(12, 64);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(130, 23);
            this.btnJoin.TabIndex = 42;
            this.btnJoin.Text = "Join map";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtJoinPad
            // 
            this.txtJoinPad.Location = new System.Drawing.Point(80, 38);
            this.txtJoinPad.Name = "txtJoinPad";
            this.txtJoinPad.Size = new System.Drawing.Size(62, 20);
            this.txtJoinPad.TabIndex = 41;
            this.txtJoinPad.Text = "Spawn";
            this.txtJoinPad.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtJoinPad.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtJoinCell
            // 
            this.txtJoinCell.Location = new System.Drawing.Point(12, 38);
            this.txtJoinCell.Name = "txtJoinCell";
            this.txtJoinCell.Size = new System.Drawing.Size(62, 20);
            this.txtJoinCell.TabIndex = 40;
            this.txtJoinCell.Text = "Enter";
            this.txtJoinCell.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtJoinCell.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtJoin
            // 
            this.txtJoin.Location = new System.Drawing.Point(12, 12);
            this.txtJoin.Name = "txtJoin";
            this.txtJoin.Size = new System.Drawing.Size(130, 20);
            this.txtJoin.TabIndex = 39;
            this.txtJoin.Text = "battleon-1e99";
            this.txtJoin.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtJoin.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // MapTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 213);
            this.Controls.Add(this.btnWalkCur);
            this.Controls.Add(this.btnWalk);
            this.Controls.Add(this.numWalkY);
            this.Controls.Add(this.numWalkX);
            this.Controls.Add(this.btnCellSwap);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.btnCurrCell);
            this.Controls.Add(this.txtPad);
            this.Controls.Add(this.txtCell);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtJoinPad);
            this.Controls.Add(this.txtJoinCell);
            this.Controls.Add(this.txtJoin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapTab";
            this.Text = "Map";
            ((System.ComponentModel.ISupportInitialize)(this.numWalkY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWalkX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWalkCur;
        private System.Windows.Forms.Button btnWalk;
        private System.Windows.Forms.NumericUpDown numWalkY;
        private System.Windows.Forms.NumericUpDown numWalkX;
        private System.Windows.Forms.Button btnCellSwap;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button btnCurrCell;
        private System.Windows.Forms.TextBox txtPad;
        private System.Windows.Forms.TextBox txtCell;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtJoinPad;
        private System.Windows.Forms.TextBox txtJoinCell;
        private System.Windows.Forms.TextBox txtJoin;
    }
}