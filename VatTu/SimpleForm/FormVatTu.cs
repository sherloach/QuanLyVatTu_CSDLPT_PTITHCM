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
    public partial class FormVatTu : Form
    {
        public FormVatTu()
        {
            InitializeComponent();
        }

        private void VattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vattuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void FormVatTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS.Vattu);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = false;
                btnUndo.Links[0].Visible = btnReload.Links[0].Visible = false;
            }
        }

        private void VattuGridControl_Click(object sender, EventArgs e)
        {

        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Check ràng buộc
            if (!Validate(txtMaVT, "Mã vật tư không được để trống!")) return;
            if (!Validate(txtTenVT, "Tên vật tư không được để trống!")) return;
            if (!Validate(txtDVT, "Đơn vị tính không được để trống!")) return;

            if (txtMaVT.Text.Trim().Length > 4)
            {
                MessageBox.Show("Mã vật tư không được quá 4 kí tự!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtMaVT.Text.Contains(" "))
            {
                MessageBox.Show("Mã vật tư không được chứa khoảng trắng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int checkMaVT = vattuBindingSource.Find("TENVT", txtTenVT.Text);
            if (checkMaVT != -1 && (checkMaVT != vattuBindingSource.Position))
            {
                MessageBox.Show("Tên vật tư trùng. Vui lòng chọn tên vật tư khác!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private bool Validate(TextBox tb, string str)
        {
            if (tb.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }
    }
}
