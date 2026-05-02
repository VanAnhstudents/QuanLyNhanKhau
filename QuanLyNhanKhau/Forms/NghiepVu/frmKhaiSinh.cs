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
    public partial class frmKhaiSinh : Form
    {
        string connStr = @"Data Source=.;Initial Catalog=QuanLyNhanKhau;Integrated Security=True";
        public frmKhaiSinh()
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
        void LoadKhaiSinh(int maNK)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tblBienDong WHERE MaNK = @MaNK";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaNK", maNK);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTrenewborn.DataSource = dt;
            }
        }

        private void cboChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuHo.SelectedValue == null || cboChuHo.SelectedValue is DataRowView)
                return;

            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM tblBienDong WHERE MaNK = @MaNK";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaNK", maNK);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTrenewborn.DataSource = dt;
            }
        }
        private void frmKhaiSinh_Load(object sender, EventArgs e)
        {
            LoadChuHo(); // load chủ hộ

            radNam.Checked = true; // mặc định
        }
        private void btnDangKiKhaiSinh_Click(object sender, EventArgs e)
        {
            // ===== VALIDATE =====
            if (cboChuHo.SelectedValue == null)
            {
                MessageBox.Show("Chọn chủ hộ!");
                return;
            }

            if (txtHoTenTre.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên trẻ!");
                txtHoTenTre.Focus();
                return;
            }

            if (txtNguoiThucHien.Text.Trim() == "")
            {
                MessageBox.Show("Nhập người thực hiện!");
                return;
            }

            int maNK = Convert.ToInt32(cboChuHo.SelectedValue);
            int gioiTinh = radNam.Checked ? 1 : 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ===== 1. THÊM TRẺ =====
                    string sqlInsert = @"
            INSERT INTO tblNguoi_phu_thuoc
            (MaNK, HoTen, NgaySinh, GioiTinh, NgheNghiep, QuanHe)
            VALUES (@MaNK, @HoTen, @NgaySinh, @GioiTinh, N'Chưa đi làm', N'Con')";

                    SqlCommand cmd = new SqlCommand(sqlInsert, conn, tran);

                    cmd.Parameters.AddWithValue("@MaNK", maNK);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTenTre.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinhTre.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);

                    cmd.ExecuteNonQuery();

                    // ===== 2. GHI BIẾN ĐỘNG (BONUS) =====
                    string sqlLog = @"
            INSERT INTO tblBienDong
            (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
            VALUES (@MaNK, N'Khai sinh', @Ngay, @Nguoi, @GhiChu)";

                    SqlCommand cmdLog = new SqlCommand(sqlLog, conn, tran);

                    cmdLog.Parameters.AddWithValue("@MaNK", maNK);
                    cmdLog.Parameters.AddWithValue("@Ngay", dtpNgayKhaiSinh.Value);
                    cmdLog.Parameters.AddWithValue("@Nguoi", txtNguoiThucHien.Text);
                    cmdLog.Parameters.AddWithValue("@GhiChu",
                        "Khai sinh cho: " + txtHoTenTre.Text);

                    cmdLog.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Đăng ký khai sinh thành công!");

                    // ===== CLEAR FORM =====
                    txtHoTenTre.Clear();
                    txtNguoiThucHien.Clear();
                    txtGhiChu.Clear();
                    radNam.Checked = true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
