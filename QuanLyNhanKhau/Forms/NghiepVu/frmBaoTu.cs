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
    public partial class frmBaoTu : Form
    {
        private int _currentMaNK = 0;
        private int _currentMaNPT = -1;   // -1 = chưa chọn, 0 = chủ hộ, >0 = người phụ thuộc
        private DataTable _membersTable;

        public frmBaoTu()
        {
            InitializeComponent();
            Load += frmBaoTu_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXacNhanBaoTu.Click += btnXacNhanBaoTu_Click;
            btnHuy.Click += (s, e) => Close();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────
        private void frmBaoTu_Load(object sender, EventArgs e)
        {
            dateTimeNgayTuVong.Value = DateTime.Today;
            BuildMembersTable();
        }

        private void BuildMembersTable()
        {
            _membersTable = new DataTable();
            _membersTable.Columns.Add("MaNK", typeof(int));
            _membersTable.Columns.Add("MaNPT", typeof(int));
            _membersTable.Columns.Add("HoTen", typeof(string));
            _membersTable.Columns.Add("GioiTinh", typeof(string));
            _membersTable.Columns.Add("QuanHe", typeof(string));
            _membersTable.Columns.Add("NgheNghiep", typeof(string));
            _membersTable.Columns.Add("TrangThai", typeof(string));

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = _membersTable;

            HoTen.DataPropertyName = "HoTen";
            GioiTinh.DataPropertyName = "GioiTinh";
            QuanHe.DataPropertyName = "QuanHe";
            NgheNghiep.DataPropertyName = "NgheNghiep";
            TrangThai.DataPropertyName = "TrangThai";
        }

        // ─────────────────────────────────────────────────────────────
        // NGƯỜI THỰC HIỆN — load HoTenCSKV + HoTenToTruong của TDP
        // thuộc hộ đang làm việc
        // ─────────────────────────────────────────────────────────────
        private void LoadNguoiThucHien(int maNK)
        {
            cbbNguoiThucHien.Items.Clear();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    const string sql = @"
                        SELECT t.HoTenCSKV, t.HoTenToTruong
                        FROM   tblTodanpho  t
                        JOIN   tblNhankhau  n ON n.MaTDP = t.MaTDP
                        WHERE  n.MaNK = @MaNK";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNK", maNK);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string cskv = dr["HoTenCSKV"]?.ToString().Trim();
                                string toTruong = dr["HoTenToTruong"]?.ToString().Trim();

                                if (!string.IsNullOrEmpty(cskv))
                                    cbbNguoiThucHien.Items.Add(cskv);
                                if (!string.IsNullOrEmpty(toTruong) && toTruong != cskv)
                                    cbbNguoiThucHien.Items.Add(toTruong);
                            }
                        }
                    }
                }

                if (cbbNguoiThucHien.Items.Count > 0)
                    cbbNguoiThucHien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải người thực hiện: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // TÌM KIẾM
        // ─────────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập họ tên để tìm kiếm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable results = new DataTable();
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_TimKiemNhanKhau", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                        new SqlDataAdapter(cmd).Fill(results);
                    }
                }

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hộ khẩu phù hợp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int maNK = results.Rows.Count == 1
                    ? (int)results.Rows[0]["MaNK"]
                    : ChooseHousehold(results);

                if (maNK > 0) LoadHousehold(maNK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ChooseHousehold(DataTable results)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "Chọn hộ khẩu";
                dlg.Size = new System.Drawing.Size(500, 300);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;

                var lb = new ListBox { Dock = DockStyle.Fill };
                var btnOk = new Button { Text = "Chọn", Dock = DockStyle.Bottom, Height = 36 };

                foreach (DataRow row in results.Rows)
                    lb.Items.Add($"{row["HoTen"]}  —  {row["DiaChi"]}");

                btnOk.Click += (s, ev) =>
                {
                    if (lb.SelectedIndex >= 0) dlg.DialogResult = DialogResult.OK;
                };

                dlg.Controls.Add(lb);
                dlg.Controls.Add(btnOk);

                if (dlg.ShowDialog(this) == DialogResult.OK && lb.SelectedIndex >= 0)
                    return (int)results.Rows[lb.SelectedIndex]["MaNK"];
            }
            return 0;
        }

        private void LoadHousehold(int maNK)
        {
            _currentMaNK = maNK;
            _currentMaNPT = -1;
            _membersTable.Rows.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetThanhVienHo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNK", maNK);

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            // Chỉ hiển thị thành viên còn đang cư trú
                            if (row["TrangThai"].ToString() == "Đang cư trú")
                            {
                                _membersTable.Rows.Add(
                                    row["MaNK"], row["MaNPT"], row["HoTen"],
                                    row["GioiTinh"], row["QuanHe"],
                                    row["NgheNghiep"], row["TrangThai"]
                                );
                            }
                        }
                    }
                }

                // Load CSKV / Tổ trưởng của TDP thuộc hộ này
                LoadNguoiThucHien(maNK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thành viên hộ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // CHỌN THÀNH VIÊN TRONG LƯỚI
        // ─────────────────────────────────────────────────────────────
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _membersTable.Rows.Count) return;

            _currentMaNPT = (int)_membersTable.Rows[e.RowIndex]["MaNPT"];
        }

        // ─────────────────────────────────────────────────────────────
        // XÁC NHẬN BÁO TỬ
        // ─────────────────────────────────────────────────────────────
        private void btnXacNhanBaoTu_Click(object sender, EventArgs e)
        {
            if (_currentMaNK == 0)
            {
                MessageBox.Show("Vui lòng tìm kiếm và chọn hộ khẩu trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_currentMaNPT < 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần báo tử trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập nguyên nhân tử vong.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbbNguoiThucHien.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập người thực hiện.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenNguoiMat = _membersTable.Rows[dataGridView1.CurrentCell.RowIndex]["HoTen"].ToString();
            string xacNhanMsg = $"Xác nhận báo tử cho: {tenNguoiMat}?";

            if (MessageBox.Show(xacNhanMsg, "Xác nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

            string ghiChu = $"Ngày tử vong: {dateTimeNgayTuVong.Value:dd/MM/yyyy}. " +
                            $"Nguyên nhân: {textBox1.Text.Trim()}. " +
                            $"Nơi tử vong: {textBox2.Text.Trim()}.";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_BaoTu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNK", _currentMaNK);
                        cmd.Parameters.AddWithValue("@MaNPT",
                            _currentMaNPT == 0 ? (object)DBNull.Value : _currentMaNPT);
                        cmd.Parameters.AddWithValue("@NguoiThucHien", cbbNguoiThucHien.Text.Trim());
                        cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Báo tử thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _currentMaNPT = -1;
                textBox1.Clear();
                textBox2.Clear();
                LoadHousehold(_currentMaNK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi báo tử: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
