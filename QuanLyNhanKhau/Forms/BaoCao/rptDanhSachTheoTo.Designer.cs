namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class rptDanhSachTheoTo
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
            this.rpt_DanhSachTheoTo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpt_DanhSachTheoTo
            // 
            this.rpt_DanhSachTheoTo.ActiveViewIndex = -1;
            this.rpt_DanhSachTheoTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpt_DanhSachTheoTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpt_DanhSachTheoTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_DanhSachTheoTo.Location = new System.Drawing.Point(0, 0);
            this.rpt_DanhSachTheoTo.Name = "rpt_DanhSachTheoTo";
            this.rpt_DanhSachTheoTo.Size = new System.Drawing.Size(800, 450);
            this.rpt_DanhSachTheoTo.TabIndex = 0;
            // 
            // rptDanhSachTheoTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_DanhSachTheoTo);
            this.Name = "rptDanhSachTheoTo";
            this.Text = "rptDanhSachTheoTo";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpt_DanhSachTheoTo;
    }
}