namespace QuanLyNhanKhau.Forms.DanhMuc
{
    partial class frmPhuong
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
            this.grbThongtinPhuong = new System.Windows.Forms.GroupBox();
            this.txtTruso = new System.Windows.Forms.TextBox();
            this.txtSodienthoai = new System.Windows.Forms.TextBox();
            this.txtTenphuong = new System.Windows.Forms.TextBox();
            this.txtMaphuong = new System.Windows.Forms.TextBox();
            this.lblTruso = new System.Windows.Forms.Label();
            this.lblSodienthoai = new System.Windows.Forms.Label();
            this.lblTenphuong = new System.Windows.Forms.Label();
            this.lblMaphuong = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.dgvPhuong = new System.Windows.Forms.DataGridView();
            this.iSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TruSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongsoPhuong = new System.Windows.Forms.Label();
            this.lblDangchon = new System.Windows.Forms.Label();
            this.txtTongsoPhuong = new System.Windows.Forms.TextBox();
            this.txtDangchon = new System.Windows.Forms.TextBox();
            this.grbThongtinPhuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuong)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongtinPhuong
            // 
            this.grbThongtinPhuong.Controls.Add(this.txtTruso);
            this.grbThongtinPhuong.Controls.Add(this.txtSodienthoai);
            this.grbThongtinPhuong.Controls.Add(this.txtTenphuong);
            this.grbThongtinPhuong.Controls.Add(this.txtMaphuong);
            this.grbThongtinPhuong.Controls.Add(this.lblTruso);
            this.grbThongtinPhuong.Controls.Add(this.lblSodienthoai);
            this.grbThongtinPhuong.Controls.Add(this.lblTenphuong);
            this.grbThongtinPhuong.Controls.Add(this.lblMaphuong);
            this.grbThongtinPhuong.Location = new System.Drawing.Point(13, 13);
            this.grbThongtinPhuong.Name = "grbThongtinPhuong";
            this.grbThongtinPhuong.Size = new System.Drawing.Size(575, 144);
            this.grbThongtinPhuong.TabIndex = 0;
            this.grbThongtinPhuong.TabStop = false;
            this.grbThongtinPhuong.Text = "Thông tin phường";
            // 
            // txtTruso
            // 
            this.txtTruso.Location = new System.Drawing.Point(85, 116);
            this.txtTruso.Name = "txtTruso";
            this.txtTruso.Size = new System.Drawing.Size(484, 20);
            this.txtTruso.TabIndex = 7;
            // 
            // txtSodienthoai
            // 
            this.txtSodienthoai.Location = new System.Drawing.Point(85, 91);
            this.txtSodienthoai.Name = "txtSodienthoai";
            this.txtSodienthoai.Size = new System.Drawing.Size(484, 20);
            this.txtSodienthoai.TabIndex = 6;
            // 
            // txtTenphuong
            // 
            this.txtTenphuong.Location = new System.Drawing.Point(85, 66);
            this.txtTenphuong.Name = "txtTenphuong";
            this.txtTenphuong.Size = new System.Drawing.Size(484, 20);
            this.txtTenphuong.TabIndex = 5;
            // 
            // txtMaphuong
            // 
            this.txtMaphuong.Location = new System.Drawing.Point(85, 39);
            this.txtMaphuong.Name = "txtMaphuong";
            this.txtMaphuong.ReadOnly = true;
            this.txtMaphuong.Size = new System.Drawing.Size(42, 20);
            this.txtMaphuong.TabIndex = 4;
            // 
            // lblTruso
            // 
            this.lblTruso.AutoSize = true;
            this.lblTruso.Location = new System.Drawing.Point(6, 119);
            this.lblTruso.Name = "lblTruso";
            this.lblTruso.Size = new System.Drawing.Size(40, 13);
            this.lblTruso.TabIndex = 3;
            this.lblTruso.Text = "Trụ sở:";
            // 
            // lblSodienthoai
            // 
            this.lblSodienthoai.AutoSize = true;
            this.lblSodienthoai.Location = new System.Drawing.Point(6, 94);
            this.lblSodienthoai.Name = "lblSodienthoai";
            this.lblSodienthoai.Size = new System.Drawing.Size(73, 13);
            this.lblSodienthoai.TabIndex = 2;
            this.lblSodienthoai.Text = "Số điện thoại:";
            // 
            // lblTenphuong
            // 
            this.lblTenphuong.AutoSize = true;
            this.lblTenphuong.Location = new System.Drawing.Point(6, 69);
            this.lblTenphuong.Name = "lblTenphuong";
            this.lblTenphuong.Size = new System.Drawing.Size(68, 13);
            this.lblTenphuong.TabIndex = 1;
            this.lblTenphuong.Text = "Tên phường:";
            // 
            // lblMaphuong
            // 
            this.lblMaphuong.AutoSize = true;
            this.lblMaphuong.Location = new System.Drawing.Point(6, 42);
            this.lblMaphuong.Name = "lblMaphuong";
            this.lblMaphuong.Size = new System.Drawing.Size(64, 13);
            this.lblMaphuong.TabIndex = 0;
            this.lblMaphuong.Text = "Mã phường:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(13, 163);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(94, 163);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(175, 163);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(513, 163);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLammoi
            // 
            this.btnLammoi.Location = new System.Drawing.Point(432, 163);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(75, 23);
            this.btnLammoi.TabIndex = 5;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.UseVisualStyleBackColor = true;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // dgvPhuong
            // 
            this.dgvPhuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iSTT,
            this.MaPhuong,
            this.TenPhuong,
            this.DienThoai,
            this.TruSo});
            this.dgvPhuong.Location = new System.Drawing.Point(13, 192);
            this.dgvPhuong.Name = "dgvPhuong";
            this.dgvPhuong.Size = new System.Drawing.Size(575, 292);
            this.dgvPhuong.TabIndex = 6;
            // 
            // iSTT
            // 
            this.iSTT.HeaderText = "STT";
            this.iSTT.Name = "iSTT";
            // 
            // MaPhuong
            // 
            this.MaPhuong.HeaderText = "Mã phường";
            this.MaPhuong.Name = "MaPhuong";
            // 
            // TenPhuong
            // 
            this.TenPhuong.HeaderText = "Tên phường";
            this.TenPhuong.Name = "TenPhuong";
            // 
            // DienThoai
            // 
            this.DienThoai.HeaderText = "Số điện thoại";
            this.DienThoai.Name = "DienThoai";
            // 
            // TruSo
            // 
            this.TruSo.HeaderText = "Trụ sở";
            this.TruSo.Name = "TruSo";
            // 
            // lblTongsoPhuong
            // 
            this.lblTongsoPhuong.AutoSize = true;
            this.lblTongsoPhuong.Location = new System.Drawing.Point(12, 493);
            this.lblTongsoPhuong.Name = "lblTongsoPhuong";
            this.lblTongsoPhuong.Size = new System.Drawing.Size(88, 13);
            this.lblTongsoPhuong.TabIndex = 7;
            this.lblTongsoPhuong.Text = "Tổng số phường:";
            // 
            // lblDangchon
            // 
            this.lblDangchon.AutoSize = true;
            this.lblDangchon.Location = new System.Drawing.Point(477, 493);
            this.lblDangchon.Name = "lblDangchon";
            this.lblDangchon.Size = new System.Drawing.Size(63, 13);
            this.lblDangchon.TabIndex = 8;
            this.lblDangchon.Text = "Đang chọn:";
            this.lblDangchon.Click += new System.EventHandler(this.lblDangchon_Click);
            // 
            // txtTongsoPhuong
            // 
            this.txtTongsoPhuong.Location = new System.Drawing.Point(106, 490);
            this.txtTongsoPhuong.Name = "txtTongsoPhuong";
            this.txtTongsoPhuong.ReadOnly = true;
            this.txtTongsoPhuong.Size = new System.Drawing.Size(42, 20);
            this.txtTongsoPhuong.TabIndex = 9;
            // 
            // txtDangchon
            // 
            this.txtDangchon.Location = new System.Drawing.Point(546, 490);
            this.txtDangchon.Name = "txtDangchon";
            this.txtDangchon.ReadOnly = true;
            this.txtDangchon.Size = new System.Drawing.Size(42, 20);
            this.txtDangchon.TabIndex = 10;
            // 
            // frmPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 515);
            this.Controls.Add(this.txtDangchon);
            this.Controls.Add(this.txtTongsoPhuong);
            this.Controls.Add(this.lblDangchon);
            this.Controls.Add(this.lblTongsoPhuong);
            this.Controls.Add(this.dgvPhuong);
            this.Controls.Add(this.btnLammoi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbThongtinPhuong);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPhuong";
            this.Text = "Quản lí Phường";
            this.grbThongtinPhuong.ResumeLayout(false);
            this.grbThongtinPhuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongtinPhuong;
        private System.Windows.Forms.Label lblTruso;
        private System.Windows.Forms.Label lblSodienthoai;
        private System.Windows.Forms.Label lblTenphuong;
        private System.Windows.Forms.Label lblMaphuong;
        private System.Windows.Forms.TextBox txtTenphuong;
        private System.Windows.Forms.TextBox txtMaphuong;
        private System.Windows.Forms.TextBox txtTruso;
        private System.Windows.Forms.TextBox txtSodienthoai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.DataGridView dgvPhuong;
        private System.Windows.Forms.Label lblTongsoPhuong;
        private System.Windows.Forms.Label lblDangchon;
        private System.Windows.Forms.TextBox txtTongsoPhuong;
        private System.Windows.Forms.TextBox txtDangchon;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruSo;
    }
}