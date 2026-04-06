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
    public partial class frmTachHo : Form
    {
        private int _currentMaNK = 0;
        private DataTable _membersTable;
        private DataGridViewCheckBoxColumn _chkColumn;

        // Ánh xạ: index trong cbbChuHo → (MaNK, MaNPT, HoTen)
        private readonly List<(int MaNK, int MaNPT, string HoTen)> _chuHoCandidates
            = new List<(int, int, string)>();

        public frmTachHo()
        {
            InitializeComponent();
            Load += frmTachHo_Load;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTachHo.Click += btnTachHo_Click;
            btnHuy.Click += (s, e) => Close();
            dgvThanhVien.CellValueChanged += dgvThanhVien_CellValueChanged;
            dgvThanhVien.CurrentCellDirtyStateChanged
                                             += dgvThanhVien_DirtyStateChanged;
        }

        // ─────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────
        private void frmTachHo_Load(object sender, EventArgs e)
        {
            dateTimeNgayTach.Value = DateTime.Today;
            LoadToDanPho();
            BuildMembersTable();
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
                MessageBox.Show("Lỗi tải tổ dân phố: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildMembersTable()
        {
            _membersTable = new DataTable();
            _membersTable.Columns.Add("MaNK", typeof(int));
            _membersTable.Columns.Add("MaNPT", typeof(int));   // 0 = chủ hộ
            _membersTable.Columns.Add("HoTen", typeof(string));
            _membersTable.Columns.Add("QuanHe", typeof(string));
            _membersTable.Columns.Add("TrangThai", typeof(string));

            // Cột checkbox "Chuyển sang hộ mới"
            _chkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "colChon",
                HeaderText = "Chuyển",
                Width = 60,
                DisplayIndex = 0
            };

            dgvThanhVien.AutoGenerateColumns = false;
            dgvThanhVien.DataSource = _membersTable;

            HoTen.DataPropertyName = "HoTen";
            QuanHe.DataPropertyName = "QuanHe";
            TrangThai.DataPropertyName = "TrangThai";

            dgvThanhVien.Columns.Insert(0, _chkColumn);
        }

        // ─────────────────────────────────────────────────────────────
        // TÌM KIẾM HỘ CŨ
        // ─────────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập họ tên chủ hộ.", "Thông báo",
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
            _membersTable.Rows.Clear();
            ResetSummary();

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
                            if (row["TrangThai"].ToString() == "Đang cư trú")
                            {
                                _membersTable.Rows.Add(
                                    row["MaNK"], row["MaNPT"],
                                    row["HoTen"], row["QuanHe"], row["TrangThai"]
                                );
                            }
                        }
                    }
                }

                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thành viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // CẬP NHẬT TÓM TẮT + CbbChuHo KHI TICK/UNTICK
        // ─────────────────────────────────────────────────────────────
        private void dgvThanhVien_DirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvThanhVien.IsCurrentCellDirty)
                dgvThanhVien.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvThanhVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvThanhVien.Columns["colChon"]?.Index) return;
            UpdateSummary();
            RefreshChuHoCandidates();
        }

        private void UpdateSummary()
        {
            int total = _membersTable.Rows.Count;
            int chuyenDi = CountChecked();
            int oLai = total - chuyenDi;

            txtOLai.Text = oLai.ToString();
            txtChuyenDi.Text = chuyenDi.ToString();
        }

        private void ResetSummary()
        {
            txtOLai.Text = "0";
            txtChuyenDi.Text = "0";
            cbbChuHo.DataSource = null;
            cbbChuHo.Items.Clear();
            _chuHoCandidates.Clear();
        }

        private int CountChecked()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvThanhVien.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colChon"] as DataGridViewCheckBoxCell;
                if (cell?.Value != null && Convert.ToBoolean(cell.Value))
                    count++;
            }
            return count;
        }

        private void RefreshChuHoCandidates()
        {
            _chuHoCandidates.Clear();
            cbbChuHo.Items.Clear();

            foreach (DataGridViewRow row in dgvThanhVien.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colChon"] as DataGridViewCheckBoxCell;
                if (cell?.Value == null || !Convert.ToBoolean(cell.Value)) continue;

                int maNK = (int)_membersTable.Rows[row.Index]["MaNK"];
                int maNPT = (int)_membersTable.Rows[row.Index]["MaNPT"];
                string hoTen = _membersTable.Rows[row.Index]["HoTen"].ToString();

                _chuHoCandidates.Add((maNK, maNPT, hoTen));
                cbbChuHo.Items.Add(hoTen);
            }

            if (cbbChuHo.Items.Count > 0)
                cbbChuHo.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────────────────────────
        // THỰC HIỆN TÁCH HỘ
        // ─────────────────────────────────────────────────────────────
        private void btnTachHo_Click(object sender, EventArgs e)
        {
            if (_currentMaNK == 0)
            {
                MessageBox.Show("Vui lòng tìm kiếm và chọn hộ cũ trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CountChecked() == 0)
            {
                MessageBox.Show("Vui lòng tick chọn ít nhất một thành viên chuyển sang hộ mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbChuHo.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chủ hộ mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ hộ mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbToDanPho.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tổ dân phố hộ mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận tách hộ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var chuHo = _chuHoCandidates[cbbChuHo.SelectedIndex];
            int maTDP = (int)cbbToDanPho.SelectedValue;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            int maNKMoi = TaoHoMoi(conn, tran, chuHo, maTDP);
                            ChuyenThanhVienSangHoMoi(conn, tran, chuHo.MaNPT, maNKMoi);
                            GhiBienDong(conn, tran, _currentMaNK, maNKMoi);
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Tách hộ thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHousehold(_currentMaNK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tách hộ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo bản ghi chủ hộ mới trong tblNhankhau
        private int TaoHoMoi(SqlConnection conn, SqlTransaction tran,
            (int MaNK, int MaNPT, string HoTen) chuHo, int maTDP)
        {
            // Lấy thông tin người sẽ làm chủ hộ mới
            DataRow sourceRow = GetMemberDataRow(chuHo.MaNK, chuHo.MaNPT);

            using (SqlCommand cmd = new SqlCommand("sp_TachHo", conn, tran))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNK_Cu", _currentMaNK);
                cmd.Parameters.AddWithValue("@HoTen_Moi", chuHo.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh_Moi", sourceRow != null
                    ? (object)sourceRow["NgaySinh"] : DateTime.Today.AddYears(-20));
                cmd.Parameters.AddWithValue("@GioiTinh_Moi", sourceRow != null
                    ? (object)sourceRow["GioiTinh"] : true);
                cmd.Parameters.AddWithValue("@NgheNghiep_Moi", txtNgheNghiep.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi_Moi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@DienThoai_Moi", txtDienThoai.Text.Trim());
                cmd.Parameters.AddWithValue("@MaTDP", maTDP);
                cmd.Parameters.AddWithValue("@NguoiThucHien", "Hệ thống");

                SqlParameter outMaNK = new SqlParameter("@MaNK_Moi", SqlDbType.Int)
                { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outMaNK);

                cmd.ExecuteNonQuery();
                return (int)outMaNK.Value;
            }
        }

        // Chuyển các thành viên được tick (trừ chủ hộ mới đã được tạo riêng) sang hộ mới
        private void ChuyenThanhVienSangHoMoi(SqlConnection conn, SqlTransaction tran,
            int maNPT_ChuHoMoi, int maNKMoi)
        {
            foreach (DataGridViewRow row in dgvThanhVien.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colChon"] as DataGridViewCheckBoxCell;
                if (cell?.Value == null || !Convert.ToBoolean(cell.Value)) continue;

                int maNPT = (int)_membersTable.Rows[row.Index]["MaNPT"];

                // Chủ hộ mới đã được tạo thành bản ghi tblNhankhau, không cần chuyển lại
                if (maNPT == maNPT_ChuHoMoi) continue;

                // Chủ hộ cũ (MaNPT = 0) không thể chuyển như người phụ thuộc
                if (maNPT == 0) continue;

                using (SqlCommand cmd = new SqlCommand("sp_ChuyenNguoiPhuThuocSangHo", conn, tran))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNPT", maNPT);
                    cmd.Parameters.AddWithValue("@MaNK_Moi", maNKMoi);
                    cmd.ExecuteNonQuery();
                }
            }

            // Xóa người phụ thuộc đã trở thành chủ hộ mới khỏi hộ cũ
            if (maNPT_ChuHoMoi > 0)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM tblNguoi_phu_thuoc WHERE MaNPT = @MaNPT", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@MaNPT", maNPT_ChuHoMoi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void GhiBienDong(SqlConnection conn, SqlTransaction tran,
            int maNKCu, int maNKMoi)
        {
            string sql = @"
                INSERT INTO tblBienDong(MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
                VALUES (@MaNKCu, N'Tách hộ', GETDATE(), N'Hệ thống',
                        N'Tách ra hộ mới MaNK=' + CAST(@MaNKMoi AS NVARCHAR));
                INSERT INTO tblBienDong(MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
                VALUES (@MaNKMoi, N'Tách hộ', GETDATE(), N'Hệ thống',
                        N'Tách từ hộ MaNK=' + CAST(@MaNKCu AS NVARCHAR));";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaNKCu", maNKCu);
                cmd.Parameters.AddWithValue("@MaNKMoi", maNKMoi);
                cmd.ExecuteNonQuery();
            }
        }

        // Lấy dữ liệu gốc của một thành viên để dùng khi tạo chủ hộ mới
        private DataRow GetMemberDataRow(int maNK, int maNPT)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = maNPT == 0
                        ? "SELECT NgaySinh, GioiTinh FROM tblNhankhau WHERE MaNK = @Id"
                        : "SELECT NgaySinh, GioiTinh FROM tblNguoi_phu_thuoc WHERE MaNPT = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", maNPT == 0 ? maNK : maNPT);
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                    }
                }
            }
            catch { return null; }
        }
    }
}
