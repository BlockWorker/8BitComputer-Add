using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace Instruction_Compiler {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private string fileName = "";
        private static readonly Regex numberRegex = new Regex(@"(?<=[ \[])(?:[0-9A-F]{2})+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex commentRegex = new Regex(@"#.*$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex commentOnlyRegex = new Regex(@"^\s*#.*$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex registerRegex = new Regex(@"(?:A|B|C|P|S|V|ZL|ZH|Z)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex instCommandRegex = new Regex("^\\s*\\.INST \"(.*)\"\\s*(?:#.*)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex addrCommandRegex = new Regex(@"^\s*\.ADDR ([0-9A-F]{4})\s*(?:#.*)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex dataCommandRegex = new Regex(@"^\s*\.DATA ((?:[0-9A-F]{2} *)+)\s*(?:#.*)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex keywordRegex = new Regex(@"(?:\.INST|\.ADDR|\.DATA)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Style blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private static readonly Style greenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        private static readonly Style grayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private static readonly Style redStyle = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);
        private static readonly Style yellowStyle = new TextStyle(Brushes.Goldenrod, null, FontStyle.Regular);
        private static readonly Style errorStyle = new WavyLineStyle(255, Color.Red);

        public void UpdateHighlighting() {
            codeBox.Range.ClearStyle(blueStyle, greenStyle, grayStyle, redStyle, yellowStyle, errorStyle);
            codeBox.Range.SetStyle(grayStyle, commentRegex); //comments
            codeBox.Range.SetStyle(yellowStyle, keywordRegex); //keywords
            codeBox.Range.SetStyle(blueStyle, Program.cmdNameRegex); //command names
            codeBox.Range.SetStyle(greenStyle, numberRegex); //numbers
            codeBox.Range.SetStyle(redStyle, registerRegex); //registers
            codeBox.LineNumberValues.Clear();
            int currAddr = 0;
            for (int i = 0; i < codeBox.LinesCount; i++) {
                var line = codeBox.Lines[i];
                var lRange = codeBox.GetLine(i);
                if (currAddr < 0) {
                    codeBox.LineNumberValues.Add(currAddr);
                    continue;
                }
                bool found = false;
                if (commentOnlyRegex.IsMatch(line)) {
                    codeBox.LineNumberValues.Add(-1);
                    found = true;
                } else if (instCommandRegex.IsMatch(line)) {
                    lRange.ClearStyle(blueStyle, greenStyle, redStyle);
                    codeBox.LineNumberValues.Add(-1);
                    found = true;
                    if (i > 0) {
                        lRange.SetStyle(errorStyle);
                    } else if (fileName != "") {
                        var match = instCommandRegex.Match(line);
                        var relPath = match.Groups[1].Value;
                        var dir = fileName.Substring(0, fileName.LastIndexOf('\\') + 1);
                        var fullPath = dir + relPath;
                        if (!File.Exists(fullPath)) lRange.SetStyle(errorStyle);
                    }
                } else if (addrCommandRegex.IsMatch(line)) {
                    var match = addrCommandRegex.Match(line);
                    currAddr = int.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
                    codeBox.LineNumberValues.Add(-1);
                    found = true;
                } else if (dataCommandRegex.IsMatch(line)) {
                    var match = dataCommandRegex.Match(line);
                    var dataStr = match.Groups[1].Value.Replace(" ", "");
                    codeBox.LineNumberValues.Add(currAddr);
                    currAddr += dataStr.Length / 2;
                    found = true;
                } else foreach (var (regex, cmd) in Program.regexCommands) {
                        if (regex.IsMatch(line)) {
                            codeBox.LineNumberValues.Add(currAddr);
                            currAddr += cmd.ByteLength;
                            found = true;
                            break;
                        }
                    }
                if (!found) {
                    codeBox.LineNumberValues.Add(currAddr);
                    currAddr = -1;
                    lRange.ClearStyle(redStyle);
                    lRange.SetStyle(errorStyle);
                }
            }
            codeBox.LineNumberValues.Add(currAddr);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fileName != "") {
                if (MessageBox.Show("All unsaved changes will be discarded. Create a new file anyway?", "New file", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            codeBox.Text = "";
            fileName = "";
            Text = "8BitCPU Compiler";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fileName == "") SaveAs();
            else File.WriteAllText(fileName, codeBox.Text);
            UpdateHighlighting();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveAs();
            UpdateHighlighting();
        }

        private void SaveAs() {
            if (progSaveDialog.ShowDialog() == DialogResult.Cancel) return;
            File.WriteAllText(progSaveDialog.FileName, codeBox.Text);
            fileName = progSaveDialog.FileName;
            Text = "8BitCPU Compiler - " + fileName.Substring(fileName.LastIndexOf('\\') + 1);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (progOpenDialog.ShowDialog() == DialogResult.Cancel) return;
            if (fileName != "") {
                if (MessageBox.Show("All unsaved changes will be discarded. Open file anyway?", "Open file", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            codeBox.Text = File.ReadAllText(progOpenDialog.FileName);
            fileName = progOpenDialog.FileName;
            var firstLine = codeBox.Lines[0];
            if (instCommandRegex.IsMatch(firstLine)) {
                var match = instCommandRegex.Match(firstLine);
                var relPath = match.Groups[1].Value;
                var dir = fileName.Substring(0, fileName.LastIndexOf('\\') + 1);
                var fullPath = dir + relPath;
                Program.LoadMicrocodeProgram(fullPath);
            }

            UpdateHighlighting();
            Text = "8BitCPU Compiler - " + fileName.Substring(fileName.LastIndexOf('\\') + 1);
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e) {
            new CommandMainForm().ShowDialog(this);
        }

        private void codeBox_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            UpdateHighlighting();
        }
    }
}
