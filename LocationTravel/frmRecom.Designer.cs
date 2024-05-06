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
            this.SuspendLayout();
            // 
            // flowLoc
            // 
            this.flowLoc.AutoScroll = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLoc;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
    }
}