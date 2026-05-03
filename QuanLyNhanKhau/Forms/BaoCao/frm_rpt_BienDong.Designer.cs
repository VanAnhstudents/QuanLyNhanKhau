namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class frm_rpt_BienDong
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
            this.grbDate = new System.Windows.Forms.GroupBox();
            this.dateTimeTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dgvBienDong = new System.Windows.Forms.DataGridView();
            this.MaBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiBienDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBienDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grbDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienDong)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDate
            // 
            this.grbDate.Controls.Add(this.btnBaoCao);
            this.grbDate.Controls.Add(this.btnLamMoi);
            this.grbDate.Controls.Add(this.btnTimKiem);
            this.grbDate.Controls.Add(this.lblDenNgay);
            this.grbDate.Controls.Add(this.lblTuNgay);
            this.grbDate.Controls.Add(this.dateTimeDenNgay);
            this.grbDate.Controls.Add(this.dateTimeTuNgay);
            this.grbDate.Location = new System.Drawing.Point(12, 12);
            this.grbDate.Name = "grbDate";
            this.grbDate.Size = new System.Drawing.Size(744, 120);
            this.grbDate.TabIndex = 0;
            this.grbDate.TabStop = false;
            this.grbDate.Text = "Khoảng thời gian biến động";
            this.grbDate.Enter += new System.EventHandler(this.grbDate_Enter);
            // 
            // dateTimeTuNgay
            // 
            this.dateTimeTuNgay.Location = new System.Drawing.Point(61, 31);
            this.dateTimeTuNgay.Name = "dateTimeTuNgay";
            this.dateTimeTuNgay.Size = new System.Drawing.Size(220, 20);
            this.dateTimeTuNgay.TabIndex = 0;
            // 
            // dateTimeDenNgay
            // 
            this.dateTimeDenNgay.Location = new System.Drawing.Point(356, 30);
            this.dateTimeDenNgay.Name = "dateTimeDenNgay";
            this.dateTimeDenNgay.Size = new System.Drawing.Size(220, 20);
            this.dateTimeDenNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(6, 37);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(49, 13);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(294, 37);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(56, 13);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dgvBienDong
            // 
            this.dgvBienDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBienDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBD,
            this.MaNPT,
            this.HoTen,
            this.LoaiBienDong,
            this.NgayBienDong,
            this.GhiChu,
            this.NguoiThucHien});
            this.dgvBienDong.Location = new System.Drawing.Point(12, 138);
            this.dgvBienDong.Name = "dgvBienDong";
            this.dgvBienDong.Size = new System.Drawing.Size(744, 388);
            this.dgvBienDong.TabIndex = 1;
            // 
            // MaBD
            // 
            this.MaBD.HeaderText = "Mã BĐ";
            this.MaBD.Name = "MaBD";
            this.MaBD.ReadOnly = true;
            // 
            // MaNPT
            // 
            this.MaNPT.HeaderText = "Mã NPT";
            this.MaNPT.Name = "MaNPT";
            this.MaNPT.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // LoaiBienDong
            // 
            this.LoaiBienDong.HeaderText = "Loại biến động";
            this.LoaiBienDong.Name = "LoaiBienDong";
            this.LoaiBienDong.ReadOnly = true;
            // 
            // NgayBienDong
            // 
            this.NgayBienDong.HeaderText = "Ngày biến động";
            this.NgayBienDong.Name = "NgayBienDong";
            this.NgayBienDong.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.HeaderText = "Người thực hiện";
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.ReadOnly = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(582, 75);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(156, 39);
            this.btnBaoCao.TabIndex = 2;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(582, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(663, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // frm_rpt_BienDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 538);
            this.Controls.Add(this.dgvBienDong);
            this.Controls.Add(this.grbDate);
            this.Name = "frm_rpt_BienDong";
            this.Text = "frm_rpt_BienDong";
            this.grbDate.ResumeLayout(false);
            this.grbDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDate;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimeDenNgay;
        private System.Windows.Forms.DateTimePicker dateTimeTuNgay;
        private System.Windows.Forms.DataGridView dgvBienDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiBienDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBienDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiThucHien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnLamMoi;
    }
}