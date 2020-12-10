using DevExpress.XtraEditors;
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
using VatTu.SubForm;

namespace VatTu
{
    public partial class FormNhanVien : Form
    {
        int position = 0;
        string maCN = "";
        Stack undolist = new Stack();

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

            // TODO: This line of code loads data into the 'dS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS.DatHang);

            // TODO: This line of code loads data into the 'dS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);

            maCN = ((DataRowView)bdsNV[0])["MACN"].ToString(); // Lúc đúng lúc sai, tìm cách khác.
            comboBox_ChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            comboBox_ChiNhanh.DisplayMember = "TENCN";
            comboBox_ChiNhanh.ValueMember = "TENSERVER";
            comboBox_ChiNhanh.SelectedIndex = Program.mChinhanh;

            // Phân Quyền
            // TODO: CONGTY thì comboBox sáng lên, các nút chức năng PHẢI mờ
            //       Không phải công ty thì comboBox mờ, các nút chức năng cần thiết PHẢI sáng.
            if (Program.mGroup == "CONGTY")
            {
                comboBox_ChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = false;
                btnUndo.Links[0].Visible = btnChuyenChiNhanh.Links[0].Visible = gcInfoNhanVien.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = btnUndo.Enabled = txtMaNV.Enabled = false;
            }

            /*if (Program.mGroup == "CONGTY")
            {
                comboBox_ChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                gcInfoNhanVien.Enabled = false;
                //btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = btnUndo.Links[0].Visible = false;
            }
            else comboBox_ChiNhanh.Enabled = false;
            if (Program.mGroup != "CHINHANH")
            {
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnChuyenChiNhanh.Enabled = txtMaNV.Enabled = false;
            }
            else btnUndo.Enabled = false;*/
        }

