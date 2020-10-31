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

namespace VatTu.SimpleForm
{
    public partial class FormVatTu : Form
    {
        int position = 0;

        public FormVatTu()
        {
            InitializeComponent();
        }

        private void FormVatTu_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại (nếu không sẽ hiện bảng cảnh báo)
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS.Vattu);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = false;
                btnUndo.Links[0].Visible = btnReload.Links[0].Visible = false;
            }
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsVatTu.Position;
            this.bdsVatTu.AddNew();
            gcInfoVatTu.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = gridVatTu.Enabled = btnReload.Enabled = false;
            btnUndo.Enabled = btnGhi.Enabled = true;

            //Program.flagCloseFormVT = false; //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
            numSLT.Value = 0;
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

            int checkMaVT = bdsVatTu.Find("TENVT", txtTenVT.Text);
            if (checkMaVT != -1 && (checkMaVT != bdsVatTu.Position))
            {
                MessageBox.Show("Tên vật tư trùng. Vui lòng chọn tên vật tư khác!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String query = "DECLARE	@return_value int " +
                           "EXEC @return_value = [dbo].[SP_CHECKID] " +
                           "@p1, @p2 " +
                           "SELECT 'Return Value' = @return_value";
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", txtMaVT.Text);
            sqlCommand.Parameters.AddWithValue("@p2", "MAVT");

            SqlDataReader dataReader = null;
            try
            {
                dataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đọc và lấy result
            dataReader.Read();
            int result_value = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();

            int indexMaVT = bdsVatTu.Find("MAVT", txtMaVT.Text);
            int indexCurrent = bdsVatTu.Position;

            if (result_value == 1 && (indexMaVT != indexCurrent))
            {
                MessageBox.Show("Mã vật tư đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database không?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        //Program.flagCloseFormVT = true; // Bật cờ cho phép tắt Form NV
                        btnThem.Enabled = btnXoa.Enabled = gridVatTu.Enabled = btnReload.Enabled = true;
                        btnUndo.Enabled = btnGhi.Enabled = gcInfoVatTu.Enabled = false;
                        this.bdsVatTu.EndEdit();
                        this.vattuTableAdapter.Update(this.dS.Vattu);
                        bdsVatTu.Position = position;
                    }
                    catch (Exception ex)
                    {
                        // Khi Update database lỗi thì xóa record vừa thêm trong bds
                        bdsVatTu.RemoveCurrent();
                        MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
