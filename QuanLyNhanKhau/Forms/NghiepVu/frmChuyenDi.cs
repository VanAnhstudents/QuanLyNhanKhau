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
    public partial class frmChuyenDi : Form
    {
        private int _currentMaNK = 0;
        private DataTable _membersTable;
        private DataGridViewCheckBoxColumn _chkColumn;

        public frmChuyenDi()
        {
            InitializeComponent();
            Load += frmChuyenDi_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuy.Click += (s, e) => Close();
            rbtnCaNhan.CheckedChanged += rbtnCaNhan_CheckedChanged;
            rbtnChuyenToanBo.CheckedChanged += rbtnChuyenToanBo_CheckedChanged;
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────
        private void frmChuyenDi_Load(object sender, EventArgs e)
        {
            rbtnChuyenToanBo.Checked = true;
            dateTimeNgayChuyenDi.Value = DateTime.Today;
            BuildMembersTable();
        }

        private void BuildMembersTable()
        {
            _membersTable = new DataTable();
            _membersTable.Columns.Add("MaNK", typeof(int));
            _membersTable.Columns.Add("MaNPT", typeof(int));   // 0 = chủ hộ
            _membersTable.Columns.Add("HoTen", typeof(string));
            _membersTable.Columns.Add("GioiTinh", typeof(string));
            _membersTable.Columns.Add("QuanHe", typeof(string));
            _membersTable.Columns.Add("NgheNghiep", typeof(string));
            _membersTable.Columns.Add("TrangThai", typeof(string));

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _membersTable;

            HoTen.DataPropertyName = "HoTen";
            GioiTinh.DataPropertyName = "GioiTinh";
            QuanHe.DataPropertyName = "QuanHe";
            NgheNghiep.DataPropertyName = "NgheNghiep";
            TrangThai.DataPropertyName = "TrangThai";
        }

        // ─────────────────────────────────────────────────────────────
        // TÌM KIẾM HỘ KHẨU
        // ─────────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập họ tên chủ hộ để tìm kiếm.", "Thông báo",
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
                dlg.Size = new System.Drawing.Size(500, 320);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;

                var lb = new ListBox { Dock = DockStyle.Fill };
                var btnOk = new Button { Text = "Chọn", Dock = DockStyle.Bottom, Height = 36 };

                foreach (DataRow row in results.Rows)
                    lb.Items.Add($"{row["HoTen"]}  —  {row["DiaChi"]}  [{row["TrangThai"]}]");

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

        // ─────────────────────────────────────────────────────────────
        // TẢI THÀNH VIÊN HỘ
        // ─────────────────────────────────────────────────────────────
        private void LoadHousehold(int maNK)
        {
            _currentMaNK = maNK;
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
                            _membersTable.Rows.Add(
                                row["MaNK"], row["MaNPT"], row["HoTen"],
                                row["GioiTinh"], row["QuanHe"],
                                row["NgheNghiep"], row["TrangThai"]
                            );
                        }
                    }
                }

                RefreshCheckboxColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thành viên hộ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // RADIO BUTTONS
        // ─────────────────────────────────────────────────────────────
        private void rbtnCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCaNhan.Checked) AddCheckboxColumn();
        }

        private void rbtnChuyenToanBo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChuyenToanBo.Checked) RemoveCheckboxColumn();
        }

        private void RefreshCheckboxColumn()
        {
            if (rbtnCaNhan.Checked) AddCheckboxColumn();
            else RemoveCheckboxColumn();
        }

        private void AddCheckboxColumn()
        {
            if (_chkColumn != null && dataGridView1.Columns.Contains(_chkColumn)) return;

            _chkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "colChon",
                HeaderText = "Chọn",
                Width = 55,
                DisplayIndex = 0
            };
            dataGridView1.Columns.Insert(0, _chkColumn);
        }

        private void RemoveCheckboxColumn()
        {
            if (_chkColumn != null && dataGridView1.Columns.Contains(_chkColumn))
            {
                dataGridView1.Columns.Remove(_chkColumn);
                _chkColumn = null;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // XÁC NHẬN CHUYỂN ĐI
        // ─────────────────────────────────────────────────────────────
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_currentMaNK == 0)
            {
                MessageBox.Show("Vui lòng tìm kiếm và chọn hộ khẩu trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChiChuyenDen.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nơi chuyển đến.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNguoiThucHien.Text))
            {
                MessageBox.Show("Vui lòng nhập người thực hiện.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ghiChu = $"Nơi chuyển đến: {txtDiaChiChuyenDen.Text.Trim()}." +
                            $" Lý do: {txtLyDoChuyenDi.Text.Trim()}." +
                            $" Ngày: {dateTimeNgayChuyenDi.Value:dd/MM/yyyy}.";
            string nguoiThucHien = txtNguoiThucHien.Text.Trim();

            try
            {
                if (rbtnChuyenToanBo.Checked)
                    ThucHienChuyenToanBo(nguoiThucHien, ghiChu);
                else
                    ThucHienChuyenCaNhan(nguoiThucHien, ghiChu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực hiện: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThucHienChuyenToanBo(string nguoiThucHien, string ghiChu)
        {
            if (MessageBox.Show("Xác nhận chuyển toàn bộ hộ khẩu đi?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ChuyenDi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNK", _currentMaNK);
                    cmd.Parameters.AddWithValue("@NguoiThucHien", nguoiThucHien);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Chuyển toàn bộ hộ thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadHousehold(_currentMaNK);
        }

        private void ThucHienChuyenCaNhan(string nguoiThucHien, string ghiChu)
        {
            List<(int maNK, int maNPT)> selected = GetCheckedMembers();

            if (selected.Count == 0)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một thành viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận chuyển {selected.Count} thành viên đã chọn?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                foreach ((int maNK, int maNPT) in selected)
                {
                    if (maNPT == 0)
                    {
                        // Chủ hộ chuyển đi riêng (không kéo người phụ thuộc)
                        using (SqlCommand cmd = new SqlCommand("sp_ChuyenDiChuHo", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaNK", maNK);
                            cmd.Parameters.AddWithValue("@NguoiThucHien", nguoiThucHien);
                            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_ChuyenDiCaNhan", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaNPT", maNPT);
                            cmd.Parameters.AddWithValue("@NguoiThucHien", nguoiThucHien);
                            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Chuyển đi cá nhân thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadHousehold(_currentMaNK);
        }

        private List<(int maNK, int maNPT)> GetCheckedMembers()
        {
            var result = new List<(int, int)>();
            if (_chkColumn == null) return result;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colChon"] as DataGridViewCheckBoxCell;
                if (cell?.Value != null && Convert.ToBoolean(cell.Value))
                {
                    int maNK = (int)_membersTable.Rows[row.Index]["MaNK"];
                    int maNPT = (int)_membersTable.Rows[row.Index]["MaNPT"];
                    result.Add((maNK, maNPT));
                }
            }
            return result;
        }
    }
}