        private void NhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.dS.DatHang);
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
                maCN = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            gcInfoNhanVien.Enabled = txtMaNV.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            txtLuong.Value = 4000000;
            dteNgaySinh.EditValue = "";
            cbTTXoa.Checked = false;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridNhanVien.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }
        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maNV = "";

            if (cbTTXoa.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa, đang ở chi nhánh khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    String NV_info = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                            dteNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
                    Console.WriteLine(NV_info);
                    maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                    bdsNV.RemoveCurrent();
                    btnUndo.Enabled = true;
                    undolist.Push(NV_info);
                    undolist.Push("DELETE");


                    Program.mlogin = Program.remoteLogin;
                    Program.password = Program.remotePassword;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);


                    Program.conn = new SqlConnection(Program.connstr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("Xoa_Login", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@USRNAME", maNV));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", maNV);
                    return;
                }
            }
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                txtMaNV.Text = txtMaNV.Text.Trim();
                String maNV = txtMaNV.Text;

                // == Query tìm MANV ==
                String query_MANV = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MANV, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", maNV);
                sqlCommand.Parameters.AddWithValue("@p2", "MANV");
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
                int result_value_MANV = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                // Check ràng buộc MANV
                int indexMaNV = bdsNV.Find("MANV", txtMaNV.Text);

                int indexCurrent = bdsNV.Position;
                if (result_value_MANV == 1 && (indexMaNV != indexCurrent))
                {
                    MessageBox.Show("Mã NV đã tồn tại ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (result_value_MANV == 2)
                {
                    MessageBox.Show("Mã NV đã tồn tại ở chi nhánh khác!", "Thông báo",
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
                            btnThem.Enabled = btnXoa.Enabled = gridNhanVien.Enabled = gcInfoNhanVien.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = btnThoat.Enabled = true;
                            btnUndo.Enabled = true;
                            txtMaNV.Enabled = false;
                            this.bdsNV.EndEdit();
                            this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                            undolist.Push(bdsNV.Position.ToString());
                            undolist.Push("INSERT");
                            bdsNV.Position = position;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsNV.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsNV.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_NV = TT.Split('#');
                    txtMaNV.Text = TT_NV[0];
                    txtHo.Text = TT_NV[1];
                    txtTen.Text = TT_NV[2];
                    txtMaCN.Text = TT_NV[3];
                    dteNgaySinh.Text = TT_NV[4];
                    txtDiaChi.Text = TT_NV[5];
                    txtLuong.Text = TT_NV[6];
                    cbTTXoa.Checked = false;
                    this.bdsNV.EndEdit();
                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);
                }
                else if (statement.Equals("INSERT"))
                {
                    int vitrixoa = int.Parse(undolist.Pop().ToString());
                    bdsNV.Position = vitrixoa;
                    bdsNV.RemoveCurrent();
                }
                else if (statement.Equals("CHUYENCN"))
                {
                    String info = undolist.Pop().ToString();
                    String[] info_CN = info.Split('#');
                    Console.WriteLine(info_CN[0] + " " + info_CN[1]);
                    String servername_temp = Program.serverName;

                    Program.serverName = info_CN[1].ToString();

                    Program.mlogin = Program.remoteLogin;
                    Program.password = Program.remotePassword;


                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                    String maNV = info_CN[0].ToString();
                    String maCN = "";
                    if (info_CN[1].ToString().Contains("2")) maCN = "CN1";
                    else if (info_CN[1].ToString().Contains("1")) maCN = "CN2";
                    Program.conn = new SqlConnection(Program.connstr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_CHUYENCHINHANH_NV", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                    cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Chuyển nhân viên trở về thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (Program.serverName != servername_temp)
                        {
                            Program.serverName = servername_temp;
                            Program.mlogin = Program.mloginDN;
                            Program.password = Program.passwordDN;
                            if (Program.KetNoi() == 0)
                                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                        }

                    }

                }
                this.nhanVienTableAdapter.Update(this.dS.NhanVien);
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        String CNchuyen;
        public void GETVALUE(String index)
        {
            CNchuyen = index;
            Console.WriteLine("CHI NHANH DUOC CHON LA: " + CNchuyen);
            if (CNchuyen != Program.serverName)
            {
                String maCN = "";
                if (CNchuyen.Contains("2")) maCN = "CN2";
                else if (CNchuyen.Contains("1")) maCN = "CN1";

                String maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                Console.WriteLine(maNV);
                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
                SqlCommand cmd = new SqlCommand("SP_CHUYENCHINHANH_NV", Program.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                SqlDataReader myReader = null;
                try
                {
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Chuyển nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    undolist.Push(maNV + "#" + CNchuyen);
                    undolist.Push("CHUYENCN");
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    btnUndo.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Vui lòng chọn CN khác chi nhánh hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void BtnChuyenChiNhanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int trangThaiXoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
            if (trangThaiXoa == 0)
            {
                FormChuyenCN pickCN = new FormChuyenCN();
                pickCN.mydata = new FormChuyenCN.GETDATA(GETVALUE);
                pickCN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nhân viên hiện không có ở chi nhánh này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
        private bool Validate(DateEdit date, string str)
        {
            if (date.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                date.Focus();
                return false;
            }
            return true;
        }

        /*
        private void TxtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }*/

        private void TxtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được để trống!");
            }
            else if (txtMaNV.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaNV, "");
            }
        }

        private void TxtHo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHo.Text))
            {
                e.Cancel = true;
                txtHo.Focus();
                errorProvider1.SetError(txtHo, "Họ nhân viên không được để trống!");
            }
            else if (txtHo.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtHo.Focus();
                errorProvider1.SetError(txtHo, "Họ nhân viên không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtHo, "");
            }
        }

        private void TxtTen_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                e.Cancel = true;
                txtTen.Focus();
                errorProvider1.SetError(txtTen, "Tên nhân viên không được để trống!");
            }
            else if (txtTen.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtTen.Focus();
                errorProvider1.SetError(txtTen, "Tên nhân viên không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTen, "");
            }
        }

        private void TxtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được để trống!");
            }
            else if (txtDiaChi.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được chứa ký tự đặc biệt!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDiaChi, "");
            }
        }

        private void DteNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if (CalculateAge(dteNgaySinh.DateTime) > 60)
            {
                e.Cancel = true;
                dteNgaySinh.Focus();
                errorProvider1.SetError(dteNgaySinh, "Ngày sinh không hợp lệ!");
            }
            else if (CalculateAge(dteNgaySinh.DateTime) < 18)
            {
                e.Cancel = true;
                dteNgaySinh.Focus();
                errorProvider1.SetError(dteNgaySinh, "Nhân viên phải lớn hơn hoặc bằng 18 tuổi!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dteNgaySinh, "");
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        // Disable validator devExpress
        private void DteNgaySinh_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
}
