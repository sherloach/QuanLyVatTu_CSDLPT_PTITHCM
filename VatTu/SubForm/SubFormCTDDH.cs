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
            txtMaVT.Text = ((DataRowView)bdsVT[bdsVT.Position])["MAVT"].ToString().Trim();
        }

        private void GvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = ((DataRowView)bdsVT[bdsVT.Position])["MAVT"].ToString().Trim();
        }
    }
}