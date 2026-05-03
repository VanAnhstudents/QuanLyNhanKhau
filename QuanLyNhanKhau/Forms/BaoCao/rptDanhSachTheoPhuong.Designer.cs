namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class rptDanhSachTheoPhuong
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
            this.rpt_DanhSachTheoPhuong = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpt_DanhSachTheoPhuong
            // 
            this.rpt_DanhSachTheoPhuong.ActiveViewIndex = -1;
            this.rpt_DanhSachTheoPhuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpt_DanhSachTheoPhuong.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpt_DanhSachTheoPhuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_DanhSachTheoPhuong.Location = new System.Drawing.Point(0, 0);
            this.rpt_DanhSachTheoPhuong.Name = "rpt_DanhSachTheoPhuong";
            this.rpt_DanhSachTheoPhuong.Size = new System.Drawing.Size(800, 450);
            this.rpt_DanhSachTheoPhuong.TabIndex = 0;
            // 
            // rptDanhSachTheoPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_DanhSachTheoPhuong);
            this.Name = "rptDanhSachTheoPhuong";
            this.Text = "rptDanhSachTheoPhuong";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpt_DanhSachTheoPhuong;
    }
}