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

namespace VatTu.Report
{
    public partial class FormSupportReport3_6 : Form
    {
        public FormSupportReport3_6()
        {
            InitializeComponent();
        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {

        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            
            XtraReport_TonghopNhapXuat report_TonghopNhapXuat = new XtraReport_TonghopNhapXuat(dateEditFrom.DateTime, dateEditTo.DateTime);
            ReportPrintTool printTool_TonghopNhapXuat = new ReportPrintTool(report_TonghopNhapXuat);
            printTool_TonghopNhapXuat.ShowPreviewDialog();
        }
    }
}
