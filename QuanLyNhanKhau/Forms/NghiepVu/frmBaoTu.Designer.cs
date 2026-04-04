namespace QuanLyNhanKhau.Forms.NghiepVu
{
    partial class frmBaoTu
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
            this.grbThongTinHoKhau = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grbThongTinBaoTu = new System.Windows.Forms.GroupBox();
            this.lblNgayTuVong = new System.Windows.Forms.Label();
            this.dateTimeNgayTuVong = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNguyenNhanTuVong = new System.Windows.Forms.Label();
            this.lblNoiTuVong = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnXacNhanBaoTu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuanHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNguoiThucHien = new System.Windows.Forms.Label();
            this.txtNguoiThucHien = new System.Windows.Forms.TextBox();
            this.grbThongTinHoKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbThongTinBaoTu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbThongTinHoKhau
            // 
            this.grbThongTinHoKhau.Controls.Add(this.dataGridView1);
            this.grbThongTinHoKhau.Controls.Add(this.btnTimKiem);
            this.grbThongTinHoKhau.Controls.Add(this.txtTimKiem);
            this.grbThongTinHoKhau.Location = new System.Drawing.Point(12, 12);
            this.grbThongTinHoKhau.Name = "grbThongTinHoKhau";
            this.grbThongTinHoKhau.Size = new System.Drawing.Size(675, 298);
            this.grbThongTinHoKhau.TabIndex = 0;
            this.grbThongTinHoKhau.TabStop = false;
            this.grbThongTinHoKhau.Text = "Thông tin hộ khẩu";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTen,
            this.GioiTinh,
            this.QuanHe,
            this.NgheNghiep,
            this.TrangThai});
            this.dataGridView1.Location = new System.Drawing.Point(6, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 247);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(309, 19);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(6, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(295, 20);
            this.txtTimKiem.TabIndex = 0;
            // 
            // grbThongTinBaoTu
            // 
            this.grbThongTinBaoTu.Controls.Add(this.txtNguoiThucHien);
            this.grbThongTinBaoTu.Controls.Add(this.lblNguoiThucHien);
            this.grbThongTinBaoTu.Controls.Add(this.textBox2);
            this.grbThongTinBaoTu.Controls.Add(this.lblNoiTuVong);
            this.grbThongTinBaoTu.Controls.Add(this.lblNguyenNhanTuVong);
            this.grbThongTinBaoTu.Controls.Add(this.textBox1);
            this.grbThongTinBaoTu.Controls.Add(this.lblNgayTuVong);
            this.grbThongTinBaoTu.Controls.Add(this.dateTimeNgayTuVong);
            this.grbThongTinBaoTu.Location = new System.Drawing.Point(12, 316);
            this.grbThongTinBaoTu.Name = "grbThongTinBaoTu";
            this.grbThongTinBaoTu.Size = new System.Drawing.Size(511, 158);
            this.grbThongTinBaoTu.TabIndex = 1;
            this.grbThongTinBaoTu.TabStop = false;
            this.grbThongTinBaoTu.Text = "Thông tin báo tử";
            // 
            // lblNgayTuVong
            // 
            this.lblNgayTuVong.AutoSize = true;
            this.lblNgayTuVong.Location = new System.Drawing.Point(6, 26);
            this.lblNgayTuVong.Name = "lblNgayTuVong";
            this.lblNgayTuVong.Size = new System.Drawing.Size(74, 13);
            this.lblNgayTuVong.TabIndex = 1;
            this.lblNgayTuVong.Text = "Ngày tử vong:";
            // 
            // dateTimeNgayTuVong
            // 
            this.dateTimeNgayTuVong.Location = new System.Drawing.Point(86, 22);
            this.dateTimeNgayTuVong.Name = "dateTimeNgayTuVong";
            this.dateTimeNgayTuVong.Size = new System.Drawing.Size(200, 20);
            this.dateTimeNgayTuVong.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lblNguyenNhanTuVong
            // 
            this.lblNguyenNhanTuVong.AutoSize = true;
            this.lblNguyenNhanTuVong.Location = new System.Drawing.Point(6, 61);
            this.lblNguyenNhanTuVong.Name = "lblNguyenNhanTuVong";
            this.lblNguyenNhanTuVong.Size = new System.Drawing.Size(113, 13);
            this.lblNguyenNhanTuVong.TabIndex = 3;
            this.lblNguyenNhanTuVong.Text = "Nguyên nhân tử vong:";
            // 
            // lblNoiTuVong
            // 
            this.lblNoiTuVong.AutoSize = true;
            this.lblNoiTuVong.Location = new System.Drawing.Point(6, 94);
            this.lblNoiTuVong.Name = "lblNoiTuVong";
            this.lblNoiTuVong.Size = new System.Drawing.Size(65, 13);
            this.lblNoiTuVong.TabIndex = 4;
            this.lblNoiTuVong.Text = "Nơi tử vong:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(428, 20);
            this.textBox2.TabIndex = 5;
            // 
            // btnXacNhanBaoTu
            // 
            this.btnXacNhanBaoTu.Location = new System.Drawing.Point(529, 316);
            this.btnXacNhanBaoTu.Name = "btnXacNhanBaoTu";
            this.btnXacNhanBaoTu.Size = new System.Drawing.Size(158, 39);
            this.btnXacNhanBaoTu.TabIndex = 2;
            this.btnXacNhanBaoTu.Text = "Xác nhận báo tử";
            this.btnXacNhanBaoTu.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(529, 361);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(158, 39);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            // 
            // QuanHe
            // 
            this.QuanHe.HeaderText = "Quan hệ";
            this.QuanHe.Name = "QuanHe";
            // 
            // NgheNghiep
            // 
            this.NgheNghiep.HeaderText = "Nghề nghiệp";
            this.NgheNghiep.Name = "NgheNghiep";
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            // 
            // lblNguoiThucHien
            // 
            this.lblNguoiThucHien.AutoSize = true;
            this.lblNguoiThucHien.Location = new System.Drawing.Point(6, 133);
            this.lblNguoiThucHien.Name = "lblNguoiThucHien";
            this.lblNguoiThucHien.Size = new System.Drawing.Size(85, 13);
            this.lblNguoiThucHien.TabIndex = 6;
            this.lblNguoiThucHien.Text = "Người thực hiện:";
            // 
            // txtNguoiThucHien
            // 
            this.txtNguoiThucHien.Location = new System.Drawing.Point(97, 130);
            this.txtNguoiThucHien.Name = "txtNguoiThucHien";
            this.txtNguoiThucHien.ReadOnly = true;
            this.txtNguoiThucHien.Size = new System.Drawing.Size(408, 20);
            this.txtNguoiThucHien.TabIndex = 7;
            // 
            // frmBaoTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 483);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhanBaoTu);
            this.Controls.Add(this.grbThongTinBaoTu);
            this.Controls.Add(this.grbThongTinHoKhau);
            this.Name = "frmBaoTu";
            this.Text = "Báo tử";
            this.grbThongTinHoKhau.ResumeLayout(false);
            this.grbThongTinHoKhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbThongTinBaoTu.ResumeLayout(false);
            this.grbThongTinBaoTu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTinHoKhau;
        private System.Windows.Forms.GroupBox grbThongTinBaoTu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblNgayTuVong;
        private System.Windows.Forms.DateTimePicker dateTimeNgayTuVong;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblNoiTuVong;
        private System.Windows.Forms.Label lblNguyenNhanTuVong;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnXacNhanBaoTu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuanHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.TextBox txtNguoiThucHien;
        private System.Windows.Forms.Label lblNguoiThucHien;
    }
}