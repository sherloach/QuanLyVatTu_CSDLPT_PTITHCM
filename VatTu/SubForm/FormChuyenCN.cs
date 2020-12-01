using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu.SubForm
{
    public partial class FormChuyenCN : DevExpress.XtraEditors.XtraForm
    {
        public FormChuyenCN()
        {
            InitializeComponent();
            //comboBox_ChiNhanh.Items.RemoveAt(Program.mChinhanh);
        }

        private void FormChuyenCN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
        }

        private void ComboBox_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public delegate void GETDATA(String index);
        public GETDATA mydata;
        private void Button_confirm_Click(object sender, EventArgs e)
        {
            if (comboBox_ChiNhanh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh cần chuyển", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_ChiNhanh.Focus();
                return;
            }
            else
            {
                mydata(comboBox_ChiNhanh.SelectedValue.ToString());
            }
        }

        private void FormChuyenCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Enabled = true;
        }
    }
}
