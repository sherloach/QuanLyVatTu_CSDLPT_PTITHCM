using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu.Report
{
    public partial class FormSupportReport : DevExpress.XtraEditors.XtraForm
    {
        private int choice;
        public FormSupportReport(int choice)
        {
            InitializeComponent();
            if ((choice == 4) || (choice == 1) || (choice == 6))
            {
                if (Program.mGroup != "CONGTY")
                {
                    comboBox_ChiNhanh.Visible = false;
                    pictureBox2.Visible = false;
                }
            }
            else
            {
                comboBox_ChiNhanh.Enabled = false;
                comboBox_ChiNhanh.Visible = false;
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
            }
            this.choice = choice;
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

        private void FormSupportReport_Load(object sender, EventArgs e)
        {
            this.v_DS_PHANMANHTableAdapter1.Fill(this.qLVT_DATHANGDataSet1.V_DS_PHANMANH);
        }

        private void Button_Preview_Click(object sender, EventArgs e)
        {
            switch (choice)
            {
                case 1:
                    XtraReport_DSNhanVien report = new XtraReport_DSNhanVien();
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                    break;
                /*case 2:
                    XtraReport_DSVatTu report_Vattu = new XtraReport_DSVatTu();
                    ReportPrintTool printTool_Vattu = new ReportPrintTool(report_Vattu);
                    printTool_Vattu.ShowPreviewDialog();
                    break;*/
                case 4:
                    XtraReport_DonDatHangChuaPhieuNhap report_DSkhongPN = new XtraReport_DonDatHangChuaPhieuNhap();
                    ReportPrintTool printTool_DSkhongPN = new ReportPrintTool(report_DSkhongPN);
                    printTool_DSkhongPN.ShowPreviewDialog();
                    break;
                /*case 6:
                    XtraReport_TonghopNhapXuat report_TonghopNhapXuat = new XtraReport_TonghopNhapXuat();
                    ReportPrintTool printTool_TonghopNhapXuat = new ReportPrintTool(report_TonghopNhapXuat);
                    printTool_TonghopNhapXuat.ShowPreviewDialog();
                    break;*/
            }
        }

        private void Button_Print_Click(object sender, EventArgs e)
        {
            switch (choice)
            {
                case 1:
                    XtraReport_DSNhanVien report_DSNV = new XtraReport_DSNhanVien();
                    try
                    {
                        if (File.Exists(@"D:\ReportDSNhanVien.pdf"))
                        {
                            DialogResult dr = MessageBox.Show("File ReportDSNhanVien.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                report_DSNV.ExportToPdf(@"D:\ReportDSNhanVien.pdf");
                                MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                        "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            report_DSNV.ExportToPdf(@"D:\ReportDSNhanVien.pdf");
                            MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                        "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Vui lòng đóng file ReportDSNhanVien.pdf",
                            "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                //case 2:
                //XtraReport_DSVatTu report_Vattu = new XtraReport_DSVatTu();
                /*
                try
                {
                    if (File.Exists(@"D:\ReportVattu.pdf"))
                    {
                        DialogResult dr = MessageBox.Show("File ReportVattu.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            report_Vattu.ExportToPdf(@"D:\ReportVattu.pdf");
                            MessageBox.Show("File ReportVattu.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        report_Vattu.ExportToPdf(@"D:\ReportVattu.pdf");
                        MessageBox.Show("File ReportVattu.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Vui lòng đóng file ReportVattu.pdf",
                        "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                break;*/

            case 4:
                XtraReport_DonDatHangChuaPhieuNhap report_DH = new XtraReport_DonDatHangChuaPhieuNhap();
                try
                {
                    if (File.Exists(@"D:\ReportDH.pdf"))
                    {
                        DialogResult dr = MessageBox.Show("File ReportDH.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            report_DH.ExportToPdf(@"D:\ReportDH.pdf");
                            MessageBox.Show("File ReportDH.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        report_DH.ExportToPdf(@"D:\ReportDH.pdf");
                        MessageBox.Show("File ReportDH.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Vui lòng đóng file ReportDH.pdf",
                        "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                break;
                
                /*case 6:
                    XtraReport_TonghopNhapXuat report_TonghopNhapXuat = new XtraReport_TonghopNhapXuat();
                    try
                    {
                        if (File.Exists(@"D:\ReportTonghopNhapXuat.pdf"))
                        {
                            DialogResult dr = MessageBox.Show("File ReportTonghopNhapXuat.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                report_TonghopNhapXuat.ExportToPdf(@"D:\ReportTonghopNhapXuat.pdf");
                                MessageBox.Show("File ReportTonghopNhapXuat.pdf đã được ghi thành công tại ổ D",
                        "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            report_TonghopNhapXuat.ExportToPdf(@"D:\ReportTonghopNhapXuat.pdf");
                            MessageBox.Show("File ReportTonghopNhapXuat.pdf đã được ghi thành công tại ổ D",
                        "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Vui lòng đóng file ReportTonghopNhapXuat.pdf",
                            "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                    */
            }
        }

        private void FormSupportReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Enabled = true;
        }
    }
}
