using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VatTu.SubForm;

namespace VatTu.SimpleForm
{
    public partial class FormLapPhieu : Form
    {
        int position = 0;
        string maCN = "";
        public FormLapPhieu()
        {
            InitializeComponent();
        }
        
        private void DatHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void FormLapPhieu_Load(object sender, EventArgs e)
        {
            gcDDH.Height = 250;
            gcPX.Height = 250;
            gcPN.Height = 250;

            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS.DatHang);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dS.CTPX);

            //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString(); // Lúc đúng lúc sai, tìm cách khác.
            comboBox_ChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            comboBox_ChiNhanh.DisplayMember = "TENCN";
            comboBox_ChiNhanh.ValueMember = "TENSERVER";
            comboBox_ChiNhanh.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "CONGTY")
            {
                comboBox_ChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Links[0].Visible = btnXoa.Links[0].Visible = btnGhi.Links[0].Visible = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
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
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.dS.DatHang);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        // ------ pre CRUD ------
        private void BtnGridKho_Click(object sender, EventArgs e)
        {
            Program.subFormKho = new SubFormKho();
            Program.subFormKho.Show();
            Program.formMain.Enabled = false;
        }

        // __ Chọn Kho của PX __
        private void BtnGridKho2_Click(object sender, EventArgs e)
        {
            Program.subFormKho = new SubFormKho();
            Program.subFormKho.Show();
            Program.formMain.Enabled = false;
        }

        // ------ CRUD ------
        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Tùy từng type trong Form Lập phiếu mà chọn ra binding source tương ứng.
            BindingSource current_bds = null;
            GridControl current_gc = null;
            GroupBox current_gb = null;

            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                current_bds = bdsPX;
                current_gc = gridPX;
                current_gb = gbInfoPX;
            }
            else
            {
                current_bds = bdsDH;
                current_gc = gridDDH;
                current_gb = gbInfoDDH;
            }
            // Giữ lại vị trí trước khi CRUD
            position = current_bds.Position;

            current_bds.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnSwitch.Enabled = false;
            current_gc.Enabled = btnReload.Enabled = false;
            current_gb.Enabled = btnGhi.Enabled = true;
            ((DataRowView)current_bds[current_bds.Position])["MANV"] = Program.maNV;
            ((DataRowView)current_bds[current_bds.Position])["NGAY"] = DateTime.Today;
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        // ------ SWITCH TYPE ------
        private void BtnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Đặt Hàng", gcDDH, gridDDH);
        }

        private void BtnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Nhập", gcPN, gridDDH);
        }

        private void BtnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Xuất", gcPX, gridPX);
        }

        private void switchPanel(string type, GroupControl groupControl, GridControl gridControl)
        {
            btnSwitch.Links[0].Caption = type;
            //btnSwitch.Links[0].ImageOptions.Image = image;
            gcDDH.Visible = false;
            gcPX.Visible = false;
            gcPN.Visible = false;
            gridDDH.Visible = false;
            gridPX.Visible = false;
            gridControl.Visible = true;
            groupControl.Visible = true;
        }

    }
}
