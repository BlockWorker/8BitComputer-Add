using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Instruction_Compiler
{
    static class Program
    {
        public static List<Signal>[] signals = new List<Signal>[10];
        public static List<Command> commands = new List<Command>();
        public static Command fetchCmd = new Command();
        public static Command[] codeCmds = new Command[128];

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
    }
}
