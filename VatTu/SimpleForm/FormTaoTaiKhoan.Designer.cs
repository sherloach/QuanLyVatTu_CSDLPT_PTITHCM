namespace VatTu.SimpleForm
{
    partial class FormTaoTaiKhoan
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
            this.vDSNHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_NHANVIEN = new VatTu.DS_NHANVIEN();
            this.v_DS_NHANVIENTableAdapter = new VatTu.DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.radioButton_User = new System.Windows.Forms.RadioButton();
            this.radioButton_ChiNhanh = new System.Windows.Forms.RadioButton();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_LoginName = new System.Windows.Forms.TextBox();
            this.comboBox_NV = new System.Windows.Forms.ComboBox();
            this.comboBox_ChiNhanh = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.qLVT_DATHANGDataSet = new VatTu.QLVT_DATHANGDataSet();
            this.vDSPHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_PHANMANHTableAdapter = new VatTu.QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.comboBox_ChiNhanh);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button_confirm);
            this.groupBox1.Controls.Add(this.radioButton_User);
            this.groupBox1.Controls.Add(this.radioButton_ChiNhanh);
            this.groupBox1.Controls.Add(this.textBox_Password);
            this.groupBox1.Controls.Add(this.textBox_LoginName);
            this.groupBox1.Controls.Add(this.comboBox_NV);
            this.groupBox1.Location = new System.Drawing.Point(40, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Login";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VatTu.Properties.Resources.door_key;
            this.pictureBox4.Location = new System.Drawing.Point(451, 294);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VatTu.Properties.Resources.user__1_;
            this.pictureBox3.Location = new System.Drawing.Point(451, 260);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VatTu.Properties.Resources.info_user;
            this.pictureBox2.Location = new System.Drawing.Point(451, 227);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VatTu.Properties.Resources.create_login;
            this.pictureBox1.Location = new System.Drawing.Point(215, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button_confirm
            // 
            this.button_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.button_confirm.FlatAppearance.BorderSize = 0;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_confirm.Font = new System.Drawing.Font("SF Pro Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.ForeColor = System.Drawing.Color.White;
            this.button_confirm.Location = new System.Drawing.Point(94, 383);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(288, 31);
            this.button_confirm.TabIndex = 12;
            this.button_confirm.Text = "TẠO";
            this.button_confirm.UseVisualStyleBackColor = false;
            this.button_confirm.Click += new System.EventHandler(this.Button_confirm_Click_1);
            // 
            // radioButton_User
            // 
            this.radioButton_User.AutoSize = true;
            this.radioButton_User.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_User.Location = new System.Drawing.Point(277, 338);
            this.radioButton_User.Name = "radioButton_User";
            this.radioButton_User.Size = new System.Drawing.Size(52, 18);
            this.radioButton_User.TabIndex = 11;
            this.radioButton_User.TabStop = true;
            this.radioButton_User.Text = "User";
            this.radioButton_User.UseVisualStyleBackColor = true;
            // 
            // radioButton_ChiNhanh
            // 
            this.radioButton_ChiNhanh.AutoSize = true;
            this.radioButton_ChiNhanh.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_ChiNhanh.Location = new System.Drawing.Point(178, 338);
            this.radioButton_ChiNhanh.Name = "radioButton_ChiNhanh";
            this.radioButton_ChiNhanh.Size = new System.Drawing.Size(84, 18);
            this.radioButton_ChiNhanh.TabIndex = 10;
            this.radioButton_ChiNhanh.TabStop = true;
            this.radioButton_ChiNhanh.Text = "Chi Nhánh";
            this.radioButton_ChiNhanh.UseVisualStyleBackColor = true;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("SF Pro Text", 11.25F);
            this.textBox_Password.Location = new System.Drawing.Point(94, 295);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(287, 25);
            this.textBox_Password.TabIndex = 9;
            // 
            // textBox_LoginName
            // 
            this.textBox_LoginName.Font = new System.Drawing.Font("SF Pro Text", 11.25F);
            this.textBox_LoginName.Location = new System.Drawing.Point(94, 261);
            this.textBox_LoginName.Name = "textBox_LoginName";
            this.textBox_LoginName.Size = new System.Drawing.Size(287, 25);
            this.textBox_LoginName.TabIndex = 8;
            // 
            // comboBox_NV
            // 
            this.comboBox_NV.DataSource = this.vDSNHANVIENBindingSource;
            this.comboBox_NV.DisplayMember = "HOTEN";
            this.comboBox_NV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NV.Font = new System.Drawing.Font("SF Pro Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_NV.FormattingEnabled = true;
            this.comboBox_NV.Location = new System.Drawing.Point(94, 227);
            this.comboBox_NV.Name = "comboBox_NV";
            this.comboBox_NV.Size = new System.Drawing.Size(287, 26);
            this.comboBox_NV.TabIndex = 7;
            this.comboBox_NV.ValueMember = "MANV";
            // 
            // comboBox_ChiNhanh
            // 
            this.comboBox_ChiNhanh.DataSource = this.vDSPHANMANHBindingSource;
            this.comboBox_ChiNhanh.DisplayMember = "TENCN";
            this.comboBox_ChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ChiNhanh.FormattingEnabled = true;
            this.comboBox_ChiNhanh.Location = new System.Drawing.Point(95, 195);
            this.comboBox_ChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_ChiNhanh.Name = "comboBox_ChiNhanh";
            this.comboBox_ChiNhanh.Size = new System.Drawing.Size(287, 25);
            this.comboBox_ChiNhanh.TabIndex = 18;
            this.comboBox_ChiNhanh.ValueMember = "TENSERVER";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::VatTu.Properties.Resources.building;
            this.pictureBox5.Location = new System.Drawing.Point(451, 193);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // qLVT_DATHANGDataSet
            // 
            this.qLVT_DATHANGDataSet.DataSetName = "QLVT_DATHANGDataSet";
            this.qLVT_DATHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vDSPHANMANHBindingSource
            // 
            this.vDSPHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.vDSPHANMANHBindingSource.DataSource = this.qLVT_DATHANGDataSet;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // FormTaoTaiKhoan
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 493);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SF Pro Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormTaoTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Tài Khoản";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DS_NHANVIEN dS_NHANVIEN;
        private System.Windows.Forms.BindingSource vDSNHANVIENBindingSource;
        private DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter v_DS_NHANVIENTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.RadioButton radioButton_User;
        private System.Windows.Forms.RadioButton radioButton_ChiNhanh;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_LoginName;
        private System.Windows.Forms.ComboBox comboBox_NV;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ComboBox comboBox_ChiNhanh;
        private QLVT_DATHANGDataSet qLVT_DATHANGDataSet;
        private System.Windows.Forms.BindingSource vDSPHANMANHBindingSource;
        private QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
    }
}