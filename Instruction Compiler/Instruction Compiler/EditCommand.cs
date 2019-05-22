using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Instruction_Compiler {
    public partial class EditCommand : Form {
        private Command cmd;
        private int step = 0;
        private bool varMode;
        private Command parentCmd = null;

        public EditCommand(Command command, Command parent = null, bool variantMode = false) {
            cmd = command;
            varMode = variantMode;
            InitializeComponent();
            if (varMode) {
                parentCmd = parent;
                codeSelect.Visible = false;
                varBox.Visible = true;
                codeVarLabel.Text = "Variant:";
                varButton.Visible = false;
                nameBox.Enabled = false;
            }
        }

        private void UpdateList() {
            basicSigView.Items.Clear();
            multSigView.Controls.Clear();
            multSigView.RowCount = 1;
            multSigView.RowStyles.Clear();
            multSigView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            var label1 = new Label();
            label1.Text = "Name";
            var label2 = new Label();
            label2.Text = "Value";
            multSigView.Controls.Add(label1, 0, 0);
            multSigView.Controls.Add(label2, 1, 0);
            int nextRow = 1;
            foreach (List<Signal> ch in Program.signals) {
                if (ch == null) continue;
                foreach (Signal sig in ch) {
                    if (sig == null) continue;
                    if (sig is BasicSignal) {
                        basicSigView.Items.Add(sig.Name);
                        basicSigView.SetItemChecked(basicSigView.Items.Count - 1, cmd.SignalSteps[step].Any((s) => s.SigName == sig.Name));
                    } else if (sig is MultiplexedSignal) {
                        var label = new Label();
                        label.Text = sig.Name;
                        multSigView.Controls.Add(label, 0, nextRow);
                        var cb = new ComboBox();
                        cb.Text = "";
                        cb.Tag = (cmd, sig.Name);
                        cb.Items.Clear();
                        foreach (MultiSubSignal ss in ((MultiplexedSignal)sig).SubSignals) cb.Items.Add(ss.Name);
                        cb.SelectedIndex = (cmd.SignalSteps[step].FirstOrDefault((s) => s.SigName == sig.Name)?.Value).GetValueOrDefault(0);
                        cb.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                        multSigView.Controls.Add(cb, 1, nextRow++);
                    }
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            var cb = (ComboBox)sender;
            var id = ((Command, string))cb.Tag;
            var sig = Program.getSignal(id.Item2);
            if (sig == null || !(sig is MultiplexedSignal)) return;
            var stepSigs = id.Item1.SignalSteps[step];
            if (cb.SelectedIndex == 0) stepSigs.RemoveWhere((s) => s.SigName == id.Item2);
            else if (stepSigs.Any((s) => s.SigName == id.Item2)) stepSigs.First((s) => s.SigName == id.Item2).Value = cb.SelectedIndex;
            else stepSigs.Add(new SignalState(id.Item2, cb.SelectedIndex));
        }

        private void EditCommand_Load(object sender, EventArgs e) {
            UpdateList();
            if (!varMode) nameBox.Text = cmd.Name;
            if (cmd.Code > 0x7f) codeSelect.Enabled = false;
            else codeSelect.Value = cmd.Code;
            if (varMode) varBox.SelectedIndex = cmd.Code - 1;
        }

        private void stepSelect_ValueChanged(object sender, EventArgs e) {
            step = (int)stepSelect.Value - 1;
            UpdateList();
        }

        private void basicSigView_ItemCheck(object sender, ItemCheckEventArgs e) {
            var sig = Program.getSignal((string)basicSigView.Items[e.Index]);
            if (sig == null || sig.GetType() != typeof(BasicSignal)) return;
            if (e.NewValue == CheckState.Unchecked) cmd.SignalSteps[step].RemoveWhere((s) => s.SigName == sig.Name);
            else if (!cmd.SignalSteps[step].Any((s) => s.SigName == sig.Name)) {
                e.NewValue = CheckState.Checked;
                cmd.SignalSteps[step].Add(new SignalState((BasicSignal)sig));
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (!varMode) cmd.Name = nameBox.Text;
            byte code = (byte)codeSelect.Value;
            if (varMode) {
                if (parentCmd.Variants.Exists(c => c.Code == cmd.Code && c != cmd)) {
                    MessageBox.Show("This variant already exists for the command " + parentCmd.Name + ".");
                    return;
                }
            } else if (cmd.Code == code || cmd.Code > 0x7f) {
                //no action required
            } else if (Program.codeCmds[code] != null) {
                MessageBox.Show("There is already a command with the code 0x" + code.ToString("X2") + ". Please choose a different code.");
                return;
            } else {
                Program.codeCmds[cmd.Code] = null;
                cmd.Code = code;
                Program.codeCmds[code] = cmd;
            }
            Close();
            if (varMode) {
                ((CommandVariants)Owner).UpdateList();
            } else {
                ((MainForm)Owner).UpdateList();
                ((MainForm)Owner).ScrollToLast();
            }
        }

        private void varBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (varMode && varBox.SelectedIndex >= 0) cmd.Code = (byte)(varBox.SelectedIndex + 1);
        }

        private void varButton_Click(object sender, EventArgs e) {
            if (!varMode) new CommandVariants(cmd).ShowDialog(this);
        }
    }
}
