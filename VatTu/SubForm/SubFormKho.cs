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
    public partial class SubFormKho : DevExpress.XtraEditors.XtraForm
    {
        public SubFormKho()
        {
            InitializeComponent();
        }

        private void KhoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void SubFormKho_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS.Kho);
        }

        private void BtnKho_Click(object sender, EventArgs e)
        {
            String maKho = ((DataRowView)bdsKho.Current)["MAKHO"].ToString();
            if (Program.formLapPhieu.btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                Program.formLapPhieu.txtMaKho_PX.Text = maKho;
            }
            else
            {
                Program.formLapPhieu.txtMaKho_DH.Text = maKho;
            }

            this.Close();
        }

        private void SubFormKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Enabled = true;
        }
    }
}