namespace QuanLyNhanKhau.Forms.BaoCao
{
    partial class frm_rpt_DanhSachTheoTo
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
            this.lblChonPhuong = new System.Windows.Forms.Label();
            this.lblChonTDP = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblDatLai = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.dgvDanhSachTheoTo = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTheoTo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChonPhuong
            // 
            this.lblChonPhuong.AutoSize = true;
            this.lblChonPhuong.Location = new System.Drawing.Point(12, 9);
            this.lblChonPhuong.Name = "lblChonPhuong";
            this.lblChonPhuong.Size = new System.Drawing.Size(74, 13);
            this.lblChonPhuong.TabIndex = 0;
            this.lblChonPhuong.Text = "Chọn phường:";
            // 
            // lblChonTDP
            // 
            this.lblChonTDP.AutoSize = true;
            this.lblChonTDP.Location = new System.Drawing.Point(12, 41);
            this.lblChonTDP.Name = "lblChonTDP";
            this.lblChonTDP.Size = new System.Drawing.Size(89, 13);
            this.lblChonTDP.TabIndex = 1;
            this.lblChonTDP.Text = "Chọn tổ dân phố:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(323, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(107, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(323, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(436, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(106, 50);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // lblDatLai
            // 
            this.lblDatLai.Location = new System.Drawing.Point(544, 4);
            this.lblDatLai.Name = "lblDatLai";
            this.lblDatLai.Size = new System.Drawing.Size(106, 50);
            this.lblDatLai.TabIndex = 5;
            this.lblDatLai.Text = "Đặt lại";
            this.lblDatLai.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(653, 4);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(106, 50);
            this.btnBaoCao.TabIndex = 6;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // dgvDanhSachTheoTo
            // 
            this.dgvDanhSachTheoTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachTheoTo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.NgheNghiep,
            this.DiaChi,
            this.TrangThai});
            this.dgvDanhSachTheoTo.Location = new System.Drawing.Point(15, 65);
            this.dgvDanhSachTheoTo.Name = "dgvDanhSachTheoTo";
            this.dgvDanhSachTheoTo.Size = new System.Drawing.Size(744, 324);
            this.dgvDanhSachTheoTo.TabIndex = 7;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
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
            // NgheNghiep
            // 
            this.NgheNghiep.HeaderText = "Nghề nghiệp";
            this.NgheNghiep.Name = "NgheNghiep";
            this.NgheNghiep.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // frm_rpt_DanhSachTheoTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 401);
            this.Controls.Add(this.dgvDanhSachTheoTo);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.lblDatLai);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblChonTDP);
            this.Controls.Add(this.lblChonPhuong);
            this.Name = "frm_rpt_DanhSachTheoTo";
            this.Text = "frm_rpt_DanhSachTheoTo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTheoTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChonPhuong;
        private System.Windows.Forms.Label lblChonTDP;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button lblDatLai;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.DataGridView dgvDanhSachTheoTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}