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
    public partial class EditSignal : Form
    {
        BasicSignal signal;

        public EditSignal(BasicSignal sig)
        {
            signal = sig;
            InitializeComponent();
            nameBox.Text = signal.Name;
            fullNameBox.Text = signal.FullName;
            bitSelect.Value = signal.Bit;
            invBox.Checked = signal.Inverted;
            bitLabel.Text = "(0x" + (1 << (int)bitSelect.Value).ToString("X2") + ")";
        }

        private void bitSelect_ValueChanged(object sender, EventArgs e)
        {
            bitLabel.Text = "(0x" + (1 << (int)bitSelect.Value).ToString("X2") + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signal.Name = nameBox.Text;
            signal.FullName = fullNameBox.Text;
            signal.Bit = (int)bitSelect.Value;
            signal.Inverted = invBox.Checked;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditSignal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((SignalConfig)Owner).UpdateList();
        }
    }
}
