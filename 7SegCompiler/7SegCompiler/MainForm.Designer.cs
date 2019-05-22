namespace _7SegCompiler {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.arduinoPort = new System.IO.Ports.SerialPort(this.components);
            this.portList = new System.Windows.Forms.ListBox();
            this.portRefreshButton = new System.Windows.Forms.Button();
            this.portConnectButton = new System.Windows.Forms.Button();
            this.digitCountSelect = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.digitCountSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // arduinoPort
            // 
            this.arduinoPort.BaudRate = 250000;
            this.arduinoPort.ReadBufferSize = 8200;
            this.arduinoPort.WriteBufferSize = 8200;
            // 
            // portList
            // 
            this.portList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portList.FormattingEnabled = true;
            this.portList.Location = new System.Drawing.Point(619, 12);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(145, 173);
            this.portList.TabIndex = 0;
            // 
            // portRefreshButton
            // 
            this.portRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.portRefreshButton.Location = new System.Drawing.Point(619, 191);
            this.portRefreshButton.Name = "portRefreshButton";
            this.portRefreshButton.Size = new System.Drawing.Size(145, 23);
            this.portRefreshButton.TabIndex = 1;
            this.portRefreshButton.Text = "Refresh";
            this.portRefreshButton.UseVisualStyleBackColor = true;
            this.portRefreshButton.Click += new System.EventHandler(this.portRefreshButton_Click);
            // 
            // portConnectButton
            // 
            this.portConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.portConnectButton.Location = new System.Drawing.Point(619, 220);
            this.portConnectButton.Name = "portConnectButton";
            this.portConnectButton.Size = new System.Drawing.Size(145, 23);
            this.portConnectButton.TabIndex = 2;
            this.portConnectButton.Text = "Connect";
            this.portConnectButton.UseVisualStyleBackColor = true;
            this.portConnectButton.Click += new System.EventHandler(this.portConnectButton_Click);
            // 
            // digitCountSelect
            // 
            this.digitCountSelect.Location = new System.Drawing.Point(54, 12);
            this.digitCountSelect.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.digitCountSelect.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.digitCountSelect.Name = "digitCountSelect";
            this.digitCountSelect.Size = new System.Drawing.Size(34, 20);
            this.digitCountSelect.TabIndex = 3;
            this.digitCountSelect.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 205);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Digits:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 254);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.digitCountSelect);
            this.Controls.Add(this.portConnectButton);
            this.Controls.Add(this.portRefreshButton);
            this.Controls.Add(this.portList);
            this.Name = "MainForm";
            this.Text = "7 Segment Compiler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.digitCountSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort arduinoPort;
        private System.Windows.Forms.ListBox portList;
        private System.Windows.Forms.Button portRefreshButton;
        private System.Windows.Forms.Button portConnectButton;
        private System.Windows.Forms.NumericUpDown digitCountSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}

