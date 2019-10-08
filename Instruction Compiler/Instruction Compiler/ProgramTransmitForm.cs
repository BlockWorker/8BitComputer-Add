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
    public partial class ProgramTransmitForm : Form
    {
        private int state = 0;
        private SerialPortStream portStream;
        private int[] data;
        private int dataIndex = 0;
        private int dataAddr = 0;

        public ProgramTransmitForm()
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
            dataIndex = 0;
            dataAddr = 0;
            progressBar.SetState(2);
            statLabel.Text = "Error writing program";
            transmitButton.Enabled = true;
            portSelect.Enabled = true;
        }

        private void transmitButton_Click(object sender, EventArgs e)
        {
            if (!portStream.IsOpen) return;
            progressBar.SetState(1);
            progressBar.Value = 0;
            statLabel.Text = "Writing program...";
            transmitButton.Enabled = false;
            portSelect.Enabled = false;

            data = (Owner as MainForm).Compile();
            if (data == null || data.Length == 0) {
                statLabel.Text = "Compilation failed";
                return;
            }

            state = 1;
            dataIndex = 0;
            dataAddr = 0;
            progressBar.Maximum = data.Length;
            portStream.Write(new byte[] { 1 }, 0, 1);
        }

        private delegate void VoidDel();

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch (state)
            {
                case 1:
                    int b = portStream.ReadByte();
                    if (b == 0)
                    {
                        Invoke(new VoidDel(ReceiveError));
                        break;
                    }
                    if (dataIndex >= data.Length)
                    {
                        state = 0;
                        dataIndex = 0;
                        Invoke(new VoidDel(() => {
                            statLabel.Text = "Program transmitted";
                            progressBar.SetState(1);
                        }));
                        break;
                    }
                    Invoke(new VoidDel(() => progressBar.Value = dataIndex));
                    var value = data[dataIndex++];
                    if (value > 0xff) {
                        dataAddr = value & 0x7fff;
                        portStream.Write(new byte[] { 1 }, 0, 1);
                    } else {
                        portStream.Write(new byte[] { 0, (byte)(dataAddr >> 8), (byte)dataAddr++, 0, (byte)value }, 0, 5);
                        Debug.WriteLine("Written to address: " + Convert.ToString(dataAddr, 16));
                    }
                    break;
                default:
                    break;
            }
        }

        private void TransmitForm_FormClosing(object sender, FormClosingEventArgs e) {
            portStream.Close();
        }
    }
}
