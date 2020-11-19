namespace VatTu.SubForm
{
    partial class FormChuyenCN
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
            this.comboBox_ChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_ChiNhanh
            // 
            this.comboBox_ChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboBox_ChiNhanh.FormattingEnabled = true;
            this.comboBox_ChiNhanh.Items.AddRange(new object[] {
            "Chi Nhánh 1 - TP.HCM",
            "Chi Nhánh 2 - HÀ NỘI"});
            this.comboBox_ChiNhanh.Location = new System.Drawing.Point(310, 120);
            this.comboBox_ChiNhanh.Name = "comboBox_ChiNhanh";
            this.comboBox_ChiNhanh.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ChiNhanh.TabIndex = 0;
            this.comboBox_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button_confirm
            // 
            this.button_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_confirm.Location = new System.Drawing.Point(326, 216);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 2;
            this.button_confirm.Text = "button1";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.Button_confirm_Click);
            // 
            // FormChuyenCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ChiNhanh);
            this.Name = "FormChuyenCN";
            this.Text = "FormChuyenCN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_confirm;
    }
}