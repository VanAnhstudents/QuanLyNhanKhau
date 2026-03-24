using QuanLyNhanKhau.Forms.DanhMuc;
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
    }
}
