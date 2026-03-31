using QuanLyNhanKhau.Forms.DanhMuc;
using QuanLyNhanKhau.Forms.NghiepVu;
using QuanLyNhanKhau.Forms.NhanKhau;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form findOpendedForm(string formID)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().Name.Equals(formID))
                    return f;
            }
            return null;
        }

        private void tổDânPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmToDanPho");
            if (f == null)
            {
                f = new frmToDanPho();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void phườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmPhuong");
            if (f == null)
            {
                f = new frmPhuong();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void chủHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmChuHo");
            if (f == null)
            {
                f = new frmChuHo();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void phụThuộcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmNguoiPhuThuoc");
            if (f == null)
            {
                f = new frmNguoiPhuThuoc();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void khaiSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmKhaiSinh");
            if (f == null)
            {
                f = new frmKhaiSinh();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void báoTửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmBaoTu");
            if (f == null)
            {
                f = new frmBaoTu();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void chuyểnĐếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmChuyenDen");
            if (f == null)
            {
                f = new frmChuyenDen();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void chuyểnĐiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmChuyenDi");
            if (f == null)
            {
                f = new frmChuyenDi();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void táchHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmTachHo");
            if (f == null)
            {
                f = new frmTachHo();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void nhậpHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findOpendedForm("frmNhapHo");
            if (f == null)
            {
                f = new frmTachHo();
                f.MdiParent = this;
            }
            f.Show();
            f.Activate();
        }

        private void theoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void theoĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void theoTổPhườngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dSTheoTổToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dSTheoPhườngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biếnĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
