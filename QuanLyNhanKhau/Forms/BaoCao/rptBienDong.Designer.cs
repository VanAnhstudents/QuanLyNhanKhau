namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class rptBienDong
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
            this.rpt_BienDong = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpt_BienDong
            // 
            this.rpt_BienDong.ActiveViewIndex = -1;
            this.rpt_BienDong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpt_BienDong.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpt_BienDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_BienDong.Location = new System.Drawing.Point(0, 0);
            this.rpt_BienDong.Name = "rpt_BienDong";
            this.rpt_BienDong.Size = new System.Drawing.Size(800, 450);
            this.rpt_BienDong.TabIndex = 0;
            // 
            // rptBienDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_BienDong);
            this.Name = "rptBienDong";
            this.Text = "rptBienDong";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpt_BienDong;
    }
}