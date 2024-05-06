namespace LocationTravel
{
    partial class frmRecom
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
            this.flowLoc = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.combinationLoc1 = new LocationTravel.CombinationLoc();
            this.combinationLoc2 = new LocationTravel.CombinationLoc();
            this.combinationLoc3 = new LocationTravel.CombinationLoc();
            this.combinationLoc4 = new LocationTravel.CombinationLoc();
            this.combinationLoc5 = new LocationTravel.CombinationLoc();
            this.flowLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLoc
            // 
            this.flowLoc.AutoScroll = true;
            this.flowLoc.Controls.Add(this.combinationLoc1);
            this.flowLoc.Controls.Add(this.combinationLoc2);
            this.flowLoc.Controls.Add(this.combinationLoc3);
            this.flowLoc.Controls.Add(this.combinationLoc4);
            this.flowLoc.Controls.Add(this.combinationLoc5);
            this.flowLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLoc.Location = new System.Drawing.Point(0, 0);
            this.flowLoc.Name = "flowLoc";
            this.flowLoc.Size = new System.Drawing.Size(1924, 1046);
            this.flowLoc.TabIndex = 0;
            this.flowLoc.Resize += new System.EventHandler(this.flowLoc_Resize);
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.BindingContainer = this.flowLoc;
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 1046;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(1903, 0);
            this.guna2VScrollBar1.Maximum = 1244;
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 21;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(21, 1046);
            this.guna2VScrollBar1.SmallChange = 5;
            this.guna2VScrollBar1.TabIndex = 1;
            // 
            // combinationLoc1
            // 
            this.combinationLoc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combinationLoc1.Location = new System.Drawing.Point(3, 3);
            this.combinationLoc1.Name = "combinationLoc1";
            this.combinationLoc1.NameCombination = null;
            this.combinationLoc1.Size = new System.Drawing.Size(1894, 243);
            this.combinationLoc1.TabIndex = 0;
            // 
            // combinationLoc2
            // 
            this.combinationLoc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combinationLoc2.Location = new System.Drawing.Point(3, 252);
            this.combinationLoc2.Name = "combinationLoc2";
            this.combinationLoc2.NameCombination = null;
            this.combinationLoc2.Size = new System.Drawing.Size(1894, 243);
            this.combinationLoc2.TabIndex = 1;
            // 
            // combinationLoc3
            // 
            this.combinationLoc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combinationLoc3.Location = new System.Drawing.Point(3, 501);
            this.combinationLoc3.Name = "combinationLoc3";
            this.combinationLoc3.NameCombination = null;
            this.combinationLoc3.Size = new System.Drawing.Size(1894, 243);
            this.combinationLoc3.TabIndex = 2;
            // 
            // combinationLoc4
            // 
            this.combinationLoc4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combinationLoc4.Location = new System.Drawing.Point(3, 750);
            this.combinationLoc4.Name = "combinationLoc4";
            this.combinationLoc4.NameCombination = null;
            this.combinationLoc4.Size = new System.Drawing.Size(1894, 243);
            this.combinationLoc4.TabIndex = 3;
            // 
            // combinationLoc5
            // 
            this.combinationLoc5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combinationLoc5.Location = new System.Drawing.Point(3, 999);
            this.combinationLoc5.Name = "combinationLoc5";
            this.combinationLoc5.NameCombination = null;
            this.combinationLoc5.Size = new System.Drawing.Size(1894, 243);
            this.combinationLoc5.TabIndex = 4;
            // 
            // frmRecom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1046);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.flowLoc);
            this.MinimizeBox = false;
            this.Name = "frmRecom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recomendation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecom_Load);
            this.flowLoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLoc;
        private CombinationLoc combinationLoc1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private CombinationLoc combinationLoc2;
        private CombinationLoc combinationLoc3;
        private CombinationLoc combinationLoc4;
        private CombinationLoc combinationLoc5;
    }
}