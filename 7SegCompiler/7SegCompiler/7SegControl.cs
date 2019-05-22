using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7SegCompiler {
    public partial class _7SegControl : UserControl {
        private byte hexValue = 0;
        public byte HexValue { get { return hexValue; } set { hexValue = value; UpdateSegColors(); } }

        public _7SegControl() {
            InitializeComponent();
            segA.Tag = 0;
            segB.Tag = 1;
            segC.Tag = 2;
            segD.Tag = 3;
            segE.Tag = 4;
            segF.Tag = 5;
            segG.Tag = 6;
            segDP.Tag = 7;
        }

        private void RepositionSegs() {
            int mid = Height / 2;
            int horWidth = Width - 98;
            int verHeight = mid - 12;
            segA.Location = new Point(34, 10);
            segA.Width = horWidth;
            segB.Location = new Point(horWidth + 38, 10);
            segB.Height = verHeight;
            segC.Location = new Point(horWidth + 38, mid + 2);
            segC.Height = verHeight;
            segD.Location = new Point(34, Height - 30);
            segD.Width = horWidth;
            segE.Location = new Point(10, mid + 2);
            segE.Height = verHeight;
            segF.Location = new Point(10, 10);
            segF.Height = verHeight;
            segG.Location = new Point(34, mid - 10);
            segG.Width = horWidth;
            segDP.Location = new Point(Width - 30, Height - 30);
        }

        private void UpdateSegColors() {
            segA.BackColor = (hexValue & 0x01) > 0 ? Color.Red : Color.White;
            segB.BackColor = (hexValue & 0x02) > 0 ? Color.Red : Color.White;
            segC.BackColor = (hexValue & 0x04) > 0 ? Color.Red : Color.White;
            segD.BackColor = (hexValue & 0x08) > 0 ? Color.Red : Color.White;
            segE.BackColor = (hexValue & 0x10) > 0 ? Color.Red : Color.White;
            segF.BackColor = (hexValue & 0x20) > 0 ? Color.Red : Color.White;
            segG.BackColor = (hexValue & 0x40) > 0 ? Color.Red : Color.White;
            segDP.BackColor = (hexValue & 0x80) > 0 ? Color.Red : Color.White;
        }

        private void _7SegControl_Resize(object sender, EventArgs e) {
            RepositionSegs();
        }

        private void _7SegControl_Load(object sender, EventArgs e) {
            RepositionSegs();
        }

        private void SegClick(object sender, EventArgs e) {
            int index = (int)((Label)sender).Tag;
            hexValue ^= (byte)(1 << index);
            UpdateSegColors();
        }
    }
}
