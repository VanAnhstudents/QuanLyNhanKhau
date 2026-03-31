using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanKhau.Database;

namespace QuanLyNhanKhau.Forms.DanhMuc
{
    public partial class frmPhuong : Form
    {
        public frmPhuong()
        {
            InitializeComponent();

            dgvPhuong.SelectionChanged += dgvPhuong_SelectionChanged;
            this.Load += frmPhuong_Load;
        }

        private void frmPhuong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "sp_GetAllPhuong",
                    CommandType.StoredProcedure);

                dgvPhuong.Rows.Clear();

                int stt = 1;
                foreach (DataRow row in dt.Rows)
                {
                    dgvPhuong.Rows.Add(
                        stt++,                       
                        row["MaPhuong"],
                        row["TenPhuong"],
                        row["DienThoai"],
                        row["TruSo"]
                    );
                }

                txtTongsoPhuong.Text = dt.Rows.Count.ToString();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu phường: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhuong.CurrentRow != null && dgvPhuong.CurrentRow.Cells["MaPhuong"].Value != null)
            {
                txtMaphuong.Text = dgvPhuong.CurrentRow.Cells["MaPhuong"].Value.ToString();
                txtTenphuong.Text = dgvPhuong.CurrentRow.Cells["TenPhuong"].Value?.ToString() ?? "";
                txtSodienthoai.Text = dgvPhuong.CurrentRow.Cells["DienThoai"].Value?.ToString() ?? "";
                txtTruso.Text = dgvPhuong.CurrentRow.Cells["TruSo"].Value?.ToString() ?? "";

                txtDangchon.Text = (dgvPhuong.CurrentRow.Index + 1).ToString();
            }
            else
            {
                txtDangchon.Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenphuong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenPhuong", txtTenphuong.Text.Trim()),
                    new SqlParameter("@DienThoai", txtSodienthoai.Text.Trim()),
                    new SqlParameter("@TruSo", txtTruso.Text.Trim())
                };

                DatabaseHelper.ExecuteNonQuery("sp_ThemPhuong", CommandType.StoredProcedure, parameters);

                MessageBox.Show("Thêm phường thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phường: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaphuong.Text))
            {
                MessageBox.Show("Vui lòng chọn phường cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaPhuong", int.Parse(txtMaphuong.Text)),
                    new SqlParameter("@TenPhuong", txtTenphuong.Text.Trim()),
                    new SqlParameter("@DienThoai", txtSodienthoai.Text.Trim()),
                    new SqlParameter("@TruSo", txtTruso.Text.Trim())
                };

                DatabaseHelper.ExecuteNonQuery("sp_SuaPhuong", CommandType.StoredProcedure, parameters);

                MessageBox.Show("Cập nhật phường thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa phường: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaphuong.Text))
            {
                MessageBox.Show("Vui lòng chọn phường cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phường này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaPhuong", int.Parse(txtMaphuong.Text))
                };

                DatabaseHelper.ExecuteNonQuery("sp_XoaPhuong", CommandType.StoredProcedure, parameters);

                MessageBox.Show("Xóa phường thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa phường: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtMaphuong.Clear();
            txtTenphuong.Clear();
            txtSodienthoai.Clear();
            txtTruso.Clear();
            txtDangchon.Clear();
        }

        private void lblMa_Click(object sender, EventArgs e) { }
        private void grbTTPhuong_Enter(object sender, EventArgs e) { }
        private void lblTen_Click(object sender, EventArgs e) { }
        private void dgvPhuong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTen_TextChanged(object sender, EventArgs e) { }
        private void txtGhiChu_TextChanged(object sender, EventArgs e) { }
        private void lblGhiChu_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void lblDangchon_Click(object sender, EventArgs e) { }
    }
}