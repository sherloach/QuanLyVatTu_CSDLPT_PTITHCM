using System;
using System.Collections;
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
        Stack undolist = new Stack();

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

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dS.CTPX);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = false;
                btnUndo.Links[0].Visible = false;
            }
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsVatTu.Position;
            this.bdsVatTu.AddNew();
            btnThem.Enabled = btnXoa.Enabled = gridVatTu.Enabled = btnReload.Enabled = btnUndo.Enabled = false;
            btnGhi.Enabled = gcInfoVatTu.Enabled = true;

            //Program.flagCloseFormVT = false; //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
            numSLT.Value = 0;
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maVT = "";
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư này?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                // == Query tìm MAVT ==
                String query_MAVT = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKTT_MAVT] " +
                               "@p1 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MAVT, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaVT.Text);
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc và lấy result
                dataReader.Read();
                int result_value_MAVT = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                if (result_value_MAVT == 1)
                {
                    MessageBox.Show("Vật tư đang được sử dụng ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (result_value_MAVT == 2)
                {
                    MessageBox.Show("Vật tư đang được sử dụng ở chi nhánh khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        String VT_info = txtMaVT.Text.Trim() + "#" + txtTenVT.Text.Trim() + "#" + txtDVT.Text.Trim() + "#" + numSLT.Text.Trim();
                        Console.WriteLine(VT_info);
                        maVT = ((DataRowView)bdsVatTu[bdsVatTu.Position])["MAVT"].ToString(); // Giữ lại mã để khi bị lỗi có thể quay về
                        bdsVatTu.RemoveCurrent();
                        btnUndo.Enabled = true;
                        undolist.Push(VT_info);
                        undolist.Push("DELETE");
                        this.vattuTableAdapter.Update(this.dS.Vattu);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.vattuTableAdapter.Fill(this.dS.Vattu);
                        bdsVatTu.Position = bdsVatTu.Find("MAVT", maVT);
                        return;
                    }
                }
            }

            // Unable nút xóa nếu không có vật tư nào
            if (bdsVatTu.Count == 0) btnXoa.Enabled = false;
        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*btnThem.Enabled = btnXoa.Enabled = gridVatTu.Enabled = btnReload.Enabled = true;
            btnUndo.Enabled = false;
            //Program.flagCloseFormVT = true; // Undo lại thì cho phép thoát mà ko kiểm tra dữ liệu
            bdsVatTu.CancelEdit();
            bdsVatTu.Position = position;*/

            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    this.bdsVatTu.AddNew();
                    String TT = undolist.Pop().ToString();
                    Console.WriteLine(TT);
                    String[] TT_VT = TT.Split('#');

                    txtMaVT.Text = TT_VT[0];
                    txtTenVT.Text = TT_VT[1];
                    txtDVT.Text = TT_VT[2];
                    numSLT.Text = TT_VT[3];
                    this.bdsVatTu.EndEdit();
                    this.vattuTableAdapter.Update(this.dS.Vattu);
                }
                else if (statement.Equals("INSERT"))
                {
                    int vitrixoa = int.Parse(undolist.Pop().ToString());
                    bdsVatTu.Position = vitrixoa;
                    bdsVatTu.RemoveCurrent();
                    this.vattuTableAdapter.Update(this.dS.Vattu);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.vattuTableAdapter.Fill(this.dS.Vattu);
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Check ràng buộc
            if (!Validate(txtMaVT, "Mã vật tư không được để trống!")) return;
            if (!Validate(txtTenVT, "Tên vật tư không được để trống!")) return;
            if (!Validate(txtDVT, "Đơn vị tính không được để trống!")) return;
            txtMaVT.Text = txtMaVT.Text.Trim();
            if (txtMaVT.Text.Trim().Length > 4)
            {
                MessageBox.Show("Mã vật tư không được quá 4 kí tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtMaVT.Text.Contains(" "))
            {
                MessageBox.Show("Mã vật tư không được chứa khoảng trắng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int checkMaVT = bdsVatTu.Find("TENVT", txtTenVT.Text);
            if (checkMaVT != -1 && (checkMaVT != bdsVatTu.Position))
            {
                MessageBox.Show("Tên vật tư trùng. Vui lòng chọn tên vật tư khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Có cần thiết chạy SP không trong khi VATTU là nhân bản???
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
                MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
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
                        btnThem.Enabled = btnXoa.Enabled = gridVatTu.Enabled = btnReload.Enabled = btnGhi.Enabled = gcInfoVatTu.Enabled = true;
                        btnUndo.Enabled = true;
                        this.bdsVatTu.EndEdit();
                        this.vattuTableAdapter.Update(this.dS.Vattu);
                        undolist.Push(bdsVatTu.Position.ToString());
                        undolist.Push("INSERT");
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
