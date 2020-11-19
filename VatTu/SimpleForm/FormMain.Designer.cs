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
            this.DanhSach = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ThongTin = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DonHang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
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
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.DanhSach,
            this.ThongTin,
            this.DonHang,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(812, 158);
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
            this.barButtonItem_CreateAccount.Name = "barButtonItem_CreateAccount";
            this.barButtonItem_CreateAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_CreateAccount_ItemClick);
            // 
            // barButtonItem_ListEmployee
            // 
            this.barButtonItem_ListEmployee.Caption = "Nhân Viên";
            this.barButtonItem_ListEmployee.Id = 6;
            this.barButtonItem_ListEmployee.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_ListEmployee.ImageOptions.SvgImage")));
            this.barButtonItem_ListEmployee.Name = "barButtonItem_ListEmployee";
            this.barButtonItem_ListEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_ListEmployee_ItemClick);
            // 
            // barButtonItem_listProduct
            // 
            this.barButtonItem_listProduct.Caption = "Vật Tư";
            this.barButtonItem_listProduct.Id = 7;
            this.barButtonItem_listProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_listProduct.ImageOptions.SvgImage")));
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
            this.barButtonItem_ListKho.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_ListKho.ImageOptions.SvgImage")));
            this.barButtonItem_ListKho.Name = "barButtonItem_ListKho";
            this.barButtonItem_ListKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem_ListKho_ItemClick);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Caption = "Lập Phiếu";
            this.btnLapPhieu.Id = 12;
            this.btnLapPhieu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLapPhieu.ImageOptions.SvgImage")));
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLapPhieu_ItemClick_1);
            // 
            // DanhSach
            // 
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
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Danh Sách";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnLapPhieu);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ThongTin
            // 
            this.ThongTin.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ThongTin.Name = "ThongTin";
            this.ThongTin.Text = "Thông tin";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem_Login);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_Info);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_ChangePassword);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_LogOut);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem_CreateAccount);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // DonHang
            // 
            this.DonHang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.DonHang.Name = "DonHang";
            this.DonHang.Text = "Đơn hàng";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem_donDatHang);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem_phieuNhap);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem_phieuXuat);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1_ItemClick_1);
            // 
            // FormChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 447);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FormChinh";
            this.Ribbon = this.ribbonControl1;
            this.Text = "FormChinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Login;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Info;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ChangePassword;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_LogOut;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateAccount;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListEmployee;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_listProduct;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_donDatHang;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_phieuNhap;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_phieuXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage DanhSach;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage DonHang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListKho;
        private DevExpress.XtraBars.BarButtonItem btnLapPhieu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
    }
}

