using CrystalDecisions.CrystalReports.Engine;
using QuanLyNhanKhau.Reports;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class rptDanhSachTheoPhuong : Form
    {
        public rptDanhSachTheoPhuong()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // Bắt chước DanhSachTheoTo: chỉ nhận DataTable + chuỗi hiển thị,
        // KHÔNG truyền/set parameter Crystal Report (tránh dialog hỏi người dùng
        // và tránh sinh thêm file DanhSachTheoPhuong1.cs, DanhSachTheoPhuong2.cs,...)
        public void LoadReport(DataTable dt, string tenPhuong, string diaChi)
        {
            var report = new DSTheoPhuong();

            // Toàn bộ dữ liệu (kể cả cột thống kê footer) đã có sẵn trong dt
            // do sp_DanhSachNhanKhauTheoPhuong trả về gộp một lần.
            report.SetDataSource(dt);

            rpt_DanhSachTheoPhuong.ReportSource = report;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (rpt_DanhSachTheoPhuong.ReportSource is ReportDocument rd)
                rd.Close();
        }
    }
}