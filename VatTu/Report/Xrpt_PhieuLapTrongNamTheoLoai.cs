using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VatTu
{
    public partial class Xrpt_PhieuLapTrongNamTheoLoai : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_PhieuLapTrongNamTheoLoai(string loai, int nam)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = nam;

            this.sqlDataSource1.Fill();
        }

    }
}
