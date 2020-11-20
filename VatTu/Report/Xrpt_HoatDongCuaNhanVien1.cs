using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace VatTu.Report
{
    public partial class Xrpt_HoatDongCuaNhanVien1 : DevExpress.XtraReports.UI.XtraReport
    {
        private int maNV;
        private DateTime from;
        private DateTime to;
        private String type;

        public Xrpt_HoatDongCuaNhanVien1()
        {
            //int maNV, DateTime from, DateTime to, String type
            this.maNV = maNV;
            this.from = from;
            this.to = to;
            this.type = type;
            InitializeComponent();
        }

        private void Xrpt_HoatDongCuaNhanVien1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            sP_RP_HoatDongCuaNhanVienTableAdapter.Connection.ConnectionString = Program.connstr;

            String query = "EXEC SP_RP_HoatDongCuaNhanVien @p1, @p2, @p3, @p4";
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", 7);
            sqlCommand.Parameters.AddWithValue("@p2", "2016-1-13");
            sqlCommand.Parameters.AddWithValue("@p3", "2020-11-20");
            sqlCommand.Parameters.AddWithValue("@p4", "X");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.DataSource = dataTable;    //Lưu ý DataSource, DataMember, DataAdapter bên Design phải để None
        }
    }
}
