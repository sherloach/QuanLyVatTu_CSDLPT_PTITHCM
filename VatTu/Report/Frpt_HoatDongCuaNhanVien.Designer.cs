namespace VatTu.Report
{
    partial class Frpt_HoatDongCuaNhanVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbNhap = new System.Windows.Forms.RadioButton();
            this.rbXuat = new System.Windows.Forms.RadioButton();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.qLVT_DATHANGDataSet_Report = new VatTu.QLVT_DATHANGDataSet_Report();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new VatTu.QLVT_DATHANGDataSet_ReportTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new VatTu.QLVT_DATHANGDataSet_ReportTableAdapters.TableAdapterManager();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.vDSNHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_NHANVIEN = new VatTu.DS_NHANVIEN();
            this.v_DS_NHANVIENTableAdapter = new VatTu.DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(78, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoạt Động Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đến Ngày:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Pro Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(186, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Họ Tên:";
            // 
            // rbNhap
            // 
            this.rbNhap.AutoSize = true;
            this.rbNhap.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNhap.Location = new System.Drawing.Point(125, 176);
            this.rbNhap.Name = "rbNhap";
            this.rbNhap.Size = new System.Drawing.Size(90, 18);
            this.rbNhap.TabIndex = 5;
            this.rbNhap.TabStop = true;
            this.rbNhap.Text = "Phiếu Nhập";
            this.rbNhap.UseVisualStyleBackColor = true;
            // 
            // rbXuat
            // 
            this.rbXuat.AutoSize = true;
            this.rbXuat.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXuat.Location = new System.Drawing.Point(244, 176);
            this.rbXuat.Name = "rbXuat";
            this.rbXuat.Size = new System.Drawing.Size(86, 18);
            this.rbXuat.TabIndex = 6;
            this.rbXuat.TabStop = true;
            this.rbXuat.Text = "Phiếu Xuất";
            this.rbXuat.UseVisualStyleBackColor = true;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(263, 84);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(137, 20);
            this.txtTenNV.TabIndex = 7;
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(98, 129);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Size = new System.Drawing.Size(100, 20);
            this.deFrom.TabIndex = 8;
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(300, 129);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Size = new System.Drawing.Size(100, 20);
            this.deTo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SF Pro Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loại Phiếu:";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(241, 217);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 27);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.Location = new System.Drawing.Point(89, 217);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 27);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // qLVT_DATHANGDataSet_Report
            // 
            this.qLVT_DATHANGDataSet_Report.DataSetName = "QLVT_DATHANGDataSet_Report";
            this.qLVT_DATHANGDataSet_Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNV
            // 
            this.bdsNV.DataMember = "NhanVien";
            this.bdsNV.DataSource = this.qLVT_DATHANGDataSet_Report;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.UpdateOrder = VatTu.QLVT_DATHANGDataSet_ReportTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cbMaNV
            // 
            this.cbMaNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNV, "MANV", true));
            this.cbMaNV.DataSource = this.vDSNHANVIENBindingSource;
            this.cbMaNV.DisplayMember = "MANV";
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(98, 85);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(46, 21);
            this.cbMaNV.TabIndex = 17;
            this.cbMaNV.ValueMember = "MANV";
            this.cbMaNV.SelectionChangeCommitted += new System.EventHandler(this.CbMaNV_SelectionChangeCommitted);
            this.cbMaNV.ContextMenuStripChanged += new System.EventHandler(this.CbMaNV_ContextMenuStripChanged);
            this.cbMaNV.TextChanged += new System.EventHandler(this.CbMaNV_TextChanged);
            // 
            // vDSNHANVIENBindingSource
            // 
            this.vDSNHANVIENBindingSource.DataMember = "V_DS_NHANVIEN";
            this.vDSNHANVIENBindingSource.DataSource = this.dS_NHANVIEN;
            // 
            // dS_NHANVIEN
            // 
            this.dS_NHANVIEN.DataSetName = "DS_NHANVIEN";
            this.dS_NHANVIEN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_NHANVIENTableAdapter
            // 
            this.v_DS_NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // Frpt_HoatDongCuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 270);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deTo);
            this.Controls.Add(this.deFrom);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.rbXuat);
            this.Controls.Add(this.rbNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frpt_HoatDongCuaNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoạt Động Nhân Viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frpt_HoatDongCuaNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.Frpt_HoatDongCuaNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbNhap;
        private System.Windows.Forms.RadioButton rbXuat;
        private System.Windows.Forms.TextBox txtTenNV;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.DateEdit deTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPreview;
        private QLVT_DATHANGDataSet_Report qLVT_DATHANGDataSet_Report;
        private System.Windows.Forms.BindingSource bdsNV;
        private QLVT_DATHANGDataSet_ReportTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private QLVT_DATHANGDataSet_ReportTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cbMaNV;
        private DS_NHANVIEN dS_NHANVIEN;
        private System.Windows.Forms.BindingSource vDSNHANVIENBindingSource;
        private DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter v_DS_NHANVIENTableAdapter;
    }
}