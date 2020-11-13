namespace VatTu.SubForm
{
    partial class SubFormCTPX
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
            System.Windows.Forms.Label mAPXLabel;
            System.Windows.Forms.Label mAVTLabel;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label dONGIALabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubFormCTPX));
            this.dS = new VatTu.DS();
            this.bdsVT = new System.Windows.Forms.BindingSource(this.components);
            this.vattuTableAdapter = new VatTu.DSTableAdapters.VattuTableAdapter();
            this.tableAdapterManager = new VatTu.DSTableAdapters.TableAdapterManager();
            this.cTPXTableAdapter = new VatTu.DSTableAdapters.CTPXTableAdapter();
            this.vattuGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONGTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dONGIANumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cTPXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sOLUONGNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mAVTTextBox = new System.Windows.Forms.TextBox();
            this.mAPXTextBox = new System.Windows.Forms.TextBox();
            mAPXLabel = new System.Windows.Forms.Label();
            mAVTLabel = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            dONGIALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dONGIANumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTPXBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLUONGNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mAPXLabel
            // 
            mAPXLabel.AutoSize = true;
            mAPXLabel.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mAPXLabel.Location = new System.Drawing.Point(47, 36);
            mAPXLabel.Name = "mAPXLabel";
            mAPXLabel.Size = new System.Drawing.Size(45, 14);
            mAPXLabel.TabIndex = 0;
            mAPXLabel.Text = "Mã PX:";
            // 
            // mAVTLabel
            // 
            mAVTLabel.AutoSize = true;
            mAVTLabel.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mAVTLabel.Location = new System.Drawing.Point(47, 72);
            mAVTLabel.Name = "mAVTLabel";
            mAVTLabel.Size = new System.Drawing.Size(44, 14);
            mAVTLabel.TabIndex = 2;
            mAVTLabel.Text = "Mã VT:";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOLUONGLabel.Location = new System.Drawing.Point(47, 107);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(60, 14);
            sOLUONGLabel.TabIndex = 4;
            sOLUONGLabel.Text = "Số lượng:";
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dONGIALabel.Location = new System.Drawing.Point(47, 143);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(52, 14);
            dONGIALabel.TabIndex = 6;
            dONGIALabel.Text = "Đơn giá:";
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
            this.tableAdapterManager.CTPXTableAdapter = this.cTPXTableAdapter;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VatTu.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = this.vattuTableAdapter;
            // 
            // cTPXTableAdapter
            // 
            this.cTPXTableAdapter.ClearBeforeFill = true;
            // 
            // vattuGridControl
            // 
            this.vattuGridControl.DataSource = this.bdsVT;
            this.vattuGridControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.vattuGridControl.Location = new System.Drawing.Point(375, 0);
            this.vattuGridControl.MainView = this.gridView1;
            this.vattuGridControl.Name = "vattuGridControl";
            this.vattuGridControl.Size = new System.Drawing.Size(408, 226);
            this.vattuGridControl.TabIndex = 1;
            this.vattuGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAVT,
            this.colTENVT,
            this.colDVT,
            this.colSOLUONGTON});
            this.gridView1.GridControl = this.vattuGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Vật Tư";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dONGIALabel);
            this.groupBox1.Controls.Add(this.dONGIANumericUpDown);
            this.groupBox1.Controls.Add(sOLUONGLabel);
            this.groupBox1.Controls.Add(this.sOLUONGNumericUpDown);
            this.groupBox1.Controls.Add(mAVTLabel);
            this.groupBox1.Controls.Add(this.mAVTTextBox);
            this.groupBox1.Controls.Add(mAPXLabel);
            this.groupBox1.Controls.Add(this.mAPXTextBox);
            this.groupBox1.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 197);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // dONGIANumericUpDown
            // 
            this.dONGIANumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cTPXBindingSource, "DONGIA", true));
            this.dONGIANumericUpDown.DecimalPlaces = 2;
            this.dONGIANumericUpDown.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dONGIANumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dONGIANumericUpDown.Location = new System.Drawing.Point(108, 140);
            this.dONGIANumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.dONGIANumericUpDown.Name = "dONGIANumericUpDown";
            this.dONGIANumericUpDown.Size = new System.Drawing.Size(181, 21);
            this.dONGIANumericUpDown.TabIndex = 7;
            // 
            // cTPXBindingSource
            // 
            this.cTPXBindingSource.DataMember = "CTPX";
            this.cTPXBindingSource.DataSource = this.dS;
            // 
            // sOLUONGNumericUpDown
            // 
            this.sOLUONGNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cTPXBindingSource, "SOLUONG", true));
            this.sOLUONGNumericUpDown.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sOLUONGNumericUpDown.Location = new System.Drawing.Point(108, 104);
            this.sOLUONGNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sOLUONGNumericUpDown.Name = "sOLUONGNumericUpDown";
            this.sOLUONGNumericUpDown.Size = new System.Drawing.Size(181, 21);
            this.sOLUONGNumericUpDown.TabIndex = 5;
            this.sOLUONGNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mAVTTextBox
            // 
            this.mAVTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cTPXBindingSource, "MAVT", true));
            this.mAVTTextBox.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAVTTextBox.Location = new System.Drawing.Point(108, 68);
            this.mAVTTextBox.Name = "mAVTTextBox";
            this.mAVTTextBox.Size = new System.Drawing.Size(181, 21);
            this.mAVTTextBox.TabIndex = 3;
            // 
            // mAPXTextBox
            // 
            this.mAPXTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cTPXBindingSource, "MAPX", true));
            this.mAPXTextBox.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mAPXTextBox.Location = new System.Drawing.Point(108, 32);
            this.mAPXTextBox.Name = "mAPXTextBox";
            this.mAPXTextBox.Size = new System.Drawing.Size(181, 21);
            this.mAPXTextBox.TabIndex = 1;
            // 
            // SubFormCTPX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vattuGridControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubFormCTPX.IconOptions.SvgImage")));
            this.Name = "SubFormCTPX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Phiếu Xuất";
            this.Load += new System.EventHandler(this.SubFormCTPX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vattuGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dONGIANumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTPXBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLUONGNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DS dS;
        private System.Windows.Forms.BindingSource bdsVT;
        private DSTableAdapters.VattuTableAdapter vattuTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl vattuGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DSTableAdapters.CTPXTableAdapter cTPXTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTENVT;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONGTON;
        private System.Windows.Forms.BindingSource cTPXBindingSource;
        private System.Windows.Forms.NumericUpDown dONGIANumericUpDown;
        private System.Windows.Forms.NumericUpDown sOLUONGNumericUpDown;
        private System.Windows.Forms.TextBox mAVTTextBox;
        private System.Windows.Forms.TextBox mAPXTextBox;
    }
}