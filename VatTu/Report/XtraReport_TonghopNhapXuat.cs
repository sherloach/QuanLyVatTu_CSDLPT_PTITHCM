using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VatTu.Report
{
    public partial class XtraReport_TonghopNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_TonghopNhapXuat(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = from;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = to;
            this.sqlDataSource1.Fill();
        }

    }
}
