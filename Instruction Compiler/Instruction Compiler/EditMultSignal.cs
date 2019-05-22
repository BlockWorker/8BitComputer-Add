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
    public partial class EditMultSignal : Form
    {
        MultiplexedSignal signal;

        public EditMultSignal(MultiplexedSignal sig)
        {
            signal = sig;
            InitializeComponent();
            bitSelect.Value = signal.Bits;
            offsetSelect.Value = signal.Offset;
            nameBox.Text = signal.SubSignals[0].Name;
            fullNameBox.Text = signal.SubSignals[0].FullName;
            multNameBox.Text = signal.Name;
            UpdateList();
        }

        private void UpdateList()
        {
            sigList.Items.Clear();
            for (int i = 0; i < signal.SubSignals.Length; i++)
            {
                int bits = i << signal.Offset;
                sigList.Items.Add(new ListViewItem(new string[] { i.ToString(), "0x" + bits.ToString("X2"), signal.SubSignals[i].Name, signal.SubSignals[i].FullName }));
            }
        }

        private void bitSelect_ValueChanged(object sender, EventArgs e)
        {
            offsetSelect.Maximum = 8 - bitSelect.Value;
            offsetSelect.Enabled = offsetSelect.Maximum > 0;
            signalSelect.Maximum = (1 << (int)bitSelect.Value) - 1;
            signal.Bits = (int)bitSelect.Value;
            UpdateList();
        }

        private void offsetSelect_ValueChanged(object sender, EventArgs e)
        {
            signal.Offset = (int)offsetSelect.Value;
            UpdateList();
        }

        private void signalSelect_ValueChanged(object sender, EventArgs e)
        {
            nameBox.Text = signal.SubSignals[(int)signalSelect.Value].Name;
            fullNameBox.Text = signal.SubSignals[(int)signalSelect.Value].FullName;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            signal.SubSignals[(int)signalSelect.Value].Name = nameBox.Text;
            signal.SubSignals[(int)signalSelect.Value].FullName = fullNameBox.Text;
            UpdateList();
        }

        private void EditMultSignal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((SignalConfig)Owner).UpdateList();
        }

        private void nameAppButton_Click(object sender, EventArgs e)
        {
            signal.Name = multNameBox.Text;
        }
    }
}
