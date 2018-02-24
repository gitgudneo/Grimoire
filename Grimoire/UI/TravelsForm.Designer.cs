namespace Grimoire.UI
{
    partial class TravelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelsForm));
            this.btnDage = new System.Windows.Forms.Button();
            this.btnEscherion = new System.Windows.Forms.Button();
            this.btnNulgath2 = new System.Windows.Forms.Button();
            this.btnNulgath = new System.Windows.Forms.Button();
            this.btnSwindle = new System.Windows.Forms.Button();
            this.btnTaro = new System.Windows.Forms.Button();
            this.btnTwins = new System.Windows.Forms.Button();
            this.btnTercess = new System.Windows.Forms.Button();
            this.grpTravel = new System.Windows.Forms.GroupBox();
            this.numPriv = new System.Windows.Forms.NumericUpDown();
            this.chkPriv = new System.Windows.Forms.CheckBox();
            this.grpTravel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDage
            // 
            this.btnDage.Location = new System.Drawing.Point(6, 247);
            this.btnDage.Name = "btnDage";
            this.btnDage.Size = new System.Drawing.Size(125, 23);
            this.btnDage.TabIndex = 0;
            this.btnDage.Text = "Dage";
            this.btnDage.UseVisualStyleBackColor = true;
            this.btnDage.Click += new System.EventHandler(this.btnDage_Click);
            // 
            // btnEscherion
            // 
            this.btnEscherion.Location = new System.Drawing.Point(6, 218);
            this.btnEscherion.Name = "btnEscherion";
            this.btnEscherion.Size = new System.Drawing.Size(125, 23);
            this.btnEscherion.TabIndex = 1;
            this.btnEscherion.Text = "Escherion";
            this.btnEscherion.UseVisualStyleBackColor = true;
            this.btnEscherion.Click += new System.EventHandler(this.btnEscherion_Click);
            // 
            // btnNulgath2
            // 
            this.btnNulgath2.Location = new System.Drawing.Point(6, 189);
            this.btnNulgath2.Name = "btnNulgath2";
            this.btnNulgath2.Size = new System.Drawing.Size(125, 23);
            this.btnNulgath2.TabIndex = 2;
            this.btnNulgath2.Text = "Nulgath 2 (tercess)";
            this.btnNulgath2.UseVisualStyleBackColor = true;
            this.btnNulgath2.Click += new System.EventHandler(this.btnNulgath2_Click);
            // 
            // btnNulgath
            // 
            this.btnNulgath.Location = new System.Drawing.Point(6, 160);
            this.btnNulgath.Name = "btnNulgath";
            this.btnNulgath.Size = new System.Drawing.Size(125, 23);
            this.btnNulgath.TabIndex = 3;
            this.btnNulgath.Text = "Nulgath (tercess)";
            this.btnNulgath.UseVisualStyleBackColor = true;
            this.btnNulgath.Click += new System.EventHandler(this.btnNulgath_Click);
            // 
            // btnSwindle
            // 
            this.btnSwindle.Location = new System.Drawing.Point(6, 131);
            this.btnSwindle.Name = "btnSwindle";
            this.btnSwindle.Size = new System.Drawing.Size(125, 23);
            this.btnSwindle.TabIndex = 4;
            this.btnSwindle.Text = "Swindle";
            this.btnSwindle.UseVisualStyleBackColor = true;
            this.btnSwindle.Click += new System.EventHandler(this.btnSwindle_Click);
            // 
            // btnTaro
            // 
            this.btnTaro.Location = new System.Drawing.Point(6, 102);
            this.btnTaro.Name = "btnTaro";
            this.btnTaro.Size = new System.Drawing.Size(125, 23);
            this.btnTaro.TabIndex = 5;
            this.btnTaro.Text = "Taro";
            this.btnTaro.UseVisualStyleBackColor = true;
            this.btnTaro.Click += new System.EventHandler(this.btnTaro_Click);
            // 
            // btnTwins
            // 
            this.btnTwins.Location = new System.Drawing.Point(6, 73);
            this.btnTwins.Name = "btnTwins";
            this.btnTwins.Size = new System.Drawing.Size(125, 23);
            this.btnTwins.TabIndex = 6;
            this.btnTwins.Text = "Twins";
            this.btnTwins.UseVisualStyleBackColor = true;
            this.btnTwins.Click += new System.EventHandler(this.btnTwins_Click);
            // 
            // btnTercess
            // 
            this.btnTercess.Location = new System.Drawing.Point(6, 44);
            this.btnTercess.Name = "btnTercess";
            this.btnTercess.Size = new System.Drawing.Size(125, 23);
            this.btnTercess.TabIndex = 7;
            this.btnTercess.Text = "Tercessuinotlim";
            this.btnTercess.UseVisualStyleBackColor = true;
            this.btnTercess.Click += new System.EventHandler(this.btnTercess_Click);
            // 
            // grpTravel
            // 
            this.grpTravel.Controls.Add(this.numPriv);
            this.grpTravel.Controls.Add(this.btnDage);
            this.grpTravel.Controls.Add(this.btnEscherion);
            this.grpTravel.Controls.Add(this.btnNulgath2);
            this.grpTravel.Controls.Add(this.btnNulgath);
            this.grpTravel.Controls.Add(this.btnSwindle);
            this.grpTravel.Controls.Add(this.btnTaro);
            this.grpTravel.Controls.Add(this.btnTwins);
            this.grpTravel.Controls.Add(this.btnTercess);
            this.grpTravel.Controls.Add(this.chkPriv);
            this.grpTravel.Location = new System.Drawing.Point(13, 13);
            this.grpTravel.Name = "grpTravel";
            this.grpTravel.Size = new System.Drawing.Size(138, 276);
            this.grpTravel.TabIndex = 8;
            this.grpTravel.TabStop = false;
            this.grpTravel.Text = "Fast travels";
            // 
            // numPriv
            // 
            this.numPriv.Enabled = false;
            this.numPriv.Location = new System.Drawing.Point(64, 18);
            this.numPriv.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPriv.Name = "numPriv";
            this.numPriv.Size = new System.Drawing.Size(67, 20);
            this.numPriv.TabIndex = 1;
            this.numPriv.Value = new decimal(new int[] {
            123456,
            0,
            0,
            0});
            // 
            // chkPriv
            // 
            this.chkPriv.AutoSize = true;
            this.chkPriv.Location = new System.Drawing.Point(6, 19);
            this.chkPriv.Name = "chkPriv";
            this.chkPriv.Size = new System.Drawing.Size(59, 17);
            this.chkPriv.TabIndex = 0;
            this.chkPriv.Text = "Private";
            this.chkPriv.UseVisualStyleBackColor = true;
            this.chkPriv.CheckedChanged += new System.EventHandler(this.chkPriv_CheckedChanged);
            // 
            // Travel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 298);
            this.Controls.Add(this.grpTravel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Travel";
            this.Text = "Fast travels";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Travel_FormClosing);
            this.grpTravel.ResumeLayout(false);
            this.grpTravel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDage;
        private System.Windows.Forms.Button btnEscherion;
        private System.Windows.Forms.Button btnNulgath2;
        private System.Windows.Forms.Button btnNulgath;
        private System.Windows.Forms.Button btnSwindle;
        private System.Windows.Forms.Button btnTaro;
        private System.Windows.Forms.Button btnTwins;
        private System.Windows.Forms.Button btnTercess;
        private System.Windows.Forms.GroupBox grpTravel;
        private System.Windows.Forms.NumericUpDown numPriv;
        private System.Windows.Forms.CheckBox chkPriv;
    }
}