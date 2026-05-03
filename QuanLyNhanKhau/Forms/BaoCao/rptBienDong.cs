using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyNhanKhau.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanKhau.Forms.BaoCao
{
    public partial class rptBienDong : Form
    {
        public rptBienDong()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public void LoadReport(DataTable dt, DateTime fromDate, DateTime toDate)
        {
            var report = new BienDong();

            report.SetDataSource(dt);

            ParameterDiscreteValue pFrom = new ParameterDiscreteValue();
            pFrom.Value = fromDate;
            report.DataDefinition.ParameterFields[0].CurrentValues.Clear();
            report.DataDefinition.ParameterFields[0].CurrentValues.Add(pFrom);

            ParameterDiscreteValue pTo = new ParameterDiscreteValue();
            pTo.Value = toDate;
            report.DataDefinition.ParameterFields[1].CurrentValues.Clear();
            report.DataDefinition.ParameterFields[1].CurrentValues.Add(pTo);

            rpt_BienDong.ReportSource = report;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (rpt_BienDong.ReportSource is ReportDocument rd)
                rd.Close();
        }
    }
}