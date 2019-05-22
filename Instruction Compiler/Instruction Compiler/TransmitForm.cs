using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// using System.IO.Ports;
using System.Diagnostics;
using RJCP.IO.Ports;
using System.Threading;

namespace Instruction_Compiler
{
    public partial class TransmitForm : Form
    {
        private byte[] data = new byte[8192];
        private int seg = 0;
        private int state = 0;
        private SerialPortStream portStream;
        private byte[] oldData = new byte[8192];

        public TransmitForm()
        {
            InitializeComponent();
            port.NewLine = "\n";
            portStream = new SerialPortStream {
                BaudRate = 100000,
                DataBits = 8,
                NewLine = "\n",
                Parity = Parity.None,
                StopBits = StopBits.One,
                WriteBufferSize = 9000,
                ReadBufferSize = 9000,
                DiscardNull = false
            };
            portStream.DataReceived += port_DataReceived;
        }

        private void RefreshPorts()
        {
            portSelect.Items.Clear();
            portSelect.Items.Add("(none)");
            foreach (string name in SerialPortStream.GetPortNames()) portSelect.Items.Add(name);
        }

        private void TransmitForm_Load(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void portSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)portSelect.SelectedItem == "(none)") portStream.Close();
            else try
                {
                    portStream.PortName = (string)portSelect.SelectedItem;
                    portStream.Open();
                }
                catch
                {
                    portStream.Close();
                    RefreshPorts();
                }
            transmitButton.Enabled = portStream.IsOpen;
            if (portStream.IsOpen) statLabel.Text = "Connected to " + portStream.PortName;
            else statLabel.Text = "Not connected";
        }

        private void ReceiveError()
        {
            state = 0;
            seg = 0;
            progressBar.SetState(2);
            statLabel.Text = "Error writing chip";
            transmitButton.Enabled = true;
            chipSelect.Enabled = true;
            portSelect.Enabled = true;
        }

        private void transmitButton_Click(object sender, EventArgs e)
        {
            if (!portStream.IsOpen) return;
            progressBar.SetState(1);
            progressBar.Value = 0;
            statLabel.Text = "Reading existing data from chip...";
            transmitButton.Enabled = false;
            checkDiffButton.Enabled = false;
            chipSelect.Enabled = false;
            portSelect.Enabled = false;

            GenData();

            state = 4;
            seg = 0;
            portStream.ReceivedBytesThreshold = 8192;
            portStream.Write(new byte[] { 0, 0, 0, 0x20, 0 }, 0, 5);
        }

        private void GenData() {
            data = new byte[8192];
            int chip = (int)chipSelect.Value;
            for (int cond = 0; cond < 4; cond++) {
                for (int i = 0; i < 128; i++) {
                    var cmd = Program.codeCmds[i];
                    if (cmd == null) cmd = Program.codeCmds[0];

                    var variant = cmd.Variants.Find(c => c.Code == cond);
                    if (variant != null) cmd = variant;

                    for (int j = 0; j < 16; j++) {
                        int index = (cond << 11) | (i << 4) | j;     // top 2 bits are flags, then 7 opcode bits, then 4 step counter bits

                        var set = cmd.SignalSteps[j];

                        foreach (SignalState sig in set) {
                            if (sig.Signal.Chip == chip) data[index] |= sig.GetValueBits();
                        }
                    }
                }
            }
        }

        private delegate void VoidDel();

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch (state)
            {
                case 1:
                    int b = portStream.ReadByte();
                    //Debug.WriteLine("Received: " + b);
                    if (b == 0)
                    {
                        Invoke(new VoidDel(ReceiveError));
                        break;
                    }
                    if (seg > 8191)
                    {
                        state = 2;
                        seg = 0;
                        Invoke(new VoidDel(() => statLabel.Text = "Checking data correctness"));
                        portStream.ReceivedBytesThreshold = 8192;
                        portStream.Write(new byte[] { 0, 0, 0, 0x20, 0 }, 0, 5);
                        break;
                    }
                    Invoke(new VoidDel(() => progressBar.Value = seg));
                    if (data[seg] != oldData[seg]) {
                        portStream.Write(new byte[] { 1, (byte)(seg >> 8), (byte)seg, 0 }, 0, 4);
                        portStream.Write(data, seg, 1);
                        Debug.WriteLine("Written to address: " + seg);
                    } else {
                        portStream.Write(new byte[] { 3 }, 0, 1);
                        //Debug.WriteLine("Omitting address " + seg);
                    }
                    seg++;
                    break;
                case 2:
                    state = 0;
                    var buf = new byte[8192];
                    portStream.Read(buf, 0, 8192);
                    if (buf.SequenceEqual(data))
                    {
                        Invoke(new VoidDel(() => {
                            statLabel.Text = "Transmitted successfully";
                            progressBar.SetState(1);
                        }));
                    }
                    else
                    {
                        Invoke(new VoidDel(() => {
                            statLabel.Text = "Error: Received incorrect data";
                            progressBar.SetState(2);
                        }));
                    }
                    portStream.ReceivedBytesThreshold = 1;
                    Invoke(new VoidDel(() => {
                        transmitButton.Enabled = true;
                        chipSelect.Enabled = true;
                        portSelect.Enabled = true;
                        checkDiffButton.Enabled = true;
                    }));
                    break;
                case 3:
                    state = 0;
                    var dBuf = new byte[8192];
                    portStream.Read(dBuf, 0, 8192);
                    int diff = 0;
                    for (int i = 0; i < 8192; i++) {
                        if (dBuf[i] != data[i]) {
                            diff++;
                            Debug.WriteLine(Convert.ToString(i, 16) + ": " + Convert.ToString(data[i], 16) + ", old: " + Convert.ToString(dBuf[i], 16));
                        }
                    }
                    portStream.ReceivedBytesThreshold = 1;
                    Invoke(new VoidDel(() => {
                        statLabel.Text = "Data differs by " + diff + "/8192 bytes.";
                        transmitButton.Enabled = true;
                        chipSelect.Enabled = true;
                        portSelect.Enabled = true;
                        checkDiffButton.Enabled = true;
                    }));
                    break;
                case 4:
                    state = 1;
                    portStream.Read(oldData, 0, 8192);
                    portStream.ReceivedBytesThreshold = 1;
                    Invoke(new VoidDel(() => {
                        statLabel.Text = "Transmitting";
                    }));
                    portStream.Write(new byte[] { 2, 0 }, 0, 2);
                    break;
                default:
                    break;
            }
        }

        private void checkDiffButton_Click(object sender, EventArgs e) {
            if (!portStream.IsOpen) return;
            state = 3;
            transmitButton.Enabled = false;
            chipSelect.Enabled = false;
            portSelect.Enabled = false;
            checkDiffButton.Enabled = false;
            GenData();
            statLabel.Text = "Reading data from chip...";
            portStream.ReceivedBytesThreshold = 8192;
            portStream.Write(new byte[] { 0, 0, 0, 0x20, 0 }, 0, 5);
        }

        private void TransmitForm_FormClosing(object sender, FormClosingEventArgs e) {
            portStream.Close();
        }
    }
}
