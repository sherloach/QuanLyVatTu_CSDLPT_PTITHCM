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
    public partial class FormChuyenCN : Form
    {
        public FormChuyenCN()
        {
            InitializeComponent();
            comboBox_ChiNhanh.Items.RemoveAt(Program.mChinhanh);
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
                mydata(comboBox_ChiNhanh.Text);
                this.Close();
            }
        }
    }
}
