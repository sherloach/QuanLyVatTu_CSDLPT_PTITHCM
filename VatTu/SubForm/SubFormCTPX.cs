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
using System.Data.SqlClient;

namespace VatTu.SubForm
{
    public partial class SubFormCTPX : DevExpress.XtraEditors.XtraForm
    {
        private bool updateSuccess = false;
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
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS.Vattu);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dS.CTPX);

            this.bdsCTPX.DataSource = Program.formLapPhieu.getBdsCTPX();
        }

        private void SubFormCTPX_Shown(object sender, EventArgs e)
        {
            this.bdsCTPX.AddNew();

            BindingSource current_PX = Program.formLapPhieu.getBdsPX();
            if (current_PX.Position != -1 && bdsVT.Position != -1)
            {
                txtMaPX.Text = getDataRow(current_PX, "MAPX");
                //txtMaVT.Text = getDataRow(bdsVT, "MAVT"); // không cần xét mã vt để tránh trường hợp mẩu tin đầu của vật tư có sl bằng 0.
                numSL.Maximum = int.Parse(gvVT.GetRowCellValue(bdsVT.Position, "SOLUONGTON").ToString().Trim());
                numSL.Value = numSL.Minimum;
                numDG.Value = 0;
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int indexMaVT = bdsCTPX.Find("MAVT", txtMaVT.Text);
                if (indexMaVT != -1 && (indexMaVT != bdsCTPX.Position))
                {
                    MessageBox.Show("Đã tồn tại mã vật tư cùng với mã phiếu xuất!", "Thông báo",
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

                        this.bdsCTPX.EndEdit();
                        this.cTPXTableAdapter.Update(Program.formLapPhieu.getDataset().CTPX);

                        String query = "DECLARE	@return_value int " +
                                       "EXEC @return_value = [dbo].[SP_UpdateSLVatTu] " +
                                       "@p1, @p2, @p3 " +
                                       "SELECT 'Return Value' = @return_value";

                        SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                        sqlCommand.Parameters.AddWithValue("@p1", maVT);
                        sqlCommand.Parameters.AddWithValue("@p2", soLuong);
                        sqlCommand.Parameters.AddWithValue("@p3", "EXPORT");
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
                            MessageBox.Show("Lỗi khi cập nhật vật tư vào Database!\n", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        updateSuccess = true;

                        // Push History for Undo
                        string data_backup = Program.formLapPhieu.GHI_CTP_BTN + " " + txtMaPX.Text.Trim() + " " + maVT;
                        Program.formLapPhieu.historyPX.Push(data_backup);
                        this.Close();
                        Program.formMain.timer1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void GvVT_Click(object sender, EventArgs e)
        {
            if (bdsVT.Position != -1)
            {
                int soLuong = int.Parse(gvVT.GetRowCellValue(bdsVT.Position, "SOLUONGTON").ToString().Trim());
                if (soLuong <= 0)
                {
                    MessageBox.Show("Vật tư này không còn hàng.\n Vui lòng chọn vật tư khác hoặc nhập hàng thêm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    numSL.Maximum = soLuong;
                    numSL.Minimum = 1;
                    txtMaVT.Text = gvVT.GetRowCellValue(bdsVT.Position, "MAVT").ToString().Trim();
                }
            }
        }

        private void SubFormCTPX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTPX.CancelEdit();
            Program.formMain.Enabled = true;
        }

        // ------ Validation ------
        private void NumSL_Validating(object sender, CancelEventArgs e)
        {
            if (numSL.Value < 0)
            {
                e.Cancel = true;
                numSL.Focus();
                errorProvider.SetError(numSL, "Số lượng phải lớn hơn 0!");
            }
        }

        private void NumDG_Validating(object sender, CancelEventArgs e)
        {
            if (numDG.Value == 0)
            {
                e.Cancel = true;
                numDG.Focus();
                errorProvider.SetError(numDG, "Đơn giá phải lớn hơn 0!");
            }
        }
    }

}