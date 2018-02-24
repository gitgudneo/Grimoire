using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Item;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.UI.BotForms
{
    public partial class ItemTab : Form
    {
        public static ItemTab Instance { get; } = new ItemTab();

        public bool Pickup
        {
            get => chkPickup.Checked;
            set => chkPickup.Checked = value;
        }

        public bool Reject
        {
            get => chkReject.Checked;
            set => chkReject.Checked = value;
        }

        private readonly Dictionary<string, string> _defaultText = new Dictionary<string, string>
        {
            {nameof(txtItem), "Item name"}, {nameof(txtSwapBank), "Bank item name"},
            {nameof(txtSwapInv), "Inventory item name"}, {nameof(txtWhitelist), "Item name"},
            {nameof(txtShopItem), "Item name"}
        };

        private ItemTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void Item_Load(object sender, EventArgs e)
        {
            cbBoosts.DisplayMember = "Name";
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            if (item.Length > 0 && cbItemCmds.SelectedIndex > -1)
            {
                IBotCommand cmd;

                switch (cbItemCmds.SelectedIndex)
                {
                    case 1: cmd = new CmdSell { ItemName = item };
                        break;
                    case 2: cmd = new CmdEquip { ItemName = item };
                        break;
                    case 3: cmd = new CmdBankTransfer { ItemName = item, TransferFromBank = false };
                        break;
                    case 4: cmd = new CmdBankTransfer { ItemName = item, TransferFromBank = true };
                        break;
                    default: cmd = new CmdGetDrop { ItemName = item };
                        break;
                }
                BotManagerForm.Instance.AddCommand(cmd);
            }
        }

        private void btnMapItem_Click(object sender, EventArgs e)
        {
            BotManagerForm.Instance.AddCommand(new CmdMapItem { ItemId = (int)numMapItem.Value });
        }

        private void btnBBAdd_Click(object sender, EventArgs e)
        {
            string item = txtBBItem.Text;
            if (item.Length > 0)
                BotManagerForm.Instance.AddCommand(
                    new CmdBuyBack { ItemName = item, PageNumberCap = (int)numBBCap.Value });
        }

        private void btnWhitelist_Click(object sender, EventArgs e)
        {
            string item = txtWhitelist.Text;
            if (item.Length > 0)
                BotManagerForm.Instance.AddWhitelistedItem(item);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string bank = txtSwapBank.Text, inv = txtSwapInv.Text;
            if (bank.Length > 0 && inv.Length > 0)
            {
                BotManagerForm.Instance.AddCommand(new CmdBankSwap
                {
                    InventoryItemName = inv,
                    BankItemName = bank
                });
            }
        }

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (cbBoosts.SelectedIndex > -1)
                BotManagerForm.Instance.AddBoost((InventoryItem)cbBoosts.SelectedItem);
        }

        private void cbBoosts_Click(object sender, EventArgs e)
        {
            cbBoosts.Items.Clear();
            cbBoosts.Items.AddRange(Player.Inventory.Items.Where(i => i.Category == "ServerUse").ToArray());
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtShopItem.TextLength > 0)
                BotManagerForm.Instance.AddCommand(new CmdBuy { ItemName = txtShopItem.Text, ShopId = (int)numShopId.Value });
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (_defaultText[t.Name] == t.Text)
                t.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (string.IsNullOrEmpty(t.Text))
                t.Text = _defaultText[t.Name];
        }
    }
}
