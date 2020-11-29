namespace VatTu
{
    partial class FormChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChinh));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem_Login = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Info = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_ChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_LogOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CreateAccount = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_ListEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_listProduct = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_donDatHang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_phieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_phieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_ListKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnLapPhieu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CTSLNX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_HDNV = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_THNX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DSVT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_out = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DSNV = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DHCPN = new DevExpress.XtraBars.BarButtonItem();
            this.DanhSach = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslMaNV = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslNhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem_Login,
            this.barButtonItem_Info,
            this.barButtonItem_ChangePassword,
            this.barButtonItem_LogOut,
            this.barButtonItem_CreateAccount,
            this.barButtonItem_ListEmployee,
            this.barButtonItem_listProduct,
            this.barButtonItem_donDatHang,
            this.barButtonItem_phieuNhap,
            this.barButtonItem_phieuXuat,
            this.barButtonItem_ListKho,
            this.btnLapPhieu,
            this.barButtonItem_CTSLNX,
            this.barButtonItem_HDNV,
            this.barButtonItem2,
            this.barButtonItem_THNX,
            this.barButtonItem_DSVT,
            this.barButtonItem_out,
            this.barButtonItem_DSNV,
            this.barButtonItem_DHCPN});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.DanhSach,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(812, 159);
            this.ribbonControl1.Click += new System.EventHandler(this.RibbonControl1_Click);
            // 
            // barButtonItem_Login
            // 
            this.barButtonItem_Login.Caption = "Đăng nhập";
            this.barButtonItem_Login.Id = 1;
            this.barButtonItem_Login.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Login.ImageOptions.SvgImage")));
            this.barButtonItem_Login.Name = "barButtonItem_Login";
            this.barButtonItem_Login.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1_ItemClick);
            // 
            // barButtonItem_Info
            // 
            this.barButtonItem_Info.Caption = "Thông tin cá nhân";
            this.barButtonItem_Info.Id = 2;
            this.barButtonItem_Info.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_Info.ImageOptions.SvgImage")));
            this.barButtonItem_Info.Name = "barButtonItem_Info";
            // 
            // barButtonItem_ChangePassword
            // 
            this.barButtonItem_ChangePassword.Caption = "Đổi mật khẩu";
            this.barButtonItem_ChangePassword.Id = 3;
            this.barButtonItem_ChangePassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_ChangePassword.ImageOptions.SvgImage")));
            this.barButtonItem_ChangePassword.Name = "barButtonItem_ChangePassword";
            // 
            // barButtonItem_LogOut
            // 
            this.barButtonItem_LogOut.Caption = "Thoát";
            this.barButtonItem_LogOut.Id = 4;
            this.barButtonItem_LogOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_LogOut.ImageOptions.SvgImage")));
            this.barButtonItem_LogOut.Name = "barButtonItem_LogOut";
            // 
            // barButtonItem_CreateAccount
            // 
            this.barButtonItem_CreateAccount.Caption = "Thêm tài khoản";
            this.barButtonItem_CreateAccount.Id = 5;
            this.barButtonItem_CreateAccount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_CreateAccount.ImageOptions.SvgImage")));
            this.barButtonItem_CreateAccount.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_CreateAccount.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem_CreateAccount.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_CreateAccount.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_CreateAccount.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_CreateAccount.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_CreateAccount.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_CreateAccount.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_CreateAccount.Name = "barButtonItem_CreateAccount";
            this.barButtonItem_CreateAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_CreateAccount_ItemClick);
            // 
            // barButtonItem_ListEmployee
            // 
            this.barButtonItem_ListEmployee.Caption = "Nhân Viên";
            this.barButtonItem_ListEmployee.Id = 6;
            this.barButtonItem_ListEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_ListEmployee.ImageOptions.LargeImage")));
            this.barButtonItem_ListEmployee.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListEmployee.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem_ListEmployee.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListEmployee.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_ListEmployee.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_ListEmployee.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_ListEmployee.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListEmployee.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_ListEmployee.Name = "barButtonItem_ListEmployee";
            this.barButtonItem_ListEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_ListEmployee_ItemClick);
            // 
            // barButtonItem_listProduct
            // 
            this.barButtonItem_listProduct.Caption = "Vật Tư";
            this.barButtonItem_listProduct.Id = 7;
            this.barButtonItem_listProduct.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_listProduct.ImageOptions.LargeImage")));
            this.barButtonItem_listProduct.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_listProduct.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem_listProduct.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_listProduct.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_listProduct.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_listProduct.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_listProduct.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_listProduct.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_listProduct.Name = "barButtonItem_listProduct";
            this.barButtonItem_listProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_listProduct_ItemClick);
            // 
            // barButtonItem_donDatHang
            // 
            this.barButtonItem_donDatHang.Caption = "Đơn hàng";
            this.barButtonItem_donDatHang.Id = 8;
            this.barButtonItem_donDatHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_donDatHang.ImageOptions.SvgImage")));
            this.barButtonItem_donDatHang.Name = "barButtonItem_donDatHang";
            this.barButtonItem_donDatHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_donDatHang_ItemClick);
            // 
            // barButtonItem_phieuNhap
            // 
            this.barButtonItem_phieuNhap.Caption = "Đơn nhập hàng";
            this.barButtonItem_phieuNhap.Id = 9;
            this.barButtonItem_phieuNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_phieuNhap.ImageOptions.SvgImage")));
            this.barButtonItem_phieuNhap.Name = "barButtonItem_phieuNhap";
            // 
            // barButtonItem_phieuXuat
            // 
            this.barButtonItem_phieuXuat.Caption = "Đơn xuất hàng";
            this.barButtonItem_phieuXuat.Id = 10;
            this.barButtonItem_phieuXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_phieuXuat.ImageOptions.SvgImage")));
            this.barButtonItem_phieuXuat.Name = "barButtonItem_phieuXuat";
            // 
            // barButtonItem_ListKho
            // 
            this.barButtonItem_ListKho.Caption = "Kho";
            this.barButtonItem_ListKho.Id = 11;
            this.barButtonItem_ListKho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_ListKho.ImageOptions.Image")));
            this.barButtonItem_ListKho.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_ListKho.ImageOptions.LargeImage")));
            this.barButtonItem_ListKho.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListKho.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem_ListKho.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListKho.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_ListKho.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_ListKho.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_ListKho.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_ListKho.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_ListKho.Name = "barButtonItem_ListKho";
            this.barButtonItem_ListKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_ListKho_ItemClick);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Caption = "Lập Phiếu";
            this.btnLapPhieu.Id = 12;
            this.btnLapPhieu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLapPhieu.ImageOptions.LargeImage")));
            this.btnLapPhieu.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnLapPhieu.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnLapPhieu.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapPhieu.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLapPhieu.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLapPhieu_ItemClick_1);
            // 
            // barButtonItem_CTSLNX
            // 
            this.barButtonItem_CTSLNX.Caption = "Chi Tiết SL Nhập Xuất";
            this.barButtonItem_CTSLNX.Id = 13;
            this.barButtonItem_CTSLNX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_CTSLNX.ImageOptions.Image")));
            this.barButtonItem_CTSLNX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_CTSLNX.ImageOptions.LargeImage")));
            this.barButtonItem_CTSLNX.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_CTSLNX.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_CTSLNX.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_CTSLNX.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_CTSLNX.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_CTSLNX.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_CTSLNX.Name = "barButtonItem_CTSLNX";
            this.barButtonItem_CTSLNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1_ItemClick_1);
            // 
            // barButtonItem_HDNV
            // 
            this.barButtonItem_HDNV.Caption = "Hoạt Động Nhân Viên";
            this.barButtonItem_HDNV.Id = 14;
            this.barButtonItem_HDNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_HDNV.ImageOptions.Image")));
            this.barButtonItem_HDNV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_HDNV.ImageOptions.LargeImage")));
            this.barButtonItem_HDNV.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_HDNV.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_HDNV.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_HDNV.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_HDNV.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_HDNV.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_HDNV.Name = "barButtonItem_HDNV";
            this.barButtonItem_HDNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_HDNV_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem_THNX
            // 
            this.barButtonItem_THNX.Caption = "Tổng Hợp Nhập Xuất";
            this.barButtonItem_THNX.Id = 16;
            this.barButtonItem_THNX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_THNX.ImageOptions.Image")));
            this.barButtonItem_THNX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_THNX.ImageOptions.LargeImage")));
            this.barButtonItem_THNX.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_THNX.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_THNX.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_THNX.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_THNX.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_THNX.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_THNX.Name = "barButtonItem_THNX";
            this.barButtonItem_THNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_THNX_ItemClick);
            // 
            // barButtonItem_DSVT
            // 
            this.barButtonItem_DSVT.Caption = "Danh Sách Vật Tư";
            this.barButtonItem_DSVT.Id = 17;
            this.barButtonItem_DSVT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DSVT.ImageOptions.Image")));
            this.barButtonItem_DSVT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DSVT.ImageOptions.LargeImage")));
            this.barButtonItem_DSVT.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DSVT.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_DSVT.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_DSVT.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_DSVT.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DSVT.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_DSVT.Name = "barButtonItem_DSVT";
            this.barButtonItem_DSVT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_DSVT_ItemClick);
            // 
            // barButtonItem_out
            // 
            this.barButtonItem_out.Caption = "Đăng Xuất";
            this.barButtonItem_out.Id = 18;
            this.barButtonItem_out.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_out.ImageOptions.Image")));
            this.barButtonItem_out.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_out.ImageOptions.LargeImage")));
            this.barButtonItem_out.ItemAppearance.Disabled.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_out.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem_out.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_out.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_out.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_out.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_out.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_out.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_out.Name = "barButtonItem_out";
            this.barButtonItem_out.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_out_ItemClick);
            // 
            // barButtonItem_DSNV
            // 
            this.barButtonItem_DSNV.Caption = "Danh Sách Nhân Viên";
            this.barButtonItem_DSNV.Id = 19;
            this.barButtonItem_DSNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DSNV.ImageOptions.Image")));
            this.barButtonItem_DSNV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DSNV.ImageOptions.LargeImage")));
            this.barButtonItem_DSNV.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DSNV.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_DSNV.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_DSNV.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_DSNV.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DSNV.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_DSNV.Name = "barButtonItem_DSNV";
            this.barButtonItem_DSNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_DSNV_ItemClick);
            // 
            // barButtonItem_DHCPN
            // 
            this.barButtonItem_DHCPN.Caption = "Đơn ĐH Chưa Có Phiếu Nhập";
            this.barButtonItem_DHCPN.Id = 20;
            this.barButtonItem_DHCPN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DHCPN.ImageOptions.Image")));
            this.barButtonItem_DHCPN.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem_DHCPN.ImageOptions.LargeImage")));
            this.barButtonItem_DHCPN.ItemAppearance.Hovered.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DHCPN.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem_DHCPN.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem_DHCPN.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem_DHCPN.ItemAppearance.Pressed.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.barButtonItem_DHCPN.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem_DHCPN.Name = "barButtonItem_DHCPN";
            this.barButtonItem_DHCPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_DHCPN_ItemClick);
            // 
            // DanhSach
            // 
            this.DanhSach.Appearance.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhSach.Appearance.Options.UseFont = true;
            this.DanhSach.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup6});
            this.DanhSach.Name = "DanhSach";
            this.DanhSach.Text = "Danh sách";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem_ListEmployee);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem_listProduct);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem_ListKho);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnLapPhieu);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem_CreateAccount);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem_out);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup8});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Báo Cáo";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_DSNV);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_DSVT);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_CTSLNX);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_DHCPN);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_HDNV);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem_THNX);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMaNV,
            this.tslTen,
            this.tslNhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslMaNV
            // 
            this.tslMaNV.Name = "tslMaNV";
            this.tslMaNV.Size = new System.Drawing.Size(43, 17);
            this.tslMaNV.Text = "Mã NV";
            // 
            // tslTen
            // 
            this.tslTen.Name = "tslTen";
            this.tslTen.Size = new System.Drawing.Size(25, 17);
            this.tslTen.Text = "Tên";
            // 
            // tslNhom
            // 
            this.tslNhom.Name = "tslNhom";
            this.tslNhom.Size = new System.Drawing.Size(41, 17);
            this.tslNhom.Text = "Nhóm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Location = new System.Drawing.Point(0, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 8);
            this.panel2.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 447);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FormChinh.IconOptions.Image")));
            this.IsMdiContainer = true;
            this.Name = "FormChinh";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Quản Lý Vật Tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Login;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Info;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ChangePassword;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_LogOut;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateAccount;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListEmployee;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_listProduct;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_donDatHang;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_phieuNhap;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_phieuXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage DanhSach;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListKho;
        private DevExpress.XtraBars.BarButtonItem btnLapPhieu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CTSLNX;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_HDNV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_THNX;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DSVT;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_out;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DSNV;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DHCPN;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslMaNV;
        private System.Windows.Forms.ToolStripStatusLabel tslTen;
        private System.Windows.Forms.ToolStripStatusLabel tslNhom;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Timer timer1;
    }
}

