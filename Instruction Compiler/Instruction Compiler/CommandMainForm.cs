using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace Instruction_Compiler
{
    public partial class CommandMainForm : Form
    {
        Command selectedCommand = Program.fetchCmd;

        private class LVComp : System.Collections.IComparer {
            public int Compare(object x, object y) {
                var xc = (Command)(x as ListViewItem).Tag;
                var yc = (Command)(y as ListViewItem).Tag;
                if (xc.Code > 0x7f) return -1;
                return xc.Code.CompareTo(yc.Code);
            }
        }

        public CommandMainForm()
        {
            InitializeComponent();
            commandView.ListViewItemSorter = new LVComp();
        }

        /*private void UpdateTable()
        {
            commandTable.SuspendLayout();
            int sigCount = Program.signals.Sum((a) => (a?.Count((e) => e != null)).GetValueOrDefault(0));
            commandTable.Controls.Clear();
            commandTable.ColumnCount = sigCount + 2;
            commandTable.ColumnStyles.Clear();
            commandTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            commandTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            commandTable.RowCount = Program.commands.Sum((c) => c?.Signals.Count()).GetValueOrDefault(0) + Program.loadCmd.Signals.Count + 1;
            commandTable.RowStyles.Clear();
            for (int i = 0; i < commandTable.RowCount; i++) commandTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            var nameLabel = new Label();
            nameLabel.Text = "Name";
            commandTable.Controls.Add(nameLabel, 1, 0);
            foreach (List<Signal> ch in Program.signals)
            {
                if (ch == null) continue;
                foreach (Signal sig in ch)
                {
                    commandTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, sig.GetType() == typeof(MultiplexedSignal) ? 60 : 40));
                    var label = new Label();
                    label.Text = sig.Name;
                    commandTable.Controls.Add(label, commandTable.ColumnStyles.Count - 1, 0);
                }
            }
            int nextRow = AddCommandToTable(Program.loadCmd, 1);
            foreach (Command cmd in Program.commands)
            {
                nextRow = AddCommandToTable(cmd, nextRow);
            }
            commandTable.ResumeLayout();
        }

        /// <returns>Next free row index</returns>
        private int AddCommandToTable(Command cmd, int startRow)
        {
            var rad = new RadioButton();
            rad.Text = "";
            rad.Tag = cmd;
            rad.CheckedChanged += radButton_CheckedChanged;
            if (startRow == 1) rad.Checked = true;
            commandTable.Controls.Add(rad, 0, startRow);
            var nameBox = new TextBox();
            nameBox.Tag = cmd;
            nameBox.Text = cmd.Name;
            nameBox.TextChanged += nameBox_TextChanged;
            commandTable.Controls.Add(nameBox, 1, startRow);
            for (int row = 0; row < cmd.Signals.Count; row++)
            {
                if (row > 0)
                {
                    var label = new Label();
                    label.Text = (row + 1).ToString();
                    commandTable.Controls.Add(label, 1, row + startRow);
                }
                int col = 2;
                foreach (List<Signal> ch in Program.signals)
                {
                    if (ch == null) continue;
                    foreach (Signal sig in ch)
                    {
                        if (sig == null) continue;
                        if (sig.GetType() == typeof(BasicSignal))
                        {
                            var cb = new CheckBox();
                            cb.Text = "";
                            cb.Tag = (cmd, row, sig.Name);
                            cb.Checked = cmd.Signals[row].Any((s) => s.SigName == sig.Name);
                            cb.CheckedChanged += checkBox_CheckedChanged;
                            commandTable.Controls.Add(cb, col, row + startRow);
                        }
                        else if (sig.GetType() == typeof(MultiplexedSignal))
                        {
                            var cb = new ComboBox();
                            cb.Text = "";
                            cb.Tag = (cmd, row, sig.Name);
                            cb.Items.Clear();
                            foreach (MultiSubSignal ss in ((MultiplexedSignal)sig).SubSignals) cb.Items.Add(ss.Name);
                            cb.SelectedIndex = (cmd.Signals[row].FirstOrDefault((s) => s.SigName == sig.Name)?.Value).GetValueOrDefault(0);
                            cb.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                            commandTable.Controls.Add(cb, col, row + startRow);
                        }
                        col++;
                    }
                };
            }
            return startRow + cmd.Signals.Count;
        }

        private void radButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked) selectedCommand = (Command)rb.Tag;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var cmd = (Command)tb.Tag;
            cmd.Name = tb.Text;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var id = ((Command, int, string))cb.Tag;
            var sig = Program.getSignal(id.Item3);
            if (sig == null || sig.GetType() != typeof(BasicSignal)) return;
            var step = id.Item1.Signals[id.Item2];
            if (cb.Checked) step.Add(new SignalState(id.Item3));
            else step.RemoveWhere((s) => s.SigName == id.Item3);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            var id = ((Command, int, string))cb.Tag;
            var sig = Program.getSignal(id.Item3);
            if (sig == null || sig.GetType() != typeof(MultiplexedSignal)) return;
            var step = id.Item1.Signals[id.Item2];
            if (cb.SelectedIndex == 0) step.RemoveWhere((s) => s.SigName == id.Item3);
            else if (step.Any((s) => s.SigName == id.Item3)) step.First((s) => s.SigName == id.Item3).Value = cb.SelectedIndex;
            else step.Add(new SignalState(id.Item3, cb.SelectedIndex));
        }*/

        public void UpdateList()
        {
            commandView.Items.Clear();
            AddCmdToList(Program.fetchCmd);
            foreach (Command cmd in Program.commands)
            {
                AddCmdToList(cmd);
            }
        }

        private void AddCmdToList(Command cmd)
        {
            var item = new ListViewItem(cmd.Name);
            item.SubItems.Add(cmd.Code < 128 ? "0x" + cmd.Code.ToString("X2") : "");
            for (int i = 0; i < 16; i++) {
                var sub = new ListViewItem.ListViewSubItem();
                foreach (SignalState sig in cmd.SignalSteps[i])
                {
                    if (sig.Value > 0 && sig.Signal.GetType() == typeof(MultiplexedSignal)) sub.Text += ((MultiplexedSignal)sig.Signal).SubSignals[sig.Value].Name + " ";
                    else if (sig.Signal.GetType() == typeof(BasicSignal)) sub.Text += sig.SigName + " ";
                }
                foreach (var v in cmd.Variants) {
                    if (v.SignalSteps[i].SequenceEqual(cmd.SignalSteps[i])) continue;
                    sub.Text += "| ";
                    foreach (SignalState varSig in v.SignalSteps[i]) {
                        if (varSig.Value > 0 && varSig.Signal.GetType() == typeof(MultiplexedSignal)) sub.Text += ((MultiplexedSignal)varSig.Signal).SubSignals[varSig.Value].Name + " ";
                        else if (varSig.Signal.GetType() == typeof(BasicSignal)) sub.Text += varSig.SigName + " ";
                    }
                }
                item.SubItems.Add(sub);
            }
            item.Tag = cmd;
            commandView.Items.Add(item);
        }

        private void controlSignalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SignalConfig().Show();
        }

        private void clearConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the entire signal configuration?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) Program.signals = new List<Signal>[10];
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configSaveDialog.ShowDialog() == DialogResult.Cancel) return;
            var sw = File.Create(configSaveDialog.FileName);
            Signal[][] sigs = new Signal[10][];
            for (int i = 0; i < 10; i++) sigs[i] = Program.signals[i]?.ToArray();
            Program.sigSer.Serialize(sw, sigs);
            sw.Close();
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configOpenDialog.ShowDialog() == DialogResult.Cancel) return;
            Program.LoadSignalConfig(configOpenDialog.FileName);
        }

        private void newCmdButton_Click(object sender, EventArgs e) {
            var cmd = new Command();
            cmd.InitEmpty();
            cmd.Code = (byte)Program.commands.Count;
            for (int i = 0; i < 16; i++) {
                var step = Program.fetchCmd.SignalSteps[i];
                if (step.Count > 0) cmd.SignalSteps[i].UnionWith(step);
                else if (Program.codeCmds[0] != null) cmd.SignalSteps[i].UnionWith(Program.codeCmds[0].SignalSteps[15]);
            }
            Program.commands.Add(cmd);
            //UpdateTable();
            new EditCommand(cmd).ShowDialog(this);
        }

        private void remCmdButton_Click(object sender, EventArgs e)
        {
            //if (Program.commands.Remove(selectedCommand)) UpdateTable();
            if (commandView.SelectedItems.Count > 0)
            {
                if (Program.commands.Remove((Command)commandView.SelectedItems[0].Tag)) UpdateList();
            }
            ScrollToLast();
        }

        /*private void addStepButton_Click(object sender, EventArgs e)
        {
            selectedCommand.Signals.Add(new HashSet<SignalState>());
            UpdateTable();
        }

        private void remStepButton_Click(object sender, EventArgs e)
        {
            if (selectedCommand.Signals.Count > 1)
            {
                selectedCommand.Signals.RemoveAt(selectedCommand.Signals.Count - 1);
                UpdateTable();
            }
        }*/

        private void MainForm_Load(object sender, EventArgs e)
        {
            //UpdateTable();
            UpdateList();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (commandView.SelectedItems.Count > 0)
            {
                new EditCommand((Command)commandView.SelectedItems[0].Tag).ShowDialog(this);
            }
        }

        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to start a new program?\r\nUnsaved changes to the current program will be lost!", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.commands = new List<Command>();
                Program.fetchCmd = new Command();
                Program.fetchCmd.InitEmpty();
            }
            UpdateList();
        }

        private void saveProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (programSaveDialog.ShowDialog() == DialogResult.Cancel) return;
            var sw = File.Create(programSaveDialog.FileName);
            var saveArr = new Command[Program.commands.Count + 1];
            saveArr[0] = Program.fetchCmd;
            Array.Copy(Program.commands.ToArray(), 0, saveArr, 1, Program.commands.Count);
            Program.cmdSer.Serialize(sw, saveArr);
            sw.Close();
        }

        private void loadProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (programOpenDialog.ShowDialog() == DialogResult.Cancel) return;
            Program.LoadMicrocodeProgram(programOpenDialog.FileName);
            UpdateList();
        }

        private void transmitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MicrocodeTransmitForm().ShowDialog();
        }

        private void dupCmdButton_Click(object sender, EventArgs e) {
            if (commandView.SelectedItems.Count == 0) return;
            var cmd = new Command((Command)commandView.SelectedItems[0].Tag, false);
            cmd.Code = (byte)Program.commands.Count;
            Program.commands.Add(cmd);
            UpdateList();
            ScrollToLast();
        }

        public void ScrollToLast() {
            commandView.Items[commandView.Items.Count - 1].EnsureVisible();
        }

        private void CommandMainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Program.UpdateCommandRegexes();
            (Owner as MainForm).UpdateHighlighting();
        }
    }
}
