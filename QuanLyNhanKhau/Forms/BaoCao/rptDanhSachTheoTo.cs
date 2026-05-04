using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyNhanKhau.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class rptDanhSachTheoTo : Form
    {
        public rptDanhSachTheoTo()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public void LoadReport(DataTable dt, string tenPhuong, string tenTDP)
        {
            var report = new DSTheoTo();

            report.SetDataSource(dt);

            rpt_DanhSachTheoTo.ReportSource = report;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (rpt_DanhSachTheoTo.ReportSource is ReportDocument rd)
                rd.Close();
        }
    }
}