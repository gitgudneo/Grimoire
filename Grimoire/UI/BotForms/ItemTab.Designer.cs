namespace Grimoire.UI.BotForms
{
    partial class ItemTab
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
            this.txtShopItem = new System.Windows.Forms.TextBox();
            this.numShopId = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnBoost = new System.Windows.Forms.Button();
            this.cbBoosts = new System.Windows.Forms.ComboBox();
            this.btnBBAdd = new System.Windows.Forms.Button();
            this.numBBCap = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBBItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numMapItem = new System.Windows.Forms.NumericUpDown();
            this.btnMapItem = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.txtSwapInv = new System.Windows.Forms.TextBox();
            this.txtSwapBank = new System.Windows.Forms.TextBox();
            this.chkReject = new System.Windows.Forms.CheckBox();
            this.chkPickup = new System.Windows.Forms.CheckBox();
            this.btnWhitelist = new System.Windows.Forms.Button();
            this.txtWhitelist = new System.Windows.Forms.TextBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cbItemCmds = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numShopId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBBCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShopItem
            // 
            this.txtShopItem.Location = new System.Drawing.Point(128, 232);
            this.txtShopItem.Name = "txtShopItem";
            this.txtShopItem.Size = new System.Drawing.Size(83, 20);
            this.txtShopItem.TabIndex = 64;
            this.txtShopItem.Text = "Item name";
            this.txtShopItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtShopItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // numShopId
            // 
            this.numShopId.Location = new System.Drawing.Point(128, 206);
            this.numShopId.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numShopId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShopId.Name = "numShopId";
            this.numShopId.Size = new System.Drawing.Size(83, 20);
            this.numShopId.TabIndex = 63;
            this.numShopId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(125, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 62;
            this.label15.Text = "Shop ID";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(128, 255);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(83, 23);
            this.btnBuy.TabIndex = 61;
            this.btnBuy.Text = "Buy item";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnBoost
            // 
            this.btnBoost.Location = new System.Drawing.Point(160, 151);
            this.btnBoost.Name = "btnBoost";
            this.btnBoost.Size = new System.Drawing.Size(157, 23);
            this.btnBoost.TabIndex = 60;
            this.btnBoost.Text = "Add boost";
            this.btnBoost.UseVisualStyleBackColor = true;
            this.btnBoost.Click += new System.EventHandler(this.btnBoost_Click);
            // 
            // cbBoosts
            // 
            this.cbBoosts.FormattingEnabled = true;
            this.cbBoosts.Location = new System.Drawing.Point(160, 125);
            this.cbBoosts.Name = "cbBoosts";
            this.cbBoosts.Size = new System.Drawing.Size(157, 21);
            this.cbBoosts.TabIndex = 59;
            this.cbBoosts.Click += new System.EventHandler(this.cbBoosts_Click);
            // 
            // btnBBAdd
            // 
            this.btnBBAdd.Location = new System.Drawing.Point(13, 255);
            this.btnBBAdd.Name = "btnBBAdd";
            this.btnBBAdd.Size = new System.Drawing.Size(93, 23);
            this.btnBBAdd.TabIndex = 58;
            this.btnBBAdd.Text = "Add command";
            this.btnBBAdd.UseVisualStyleBackColor = true;
            this.btnBBAdd.Click += new System.EventHandler(this.btnBBAdd_Click);
            // 
            // numBBCap
            // 
            this.numBBCap.Location = new System.Drawing.Point(68, 229);
            this.numBBCap.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numBBCap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBBCap.Name = "numBBCap";
            this.numBBCap.Size = new System.Drawing.Size(38, 20);
            this.numBBCap.TabIndex = 57;
            this.numBBCap.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Page cap";
            // 
            // txtBBItem
            // 
            this.txtBBItem.Location = new System.Drawing.Point(13, 203);
            this.txtBBItem.Name = "txtBBItem";
            this.txtBBItem.Size = new System.Drawing.Size(93, 20);
            this.txtBBItem.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "AC item buy back";
            // 
            // numMapItem
            // 
            this.numMapItem.Location = new System.Drawing.Point(236, 231);
            this.numMapItem.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMapItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMapItem.Name = "numMapItem";
            this.numMapItem.Size = new System.Drawing.Size(81, 20);
            this.numMapItem.TabIndex = 53;
            this.numMapItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnMapItem
            // 
            this.btnMapItem.Location = new System.Drawing.Point(236, 255);
            this.btnMapItem.Name = "btnMapItem";
            this.btnMapItem.Size = new System.Drawing.Size(81, 23);
            this.btnMapItem.TabIndex = 52;
            this.btnMapItem.Text = "Get map item";
            this.btnMapItem.UseVisualStyleBackColor = true;
            this.btnMapItem.Click += new System.EventHandler(this.btnMapItem_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(12, 151);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(133, 23);
            this.btnSwap.TabIndex = 51;
            this.btnSwap.Text = "Bank swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // txtSwapInv
            // 
            this.txtSwapInv.Location = new System.Drawing.Point(12, 125);
            this.txtSwapInv.Name = "txtSwapInv";
            this.txtSwapInv.Size = new System.Drawing.Size(133, 20);
            this.txtSwapInv.TabIndex = 50;
            this.txtSwapInv.Text = "Inventory item name";
            this.txtSwapInv.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSwapInv.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // txtSwapBank
            // 
            this.txtSwapBank.Location = new System.Drawing.Point(12, 98);
            this.txtSwapBank.Name = "txtSwapBank";
            this.txtSwapBank.Size = new System.Drawing.Size(133, 20);
            this.txtSwapBank.TabIndex = 49;
            this.txtSwapBank.Text = "Bank item name";
            this.txtSwapBank.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtSwapBank.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // chkReject
            // 
            this.chkReject.AutoSize = true;
            this.chkReject.Location = new System.Drawing.Point(160, 91);
            this.chkReject.Name = "chkReject";
            this.chkReject.Size = new System.Drawing.Size(157, 17);
            this.chkReject.TabIndex = 48;
            this.chkReject.Text = "Reject non-whitelisted items";
            this.chkReject.UseVisualStyleBackColor = true;
            // 
            // chkPickup
            // 
            this.chkPickup.AutoSize = true;
            this.chkPickup.Checked = true;
            this.chkPickup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPickup.Location = new System.Drawing.Point(160, 68);
            this.chkPickup.Name = "chkPickup";
            this.chkPickup.Size = new System.Drawing.Size(141, 17);
            this.chkPickup.TabIndex = 47;
            this.chkPickup.Text = "Pick up whitelisted items";
            this.chkPickup.UseVisualStyleBackColor = true;
            // 
            // btnWhitelist
            // 
            this.btnWhitelist.Location = new System.Drawing.Point(160, 39);
            this.btnWhitelist.Name = "btnWhitelist";
            this.btnWhitelist.Size = new System.Drawing.Size(133, 23);
            this.btnWhitelist.TabIndex = 46;
            this.btnWhitelist.Text = "Add to item whitelist";
            this.btnWhitelist.UseVisualStyleBackColor = true;
            this.btnWhitelist.Click += new System.EventHandler(this.btnWhitelist_Click);
            // 
            // txtWhitelist
            // 
            this.txtWhitelist.Location = new System.Drawing.Point(160, 13);
            this.txtWhitelist.Name = "txtWhitelist";
            this.txtWhitelist.Size = new System.Drawing.Size(133, 20);
            this.txtWhitelist.TabIndex = 45;
            this.txtWhitelist.Text = "Item name";
            this.txtWhitelist.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtWhitelist.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(12, 65);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(133, 23);
            this.btnItem.TabIndex = 44;
            this.btnItem.Text = "Add command";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(12, 39);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(133, 20);
            this.txtItem.TabIndex = 43;
            this.txtItem.Text = "Item name";
            this.txtItem.Enter += new System.EventHandler(this.TextboxEnter);
            this.txtItem.Leave += new System.EventHandler(this.TextboxLeave);
            // 
            // cbItemCmds
            // 
            this.cbItemCmds.FormattingEnabled = true;
            this.cbItemCmds.Items.AddRange(new object[] {
            "Get drop",
            "Sell",
            "Equip",
            "To bank from inv",
            "To inv from bank"});
            this.cbItemCmds.Location = new System.Drawing.Point(12, 12);
            this.cbItemCmds.Name = "cbItemCmds";
            this.cbItemCmds.Size = new System.Drawing.Size(133, 21);
            this.cbItemCmds.TabIndex = 42;
            // 
            // ItemTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 291);
            this.Controls.Add(this.txtShopItem);
            this.Controls.Add(this.numShopId);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnBoost);
            this.Controls.Add(this.cbBoosts);
            this.Controls.Add(this.btnBBAdd);
            this.Controls.Add(this.numBBCap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBBItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numMapItem);
            this.Controls.Add(this.btnMapItem);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.txtSwapInv);
            this.Controls.Add(this.txtSwapBank);
            this.Controls.Add(this.chkReject);
            this.Controls.Add(this.chkPickup);
            this.Controls.Add(this.btnWhitelist);
            this.Controls.Add(this.txtWhitelist);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.cbItemCmds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemTab";
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numShopId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBBCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShopItem;
        private System.Windows.Forms.NumericUpDown numShopId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnBoost;
        private System.Windows.Forms.ComboBox cbBoosts;
        private System.Windows.Forms.Button btnBBAdd;
        private System.Windows.Forms.NumericUpDown numBBCap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBBItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMapItem;
        private System.Windows.Forms.Button btnMapItem;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TextBox txtSwapInv;
        private System.Windows.Forms.TextBox txtSwapBank;
        private System.Windows.Forms.CheckBox chkReject;
        private System.Windows.Forms.CheckBox chkPickup;
        private System.Windows.Forms.Button btnWhitelist;
        private System.Windows.Forms.TextBox txtWhitelist;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ComboBox cbItemCmds;
    }
}