using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grimoire.Botting.Commands.Map;
using Grimoire.Game;

namespace Grimoire.UI.BotForms
{
    public partial class MapTab : Form
    {
        public static MapTab Instance { get; } = new MapTab();

        private readonly Dictionary<string, string> _defaultText = new Dictionary<string, string>
        {
            {nameof(txtJoin), "battleon-1e99"}, {nameof(txtJoinCell), "Enter"}, {nameof(txtJoinPad), "Spawn"},
            {nameof(txtCell), "Cell"}, {nameof(txtPad), "Pad"}
        };

        private MapTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string map = txtJoin.Text,
                cell = string.IsNullOrEmpty(txtJoinCell.Text) ? "Enter" : txtJoinCell.Text,
                pad = string.IsNullOrEmpty(txtJoinPad.Text) ? "Spawn" : txtJoinPad.Text;
            if (map.Length > 0)
                BotManagerForm.Instance.AddCommand(new CmdJoin { Map = map, Cell = cell, Pad = pad });
        }

        private void btnCellSwap_Click(object sender, EventArgs e)
        {
            txtJoinCell.Text = txtCell.Text;
            txtJoinPad.Text = txtPad.Text;
        }

        private void btnCurrCell_Click(object sender, EventArgs e)
        {
            txtCell.Text = Player.Cell;
            txtPad.Text = Player.Pad;
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            string cell = string.IsNullOrEmpty(txtCell.Text) ? "Enter" : txtCell.Text,
                pad = string.IsNullOrEmpty(txtPad.Text) ? "Spawn" : txtPad.Text;
            BotManagerForm.Instance.AddCommand(new CmdMoveToCell { Cell = cell, Pad = pad });
        }

        private void btnWalk_Click(object sender, EventArgs e)
        {
            string x = numWalkX.Value.ToString(), y = numWalkY.Value.ToString();
            BotManagerForm.Instance.AddCommand(new CmdWalk { X = x, Y = y });
        }

        private void btnWalkCur_Click(object sender, EventArgs e)
        {
            float[] pos = Player.Position;
            numWalkX.Value = (decimal)pos[0];
            numWalkY.Value = (decimal)pos[1];
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
