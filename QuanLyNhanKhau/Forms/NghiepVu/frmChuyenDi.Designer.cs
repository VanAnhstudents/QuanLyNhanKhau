namespace QuanLyNhanKhau.Forms.NghiepVu
{
    partial class frmChuyenDi
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
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuanHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtnChuyenToanBo = new System.Windows.Forms.RadioButton();
            this.rbtnCaNhan = new System.Windows.Forms.RadioButton();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grbThongTinChuyenDi = new System.Windows.Forms.GroupBox();
            this.txtLyDoChuyenDi = new System.Windows.Forms.TextBox();
            this.txtDiaChiChuyenDen = new System.Windows.Forms.TextBox();
            this.dateTimeNgayChuyenDi = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiThucHien = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.lblDiaChiChuyenDen = new System.Windows.Forms.Label();
            this.lblNgayChuyenDi = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.cbbNguoiThucHien = new System.Windows.Forms.ComboBox();
            this.grbThongTinHoKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbThongTinChuyenDi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbThongTinHoKhau
            // 
            this.grbThongTinHoKhau.Controls.Add(this.dataGridView1);
            this.grbThongTinHoKhau.Controls.Add(this.rbtnChuyenToanBo);
            this.grbThongTinHoKhau.Controls.Add(this.rbtnCaNhan);
            this.grbThongTinHoKhau.Controls.Add(this.btnTimKiem);
            this.grbThongTinHoKhau.Controls.Add(this.txtTimKiem);
            this.grbThongTinHoKhau.Location = new System.Drawing.Point(12, 12);
            this.grbThongTinHoKhau.Name = "grbThongTinHoKhau";
            this.grbThongTinHoKhau.Size = new System.Drawing.Size(673, 325);
            this.grbThongTinHoKhau.TabIndex = 0;
            this.grbThongTinHoKhau.TabStop = false;
            this.grbThongTinHoKhau.Text = "Thông tin hộ khẩu hiện tại";
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 247);
            this.dataGridView1.TabIndex = 4;
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
            // rbtnChuyenToanBo
            // 
            this.rbtnChuyenToanBo.AutoSize = true;
            this.rbtnChuyenToanBo.Location = new System.Drawing.Point(116, 47);
            this.rbtnChuyenToanBo.Name = "rbtnChuyenToanBo";
            this.rbtnChuyenToanBo.Size = new System.Drawing.Size(115, 17);
            this.rbtnChuyenToanBo.TabIndex = 3;
            this.rbtnChuyenToanBo.TabStop = true;
            this.rbtnChuyenToanBo.Text = "Chuyển toàn bộ hộ";
            this.rbtnChuyenToanBo.UseVisualStyleBackColor = true;
            // 
            // rbtnCaNhan
            // 
            this.rbtnCaNhan.AutoSize = true;
            this.rbtnCaNhan.Location = new System.Drawing.Point(7, 47);
            this.rbtnCaNhan.Name = "rbtnCaNhan";
            this.rbtnCaNhan.Size = new System.Drawing.Size(103, 17);
            this.rbtnCaNhan.TabIndex = 2;
            this.rbtnCaNhan.TabStop = true;
            this.rbtnCaNhan.Text = "Chuyển cá nhân";
            this.rbtnCaNhan.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(591, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(7, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(578, 20);
            this.txtTimKiem.TabIndex = 0;
            // 
            // grbThongTinChuyenDi
            // 
            this.grbThongTinChuyenDi.Controls.Add(this.cbbNguoiThucHien);
            this.grbThongTinChuyenDi.Controls.Add(this.txtLyDoChuyenDi);
            this.grbThongTinChuyenDi.Controls.Add(this.txtDiaChiChuyenDen);
            this.grbThongTinChuyenDi.Controls.Add(this.dateTimeNgayChuyenDi);
            this.grbThongTinChuyenDi.Controls.Add(this.lblNguoiThucHien);
            this.grbThongTinChuyenDi.Controls.Add(this.lblLyDo);
            this.grbThongTinChuyenDi.Controls.Add(this.lblDiaChiChuyenDen);
            this.grbThongTinChuyenDi.Controls.Add(this.lblNgayChuyenDi);
            this.grbThongTinChuyenDi.Location = new System.Drawing.Point(12, 343);
            this.grbThongTinChuyenDi.Name = "grbThongTinChuyenDi";
            this.grbThongTinChuyenDi.Size = new System.Drawing.Size(499, 250);
            this.grbThongTinChuyenDi.TabIndex = 1;
            this.grbThongTinChuyenDi.TabStop = false;
            this.grbThongTinChuyenDi.Text = "Thông tin chuyển đi";
            // 
            // txtLyDoChuyenDi
            // 
            this.txtLyDoChuyenDi.Location = new System.Drawing.Point(98, 92);
            this.txtLyDoChuyenDi.Name = "txtLyDoChuyenDi";
            this.txtLyDoChuyenDi.Size = new System.Drawing.Size(395, 20);
            this.txtLyDoChuyenDi.TabIndex = 6;
            // 
            // txtDiaChiChuyenDen
            // 
            this.txtDiaChiChuyenDen.Location = new System.Drawing.Point(132, 58);
            this.txtDiaChiChuyenDen.Name = "txtDiaChiChuyenDen";
            this.txtDiaChiChuyenDen.Size = new System.Drawing.Size(361, 20);
            this.txtDiaChiChuyenDen.TabIndex = 5;
            // 
            // dateTimeNgayChuyenDi
            // 
            this.dateTimeNgayChuyenDi.Location = new System.Drawing.Point(97, 23);
            this.dateTimeNgayChuyenDi.Name = "dateTimeNgayChuyenDi";
            this.dateTimeNgayChuyenDi.Size = new System.Drawing.Size(200, 20);
            this.dateTimeNgayChuyenDi.TabIndex = 4;
            // 
            // lblNguoiThucHien
            // 
            this.lblNguoiThucHien.AutoSize = true;
            this.lblNguoiThucHien.Location = new System.Drawing.Point(7, 129);
            this.lblNguoiThucHien.Name = "lblNguoiThucHien";
            this.lblNguoiThucHien.Size = new System.Drawing.Size(85, 13);
            this.lblNguoiThucHien.TabIndex = 3;
            this.lblNguoiThucHien.Text = "Người thực hiện:";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(6, 95);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(86, 13);
            this.lblLyDo.TabIndex = 2;
            this.lblLyDo.Text = "Lý do chuyển đi:";
            // 
            // lblDiaChiChuyenDen
            // 
            this.lblDiaChiChuyenDen.AutoSize = true;
            this.lblDiaChiChuyenDen.Location = new System.Drawing.Point(6, 61);
            this.lblDiaChiChuyenDen.Name = "lblDiaChiChuyenDen";
            this.lblDiaChiChuyenDen.Size = new System.Drawing.Size(120, 13);
            this.lblDiaChiChuyenDen.TabIndex = 1;
            this.lblDiaChiChuyenDen.Text = "Địa chỉ nơi chuyển đến:";
            // 
            // lblNgayChuyenDi
            // 
            this.lblNgayChuyenDi.AutoSize = true;
            this.lblNgayChuyenDi.Location = new System.Drawing.Point(6, 29);
            this.lblNgayChuyenDi.Name = "lblNgayChuyenDi";
            this.lblNgayChuyenDi.Size = new System.Drawing.Size(85, 13);
            this.lblNgayChuyenDi.TabIndex = 0;
            this.lblNgayChuyenDi.Text = "Ngày chuyển đi:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(517, 343);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(168, 39);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận chuyển đi";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(517, 394);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(168, 42);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // cbbNguoiThucHien
            // 
            this.cbbNguoiThucHien.FormattingEnabled = true;
            this.cbbNguoiThucHien.Location = new System.Drawing.Point(98, 126);
            this.cbbNguoiThucHien.Name = "cbbNguoiThucHien";
            this.cbbNguoiThucHien.Size = new System.Drawing.Size(395, 21);
            this.cbbNguoiThucHien.TabIndex = 7;
            // 
            // frmChuyenDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 605);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.grbThongTinChuyenDi);
            this.Controls.Add(this.grbThongTinHoKhau);
            this.Name = "frmChuyenDi";
            this.Text = "Chuyển đi";
            this.grbThongTinHoKhau.ResumeLayout(false);
            this.grbThongTinHoKhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbThongTinChuyenDi.ResumeLayout(false);
            this.grbThongTinChuyenDi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTinHoKhau;
        private System.Windows.Forms.RadioButton rbtnCaNhan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuanHe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.RadioButton rbtnChuyenToanBo;
        private System.Windows.Forms.GroupBox grbThongTinChuyenDi;
        private System.Windows.Forms.Label lblNguoiThucHien;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.Label lblDiaChiChuyenDen;
        private System.Windows.Forms.Label lblNgayChuyenDi;
        private System.Windows.Forms.TextBox txtLyDoChuyenDi;
        private System.Windows.Forms.TextBox txtDiaChiChuyenDen;
        private System.Windows.Forms.DateTimePicker dateTimeNgayChuyenDi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cbbNguoiThucHien;
    }
}