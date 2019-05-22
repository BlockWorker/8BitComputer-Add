using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Instruction_Compiler {
    public partial class CommandVariants : Form {

        private readonly string[] varNames = { "", "LT", "GT", "(3)" };
        private Command parentCmd;

        public CommandVariants(Command command) {
            parentCmd = command;
            InitializeComponent();
            Text = "Variants of command " + parentCmd.Name;
        }

        public void UpdateList() {
            variantView.Items.Clear();
            foreach (Command cmd in parentCmd.Variants) {
                AddCmdToList(cmd);
            }
        }

        private void AddCmdToList(Command cmd) {
            var item = new ListViewItem(varNames[cmd.Code]);
            foreach (HashSet<SignalState> step in cmd.SignalSteps) {
                var sub = new ListViewItem.ListViewSubItem();
                foreach (SignalState sig in step) {
                    if (sig.Value > 0 && sig.Signal.GetType() == typeof(MultiplexedSignal)) sub.Text += ((MultiplexedSignal)sig.Signal).SubSignals[sig.Value].Name + " ";
                    else if (sig.Signal.GetType() == typeof(BasicSignal)) sub.Text += sig.SigName + " ";
                }
                item.SubItems.Add(sub);
            }
            item.Tag = cmd;
            variantView.Items.Add(item);
        }

        private void newButton_Click(object sender, EventArgs e) {
            if (parentCmd.Variants.Count >= 3) {
                newButton.Enabled = dupButton.Enabled = false;
                return;
            }
            var cmd = new Command(parentCmd, true);
            cmd.Code = (byte)(parentCmd.Variants.Count + 1);
            parentCmd.Variants.Add(cmd);
            newButton.Enabled = dupButton.Enabled = parentCmd.Variants.Count < 3;
            new EditCommand(cmd, parentCmd, true).ShowDialog(this);
        }

        private void removeButton_Click(object sender, EventArgs e) {
            if (variantView.SelectedItems.Count > 0) {
                if (parentCmd.Variants.Remove((Command)variantView.SelectedItems[0].Tag)) UpdateList();
            }
            newButton.Enabled = dupButton.Enabled = parentCmd.Variants.Count < 3;
        }

        private void editButton_Click(object sender, EventArgs e) {
            if (variantView.SelectedItems.Count > 0) {
                new EditCommand((Command)variantView.SelectedItems[0].Tag, parentCmd, true).ShowDialog(this);
            }
        }

        private void dupButton_Click(object sender, EventArgs e) {
            if (parentCmd.Variants.Count >= 3) {
                newButton.Enabled = dupButton.Enabled = false;
                return;
            }
            if (variantView.SelectedItems.Count == 0) return;
            var cmd = new Command((Command)variantView.SelectedItems[0].Tag, false);
            cmd.Code = (byte)(parentCmd.Variants.Count + 1);
            parentCmd.Variants.Add(cmd);
            newButton.Enabled = dupButton.Enabled = parentCmd.Variants.Count < 3;
            UpdateList();
        }

        private void CommandVariants_Load(object sender, EventArgs e) {
            UpdateList();
        }
    }
}
