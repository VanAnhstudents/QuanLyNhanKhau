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

namespace QuanLyNhanKhau.Forms.NhanKhau
{
    public partial class frmNguoiPhuThuoc : Form
    {
        string connStr = @"Data Source=.;Initial Catalog=QuanLyNhanKhau;Integrated Security=True";

        public frmNguoiPhuThuoc()
        {
            InitializeComponent();
        }
        void LoadChuHo()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
        SELECT 0 AS MaNK, N'-- Vui lòng chọn chủ hộ --' AS HoTen
        UNION ALL
        SELECT MaNK, HoTen FROM tblNhankhau";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboChuHo.DataSource = dt;
                cboChuHo.DisplayMember = "HoTen";
                cboChuHo.ValueMember = "MaNK";
            }
        }
        void LoadNguoiPhuThuoc(int maNK)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tblNguoi_phu_thuoc WHERE MaNK = @MaNK";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaNK", maNK);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNguoiPhuThuoc.DataSource = dt;
            }
        }

        private void cboChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuHo.SelectedValue == null || cboChuHo.SelectedValue is DataRowView)
                return;

            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tblNguoi_phu_thuoc WHERE MaNK = @MaNK";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaNK", maNK);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNguoiPhuThuoc.DataSource = dt;
            }
        }
        private void frmNguoiPhuThuoc_Load(object sender, EventArgs e)
        {
            LoadChuHo();
        }

        private void grpCac_Enter(object sender, EventArgs e)
        {

        }

        private void cboQuanHe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập họ tên!");
                return;
            }

            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
            int gioiTinh = radNam.Checked ? 1 : 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
        INSERT INTO tblNguoi_phu_thuoc
        (MaNK, HoTen, NgaySinh, GioiTinh, NgheNghiep, QuanHe)
        VALUES (@MaNK, @HoTen, @NgaySinh, @GioiTinh, @NgheNghiep, @QuanHe)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaNK", maNK);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text);
                cmd.Parameters.AddWithValue("@QuanHe", cboQuanHe.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");

                LoadNguoiPhuThuoc(maNK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNguoiPhuThuoc.CurrentRow == null) return;

            int maNPT = Convert.ToInt32(dgvNguoiPhuThuoc.CurrentRow.Cells["MaNPT"].Value);
            int gioiTinh = radNam.Checked ? 1 : 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
        UPDATE tblNguoi_phu_thuoc
        SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
            NgheNghiep=@NgheNghiep, QuanHe=@QuanHe
        WHERE MaNPT=@MaNPT";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@NgheNghiep", txtNgheNghiep.Text);
                cmd.Parameters.AddWithValue("@QuanHe", cboQuanHe.Text);
                cmd.Parameters.AddWithValue("@MaNPT", maNPT);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công!");

                int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
                LoadNguoiPhuThuoc(maNK);
            }
        }

        private void dgvNguoiPhuThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNguoiPhuThuoc.Rows[e.RowIndex];

            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            cboQuanHe.Text = row.Cells["QuanHe"].Value.ToString();
            txtNgheNghiep.Text = row.Cells["NgheNghiep"].Value.ToString();

            bool gt = Convert.ToBoolean(row.Cells["GioiTinh"].Value);
            if (gt) radNam.Checked = true;
            else radNu.Checked = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiPhuThuoc.CurrentRow == null) return;

            int maNPT = Convert.ToInt32(dgvNguoiPhuThuoc.CurrentRow.Cells["MaNPT"].Value);

            DialogResult r = MessageBox.Show("Xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (r != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "DELETE FROM tblNguoi_phu_thuoc WHERE MaNPT=@MaNPT";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNPT", maNPT);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!");

                int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
                LoadNguoiPhuThuoc(maNK);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNgheNghiep.Clear();
            cboQuanHe.SelectedIndex = -1;
            radNam.Checked = true;
        }
    }
}

