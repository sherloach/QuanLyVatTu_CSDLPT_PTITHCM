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
            this.comboBox_NV = new System.Windows.Forms.ComboBox();
            this.textBox_LoginName = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.radioButton_ChiNhanh = new System.Windows.Forms.RadioButton();
            this.radioButton_User = new System.Windows.Forms.RadioButton();
            this.button_confirm = new System.Windows.Forms.Button();
            this.dS_NHANVIEN = new VatTu.DS_NHANVIEN();
            this.vDSNHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_NHANVIENTableAdapter = new VatTu.DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_NV
            // 
            this.comboBox_NV.DataSource = this.vDSNHANVIENBindingSource;
            this.comboBox_NV.DisplayMember = "HOTEN";
            this.comboBox_NV.FormattingEnabled = true;
            this.comboBox_NV.Location = new System.Drawing.Point(297, 97);
            this.comboBox_NV.Name = "comboBox_NV";
            this.comboBox_NV.Size = new System.Drawing.Size(121, 21);
            this.comboBox_NV.TabIndex = 0;
            this.comboBox_NV.ValueMember = "MANV";
            // 
            // textBox_LoginName
            // 
            this.textBox_LoginName.Location = new System.Drawing.Point(250, 155);
            this.textBox_LoginName.Name = "textBox_LoginName";
            this.textBox_LoginName.Size = new System.Drawing.Size(242, 20);
            this.textBox_LoginName.TabIndex = 2;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(245, 222);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(242, 20);
            this.textBox_Password.TabIndex = 3;
            // 
            // radioButton_ChiNhanh
            // 
            this.radioButton_ChiNhanh.AutoSize = true;
            this.radioButton_ChiNhanh.Location = new System.Drawing.Point(250, 292);
            this.radioButton_ChiNhanh.Name = "radioButton_ChiNhanh";
            this.radioButton_ChiNhanh.Size = new System.Drawing.Size(75, 17);
            this.radioButton_ChiNhanh.TabIndex = 4;
            this.radioButton_ChiNhanh.TabStop = true;
            this.radioButton_ChiNhanh.Text = "Chi Nhanh";
            this.radioButton_ChiNhanh.UseVisualStyleBackColor = true;
            this.radioButton_ChiNhanh.CheckedChanged += new System.EventHandler(this.RadioButton_ChiNhanh_CheckedChanged);
            // 
            // radioButton_User
            // 
            this.radioButton_User.AutoSize = true;
            this.radioButton_User.Location = new System.Drawing.Point(389, 292);
            this.radioButton_User.Name = "radioButton_User";
            this.radioButton_User.Size = new System.Drawing.Size(47, 17);
            this.radioButton_User.TabIndex = 5;
            this.radioButton_User.TabStop = true;
            this.radioButton_User.Text = "User";
            this.radioButton_User.UseVisualStyleBackColor = true;
            this.radioButton_User.CheckedChanged += new System.EventHandler(this.RadioButton_User_CheckedChanged);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(336, 363);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 6;
            this.button_confirm.Text = "button1";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.Button_confirm_Click);
            // 
            // dS_NHANVIEN
            // 
            this.dS_NHANVIEN.DataSetName = "DS_NHANVIEN";
            this.dS_NHANVIEN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vDSNHANVIENBindingSource
            // 
            this.vDSNHANVIENBindingSource.DataMember = "V_DS_NHANVIEN";
            this.vDSNHANVIENBindingSource.DataSource = this.dS_NHANVIEN;
            // 
            // v_DS_NHANVIENTableAdapter
            // 
            this.v_DS_NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // FormTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.radioButton_User);
            this.Controls.Add(this.radioButton_ChiNhanh);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_LoginName);
            this.Controls.Add(this.comboBox_NV);
            this.Name = "FormTaoTaiKhoan";
            this.Text = "FormTaoTaiKhoan";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_NHANVIEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSNHANVIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_NV;
        private System.Windows.Forms.TextBox textBox_LoginName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.RadioButton radioButton_ChiNhanh;
        private System.Windows.Forms.RadioButton radioButton_User;
        private System.Windows.Forms.Button button_confirm;
        private DS_NHANVIEN dS_NHANVIEN;
        private System.Windows.Forms.BindingSource vDSNHANVIENBindingSource;
        private DS_NHANVIENTableAdapters.V_DS_NHANVIENTableAdapter v_DS_NHANVIENTableAdapter;
    }
}