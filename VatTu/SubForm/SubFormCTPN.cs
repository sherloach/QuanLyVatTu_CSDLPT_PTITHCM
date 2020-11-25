using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatTu.SubForm
{
    public partial class SubFormCTPN : Form
    {
        private bool updateSuccess = false;
        public SubFormCTPN()
        {
            InitializeComponent();
        }

        private void DatHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void GvCTDDH_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            int count = gvCTDDH.RowCount;
            for (int i = 0; i < count; i++)
            {
                string maVT = gvCTDDH.GetRowCellValue(i, "MAVT").ToString().Trim();
                int indexMaVT = bdsCTPN.Find("MAVT", maVT);
                if (indexMaVT != -1)
                {
                    if (e.ListSourceRow == i)
                    {
                        e.Visible = false;
                        e.Handled = true;
                    }
                }
            }
        }

        private void SubFormCTPN_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);

            this.bdsCTDDH.DataSource = Program.formLapPhieu.getBdsCTDDH();
            this.bdsCTPN.DataSource = Program.formLapPhieu.getBdsCTPN();
        }

        private void SubFormCTPN_Shown(object sender, EventArgs e)
        {
            this.bdsCTPN.AddNew();
            BindingSource current_PN = Program.formLapPhieu.getBdsPN();

            if (current_PN.Position != -1 && bdsCTDDH.Position != -1) // Cả PN và CT DDH đều có dữ liệu
            {
                txtMaPN.Text = ((DataRowView)current_PN[current_PN.Position])["MAPN"].ToString().Trim();
                txtMaVT.Text = ((DataRowView)bdsCTDDH[bdsCTDDH.Position])["MAVT"].ToString().Trim();
                numSL.Maximum = int.Parse(gvCTDDH.GetRowCellValue(bdsCTDDH.Position, "SOLUONG").ToString().Trim());
                numSL.Value = numSL.Minimum;
                numDG.Value = int.Parse(gvCTDDH.GetRowCellValue(bdsCTDDH.Position, "DONGIA").ToString().Trim()); ;
            }
        }

        private void SubFormCTPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTPN.CancelEdit();
            Program.formMain.Enabled = true;
        }

        private void GvCTDDH_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (bdsCTDDH.Position != -1) // Nếu có dữ liệu
            {
                txtMaVT.Text = gvCTDDH.GetFocusedRowCellValue(gvCTDDH.Columns["MAVT"]).ToString().Trim();
                numSL.Maximum = int.Parse(gvCTDDH.GetFocusedRowCellValue(gvCTDDH.Columns["SOLUONG"]).ToString().Trim());
                numDG.Value = int.Parse(gvCTDDH.GetFocusedRowCellValue(gvCTDDH.Columns["DONGIA"]).ToString().Trim());

                //txtMaVT.Text = gvCTDDH.GetRowCellValue(e., "MAVT").ToString().Trim();
                //numSL.Maximum = int.Parse(gvCTDDH.GetRowCellValue(g, "SOLUONG").ToString().Trim());
                //numDG.Value = int.Parse(gvCTDDH.GetRowCellValue(gvCTDDH.SelectedRowsCount, "DONGIA").ToString().Trim());
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            int indexMaVT = bdsCTPN.Find("MAVT", txtMaVT);
            if (indexMaVT != -1 && (indexMaVT != bdsCTPN.Position))
            {
                MessageBox.Show("Đã tồn tại mã vật tư này trong chi tiết phiếu nhập khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    // Lưu lại MAVT và SOLUONG để khi EndEdit không bị mất dữ liệu vì con trỏ về đầu
                    string maVT = txtMaVT.Text;
                    int soLuong = int.Parse(numSL.Value.ToString());

                    this.bdsCTPN.EndEdit();
                    this.cTPNTableAdapter.Update(Program.formLapPhieu.getDataset().CTPN);
                    String query = "DECLARE	@return_value int " +
                                   "EXEC @return_value = [dbo].[SP_UpdateSLVatTu] " +
                                   "@p1, @p2, @p3 " +
                                   "SELECT 'Return Value' = @return_value";

                    SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                    sqlCommand.Parameters.AddWithValue("@p1", maVT);
                    sqlCommand.Parameters.AddWithValue("@p2", soLuong);
                    sqlCommand.Parameters.AddWithValue("@p3", "IMPORT");

                    SqlDataReader dataReader = null;
                    try
                    {
                        dataReader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật vật tư vào Database!\n" + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataReader.Close();
                        return;
                    }
                    dataReader.Read();
                    int result_value = int.Parse(dataReader.GetValue(0).ToString());
                    dataReader.Close();
                    if (result_value == 0)
                    {
                        MessageBox.Show("Lỗi khi cập nhật Vật Tư vào Database!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        query = "DECLARE @return_value int " +
                                "EXEC @return_value = [dbo].[SP_UpdateSLVatTu] " +
                                "@p1, @p2, @p3 " +
                                "SELECT 'Return Value' = @return_value";
                        sqlCommand = new SqlCommand(query, Program.conn);
                        sqlCommand.Parameters.AddWithValue("@p1", maVT);
                        sqlCommand.Parameters.AddWithValue("@p2", soLuong);
                        sqlCommand.Parameters.AddWithValue("@p3", "EXPORT");
                        try
                        {
                            dataReader = sqlCommand.ExecuteReader();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi Rollback dữ liệu. Vui lòng truy suất Database kiểm tra lại!\n" + ex.Message, "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataReader.Close();
                            return;
                        }
                        return;
                    }
                    updateSuccess = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
