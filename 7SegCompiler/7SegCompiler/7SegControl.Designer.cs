namespace _7SegCompiler {
    partial class _7SegControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.segA = new System.Windows.Forms.Label();
            this.segG = new System.Windows.Forms.Label();
            this.segD = new System.Windows.Forms.Label();
            this.segF = new System.Windows.Forms.Label();
            this.segE = new System.Windows.Forms.Label();
            this.segB = new System.Windows.Forms.Label();
            this.segC = new System.Windows.Forms.Label();
            this.segDP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // segA
            // 
            this.segA.BackColor = System.Drawing.Color.White;
            this.segA.Location = new System.Drawing.Point(34, 10);
            this.segA.Name = "segA";
            this.segA.Size = new System.Drawing.Size(62, 20);
            this.segA.TabIndex = 0;
            this.segA.Tag = 7;
            this.segA.Click += new System.EventHandler(this.SegClick);
            // 
            // segG
            // 
            this.segG.BackColor = System.Drawing.Color.White;
            this.segG.Location = new System.Drawing.Point(34, 85);
            this.segG.Name = "segG";
            this.segG.Size = new System.Drawing.Size(62, 20);
            this.segG.TabIndex = 1;
            this.segG.Click += new System.EventHandler(this.SegClick);
            // 
            // segD
            // 
            this.segD.BackColor = System.Drawing.Color.White;
            this.segD.Location = new System.Drawing.Point(34, 160);
            this.segD.Name = "segD";
            this.segD.Size = new System.Drawing.Size(62, 20);
            this.segD.TabIndex = 2;
            this.segD.Click += new System.EventHandler(this.SegClick);
            // 
            // segF
            // 
            this.segF.BackColor = System.Drawing.Color.White;
            this.segF.Location = new System.Drawing.Point(10, 10);
            this.segF.Name = "segF";
            this.segF.Size = new System.Drawing.Size(20, 83);
            this.segF.TabIndex = 3;
            this.segF.Click += new System.EventHandler(this.SegClick);
            // 
            // segE
            // 
            this.segE.BackColor = System.Drawing.Color.White;
            this.segE.Location = new System.Drawing.Point(10, 97);
            this.segE.Name = "segE";
            this.segE.Size = new System.Drawing.Size(20, 83);
            this.segE.TabIndex = 4;
            this.segE.Click += new System.EventHandler(this.SegClick);
            // 
            // segB
            // 
            this.segB.BackColor = System.Drawing.Color.White;
            this.segB.Location = new System.Drawing.Point(100, 10);
            this.segB.Name = "segB";
            this.segB.Size = new System.Drawing.Size(20, 83);
            this.segB.TabIndex = 5;
            this.segB.Click += new System.EventHandler(this.SegClick);
            // 
            // segC
            // 
            this.segC.BackColor = System.Drawing.Color.White;
            this.segC.Location = new System.Drawing.Point(100, 97);
            this.segC.Name = "segC";
            this.segC.Size = new System.Drawing.Size(20, 83);
            this.segC.TabIndex = 6;
            this.segC.Click += new System.EventHandler(this.SegClick);
            // 
            // segDP
            // 
            this.segDP.BackColor = System.Drawing.Color.White;
            this.segDP.Location = new System.Drawing.Point(130, 160);
            this.segDP.Name = "segDP";
            this.segDP.Size = new System.Drawing.Size(20, 20);
            this.segDP.TabIndex = 7;
            this.segDP.Click += new System.EventHandler(this.SegClick);
            // 
            // _7SegControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.segDP);
            this.Controls.Add(this.segC);
            this.Controls.Add(this.segB);
            this.Controls.Add(this.segE);
            this.Controls.Add(this.segF);
            this.Controls.Add(this.segD);
            this.Controls.Add(this.segG);
            this.Controls.Add(this.segA);
            this.Name = "_7SegControl";
            this.Size = new System.Drawing.Size(160, 190);
            this.Load += new System.EventHandler(this._7SegControl_Load);
            this.Resize += new System.EventHandler(this._7SegControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label segA;
        private System.Windows.Forms.Label segG;
        private System.Windows.Forms.Label segD;
        private System.Windows.Forms.Label segF;
        private System.Windows.Forms.Label segE;
        private System.Windows.Forms.Label segB;
        private System.Windows.Forms.Label segC;
        private System.Windows.Forms.Label segDP;
    }
}
