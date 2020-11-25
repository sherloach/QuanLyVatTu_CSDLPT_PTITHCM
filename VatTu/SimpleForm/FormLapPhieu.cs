using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using VatTu.DSTableAdapters;
using VatTu.SubForm;

namespace VatTu.SimpleForm
{
    public partial class FormLapPhieu : Form
    {
        int position = 0;
        string maCN = "";

        // Do form phiếu thiết kế theo kiểu tổng hợp của 3 loại phiếu,
        // nên tùy vào user chọn phiếu nào hệ thống sẽ gán binding source tương ứng
        BindingSource current_bds = null;
        GridControl current_gc = null;
        GroupBox current_gb = null; // Khu vực điền thông tin phiếu
        string type = "";

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
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
            }

            // Gán DataSource
            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                current_bds = bdsPX;
                current_gc = gridPX;
                current_gb = gbInfoPX;
                type = "MAPX";
            }
            else
            {
                current_bds = bdsDH;
                current_gc = gridDDH;
                current_gb = gbInfoDDH;
                type = "MasoDDH";
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
            /*
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
            }*/
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
            if (check_owner(current_bds, type.Equals("MAPX") ? gvPX : gvDDH)) {
                string maPhieu = "";
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    //type = "MAPX";
                    if (bdsCTPX.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa phiếu này vì đã lập chi tiết phiếu xuất", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    //type = "MasoDDH";
                    if (bdsCTDDH.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa đơn đặt hàng này vì đã lập chi tiết DDH", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (bdsPN.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa đơn đặt hàng này vì đã lập phiếu nhập", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu/đơn này không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        maPhieu = ((DataRowView)current_bds[current_bds.Position])[type].ToString();
                        current_bds.RemoveCurrent();
                        if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                        {
                            this.phieuXuatTableAdapter.Update(this.dS.PhieuXuat);
                        }
                        else
                        {
                            this.datHangTableAdapter.Update(this.dS.DatHang);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
                        this.datHangTableAdapter.Fill(this.dS.DatHang);
                        current_bds.Position = current_bds.Find(type, maPhieu);
                        return;
                    }
                }
            } 
            else
            {
                MessageBox.Show("Bạn không phải là người lập phiếu/đơn này", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (current_bds.Count == 0) btnXoa.Enabled = false;
        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(this.dS.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
                this.cTPNTableAdapter.Fill(this.dS.CTPN);
                this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
                this.cTPXTableAdapter.Fill(this.dS.CTPX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void BtnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // TODO: thêm ddh, phiếu xuất dùng chung hàm
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                TextBox tb_maPhieu = null;
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    current_bds = bdsPX;
                    tb_maPhieu = txtMaPX;
                    type = "MAPX";
                    current_gc = gridPX;
                    current_gb = gbInfoPX;
                }
                else
                {
                    current_bds = bdsDH;
                    tb_maPhieu = txtMaDDH;
                    type = "MasoDDH";
                    current_gc = gridDDH;
                    current_gb = gbInfoDDH;
                }

                String query = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", tb_maPhieu.Text);
                sqlCommand.Parameters.AddWithValue("@p2", type);
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

                // Check ràng buộc mã các phiếu
                int indexMaPhieu = current_bds.Find(type, tb_maPhieu.Text);
                int indexCurrent = current_bds.Position;
                if (result_value == 1 && (indexMaPhieu != indexCurrent))
                {
                    MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (result_value == 2)
                {
                    MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            current_gb.Enabled = false;
                            btnThem.Enabled = btnXoa.Enabled = current_gc.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = btnSwitch.Enabled = true;
                            current_bds.EndEdit();
                            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                            {
                                this.phieuXuatTableAdapter.Update(this.dS.PhieuXuat);
                            }
                            else
                            {
                                this.datHangTableAdapter.Update(this.dS.DatHang);
                            }
                            current_bds.Position = position;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            current_bds.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ------ POPUP MENU ------
        // ______ CTDDH ______
        private void GvCTDDH_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                //DXMenuItem menuThemCTDDH = createMenuItem("Thêm chi tiết DDH", null);
                DXMenuItem menuItemUp = new DXMenuItem("Move Up");
                //menuThemCTDDH.Click += new EventHandler(menuAddChiTietDDH_Click);
                //e.Menu.Items.Add(menuThemCTDDH);
                e.Menu.Items.Add(menuItemUp);
            }
        }

        private void MiThemCTDDH_Click(object sender, EventArgs e)
        {
            Program.subFormCTDDH = new SubFormCTDDH();
            Program.subFormCTDDH.Show();
            Program.formMain.Enabled = false;
        }

        private void GridCTDDH_MouseHover(object sender, EventArgs e)
        {
            gridCTDDH.ContextMenuStrip = check_owner(bdsDH, gvDDH) ? cmsCTDDH : cmsChecked;
        }

        // ______ PHIẾU NHẬP ______
        private void GridPN_MouseHover(object sender, EventArgs e)
        {
            if (check_owner(bdsDH, gvDDH))
            {
                if (this.bdsPN.Count > 0)
                {
                    cmsPN.Items[0].Text = "Đã thêm phiếu nhập";
                    cmsPN.Items[0].Enabled = cmsPN.Items[2].Visible = false;
                    cmsPN.Items[1].Enabled  = cmsPN.Items[3].Enabled = true;
                }
                else
                {
                    cmsPN.Items[0].Text = "Thêm phiếu nhập";
                    cmsPN.Items[0].Enabled = cmsPN.Items[2].Visible = true;
                    cmsPN.Items[1].Enabled = cmsPN.Items[2].Enabled = cmsPN.Items[3].Enabled = false;
                }
                gridPN.ContextMenuStrip = cmsPN;
            }
            else
            {
                gridPN.ContextMenuStrip = cmsChecked;
            }
        }

        private void MiThemPN_Click(object sender, EventArgs e)
        {
            //Program.subFormPN = new SubFormPN();
            //Program.subFormPN.Show();
            //Program.formMain.Enabled = false;
            this.bdsPN.AddNew();

            gridDDH.Enabled = false;
            cmsPN.Items[2].Enabled = true;

            // Set value cho mẩu tin
            //string maDDH = ((DataRowView)bdsDH[bdsDH.Position])["MasoDDH"].ToString().Trim();
            //((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"] = maDDH;
            string maKho = ((DataRowView)bdsDH[bdsDH.Position])["MAKHO"].ToString().Trim();
            ((DataRowView)bdsPN[bdsPN.Position])["MAKHO"] = maKho;
            ((DataRowView)bdsPN[bdsPN.Position])["MANV"] = Program.maNV;
            ((DataRowView)bdsPN[bdsPN.Position])["NGAY"] = DateTime.Today;
        }

        private void MiXoaPN_Click(object sender, EventArgs e)
        {

        }

        private void MiGhiPN_Click(object sender, EventArgs e)
        {
            string maPN = this.gvPN.GetRowCellValue(bdsPN.Position, "MAPN").ToString();
            String query = "DECLARE	@return_value int " +
                            "EXEC @return_value = [dbo].[SP_CHECKID] " +
                            "@p1, @p2 " +
                            "SELECT 'Return Value' = @return_value";
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", maPN);
            sqlCommand.Parameters.AddWithValue("@p2", "MAPN");
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
            // Check ràng buộc mã các phiếu
            //int indexMaPhieu = bdsPN.Find("", maPN);
            //int indexCurrent = bdsPN.Position;
            if (result_value == 1)
            {
                MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result_value == 2)
            {
                MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        this.bdsPN.EndEdit();
                        this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);
                        gridDDH.Enabled = true;
                        cmsPN.Items[1].Enabled = cmsPN.Items[3].Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        // Khi Update database lỗi thì xóa record vừa thêm trong bds
                        bdsPN.RemoveCurrent();
                        gridDDH.Enabled = true;
                        cmsPN.Items[0].Enabled = true;
                        cmsPN.Items[1].Enabled = cmsPN.Items[2].Enabled = cmsPN.Items[3].Enabled = false;
                        MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ______ CTPN ______
        private void MiThemCTPN_Click(object sender, EventArgs e)
        {
            if (bdsCTDDH.Count == 0)
            {
                MessageBox.Show("Đơn đặt hàng chưa lập chi tiết đơn đặt hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (bdsCTDDH.Count == bdsCTPN.Count)
            {
                MessageBox.Show("Đơn đặt hàng này đã lập đủ chi tiết phiếu nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.subFormCTPN = new SubFormCTPN();
            Program.subFormCTPN.Show();
            Program.formMain.Enabled = false;
        }

        // ______ CTPX ______
        private void GridCTPX_MouseHover(object sender, EventArgs e)
        {
            gridCTPX.ContextMenuStrip = check_owner(bdsPX, gvPX) ? cmsCTPX : cmsChecked;
        }

        private void MiThemCTPX_Click(object sender, EventArgs e)
        {
            Program.subFormCTPX = new SubFormCTPX();
            Program.subFormCTPX.Show();
            Program.formMain.Enabled = false;
        }
        // ------ SWITCH TYPE ------
        private void BtnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Đặt Hàng", gcDDH, gridDDH);
            btnThem.Enabled = btnXoa.Enabled = true;

            // Gán data sources
            current_bds = bdsDH;
            current_gc = gridDDH;
            current_gb = gbInfoDDH;
            type = "MasoDDH";
        }

        private void BtnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Nhập", gcPN, gridDDH);
            btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
        }

        private void BtnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Xuất", gcPX, gridPX);
            btnThem.Enabled = btnXoa.Enabled = true;

            // Gán data sources
            current_bds = bdsPX;
            current_gc = gridPX;
            current_gb = gbInfoPX;
            type = "MAPX";
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

        // ------ Utils Methods ------
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

        private DXMenuItem createMenuItem(string caption, Bitmap image)
        {
            DXMenuItem menuItem = new DXMenuItem();
            menuItem.Image = image;
            menuItem.Caption = caption;
            return menuItem;
        }

        // Kiểm tra manv login có trùng với manv của phiếu đang xét không
        private bool check_owner(BindingSource current_bds, GridView current_gv)
        {
            int maNV = 0;
            if (current_gv.GetRowCellValue(current_bds.Position, "MANV") != null)
            {
                maNV = int.Parse(current_gv.GetRowCellValue(current_bds.Position, "MANV").ToString().Trim());
            }
            return (maNV == Program.maNV);
        }

        // ------ Checked Methods ------
        private void TxtMaDDH_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDDH.Text))
            {
                e.Cancel = true;
                txtMaDDH.Focus();
                errorProvider.SetError(txtMaDDH, "Mã DH không được để trống!");
            }
            else if (txtMaDDH.Text.Contains(" "))
            {
                e.Cancel = true;
                txtMaDDH.Focus();
                errorProvider.SetError(txtMaDDH, "Mã DH không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaDDH, "");
            }
        }

        private void TxtNhaCC_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhaCC.Text))
            {
                e.Cancel = true;
                txtNhaCC.Focus();
                errorProvider.SetError(txtNhaCC, "Nhà cung cấp không được để trống!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNhaCC, "");
            }
        }

        private void TxtMaPX_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPX.Text))
            {
                e.Cancel = true;
                txtMaPX.Focus();
                errorProvider.SetError(txtMaPX, "Mã PX không được để trống!");
            }
            else if (txtMaPX.Text.Contains(" "))
            {
                e.Cancel = true;
                txtMaPX.Focus();
                errorProvider.SetError(txtMaPX, "Mã PX không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaPX, "");
            }
        }

        private void TxtTenKH_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                e.Cancel = true;
                txtTenKH.Focus();
                errorProvider.SetError(txtTenKH, "Tên khách hàng không được để trống!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtTenKH, "");
            }
        }

        private void TxtMaKho_PX_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKho_PX.Text))
            {
                e.Cancel = true;
                txtMaKho_PX.Focus();
                errorProvider.SetError(txtMaKho_PX, "Vui lòng chọn mã kho!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaKho_PX, "");
            }
        }

        private void TxtMaKho_DH_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKho_DH.Text))
            {
                e.Cancel = true;
                txtMaKho_DH.Focus();
                errorProvider.SetError(txtMaKho_DH, "Vui lòng chọn mã kho!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtMaKho_DH, "");
            }
        }

        private void GvPN_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            object val = e.Value;

            if (view.FocusedColumn.FieldName == "MAPN")
            {
                if (val == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Valid = false;
                    e.ErrorText = "Vui lòng nhập mã phiếu nhập!";
                }
                else if (val.ToString().Trim().Contains(" "))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã phiếu nhập không được chứa khoảng trắng!";
                }
            }
        }

        private void GvPN_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            view.ActiveEditor.IsModified = true;
        }

        // ------ Getter để các form khác có thể sử dụng binding source của form này ------
        public BindingSource getBdsCTDDH()
        {
            return this.bdsCTDDH;
        }

        public BindingSource getBdsDDH()
        {
            return this.bdsDH;
        }

        public BindingSource getBdsPX()
        {
            return this.bdsPX;
        }

        public BindingSource getBdsCTPX()
        {
            return this.bdsCTPX;
        }

        public BindingSource getBdsPN()
        {
            return this.bdsPN;
        }
        public BindingSource getBdsCTPN()
        {
            return this.bdsCTPN;
        }

        public DS getDataset()
        {
            return this.dS;
        }

        
    }
}
