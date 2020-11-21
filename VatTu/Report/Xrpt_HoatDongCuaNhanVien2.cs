using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace VatTu.Report
{
    public partial class Xrpt_HoatDongCuaNhanVien2 : DevExpress.XtraReports.UI.XtraReport
    {
        private int maNV;
        private DateTime from;
        private DateTime to;
        private String type;

        public Xrpt_HoatDongCuaNhanVien2(int maNV, DateTime from, DateTime to, String type)
        {
            this.maNV = maNV;
            this.from = from;
            this.to = to;
            this.type = type;
            InitializeComponent();
        }

        private void Xrpt_HoatDongCuaNhanVien2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            sP_RP_HoatDongCuaNhanVienTableAdapter.Connection.ConnectionString = Program.connstr;

            String query = "EXEC SP_RP_HoatDongCuaNhanVien @p1, @p2, @p3, @p4";
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", this.maNV);
            sqlCommand.Parameters.AddWithValue("@p2", this.from);
            sqlCommand.Parameters.AddWithValue("@p3", this.to);
            sqlCommand.Parameters.AddWithValue("@p4", this.type);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.DataSource = dataTable;    //Lưu ý DataSource, DataMember, DataAdapter bên Design phải để None
        }
    }
}
