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
            this.btnRecom = new Guna.UI2.WinForms.Guna2Button();
            this.flowLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLoc
            // 
            this.flowLoc.AutoScroll = true;
            this.flowLoc.Controls.Add(this.btnRecom);
            this.flowLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLoc.Location = new System.Drawing.Point(0, 0);
            this.flowLoc.Margin = new System.Windows.Forms.Padding(10);
            this.flowLoc.Name = "flowLoc";
            this.flowLoc.Size = new System.Drawing.Size(1924, 1046);
            this.flowLoc.TabIndex = 0;
            this.flowLoc.Resize += new System.EventHandler(this.flowLoc_Resize);
            // 
            // btnRecom
            // 
            this.btnRecom.BorderRadius = 5;
            this.btnRecom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecom.FillColor = System.Drawing.Color.Red;
            this.btnRecom.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.btnRecom.ForeColor = System.Drawing.Color.White;
            this.btnRecom.Location = new System.Drawing.Point(3, 3);
            this.btnRecom.Name = "btnRecom";
            this.btnRecom.Size = new System.Drawing.Size(131, 35);
            this.btnRecom.TabIndex = 15;
            this.btnRecom.Text = "Tạo mới";
            this.btnRecom.Click += new System.EventHandler(this.btnRecom_Click);
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
            this.flowLoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLoc;
        private Guna.UI2.WinForms.Guna2Button btnRecom;
    }
}