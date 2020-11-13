namespace VatTu.SubForm
{
    partial class SubFormCTDDH
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
            System.Windows.Forms.Label dONGIALabel;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label mAVTLabel;
            System.Windows.Forms.Label masoDDHLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubFormCTDDH));
            this.dS = new VatTu.DS();
            this.bdsVT = new System.Windows.Forms.BindingSource(this.components);
            this.vattuTableAdapter = new VatTu.DSTableAdapters.VattuTableAdapter();
            this.tableAdapterManager = new VatTu.DSTableAdapters.TableAdapterManager();
            this.vattuGridControl = new DevExpress.XtraGrid.GridControl();
            this.gvVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONGTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bdsCTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDH = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new VatTu.DSTableAdapters.DatHangTableAdapter();
            this.cTDDHTableAdapter = new VatTu.DSTableAdapters.CTDDHTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numDG = new System.Windows.Forms.NumericUpDown();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            dONGIALabel = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            mAVTLabel = new System.Windows.Forms.Label();
            masoDDHLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            this.SuspendLayout();
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dONGIALabel.Location = new System.Drawing.Point(36, 141);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(57, 15);
            dONGIALabel.TabIndex = 15;
            dONGIALabel.Text = "Đơn giá:";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOLUONGLabel.Location = new System.Drawing.Point(36, 107);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(66, 15);
            sOLUONGLabel.TabIndex = 13;
            sOLUONGLabel.Text = "Số lượng:";
            // 
            // mAVTLabel
            // 
            mAVTLabel.AutoSize = true;
            mAVTLabel.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mAVTLabel.Location = new System.Drawing.Point(36, 72);
            mAVTLabel.Name = "mAVTLabel";
            mAVTLabel.Size = new System.Drawing.Size(49, 15);
            mAVTLabel.TabIndex = 11;
            mAVTLabel.Text = "Mã VT:";
            // 
            // masoDDHLabel
            // 
            masoDDHLabel.AutoSize = true;
            masoDDHLabel.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            masoDDHLabel.Location = new System.Drawing.Point(36, 36);
            masoDDHLabel.Name = "masoDDHLabel";
            masoDDHLabel.Size = new System.Drawing.Size(60, 15);
            masoDDHLabel.TabIndex = 9;
            masoDDHLabel.Text = "Mã DDH:";
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsVT
            // 
            this.bdsVT.DataMember = "Vattu";
            this.bdsVT.DataSource = this.dS;
            // 
            // vattuTableAdapter
            // 
            this.vattuTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VatTu.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = this.vattuTableAdapter;
            // 
            // vattuGridControl
            // 
            this.vattuGridControl.DataSource = this.bdsVT;
            this.vattuGridControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.vattuGridControl.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vattuGridControl.Location = new System.Drawing.Point(375, 0);
            this.vattuGridControl.MainView = this.gvVT;
            this.vattuGridControl.Name = "vattuGridControl";
            this.vattuGridControl.Size = new System.Drawing.Size(408, 226);
            this.vattuGridControl.TabIndex = 1;
            this.vattuGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVT});
            // 
            // gvVT
            // 
            this.gvVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAVT,
            this.colTENVT,
            this.colDVT,
            this.colSOLUONGTON});
            this.gvVT.GridControl = this.vattuGridControl;
            this.gvVT.Name = "gvVT";
            this.gvVT.OptionsView.ShowGroupPanel = false;
            this.gvVT.OptionsView.ShowViewCaption = true;
            this.gvVT.ViewCaption = "Vật Tư";
            this.gvVT.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GvVT_RowClick);
            // 
            // colMAVT
            // 
            this.colMAVT.Caption = "Mã vật tư";
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 0;
            // 
            // colTENVT
            // 
            this.colTENVT.Caption = "Tên vật tư";
            this.colTENVT.FieldName = "TENVT";
            this.colTENVT.Name = "colTENVT";
            this.colTENVT.Visible = true;
            this.colTENVT.VisibleIndex = 1;
            // 
            // colDVT
            // 
            this.colDVT.Caption = "Đơn vị tính";
            this.colDVT.FieldName = "DVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.Visible = true;
            this.colDVT.VisibleIndex = 2;
            // 
            // colSOLUONGTON
            // 
            this.colSOLUONGTON.Caption = "Số lượng tồn";
            this.colSOLUONGTON.FieldName = "SOLUONGTON";
            this.colSOLUONGTON.Name = "colSOLUONGTON";
            this.colSOLUONGTON.Visible = true;
            this.colSOLUONGTON.VisibleIndex = 3;
            // 
            // bdsCTDDH
            // 
            this.bdsCTDDH.DataMember = "FK_CTDDH_DatHang";
            this.bdsCTDDH.DataSource = this.bdsDH;
            // 
            // bdsDH
            // 
            this.bdsDH.DataMember = "DatHang";
            this.bdsDH.DataSource = this.dS;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dONGIALabel);
            this.groupBox1.Controls.Add(this.numDG);
            this.groupBox1.Controls.Add(sOLUONGLabel);
            this.groupBox1.Controls.Add(this.numSL);
            this.groupBox1.Controls.Add(mAVTLabel);
            this.groupBox1.Controls.Add(this.txtMaVT);
            this.groupBox1.Controls.Add(masoDDHLabel);
            this.groupBox1.Controls.Add(this.txtMaDDH);
            this.groupBox1.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // numDG
            // 
            this.numDG.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsCTDDH, "DONGIA", true));
            this.numDG.DecimalPlaces = 2;
            this.numDG.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDG.Location = new System.Drawing.Point(108, 140);
            this.numDG.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numDG.Name = "numDG";
            this.numDG.Size = new System.Drawing.Size(181, 21);
            this.numDG.TabIndex = 16;
            // 
            // numSL
            // 
            this.numSL.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsCTDDH, "SOLUONG", true));
            this.numSL.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSL.Location = new System.Drawing.Point(108, 104);
            this.numSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(181, 21);
            this.numSL.TabIndex = 14;
            this.numSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtMaVT
            // 
            this.txtMaVT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCTDDH, "MAVT", true));
            this.txtMaVT.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVT.Location = new System.Drawing.Point(108, 68);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.ReadOnly = true;
            this.txtMaVT.Size = new System.Drawing.Size(181, 21);
            this.txtMaVT.TabIndex = 12;
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCTDDH, "MasoDDH", true));
            this.txtMaDDH.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDDH.Location = new System.Drawing.Point(108, 32);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.ReadOnly = true;
            this.txtMaDDH.Size = new System.Drawing.Size(181, 21);
            this.txtMaDDH.TabIndex = 10;
            // 
            // SubFormCTDDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vattuGridControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubFormCTDDH.IconOptions.SvgImage")));
            this.Name = "SubFormCTDDH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Đơn Đặt Hàng";
            this.Load += new System.EventHandler(this.SubFormCTDDH_Load);
            this.Shown += new System.EventHandler(this.SubFormCTDDH_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DS dS;
        private System.Windows.Forms.BindingSource bdsVT;
        private DSTableAdapters.VattuTableAdapter vattuTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl vattuGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVT;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTENVT;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONGTON;
        private System.Windows.Forms.BindingSource bdsDH;
        private DSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTDDH;
        private DSTableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDG;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.TextBox txtMaDDH;
    }
}