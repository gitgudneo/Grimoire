namespace Grimoire.UI
{
    partial class PacketTamperer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketTamperer));
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.btnToServer = new System.Windows.Forms.Button();
            this.chkFromClient = new System.Windows.Forms.CheckBox();
            this.chkFromServer = new System.Windows.Forms.CheckBox();
            this.btnToClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(13, 13);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(536, 69);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.Location = new System.Drawing.Point(13, 117);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(536, 239);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            // 
            // btnToServer
            // 
            this.btnToServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToServer.Location = new System.Drawing.Point(465, 88);
            this.btnToServer.Name = "btnToServer";
            this.btnToServer.Size = new System.Drawing.Size(84, 23);
            this.btnToServer.TabIndex = 3;
            this.btnToServer.Text = "Send to server";
            this.btnToServer.UseVisualStyleBackColor = true;
            this.btnToServer.Click += new System.EventHandler(this.btnToServer_Click);
            // 
            // chkFromClient
            // 
            this.chkFromClient.AutoSize = true;
            this.chkFromClient.Location = new System.Drawing.Point(137, 94);
            this.chkFromClient.Name = "chkFromClient";
            this.chkFromClient.Size = new System.Drawing.Size(114, 17);
            this.chkFromClient.TabIndex = 4;
            this.chkFromClient.Text = "Capture from client";
            this.chkFromClient.UseVisualStyleBackColor = true;
            this.chkFromClient.CheckedChanged += new System.EventHandler(this.chkFromClient_CheckedChanged);
            // 
            // chkFromServer
            // 
            this.chkFromServer.AutoSize = true;
            this.chkFromServer.Location = new System.Drawing.Point(13, 94);
            this.chkFromServer.Name = "chkFromServer";
            this.chkFromServer.Size = new System.Drawing.Size(118, 17);
            this.chkFromServer.TabIndex = 5;
            this.chkFromServer.Text = "Capture from server";
            this.chkFromServer.UseVisualStyleBackColor = true;
            this.chkFromServer.CheckedChanged += new System.EventHandler(this.chkFromServer_CheckedChanged);
            // 
            // btnToClient
            // 
            this.btnToClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToClient.Location = new System.Drawing.Point(375, 88);
            this.btnToClient.Name = "btnToClient";
            this.btnToClient.Size = new System.Drawing.Size(84, 23);
            this.btnToClient.TabIndex = 6;
            this.btnToClient.Text = "Send to client";
            this.btnToClient.UseVisualStyleBackColor = true;
            this.btnToClient.Click += new System.EventHandler(this.btnToClient_Click);
            // 
            // PacketTamperer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 368);
            this.Controls.Add(this.btnToClient);
            this.Controls.Add(this.chkFromServer);
            this.Controls.Add(this.chkFromClient);
            this.Controls.Add(this.btnToServer);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PacketTamperer";
            this.Text = "Packet Tamperer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketTamperer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Button btnToServer;
        private System.Windows.Forms.CheckBox chkFromClient;
        private System.Windows.Forms.CheckBox chkFromServer;
        private System.Windows.Forms.Button btnToClient;
    }
}