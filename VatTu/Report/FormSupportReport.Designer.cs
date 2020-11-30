namespace VatTu.Report
{
    partial class FormSupportReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupportReport));
            this.label1 = new System.Windows.Forms.Label();
            this.button_Preview = new System.Windows.Forms.Button();
            this.button_Print = new System.Windows.Forms.Button();
            this.comboBox_ChiNhanh = new System.Windows.Forms.ComboBox();
            this.vDSPHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLVT_DATHANGDataSet1 = new VatTu.QLVT_DATHANGDataSet();
            this.v_DS_PHANMANHTableAdapter1 = new VatTu.QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(140, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo";
            // 
            // button_Preview
            // 
            this.button_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_Preview.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Preview.Location = new System.Drawing.Point(87, 106);
            this.button_Preview.Margin = new System.Windows.Forms.Padding(2);
            this.button_Preview.Name = "button_Preview";
            this.button_Preview.Size = new System.Drawing.Size(114, 28);
            this.button_Preview.TabIndex = 1;
            this.button_Preview.Text = "Preview";
            this.button_Preview.UseVisualStyleBackColor = true;
            this.button_Preview.Click += new System.EventHandler(this.Button_Preview_Click);
            // 
            // button_Print
            // 
            this.button_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_Print.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Print.Location = new System.Drawing.Point(205, 106);
            this.button_Print.Margin = new System.Windows.Forms.Padding(2);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(119, 28);
            this.button_Print.TabIndex = 2;
            this.button_Print.Text = "Print";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.Button_Print_Click);
            // 
            // comboBox_ChiNhanh
            // 
            this.comboBox_ChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboBox_ChiNhanh.DataSource = this.vDSPHANMANHBindingSource;
            this.comboBox_ChiNhanh.DisplayMember = "TENCN";
            this.comboBox_ChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ChiNhanh.Font = new System.Drawing.Font("SF Pro Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ChiNhanh.FormattingEnabled = true;
            this.comboBox_ChiNhanh.Location = new System.Drawing.Point(87, 64);
            this.comboBox_ChiNhanh.Name = "comboBox_ChiNhanh";
            this.comboBox_ChiNhanh.Size = new System.Drawing.Size(237, 26);
            this.comboBox_ChiNhanh.TabIndex = 9;
            this.comboBox_ChiNhanh.ValueMember = "TENSERVER";
            this.comboBox_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ChiNhanh_SelectedIndexChanged);
            // 
            // vDSPHANMANHBindingSource
            // 
            this.vDSPHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.vDSPHANMANHBindingSource.DataSource = this.qLVT_DATHANGDataSet1;
            // 
            // qLVT_DATHANGDataSet1
            // 
            this.qLVT_DATHANGDataSet1.DataSetName = "QLVT_DATHANGDataSet";
            this.qLVT_DATHANGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHTableAdapter1
            // 
            this.v_DS_PHANMANHTableAdapter1.ClearBeforeFill = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(68, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // FormSupportReport
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 168);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBox_ChiNhanh);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.button_Preview);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.Image = global::VatTu.Properties.Resources.dathang;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSupportReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSupportReport_FormClosing);
            this.Load += new System.EventHandler(this.FormSupportReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Preview;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.ComboBox comboBox_ChiNhanh;
        private QLVT_DATHANGDataSet qLVT_DATHANGDataSet;
        private QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLVT_DATHANGDataSet qLVT_DATHANGDataSet1;
        private System.Windows.Forms.BindingSource vDSPHANMANHBindingSource;
        private QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}