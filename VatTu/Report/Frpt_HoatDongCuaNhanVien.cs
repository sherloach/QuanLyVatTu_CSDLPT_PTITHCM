using DevExpress.XtraReports.UI;
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

namespace VatTu.Report
{
    public partial class Frpt_HoatDongCuaNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public static int maNV;
        public static String tenNV;
        public static String ngaySinh;
        public static String diaChi;
        public static int luong;
        public static String maCN;

        public Frpt_HoatDongCuaNhanVien()
        {
            InitializeComponent();
        }

        private void NhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVT_DATHANGDataSet_Report);
        }

        private void Frpt_HoatDongCuaNhanVien_Load(object sender, EventArgs e)
        {
            String connStrSite3 = "Data Source=" + Program.serverName + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;

            this.v_DS_NHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_DS_NHANVIENTableAdapter.Fill(this.dS_NHANVIEN.V_DS_NHANVIEN);
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            String type = (rbNhap.Checked) ? "N" : "X";

            Xrpt_HoatDongCuaNhanVien2 rpt = new Xrpt_HoatDongCuaNhanVien2(maNV, deFrom.DateTime, deTo.DateTime, type);
            /*rpt.xrlMaNV.Text = maNV.ToString().Trim();
            rpt.xrlHoTen.Text = tenNV;
            rpt.xrlNgaySinh.Text = ngaySinh;
            rpt.xrlDiaChi.Text = diaChi;
            rpt.xrlLuong.Text = luong.ToString().Trim();
            rpt.xrlCN.Text = maCN;
            rpt.xrTitle.Text = "BẢNG KÊ CHỨNG TỪ PHIẾU ";
            rpt.xrTitle.Text += (type == "N") ? "NHẬP" : "XUẤT";*/

            ReportPrintTool print = new ReportPrintTool(rpt);
            rpt.ShowPreviewDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frpt_HoatDongCuaNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formMain.Enabled = true;
        }

        private void CbMaNV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String query = "EXEC SP_ThongTinNhanVien @p1";
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            sqlCommand.Parameters.AddWithValue("@p1", cbMaNV.Text);
            SqlDataReader dataReader = null;

            try
            {
                dataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi Database!\n" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                dataReader.Close();
                return;
            }

            dataReader.Read();

            // Gán giá trị cho các label bên report
            maNV = int.Parse(dataReader.GetValue(0).ToString());
            tenNV = dataReader.GetValue(1).ToString();
            ngaySinh = dataReader.GetValue(2).ToString();
            diaChi = dataReader.GetValue(3).ToString();
            luong = int.Parse(dataReader.GetValue(4).ToString());
            maCN = dataReader.GetValue(5).ToString();
            txtTenNV.Text = tenNV;
            dataReader.Close();
        }
    }
}
