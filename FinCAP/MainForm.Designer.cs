namespace FinCAP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.LedgerMasterTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateFileTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBtnLedgerMaster = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LedgerMasterTSMenu,
            this.GenerateFileTSMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LedgerMasterTSMenu
            // 
            this.LedgerMasterTSMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LedgerMasterTSMenu.Name = "LedgerMasterTSMenu";
            this.LedgerMasterTSMenu.Size = new System.Drawing.Size(94, 20);
            this.LedgerMasterTSMenu.Text = "Ledger Master";
            this.LedgerMasterTSMenu.Click += new System.EventHandler(this.ledgerMasterToolStripMenuItem_Click);
            // 
            // GenerateFileTSMenu
            // 
            this.GenerateFileTSMenu.BackColor = System.Drawing.Color.PeachPuff;
            this.GenerateFileTSMenu.Name = "GenerateFileTSMenu";
            this.GenerateFileTSMenu.Size = new System.Drawing.Size(87, 20);
            this.GenerateFileTSMenu.Text = "Generate File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBtnLedgerMaster});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBtnLedgerMaster
            // 
            this.TSBtnLedgerMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBtnLedgerMaster.Image = ((System.Drawing.Image)(resources.GetObject("TSBtnLedgerMaster.Image")));
            this.TSBtnLedgerMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBtnLedgerMaster.Name = "TSBtnLedgerMaster";
            this.TSBtnLedgerMaster.Size = new System.Drawing.Size(86, 22);
            this.TSBtnLedgerMaster.Text = "Ledger Master";
            this.TSBtnLedgerMaster.Click += new System.EventHandler(this.TSBtnLedgerMaster_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Convert Contract Note to Tally Upload Format";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LedgerMasterTSMenu;
        private System.Windows.Forms.ToolStripMenuItem GenerateFileTSMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBtnLedgerMaster;
    }
}