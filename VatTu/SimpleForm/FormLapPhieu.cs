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

        // Stack
        public Stack<String> historyDDH;
        public Stack<String> historyPX;
        public Stack<String> historyPN;

        // Undo Type
        String THEM_BTN = "_them"; // Click btn thêm
        String THEMPN_BTN = "_thempn"; // Click menu item thêm phiếu nhập
        String XOA_BTN = "_xoa"; // Click btn xóa
        String GHI_BTN = "_ghi"; // Click btn ghi
        String GHIPN_BTN = "_pn"; // Click menu item ghi phiếu nhập
        public string GHI_CTP_BTN = "_ctp"; // Click btn ghi của subform chi tiết phiếu xuất/ddh
        public bool check_ctp = false; // để biết là đang CRUD trên các table chi tiết phiếu

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
            gridDDH.Height = 435;
            gridPX.Height = 435;
            gcDDH.Height = 240;
            gcPX.Height = 240;
            gcPN.Height = 240;

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
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
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

            historyDDH = new Stack<string>();
            historyPX = new Stack<string>();
            historyPN = new Stack<string>();
        }

        private void updateChiTietPhieuTableAdapter()
        {
            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                this.cTPXTableAdapter.Update(this.dS.CTPX);
                return;
            }
            if (btnSwitch.Links[0].Caption.Equals("Đặt Hàng"))
            {
                this.cTDDHTableAdapter.Update(this.dS.CTDDH);
                return;
            }
            if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập"))
            {
                this.cTPNTableAdapter.Update(this.dS.CTPN);
                return;
            }
        }

        private void ComboBox_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Trường hợp chưa kịp chọn CN, thuộc tính index ở combobox sẽ thay đổi
            // "System.Data.DataRowView" sẽ xuất hiện và tất nhiên hệ thống sẽ không thể
            // nhận diện được tên server "System.Data.DataRowView".
            if (comboBox_ChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (comboBox_ChiNhanh.SelectedValue.ToString() == null) return;

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
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.dS.CTPX);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        // ------ UNDO ------
        private void pushHistory(string data)
        {
            if (btnSwitch.Links[0].Caption.Equals("Đặt Hàng"))
            {
                historyDDH.Push(data);
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                historyPX.Push(data);
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập"))
            {
                historyPN.Push(data);
            }
        }

        private void unClickThem()
        {
            btnThem.Enabled = btnXoa.Enabled = btnSwitch.Enabled = true;
            current_gc.Enabled = btnReload.Enabled = true;
            current_gb.Enabled = btnGhi.Enabled = false;
            current_bds.CancelEdit();
            current_bds.Position = position;
        }

        private void unClickThemPhieuNhap()
        {
            gridDDH.Enabled = true;
            cmsPN.Items[2].Enabled = false;
            if (bdsPN.Current != null) bdsPN.RemoveCurrent();
        }

        // Return vị trí của mẩu tin vừa ghi
        public int split_index_ghi(string GHIBTN, BindingSource currBds, string t)
        {
            char[] separators = new char[] { '#', '%' };
            string[] temp = GHIBTN.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string maPhieu = temp[1];
            int indexDataRowUpdated = currBds.Find(t, maPhieu);

            return indexDataRowUpdated;
        }

        private string[] split_data(string XOABTN)
        {
            char[] separators = new char[] { '#', '%' };
            string[] data = XOABTN.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return data;
        }

        private void unClickGhi(int index)
        {
            // Giữ lại mã phiếu đề phòng trường hợp user cancel việc undo
            string maPhieu_backup = ((DataRowView)current_bds[index])[0].ToString().Trim();

            DialogResult dr = MessageBox.Show("Phiếu '" + maPhieu_backup + "' đã được ghi vào database.\nBạn có chắc muốn Undo không??", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //int deletedPosition = current_bds.Find(type, maPhieu);

                string name_backup = ((DataRowView)current_bds[index])[2].ToString().Trim();
                string maKho_backup = ((DataRowView)current_bds[index])[4].ToString().Trim();
                current_bds.RemoveAt(index);
                themFunc();
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    this.phieuXuatTableAdapter.Update(this.dS.PhieuXuat);
                    txtMaPX.Text = maPhieu_backup;
                    txtTenKH.Text = name_backup;
                    txtMaKho_PX.Text = maKho_backup;
                }
                else
                {
                    this.datHangTableAdapter.Update(this.dS.DatHang);
                    txtMaDDH.Text = maPhieu_backup;
                    txtNhaCC.Text = name_backup;
                    txtMaKho_DH.Text = maKho_backup;
                }

                return;
            }

            pushHistory(GHI_BTN + "#%" + maPhieu_backup);
        }

        private void unClickXoa(string[] data_backup, BindingSource currBds)
        {
            currBds.AddNew();
            ((DataRowView)currBds[currBds.Position])[0] = data_backup[1];
            // Khi tách dữ liệu ra thì ngày được tách thành: [2] - mm/dd/yyyy [3] - time [4] - AM/PM
            ((DataRowView)currBds[currBds.Position])[1] = data_backup[2];
            ((DataRowView)currBds[currBds.Position])[2] = data_backup[3];
            ((DataRowView)currBds[currBds.Position])[3] = Program.maNV;
            ((DataRowView)currBds[currBds.Position])[4] = data_backup[4];
            currBds.EndEdit();

            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                this.phieuXuatTableAdapter.Update(this.dS.PhieuXuat);
            }
            else if (btnSwitch.Links[0].Caption.Equals("Đặt Hàng"))
            {
                this.datHangTableAdapter.Update(this.dS.DatHang);
            }
            else
            {
                this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);
            }
        }

        private void unClickMenuItemThemChiTietPhieu(int index, BindingSource currBds)
        {
            // Giữ lại mã phiếu và mã vật tư đề phòng trường hợp user cancel việc undo
            string maPhieu_backup = ((DataRowView)currBds[index])[0].ToString().Trim();
            string maVatTu_backup = ((DataRowView)currBds[index])[1].ToString().Trim();
            int soLuong = int.Parse(((DataRowView)currBds[index])[2].ToString().Trim());

            //string maVatTu_backup = index;

            DialogResult dr = MessageBox.Show("Dữ liệu đã được ghi vào database.\nBạn có chắc muốn Undo không??", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                currBds.RemoveAt(index);
                updateChiTietPhieuTableAdapter();
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    undo_update_SoLuongVT(maVatTu_backup, soLuong, "IMPORT");
                }
                else if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập"))
                {
                    undo_update_SoLuongVT(maVatTu_backup, soLuong, "EXPORT");
                }
                return;
            }

            pushHistory(GHI_CTP_BTN + "#%" + maPhieu_backup + "#%" + maVatTu_backup);
        }

        // Vẫn còn th sai
        private void undo_update_SoLuongVT(string maVatTu, int soLuong, string type)
        {
            String query = "DECLARE	@return_value int " +
                                    "EXEC @return_value = [dbo].[SP_UpdateSLVatTu] " +
                                    "@p1, @p2, @p3 " +
                                    "SELECT 'Return Value' = @return_value";

            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", maVatTu);
            sqlCommand.Parameters.AddWithValue("@p2", soLuong);
            sqlCommand.Parameters.AddWithValue("@p3", type);
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
        }

        // ------ CRUD ------
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

        private void themFunc()
        {
            current_bds.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnSwitch.Enabled = false;
            current_gc.Enabled = btnReload.Enabled = false;
            current_gb.Enabled = btnGhi.Enabled = true;
            ((DataRowView)current_bds[current_bds.Position])["MANV"] = Program.maNV;
            ((DataRowView)current_bds[current_bds.Position])["NGAY"] = DateTime.Today;
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Giữ lại vị trí trước khi CRUD
            position = current_bds.Position;
            themFunc();

            pushHistory(THEM_BTN);
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maNhanVien = int.Parse(((DataRowView)current_bds[current_bds.Position])["MANV"].ToString());

            //if (check_owner(current_bds, type.Equals("MAPX") ? gvPX : gvDDH)) {
            if (Program.maNV == maNhanVien)
            {
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
                        maPhieu = ((DataRowView)current_bds[current_bds.Position])[type].ToString().Trim();
                        string ngay = ((DataRowView)current_bds[current_bds.Position])[1].ToString().Trim();
                        string name = ((DataRowView)current_bds[current_bds.Position])[2].ToString().Trim();
                        string maKho = ((DataRowView)current_bds[current_bds.Position])[4].ToString().Trim();

                        current_bds.RemoveCurrent();
                        if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                        {
                            this.phieuXuatTableAdapter.Update(this.dS.PhieuXuat);
                            historyPX.Push(XOA_BTN + "#%" + maPhieu + "#%" + ngay + "#%" + name + "#%" + maKho);
                        }
                        else
                        {
                            this.datHangTableAdapter.Update(this.dS.DatHang);
                            historyDDH.Push(XOA_BTN + "#%" + maPhieu + "#%" + ngay + "#%" + name + "#%" + maKho);
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
                MessageBox.Show("Bạn không có quyền xóa phiếu/đơn này!", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (current_bds.Count == 0) btnXoa.Enabled = false;
        }

        private void BtnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String undoHistory = "";
            BindingSource currBds = null;

            // Click thêm btn của DDH
            if (btnSwitch.Links[0].Caption.Equals("Đặt Hàng") && historyDDH.Count != 0)
            {
                undoHistory = historyDDH.Pop();
                currBds = bdsCTDDH;
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất") && historyPX.Count != 0) // Click thêm btn của PX
            {
                undoHistory = historyPX.Pop();
                currBds = bdsCTPX;
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập") && historyPN.Count != 0)
            {
                undoHistory = historyPN.Pop();
                currBds = bdsCTPN;
            }

            if (undoHistory.Equals("")) return;

            if (undoHistory.Equals(THEM_BTN))
            {
                unClickThem();
                return;
            }

            if (undoHistory.Equals(THEMPN_BTN))
            {
                unClickThemPhieuNhap();
                return;
            }

            if (undoHistory.Contains("_ghi"))
            {
                int index = split_index_ghi(undoHistory, current_bds, type);
                unClickGhi(index);
                return;
            }

            if (undoHistory.Contains("_xoa"))
            {
                BindingSource bd = current_bds;
                string data_backup = undoHistory;
                string[] data_backup_split = split_data(undoHistory);
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập"))
                {
                    bd = bdsPN;
                    int indexLastDataRow = current_bds.Find(type, data_backup_split[5]);
                    if (current_bds.Position != indexLastDataRow)
                    {
                        current_bds.Position = indexLastDataRow;
                        pushHistory(data_backup);
                        return;
                    }
                }

                unClickXoa(data_backup_split, bd);
                return;
            }

            if (undoHistory.Contains("_ctp"))
            {
                // Nếu con trỏ không đứng đúng vị trí của mẩu tin vừa mới thêm thì ta phải giữ lại
                // mã phiếu để sử dụng cho lần undo kế tiếp (sau khi đã về đúng vị trí)
                string data_backup = undoHistory;
                string[] data_backup_split = split_data(undoHistory);
                if (check_position(data_backup, data_backup_split[1]))
                {
                    int index = currBds.Find("MAVT", data_backup_split[2]);
                    unClickMenuItemThemChiTietPhieu(index, currBds);
                    return;
                }
                return;
            }

            if (undoHistory.Contains(GHIPN_BTN))
            {
                string data_backup = undoHistory;
                string[] data_backup_split = split_data(undoHistory);
                if (check_position(data_backup, data_backup_split[1]))
                {
                    DialogResult dr = MessageBox.Show("Phiếu '" + data_backup_split[2] + "' đã được ghi vào database.\nBạn có chắc muốn Undo không??", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        bdsPN.RemoveAt(0);
                        this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);
                        return;
                    }
                    // Cancel undo.
                    pushHistory(data_backup);
                }
                return;
            }
        }

        private bool check_position(string data_backup, string value)
        {
            // tìm vị trí của đơn đặt hàng/phiếu mới thêm Chi tiết DDH/phiếu
            // và set position của bds hiện tại vào đúng vị trí đó 
            int indexLastDataRow = current_bds.Find(type, value);
            if (current_bds.Position != indexLastDataRow)
            {
                current_bds.Position = indexLastDataRow;
                pushHistory(data_backup);
                return false; // Con trỏ chưa nằm đúng vị trí
            }

            return true; // Con trỏ đã nằm đúng vị trí của mẩu tin cần undo
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
                                historyPX.Push(GHI_BTN + "#%" + tb_maPhieu.Text);
                            }
                            else
                            {
                                this.datHangTableAdapter.Update(this.dS.DatHang);
                                historyDDH.Push(GHI_BTN + "#%" + tb_maPhieu.Text);
                            }
                            current_bds.Position = position;
                            Program.formMain.timer1.Enabled = true;
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

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                    cmsPN.Items[0].Enabled = false;
                    cmsPN.Items[1].Enabled = cmsPN.Items[2].Enabled = cmsPN.Items[3].Enabled = true;
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

            pushHistory(THEMPN_BTN);
        }

        private void MiGhiPN_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string maPN = this.gvPN.GetRowCellValue(bdsPN.Position, "MAPN").ToString();

                // Check ràng buộc mã các phiếu
                //int indexMaPhieu = bdsPN.Find("", maPN);
                //int indexCurrent = bdsPN.Position;
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

                        string maSoDDH = this.gvPN.GetRowCellValue(bdsPN.Position, "MasoDDH").ToString().Trim();
                        pushHistory(GHIPN_BTN + "#%" + maSoDDH + "#%" + maPN);
                        Program.formMain.timer1.Enabled = true;
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

        private void MiXoaPN_Click(object sender, EventArgs e)
        {
            string maPhieu = "";
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu nhập này vì đã lập chi tiết phiếu nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    maPhieu = ((DataRowView)bdsPN[bdsPN.Position])[0].ToString().Trim();
                    string ngay = ((DataRowView)bdsPN[bdsPN.Position])[1].ToString().Trim();
                    string maDDH = ((DataRowView)bdsPN[bdsPN.Position])[2].ToString().Trim();
                    string maKho = ((DataRowView)bdsPN[bdsPN.Position])[4].ToString().Trim();
                    bdsPN.RemoveCurrent();
                    this.phieuNhapTableAdapter.Update(this.dS.PhieuNhap);

                    pushHistory(XOA_BTN + "#$" + maPhieu + "#$" + ngay + "#$" + maDDH + "#$" + maKho);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
                    bdsPN.Position = bdsPN.Find("MAPN", maPhieu);
                    return;
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

            // Có mã DDH để tìm position của phiếu nhập
            string maDDH = ((DataRowView)bdsPN[bdsPN.Position])[2].ToString().Trim();
            Program.subFormCTPN.maDDH = maDDH;
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
            //btnThem.Enabled = btnXoa.Enabled = true;
            if (Program.mGroup == "CONGTY")
            {
                comboBox_ChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = true;
            }
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

            current_bds = bdsDH;
            type = "MasoDDH";
        }

        private void BtnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Xuất", gcPX, gridPX);
            //btnThem.Enabled = btnXoa.Enabled = true;
            if (Program.mGroup == "CONGTY")
            {
                comboBox_ChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                comboBox_ChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = true;
            }

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
            else if (txtMaDDH.Text.Trim().Contains(" "))
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
            else if (txtMaPX.Text.Trim().Contains(" "))
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
                else if (checkMaPhieuNhap(val.ToString().Trim()) == 1)
                {
                    e.Valid = false;
                    e.ErrorText = "Mã phiếu nhập đã tồn tại ở chi nhánh hiện tại!";
                }
                else if (checkMaPhieuNhap(val.ToString().Trim()) == 2)
                {
                    e.Valid = false;
                    e.ErrorText = "Mã phiếu nhập đã tồn tại ở chi nhánh khác!";
                }
                else
                {
                    e.Valid = true;
                }
            }
        }

        private int checkMaPhieuNhap(string maPN)
        {
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
                return 0;
            }

            // Đọc và lấy result
            dataReader.Read();
            int result_value = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();

            return result_value;
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
