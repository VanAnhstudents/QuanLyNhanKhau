namespace QuanLyNhanKhau.Forms.NhanKhau
{
    partial class frmChuHo
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
            this.dgrChuHo = new System.Windows.Forms.DataGridView();
            this.grpThongTinChuHo = new System.Windows.Forms.GroupBox();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.txtMaTDP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpNtgaysinh = new System.Windows.Forms.DateTimePicker();
            this.txtDienthoai = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoilamviec = new System.Windows.Forms.TextBox();
            this.txtNghenghiep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MaNK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiLamViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrChuHo)).BeginInit();
            this.grpThongTinChuHo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrChuHo
            // 
            this.dgrChuHo.AllowUserToAddRows = false;
            this.dgrChuHo.AllowUserToDeleteRows = false;
            this.dgrChuHo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrChuHo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrChuHo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNK,
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.NgheNghiep,
            this.NoiLamViec,
            this.DiaChi,
            this.DienThoai,
            this.MaTDP});
            this.dgrChuHo.Location = new System.Drawing.Point(12, 308);
            this.dgrChuHo.MultiSelect = false;
            this.dgrChuHo.Name = "dgrChuHo";
            this.dgrChuHo.ReadOnly = true;
            this.dgrChuHo.RowHeadersWidth = 51;
            this.dgrChuHo.RowTemplate.Height = 24;
            this.dgrChuHo.Size = new System.Drawing.Size(1043, 221);
            this.dgrChuHo.TabIndex = 0;
            this.dgrChuHo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrChuHo_CellClick);
            // 
            // grpThongTinChuHo
            // 
            this.grpThongTinChuHo.Controls.Add(this.rdoNu);
            this.grpThongTinChuHo.Controls.Add(this.rdoNam);
            this.grpThongTinChuHo.Controls.Add(this.txtMaTDP);
            this.grpThongTinChuHo.Controls.Add(this.label9);
            this.grpThongTinChuHo.Controls.Add(this.dtpNtgaysinh);
            this.grpThongTinChuHo.Controls.Add(this.txtDienthoai);
            this.grpThongTinChuHo.Controls.Add(this.txtDiachi);
            this.grpThongTinChuHo.Controls.Add(this.label5);
            this.grpThongTinChuHo.Controls.Add(this.txtNoilamviec);
            this.grpThongTinChuHo.Controls.Add(this.txtNghenghiep);
            this.grpThongTinChuHo.Controls.Add(this.label7);
            this.grpThongTinChuHo.Controls.Add(this.label6);
            this.grpThongTinChuHo.Controls.Add(this.label4);
            this.grpThongTinChuHo.Controls.Add(this.label3);
            this.grpThongTinChuHo.Controls.Add(this.label2);
            this.grpThongTinChuHo.Controls.Add(this.label1);
            this.grpThongTinChuHo.Controls.Add(this.txtHoten);
            this.grpThongTinChuHo.Location = new System.Drawing.Point(12, 12);
            this.grpThongTinChuHo.Name = "grpThongTinChuHo";
            this.grpThongTinChuHo.Size = new System.Drawing.Size(1043, 257);
            this.grpThongTinChuHo.TabIndex = 5;
            this.grpThongTinChuHo.TabStop = false;
            this.grpThongTinChuHo.Text = "Thông tin chủ hộ";
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(185, 81);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(45, 20);
            this.rdoNu.TabIndex = 19;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Location = new System.Drawing.Point(122, 81);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(57, 20);
            this.rdoNam.TabIndex = 18;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtMaTDP
            // 
            this.txtMaTDP.Location = new System.Drawing.Point(122, 221);
            this.txtMaTDP.Name = "txtMaTDP";
            this.txtMaTDP.Size = new System.Drawing.Size(257, 22);
            this.txtMaTDP.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Mã tổ dân phố:";
            // 
            // dtpNtgaysinh
            // 
            this.dtpNtgaysinh.Location = new System.Drawing.Point(122, 53);
            this.dtpNtgaysinh.Name = "dtpNtgaysinh";
            this.dtpNtgaysinh.Size = new System.Drawing.Size(257, 22);
            this.dtpNtgaysinh.TabIndex = 15;
            // 
            // txtDienthoai
            // 
            this.txtDienthoai.Location = new System.Drawing.Point(122, 193);
            this.txtDienthoai.Name = "txtDienthoai";
            this.txtDienthoai.Size = new System.Drawing.Size(257, 22);
            this.txtDienthoai.TabIndex = 14;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(122, 165);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(257, 22);
            this.txtDiachi.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nơi làm việc:";
            // 
            // txtNoilamviec
            // 
            this.txtNoilamviec.Location = new System.Drawing.Point(122, 137);
            this.txtNoilamviec.Name = "txtNoilamviec";
            this.txtNoilamviec.Size = new System.Drawing.Size(257, 22);
            this.txtNoilamviec.TabIndex = 12;
            // 
            // txtNghenghiep
            // 
            this.txtNghenghiep.Location = new System.Drawing.Point(122, 109);
            this.txtNghenghiep.Name = "txtNghenghiep";
            this.txtNghenghiep.Size = new System.Drawing.Size(257, 22);
            this.txtNghenghiep.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Số điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Địa chỉ thường trú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nghề nghiệp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giới tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày sinh:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên chủ hộ:";
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(122, 25);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(257, 22);
            this.txtHoten.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 275);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(93, 275);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(174, 275);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MaNK
            // 
            this.MaNK.DataPropertyName = "MaNK";
            this.MaNK.HeaderText = "Mã nhân khẩu";
            this.MaNK.MinimumWidth = 6;
            this.MaNK.Name = "MaNK";
            this.MaNK.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 125;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 125;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 125;
            // 
            // NgheNghiep
            // 
            this.NgheNghiep.DataPropertyName = "NgheNghiep";
            this.NgheNghiep.HeaderText = "Nghề nghiệp";
            this.NgheNghiep.MinimumWidth = 6;
            this.NgheNghiep.Name = "NgheNghiep";
            this.NgheNghiep.Width = 125;
            // 
            // NoiLamViec
            // 
            this.NoiLamViec.DataPropertyName = "NoiLamViec";
            this.NoiLamViec.HeaderText = "Nơi làm việc";
            this.NoiLamViec.MinimumWidth = 6;
            this.NoiLamViec.Name = "NoiLamViec";
            this.NoiLamViec.Width = 125;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 125;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.MinimumWidth = 6;
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Width = 125;
            // 
            // MaTDP
            // 
            this.MaTDP.DataPropertyName = "MaTDP";
            this.MaTDP.HeaderText = "Mã tổ dân phố";
            this.MaTDP.MinimumWidth = 6;
            this.MaTDP.Name = "MaTDP";
            this.MaTDP.Width = 125;
            // 
            // frmChuHo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpThongTinChuHo);
            this.Controls.Add(this.dgrChuHo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChuHo";
            this.Text = "frmChuHo";
            this.Load += new System.EventHandler(this.frmChuHo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrChuHo)).EndInit();
            this.grpThongTinChuHo.ResumeLayout(false);
            this.grpThongTinChuHo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrChuHo;
        private System.Windows.Forms.GroupBox grpThongTinChuHo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNtgaysinh;
        private System.Windows.Forms.TextBox txtDienthoai;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtNoilamviec;
        private System.Windows.Forms.TextBox txtNghenghiep;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtMaTDP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNK;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiLamViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTDP;
    }
}