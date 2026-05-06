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
    public partial class frmLogin : Form
    {
        string connStr = @"Data Source=.;Initial Catalog=QuanLyNhanKhau;Integrated Security=True";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Nhập đầy đủ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap=@u AND MatKhau=@p";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.Hide();
                    frmMain f = new frmMain();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
            }
        }

        private void ckHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false; // hiện
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;  // ẩn
            }
        }
    }
}