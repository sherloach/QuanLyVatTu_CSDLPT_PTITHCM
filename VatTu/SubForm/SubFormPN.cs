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
    public partial class SubFormPN : Form
    {
        private bool updateSuccess = false;
        public SubFormPN()
        {
            InitializeComponent();
        }

        private void DatHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void SubFormPN_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS.DatHang);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.bdsPN.DataSource = Program.formLapPhieu.getBdsPN();
        }

        private void SubFormPN_Shown(object sender, EventArgs e)
        {
            this.bdsPN.AddNew();
            BindingSource current_DDH = Program.formLapPhieu.getBdsDDH();
            txtMaDDH.Text = ((DataRowView)current_DDH[current_DDH.Position])["MasoDDH"].ToString().Trim();
            txtMaKho.Text = ((DataRowView)current_DDH[current_DDH.Position])["MAKHO"].ToString().Trim();
            ((DataRowView)bdsPN[bdsPN.Position])["MANV"] = Program.maNV;
            ((DataRowView)bdsPN[bdsPN.Position])["NGAY"] = DateTime.Today;
        }

        private void SubFormPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsPN.CancelEdit();
            Program.formMain.Enabled = true;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

            }
        }

        // ------ Validation ------
        private void TxtMaPN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPN.Text))
            {
                e.Cancel = true;
                txtMaPN.Focus();
                errorProvider.SetError(txtMaPN, "Mã PN không được để trống!");
            }
            else if (txtMaPN.Text.Contains(" "))
            {
                e.Cancel = true;
                txtMaPN.Focus();
                errorProvider.SetError(txtMaPN, "Mã PN không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaPN, "");
            }
        }
    }
}
