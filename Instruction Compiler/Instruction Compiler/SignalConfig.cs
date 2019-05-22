using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instruction_Compiler
{
    public partial class SignalConfig : Form
    {
        private int chip = 0;

        public SignalConfig()
        {
            InitializeComponent();
        }

        public void UpdateList()
        {
            signalView.Items.Clear();
            if (Program.signals[chip] == null) return;
            foreach (Signal sig in Program.signals[chip])
            {
                if (sig == null) continue;
                if (sig.GetType() == typeof(BasicSignal))
                {
                    var bsig = (BasicSignal)sig;
                    var item = new ListViewItem(new string[] { bsig.Bit.ToString(), sig.Name, sig.FullName, bsig.GetBits().ToString("X2"), bsig.Inverted ? "✓" : "" });
                    item.Tag = sig;
                    signalView.Items.Add(item);
                }
                else if (sig.GetType() == typeof(MultiplexedSignal))
                {
                    var msig = (MultiplexedSignal)sig;
                    var item = new ListViewItem(new string[] { msig.Offset + "-" + (msig.Offset + msig.Bits - 1), sig.Name, sig.FullName, msig.GetBits().ToString("X2"), "" });
                    item.Tag = sig;
                    signalView.Items.Add(item);
                    foreach (var sub in msig.SubSignals)
                    {
                        var subitem = new ListViewItem(new string[] { "(mult)", sub.Name, sub.FullName, "(" + sub.GetBits().ToString("X2") + ")", "" });
                        subitem.Tag = sig;
                        signalView.Items.Add(subitem);
                    }
                }
            }
        }

        private void SignalConfig_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void chipSelect_ValueChanged(object sender, EventArgs e)
        {
            chip = (int)chipSelect.Value;
            UpdateList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Program.signals[chip] == null) Program.signals[chip] = new List<Signal>();
            var sig = new BasicSignal();
            sig.Chip = chip;
            Program.signals[chip].Add(sig);
            new EditSignal(sig).ShowDialog(this);
        }

        private void mulButton_Click(object sender, EventArgs e)
        {
            if (Program.signals[chip] == null) Program.signals[chip] = new List<Signal>();
            var sig = new MultiplexedSignal();
            sig.Chip = chip;
            Program.signals[chip].Add(sig);
            new EditMultSignal(sig).ShowDialog(this);
        }

        private void remButton_Click(object sender, EventArgs e)
        {
            if (Program.signals[chip] == null) return;
            foreach (ListViewItem item in signalView.SelectedItems) Program.signals[chip].Remove((Signal)item.Tag);
            if (Program.signals[chip].Count == 0) Program.signals[chip] = null;
            UpdateList();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (signalView.SelectedItems.Count == 0 || Program.signals[chip] == null) return;
            var sig = signalView.SelectedItems[0].Tag;
            if (sig.GetType() == typeof(BasicSignal)) new EditSignal((BasicSignal)sig).ShowDialog(this);
            else if (sig.GetType() == typeof(MultiplexedSignal)) new EditMultSignal((MultiplexedSignal)sig).ShowDialog(this);
        }
    }
}
