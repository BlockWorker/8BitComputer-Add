namespace Instruction_Compiler
{
    partial class EditMultSignal
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
            this.bitSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.signalSelect = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.fullNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.offsetSelect = new System.Windows.Forms.NumericUpDown();
            this.sigList = new System.Windows.Forms.ListView();
            this.numCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bitCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.multNameBox = new System.Windows.Forms.TextBox();
            this.nameAppButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bitSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalSelect)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // bitSelect
            // 
            this.bitSelect.Location = new System.Drawing.Point(53, 20);
            this.bitSelect.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.bitSelect.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.bitSelect.Name = "bitSelect";
            this.bitSelect.Size = new System.Drawing.Size(28, 20);
            this.bitSelect.TabIndex = 1;
            this.bitSelect.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.bitSelect.ValueChanged += new System.EventHandler(this.bitSelect_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bits:";
            // 
            // signalSelect
            // 
            this.signalSelect.Location = new System.Drawing.Point(71, 19);
            this.signalSelect.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.signalSelect.Name = "signalSelect";
            this.signalSelect.Size = new System.Drawing.Size(40, 20);
            this.signalSelect.TabIndex = 3;
            this.signalSelect.ValueChanged += new System.EventHandler(this.signalSelect_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Signal No.:";
            // 
            // fullNameBox
            // 
            this.fullNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullNameBox.Location = new System.Drawing.Point(186, 43);
            this.fullNameBox.Name = "fullNameBox";
            this.fullNameBox.Size = new System.Drawing.Size(202, 20);
            this.fullNameBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Full Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(186, 18);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(202, 20);
            this.nameBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.applyButton);
            this.groupBox1.Controls.Add(this.signalSelect);
            this.groupBox1.Controls.Add(this.fullNameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(87, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 75);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signal properties";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(9, 41);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(102, 23);
            this.applyButton.TabIndex = 10;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Offset:";
            // 
            // offsetSelect
            // 
            this.offsetSelect.Location = new System.Drawing.Point(53, 46);
            this.offsetSelect.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.offsetSelect.Name = "offsetSelect";
            this.offsetSelect.Size = new System.Drawing.Size(28, 20);
            this.offsetSelect.TabIndex = 10;
            this.offsetSelect.ValueChanged += new System.EventHandler(this.offsetSelect_ValueChanged);
            // 
            // sigList
            // 
            this.sigList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sigList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numCol,
            this.bitCol,
            this.nameCol,
            this.fullNameCol});
            this.sigList.GridLines = true;
            this.sigList.Location = new System.Drawing.Point(12, 116);
            this.sigList.Name = "sigList";
            this.sigList.Size = new System.Drawing.Size(476, 278);
            this.sigList.TabIndex = 12;
            this.sigList.UseCompatibleStateImageBehavior = false;
            this.sigList.View = System.Windows.Forms.View.Details;
            // 
            // numCol
            // 
            this.numCol.Text = "No.";
            this.numCol.Width = 40;
            // 
            // bitCol
            // 
            this.bitCol.Text = "Bits";
            this.bitCol.Width = 40;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Name";
            // 
            // fullNameCol
            // 
            this.fullNameCol.Text = "Full Name";
            this.fullNameCol.Width = 120;
            // 
            // multNameBox
            // 
            this.multNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multNameBox.Location = new System.Drawing.Point(56, 89);
            this.multNameBox.Name = "multNameBox";
            this.multNameBox.Size = new System.Drawing.Size(351, 20);
            this.multNameBox.TabIndex = 13;
            // 
            // nameAppButton
            // 
            this.nameAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameAppButton.Location = new System.Drawing.Point(413, 87);
            this.nameAppButton.Name = "nameAppButton";
            this.nameAppButton.Size = new System.Drawing.Size(75, 23);
            this.nameAppButton.TabIndex = 14;
            this.nameAppButton.Text = "Apply";
            this.nameAppButton.UseVisualStyleBackColor = true;
            this.nameAppButton.Click += new System.EventHandler(this.nameAppButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Name:";
            // 
            // EditMultSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 406);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nameAppButton);
            this.Controls.Add(this.multNameBox);
            this.Controls.Add(this.sigList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.offsetSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bitSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(516, 445);
            this.Name = "EditMultSignal";
            this.Text = "Edit Multiplexed Signal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditMultSignal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bitSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown bitSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown signalSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fullNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown offsetSelect;
        private System.Windows.Forms.ListView sigList;
        private System.Windows.Forms.ColumnHeader bitCol;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader fullNameCol;
        private System.Windows.Forms.ColumnHeader numCol;
        private System.Windows.Forms.TextBox multNameBox;
        private System.Windows.Forms.Button nameAppButton;
        private System.Windows.Forms.Label label6;
    }
}