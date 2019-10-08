namespace Instruction_Compiler
{
    partial class MicrocodeTransmitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.portSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.transmitButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statLabel = new System.Windows.Forms.Label();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.chipSelect = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkDiffButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chipSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // portSelect
            // 
            this.portSelect.FormattingEnabled = true;
            this.portSelect.Items.AddRange(new object[] {
            "(none)"});
            this.portSelect.Location = new System.Drawing.Point(76, 14);
            this.portSelect.Name = "portSelect";
            this.portSelect.Size = new System.Drawing.Size(121, 21);
            this.portSelect.TabIndex = 0;
            this.portSelect.Text = "(none)";
            this.portSelect.SelectedIndexChanged += new System.EventHandler(this.portSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port:";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(203, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // transmitButton
            // 
            this.transmitButton.Enabled = false;
            this.transmitButton.Location = new System.Drawing.Point(12, 67);
            this.transmitButton.Name = "transmitButton";
            this.transmitButton.Size = new System.Drawing.Size(75, 23);
            this.transmitButton.TabIndex = 3;
            this.transmitButton.Text = "Transmit";
            this.transmitButton.UseVisualStyleBackColor = true;
            this.transmitButton.Click += new System.EventHandler(this.transmitButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(93, 67);
            this.progressBar.Maximum = 8192;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(185, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Location = new System.Drawing.Point(12, 97);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(78, 13);
            this.statLabel.TabIndex = 5;
            this.statLabel.Text = "Not connected";
            // 
            // port
            // 
            this.port.BaudRate = 250000;
            this.port.ReadBufferSize = 9000;
            // 
            // chipSelect
            // 
            this.chipSelect.Location = new System.Drawing.Point(77, 41);
            this.chipSelect.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.chipSelect.Name = "chipSelect";
            this.chipSelect.Size = new System.Drawing.Size(120, 20);
            this.chipSelect.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chip:";
            // 
            // checkDiffButton
            // 
            this.checkDiffButton.Location = new System.Drawing.Point(203, 38);
            this.checkDiffButton.Name = "checkDiffButton";
            this.checkDiffButton.Size = new System.Drawing.Size(75, 23);
            this.checkDiffButton.TabIndex = 8;
            this.checkDiffButton.Text = "Check Diff";
            this.checkDiffButton.UseVisualStyleBackColor = true;
            this.checkDiffButton.Click += new System.EventHandler(this.checkDiffButton_Click);
            // 
            // MicrocodeTransmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 119);
            this.Controls.Add(this.checkDiffButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chipSelect);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.transmitButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MicrocodeTransmitForm";
            this.Text = "Transmit Microcode Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransmitForm_FormClosing);
            this.Load += new System.EventHandler(this.TransmitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chipSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button transmitButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statLabel;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.NumericUpDown chipSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button checkDiffButton;
    }
}