namespace Instruction_Compiler
{
    partial class SignalConfig
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
            this.chipSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.mulButton = new System.Windows.Forms.Button();
            this.remButton = new System.Windows.Forms.Button();
            this.signalView = new System.Windows.Forms.ListView();
            this.bitCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maskCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.invCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chipSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // chipSelect
            // 
            this.chipSelect.Location = new System.Drawing.Point(43, 12);
            this.chipSelect.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.chipSelect.Name = "chipSelect";
            this.chipSelect.Size = new System.Drawing.Size(34, 20);
            this.chipSelect.TabIndex = 0;
            this.chipSelect.ValueChanged += new System.EventHandler(this.chipSelect_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chip";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(83, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mulButton
            // 
            this.mulButton.Location = new System.Drawing.Point(164, 10);
            this.mulButton.Name = "mulButton";
            this.mulButton.Size = new System.Drawing.Size(94, 23);
            this.mulButton.TabIndex = 4;
            this.mulButton.Text = "Add Multiplexed";
            this.mulButton.UseVisualStyleBackColor = true;
            this.mulButton.Click += new System.EventHandler(this.mulButton_Click);
            // 
            // remButton
            // 
            this.remButton.Location = new System.Drawing.Point(345, 10);
            this.remButton.Name = "remButton";
            this.remButton.Size = new System.Drawing.Size(75, 23);
            this.remButton.TabIndex = 5;
            this.remButton.Text = "Remove";
            this.remButton.UseVisualStyleBackColor = true;
            this.remButton.Click += new System.EventHandler(this.remButton_Click);
            // 
            // signalView
            // 
            this.signalView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signalView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bitCol,
            this.nameCol,
            this.fullNameCol,
            this.maskCol,
            this.invCol});
            this.signalView.Location = new System.Drawing.Point(12, 39);
            this.signalView.Name = "signalView";
            this.signalView.Size = new System.Drawing.Size(407, 298);
            this.signalView.TabIndex = 6;
            this.signalView.UseCompatibleStateImageBehavior = false;
            this.signalView.View = System.Windows.Forms.View.Details;
            // 
            // bitCol
            // 
            this.bitCol.Text = "Bit(s)";
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
            // maskCol
            // 
            this.maskCol.Text = "Bitmask";
            // 
            // invCol
            // 
            this.invCol.Text = "Inverted";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(264, 9);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // SignalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 349);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.signalView);
            this.Controls.Add(this.remButton);
            this.Controls.Add(this.mulButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chipSelect);
            this.MinimumSize = new System.Drawing.Size(447, 388);
            this.Name = "SignalConfig";
            this.Text = "Signal Config";
            this.Load += new System.EventHandler(this.SignalConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chipSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown chipSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button mulButton;
        private System.Windows.Forms.Button remButton;
        private System.Windows.Forms.ListView signalView;
        private System.Windows.Forms.ColumnHeader bitCol;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader fullNameCol;
        private System.Windows.Forms.ColumnHeader maskCol;
        private System.Windows.Forms.ColumnHeader invCol;
        private System.Windows.Forms.Button editButton;
    }
}