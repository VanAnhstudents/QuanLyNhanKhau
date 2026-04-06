using QuanLyNhanKhau.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.NghiepVu
{
    public partial class frmChuyenDen : Form
    {
        // Bảng lưu người phụ thuộc nhập trên grid trước khi lưu DB
        private DataTable _dependentsTable;

        public frmChuyenDen()
        {
            InitializeComponent();
            Load += frmChuyenDen_Load;
            btnTaoMoi.Click += btnTaoMoi_Click;
            btnHuy.Click += (s, e) => Close();
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────
        private void frmChuyenDen_Load(object sender, EventArgs e)
        {
            dateTimeNgaySinh.Value = DateTime.Today.AddYears(-20);
            dateTimeNgayDangKy.Value = DateTime.Today;

            LoadToDanPho();
            SetupDependentsGrid();
        }

        private void LoadToDanPho()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllTDP", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);

                        cbbToDanPho.DisplayMember = "TenTDP";
                        cbbToDanPho.ValueMember = "MaTDP";
                        cbbToDanPho.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tổ dân phố: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDependentsGrid()
        {
            _dependentsTable = new DataTable();
            _dependentsTable.Columns.Add("HoTen", typeof(string));
            _dependentsTable.Columns.Add("NgaySinh", typeof(string));
            _dependentsTable.Columns.Add("GioiTinh", typeof(string));
            _dependentsTable.Columns.Add("QuanHe", typeof(string));

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _dependentsTable;
            dataGridView1.AllowUserToAddRows = true;

            HoTen.DataPropertyName = "HoTen";
            NgaySinh.DataPropertyName = "NgaySinh";
            GioiTinh.DataPropertyName = "GioiTinh";
            QuanHe.DataPropertyName = "QuanHe";
        }

        // ─────────────────────────────────────────────────────────────
        // TẠO NHÂN KHẨU MỚI (CHUYỂN ĐẾN)
        // ─────────────────────────────────────────────────────────────
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (MessageBox.Show("Xác nhận tạo hồ sơ nhân khẩu mới?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            bool gioiTinhNam = rbtnNam.Checked;
            int maTDP = (int)cbbToDanPho.SelectedValue;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // ① Tạo chủ hộ + ghi biến động "Chuyển đến"
                    int maNKMoi = CreateChuHo(conn, gioiTinhNam, maTDP);

                    // ② Thêm từng người phụ thuộc (nếu có)
                    foreach (DataRow row in _dependentsTable.Rows)
                    {
                        string hoTen = row["HoTen"]?.ToString().Trim();
                        if (string.IsNullOrEmpty(hoTen)) continue;

                        AddNguoiPhuThuoc(conn, maNKMoi, row);
                    }
                }

                MessageBox.Show("Tạo hồ sơ nhân khẩu chuyển đến thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo hồ sơ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CreateChuHo(SqlConnection conn, bool gioiTinhNam, int maTDP)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ChuyenDen", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimeNgaySinh.Value.Date);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinhNam ? 1 : 0);
                cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text.Trim());
                cmd.Parameters.AddWithValue("@NoiLamViec", txtNoiLamViec.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@DienThoai", txtSoDienThoai.Text.Trim());
                cmd.Parameters.AddWithValue("@MaTDP", maTDP);
                cmd.Parameters.AddWithValue("@NgayDangKy", dateTimeNgayDangKy.Value.Date);
                cmd.Parameters.AddWithValue("@LyDo", txtLyDoChuyenDen.Text.Trim());
                cmd.Parameters.AddWithValue("@NguoiThucHien", txtNguoiThucHien.Text.Trim());

                SqlParameter outMaNK = new SqlParameter("@MaNK_Moi", SqlDbType.Int)
                { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outMaNK);

                cmd.ExecuteNonQuery();
                return (int)outMaNK.Value;
            }
        }

        private void AddNguoiPhuThuoc(SqlConnection conn, int maNK, DataRow row)
        {
            // Xử lý ngày sinh – người dùng nhập chuỗi dd/MM/yyyy hoặc để trống
            DateTime ngaySinh = DateTime.Today;
            if (!string.IsNullOrWhiteSpace(row["NgaySinh"]?.ToString()))
                DateTime.TryParseExact(row["NgaySinh"].ToString(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out ngaySinh);

            bool gioiTinh = row["GioiTinh"]?.ToString().Trim().ToLower() != "nữ";

            using (SqlCommand cmd = new SqlCommand("sp_ThemNguoiPhuThuoc", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNK", maNK);
                cmd.Parameters.AddWithValue("@HoTen", row["HoTen"].ToString().Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.Date);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ? 1 : 0);
                cmd.Parameters.AddWithValue("@NgheNghiep", DBNull.Value);
                cmd.Parameters.AddWithValue("@QuanHe", row["QuanHe"]?.ToString().Trim() ?? "Khác");
                cmd.ExecuteNonQuery();
            }
        }

        // ─────────────────────────────────────────────────────────────
        // VALIDATION
        // ─────────────────────────────────────────────────────────────
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (!rbtnNam.Checked && !rbtnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            if (cbbToDanPho.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tổ dân phố.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNguoiThucHien.Text))
            {
                MessageBox.Show("Vui lòng nhập người thực hiện.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiThucHien.Focus();
                return false;
            }
            return true;
        }

        private void ResetForm()
        {
            txtHoTen.Clear();
            txtNgheNghiep.Clear();
            txtNoiLamViec.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtLyDoChuyenDen.Clear();
            txtNguoiThucHien.Clear();
            rbtnNam.Checked = false;
            rbtnNu.Checked = false;
            dateTimeNgaySinh.Value = DateTime.Today.AddYears(-20);
            dateTimeNgayDangKy.Value = DateTime.Today;
            _dependentsTable.Rows.Clear();
        }
    }
}
