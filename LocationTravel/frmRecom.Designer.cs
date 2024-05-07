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
            // frmRecom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1046);
            this.Controls.Add(this.flowLoc);
            this.Name = "frmRecom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recomendation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLoc;
    }
}