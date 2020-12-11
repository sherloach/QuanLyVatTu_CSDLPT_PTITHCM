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
    public partial class FormKho : Form
    {
        int position = 0;
        string maCN = "";

        public Stack<String> history_kho;

        // Undo Type
        String THEM_BTN = "_&them"; // Click btn thêm
        String XOA_BTN = "_&xoa"; // Click btn xóa
        String GHI_BTN = "_&ghi"; // Click btn ghi

        public FormKho()
        {
            InitializeComponent();
        }

        private void KhoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void FormKho_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS.Kho);
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS.DatHang);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = btnUndo.Links[0].Visible = false;
                txtTenKho.Enabled = txtMaKho.Enabled = txtDiaChi.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = txtMaKho.Enabled = false;
            }

            maCN = (((DataRowView)bdsKho[0])["MACN"].ToString()); // lúc đúng lúc sai

            this.comboBox_ChiNhanh.DataSource = Program.bds_dspm; // DataSource của comboBox_ChiNhanh tham chiếu đến bindingSource ở LoginForm
            comboBox_ChiNhanh.DisplayMember = "TENCN";
            comboBox_ChiNhanh.ValueMember = "TENSERVER";
            comboBox_ChiNhanh.SelectedIndex = Program.mChinhanh;

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled = false;
            //Program.flagCloseFormKho = true; //Khi load bật cho phép có thể đóng form

            history_kho = new Stack<string>();
        }

        private void themFunc()
        {
            position = bdsKho.Position;
            txtMaKho.Enabled = true;
            this.bdsKho.AddNew();
            txtMaCN.Text = maCN;
            btnThem.Enabled = btnXoa.Enabled = khoGridControl.Enabled = btnReload.Enabled = false;
            btnUndo.Enabled = gcInfoKho.Enabled = btnGhi.Enabled = true;
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themFunc();
            history_kho.Push(THEM_BTN);
            //Program.flagCloseFormKho = false;    //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maKho = "";
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập phiếu xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa kho này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                try
                {
                    maKho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
                    string tenKho = ((DataRowView)bdsKho[bdsKho.Position])["TENKHO"].ToString();
                    string diaChi = ((DataRowView)bdsKho[bdsKho.Position])["DIACHI"].ToString();

                    bdsKho.RemoveCurrent();
                    btnUndo.Enabled = true;
                    this.khoTableAdapter.Update(this.dS.Kho);
                    history_kho.Push(XOA_BTN + "#%" + maKho + "#%" + tenKho + "#%" + diaChi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.khoTableAdapter.Fill(this.dS.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", maKho);
                    return;
                }
            }

            if (bdsKho.Count == 0) btnXoa.Enabled = false;
        }


        // ------ UNDO ------
        private void unClickThem()
        {
            btnThem.Enabled = btnXoa.Enabled = khoGridControl.Enabled = btnReload.Enabled = gcInfoKho.Enabled = true;
            btnGhi.Enabled = txtMaKho.Enabled = false;
            this.bdsKho.CancelEdit();
            bdsKho.Position = position;
        }

        private void unClickGhi(int index)
        {
            string maKho_backup = ((DataRowView)bdsKho[index])[0].ToString().Trim();
            DialogResult dr = MessageBox.Show("Phiếu '" + maKho_backup + "' đã được ghi vào database.\nBạn có chắc muốn Undo không??", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //int deletedPosition = current_bds.Find(type, maPhieu);

                string tenKho_backup = ((DataRowView)bdsKho[index])[1].ToString().Trim();
                string diaChi_backup = ((DataRowView)bdsKho[index])[2].ToString().Trim();
                bdsKho.RemoveAt(index);
                themFunc();
                this.khoTableAdapter.Update(this.dS.Kho);
                txtMaKho.Text = maKho_backup;
                txtTenKho.Text = tenKho_backup;
                txtDiaChi.Text = maKho_backup;

                return;
            }

            history_kho.Push(GHI_BTN + "#%" + maKho_backup);
        }

        private void unClickXoa(string[] data_backup)
        {
            bdsKho.AddNew();
            ((DataRowView)bdsKho[bdsKho.Position])[0] = data_backup[1];
            // Khi tách dữ liệu ra thì ngày được tách thành: [2] - mm/dd/yyyy [3] - time [4] - AM/PM
            ((DataRowView)bdsKho[bdsKho.Position])[1] = data_backup[2];
            ((DataRowView)bdsKho[bdsKho.Position])[2] = data_backup[3];
            ((DataRowView)bdsKho[bdsKho.Position])[3] = maCN;
            bdsKho.EndEdit();
            this.khoTableAdapter.Update(this.dS.Kho);
        }

        public int split_index_ghi(string GHIBTN)
        {
            char[] separators = new char[] { '#', '%' };
            string[] temp = GHIBTN.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string maPhieu = temp[1];
            int indexDataRowUpdated = bdsKho.Find("MAKHO", maPhieu);

            return indexDataRowUpdated;
        }

        private string[] split_data(string XOABTN)
        {
            char[] separators = new char[] { '#', '%' };
            string[] data = XOABTN.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return data;
        }

        // TODO: vị trí, non-update
        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String undoHistory = "";
            undoHistory = history_kho.Pop();
            if (history_kho.Count == 0) btnUndo.Enabled = false;

            if (undoHistory.Equals(""))
            {
                btnUndo.Enabled = false;
                return;
            }

            if (undoHistory.Equals(THEM_BTN))
            {
                unClickThem();
                return;
            }

            if (undoHistory.Contains("_&ghi"))
            {
                int index = split_index_ghi(undoHistory);
                unClickGhi(index);
                return;
            }

            if (undoHistory.Contains(XOA_BTN))
            {
                string[] data_backup_split = split_data(undoHistory);
                unClickXoa(data_backup_split);
                return;
            }
        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.khoTableAdapter.Fill(this.dS.Kho);
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                // == Query tìm MAKHO ==
                String query_MAKHO = "DECLARE @return_value int " +
                                    "EXEC @return_value = [dbo].[SP_CHECKID_TRACUU] " +
                                    "@p1, @p2 " +
                                    "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MAKHO, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaKho.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "MAKHO");
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
                int result_value_MAKHO = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();

                // == Query tìm TENKHO ==
                String query_TENKHO = "DECLARE @return_value int " +
                                       "EXEC @return_value = [dbo].[SP_CHECKID_TRACUU] " +
                                       "@p1, @p2 " +
                                       "SELECT 'Return Value' = @return_value";
                sqlCommand = new SqlCommand(query_TENKHO, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", txtTenKho.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "TENKHO");

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
                int result_value_TENKHO = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();

                // Check ràng buộc MAKHO, TENKHO
                int indexMaKHO = bdsKho.Find("MAKHO", txtMaKho.Text);
                int indexTENKHO = bdsKho.Find("TENKHO", txtTenKho.Text);
                int indexCurrent = bdsKho.Position;
                if (result_value_MAKHO == 1 && (indexMaKHO != indexCurrent)) // điều kiện sau là nhằm trường hợp sửa thông tin sẽ không xét chính nó
                {
                    MessageBox.Show("Mã kho đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (result_value_TENKHO == 1 && (indexTENKHO != indexCurrent))
                {
                    MessageBox.Show("Tên kho đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            //Program.flagCloseFormKho = true; //Bật cờ cho phép tắt Form NV
                            btnThem.Enabled = btnXoa.Enabled = khoGridControl.Enabled = gcInfoKho.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = true;
                            btnUndo.Enabled = true;
                            txtMaKho.Enabled = false;
                            this.bdsKho.EndEdit();
                            Program.formMain.timer1.Enabled = true;
                            this.khoTableAdapter.Update(this.dS.Kho);
                            history_kho.Push(GHI_BTN + "#%" + txtMaKho.Text);
                            bdsKho.Position = position;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsKho.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ComboBox_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Trường hợp chưa kịp chọn CN, thuộc tính index ở combobox sẽ thay đổi
            // "System.Data.DataRowView" sẽ xuất hiện và tất nhiên hệ thống sẽ không thể
            // nhận diện được tên server "System.Data.DataRowView".
            if (comboBox_ChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            // Lấy tên server
            Program.serverName = comboBox_ChiNhanh.SelectedValue.ToString();

            // Nếu tên server khác với tên server ngoài đăng nhập, thì ta phải sử dụng HTKN
            if (comboBox_ChiNhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remoteLogin;
                Program.password = Program.remotePassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.dS.Kho);
                maCN = ((DataRowView)bdsKho[0])["MACN"].ToString();
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

        private void TxtMaKho_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKho.Text))
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được để trống!");
            }
            else if (txtMaKho.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được chứa khoảng trắng!");
            }
            else if (txtMaKho.Text.Trim().Contains("#") || txtMaKho.Text.Trim().Contains("%"))
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaKho, "");
            }
        }

        private void TxtTenKho_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKho.Text))
            {
                e.Cancel = true;
                txtTenKho.Focus();
                errorProvider1.SetError(txtTenKho, "Tên kho không được để trống!");
            }
            else if (txtTenKho.Text.Trim().Contains("#") || txtTenKho.Text.Trim().Contains("%"))
            {
                e.Cancel = true;
                txtTenKho.Focus();
                errorProvider1.SetError(txtTenKho, "Tên kho không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenKho, "");
            }
        }

        private void TxtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ kho không được để trống!");
            }
            else if (txtDiaChi.Text.Trim().Contains("#") || txtDiaChi.Text.Trim().Contains("%"))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ kho không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDiaChi, "");
            }
        }
    }
}
