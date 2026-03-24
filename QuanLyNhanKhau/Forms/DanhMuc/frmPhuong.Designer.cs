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
            this.grbTTPhuong = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvPhuong = new System.Windows.Forms.DataGridView();
            this.MaPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.lblDangChon = new System.Windows.Forms.Label();
            this.grbTTPhuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuong)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTTPhuong
            // 
            this.grbTTPhuong.Controls.Add(this.txtGhiChu);
            this.grbTTPhuong.Controls.Add(this.lblGhiChu);
            this.grbTTPhuong.Controls.Add(this.txtSDT);
            this.grbTTPhuong.Controls.Add(this.lblSDT);
            this.grbTTPhuong.Controls.Add(this.txtTen);
            this.grbTTPhuong.Controls.Add(this.lblTen);
            this.grbTTPhuong.Controls.Add(this.txtMa);
            this.grbTTPhuong.Controls.Add(this.lblMa);
            this.grbTTPhuong.Location = new System.Drawing.Point(0, 0);
            this.grbTTPhuong.Name = "grbTTPhuong";
            this.grbTTPhuong.Size = new System.Drawing.Size(788, 130);
            this.grbTTPhuong.TabIndex = 0;
            this.grbTTPhuong.TabStop = false;
            this.grbTTPhuong.Text = "Thông tin Phường";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(3, 24);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(75, 16);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã Phường";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(95, 18);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(100, 22);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(3, 52);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(80, 16);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên Phường";
            this.lblTen.Click += new System.EventHandler(this.lblTen_Click);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(95, 46);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 22);
            this.txtTen.TabIndex = 3;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(6, 80);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(66, 16);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "Điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(95, 74);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 22);
            this.txtSDT.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(6, 105);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 16);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(95, 102);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(100, 22);
            this.txtGhiChu.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 136);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(95, 136);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(176, 136);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(257, 136);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(487, 136);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // dgvPhuong
            // 
            this.dgvPhuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhuong,
            this.TenPhuong,
            this.Dienthoai,
            this.Ghichu});
            this.dgvPhuong.Location = new System.Drawing.Point(12, 176);
            this.dgvPhuong.Name = "dgvPhuong";
            this.dgvPhuong.RowHeadersWidth = 51;
            this.dgvPhuong.RowTemplate.Height = 24;
            this.dgvPhuong.Size = new System.Drawing.Size(550, 150);
            this.dgvPhuong.TabIndex = 6;
            this.dgvPhuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhuong_CellContentClick);
            // 
            // MaPhuong
            // 
            this.MaPhuong.HeaderText = "Mã Phường";
            this.MaPhuong.MinimumWidth = 6;
            this.MaPhuong.Name = "MaPhuong";
            this.MaPhuong.Width = 125;
            // 
            // TenPhuong
            // 
            this.TenPhuong.HeaderText = "Tên Phường";
            this.TenPhuong.MinimumWidth = 6;
            this.TenPhuong.Name = "TenPhuong";
            this.TenPhuong.Width = 125;
            // 
            // Dienthoai
            // 
            this.Dienthoai.HeaderText = "Điện thoại";
            this.Dienthoai.MinimumWidth = 6;
            this.Dienthoai.Name = "Dienthoai";
            this.Dienthoai.Width = 125;
            // 
            // Ghichu
            // 
            this.Ghichu.HeaderText = "Ghi chú";
            this.Ghichu.MinimumWidth = 6;
            this.Ghichu.Name = "Ghichu";
            this.Ghichu.Width = 125;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(9, 339);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(105, 16);
            this.lblTongSo.TabIndex = 7;
            this.lblTongSo.Text = "Tổng số phường";
            // 
            // lblDangChon
            // 
            this.lblDangChon.AutoSize = true;
            this.lblDangChon.Location = new System.Drawing.Point(173, 339);
            this.lblDangChon.Name = "lblDangChon";
            this.lblDangChon.Size = new System.Drawing.Size(74, 16);
            this.lblDangChon.TabIndex = 8;
            this.lblDangChon.Text = "Đang chọn:";
            // 
            // frmPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDangChon);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.dgvPhuong);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbTTPhuong);
            this.Name = "frmPhuong";
            this.Text = "Quản lí Phường";
            this.grbTTPhuong.ResumeLayout(false);
            this.grbTTPhuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTTPhuong;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ghichu;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Label lblDangChon;
    }
}