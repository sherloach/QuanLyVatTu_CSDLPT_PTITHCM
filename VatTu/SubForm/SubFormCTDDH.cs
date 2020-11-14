using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VatTu.SubForm
{
    public partial class SubFormCTDDH : DevExpress.XtraEditors.XtraForm
    {
        private bool updateSuccess = false;
        public SubFormCTDDH()
        {
            InitializeComponent();
        }

        private void VattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void SubFormCTDDH_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS.Vattu);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

            this.bdsCTDDH.DataSource = Program.formLapPhieu.getBdsCTDDH();
        }

        private void SubFormCTDDH_Shown(object sender, EventArgs e)
        {
            this.bdsCTDDH.AddNew();

            BindingSource current_DDH = Program.formLapPhieu.getBdsDDH();
            string maSoDDH = getDataRow(current_DDH, "MasoDDH");
            txtMaDDH.Text = maSoDDH;
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
            numSL.Value = 1;
            numDG.Value = 0;
        }

        private void GvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int indexMaVT = bdsCTDDH.Find("MAVT", txtMaVT.Text);
                if (indexMaVT != -1 && (indexMaVT != bdsCTDDH.Position))
                {
                    MessageBox.Show("Đã tồn tại mã vật tư cùng với mã đơn hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        this.bdsCTDDH.EndEdit();
                        this.cTDDHTableAdapter.Update(Program.formLapPhieu.getDataset().CTDDH);
                        updateSuccess = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Lỗi thì phải cho AddNew, nếu không thì dữ liệu sẽ là dữ liệu của mẩu tin cuối
                        BindingSource current_DDH = Program.formLapPhieu.getBdsDDH();
                        string maSoDDH = getDataRow(current_DDH, "MasoDDH");
                        txtMaDDH.Text = maSoDDH;
                        this.bdsCTDDH.AddNew();
                        txtMaVT.Text = getDataRow(bdsVT, "MAVT");
                        numSL.Value = 1;
                        numDG.Value = 0;
                    }
                }
            }
        }

        private void SubFormCTDDH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTDDH.CancelEdit();
            Program.formMain.Enabled = true;
        }

        // ------ Validation ------
        private void NumDG_Validating(object sender, CancelEventArgs e)
        {
            if (numDG.Value == 0)
            {
                e.Cancel = true;
                numDG.Focus();
                errorProvider.SetError(numDG, "Đơn giá phải lớn hơn 0!");
            }
        }

        private void NumSL_Validating(object sender, CancelEventArgs e)
        {
            if (numSL.Value < 0)
            {
                e.Cancel = true;
                numSL.Focus();
                errorProvider.SetError(numSL, "Số lượng phải lớn hơn 0!");
            }
        }
    }
}