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
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.lblDangChon = new System.Windows.Forms.Label();
            this.txtTongsoPhuong = new System.Windows.Forms.TextBox();
            this.txtDangchon = new System.Windows.Forms.TextBox();
            this.listPhuong = new System.Windows.Forms.ListView();
            this.grbTTPhuong.SuspendLayout();
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
            this.grbTTPhuong.Location = new System.Drawing.Point(11, 11);
            this.grbTTPhuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbTTPhuong.Name = "grbTTPhuong";
            this.grbTTPhuong.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grbTTPhuong.Size = new System.Drawing.Size(578, 151);
            this.grbTTPhuong.TabIndex = 0;
            this.grbTTPhuong.TabStop = false;
            this.grbTTPhuong.Text = "Thông tin Phường";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(68, 109);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(487, 38);
            this.txtGhiChu.TabIndex = 7;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 112);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            this.lblGhiChu.Click += new System.EventHandler(this.lblGhiChu_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(79, 85);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(476, 20);
            this.txtSDT.TabIndex = 5;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(20, 88);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(58, 13);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "Điện thoại:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(90, 48);
            this.txtTen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(465, 20);
            this.txtTen.TabIndex = 3;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(20, 51);
            this.lblTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(69, 13);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên Phường:";
            this.lblTen.Click += new System.EventHandler(this.lblTen_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(86, 17);
            this.txtMa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(58, 20);
            this.txtMa.TabIndex = 1;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(20, 20);
            this.lblMa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(65, 13);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã Phường:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(11, 166);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 31);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(85, 166);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(70, 31);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(159, 166);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(70, 31);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(445, 166);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(70, 31);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(519, 166);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(70, 31);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(8, 417);
            this.lblTongSo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(88, 13);
            this.lblTongSo.TabIndex = 7;
            this.lblTongSo.Text = "Tổng số phường:";
            // 
            // lblDangChon
            // 
            this.lblDangChon.AutoSize = true;
            this.lblDangChon.Location = new System.Drawing.Point(442, 417);
            this.lblDangChon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDangChon.Name = "lblDangChon";
            this.lblDangChon.Size = new System.Drawing.Size(63, 13);
            this.lblDangChon.TabIndex = 8;
            this.lblDangChon.Text = "Đang chọn:";
            // 
            // txtTongsoPhuong
            // 
            this.txtTongsoPhuong.Location = new System.Drawing.Point(98, 414);
            this.txtTongsoPhuong.Name = "txtTongsoPhuong";
            this.txtTongsoPhuong.Size = new System.Drawing.Size(32, 20);
            this.txtTongsoPhuong.TabIndex = 9;
            // 
            // txtDangchon
            // 
            this.txtDangchon.Location = new System.Drawing.Point(510, 414);
            this.txtDangchon.Name = "txtDangchon";
            this.txtDangchon.Size = new System.Drawing.Size(32, 20);
            this.txtDangchon.TabIndex = 10;
            // 
            // listPhuong
            // 
            this.listPhuong.HideSelection = false;
            this.listPhuong.Location = new System.Drawing.Point(11, 203);
            this.listPhuong.Name = "listPhuong";
            this.listPhuong.Size = new System.Drawing.Size(578, 205);
            this.listPhuong.TabIndex = 11;
            this.listPhuong.UseCompatibleStateImageBehavior = false;
            // 
            // frmPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 439);
            this.Controls.Add(this.listPhuong);
            this.Controls.Add(this.txtDangchon);
            this.Controls.Add(this.txtTongsoPhuong);
            this.Controls.Add(this.lblDangChon);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbTTPhuong);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPhuong";
            this.Text = "Quản lí Phường";
            this.grbTTPhuong.ResumeLayout(false);
            this.grbTTPhuong.PerformLayout();
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
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Label lblDangChon;
        private System.Windows.Forms.TextBox txtTongsoPhuong;
        private System.Windows.Forms.TextBox txtDangchon;
        private System.Windows.Forms.ListView listPhuong;
    }
}