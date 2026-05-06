using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.NhanKhau
{
    public partial class frmNguoiPhuThuoc : Form
    {

        private readonly string _connStr =
            @"Data Source=.;Initial Catalog=QuanLyNhanKhau;Integrated Security=True";


        private bool _isLoading = false;

        public frmNguoiPhuThuoc()
        {
            InitializeComponent();
        }


        private SqlConnection CreateConnection() =>
            new SqlConnection(_connStr);

        private void LoadChuHo()
        {
            _isLoading = true;                 
            try
            {
                using (SqlConnection conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("sp_GetAllNhanKhauComboBox", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboChuHo.DataSource = dt;
                    cboChuHo.DisplayMember = "HoTen";
                    cboChuHo.ValueMember = "MaNK";
                    cboChuHo.SelectedIndex = 0;  
                }
            }
            finally
            {
                _isLoading = false;            
            }
        }


        private void LoadNguoiPhuThuoc(int maNK)
        {
            using (SqlConnection conn = CreateConnection())
            using (SqlCommand cmd = new SqlCommand("sp_GetNguoiPhuThuocByNK", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNK", maNK);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNguoiPhuThuoc.DataSource = dt;
            }
        }


        private void ClearForm()
        {
            txtHoTen.Clear();
            txtNgheNghiep.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            cboQuanHe.SelectedIndex = -1;
            radNam.Checked = true;
        }


        private void frmNguoiPhuThuoc_Load(object sender, EventArgs e)
        {
            dgvNguoiPhuThuoc.AutoGenerateColumns = false;
            LoadChuHo();
        }


        private void cboChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (cboChuHo.SelectedValue == null) return;
            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
            if (maNK == 0) return;

            LoadNguoiPhuThuoc(maNK);
            ClearForm();
        }


        private void dgvNguoiPhuThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNguoiPhuThuoc.Rows[e.RowIndex];

            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtNgheNghiep.Text = row.Cells["NgheNghiep"].Value?.ToString() ?? "";
            cboQuanHe.Text = row.Cells["QuanHe"].Value?.ToString() ?? "";

            if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            else
                dtpNgaySinh.Value = DateTime.Today;

            bool isNam = row.Cells["GioiTinh"].Value != DBNull.Value
                         && Convert.ToBoolean(row.Cells["GioiTinh"].Value);
            radNam.Checked = isNam;
            radNu.Checked = !isNam;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
            int gioiTinh = radNam.Checked ? 1 : 0;

            try
            {
                using (SqlConnection conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("sp_ThemNguoiPhuThuoc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNK", maNK);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text.Trim());
                    cmd.Parameters.AddWithValue("@QuanHe", cboQuanHe.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNguoiPhuThuoc(maNK);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNguoiPhuThuoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn người phụ thuộc cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            int maNPT = Convert.ToInt32(dgvNguoiPhuThuoc.CurrentRow.Cells["MaNPT"].Value);
            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
            int gioiTinh = radNam.Checked ? 1 : 0;

            try
            {
                using (SqlConnection conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("sp_SuaNguoiPhuThuoc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNPT", maNPT);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text.Trim());
                    cmd.Parameters.AddWithValue("@QuanHe", cboQuanHe.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sửa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNguoiPhuThuoc(maNK);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiPhuThuoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn người phụ thuộc cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNPT = dgvNguoiPhuThuoc.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "";
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa \"{tenNPT}\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int maNPT = Convert.ToInt32(dgvNguoiPhuThuoc.CurrentRow.Cells["MaNPT"].Value);
            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);

            try
            {
                using (SqlConnection conn = CreateConnection())
                using (SqlCommand cmd = new SqlCommand("sp_XoaNguoiPhuThuoc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNPT", maNPT);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNguoiPhuThuoc(maNK);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateForm()
        {
            // Kiểm tra đã chọn chủ hộ chưa
            if (cboChuHo.SelectedValue == null || Convert.ToInt32(cboChuHo.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn chủ hộ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChuHo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboQuanHe.Text))
            {
                MessageBox.Show("Vui lòng chọn quan hệ với chủ hộ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboQuanHe.Focus();
                return false;
            }

            return true;
        }


        private void grpCac_Enter(object sender, EventArgs e) { }
        private void cboQuanHe_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}