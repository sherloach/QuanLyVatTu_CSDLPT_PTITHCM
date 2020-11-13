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
    public partial class SubFormCTPX : DevExpress.XtraEditors.XtraForm
    {
        public SubFormCTPX()
        {
            InitializeComponent();
        }

        private void VattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void SubFormCTPX_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Fill(this.dS.CTPX);
            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.dS.Vattu);

        }
    }
}