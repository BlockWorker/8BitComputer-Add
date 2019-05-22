namespace Instruction_Compiler
{
    partial class EditCommand
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
            this.basicSigView = new System.Windows.Forms.CheckedListBox();
            this.multSigView = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.stepSelect = new System.Windows.Forms.NumericUpDown();
            this.codeVarLabel = new System.Windows.Forms.Label();
            this.codeSelect = new System.Windows.Forms.NumericUpDown();
            this.varBox = new System.Windows.Forms.ComboBox();
            this.varButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // basicSigView
            // 
            this.basicSigView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basicSigView.FormattingEnabled = true;
            this.basicSigView.Location = new System.Drawing.Point(0, 0);
            this.basicSigView.Name = "basicSigView";
            this.basicSigView.Size = new System.Drawing.Size(229, 339);
            this.basicSigView.TabIndex = 0;
            this.basicSigView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.basicSigView_ItemCheck);
            // 
            // multSigView
            // 
            this.multSigView.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.multSigView.ColumnCount = 2;
            this.multSigView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.multSigView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.multSigView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multSigView.Location = new System.Drawing.Point(0, 0);
            this.multSigView.Name = "multSigView";
            this.multSigView.RowCount = 1;
            this.multSigView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.multSigView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.multSigView.Size = new System.Drawing.Size(215, 339);
            this.multSigView.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(310, 383);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(56, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(404, 20);
            this.nameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.multSigView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.basicSigView);
            this.splitContainer1.Size = new System.Drawing.Size(448, 339);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Step:";
            // 
            // stepSelect
            // 
            this.stepSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stepSelect.Location = new System.Drawing.Point(50, 383);
            this.stepSelect.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.stepSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepSelect.Name = "stepSelect";
            this.stepSelect.Size = new System.Drawing.Size(38, 20);
            this.stepSelect.TabIndex = 6;
            this.stepSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepSelect.ValueChanged += new System.EventHandler(this.stepSelect_ValueChanged);
            // 
            // codeVarLabel
            // 
            this.codeVarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.codeVarLabel.AutoSize = true;
            this.codeVarLabel.Location = new System.Drawing.Point(94, 386);
            this.codeVarLabel.Name = "codeVarLabel";
            this.codeVarLabel.Size = new System.Drawing.Size(48, 13);
            this.codeVarLabel.TabIndex = 7;
            this.codeVarLabel.Text = "Opcode:";
            this.codeVarLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // codeSelect
            // 
            this.codeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.codeSelect.Hexadecimal = true;
            this.codeSelect.Location = new System.Drawing.Point(148, 384);
            this.codeSelect.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.codeSelect.Name = "codeSelect";
            this.codeSelect.Size = new System.Drawing.Size(48, 20);
            this.codeSelect.TabIndex = 8;
            // 
            // varBox
            // 
            this.varBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.varBox.FormattingEnabled = true;
            this.varBox.Items.AddRange(new object[] {
            "LT",
            "GT",
            "(3)"});
            this.varBox.Location = new System.Drawing.Point(148, 383);
            this.varBox.Name = "varBox";
            this.varBox.Size = new System.Drawing.Size(48, 21);
            this.varBox.TabIndex = 9;
            this.varBox.Visible = false;
            this.varBox.SelectedIndexChanged += new System.EventHandler(this.varBox_SelectedIndexChanged);
            // 
            // varButton
            // 
            this.varButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.varButton.Location = new System.Drawing.Point(211, 383);
            this.varButton.Name = "varButton";
            this.varButton.Size = new System.Drawing.Size(86, 23);
            this.varButton.TabIndex = 10;
            this.varButton.Text = "Variants...";
            this.varButton.UseVisualStyleBackColor = true;
            this.varButton.Click += new System.EventHandler(this.varButton_Click);
            // 
            // EditCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 418);
            this.Controls.Add(this.varButton);
            this.Controls.Add(this.varBox);
            this.Controls.Add(this.codeSelect);
            this.Controls.Add(this.codeVarLabel);
            this.Controls.Add(this.stepSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.nameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(488, 305);
            this.Name = "EditCommand";
            this.Text = "Edit Command";
            this.Load += new System.EventHandler(this.EditCommand_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox basicSigView;
        private System.Windows.Forms.TableLayoutPanel multSigView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown stepSelect;
        private System.Windows.Forms.Label codeVarLabel;
        private System.Windows.Forms.NumericUpDown codeSelect;
        private System.Windows.Forms.ComboBox varBox;
        private System.Windows.Forms.Button varButton;
    }
}