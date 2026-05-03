using QuanLyNhanKhau.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class frm_rpt_BienDong : Form
    {
        public frm_rpt_BienDong()
        {
            InitializeComponent();
            dateTimeTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimeDenNgay.Value = new DateTime(DateTime.Now.Year, 12, 31);

            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnBaoCao.Click += BtnBaoCao_Click;

            btnBaoCao.Enabled = false;
        }

        private DataTable LayDuLieu(DateTime fromDate, DateTime toDate)
        {
            return DatabaseHelper.ExecuteQuery(
                "sp_BaoCaoBienDong",
                CommandType.StoredProcedure,
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            );
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (dateTimeTuNgay.Value.Date > dateTimeDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = LayDuLieu(dateTimeTuNgay.Value, dateTimeDenNgay.Value);

                dgvBienDong.DataSource = null;
                dgvBienDong.AutoGenerateColumns = false;

                MaBD.DataPropertyName = "MaBD";
                MaNPT.DataPropertyName = "MaNPT";
                HoTen.DataPropertyName = "HoTen";
                LoaiBienDong.DataPropertyName = "LoaiBienDong";
                NgayBienDong.DataPropertyName = "NgayBienDong";
                GhiChu.DataPropertyName = "GhiChu";
                NguoiThucHien.DataPropertyName = "NguoiThucHien";

                dgvBienDong.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu biến động trong khoảng thời gian đã chọn.",
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

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            dateTimeTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dateTimeDenNgay.Value = new DateTime(DateTime.Now.Year, 12, 31);
            dgvBienDong.DataSource = null;
            btnBaoCao.Enabled = false;
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvBienDong.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tìm kiếm dữ liệu trước khi xem báo cáo.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var frmViewer = new rptBienDong();
                frmViewer.LoadReport(dt, dateTimeTuNgay.Value.Date, dateTimeDenNgay.Value.Date);
                frmViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grbDate_Enter(object sender, EventArgs e) { }
    }
}