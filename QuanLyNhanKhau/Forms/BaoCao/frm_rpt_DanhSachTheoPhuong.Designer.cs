namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class frm_rpt_DanhSachTheoPhuong
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
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbChonPhuong = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.dgvTheoPhuong = new System.Windows.Forms.DataGridView();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoPhuong)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.Controls.Add(this.btnBaoCao);
            this.grbTimKiem.Controls.Add(this.btnLamMoi);
            this.grbTimKiem.Controls.Add(this.btnTimKiem);
            this.grbTimKiem.Controls.Add(this.cbbChonPhuong);
            this.grbTimKiem.Controls.Add(this.label1);
            this.grbTimKiem.Location = new System.Drawing.Point(12, 12);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(648, 70);
            this.grbTimKiem.TabIndex = 0;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Lọc danh sách nhân khẩu theo phường";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn phường:";
            // 
            // cbbChonPhuong
            // 
            this.cbbChonPhuong.FormattingEnabled = true;
            this.cbbChonPhuong.Location = new System.Drawing.Point(86, 37);
            this.cbbChonPhuong.Name = "cbbChonPhuong";
            this.cbbChonPhuong.Size = new System.Drawing.Size(313, 21);
            this.cbbChonPhuong.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(405, 35);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(486, 35);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(567, 35);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 23);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // dgvTheoPhuong
            // 
            this.dgvTheoPhuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheoPhuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.TenTDP,
            this.NgheNghiep,
            this.TrangThai});
            this.dgvTheoPhuong.Location = new System.Drawing.Point(12, 88);
            this.dgvTheoPhuong.Name = "dgvTheoPhuong";
            this.dgvTheoPhuong.Size = new System.Drawing.Size(648, 470);
            this.dgvTheoPhuong.TabIndex = 1;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // TenTDP
            // 
            this.TenTDP.HeaderText = "Tên tổ dân phố";
            this.TenTDP.Name = "TenTDP";
            this.TenTDP.ReadOnly = true;
            // 
            // NgheNghiep
            // 
            this.NgheNghiep.HeaderText = "Nghề nghiệp";
            this.NgheNghiep.Name = "NgheNghiep";
            this.NgheNghiep.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // frm_rpt_DanhSachTheoPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 570);
            this.Controls.Add(this.dgvTheoPhuong);
            this.Controls.Add(this.grbTimKiem);
            this.Name = "frm_rpt_DanhSachTheoPhuong";
            this.Text = "frm_rpt_DanhSachTheoPhuong";
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoPhuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbChonPhuong;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTheoPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}