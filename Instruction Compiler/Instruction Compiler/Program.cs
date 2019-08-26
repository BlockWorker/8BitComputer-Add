using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Instruction_Compiler
{
    static class Program
    {
        public static readonly XmlSerializer sigSer = new XmlSerializer(typeof(Signal[][]), new Type[] { typeof(BasicSignal), typeof(MultiplexedSignal) });
        public static readonly XmlSerializer cmdSer = new XmlSerializer(typeof(Command[]));

        public static List<Signal>[] signals = new List<Signal>[10];
        public static List<Command> commands = new List<Command>();
        public static Command fetchCmd = new Command();
        public static Command[] codeCmds = new Command[128];
        public static List<(Regex, Command)> regexCommands = new List<(Regex, Command)>();
        public static Regex cmdNameRegex = new Regex("(?!)", RegexOptions.Compiled);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fetchCmd.Name = "Fetch";
            fetchCmd.Code = 255;
            fetchCmd.InitEmpty();
            Application.Run(new MainForm());
        }

        public static Signal getSignal(string name)
        {
            foreach (List<Signal> sig in signals)
            {
                if (sig == null) continue;
                var found = sig.Find((s) => s.Name == name);
                if (found != null) return found;
            }
            return null;
        }

        public static void SetState(this ProgressBar bar, int state)
        {
            SendMessage(bar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        public static void LoadSignalConfig(string path) {
            if (!File.Exists(path)) return;
            var sr = File.OpenRead(path);
            if (!sigSer.CanDeserialize(XmlReader.Create(sr))) {
                sr.Close();
                return;
            }
            sr.Seek(0, SeekOrigin.Begin);
            var sigs = (Signal[][])sigSer.Deserialize(XmlReader.Create(sr));
            for (int i = 0; i < 10; i++) signals[i] = sigs[i] == null ? null : new List<Signal>(sigs[i]);
            sr.Close();
        }

        public static void LoadMicrocodeProgram(string fileName) {
            if (!File.Exists(fileName)) return;
            LoadSignalConfig(fileName.Replace(".mcp", ".sig"));
            var sr = File.OpenRead(fileName);
            if (!cmdSer.CanDeserialize(XmlReader.Create(sr))) {
                sr.Close();
                return;
            }
            sr.Seek(0, SeekOrigin.Begin);
            var saveArr = (Command[])cmdSer.Deserialize(sr);
            fetchCmd = saveArr[0];
            commands = new List<Command>();
            for (int i = 1; i < saveArr.Length; i++) {
                var item = saveArr[i];
                commands.Add(item);
                codeCmds[item.Code] = item;
            }
            sr.Close();
            UpdateCommandRegexes();
        }

        public static void UpdateCommandRegexes() {
            regexCommands.Clear();
            var nameRegexString = "(?:";
            foreach (var cmd in commands) {
                regexCommands.Add((cmd.CmdRegex, cmd));
                var space = cmd.Name.IndexOf(' ');
                nameRegexString += space >= 0 ? cmd.Name.Substring(0, space) : cmd.Name;
                nameRegexString += "|";
            }
            cmdNameRegex = new Regex(nameRegexString.TrimEnd('|') + ")", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}
