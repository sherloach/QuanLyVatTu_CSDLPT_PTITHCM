using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu
{
    public partial class Frpt_PhieuNvLapTrongNamTheoLoai : Form
    {
        public Frpt_PhieuNvLapTrongNamTheoLoai()
        {
            InitializeComponent();
        }

        private void Frpt_PhieuNvLapTrongNamTheoLoai_Load(object sender, EventArgs e)
        {
            comboBox_ChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            comboBox_ChiNhanh.DisplayMember = "TENCN";
            comboBox_ChiNhanh.ValueMember = "TENSERVER";
            comboBox_ChiNhanh.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "CONGTY") comboBox_ChiNhanh.Enabled = true;
            else comboBox_ChiNhanh.Enabled = false;
        }

        private void ComboBox_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            // Lấy tên server
            Program.serverName = comboBox_ChiNhanh.SelectedValue.ToString();

            // Nếu tên server khác với tên server ngoài đăng nhập, thì ta phải sử dụng HTKN
            if (comboBox_ChiNhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remoteLogin;
                Program.password = Program.remotePassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            Xrpt_PhieuLapTrongNamTheoLoai rpt = new Xrpt_PhieuLapTrongNamTheoLoai(cbLoai.Text.Substring(0, 1), int.Parse(cbNam.Text));

            rpt.lblTieuDe.Text = "DANH SÁCH PHIẾU " + cbLoai.Text.ToUpper() + " NHÂN VIÊN LẬP TRONG NĂM " + cbNam.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
