using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace _7SegCompiler {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            RefreshPorts();
        }

        private void RefreshPorts() {
            var ports = SerialPort.GetPortNames();
            if (ports.Length == 0) {
                MessageBox.Show("No serial ports found!");
            }
            portList.Items.Clear();
            portList.Items.AddRange(ports);
        }

        private void portRefreshButton_Click(object sender, EventArgs e) {
            RefreshPorts();
        }

        private void portConnectButton_Click(object sender, EventArgs e) {
            if (portList.SelectedIndex < 0) return;
            arduinoPort.Close();
            arduinoPort.PortName = (string)portList.SelectedItem;
            arduinoPort.Open();
        }
    }
}
