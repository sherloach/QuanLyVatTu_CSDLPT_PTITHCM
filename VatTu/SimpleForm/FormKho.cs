using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu.SimpleForm
{
    public partial class FormKho : Form
    {
        int position = 0;
        string maCN = "";

        public FormKho()
        {
            InitializeComponent();
        }

        private void KhoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void FormKho_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS.Kho);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = btnUndo.Links[0].Visible = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = false;
            }

            maCN = (((DataRowView)bdsKho[0])["MACN"].ToString()); // lúc đúng lúc sai

            this.comboBox_ChiNhanh.DataSource = Program.bds_dspm; // DataSource của comboBox_ChiNhanh tham chiếu đến bindingSource ở LoginForm
            comboBox_ChiNhanh.DisplayMember = "TENCN";
            comboBox_ChiNhanh.ValueMember = "TENSERVER";
            comboBox_ChiNhanh.SelectedIndex = Program.mChinhanh;

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled = gcInfoKho.Enabled = false;
            //Program.flagCloseFormKho = true; //Khi load bật cho phép có thể đóng form
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
