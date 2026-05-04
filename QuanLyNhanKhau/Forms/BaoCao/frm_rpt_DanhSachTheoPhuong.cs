using QuanLyNhanKhau.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class frm_rpt_DanhSachTheoPhuong : Form
    {
        public frm_rpt_DanhSachTheoPhuong()
        {
            InitializeComponent();

            this.Load += frm_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnBaoCao.Click += btnBaoCao_Click;

            btnBaoCao.Enabled = false;
        }

        // ── Helper lấy MaPhuong an toàn ─────────────────────────────────────
        private int GetMaPhuong()
        {
            if (cbbChonPhuong.SelectedItem == null) return 0;
            DataRowView row = (DataRowView)cbbChonPhuong.SelectedItem;
            return Convert.ToInt32(row["MaPhuong"]);
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

            cbbChonPhuong.DataSource = null;
            cbbChonPhuong.DataSource = dt;
            cbbChonPhuong.DisplayMember = "TenPhuong";
            cbbChonPhuong.ValueMember = "MaPhuong";
            cbbChonPhuong.SelectedIndex = 0;

            dgvTheoPhuong.DataSource = null;
            btnBaoCao.Enabled = false;
        }

        // ── Lấy dữ liệu từ SP gộp ───────────────────────────────────────────
        // sp_DanhSachNhanKhauTheoPhuong trả về 1 result-set chứa đủ:
        //   cột chi tiết (danh sách nhân khẩu) + cột thống kê footer.
        private DataTable LayDuLieu()
        {
            return DatabaseHelper.ExecuteQuery(
                "sp_DanhSachNhanKhauTheoPhuong",
                CommandType.StoredProcedure,
                new SqlParameter("@MaPhuong", GetMaPhuong()));
        }

        // ── Tìm kiếm ────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = LayDuLieu();

                dgvTheoPhuong.DataSource = null;
                dgvTheoPhuong.AutoGenerateColumns = false;

                HoTen.DataPropertyName = "HoTen";
                NgaySinh.DataPropertyName = "NgaySinh";
                GioiTinh.DataPropertyName = "GioiTinh";
                TenTDP.DataPropertyName = "TenTDP";
                NgheNghiep.DataPropertyName = "NgheNghiep";
                TrangThai.DataPropertyName = "TrangThai";

                dgvTheoPhuong.DataSource = dt;

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

        // ── Làm mới ─────────────────────────────────────────────────────────
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhuong();
        }

        // ── Báo cáo ─────────────────────────────────────────────────────────
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvTheoPhuong.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tìm kiếm dữ liệu trước khi xem báo cáo.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenPhuong = cbbChonPhuong.Text;
                string diaChi = dt.Rows[0]["DiaChiTruSo"]?.ToString() ?? "";

                // Bắt chước DanhSachTheoTo: chỉ truyền dt + chuỗi hiển thị,
                // KHÔNG truyền maPhuong vào LoadReport (không còn SetParameterValue).
                var rptForm = new rptDanhSachTheoPhuong();
                rptForm.LoadReport(dt, tenPhuong, diaChi);
                rptForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}