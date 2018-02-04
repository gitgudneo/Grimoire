namespace ExamplePacketPlugin
{
    partial class Main
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
            this.txtMap = new System.Windows.Forms.TextBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtMap
            // 
            this.txtMap.Location = new System.Drawing.Point(12, 48);
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(240, 20);
            this.txtMap.TabIndex = 1;
            this.txtMap.Text = "yulgar-123456";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 12);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(240, 30);
            this.chkEnable.TabIndex = 2;
            this.chkEnable.Text = "When a join packet is sent to the server, \r\nintercept the packet and join this ma" +
    "p instead";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 82);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.txtMap);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.CheckBox chkEnable;
    }
}