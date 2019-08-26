namespace Instruction_Compiler
{
    partial class CommandMainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlSignalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transmitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.configOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.newCmdButton = new System.Windows.Forms.Button();
            this.remCmdButton = new System.Windows.Forms.Button();
            this.commandView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.codeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editButton = new System.Windows.Forms.Button();
            this.programSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.programOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.dupCmdButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controlSignalsToolStripMenuItem,
            this.transmitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProgramToolStripMenuItem,
            this.saveProgramToolStripMenuItem,
            this.loadProgramToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearConfigToolStripMenuItem,
            this.saveConfigToolStripMenuItem,
            this.loadConfigToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProgramToolStripMenuItem
            // 
            this.newProgramToolStripMenuItem.Name = "newProgramToolStripMenuItem";
            this.newProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProgramToolStripMenuItem.Text = "New Program";
            this.newProgramToolStripMenuItem.Click += new System.EventHandler(this.newProgramToolStripMenuItem_Click);
            // 
            // saveProgramToolStripMenuItem
            // 
            this.saveProgramToolStripMenuItem.Name = "saveProgramToolStripMenuItem";
            this.saveProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProgramToolStripMenuItem.Text = "Save Program";
            this.saveProgramToolStripMenuItem.Click += new System.EventHandler(this.saveProgramToolStripMenuItem_Click);
            // 
            // loadProgramToolStripMenuItem
            // 
            this.loadProgramToolStripMenuItem.Name = "loadProgramToolStripMenuItem";
            this.loadProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadProgramToolStripMenuItem.Text = "Load Program";
            this.loadProgramToolStripMenuItem.Click += new System.EventHandler(this.loadProgramToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // clearConfigToolStripMenuItem
            // 
            this.clearConfigToolStripMenuItem.Name = "clearConfigToolStripMenuItem";
            this.clearConfigToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearConfigToolStripMenuItem.Text = "Clear Config";
            this.clearConfigToolStripMenuItem.Click += new System.EventHandler(this.clearConfigToolStripMenuItem_Click);
            // 
            // saveConfigToolStripMenuItem
            // 
            this.saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            this.saveConfigToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveConfigToolStripMenuItem.Text = "Save Config";
            this.saveConfigToolStripMenuItem.Click += new System.EventHandler(this.saveConfigToolStripMenuItem_Click);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadConfigToolStripMenuItem.Text = "Load Config";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // controlSignalsToolStripMenuItem
            // 
            this.controlSignalsToolStripMenuItem.Name = "controlSignalsToolStripMenuItem";
            this.controlSignalsToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.controlSignalsToolStripMenuItem.Text = "Control Signals";
            this.controlSignalsToolStripMenuItem.Click += new System.EventHandler(this.controlSignalsToolStripMenuItem_Click);
            // 
            // transmitToolStripMenuItem
            // 
            this.transmitToolStripMenuItem.Name = "transmitToolStripMenuItem";
            this.transmitToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.transmitToolStripMenuItem.Text = "Transmit";
            this.transmitToolStripMenuItem.Click += new System.EventHandler(this.transmitToolStripMenuItem_Click);
            // 
            // configSaveDialog
            // 
            this.configSaveDialog.DefaultExt = "sig";
            this.configSaveDialog.Filter = "Signal Config|*.sig|All files|*.*";
            this.configSaveDialog.InitialDirectory = "%userprofile%\\Documents";
            // 
            // configOpenDialog
            // 
            this.configOpenDialog.DefaultExt = "sig";
            this.configOpenDialog.Filter = "Signal Config|*.sig|All files|*.*";
            this.configOpenDialog.InitialDirectory = "%userprofile%\\Documents";
            // 
            // newCmdButton
            // 
            this.newCmdButton.Location = new System.Drawing.Point(12, 27);
            this.newCmdButton.Name = "newCmdButton";
            this.newCmdButton.Size = new System.Drawing.Size(75, 23);
            this.newCmdButton.TabIndex = 0;
            this.newCmdButton.Text = "New";
            this.newCmdButton.UseVisualStyleBackColor = true;
            this.newCmdButton.Click += new System.EventHandler(this.newCmdButton_Click);
            // 
            // remCmdButton
            // 
            this.remCmdButton.Location = new System.Drawing.Point(268, 27);
            this.remCmdButton.Name = "remCmdButton";
            this.remCmdButton.Size = new System.Drawing.Size(93, 23);
            this.remCmdButton.TabIndex = 2;
            this.remCmdButton.Text = "Remove";
            this.remCmdButton.UseVisualStyleBackColor = true;
            this.remCmdButton.Click += new System.EventHandler(this.remCmdButton_Click);
            // 
            // commandView
            // 
            this.commandView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.codeHeader,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.commandView.FullRowSelect = true;
            this.commandView.Location = new System.Drawing.Point(12, 56);
            this.commandView.MultiSelect = false;
            this.commandView.Name = "commandView";
            this.commandView.Size = new System.Drawing.Size(631, 412);
            this.commandView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.commandView.TabIndex = 5;
            this.commandView.UseCompatibleStateImageBehavior = false;
            this.commandView.View = System.Windows.Forms.View.Details;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 100;
            // 
            // codeHeader
            // 
            this.codeHeader.Text = "Code";
            this.codeHeader.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Step 1";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Step 2";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Step 3";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Step 4";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Step 5";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Step 6";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Step 7";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Step 8";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Step 9";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Step 10";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Step 11";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Step 12";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Step 13";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Step 14";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Step 15";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Step 16";
            this.columnHeader16.Width = 100;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(93, 27);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // programSaveDialog
            // 
            this.programSaveDialog.DefaultExt = "mcp";
            this.programSaveDialog.Filter = "Microcode program|*.mcp|All files|*.*";
            this.programSaveDialog.InitialDirectory = "%userprofile%\\Documents";
            // 
            // programOpenDialog
            // 
            this.programOpenDialog.Filter = "Microcode program|*.mcp|All files|*.*";
            this.programOpenDialog.InitialDirectory = "%userprofile%\\Documents";
            // 
            // dupCmdButton
            // 
            this.dupCmdButton.Location = new System.Drawing.Point(174, 27);
            this.dupCmdButton.Name = "dupCmdButton";
            this.dupCmdButton.Size = new System.Drawing.Size(88, 23);
            this.dupCmdButton.TabIndex = 7;
            this.dupCmdButton.Text = "Duplicate";
            this.dupCmdButton.UseVisualStyleBackColor = true;
            this.dupCmdButton.Click += new System.EventHandler(this.dupCmdButton_Click);
            // 
            // CommandMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 480);
            this.Controls.Add(this.dupCmdButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.commandView);
            this.Controls.Add(this.remCmdButton);
            this.Controls.Add(this.newCmdButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CommandMainForm";
            this.Text = "Instruction Compiler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommandMainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlSignalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem clearConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog configSaveDialog;
        private System.Windows.Forms.OpenFileDialog configOpenDialog;
        private System.Windows.Forms.Button newCmdButton;
        private System.Windows.Forms.Button remCmdButton;
        private System.Windows.Forms.ListView commandView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.SaveFileDialog programSaveDialog;
        private System.Windows.Forms.OpenFileDialog programOpenDialog;
        private System.Windows.Forms.ToolStripMenuItem transmitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader codeHeader;
        private System.Windows.Forms.Button dupCmdButton;
    }
}

