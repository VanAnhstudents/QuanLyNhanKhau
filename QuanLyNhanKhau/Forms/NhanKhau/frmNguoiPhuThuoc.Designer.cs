namespace QuanLyNhanKhau.Forms.NhanKhau
{
    partial class frmNguoiPhuThuoc
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
            this.grpNguoiPhuThuoc = new System.Windows.Forms.GroupBox();
            this.lblQuanHe = new System.Windows.Forms.Label();
            this.lblGioitinh = new System.Windows.Forms.Label();
            this.lblNgheNghiep = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.cboQuanHe = new System.Windows.Forms.ComboBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboChuHo = new System.Windows.Forms.ComboBox();
            this.dgvNguoiPhuThuoc = new System.Windows.Forms.DataGridView();
            this.lblChuho = new System.Windows.Forms.Label();
            this.grpNguoiPhuThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiPhuThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNguoiPhuThuoc
            // 
            this.grpNguoiPhuThuoc.Controls.Add(this.lblQuanHe);
            this.grpNguoiPhuThuoc.Controls.Add(this.lblGioitinh);
            this.grpNguoiPhuThuoc.Controls.Add(this.lblNgheNghiep);
            this.grpNguoiPhuThuoc.Controls.Add(this.lblNgaySinh);
            this.grpNguoiPhuThuoc.Controls.Add(this.lblHoTen);
            this.grpNguoiPhuThuoc.Controls.Add(this.txtNgheNghiep);
            this.grpNguoiPhuThuoc.Controls.Add(this.cboQuanHe);
            this.grpNguoiPhuThuoc.Controls.Add(this.radNam);
            this.grpNguoiPhuThuoc.Controls.Add(this.radNu);
            this.grpNguoiPhuThuoc.Controls.Add(this.dtpNgaySinh);
            this.grpNguoiPhuThuoc.Controls.Add(this.txtHoTen);
            this.grpNguoiPhuThuoc.Location = new System.Drawing.Point(1, 96);
            this.grpNguoiPhuThuoc.Name = "grpNguoiPhuThuoc";
            this.grpNguoiPhuThuoc.Size = new System.Drawing.Size(726, 239);
            this.grpNguoiPhuThuoc.TabIndex = 0;
            this.grpNguoiPhuThuoc.TabStop = false;
            this.grpNguoiPhuThuoc.Text = "Thông tin người phụ thuộc";
            // 
            // lblQuanHe
            // 
            this.lblQuanHe.AutoSize = true;
            this.lblQuanHe.Location = new System.Drawing.Point(11, 161);
            this.lblQuanHe.Name = "lblQuanHe";
            this.lblQuanHe.Size = new System.Drawing.Size(60, 16);
            this.lblQuanHe.TabIndex = 10;
            this.lblQuanHe.Text = "Quan Hệ";
            // 
            // lblGioitinh
            // 
            this.lblGioitinh.AutoSize = true;
            this.lblGioitinh.Location = new System.Drawing.Point(11, 95);
            this.lblGioitinh.Name = "lblGioitinh";
            this.lblGioitinh.Size = new System.Drawing.Size(54, 16);
            this.lblGioitinh.TabIndex = 9;
            this.lblGioitinh.Text = "Giới tính";
            // 
            // lblNgheNghiep
            // 
            this.lblNgheNghiep.AutoSize = true;
            this.lblNgheNghiep.Location = new System.Drawing.Point(11, 127);
            this.lblNgheNghiep.Name = "lblNgheNghiep";
            this.lblNgheNghiep.Size = new System.Drawing.Size(87, 16);
            this.lblNgheNghiep.TabIndex = 8;
            this.lblNgheNghiep.Text = "Nghề Nghiệp";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(11, 59);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(69, 16);
            this.lblNgaySinh.TabIndex = 7;
            this.lblNgaySinh.Text = "Ngày Sinh";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(11, 27);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 16);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.Location = new System.Drawing.Point(114, 121);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(100, 22);
            this.txtNgheNghiep.TabIndex = 5;
            // 
            // cboQuanHe
            // 
            this.cboQuanHe.FormattingEnabled = true;
            this.cboQuanHe.Location = new System.Drawing.Point(114, 153);
            this.cboQuanHe.Name = "cboQuanHe";
            this.cboQuanHe.Size = new System.Drawing.Size(121, 24);
            this.cboQuanHe.TabIndex = 4;
            this.cboQuanHe.SelectedIndexChanged += new System.EventHandler(this.cboQuanHe_SelectedIndexChanged);
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(93, 91);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(57, 20);
            this.radNam.TabIndex = 3;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(229, 91);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(45, 20);
            this.radNu.TabIndex = 2;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(93, 53);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaySinh.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(93, 21);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(100, 22);
            this.txtHoTen.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(25, 367);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 367);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(296, 367);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(638, 367);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // cboChuHo
            // 
            this.cboChuHo.FormattingEnabled = true;
            this.cboChuHo.Location = new System.Drawing.Point(106, 39);
            this.cboChuHo.Name = "cboChuHo";
            this.cboChuHo.Size = new System.Drawing.Size(121, 24);
            this.cboChuHo.TabIndex = 11;
            // 
            // dgvNguoiPhuThuoc
            // 
            this.dgvNguoiPhuThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiPhuThuoc.Location = new System.Drawing.Point(15, 417);
            this.dgvNguoiPhuThuoc.Name = "dgvNguoiPhuThuoc";
            this.dgvNguoiPhuThuoc.RowHeadersWidth = 51;
            this.dgvNguoiPhuThuoc.RowTemplate.Height = 24;
            this.dgvNguoiPhuThuoc.Size = new System.Drawing.Size(712, 89);
            this.dgvNguoiPhuThuoc.TabIndex = 12;
            // 
            // lblChuho
            // 
            this.lblChuho.AutoSize = true;
            this.lblChuho.Location = new System.Drawing.Point(12, 42);
            this.lblChuho.Name = "lblChuho";
            this.lblChuho.Size = new System.Drawing.Size(80, 16);
            this.lblChuho.TabIndex = 15;
            this.lblChuho.Text = "Chọn chủ hộ";
            // 
            // frmNguoiPhuThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.lblChuho);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboChuHo);
            this.Controls.Add(this.dgvNguoiPhuThuoc);
            this.Controls.Add(this.grpNguoiPhuThuoc);
            this.Name = "frmNguoiPhuThuoc";
            this.Text = "Quản Lí Người Phụ Thuộc";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmNguoiPhuThuoc_Load);
            this.grpNguoiPhuThuoc.ResumeLayout(false);
            this.grpNguoiPhuThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiPhuThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNguoiPhuThuoc;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cboQuanHe;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblGioitinh;
        private System.Windows.Forms.Label lblNgheNghiep;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private System.Windows.Forms.Label lblQuanHe;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNguoiPhuThuoc;
        private System.Windows.Forms.ComboBox cboChuHo;
        private System.Windows.Forms.Label lblChuho;
    }
}