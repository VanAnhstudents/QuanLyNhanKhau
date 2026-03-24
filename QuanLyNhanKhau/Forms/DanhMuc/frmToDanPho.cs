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
using QuanLyNhanKhau.Database;

namespace QuanLyNhanKhau.Forms.DanhMuc
{
    public partial class frmToDanPho : Form
    {
        private int _maTDP = -1;

        public frmToDanPho()
        {
            InitializeComponent();
            
            // Register event handlers
            this.Load += FrmToDanPho_Load;
            
            this.listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            
            this.rdoXoa.CheckedChanged += UpdateControlState;
            this.rdoThem.CheckedChanged += UpdateControlState;
            this.rdoSua.CheckedChanged += UpdateControlState;

            this.btnExecute.Click += BtnExecute_Click;
            this.btnExecute.Text = "Thực hiện";
        }

        private void FrmToDanPho_Load(object sender, EventArgs e)
        {
            // Configure ListView settings
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;

            listView1.Columns.Add("Mã TDP", 60);
            listView1.Columns.Add("Tên TDP", 150);
            listView1.Columns.Add("Mã Phường", 80);
            listView1.Columns.Add("Họ Tên CSKV", 150);
            listView1.Columns.Add("SĐT CSKV", 100);
            listView1.Columns.Add("Họ Tên Tổ Trưởng", 150);
            listView1.Columns.Add("SĐT Tổ Trưởng", 100);

            // Select "Thêm" radio by default
            rdoThem.Checked = true;
            UpdateControlState(null, null);

            LoadData();
        }

        private void LoadData()
        {
            listView1.Items.Clear();
            try
            {
                // Fetch existing data using DatabaseHelper
                var dt = DatabaseHelper.ExecuteQuery("SELECT MaTDP, TenTDP, MaPhuong, HoTenCSKV, DienThoaiCSKV, HoTenToTruong, DienThoaiToTruong FROM tblTodanpho");
                
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaTDP"].ToString());
                    item.SubItems.Add(row["TenTDP"].ToString());
                    item.SubItems.Add(row["MaPhuong"].ToString());
                    item.SubItems.Add(row["HoTenCSKV"].ToString());
                    item.SubItems.Add(row["DienThoaiCSKV"].ToString());
                    item.SubItems.Add(row["HoTenToTruong"].ToString());
                    item.SubItems.Add(row["DienThoaiToTruong"].ToString());
                    
                    // Store table PK in ListViewItem.Tag for editing and deleting
                    item.Tag = row["MaTDP"].ToString();
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateControlState(object sender, EventArgs e)
        {
            // User can't edit TextBoxes if "Xóa" is selected
            bool isReadOnly = rdoXoa.Checked;
            
            txtTenTDP.ReadOnly = isReadOnly;
            txtMaPhuong.ReadOnly = isReadOnly;
            txtHoTenCSKV.ReadOnly = isReadOnly;
            txtDienThoaiCSKV.ReadOnly = isReadOnly;
            txtHoTenToTruong.ReadOnly = isReadOnly;
            txtDienThoaiToTruong.ReadOnly = isReadOnly;

            // Clear inputs when changing to "Thêm" mode
            if (sender == rdoThem && rdoThem.Checked)
            {
                ClearInputs();
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                
                // Track currently selected item's primary key
                _maTDP = int.Parse(item.Tag.ToString());
                
                txtTenTDP.Text = item.SubItems[1].Text;
                txtMaPhuong.Text = item.SubItems[2].Text;
                txtHoTenCSKV.Text = item.SubItems[3].Text;
                txtDienThoaiCSKV.Text = item.SubItems[4].Text;
                txtHoTenToTruong.Text = item.SubItems[5].Text;
                txtDienThoaiToTruong.Text = item.SubItems[6].Text;

                // Automatically change to "Sửa" mode if user clicks a column while in "Thêm" mode
                if (rdoThem.Checked)
                {
                    rdoSua.Checked = true;
                }
            }
            else
            {
                // Reset ID trigger when nothing selected
                _maTDP = -1;
            }
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoThem.Checked)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TenTDP", txtTenTDP.Text.Trim()),
                        new SqlParameter("@MaPhuong", int.Parse(txtMaPhuong.Text.Trim())),
                        new SqlParameter("@HoTenCSKV", txtHoTenCSKV.Text.Trim()),
                        new SqlParameter("@DienThoaiCSKV", txtDienThoaiCSKV.Text.Trim()),
                        new SqlParameter("@HoTenToTruong", txtHoTenToTruong.Text.Trim()),
                        new SqlParameter("@DienThoaiToTruong", txtDienThoaiToTruong.Text.Trim())
                    };
                    
                    DatabaseHelper.ExecuteNonQuery("sp_ThemTDP", CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rdoSua.Checked)
                {
                    if (_maTDP == -1)
                    {
                        MessageBox.Show("Vui lòng chọn một tổ dân phố để sửa.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaTDP", _maTDP),
                        new SqlParameter("@TenTDP", txtTenTDP.Text.Trim()),
                        new SqlParameter("@MaPhuong", int.Parse(txtMaPhuong.Text.Trim())),
                        new SqlParameter("@HoTenCSKV", txtHoTenCSKV.Text.Trim()),
                        new SqlParameter("@DienThoaiCSKV", txtDienThoaiCSKV.Text.Trim()),
                        new SqlParameter("@HoTenToTruong", txtHoTenToTruong.Text.Trim()),
                        new SqlParameter("@DienThoaiToTruong", txtDienThoaiToTruong.Text.Trim())
                    };
                    
                    DatabaseHelper.ExecuteNonQuery("sp_SuaTDP", CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rdoXoa.Checked)
                {
                    if (_maTDP == -1)
                    {
                        MessageBox.Show("Vui lòng chọn một tổ dân phố chứa thông tin bạn muốn xoá.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa tổ dân phố số {_maTDP}?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (confirm == DialogResult.Yes)
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@MaTDP", _maTDP)
                        };
                        
                        DatabaseHelper.ExecuteNonQuery("sp_XoaTDP", CommandType.StoredProcedure, parameters);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _maTDP = -1;
            txtTenTDP.Clear();
            txtMaPhuong.Clear();
            txtHoTenCSKV.Clear();
            txtDienThoaiCSKV.Clear();
            txtHoTenToTruong.Clear();
            txtDienThoaiToTruong.Clear();
            
            // Unselect the ListView items
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems.Clear();
            }
        }
    }
}
