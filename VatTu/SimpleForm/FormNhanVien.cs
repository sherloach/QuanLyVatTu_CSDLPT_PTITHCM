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
using VatTu.SubForm;

namespace VatTu
{
    public partial class FormNhanVien : Form
    {
        int position = 0;
        string maCN = "";

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
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = btnUndo.Links[0].Visible = btnChuyenChiNhanh.Links[0].Visible = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = false;
            }
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
            gcInfoNhanVien.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            dteNgaySinh.EditValue = "";

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gridNhanVien.Enabled = false;
        }
        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn đặt hàng", "",
                       MessageBoxButtons.OK);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu phập", "",
                       MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này ?? ", "Xác nhận",
                       MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString()); // giữ lại để khi xóa bij lỗi thì ta sẽ quay về lại
                    bdsNV.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }

            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            // Kiểm tra MACN, PHAI, NGAYSINH  phải có
            // LUONg thỏa Miền giá trị
            // MANV không được trùng trên các phân mảnh

            try
            {
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.dS.NhanVien);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gridNhanVien.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            gcInfoNhanVien.Enabled = false;
        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        String CNchuyen;
        public void GETVALUE(String index)
        {
            CNchuyen = index;
            string maCN = "";
            if (CNchuyen.Contains("2"))
            {
                maCN = "CN2";
            } else if (CNchuyen.Contains("1"))
            {
                maCN = "CN1";
            }
            Console.WriteLine("CHI NHANH DUOC CHON LA: " + CNchuyen);

            String maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
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
                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        }
    }
}
