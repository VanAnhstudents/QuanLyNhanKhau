using QuanLyNhanKhau.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class frm_rpt_DanhSachTheoTo : Form
    {
        public frm_rpt_DanhSachTheoTo()
        {
            InitializeComponent();

            this.Load += frm_Load;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            btnTimKiem.Click += btnTimKiem_Click;
            lblDatLai.Click += lblDatLai_Click;
            btnBaoCao.Click += btnBaoCao_Click;

            btnBaoCao.Enabled = false;
        }

        // ── Helpers lấy giá trị ComboBox an toàn ────────────────────────────
        private int GetMaPhuong()
        {
            if (comboBox1.SelectedItem == null) return 0;
            DataRowView row = (DataRowView)comboBox1.SelectedItem;
            return Convert.ToInt32(row["MaPhuong"]);
        }

        private int GetMaTDP()
        {
            if (comboBox2.SelectedItem == null) return 0;
            DataRowView row = (DataRowView)comboBox2.SelectedItem;
            return Convert.ToInt32(row["MaTDP"]);
        }

        // ── Load form ────────────────────────────────────────────────────────
        private void frm_Load(object sender, EventArgs e)
        {
            LoadPhuong();
        }

        private void LoadPhuong()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "sp_GetAllPhuongForReport",
                CommandType.StoredProcedure);

            comboBox1.DataSource = null;
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenPhuong";
            comboBox1.ValueMember = "MaPhuong";
            comboBox1.SelectedIndex = 0;
        }

        // ── Đổi Phường → load lại TDP ───────────────────────────────────────
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "sp_GetTDPByPhuong",
                CommandType.StoredProcedure,
                new SqlParameter("@MaPhuong", GetMaPhuong()));

            comboBox2.DataSource = null;
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "TenTDP";
            comboBox2.ValueMember = "MaTDP";
            comboBox2.SelectedIndex = 0;

            // Reset grid và nút báo cáo khi đổi bộ lọc
            dgvDanhSachTheoTo.DataSource = null;
            btnBaoCao.Enabled = false;
        }

        // ── Lấy dữ liệu từ SP ───────────────────────────────────────────────
        private DataTable LayDuLieu()
        {
            return DatabaseHelper.ExecuteQuery(
                "sp_BaoCaoDanhSachTheoTo",
                CommandType.StoredProcedure,
                new SqlParameter("@MaPhuong", GetMaPhuong()),
                new SqlParameter("@MaTDP", GetMaTDP()));
        }

        // ── Tìm kiếm ────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = LayDuLieu();

                dgvDanhSachTheoTo.DataSource = null;
                dgvDanhSachTheoTo.AutoGenerateColumns = false;

                // Map DataPropertyName cho từng cột
                STT.DataPropertyName = "";          // tính thủ công bên dưới
                HoTen.DataPropertyName = "HoTen";
                NgaySinh.DataPropertyName = "NgaySinh";
                GioiTinh.DataPropertyName = "GioiTinh";
                NgheNghiep.DataPropertyName = "NgheNghiep";
                DiaChi.DataPropertyName = "DiaChi";
                TrangThai.DataPropertyName = "TrangThai";

                dgvDanhSachTheoTo.DataSource = dt;

                // Điền cột STT thủ công
                for (int i = 0; i < dgvDanhSachTheoTo.Rows.Count; i++)
                    dgvDanhSachTheoTo.Rows[i].Cells["STT"].Value = i + 1;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân khẩu nào.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBaoCao.Enabled = false;
                }
                else
                {
                    btnBaoCao.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Đặt lại ─────────────────────────────────────────────────────────
        private void lblDatLai_Click(object sender, EventArgs e)
        {
            LoadPhuong();
            dgvDanhSachTheoTo.DataSource = null;
            btnBaoCao.Enabled = false;
        }

        // ── Báo cáo ─────────────────────────────────────────────────────────
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvDanhSachTheoTo.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tìm kiếm dữ liệu trước khi xem báo cáo.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var frmViewer = new rptDanhSachTheoTo();
                frmViewer.LoadReport(dt, comboBox1.Text, comboBox2.Text);
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}