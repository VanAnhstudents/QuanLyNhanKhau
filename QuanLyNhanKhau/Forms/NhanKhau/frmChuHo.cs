using QuanLyNhanKhau.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.NhanKhau
{
    public partial class frmChuHo : Form
    {
        public frmChuHo()
        {
            InitializeComponent();
        }

        private int selectedMaNK = -1; // Biến lưu trữ MaNK của dòng đang được chọn

        private void frmChuHo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Truy vấn lấy dữ liệu từ bảng tblNhankhau
                // Thêm MaNK ngầm bên trong để phục vụ việc thao tác Sửa/Xóa
                string query = "SELECT MaNK, HoTen, NgaySinh, GioiTinh, NgheNghiep, NoiLamViec, DiaChi, DienThoai, MaTDP FROM tblNhankhau";
                var dt = DatabaseHelper.ExecuteQuery(query);

                dgrChuHo.AutoGenerateColumns = false;
                dgrChuHo.DataSource = dt;

                // Ẩn cột MaNK nếu DataGridView đang tự động tạo cột
                if (dgrChuHo.Columns.Contains("MaNK"))
                {
                    dgrChuHo.Columns["MaNK"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaTDP.Text) || !int.TryParse(txtMaTDP.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập Mã tổ dân phố hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtHoten.Clear();
            dtpNtgaysinh.Value = DateTime.Now;
            rdoNam.Checked = true;
            txtNghenghiep.Clear();
            txtNoilamviec.Clear();
            txtDiachi.Clear();
            txtDienthoai.Clear();
            txtMaTDP.Clear();
            selectedMaNK = -1;
        }

        private void dgrChuHo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrChuHo.Rows[e.RowIndex];

                // Lấy MaNK
                if (row.Cells["MaNK"].Value != null && row.Cells["MaNK"].Value != DBNull.Value)
                {
                    selectedMaNK = Convert.ToInt32(row.Cells["MaNK"].Value);
                }

                txtHoten.Text = row.Cells["HoTen"].Value?.ToString();

                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                    dtpNtgaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                bool gioiTinh = Convert.ToBoolean(row.Cells["GioiTinh"].Value);
                if (gioiTinh)
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;

                txtNghenghiep.Text = row.Cells["NgheNghiep"].Value?.ToString();
                txtNoilamviec.Text = row.Cells["NoiLamViec"].Value?.ToString();
                txtDiachi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtDienthoai.Text = row.Cells["DienThoai"].Value?.ToString();
                txtMaTDP.Text = row.Cells["MaTDP"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@HoTen", txtHoten.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@NgaySinh", dtpNtgaysinh.Value.Date),
                    new System.Data.SqlClient.SqlParameter("@GioiTinh", rdoNam.Checked), // True: Nam, False: Nữ
                    new System.Data.SqlClient.SqlParameter("@NgheNghiep", txtNghenghiep.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@NoiLamViec", txtNoilamviec.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", txtDiachi.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DienThoai", txtDienthoai.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MaTDP", Convert.ToInt32(txtMaTDP.Text.Trim()))
                };

                DatabaseHelper.ExecuteNonQuery("sp_ThemNhanKhau", CommandType.StoredProcedure, parameters);
                MessageBox.Show("Thêm chủ hộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaNK == -1)
            {
                MessageBox.Show("Vui lòng chọn chủ hộ cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                var parameters = new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@MaNK", selectedMaNK),
                    new System.Data.SqlClient.SqlParameter("@HoTen", txtHoten.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@NgaySinh", dtpNtgaysinh.Value.Date),
                    new System.Data.SqlClient.SqlParameter("@GioiTinh", rdoNam.Checked),
                    new System.Data.SqlClient.SqlParameter("@NgheNghiep", txtNghenghiep.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@NoiLamViec", txtNoilamviec.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DiaChi", txtDiachi.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@DienThoai", txtDienthoai.Text.Trim()),
                    new System.Data.SqlClient.SqlParameter("@MaTDP", Convert.ToInt32(txtMaTDP.Text.Trim()))
                };

                DatabaseHelper.ExecuteNonQuery("sp_SuaNhanKhau", CommandType.StoredProcedure, parameters);
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaNK == -1)
            {
                MessageBox.Show("Vui lòng chọn chủ hộ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chủ hộ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var parameters = new System.Data.SqlClient.SqlParameter[]
                    {
                        new System.Data.SqlClient.SqlParameter("@MaNK", selectedMaNK)
                    };

                    Database.DatabaseHelper.ExecuteNonQuery("sp_XoaNhanKhau", CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
