namespace QuanLyNhanKhau.Forms.NghiepVu
{
    partial class frmTachHo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbHoCu = new System.Windows.Forms.GroupBox();
            this.dgvThanhVien = new System.Windows.Forms.DataGridView();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuanHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grbHoMoi = new System.Windows.Forms.GroupBox();
            this.dateTimeNgayTach = new System.Windows.Forms.DateTimePicker();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.cbbToDanPho = new System.Windows.Forms.ComboBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblNgayTachHo = new System.Windows.Forms.Label();
            this.lblNgheNghiep = new System.Windows.Forms.Label();
            this.lblToDanPho = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblChuHoMoi = new System.Windows.Forms.Label();
            this.cbbChuHo = new System.Windows.Forms.ComboBox();
            this.grbTomTat = new System.Windows.Forms.GroupBox();
            this.txtChuyenDi = new System.Windows.Forms.TextBox();
            this.txtOLai = new System.Windows.Forms.TextBox();
            this.lblChuyenDi = new System.Windows.Forms.Label();
            this.lblOLai = new System.Windows.Forms.Label();
            this.btnTachHo = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblNguoiThucHien = new System.Windows.Forms.Label();
            this.cbbNguoiThucHien = new System.Windows.Forms.ComboBox();
            this.grbHoCu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).BeginInit();
            this.grbHoMoi.SuspendLayout();
            this.grbTomTat.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbHoCu
            // 
            this.grbHoCu.Controls.Add(this.dgvThanhVien);
            this.grbHoCu.Controls.Add(this.btnTimKiem);
            this.grbHoCu.Controls.Add(this.txtTimKiem);
            this.grbHoCu.Location = new System.Drawing.Point(12, 12);
            this.grbHoCu.Name = "grbHoCu";
            this.grbHoCu.Size = new System.Drawing.Size(428, 278);
            this.grbHoCu.TabIndex = 0;
            this.grbHoCu.TabStop = false;
            this.grbHoCu.Text = "Hộ cũ";
            // 
            // dgvThanhVien
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThanhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTen,
            this.QuanHe,
            this.TrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThanhVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThanhVien.Location = new System.Drawing.Point(7, 56);
            this.dgvThanhVien.Name = "dgvThanhVien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThanhVien.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThanhVien.Size = new System.Drawing.Size(415, 216);
            this.dgvThanhVien.TabIndex = 2;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            // 
            // QuanHe
            // 
            this.QuanHe.HeaderText = "Quan hệ";
            this.QuanHe.Name = "QuanHe";
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái ";
            this.TrangThai.Name = "TrangThai";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(331, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(91, 23);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(7, 30);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(318, 20);
            this.txtTimKiem.TabIndex = 0;
            // 
            // grbHoMoi
            // 
            this.grbHoMoi.Controls.Add(this.dateTimeNgayTach);
            this.grbHoMoi.Controls.Add(this.txtNgheNghiep);
            this.grbHoMoi.Controls.Add(this.cbbToDanPho);
            this.grbHoMoi.Controls.Add(this.txtDienThoai);
            this.grbHoMoi.Controls.Add(this.lblNgayTachHo);
            this.grbHoMoi.Controls.Add(this.lblNgheNghiep);
            this.grbHoMoi.Controls.Add(this.lblToDanPho);
            this.grbHoMoi.Controls.Add(this.lblDienThoai);
            this.grbHoMoi.Controls.Add(this.lblDiaChi);
            this.grbHoMoi.Controls.Add(this.txtDiaChi);
            this.grbHoMoi.Controls.Add(this.lblChuHoMoi);
            this.grbHoMoi.Controls.Add(this.cbbChuHo);
            this.grbHoMoi.Location = new System.Drawing.Point(446, 12);
            this.grbHoMoi.Name = "grbHoMoi";
            this.grbHoMoi.Size = new System.Drawing.Size(428, 210);
            this.grbHoMoi.TabIndex = 1;
            this.grbHoMoi.TabStop = false;
            this.grbHoMoi.Text = "Hộ mới";
            // 
            // dateTimeNgayTach
            // 
            this.dateTimeNgayTach.Location = new System.Drawing.Point(86, 176);
            this.dateTimeNgayTach.Name = "dateTimeNgayTach";
            this.dateTimeNgayTach.Size = new System.Drawing.Size(200, 20);
            this.dateTimeNgayTach.TabIndex = 11;
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.Location = new System.Drawing.Point(83, 147);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(339, 20);
            this.txtNgheNghiep.TabIndex = 10;
            // 
            // cbbToDanPho
            // 
            this.cbbToDanPho.FormattingEnabled = true;
            this.cbbToDanPho.Location = new System.Drawing.Point(77, 116);
            this.cbbToDanPho.Name = "cbbToDanPho";
            this.cbbToDanPho.Size = new System.Drawing.Size(345, 21);
            this.cbbToDanPho.TabIndex = 9;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(85, 87);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(337, 20);
            this.txtDienThoai.TabIndex = 8;
            // 
            // lblNgayTachHo
            // 
            this.lblNgayTachHo.AutoSize = true;
            this.lblNgayTachHo.Location = new System.Drawing.Point(6, 178);
            this.lblNgayTachHo.Name = "lblNgayTachHo";
            this.lblNgayTachHo.Size = new System.Drawing.Size(74, 13);
            this.lblNgayTachHo.TabIndex = 7;
            this.lblNgayTachHo.Text = "Ngày tách hộ:";
            // 
            // lblNgheNghiep
            // 
            this.lblNgheNghiep.AutoSize = true;
            this.lblNgheNghiep.Location = new System.Drawing.Point(6, 150);
            this.lblNgheNghiep.Name = "lblNgheNghiep";
            this.lblNgheNghiep.Size = new System.Drawing.Size(71, 13);
            this.lblNgheNghiep.TabIndex = 6;
            this.lblNgheNghiep.Text = "Nghề nghiệp:";
            // 
            // lblToDanPho
            // 
            this.lblToDanPho.AutoSize = true;
            this.lblToDanPho.Location = new System.Drawing.Point(6, 119);
            this.lblToDanPho.Name = "lblToDanPho";
            this.lblToDanPho.Size = new System.Drawing.Size(65, 13);
            this.lblToDanPho.TabIndex = 5;
            this.lblToDanPho.Text = "Tổ dân phố:";
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(6, 90);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(73, 13);
            this.lblDienThoai.TabIndex = 4;
            this.lblDienThoai.Text = "Số điện thoại:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(6, 61);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(43, 13);
            this.lblDiaChi.TabIndex = 3;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(55, 58);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(367, 20);
            this.txtDiaChi.TabIndex = 2;
            // 
            // lblChuHoMoi
            // 
            this.lblChuHoMoi.AutoSize = true;
            this.lblChuHoMoi.Location = new System.Drawing.Point(6, 33);
            this.lblChuHoMoi.Name = "lblChuHoMoi";
            this.lblChuHoMoi.Size = new System.Drawing.Size(63, 13);
            this.lblChuHoMoi.TabIndex = 1;
            this.lblChuHoMoi.Text = "Chủ hộ mới:";
            // 
            // cbbChuHo
            // 
            this.cbbChuHo.FormattingEnabled = true;
            this.cbbChuHo.Location = new System.Drawing.Point(75, 30);
            this.cbbChuHo.Name = "cbbChuHo";
            this.cbbChuHo.Size = new System.Drawing.Size(121, 21);
            this.cbbChuHo.TabIndex = 0;
            // 
            // grbTomTat
            // 
            this.grbTomTat.Controls.Add(this.txtChuyenDi);
            this.grbTomTat.Controls.Add(this.txtOLai);
            this.grbTomTat.Controls.Add(this.lblChuyenDi);
            this.grbTomTat.Controls.Add(this.lblOLai);
            this.grbTomTat.Location = new System.Drawing.Point(446, 228);
            this.grbTomTat.Name = "grbTomTat";
            this.grbTomTat.Size = new System.Drawing.Size(208, 83);
            this.grbTomTat.TabIndex = 2;
            this.grbTomTat.TabStop = false;
            this.grbTomTat.Text = "Tóm tắt";
            // 
            // txtChuyenDi
            // 
            this.txtChuyenDi.Location = new System.Drawing.Point(162, 51);
            this.txtChuyenDi.Name = "txtChuyenDi";
            this.txtChuyenDi.ReadOnly = true;
            this.txtChuyenDi.Size = new System.Drawing.Size(40, 20);
            this.txtChuyenDi.TabIndex = 3;
            // 
            // txtOLai
            // 
            this.txtOLai.Location = new System.Drawing.Point(116, 23);
            this.txtOLai.Name = "txtOLai";
            this.txtOLai.ReadOnly = true;
            this.txtOLai.Size = new System.Drawing.Size(40, 20);
            this.txtOLai.TabIndex = 2;
            // 
            // lblChuyenDi
            // 
            this.lblChuyenDi.AutoSize = true;
            this.lblChuyenDi.Location = new System.Drawing.Point(6, 54);
            this.lblChuyenDi.Name = "lblChuyenDi";
            this.lblChuyenDi.Size = new System.Drawing.Size(150, 13);
            this.lblChuyenDi.TabIndex = 1;
            this.lblChuyenDi.Text = "Số người chuyển sang hộ mới:";
            // 
            // lblOLai
            // 
            this.lblOLai.AutoSize = true;
            this.lblOLai.Location = new System.Drawing.Point(6, 26);
            this.lblOLai.Name = "lblOLai";
            this.lblOLai.Size = new System.Drawing.Size(104, 13);
            this.lblOLai.TabIndex = 0;
            this.lblOLai.Text = "Số người ở lại hộ cũ:";
            // 
            // btnTachHo
            // 
            this.btnTachHo.Location = new System.Drawing.Point(660, 228);
            this.btnTachHo.Name = "btnTachHo";
            this.btnTachHo.Size = new System.Drawing.Size(214, 39);
            this.btnTachHo.TabIndex = 3;
            this.btnTachHo.Text = "Tách hộ";
            this.btnTachHo.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(660, 272);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(214, 39);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // lblNguoiThucHien
            // 
            this.lblNguoiThucHien.AutoSize = true;
            this.lblNguoiThucHien.Location = new System.Drawing.Point(12, 299);
            this.lblNguoiThucHien.Name = "lblNguoiThucHien";
            this.lblNguoiThucHien.Size = new System.Drawing.Size(85, 13);
            this.lblNguoiThucHien.TabIndex = 5;
            this.lblNguoiThucHien.Text = "Người thực hiện:";
            // 
            // cbbNguoiThucHien
            // 
            this.cbbNguoiThucHien.FormattingEnabled = true;
            this.cbbNguoiThucHien.Location = new System.Drawing.Point(103, 296);
            this.cbbNguoiThucHien.Name = "cbbNguoiThucHien";
            this.cbbNguoiThucHien.Size = new System.Drawing.Size(337, 21);
            this.cbbNguoiThucHien.TabIndex = 6;
            // 
            // frmTachHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 321);
            this.Controls.Add(this.cbbNguoiThucHien);
            this.Controls.Add(this.lblNguoiThucHien);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnTachHo);
            this.Controls.Add(this.grbTomTat);
            this.Controls.Add(this.grbHoMoi);
            this.Controls.Add(this.grbHoCu);
            this.Name = "frmTachHo";
            this.Text = "Tách hộ";
            this.grbHoCu.ResumeLayout(false);
            this.grbHoCu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).EndInit();
            this.grbHoMoi.ResumeLayout(false);
            this.grbHoMoi.PerformLayout();
            this.grbTomTat.ResumeLayout(false);
            this.grbTomTat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbHoCu;
        private System.Windows.Forms.DataGridView dgvThanhVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox grbHoMoi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblChuHoMoi;
        private System.Windows.Forms.ComboBox cbbChuHo;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblNgayTachHo;
        private System.Windows.Forms.Label lblNgheNghiep;
        private System.Windows.Forms.Label lblToDanPho;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.ComboBox cbbToDanPho;
        private System.Windows.Forms.DateTimePicker dateTimeNgayTach;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private System.Windows.Forms.GroupBox grbTomTat;
        private System.Windows.Forms.TextBox txtChuyenDi;
        private System.Windows.Forms.TextBox txtOLai;
        private System.Windows.Forms.Label lblChuyenDi;
        private System.Windows.Forms.Label lblOLai;
        private System.Windows.Forms.Button btnTachHo;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuanHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label lblNguoiThucHien;
        private System.Windows.Forms.ComboBox cbbNguoiThucHien;
    }
}